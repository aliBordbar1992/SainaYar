using System;
using System.Linq;
using FluentAssertions;
using SainaYar.InvestmentFund.Core;
using SainaYar.InvestmentFund.Core.Model;
using Xunit;

namespace SainaYar.InvestmentFund.Tests
{
    public class FundTests
    {
        [Fact]
        public void Can_Add_Members_To_Fund()
        {
            var fund = new Fund(Guid.NewGuid(), 2);
            fund.AddMember(Member.Create(fund.Id, "Ali Bordbar", 2));

            fund.Members.Count().Should().Be(1);
        }
        [Fact]
        public void Cannot_Add_Duplicate_Member_To_Fund()
        {
            var fund = new Fund(Guid.NewGuid(), 2);
            var memberToAdd = Member.Create(fund.Id, "Ali Bordbar", 2);
            fund.AddMember(memberToAdd);

            fund.Invoking(x => x.AddMember(memberToAdd))
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot add duplicate member to Fund.*");
        }
        [Fact]
        public void Cannot_Add_Member_With_Shares_More_Than_Fund_Max_Shares()
        {
            var fund = new Fund(Guid.NewGuid(), 2);
            var memberToAdd = Member.Create(fund.Id, "Ali Bordbar", 3);

            fund.Invoking(x => x.AddMember(memberToAdd))
                .Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Cannot add member with shares greater than the Fund maximum shares.*");
        }

        //[Fact]
        //public void Can_Increase_Shares_For_Member()
        //{
        //    var fund = new Fund(Guid.NewGuid(), 2);
        //    var memberAli = Member.Create(fund.Id, "Ali Bordbar", 1);
        //    fund.AddMember(memberAli);

        //    fund.IncreaseMemberShare(memberAli, 1);
        //    memberAli.TotalShares().Should().Be(2);
        //}
        //[Fact]
        //public void No_Member_Found_To_Increase_Shares()
        //{
        //    var fund = new Fund(Guid.NewGuid(), 2);
        //    var memberAli = Member.Create("Ali Bordbar", 1);

        //    fund.Invoking(x => x.IncreaseMemberShare(memberAli, 1))
        //        .Should().Throw<ArgumentException>()
        //        .WithMessage("No member found in fund.*");
        //}
        //[Fact]
        //public void Cannot_Increase_Shares_More_Than_Fund_Max_Shares()
        //{
        //    var fund = new Fund(Guid.NewGuid(), 2);
        //    var memberAli = Member.Create("Ali Bordbar", 2);
        //    fund.AddMember(memberAli);

        //    fund.Invoking(x => x.IncreaseMemberShare(memberAli, 1))
        //        .Should().Throw<InvalidOperationException>()
        //        .WithMessage("Cannot increase shares.*")
        //        .WithInnerException<ArgumentOutOfRangeException>()
        //        .WithMessage("Member shares cannot be greater than Fund maximum shares.*");
        //}


        //[Fact]
        //public void Can_Decrease_Shares_For_Member()
        //{
        //    var fund = new Fund(Guid.NewGuid(), 2);
        //    var memberAli = Member.Create("Ali Bordbar", 2);
        //    fund.AddMember(memberAli);

        //    fund.DecreaseMemberShare(memberAli, 1);
        //    memberAli.TotalShares().Should().Be(1);
        //}
        //[Fact]
        //public void No_Member_Found_To_Decrease_Shares()
        //{
        //    var fund = new Fund(Guid.NewGuid(), 2);
        //    var memberAli = Member.Create("Ali Bordbar", 1);

        //    fund.Invoking(x => x.DecreaseMemberShare(memberAli, 1))
        //        .Should().Throw<ArgumentException>()
        //        .WithMessage("No member found in fund.*");
        //}
        //[Fact]
        //public void Cannot_Decrease_Shares_Less_Than_One()
        //{
        //    var fund = new Fund(Guid.NewGuid(), 2);
        //    var memberAli = Member.Create("Ali Bordbar", 1);
        //    fund.AddMember(memberAli);

        //    fund.Invoking(x => x.DecreaseMemberShare(memberAli, 1))
        //        .Should().Throw<InvalidOperationException>()
        //        .WithMessage("Cannot decrease shares.*")
        //        .WithInnerException<ArgumentOutOfRangeException>()
        //        .WithMessage("Member cannot have less than 1 shares.*");
        //}

        [Fact]
        public void Can_Calculate_Total_Balance()
        {
            var fund = new Fund(Guid.NewGuid(), 2);
            
        }
    }
}
