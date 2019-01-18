using System;
using System.Collections.Generic;
using System.Linq;
using SainaYar.SharedKernel.Shared;

namespace SainaYar.InvestmentFund.Core.Model
{
    public class Fund : AggregateRoot<Guid>
    {
        private List<Member> _members;
        public IEnumerable<Member> Members
        {
            get { return _members.AsEnumerable(); }
            private set { _members = (List<Member>) value; }
        }

        private int _maxNumberOfShares;

        public Fund(Guid id, int maxShares) : base(id)
        {
            _members = new List<Member>();
            _maxNumberOfShares = maxShares;
        }

        private Fund() : base(Guid.NewGuid())
        {
            _members = new List<Member>();
        }


        public Member AddMember(Member member)
        {
            if (_members.Any(x => x == member))
                throw new InvalidOperationException("Cannot add duplicate member to Fund.");
            if (member.NumberOfShares > _maxNumberOfShares)
                throw new ArgumentOutOfRangeException(nameof(member.NumberOfShares), member.NumberOfShares, "Cannot add member with shares greater than the Fund maximum shares.");

            _members.Add(member);
            return member;
        }

        //public void IncreaseMemberShare(Member member, int numberOfShares)
        //{
        //    if (MemberNotFound(member))
        //    {
        //        throw new ArgumentException("No member found in fund.", nameof(member));
        //    }

        //    var m = GetMember(member.Id);
        //    if (TotalSharesExceedFundMaxOfShares(m.TotalShares(), numberOfShares))
        //    {
        //        throw new InvalidOperationException("Cannot increase shares.",
        //            new ArgumentOutOfRangeException(nameof(m.NumberOfShares), m.NumberOfShares, "Member shares cannot be greater than Fund maximum shares."));
        //    }

        //    m.IncreaseSharesBy(numberOfShares);
        //}

        //public void DecreaseMemberShare(Member member, int numberOfShares)
        //{
        //    if (MemberNotFound(member))
        //    {
        //        throw new ArgumentException("No member found in fund.", nameof(member));
        //    }

        //    var m = GetMember(member.Id);
        //    if (m.TotalShares() - numberOfShares < 1)
        //    {
        //        throw new InvalidOperationException("Cannot decrease shares.",
        //            new ArgumentOutOfRangeException(nameof(m), m.TotalShares(), "Member cannot have less than 1 shares."));
        //    }

        //    m.DecreaseSharesBy(numberOfShares);
        //}

    }
}
