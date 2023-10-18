using AutoMapper;
using MicroUniverso.AprovacaoNotasCompra.Application.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Application.Models.Autorizacao;
using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Exceptions;
using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services;
using MicroUniverso.AprovacaoNotasCompra.Infra.Data;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Services
{
    public class NotaCompraApplication : INotaCompraApplication
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly INotaCompraService _notaCompraService;
        private readonly IUnitOfWork<ApplicationContext> _unitOfWork;
        private readonly IHistoricoAprovacaoService _historicoAprovacaoService;
        private readonly IFaixaValorAprovacaoService _faixaValorAprovacaoService;

        public NotaCompraApplication(IMapper mapper, IUsuarioService usuarioService, INotaCompraService notaCompraService, IUnitOfWork<ApplicationContext> unitOfWork, IHistoricoAprovacaoService historicoAprovacaoService, IFaixaValorAprovacaoService faixaValorAprovacaoService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
            _notaCompraService = notaCompraService;
            _unitOfWork = unitOfWork;
            _historicoAprovacaoService = historicoAprovacaoService;
            _faixaValorAprovacaoService = faixaValorAprovacaoService;
        }

        public async Task<IEnumerable<NotaCompraListaModel>> ObterNotasPendentesAprovacao(Guid usuarioId)
        {
            var usuario = await _usuarioService.ObterPorId(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var notasPendentes = await _notaCompraService.ObterNotasPendentesAprovacao();

            return _mapper.Map<IEnumerable<NotaCompraListaModel>>(notasPendentes);

            //TODO: falta implemnentar os filtros e regras para consulta
        }


        public async Task AprovarNotaCompra(Guid notaCompraId, Guid usuarioId)
        {
            await ValidaUsuario(usuarioId);
            var notaCompra = await ValidaNotaCompra(notaCompraId);
            var historicoAprovacoes = await ValidaHistoricoAprovacao(notaCompraId, usuarioId);
            var faixasValor = await _faixaValorAprovacaoService.ObterTodasFaixas();

            int vistosNecessariosParaAprovar = 0;
            int aprovacoesNecessariasParaAprovar = 0;

            foreach (var faixa in faixasValor)
            {
                if (notaCompra!.ValorTotal >= faixa.ValorMinimo && notaCompra.ValorTotal <= faixa.ValorMaximo)
                {
                    vistosNecessariosParaAprovar = faixa.VistosNecessarios;
                    aprovacoesNecessariasParaAprovar = faixa.AprovacoesNecessarias;
                    break;
                }
            }

            if (aprovacoesNecessariasParaAprovar == 0)
            {
                throw new ErrorValidationException("Não é necessário aprovação para a nota de compra");
            }

            int vistos = 0;
            int aprovacoes = 0;

            foreach (var historico in historicoAprovacoes)
            {
                if (historico.NotaCompraId == notaCompraId && historico.Operacao == PapelEnum.Visto)
                    vistos++;

                if (historico.NotaCompraId == notaCompraId && historico.Operacao == PapelEnum.Aprovacao)
                    aprovacoes++;
            }

            if (vistos < vistosNecessariosParaAprovar)
            {
                throw new ErrorValidationException("Falta visto para a Nota de compra");
            }
            else if (aprovacoes < aprovacoesNecessariasParaAprovar)
            {
                aprovacoesNecessariasParaAprovar--;
                if (aprovacoesNecessariasParaAprovar == aprovacoes)                
                    AtualizarStatus(notaCompra, StatusEnum.Aprovada);

                await InserirHistoricoAprovacao(notaCompraId, usuarioId, PapelEnum.Aprovacao);
                await _unitOfWork.SaveChanges();
                await Task.CompletedTask;
            }
            else
            {
                throw new ErrorValidationException("Já foi registrado a aprovação da nota de compra");
            }

            //TODO: falta separar as validações em classe de validação para deixar o código mais limpo
        }

        public async Task RegistrarVisto(Guid notaCompraId, Guid usuarioId)
        {
            await ValidaUsuario(usuarioId);
            var notaCompra = await ValidaNotaCompra(notaCompraId);

            var historicoAprovacoes = await _historicoAprovacaoService.ObterLista();

            if (historicoAprovacoes.Any(x => x.NotaCompraId == notaCompraId && x.UsuarioId == usuarioId & x.Operacao == PapelEnum.Visto))
            {
                throw new ErrorValidationException("Usuário já registrou o visto da nota de compra");
            }

            var faixasValor = await _faixaValorAprovacaoService.ObterTodasFaixas();
            int vistosNecessariosParaAprovar = 0;

            foreach (var faixa in faixasValor)
            {
                if (notaCompra!.ValorTotal >= faixa.ValorMinimo && notaCompra.ValorTotal <= faixa.ValorMaximo)
                {
                    vistosNecessariosParaAprovar = faixa.VistosNecessarios;
                    break;
                }
            }

            int vistos = 0;

            foreach (var historico in historicoAprovacoes)
            {
                if (historico.NotaCompraId == notaCompraId && historico.Operacao == PapelEnum.Visto)
                    vistos++;
            }

            if (vistos < vistosNecessariosParaAprovar)
            {
                AtualizarStatus(notaCompra, StatusEnum.Pendente);
                await InserirHistoricoAprovacao(notaCompraId, usuarioId, PapelEnum.Visto);
                await _unitOfWork.SaveChanges();
                await Task.CompletedTask;
            }
            else
            {
                throw new ErrorValidationException("Já foi registrado o visto da nota de compra");
            }

            //TODO: falta separar as validações em classe de validação para deixar o código mais limpo
        }

        private async Task<IEnumerable<HistoricoAprovacao>> ValidaHistoricoAprovacao(Guid notaCompraId, Guid usuarioId)
        {
            var historicoAprovacoes = await _historicoAprovacaoService.ObterLista();

            if (historicoAprovacoes.Any(x => x.NotaCompraId == notaCompraId && x.UsuarioId == usuarioId & x.Operacao == PapelEnum.Aprovacao))
            {
                throw new ErrorValidationException("Usuário já registrou a aprovação da nota de compra");
            }

            return historicoAprovacoes;
        }

        private async Task<NotaCompra?> ValidaNotaCompra(Guid notaCompraId)
        {
            var notaCompra = await _notaCompraService.ObterNotaPorId(notaCompraId);
            if (notaCompra == null)
            {
                throw new ErrorValidationException("Nota de compra não encontrada");
            }

            return notaCompra;
        }

        private async Task ValidaUsuario(Guid usuarioId)
        {
            var usuario = await _usuarioService.ObterPorId(usuarioId);
            if (usuario == null)
            {
                throw new ErrorValidationException("Usuário não encontrado");
            }
        }

        private static void AtualizarStatus(NotaCompra? notaCompra, StatusEnum status)
        {
            notaCompra!.AtualizarStatus(status);
        }

        private async Task InserirHistoricoAprovacao(Guid notaCompraId, Guid usuarioId, PapelEnum visto)
        {
            var historicoAprovacao = new HistoricoAprovacao(DateTime.Now, usuarioId, notaCompraId, visto);
            await _historicoAprovacaoService.Inserir(historicoAprovacao);
        }
    }
}
