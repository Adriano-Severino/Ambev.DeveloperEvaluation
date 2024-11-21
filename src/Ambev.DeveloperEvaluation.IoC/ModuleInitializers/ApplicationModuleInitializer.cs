using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers
{
    /// <summary>
    /// Initializes application modules and registers services.
    /// </summary>
    public class ApplicationModuleInitializer : IModuleInitializer
    {
        /// <summary>
        /// Initializes the module and registers services with the specified web application builder.
        /// </summary>
        /// <param name="builder">The web application builder.</param>
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        }
    }
}
