using Microsoft.EntityFrameworkCore;
using System;
using ToysAndGames.Data;

namespace ToysAndGames.Tests.Fixtures
{
    public class ToysAndGamesDbContextFixture : IDisposable
    {
        private bool disposedValue;
        
        public ToysAndGamesDbContext Context { get; private set; }

        public ToysAndGamesDbContextFixture()
        {
            var options = new DbContextOptionsBuilder<ToysAndGamesDbContext>().UseInMemoryDatabase("ToysAndGames").Options;

            Context = new ToysAndGamesDbContext(options);

            if (Context.Database.EnsureCreated() == false) throw new ArgumentNullException("Database not initialized");

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (Context is not null)
                    {
                        Context.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ToysAndGamesDbContextFixture()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
