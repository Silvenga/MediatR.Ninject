using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Ninject;
using Xunit;

namespace MediatR.Ninject.Tests
{
    public class InjectionFacts
    {
        [Fact]
        public void When_requesting_multiple_types_factory_does_not_return_null()
        {
            var kernel = new StandardKernel();
            kernel.BindMediatR();

            kernel.Bind<IRequestHandler<QueryFixture.Query, QueryFixture.Result>>().To<QueryFixtureHandler>();

            var factory = kernel.Get<ServiceFactory>();

            // Act
            var result = (IEnumerable<IRequestHandler<QueryFixture.Query, QueryFixture.Result>>)
                factory(typeof(IEnumerable<IRequestHandler<QueryFixture.Query, QueryFixture.Result>>));

            // Assert
            result.Should().NotBeNull();
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