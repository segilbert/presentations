// -----------------------------------------------------------------------
// <copyright file="RiderServiceTests1.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace FrozenBytes.Tdd.Demo.UnitTests
{
    using System;

    using FluentAssertions;

    using FrozenBytes.Tdd.Legacy.Demo.Infrastructure.Repositories;

    using NSubstitute;

    using NUnit.Framework;

    using StriderCupRacing.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RiderServiceTests1
    {
        // Rider who want to register for a BMX
        // Quickly _rider with min info
        //  1. first name
        //  2. last name
        //  3. DOB
        // Once _rider is register or created assign a number
        //
        [Test]
        public void CreateNewRider_WithAllRequiredInformation_ShouldReturnRiderNumber()

        {
            // AAA
            // Arrange
            IRiderRepository riderRepository = Substitute.For<IRiderRepository>();
            riderRepository.Add(Arg.Any<Rider>()).Returns(
                 new Rider() {   DateOfBirth = DateTime.Parse("08/03/2000"), 
                                FirstName = "Try", 
                                LastName = "Me", 
                                Number = 1 });

            RiderService riderService = new RiderService(riderRepository);
            Rider rider = new Rider()
                            {
                                DateOfBirth = DateTime.Parse("08/03/2000"),
                                FirstName = "Try",
                                LastName = "Me"
                            };

            // Act
            int riderNumber = riderService.CreateNewRider(  rider.FirstName,
                                                            rider.LastName,
                                                            rider.DateOfBirth);


            // Assert
            riderNumber.Should().Be(1);
        }

        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void CreateNewRider_WithNoLastName_ShouldRaiseAnExpecption()
        {
            // AAA
            // Arrange
            TestableRiderService riderService = TestableRiderService.Create();
            riderService.Rider.LastName = string.Empty;

            // Act
            //int riderNumber = riderService.CreateNewRider(
            //                                                rider.FirstName, 
            //                                                rider.LastName, 
            //                                                rider.DateOfBirth);

            // Assert
            Assert.Throws<ArgumentNullException>(
                delegate
                {
                    int riderNumber = riderService.CreateNewRider(
                                      riderService.Rider.FirstName,
                                      riderService.Rider.LastName,
                                      riderService.Rider.DateOfBirth);
                });
        }


    }

    public class TestableRiderService : RiderService
    {
        private IRiderRepository _riderRepository;

        public TestableRiderService(IRiderRepository pxRepository, Rider pxRider)
            : base(pxRepository)
        {
            this._riderRepository = pxRepository;
            this.Rider = pxRider;
        }

        public Rider Rider { get; set; }

        public static TestableRiderService Create()
        {
            IRiderRepository riderRepository = Substitute.For<IRiderRepository>();
            riderRepository.Add(Arg.Any<Rider>()).Returns(
                new Rider()
                {
                    DateOfBirth = DateTime.Parse("08/03/2000"),
                    FirstName = "Try",
                    LastName = "Me",
                    Number = 1
                }
                );

            Rider rider = new Rider()
            {
                DateOfBirth = DateTime.Parse("08/03/2000"),
                FirstName = "Try",
                LastName = "Me"
            };

            return new TestableRiderService(riderRepository, rider);
        }
    }
}
