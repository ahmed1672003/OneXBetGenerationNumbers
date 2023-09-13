namespace OneXBet.Infrastructure.Specifications.Users;

public sealed class PhoneNumberExistSpecification : Specification<User>
{
    private PhoneNumberExistSpecification(string phoneNumber) : base(user => user.PhoneNumber.Equals(phoneNumber))
    {

    }

    public override bool IsSatisfiedBy(User entity)
    {
        throw new NotImplementedException();
    }

    public static PhoneNumberExistSpecification Create(string phoneNumber) => new PhoneNumberExistSpecification(phoneNumber);

}
