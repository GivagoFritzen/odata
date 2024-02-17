using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using WebApplication.Infra;
using WebApplication.Service;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);


// Add services to the container.

/// 
// Count():   Habilita a funcionalidade de contagem de entidades em uma consulta OData. Isso permite que os clientes solicitem a contagem total de entidades que correspondem a uma consulta, além dos dados da entidade.
// Filter():  Habilita a funcionalidade de filtragem em uma consulta OData. Isso permite que os clientes filtrem os resultados da consulta com base em critérios específicos, como igualdade, comparações, etc.
// Expand():  Habilita a funcionalidade de expansão de entidades relacionadas em uma consulta OData. Isso permite que os clientes solicitem entidades relacionadas junto com a entidade principal em uma única solicitação.
// Select():  Habilita a funcionalidade de seleção de propriedades em uma consulta OData. Isso permite que os clientes solicitem apenas as propriedades desejadas de uma entidade em vez de todas as propriedades.
// OrderBy(): Habilita a funcionalidade de ordenação em uma consulta OData. Isso permite que os clientes especifiquem a ordem em que desejam que os resultados sejam retornados.
// SetMaxTop(100): Define o número máximo de entidades que podem ser retornadas em uma única solicitação. Neste caso, está configurado para 100 entidades.
builder.Services.AddControllers().AddOData(opt => opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(100));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<BookMapper>();
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
