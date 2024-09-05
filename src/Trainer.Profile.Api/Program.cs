using Trainer.Profile.Adaptors.Ef.Module;
using Trainer.Profile.Adaptors.Http.Refit.Module;
using Trainer.Profile.Api.APIs.Registration;
using Trainer.Profile.Api.ExceptionHandler;
using Trainer.Profile.Application.Module;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GeneralExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.RegisterApplication(c => { });
builder.Services.RegisterRefitAdaptor(builder.Configuration);
builder.Services.RegisterEfAdaptor(c => c.ConnectionString = builder.Configuration.GetConnectionString("ProfileSQL"));

var app = builder.Build();

app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.SetTrainerRoutes();

app.Run();