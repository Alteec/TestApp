using API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(cfg => {
	cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
	x.RequireHttpsMetadata = false;
	x.SaveToken = false;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(
			Encoding.UTF8
			.GetBytes(builder.Configuration["TokenKey"])
		),
		ValidateIssuer = false,
		ValidateAudience = false,
		ClockSkew = TimeSpan.Zero
	};
});
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;


var context = services.GetRequiredService<DataContext>();

await context.Database.MigrateAsync();
await Seed.SeedData(context);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
