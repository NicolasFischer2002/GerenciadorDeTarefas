using Aplicacao.Comandos.CriarTarefa;
using Infraestrutura.Dependencias;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(
    builder.Configuration);

builder.Services.AddScoped<CriarTarefaCommandHandler>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();