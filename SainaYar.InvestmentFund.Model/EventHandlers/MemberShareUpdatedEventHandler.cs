using System;
using SainaYar.InvestmentFund.Core.Events;
using SainaYar.SharedKernel.Enums;
using SainaYar.SharedKernel.Interfaces;

namespace SainaYar.InvestmentFund.Core.EventHandlers
{
    public class MemberShareUpdatedEventHandler : IHandle<MemberShareUpdatedEvent>
    {
        private MemberShareUpdatedEvent _args;

        public void Handle(MemberShareUpdatedEvent args)
        {
            _args = args;
            switch (args.MemberUpdateType)
            {
                case MemberShareUpdateType.Increased:
                    HandleIncreasingShare();
                    break;
                case MemberShareUpdateType.Decreased:
                    HandleDecreasingShare();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void HandleIncreasingShare()
        {
            throw new InvalidOperationException("Cannot increase shares.",
                new ArgumentOutOfRangeException(nameof(_args.MemberUpdated.NumberOfShares), _args.MemberUpdated.NumberOfShares, "Member shares cannot be greater than Fund maximum shares."));
        }
        private void HandleDecreasingShare()
        {
            throw new InvalidOperationException("Cannot decrease shares.",
                new ArgumentOutOfRangeException(nameof(_args.MemberUpdated), _args.MemberUpdated.TotalShares(), "Member cannot have less than 1 shares."));
        }
    }
}