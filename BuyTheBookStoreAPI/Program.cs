using AutoMapper;
using BuyTheBookStore.Application;
using BuyTheBookStore.Application.Helpers;
using BuyTheBookStore.Application.Services.BookService;
using BuyTheBookStore.Application.Services.OrderService;
using BuyTheBookStore.Application.Services.RecommendationService;
using BuyTheBookStore.Application.Services.UserService;
using BuyTheBookStore.Application.UserService.Services;
using BuyTheBookStore.Application.Validators;
using BuyTheBookStore.Application.Validators.BookDtoValidators;
using BuyTheBookStore.Application.Validators.OrderDtoValidators;
using BuyTheBookStore.Application.Validators.UserDtoValidators;
using BuyTheBookStore.DataAccess.Persistence;
using BuyTheBookStore.DataAccess.Repositories;
using BuyTheBookStore.DataAccess.Repositories.Impl;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidateModelAttribute));
}).AddNewtonsoftJson(option =>
{
    option.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Error;
}).AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<RegisterUserValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<LoginDtoValidatior>();
    fv.RegisterValidatorsFromAssemblyContaining<CustomerUpdateDtoValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<BookDtoValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<OrderDtoValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<OrderItemValidator>();
}); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standart auth with bearer scheme",
        In = ParameterLocation.Header,
        Name = "Auhtorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
