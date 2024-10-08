using AutoMapper;
using Todolist.Application.ViewModel;
using Todolist.Domain.Entities;

namespace Todolist.Application.ObjectMapping
{
    internal class ComentarioProfile : Profile
    {
        public ComentarioProfile()
        {
            CreateMap<Comentario, ComentarioViewModel>()
           .ForMember(dest => dest.AutorNome, opt => opt.MapFrom(src => src.Autor!.Nome));
        }
    }
}
