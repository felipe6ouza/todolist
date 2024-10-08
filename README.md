# Todolist
Uma simples API de Lista de Tarefas

## Executando o Projeto

### Requisitos
- Docker Compose

### Instruções

1. **Navegue até a raiz do projeto:**

   Acesse a pasta onde está localizado o arquivo `docker-compose.yml`:

2. **Construa e inicie os containers**:

```
docker-compose up --build
```
3. **Acesse a documentação da API**:
Acesse a documentação Swagger da API em seu navegador ou faça requests por ferramentas como o Postman/Insomnia:
```
http://localhost:8080/swagger/index.html
```

## Observações:

- Dois usuários de teste foram criados via Migration do EF: um com a função de 'colaborador' e outro com a função de 'gerente'. Você pode obter as informações deles requisitando o endpoint /api/Usuario/todos.

- O container do SQL Server foi configurado para utilizar a porta 1433.

Tecnologias e Bibliotecas Utilizadas:

- .NET 8
- EF Core
- MediatR
- FluentValidation
- SQL Server



### 2ª Fase: Perguntas para o Product Owner (PO)

Na segunda fase, visando o refinamento para futuras implementações ou melhorias, algumas questões que eu levantaria para o PO seriam:

1. **Anexos em Tarefas**: Faz sentido permitir que os usuários adicionem anexos (arquivos, links, etc.) diretamente nas tarefas? Se sim, há algum limite de tamanho ou tipo de arquivo a ser considerado?
   
2. **Notificações de Alerta**: Seria interessante criar um sistema de notificações automáticas para alertar os usuários sobre prazos próximos, tarefas atrasadas ou alterações nas tarefas? Se sim, como os usuários devem ser notificados (e-mail, push notifications, etc.)?

3. **Associação de Cores a Projetos**: Seria relevante associar cores aos projetos para facilitar a visualização e identificação rápida pelos usuários? 

4. **Esquema de Subtarefas**: Faz sentido permitir a criação de subtarefas dentro de uma tarefa principal? 

### 3ª Fase: Possíveis Melhorias no Projeto

Na terceira fase, alguns pontos de melhoria e sugestões que eu implementaria no projeto seriam:

1. **Cache para Otimização de Consultas**:
   - Adicionar um **provedor de cache**, como o Redis, para armazenar resultados de consultas frequentes. Isso reduziria a carga no banco de dados e aumentaria a performance geral da aplicação.

2. **Event Sourcing para Histórico de Alterações**:
   - Considerar a adoção de estratégias de **Event Sourcing** para o gerenciamento do histórico de alterações. Ao invés de apenas salvar snapshots do estado atual de uma tarefa, seria possível armazenar os eventos que causaram essas mudanças. Isso proporcionaria um histórico detalhado e reversível, além de melhor rastreabilidade das operações realizadas.

3.  **Monitoramente e Logging**:
   - Implementar ferramentas de monitoramento (como Prometheus, Grafana) e centralização de logs (como ELK) para facilitar o diagnóstico e monitoramento da aplicação em produção.
4. **Autorização de Relatório**
 A verificação de permissões para acessar os relatórios seria baseada em Roles/Claims, extraídas a partir do token da requisição e aplicadas durante o processo de autenticação e autorização no endpoint.

5. **Mais Testes**
- Implementaria **Testes de Carga** para medir a capacidade de throughput da aplicação, garantindo que ela possa lidar com um grande volume de requets.
- Aumentaria a cobertura de testes de unidade para todos os casos de uso, com foco tanto em testes de entidades quanto de handlers. (Reconheço que poderia ter entregue uma maior cobertura até aqui. Nos testes que existentes, minha intenção foi demonstrar como abordaria a implementação de testes para os dois cenários distintos).

