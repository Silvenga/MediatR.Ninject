using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Ninject;
using Ploeh.AutoFixture;
using Xunit;

namespace MediatR.Ninject.Tests
{
    public class FlowFacts
    {
        private static readonly Fixture AutoFixture = new Fixture();

        private readonly IKernel _kernel;

        public FlowFacts()
        {
            _kernel = new StandardKernel();
            _kernel.BindMediatR();
            _kernel.Bind<IRequestHandler<QueryFixture.Query, QueryFixture.Result>>().To<QueryFixtureHandler>();
        }

        [Fact]
        public async Task Standard_flow_should_work()
        {
            var mediator = _kernel.Get<IMediator>();
            var input = AutoFixture.Create<QueryFixture.Query>();

            // Act
            var result = await mediator.Send(input);

            // Assert
            result.Output.Should().Be(input.Input);
        }

        public static class QueryFixture
        {
            public class Query : IRequest<Result>
            {
                public Guid Input { get; set; }
            }

            public class Result
            {
                public Guid Output { get; set; }
            }
        }

        public class QueryFixtureHandler : IRequestHandler<QueryFixture.Query, QueryFixture.Result>
        {
            public Task<QueryFixture.Result> Handle(QueryFixture.Query message, CancellationToken cancellationToken)
            {
                return Task.FromResult(new QueryFixture.Result {Output = message.Input});
            }
        }
    }
}