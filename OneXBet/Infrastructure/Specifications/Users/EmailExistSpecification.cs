namespace OneXBet.Infrastructure.Specifications.Users;

public sealed class EmailExistSpecification : Specification<User>
{
    private EmailExistSpecification(string email) : base(user => user.Email.Equals(email)) { }
    public sealed override bool IsSatisfiedBy(User entity)
    {
        throw new NotImplementedException();
    }
    public static EmailExistSpecification Create(string email)
    {
        return new(email);
    }
}
