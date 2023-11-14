using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shop25;
using shop25.Data.Contex;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContex>(options =>
options.UseSqlServer("Server=localhost;Database=qwe;Trusted_Connection=True; TrustServerCertificate=true"));
builder.Services.AddDbContext<ForumContex>(options =>
options.UseSqlServer("Server=localhost;Database=qwe;Trusted_Connection=True; TrustServerCertificate=true"));
builder.Services.AddDbContext<ProductContex>(options =>
options.UseSqlServer("Server=localhost;Database=qwe;Trusted_Connection=True; TrustServerCertificate=true"));
builder.Services.AddDbContext<UserBasketContex>(options =>
options.UseSqlServer("Server=localhost;Database=qwe;Trusted_Connection=True; TrustServerCertificate=true"));
builder.Services.AddDbContext<OrderContex>(options =>
options.UseSqlServer("Server=localhost;Database=qwe;Trusted_Connection=True; TrustServerCertificate=true"));
builder.Services.AddDbContext<order_historyContex>(options =>
options.UseSqlServer("Server=localhost;Database=qwe;Trusted_Connection=True; TrustServerCertificate=true"));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
