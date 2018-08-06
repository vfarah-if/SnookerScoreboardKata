using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Xunit;

namespace SnookerKata.Domain.UnitTests
{
    public class SnookerGameShould
    {
        private readonly Fixture autoFixture;

        public SnookerGameShould()
        {
            autoFixture = new Fixture();
            autoFixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void ShouldHave()
        {
            autoFixture.Create<bool>().Should().BeTrue();
        }

    }
}
