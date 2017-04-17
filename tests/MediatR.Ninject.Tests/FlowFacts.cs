using System;
using System.Threading.Tasks;

using FluentAssertions;

using Ninject;

using Ploeh.AutoFixture;

using Xunit;

namespace MediatR.Ninject.Tests
{
    public class FlowFacts
    {
        private static readonly Fixture Autofixture = new Fixture();

        private readonly IKernel _kernel;

        public FlowFacts()
        {
            _kernel = new StandardKernel();
            _kernel.BindMediatR();
            _kernel.Bind<IAsyncRequestHandler<QueryFixture.Query, QueryFixture.Result>>().To<QueryFixtureHandler>();
        }

        [Fact]
        public async Task FlowWorks()
        {
            var mediator = _kernel.Get<IMediator>();
            var input = Autofixture.Create<QueryFixture.Query>();

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

        public class QueryFixtureHandler : IAsyncRequestHandler<QueryFixture.Query, QueryFixture.Result>
        {
            public Task<QueryFixture.Result> Handle(QueryFixture.Query message)
            {
                return Task.FromResult(new QueryFixture.Result {Output = message.Input});
            }
        }
    }
}