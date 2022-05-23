using FacebookClone.BLL.Services;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.Presentation.EndpointDefinitions;
using FacebookClone.Presentation.Helpers;
using FacebookClone.Presentation.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Connections;
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
builder.Services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
builder.Services.AddScoped<IFriendshipService, FriendshipService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddScoped<ITwoFactorAuthenticatorRepository, TwoFactorAuthenticatorRepository>();

builder.Services.AddScoped<IEmailConfirmRepository, EmailConfirmRepository>();
builder.Services.AddScoped<IEmailConfirmService, EmailConfirmService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISendEmailService, SendEmailService>();
builder.Services.AddScoped<FacebookCloneDBContext>();
builder.Services.AddSignalR();

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
        ValidIssuer = builder.Configuration["LocalHost"],
        ValidAudience = builder.Configuration["LocalHost"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
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
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

var app = builder.Build();

UserEndpointDefinition.DefineEndpoints(app);
AlbumEndpointDefinition.DefineEndpoints(app);
ImageEndpointDefinition.DefineEndpoints(app);
CommentEndpointDefinition.DefineEndpoints(app);
FriendshipEndpointDefinition.DefineEndpoints(app);
MessageEndpointDefiniton.DefineEndpoints(app);


app.UseCors("AllowAllCors");

app.UseExceptionHandler("/errors");

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.UseWebSockets();

app.MapHub<ChatHub>("/chatHub", options =>
{
    options.Transports =
        HttpTransportType.WebSockets |
        HttpTransportType.LongPolling;
});
app.Run();