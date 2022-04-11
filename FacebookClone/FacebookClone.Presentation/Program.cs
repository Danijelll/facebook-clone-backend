using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Services;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.Presentation.EndpointDefinitions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IEmailConfirmRepository,EmailConfirmRepository>();
builder.Services.AddScoped<IEmailConfirmService, EmailConfirmService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISendEmailService, SendEmailService>();
builder.Services.AddScoped<FacebookCloneDBContext>();

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "https://localhost:5001",
        ValidAudience = "https://localhost:5001",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireId", policy => policy.RequireClaim("id"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllCors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

var app = builder.Build();

UserEndpointDefinition.DefineEndpoints(app);
AlbumEndpointDefinition.DefineEndpoints(app);
ImageEndpointDefinition.DefineEndpoints(app);
CommentEndpointDefinition.DefineEndpoints(app);

app.UseCors("AllowAllCors");

app.UseAuthentication();

app.UseAuthorization();

app.Run();