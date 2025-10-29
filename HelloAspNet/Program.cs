var builder = WebApplication.CreateBuilder(args); // Cria o construtor da aplicação web (configura o servidor, logs     e                                                    ambiente)
var app = builder.Build();                        // Constrói o aplicativo ASP.NET pronto para rodar e receber requisições

// Rota principal ("/")
app.MapGet("/", () =>                             // Cria uma rota GET para o endereço raiz (http://localhost:5000/)
{
    
    // Cria uma string contendo o código HTML da página
    string html = @"                              
        <html>
            <head>
                <title>Meu primeiro ASP.NET</title>
            </head>
            <body style='font-family: Arial; text-align: center; margin-top: 50px;'>
                <h1 style='color: blue;'>Hello, World!</h1>
                <p>Este e meu primeiro teste com ASP.NET Core </p>
            </body>
        </html>";
    
    return Results.Content(html, "text/html");    // Retorna o conteúdo HTML como resposta da requisição (tipo text/html)
});

app.Run(); // Inicia o servidor web e mantém a aplicação em execução até ser parada (Ctrl + C no terminal)
