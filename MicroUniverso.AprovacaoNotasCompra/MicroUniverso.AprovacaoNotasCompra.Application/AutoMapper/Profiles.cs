using AutoMapper;
using MicroUniverso.AprovacaoNotasCompra.Application.Core.Extensions;
using MicroUniverso.AprovacaoNotasCompra.Application.Models.Autorizacao;
using MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Application.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Usuario, UsuarioListaModel>()
                .ForMember(x => x.Papel, o => o.MapFrom(x => EnumExtensions.GetSafeEnumAnswer(x.Papel)));

            CreateMap<NotaCompra, NotaCompraListaModel>();
                //.ForMember(x => x.Status, o => o.MapFrom(x => EnumExtensions.GetSafeEnumAnswer(x.Status)));
        }
    }
}
