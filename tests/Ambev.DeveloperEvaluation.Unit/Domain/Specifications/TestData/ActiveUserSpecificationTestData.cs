using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation for ActiveUserSpecification tests
/// to ensure consistency across test cases.
/// </summary>
public static class ActiveUserSpecificationTestData
{
    /// <summary>
    /// Configures the Faker to generate valid User entities.
    /// The generated users will have valid:
    /// - Email (valid format)
    /// - Password (meeting complexity requirements)
    /// - Username
    /// - Phone (Brazilian format)
    /// - Role (User)
    /// Status is not set here as it's the main test parameter
    /// </summary>
    private static readonly Faker<User> userFaker = new Faker<User>()
        .CustomInstantiator(f => new User(
            f.Internet.UserName(),
            new Email(f.Internet.Email()),
            new PhoneNumber($"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}"),
            new Password($"Test@{f.Random.Number(100, 999)}"),
            f.PickRandom<UserRole>()
        ));

    /// <summary>
    /// Generates a valid User entity with the specified status.
    /// </summary>
    /// <param name="status">The UserStatus to set for the generated user.</param>
    /// <returns>A valid User entity with randomly generated data and specified status.</returns>
    public static User GenerateUser(UserStatus status)
    {
        var user = userFaker.Generate();
        SetUserStatus(user, status);
        return user;
    }

    /// <summary>
    /// Sets the status of the user based on the provided status.
    /// </summary>
    /// <param name="user">The user to set the status for.</param>
    /// <param name="status">The status to set.</param>
    private static void SetUserStatus(User user, UserStatus status)
    {
        if (status == UserStatus.Active)
        {
            user.Activate();
        }
        else if (status == UserStatus.Inactive)
        {
            user.Deactivate();
        }
        else if (status == UserStatus.Suspended)
        {
            user.Suspend();
        }
    }
}
