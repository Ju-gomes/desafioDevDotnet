using DesafioDevDotnet.Services;
using DesafioDevDotnet.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// --- REGISTRO DOS SERVIÇOS (INJEÇÃO DE DEPENDÊNCIA) ---
builder.Services.AddScoped<IComissaoService, ComissaoService>();
builder.Services.AddScoped<ICobrancaService, CobrancaService>();

// Singleton para manter o estado do estoque em memória
builder.Services.AddSingleton<IEstoqueService, EstoqueService>(); 

// OpenAPI
builder.Services.AddOpenApi();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//Rotas dos controllers na aplicação
app.MapControllers(); 
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.Run();
