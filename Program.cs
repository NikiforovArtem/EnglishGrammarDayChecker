using EnglishGrammarDayChecker.Infrastructure;
using EnglishGrammarDayChecker.Model.Interfaces;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Storage.SQLite;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddHangfire(configuration => configuration
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSQLiteStorage(builder.Configuration.GetConnectionString("SqlLite")));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IGrammarTaskRepository, GrammarTaskRepository>();
builder.Services.AddSingleton<IGrammarTaskUpdaterService, GrammarTaskUpdaterService>();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseCors("corsapp");
app.MapControllers();

app.UseHangfireDashboard("/jobs", new DashboardOptions()
{ Authorization = new[] { new LocalRequestsOnlyAuthorizationFilter() } });
app.MapHangfireDashboard();

app.Run();

