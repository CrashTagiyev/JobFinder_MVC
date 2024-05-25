using FluentValidation;
using FluentValidation.AspNetCore;
using JobFinder_Application.Services;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Domain.Users;
using JobFinder_Persistence.Data;
using JobFinder_Persistence.Repositories;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels;
using JobFinder_Presentation.AutoMapper.AccountMappingProfiles;
using JobFinder_Presentation.BuilderServices;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.Web.Mvc;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

//Repositories
builder.Services.RepositoryRegister();

//Application layer Services
builder.Services.AppServicesRegister();

//View models
builder.Services.ViewModelsRegister();

//FluentValidation
builder.Services.FluentValidatorRegister();

//AutoMapper Profiles
builder.Services.AutoMapperRegister();
//Db Context
builder.DbContextRegister();
//Identity config
builder.Services.IdentityRegister();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
	name: "default",
	pattern: "{area=AllUsers}/{controller=Home}/{action=Index}/{id?}");


//------------------------------------

//Creating Employer and Admin role and Admin account

using var container = app.Services.CreateScope();
var usermanager = container.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
var roleManager = container.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

var dbContext = container.ServiceProvider.GetRequiredService<JobFinderDbContext>();

//dbContext.Tags.RemoveRange(dbContext.Tags.ToArray());
//dbContext.SaveChanges();
//var tag1 = new Tag() { Name = "Asp.NET DEV" };
//var tag2 = new Tag() { Name = "Asp C# .Net" };
//var tag3 = new Tag() { Name = "FrontEndJSCSSHTML" };
//await dbContext.Tags.AddAsync(tag1);
//await dbContext.Tags.AddAsync(tag2);
//await dbContext.Tags.AddAsync(tag3);
//await dbContext.SaveChangesAsync();


//dbContext.Categories.RemoveRange(dbContext.Categories.ToArray());
//var cat1 = new Category() { Name = "Web Developer" };
//var cat2 = new Category() { Name = "Back-end Developer" };
//var cat3 = new Category() { Name = "Fron-end Developer" };
//await dbContext.Categories.AddAsync(cat1);
//await dbContext.Categories.AddAsync(cat2);
//await dbContext.Categories.AddAsync(cat3);
//await dbContext.SaveChangesAsync();

var employerRole = await roleManager.RoleExistsAsync("Employer");
if (!employerRole)
    await roleManager.CreateAsync(new IdentityRole("Employer"));


var adminRole = await roleManager.RoleExistsAsync("Admin");
if (!adminRole)
    await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

var adminUser = await usermanager.FindByNameAsync("AdminEmil");
if (adminUser is null)
{
    var result = await usermanager.CreateAsync(new AppUser
    {
        UserName = "AdminEmil",
        Email = "cavid@gmail.com",
        EmailConfirmed = true,
        Firstname = "Emil",
        Lastname = "Tagiyev",
        PhoneNumber = "509999999"
    }, "123qweA@");

    if (result.Succeeded)
    {
        var user = await usermanager.FindByNameAsync("AdminEmil");
        await usermanager.AddToRoleAsync(user!, "Admin");
    }
}

app.Run();
