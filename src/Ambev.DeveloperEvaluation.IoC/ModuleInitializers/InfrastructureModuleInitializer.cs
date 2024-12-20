﻿using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Infrastructure.Handlers;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers
{
    /// <summary>
    /// Initializes infrastructure modules and registers services.
    /// </summary>
    public class InfrastructureModuleInitializer : IModuleInitializer
    {
        /// <summary>
        /// Initializes the module and registers services with the specified web application builder.
        /// </summary>
        /// <param name="builder">The web application builder.</param>
        public void Initialize(WebApplicationBuilder builder)
        {
            // Registro dos repositórios
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ISaleRepository, SaleRepository>();

            // Registro dos handlers de eventos
            builder.Services.AddTransient<INotificationHandler<SaleCreated>, SaleEventHandler>();
            builder.Services.AddTransient<INotificationHandler<SaleModified>, SaleEventHandler>();
            builder.Services.AddTransient<INotificationHandler<SaleCancelled>, SaleEventHandler>();
            builder.Services.AddTransient<INotificationHandler<ItemCancelled>, SaleEventHandler>();

            // Registro dos validadores
            builder.Services.AddTransient<IValidator<GetSaleRequest>, GetSaleRequestValidator>();
            builder.Services.AddTransient<IValidator<UpdateSaleRequest>, UpdateSaleRequestValidator>();
            builder.Services.AddTransient<IValidator<DeleteSaleCommand>, DeleteSaleCommandValidator>();

            // Registro dos handlers
            builder.Services.AddTransient<IRequestHandler<CreateSaleCommand, CreateSaleResult>, CreateSaleHandler>();
            builder.Services.AddTransient<IRequestHandler<GetAllSalesCommand, PaginatedList<GetAllSalesResult>>, GetAllSalesHandler>();
            builder.Services.AddTransient<IRequestHandler<GetSaleCommand, GetSaleResult>, GetSaleHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdateSaleCommand, UpdateSaleResult>, UpdateSaleHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteSaleCommand, Unit>, DeleteSaleHandler>();
        }
    }
}
