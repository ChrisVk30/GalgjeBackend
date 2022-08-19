using GalgjeGame.Core.Interfaces;
using GalgjeGame.Core.Services;
using GalgjeGame.Infrastructure.Data;
using GalgjeGame.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GalgjeDatabase");

// Add services to the container.
builder.Services.AddDbContext<GalgjeContext>(options =>
   options.UseSqlServer(connectionString));
builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddTransient<IPlayersRepository, PlayerRepository>();
builder.Services.AddTransient<IWordsRepository, WordsRepository>();
builder.Services.AddTransient<IPlayerStatsService, PlayerStatsService>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IWordsService, WordsService>();
builder.Services.AddTransient<EncryptService>();

builder.Services.AddControllers();

builder.Services.AddCors(options => { options.AddPolicy("frontend", policy => {policy.WithOrigins("http://localhost:5174").AllowAnyMethod().AllowAnyHeader().AllowCredentials(); }); });

//builder.Services.AddSwaggerGen(options =>
//{
//	options.SwaggerDoc("v1", new OpenApiInfo
//	{
//		Title = "Nog steeds mijn beste API",
//		Version = "v1"
//	});
//});

//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//{
//	options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
//});

builder.Services.AddRazorPages();

builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseCors("frontend");

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();