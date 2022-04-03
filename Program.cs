using AccountService.DataBase;
using AccountService.Errors;
using AccountService.Interfaces;
using AccountService.Models;
using AccountService.Services;
using AccountService.Validation;
using AccountService.Validation.Validators;
using Microsoft.EntityFrameworkCore;
using WebUtilities.Interfaces;
using WebUtilities.Model;
using WebUtilities.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AccountContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AccountContext>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService.Services.AccountService>();
builder.Services.AddScoped<List<IValidationService<Account>>>(x => new List<IValidationService<Account>>() 
                                                                    {
                                                                        new EmptyEmailValidator<Account>(),
                                                                        new EmptyNameValidator<Account>(),
                                                                        new CorrectEmailValidator<Account>()
                                                                    });
builder.Services.AddScoped<IOperationResultBuilder<OperationResult>, OperationResultBuilder<OperationResult>>();
builder.Services.AddScoped<IValidationSolver, ValidationSolver>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.WithOrigins(@"http://localhost:8080/", @"https://localhost:44392/", @"https://localhost:44392/api/Account");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseMiddleware<ErrorsHandler>();
app.UseAuthorization();

app.MapControllers();

app.Run();
