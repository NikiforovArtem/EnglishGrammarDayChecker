using EnglishGrammarDayChecker.Infrastructure;
using EnglishGrammarDayChecker.Model.Interfaces;
using Hangfire;
using Hangfire.Storage.SQLite;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
});

builder.Services.AddHangfire(configuration => configuration
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSQLiteStorage(builder.Configuration.GetConnectionString("SqlLite")));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IGrammarTaskRepository, GrammarTaskRepository>();
builder.Services.AddSingleton<IGrammarTaskUpdaterService, GrammarTaskUpdaterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapHangfireDashboard();

app.Run();

