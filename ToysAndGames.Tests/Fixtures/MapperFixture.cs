using AutoMapper;
using ToysAndGames.DTO;

namespace ToysAndGames.Tests.Fixtures
{
    public class MapperFixture
    {
        public IConfigurationProvider MapperConfiguration { get; }
        public IMapper Mapper { get; }
        public MapperFixture()
        {
            MapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.AddProfile<AutoMapperProfiles>();
            });
            Mapper = new Mapper(MapperConfiguration);
        }
    }
}
