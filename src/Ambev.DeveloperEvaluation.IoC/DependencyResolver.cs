using Ambev.DeveloperEvaluation.IoC.ModuleInitializers;
using Microsoft.AspNetCore.Builder;

namespace Ambev.DeveloperEvaluation.IoC
{
    /// <summary>
    /// Resolves and registers application dependencies.
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Registers dependencies with the specified web application builder.
        /// </summary>
        /// <param name="builder">The web application builder.</param>
        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            new ApplicationModuleInitializer().Initialize(builder);
            new InfrastructureModuleInitializer().Initialize(builder);
            new WebApiModuleInitializer().Initialize(builder);
        }
    }
}
