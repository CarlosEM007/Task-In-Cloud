using Task_in_Cloud.Infrastructure.Repository;
using Task_in_Cloud.Application.Service;
using Swashbuckle.AspNetCore.Filters;
using Task_in_Cloud.Domain.Service;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Conexão ao Banco
var url = Environment.GetEnvironmentVariable("TASKIN_SUPABASE_URL");
var key = Environment.GetEnvironmentVariable("TASKIN_SUPABASE_KEY");

var supabase = new Supabase.Client(url, key);
await supabase.InitializeAsync();

builder.Services.AddSingleton<Client>(supabase);
#endregion

#region Scoped

builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddScoped<WorkspaceRepository>();
builder.Services.AddScoped<WorkspaceService>();

builder.Services.AddScoped<ObservacaoRepository>();
builder.Services.AddScoped<ObservacaoService>();

#endregion

builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
