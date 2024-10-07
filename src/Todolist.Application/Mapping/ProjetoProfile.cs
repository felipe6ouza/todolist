using AutoMapper;
using Todolist.Application.UseCases.Queries.ListarProjetosUsuario;
using Todolist.Domain.Aggregates;

namespace Todolist.Application.Mapping
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<Projeto, ProjetoViewModel>()
                .ForMember(dest => dest.Favorito, opt => opt.MapFrom(src => src.Status.Favorito))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Status.Ativo));
        }
    }

}
