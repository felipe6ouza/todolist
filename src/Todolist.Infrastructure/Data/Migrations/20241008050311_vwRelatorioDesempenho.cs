using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todolist.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
#pragma warning disable IDE1006 // Naming Styles
    public partial class vwRelatorioDesempenho : Migration
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER VIEW vwRelatorioDesempenho AS 
            SELECT 
                u.Id AS ResponsavelId,
                u.Nome AS ResponsavelNome,
                COUNT(t.Id) AS TotalTarefasConcluidas,
                AVG(DATEDIFF(day, t.DataInicial, t.DataFinal)) AS MediaDiasConclusao
            FROM 
                Tarefas t
            JOIN 
                Usuarios u ON t.ResponsavelId = u.Id 
            WHERE 
                t.StatusTarefa = 1 -- Status concluído
                AND t.DataFinal >= DATEADD(day, -30, GETDATE())
            GROUP BY 
                u.Id, u.Nome;
        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vwRelatorioDesempenho;");
        }
    }
}
