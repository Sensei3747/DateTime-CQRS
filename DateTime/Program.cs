using DateTime;
using DateTime.Application.Abstractions.Auth;
using DateTime.Domain.Models.Users;
using DateTime.Extensions;
using DateTime.Infrastructure.Data;
using DateTime.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;




var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
    );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});


var app = builder.Build();

using(var scope = app.Services.CreateScope()) {
  var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var pass = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
  await DbSeeder.SeedAsync(ctx, pass);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


    app.ApplyMigrations();
}

app.UseAuthorization();

app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();