using System;
using FluentAssertions;
using SainaYar.InvestmentFund.Core;
using SainaYar.InvestmentFund.Core.Model;
using Xunit;

namespace SainaYar.InvestmentFund.Tests
{
    public class MemberTests
    {
        private readonly Guid _testFundId = Guid.NewGuid();
        [Fact]
        public void Can_Increase_Shares_For_Member()
        {
            var member = Member.Create(_testFundId, "Ali Bordbar", 1);

            member.IncreaseSharesBy(1);
            member.TotalShares().Should().Be(2);
        }
        [Fact]
        public void Cannot_Increase_Shares_More_Than_Fund_Max_Shares()
        {
            var member = Member.Create(_testFundId, "Ali Bordbar", 2);

            member.Invoking(x => x.IncreaseSharesBy(1))
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot increase shares.*")
                .WithInnerException<ArgumentOutOfRangeException>()
                .WithMessage("Member shares cannot exceed Fund maximum shares.*");
        }
    }
}