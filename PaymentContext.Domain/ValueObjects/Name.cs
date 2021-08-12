using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsLowerThan(FirstName, 3, nameof(FirstName), "The min len for First name is 3")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
