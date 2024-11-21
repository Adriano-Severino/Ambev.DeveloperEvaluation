using Microsoft.AspNetCore.Builder;

namespace Ambev.DeveloperEvaluation.IoC
{
    /// <summary>
    /// Interface for module initializers.
    /// </summary>
    public interface IModuleInitializer
    {
        /// <summary>
        /// Initializes the module with the specified web application builder.
        /// </summary>
        /// <param name="builder">The web application builder.</param>
        void Initialize(WebApplicationBuilder builder);
    }
}
