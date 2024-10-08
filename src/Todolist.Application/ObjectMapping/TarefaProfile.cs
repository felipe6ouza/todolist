using AutoMapper;
using Todolist.Application.ViewModel;
using Todolist.Domain.Aggregates;

namespace Todolist.Application.ObjectMapping
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, ResumoTarefaViewModel>()
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.TimelineTarefa!.DataInicial))
                .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.TimelineTarefa!.DataFinal))
                .ForMember(dest => dest.QuantidadeComentarios, opt => opt.MapFrom(src => src.Comentarios.Count()));

            CreateMap<Tarefa, DetalhesTarefaViewModel>()
               .ForMember(dest => dest.AutorNome, opt => opt.MapFrom(src => src.Autor.Nome))
               .ForMember(dest => dest.ProjetoNome, opt => opt.MapFrom(src => src.Projeto.Nome))
               .ForMember(dest => dest.ResponsavelNome, opt => opt.MapFrom(src => src.Responsavel != null ? src.Responsavel.Nome : null))
               .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.TimelineTarefa!.DataInicial))
               .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.TimelineTarefa!.DataFinal))
               .ForMember(dest => dest.Comentarios, opt => opt.MapFrom(src => src.Comentarios));

           
        }
    }
}
