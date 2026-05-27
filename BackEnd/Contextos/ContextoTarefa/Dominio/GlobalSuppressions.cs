// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA2208:Instanciar exceções de argumentos corretamente", Justification = "<Pendente>", Scope = "member", Target = "~M:Dominio.ValueObjects.TituloTarefa.#ctor(System.String)")]
[assembly: SuppressMessage("Usage", "CA2208:Instanciar exceções de argumentos corretamente", Justification = "<Pendente>", Scope = "member", Target = "~M:Dominio.ValueObjects.DescricaoTarefa.#ctor(System.String)")]
[assembly: SuppressMessage("Style", "IDE0290:Usar construtor primário", Justification = "<Pendente>", Scope = "member", Target = "~M:Dominio.Agregado.Tarefa.#ctor(System.Guid,Dominio.ValueObjects.TituloTarefa,Dominio.ValueObjects.DescricaoTarefa)")]
[assembly: SuppressMessage("Style", "IDE0074:Usar a atribuição composta", Justification = "<Pendente>", Scope = "member", Target = "~M:Dominio.Agregado.Tarefa.#ctor(System.Guid,Dominio.ValueObjects.TituloTarefa,Dominio.ValueObjects.DescricaoTarefa)")]
[assembly: SuppressMessage("Style", "IDE0074:Usar a atribuição composta", Justification = "<Pendente>", Scope = "member", Target = "~M:Dominio.Agregado.Tarefa.CriarTarefa(System.Guid,Dominio.ValueObjects.TituloTarefa,Dominio.ValueObjects.DescricaoTarefa)~Dominio.Agregado.Tarefa")]
[assembly: SuppressMessage("Maintainability", "CA1510:Usar o auxiliar de lançamento de ArgumentNullException", Justification = "<Pendente>", Scope = "member", Target = "~M:Dominio.Agregado.Tarefa.AlterarTitulo(Dominio.ValueObjects.TituloTarefa)")]
