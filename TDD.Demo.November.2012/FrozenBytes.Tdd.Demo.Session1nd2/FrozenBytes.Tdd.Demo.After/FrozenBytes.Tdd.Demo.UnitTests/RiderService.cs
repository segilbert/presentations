namespace FrozenBytes.Tdd.Demo.UnitTests
{
    using System;

    using FrozenBytes.Tdd.Legacy.Demo.Infrastructure.Repositories;

    using StriderCupRacing.Models;

    public class RiderService
    {
        private IRiderRepository _RiderRepository;

        public RiderService(IRiderRepository riderRepository)
        {
            _RiderRepository = riderRepository;
        }

        public int CreateNewRider(string psFirstName, string psLastName, DateTime pdtDateOfBirth)
        {
            Rider rider = new Rider()
                {
                    DateOfBirth = pdtDateOfBirth,
                    FirstName = psFirstName,
                    LastName = psLastName
                };

            // validate last name
            if (string.IsNullOrWhiteSpace(rider.LastName)) throw new ArgumentNullException("Rider Last Name must be entered.");

            rider = _RiderRepository.Add(rider);



            return rider.Number;
        }
    }
}