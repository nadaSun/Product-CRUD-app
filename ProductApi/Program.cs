using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlite("Data Source=products.db"));
builder.Services.AddCors(opt =>
opt.AddPolicy("AllowAll", p =>
p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/api/products", async (AppDbContext db) => await
db.Products.ToListAsync());
app.MapGet("/api/products/{id}", async (int id, AppDbContext db) => await
db.Products.FindAsync(id) is Product p ? Results.Ok(p) : Results.NotFound());
app.MapPost("/api/products", async (Product product, AppDbContext db) => {
db.Products.Add(product); await db.SaveChangesAsync(); return
Results.Created($"/api/products/{product.Id}", product); });
app.MapPut("/api/products/{id}", async (int id, Product update, AppDbContext db) => { var p = await db.Products.FindAsync(id); if (p is null) return
Results.NotFound(); p.Name = update.Name; p.Price = update.Price; await
db.SaveChangesAsync(); return Results.NoContent(); });
app.MapDelete("/api/products/{id}", async (int id, AppDbContext db) => { var p
= await db.Products.FindAsync(id); if (p is null) return Results.NotFound();
db.Products.Remove(p); await db.SaveChangesAsync(); return
Results.NoContent(); });
app.Run();