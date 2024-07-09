using Biblioteca.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // Inicializa o construtor do aplicativo Web, que configura os serviços e middlewares.

// Adiciona serviços ao contêiner.
builder.Services.AddControllersWithViews(); // Adiciona suporte para controladores com views ao contêiner de serviços.

var ConnectionsString = builder.Configuration.GetConnectionString("BibliotecaContext"); // Obtém a string de conexão para o contexto "BibliotecaContext" a partir das configurações.

builder.Services.AddDbContext<AppDataContext>( // Adiciona o contexto de dados AppDataContext ao contêiner de serviços.
    options =>
    {
        options.UseMySQL(ConnectionsString, builder => // Configura o contexto para usar MySQL com a string de conexão obtida.
            builder.MigrationsAssembly("Biblioteca") // Especifica a assembly onde estão as migrações.
        );
    }
);


var app = builder.Build(); // Constrói a aplicação Web com as configurações definidas.

// Configura o pipeline de requisições HTTP.
if (!app.Environment.IsDevelopment()) // Verifica se o ambiente não é de desenvolvimento.
{
    app.UseExceptionHandler("/Home/Error"); // Configura o middleware de tratamento de exceções para redirecionar para a página de erro.
    app.UseHsts(); // Habilita HSTS (HTTP Strict Transport Security) com o valor padrão de 30 dias.
}

app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS.
app.UseStaticFiles(); // Habilita o servidor para servir arquivos estáticos (como HTML, CSS, JS).

app.UseRouting(); // Habilita o roteamento.

app.UseAuthorization(); // Habilita a autorização.

app.MapControllerRoute( // Mapeia a rota padrão para os controladores.
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Define o padrão de rota: controlador "Home", ação "Index" e id opcional.

app.Run(); // Executa a aplicação.
