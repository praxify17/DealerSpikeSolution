using Microsoft.EntityFrameworkCore;
using ProductEndpoint.Data;
using static ProductEndpoint.Data.DumyData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProductDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowReactApp",
		b => b.WithOrigins("http://localhost:3000")
			  .AllowAnyHeader()
			  .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
	DumyData.Seed(dbContext);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowReactApp");

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
