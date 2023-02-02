using ToysAndGames.Tests.Fixtures;
using Xunit;

namespace ToysAndGames.Tests
{
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<ToysAndGamesDbContextFixture>, ICollectionFixture<MapperFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
