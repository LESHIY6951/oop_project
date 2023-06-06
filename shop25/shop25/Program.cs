using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shop25;
using shop25.Data.Contex;
using shop25.Data.Moks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IUser, MoksUser>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Services.AddDbContext<UserContex>(options => options.UseSqlServer("Server=localhost;Database=Shop;Trusted_Connection=True; TrustServerCertificate=true"));
app.Run();
