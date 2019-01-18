using System;
using SainaYar.InvestmentFund.Core.Model;
using SainaYar.SharedKernel.Enums;
using SainaYar.SharedKernel.Interfaces;

namespace SainaYar.InvestmentFund.Core.Events
{
    public class MemberShareUpdatedEvent : IDomainEvent
    {
        public MemberShareUpdatedEvent(Member member, MemberShareUpdateType updateType) : this()
        {
            MemberUpdated = member;
            MemberUpdateType = updateType;
        }

        public MemberShareUpdatedEvent()
        {
            this.Id = Guid.NewGuid();
            DateTimeEventOccurred = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DateTimeEventOccurred { get; private set; }
        public Member MemberUpdated { get; private set; }
        public MemberShareUpdateType MemberUpdateType { get; private set; }
    }
}
