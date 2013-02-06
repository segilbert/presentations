// -----------------------------------------------------------------------
// <copyright file="IRiderService.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace FrozenBytes.Tdd.Legacy.Demo.UnitTests
{
    using System;

    using StriderCupRacing.Models;

    public interface IRiderService
    {
        int GetAge(Rider pxRider, DateTime pdtDateAsAt);

        string GetRiderClassification(
            Rider pxRider, int piAge, int currentFirstPlaceFinishes, int currentTopThreeFinishes);
    }
}
