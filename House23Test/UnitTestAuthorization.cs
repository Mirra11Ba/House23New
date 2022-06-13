using System;
using Xunit;
using House23.UI.Pages;

namespace House23Test
{
    public class UnitTestAuthorization
    {
        [Fact]
        public void TestAuthorizationPositive()
        {
            // assert
            var r = Proba.UserAuthorization("hrm1", "hrm1");
            Assert.True(r);
        }

        [Fact]
        public void TestAuthorizationNegative()
        {
            // assert
            var r = Proba.UserAuthorization("1", "f");
            Assert.False(r);
        }
    }
}
