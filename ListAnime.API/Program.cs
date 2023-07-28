using ListAnime.API.Repositories;
using ListAnime.API.Repositories.Context;
using ListAnime.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<SeedDb>();

builder.Services.AddDbContext<AnimeContext>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

//SeedData(app);

//void SeedData(WebApplication app)
//{
//    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//    using (IServiceScope? scope = scopedFactory!.CreateScope())
//    {
//        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
//        service!.SeedAsync().Wait();
//    }
//}

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

