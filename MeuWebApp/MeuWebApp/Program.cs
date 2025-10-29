var builder = WebApplication.CreateBuilder(args);
// Cria o builder da aplicação web, configurando servidor, logs e serviços.

builder.Services.AddRazorPages();
// Adiciona o serviço Razor Pages ao contêiner de dependências.

var app = builder.Build();
// Constrói a aplicação ASP.NET Core a partir do builder.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // Define uma página de erro personalizada em produção.

    app.UseHsts();
    // Ativa HSTS para forçar HTTPS em produção.
}

app.UseHttpsRedirection();
// Redireciona requisições HTTP para HTTPS.

app.UseStaticFiles();
// Permite servir arquivos estáticos da pasta wwwroot.

app.UseRouting();
// Habilita o roteamento para páginas e endpoints.

app.UseAuthorization();
// Habilita o middleware de autorização.

app.MapRazorPages();
// Mapeia todas as Razor Pages do projeto para URLs.

app.Run();
// Inicia o servidor web e mantém a aplicação em execução.
