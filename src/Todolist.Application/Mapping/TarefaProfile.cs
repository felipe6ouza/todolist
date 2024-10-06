using AutoMapper;
using Todolist.Application.UseCases.Queries.ListarTarefasProjeto;
using Todolist.Domain.Aggregates;

namespace Todolist.Application.Mapping
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaViewModel>()
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.TimelineTarefa!.DataInicial))
                .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.TimelineTarefa!.DataFinal))
                .ForMember(dest => dest.QuantidadeComentarios, opt => opt.MapFrom(src => src.Comentarios.Count()));

        }
    }
}
