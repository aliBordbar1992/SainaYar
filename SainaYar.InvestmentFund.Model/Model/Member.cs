using System;
using SainaYar.InvestmentFund.Core.Events;
using SainaYar.SharedKernel.Enums;
using SainaYar.SharedKernel.Shared;

namespace SainaYar.InvestmentFund.Core.Model
{
    public class Member : Entity<Guid>
    {
        public Guid FundId { get; private set; }
        public int NumberOfShares { get; private set; }
        public string FullName { get; private set; }

        //no persisting
        public bool TotalSharesExceedingFundMaxShare { get; set; }

        public Member(Guid memberId) : base(memberId) {}
        private Member() : base(Guid.NewGuid()) {}

        public static Member Create(Guid fundId, string memberName, int numberOfShares)
        {
            var newMember = new Member(Guid.NewGuid());
            newMember.FundId = fundId;
            newMember.FullName = memberName;
            newMember.NumberOfShares = numberOfShares;

            return newMember;
        }

        public int TotalShares()
        {
            return NumberOfShares;
        }

        public void EditName(string newName)
        {
            FullName = newName;
        }

        public void IncreaseSharesBy(int numberOfShares)
        {
            NumberOfShares += numberOfShares;

            var increasedShareEvent = new MemberShareUpdatedEvent(this, MemberShareUpdateType.Increased);
            DomainEvents.Raise(increasedShareEvent);
        }

        public void DecreaseSharesBy(int numberOfShares)
        {
            NumberOfShares -= numberOfShares;

            var decreasedShareEvent = new MemberShareUpdatedEvent(this, MemberShareUpdateType.Decreased);
            DomainEvents.Raise(decreasedShareEvent);
        }
    }
}
