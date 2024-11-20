using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListAllUsers
{
    /// <summary>
    /// Command for listing all users.
    /// </summary>
    public class ListAllUsersCommand : IRequest<ListAllUsersResult>
    {
    }
}
