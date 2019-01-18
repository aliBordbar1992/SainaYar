using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SainaYar.InvestmentFund.Core.EventHandlers;
using SainaYar.InvestmentFund.Core.Events;
using SainaYar.SharedKernel.Interfaces;
using SainaYar.SharedKernel.Shared;
using StructureMap;
using Xunit;

namespace SainaYar.SharedKernel.Tests
{
    public class ContainerTests
    {
        public class HandlersRegistry : Registry
        {
            public HandlersRegistry()
            {
                Scan(x =>
                {
                    x.Assembly("SainaYar.InvestmentFund.Model.EventHandlers");
                    x.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
                });
            }
        }

        [Fact]
        public void visualization_registry()
        {
            var container = Container.For<HandlersRegistry>();


            container.GetInstance<IHandle<MemberShareUpdatedEvent>>()
                .Should().BeOfType<MemberShareUpdatedEventHandler>();
        }
    }
}
