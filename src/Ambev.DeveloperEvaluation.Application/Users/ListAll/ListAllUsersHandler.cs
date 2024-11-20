using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Dto;

namespace Ambev.DeveloperEvaluation.Application.Users.ListAllUsers
{
    /// <summary>
    /// Handler for processing ListAllUsersCommand requests
    /// </summary>
    public class ListAllUsersHandler : IRequestHandler<ListAllUsersCommand, ListAllUsersResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ListAllUsersHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ListAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the ListAllUsersCommand request
        /// </summary>
        /// <param name="command">The ListAllUsers command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of all users</returns>
        public async Task<ListAllUsersResult> Handle(ListAllUsersCommand command, CancellationToken cancellationToken)
        {
            var users = await _userRepository.ListAllAsync(cancellationToken);
            var result = new ListAllUsersResult
            {
                Users = _mapper.Map<List<UserDto>>(users)
            };
            return result;
        }
    }
}
