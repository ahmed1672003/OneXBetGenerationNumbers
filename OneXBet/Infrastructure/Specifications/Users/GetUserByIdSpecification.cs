namespace OneXBet.Infrastructure.Specifications.Users;

public sealed class GetUserByIdSpecification : Specification<User>
{
    private GetUserByIdSpecification(int userId) : base(user => user.Id == userId)
    {
    }

    public override bool IsSatisfiedBy(User entity)
    {
        throw new NotImplementedException();
    }

    public static GetUserByIdSpecification Create(int userId) => new GetUserByIdSpecification(userId);

}
