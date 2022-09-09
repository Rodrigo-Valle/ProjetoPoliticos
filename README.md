<div align="center"><h1>ProjetoAPI</h1></div>

<p> Projeto criado utilizando a plataforma DotNet, simulando um sistema politico. São duas APIs, uma de Admin onde são realizados os CRUDS, e outra para usuario, que consome a API de admin e realiza algumas consultas disponiveis.</p>

<p> As APIs rodam nas portas:</p>


- AdminAPI: https://localhost:5002 e http://localhost:5003

- UserAPI: http://localhost:5000 e http://localhost:5001

obs: Se ocorrer o erro: 
> System.Net.Http.HttpRequestException: The SSL connection could not be established, see inner exception.

Efetue o comando: `dotnet dev-certs https --trust` para liberar o acesso sem uso de certificado SSL pelo localhost.

A AdminAPI só pode ser acessada por usuario cadastrado como administrador, para isso já utilize as seguintes credenciais para login:

- Usuario: Admin

- Senha: Gft2021

Ao rodar a aplicação AdminApi pela primeira vez será criado e populado o Banco de Dados, utilizei o MariaDB, sem senha de acesso e será criado o banco politicos.

As aplicações utilizam token JWT com tempo de expiração de 1 hora, sendo que o unico caminho que não possui restrição de acesso, é o de login.
A aplicação UserAPI possui uma rota para login onde vai receber os dados de login, enviar para a AdminAPI que ira realizar o login e gerar o token e enviar o token devolta para a UserAPI, após isso o token fica registrado e é enviado automaticamente em todas as requisições.
