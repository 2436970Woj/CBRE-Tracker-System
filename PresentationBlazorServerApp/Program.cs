//Adding global makes these available throughout the app
global using Infrastructure.DataAccess;
global using Infrastructure.Interfaces;
global using Infrastructure.Repositories;
global using Microsoft.AspNetCore.Authentication.Negotiate;
global using MudBlazor.Services;
global using Radzen;
global using Application.Interfaces.EmployeeServiceInterfaces;
global using Application.Interfaces.RoleServiceInterfaces;
global using Application.Services.EmployeeServices;
global using Application.Services.RoleServices;
global using Application.Interfaces.DropDownServicesInterfaces;
global using Application.Services.DropDownServices;
global using Application.Interfaces.FileUploadServiceInterfaces;
global using Application.Services.FileUploadServices;
global using Application.Interfaces.ReqTicketServiceInterfaces;
global using Application.Services.ReqTicketServices;
global using Microsoft.JSInterop;
global using ClosedXML;



namespace PresentationBlazorServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            //Call services from other projects to allow dependency injection
            builder.Services.AddTransient<ISqlDapperData, SqlDapperData>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IRoleRepository, RoleRepository>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IRequestLocationRepository, RequestLocationRepository>();
            builder.Services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
            builder.Services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
            builder.Services.AddScoped<IRequestTicketRepository, RequestTicketRepository>();
            builder.Services.AddScoped<IRequestDocRepository, RequestDocRepository>();

            builder.Services.AddTransient<IRoleService, RoleService>();
            builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
            builder.Services.AddScoped<IRoleChangedService, RoleChangedService>();
            builder.Services.AddScoped<IRequestDropDownService, RequestDropDownService>();
            builder.Services.AddScoped<IFileUploadService, FileUploadService>();
            builder.Services.AddScoped<IReqTicketService, ReqTicketService>();
            builder.Services.AddScoped<IRequestFileUploadService, RequestFileUploadService>();

            // Program.cs
            builder.Services.AddSingleton<IJSInProcessRuntime>(services => (IJSInProcessRuntime)services.GetRequiredService<IJSRuntime>());

            //If using MudBlazor need the following:
            builder.Services.AddMudServices();


            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopCenter;
                config.SnackbarConfiguration.PreventDuplicates = true;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 3500;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Filled;
            });

            //Use Extensions with Radzen components
           // builder.Services.AddScoped<MudBlazor.DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();


            var app = builder.Build();

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}