using FoRavers.Data;
using FoRavers.Helpers.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FoRaversDbContext>(Options => 
Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") 
?? throw new InvalidOperationException("Connection string 'FoRaversDbContext' not found.")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
