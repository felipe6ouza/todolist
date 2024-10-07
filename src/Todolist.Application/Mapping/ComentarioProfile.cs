using AutoMapper;
using Todolist.Application.UseCases.Queries.ObterDetalhesTarefa;
using Todolist.Domain.Entities;

namespace Todolist.Application.Mapping
{
    internal class ComentarioProfile : Profile
    {
        public ComentarioProfile()
        {
            CreateMap<Comentario, ComentarioViewModel>()
           .ForMember(dest => dest.AutorNome, opt => opt.MapFrom(src => src.Autor.Nome));
        }
    }
}
