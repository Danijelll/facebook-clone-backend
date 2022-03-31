using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Services;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories;
using FacebookClone.DAL.Repositories.Abstract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<FacebookCloneDBContext>();

var app = builder.Build();

app.MapGet("/users", (IUserService userService) => userService.GetAll());

app.MapPost("/login", (UserDTO user, IUserService userService) => userService.Add(user));

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

app.Run();