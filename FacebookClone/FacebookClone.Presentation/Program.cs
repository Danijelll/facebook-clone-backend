using FacebookClone.BLL.Services;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.Presentation.EndpointDefinitions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<FacebookCloneDBContext>();

var app = builder.Build();

UserEndpointDefinition.DefineEndpoints(app);
AlbumEndpointDefinition.DefineEndpoints(app);

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