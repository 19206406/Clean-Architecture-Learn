using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RH.LeaveManagement.Application.Contracts.Infrastructure;
using RH.LeaveManagement.Application.Models;
using RH.LeaveManagement.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Infrastructure
{
    public class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>(); 

            return services; 
        }
    }
}
