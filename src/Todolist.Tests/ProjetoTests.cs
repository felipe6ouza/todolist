using Bogus;
using Moq;
using Todolist.Application.UseCases.Commands.DeletarProjeto;
using Todolist.Domain.Aggregates;
using Todolist.Domain.Repositories;
using Todolist.Domain.Shared;

namespace Todolist.Tests
{

    public class ProjetoTests
    {

        private readonly Mock<IProjetoRepository> _projetoRepositoryMock;
        private readonly DeletarProjetoHandler _handler;
        private readonly Faker _faker;

        public ProjetoTests()
        {
            _projetoRepositoryMock = new Mock<IProjetoRepository>();
            _handler = new DeletarProjetoHandler(_projetoRepositoryMock.Object);
            _faker = new Faker();
        }
        private const int NUMERO_MAXIMO_TAREFAS = 20;

        [Fact]
        public void AdicionarTarefa_DeveLancarExcecao_QuandoLimiteDeTarefasExcedido()
        {
            // Arrange
            var projeto = new Projeto();

            for (int i = 0; i < NUMERO_MAXIMO_TAREFAS; i++)
            {
                var nomeTarefa = _faker.Lorem.Sentence();
                var prioridadeId = _faker.Random.Int(1, 5);
                var autorId = _faker.Random.Int(1, 10);
                var dataFinal = _faker.Date.Future();
                var descricao = _faker.Lorem.Paragraph();
                projeto.AdicionarTarefa(nomeTarefa, prioridadeId, autorId, dataFinal, descricao);
            }

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
                projeto.AdicionarTarefa("Tarefa 21", 1, 1, DateTime.Now.AddDays(1), "Descrição"));

            // Assert
            Assert.Equal("Numero máximo de Tarefas Excedido", exception.Message);
        }


        [Fact]
        public async Task DeletarProjetoHandler_DeveFalhar_QuandoExistemTarefasPendentes()
        {
            // Arrange
            var projetoId = _faker.Random.Int(1, 100);
            var projeto = new Projeto();

            projeto.AdicionarTarefa("Tarefa 1", 1, 1, DateTime.Now.AddDays(1), "Descrição da tarefa");

            _projetoRepositoryMock.Setup(repo => repo.ObterPorId(projetoId))
                .ReturnsAsync(projeto);

            var command = new DeletarProjetoCommand { ProjetoId = projetoId };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailed);
            Assert.Equal("O Projeto não pode ser removido porque existem tarefas associadas", result.Errors[0].Message);
        }

    }



}
