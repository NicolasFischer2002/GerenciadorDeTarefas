using Aplicacao.Comandos.AtualizarTarefa;
using Aplicacao.Comandos.ConcluirTarefa;
using Aplicacao.Comandos.CriarTarefa;
using Aplicacao.Comandos.ExcluirTarefa;
using Aplicacao.Comandos.IniciarTarefa;
using Aplicacao.Comandos.ReabrirTarefa;
using Aplicacao.Consultas.ObterPorId;
using Aplicacao.Consultas.ObterTodas;
using Infraestrutura.Dependencias;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<CriarTarefaCommandHandler>();
builder.Services.AddScoped<ObterTarefaPorIdQueryHandler>();
builder.Services.AddScoped<ListarTarefasQueryHandler>();
builder.Services.AddScoped<ExcluirTarefaCommandHandler>();
builder.Services.AddScoped<IniciarTarefaCommandHandler>();
builder.Services.AddScoped<ConcluirTarefaCommandHandler>();
builder.Services.AddScoped<ReabrirTarefaCommandHandler>();
builder.Services.AddScoped<AtualizarTarefaCommandHandler>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();