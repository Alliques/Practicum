using Persistence;
using System;

namespace BookLibrary.Tests.Common
{
    public abstract class TestBase : IDisposable
    {
        protected readonly RepositoryContext Context;

        public TestBase()
        {
            Context = ContextFactory.Create();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }
}
