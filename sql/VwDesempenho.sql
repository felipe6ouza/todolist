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
