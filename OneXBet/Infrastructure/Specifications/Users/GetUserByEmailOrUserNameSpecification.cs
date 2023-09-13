using System.ComponentModel.DataAnnotations;

namespace OneXBet.Infrastructure.Specifications.Users;

public class GetUserByEmailOrUserNameSpecification : Specification<User>
{
    private GetUserByEmailOrUserNameSpecification(string emailOrUserName) : base(user => new EmailAddressAttribute().IsValid(emailOrUserName) ? user.Email.Equals(emailOrUserName) : user.UserName.Equals(emailOrUserName)) { }
    public override bool IsSatisfiedBy(User entity)
    {
        throw new NotImplementedException();
    }

    public static GetUserByEmailOrUserNameSpecification Create(string emailOrUserName) => new(emailOrUserName);
}