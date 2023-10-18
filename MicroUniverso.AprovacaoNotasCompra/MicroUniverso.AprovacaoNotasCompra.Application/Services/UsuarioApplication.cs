using AutoMapper;
using MicroUniverso.AprovacaoNotasCompra.Application.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario;
using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Exceptions;
using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services;
using MicroUniverso.AprovacaoNotasCompra.Infra.Data;
using System.ComponentModel.DataAnnotations;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Services
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuariosService;
        private readonly IUnitOfWork<ApplicationContext> _unitOfWork;

        public UsuarioApplication(IMapper mapper, IUsuarioService usuariosService, IUnitOfWork<ApplicationContext> unitOfWork)
        {
            _mapper = mapper;
            _usuariosService = usuariosService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UsuarioListaModel>> ObterLista()
        {
            var usuarios = await _usuariosService.ObterLista();
            var listaUsuarios = _mapper.Map<IEnumerable<UsuarioListaModel>>(usuarios);

            return listaUsuarios;
        }

        public async Task<UsuarioListaModel> ObterPorId(Guid usuarioId)
        {
            var usuario = await _usuariosService.ObterPorId(usuarioId);

            if (usuario == null)
            {
                return null!;
            }
            return _mapper.Map<UsuarioListaModel>(usuario); ;
        }

        public async Task Inserir(UsuarioCriacaoModel usuarioModel)
        {
            var usuario = new Usuario(usuarioModel.Login, usuarioModel.Senha, usuarioModel.Papel, usuarioModel.ValorMinimo, usuarioModel.ValorMaximo);

            if (!usuario.EhValido())
            {
                string? mensagem = usuario.MensagemValidacao();
                throw new ErrorValidationException(mensagem ?? "Erro não identificado ao criar o Usuário");
            }

            await _usuariosService.Inserir(usuario);
            await _unitOfWork.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task Atualizar(Guid idUsuario, UsuarioAtualizacaoModel usuarioModel)
        {
            var usuario = await _usuariosService.ObterPorId(idUsuario);

            if (usuario == null)
            {
                throw new ErrorValidationException("Usuário não encontrado");
            }

            usuario.AtualizarLogin(usuarioModel.Login!);
            usuario.AtualizarPapel(usuarioModel.Papel);
            usuario.AtualizarValorMinimo(usuarioModel.ValorMinimo);
            usuario.AtualizarValorMaximo(usuarioModel.ValorMaximo);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
            await _unitOfWork.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task Excluir(Guid usuarioId)
        {
            var usuario = await _usuariosService.ObterPorId(usuarioId);

            if (usuario is null)
            {
                throw new ValidationException("Não foi possível encontrar o usuário");
            }

            await _usuariosService.Excluir(usuario);            
            await Task.CompletedTask;
        }
    }
}
