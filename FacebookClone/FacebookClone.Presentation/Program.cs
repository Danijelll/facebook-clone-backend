using FacebookClone.BLL.Services;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;
using FacebookClone.Presentation.EndpointDefinitions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<FacebookCloneDBContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllCors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

UserEndpointDefinition.DefineEndpoints(app);
AlbumEndpointDefinition.DefineEndpoints(app);
ImageEndpointDefinition.DefineEndpoints(app);
CommentEndpointDefinition.DefineEndpoints(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("AllowAllCors");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.Run();