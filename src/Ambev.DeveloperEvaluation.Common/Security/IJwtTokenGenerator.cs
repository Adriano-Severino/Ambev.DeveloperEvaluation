namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Interface for generating JWT tokens.
    /// </summary>
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generates a JWT token for a specified user.
        /// </summary>
        /// <param name="user">The user for whom to generate the token.</param>
        /// <returns>A JWT token string.</returns>
        string GenerateToken(IUser user);
    }
}
