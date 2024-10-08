﻿using Todolist.Domain.Entities;

namespace Todolist.Application.ViewModel
{

    public class ComentarioViewModel
    {
        public int Id { get; private set; }
        public  string? Descricao { get; private set; }
        public int AutorId { get; private set; }
        public required string AutorNome { get; set; }
    }
    public class DetalhesTarefaViewModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public int StatusTarefa { get; set; }
        public int ProjetoId { get; set; }
        public string? ProjetoNome { get; set; }
        public int AutorId { get; set; }
        public string? AutorNome { get; set; }
        public int? ResponsavelId { get; set; }
        public string? ResponsavelNome { get; set; }

        public List<ComentarioViewModel>? Comentarios { get; set; }
    }
}
