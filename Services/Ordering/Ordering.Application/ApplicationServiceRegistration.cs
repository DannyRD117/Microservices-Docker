using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public static class ApplicationServiceRegistration
    {
        
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            // configuramos automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // configuramos fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // configuramos Mediatr
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), 
                typeof(UnhandledExceptionBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior));

            return services;

        }
        
    }
}
