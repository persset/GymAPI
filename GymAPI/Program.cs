using GymAPI.Data;
using GymAPI.Services.Client;
using GymAPI.Services.Functionary;
using GymAPI.Services.MuscleGroup;
using GymAPI.Services.Plan;
using GymAPI.Services.PlanPeriodicity;
using GymAPI.Services.Training;
using GymAPI.Services.TrainingOrganizaton;
using GymAPI.Services.User;
using GymAPI.Services.UserPrivilege;
using GymAPI.Services.UserType;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFunctionaryService, FunctionaryService>();
builder.Services.AddScoped<IMuscleGroupService, MuscleGroupService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IPlanPeriodicityService, PlanPeriodicityService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingOrganizationService, TrainingOrganizationService>();
builder.Services.AddScoped<IUserPrivilegeService, UserPrivilegeService>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();
#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
