namespace OneXBet.Infrastructure.Specifications.Users;

public sealed class GetUserByEmailSpecification : Specification<User>
{
    private GetUserByEmailSpecification(int userId) : base(user => user.Id == userId)
    {
    }
    public override bool IsSatisfiedBy(User entity)
    {
        throw new NotImplementedException();
    }

    public static GetUserByEmailSpecification Create(int userId)
    {
        return new(userId);
    }
}
