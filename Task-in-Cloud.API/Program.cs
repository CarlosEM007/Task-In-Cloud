using Supabase;
using Task_in_Cloud.Application.Service;
using Task_in_Cloud.Domain.Service;
using Task_in_Cloud.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Conexão ao Banco
var url = Environment.GetEnvironmentVariable("TASKIN_SUPABASE_URL");
var key = Environment.GetEnvironmentVariable("TASKIN_SUPABASE_KEY");

var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};

var supabase = new Supabase.Client(url, key, options);
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
