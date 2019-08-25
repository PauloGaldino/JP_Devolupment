using JP_Devolupment.Application.Interfaces;
using JP_Devolupment.Application.Services;
using JP_Devolupment.Domain.CommandHandlers;
using JP_Devolupment.Domain.Commands;
using JP_Devolupment.Domain.Core.Bus;
using JP_Devolupment.Domain.Core.Events;
using JP_Devolupment.Domain.Core.Notifications;
using JP_Devolupment.Domain.EventHandlers;
using JP_Devolupment.Domain.Events;
using JP_Devolupment.Domain.Interfaces;
using JP_Devolupment.Infra.CrossCutting.Bus;
using JP_Devolupment.Infra.CrossCutting.Identity.Authorization;
using JP_Devolupment.Infra.CrossCutting.Identity.Models;
using JP_Devolupment.Infra.CrossCutting.Identity.Services;
using JP_Devolupment.Infra.Data.Context;
using JP_Devolupment.Infra.Data.EventSourcing;
using JP_Devolupment.Infra.Data.Repository;
using JP_Devolupment.Infra.Data.Repository.EventSourcing;
using JP_Devolupment.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace JP_Devolupment.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DevolupmentContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}