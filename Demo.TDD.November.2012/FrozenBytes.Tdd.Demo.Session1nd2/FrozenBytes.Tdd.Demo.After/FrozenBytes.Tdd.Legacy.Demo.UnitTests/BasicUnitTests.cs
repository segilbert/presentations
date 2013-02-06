// -----------------------------------------------------------------------
// <copyright file="BasicUnitTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace FrozenBytes.Tdd.Legacy.Demo.UnitTests
{
    using System;

    using NUnit.Framework;
    using FluentAssertions;
    using StriderCupRacing.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BasicUnitTests
    {
        [Test]
        public void GetAge_RiderIsBornThisYear_ShouldBeZero()
        {
            // AAA
            // Arrange
            RiderSerivce riderSerivce = new RiderSerivce();
            Rider rider = new Rider()
            {
                City = "Atlanta",
                Country = "USA",
                DateOfBirth = DateTime.Parse("10/21/2012"),
                FirstName = "Chase",
                LastName = "Me",
                GenderEnum = GenderEnum.Male,
                Number = 431,
                RiderId = 1,
                SkillLevelEnum = RiderSkillLevelEnum.Beginner
            };

            // Act
            int age = riderSerivce.GetAge(rider, DateTime.Now);

            // Assert
            //Assert.AreEqual(0,age);
            age.Should().Be(0);
        }
    }
}
