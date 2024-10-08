﻿using Todolist.Domain.Entities;
using Todolist.Domain.Enum;
using Todolist.Domain.Shared;
using Todolist.Domain.ValueObjects;

namespace Todolist.Domain.Aggregates
{
    public class Tarefa : IAggregateRoot
    {
        public int Id { get; private set; }
        public int ProjetoId { get; private set; }
        public int PrioridadeId { get; private set; }  
        public int? AutorId { get; private set; }
        public int? ResponsavelId { get; private set; }
        public string? Nome { get; private set; } 
        public string? Descricao { get; private set; } 
        public int StatusTarefa { get; private set; }
        public TimelineTarefa? TimelineTarefa { get; private set; }
        public TipoPrioridade? Prioridade { get; private set; }


        public Projeto? Projeto { get; private set; }
        public Usuario? Autor { get; private set; }
        public Usuario? Responsavel { get; private set; }

        private readonly List<Comentario> _comentarios = [];
        public IReadOnlyCollection<Comentario> Comentarios => _comentarios;


        protected Tarefa() { }

        public Tarefa(string nome, int projetoId, int prioridadeId, int autorId, TimelineTarefa timelineTarefa, string? descricao, int? responsavelId = null)
        {
            Nome = nome;
            ProjetoId = projetoId;
            PrioridadeId = prioridadeId;
            AutorId = autorId;
            TimelineTarefa = timelineTarefa;
            Descricao = descricao;
            StatusTarefa = (int)StatusTarefaEnum.Pendente;
            ResponsavelId = responsavelId;
        }

        public Comentario AdicionarComentario(string descricao, int usuarioId)
        {
            var comentario = new Comentario(this.Id, usuarioId, descricao);
            _comentarios.Add(comentario);

            return comentario;
        }

        public void AtualizarPrioridade(int prioridadeId)
        {
            PrioridadeId = prioridadeId;
        }

        public void AtualizarNome(string? nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                Nome = nome;
            }
        }
      

        public void AtualizarDescricao(string? descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
            {
                Descricao = descricao;
            }
        }

        public void AtualizarDataFinal(DateTime? dataFinal)
        {
            if (dataFinal.HasValue)
            {
                TimelineTarefa?.AtualizarDataFinal((DateTime)dataFinal);
            }
        }

        public void AtualizarResponsavel(int? responsavelId)
        {
            if (responsavelId.HasValue)
            {
                ResponsavelId = responsavelId;
            }
        }

        public void AtualizarStatus(int? status)
        {
            if (status.HasValue)
            {
                StatusTarefa = (int)status;
            }
        }
    }

}
