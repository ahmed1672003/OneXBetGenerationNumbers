namespace OneXBet.Infrastructure.Specifications.Users;

public sealed class UserNameExistSpecification : Specification<User>
{
    private UserNameExistSpecification(string userName) : base(user => user.UserName.Equals(userName)) { }
    public override bool IsSatisfiedBy(User entity)
    {
        throw new NotImplementedException();
    }
    public static UserNameExistSpecification Create(string userName) => new UserNameExistSpecification(userName);
}
