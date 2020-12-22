using System.Collections.Generic;
using Should;
using Xunit;

namespace Dynamic.Mapper.Tests
{
    public class MappingClassFixture
    {
        private readonly MappingClass _itemUnderTest;
        private MappingConfig _config;
        private Dictionary<string, object> _payload;

        public MappingClassFixture()
        {
            _itemUnderTest = new MappingClass();
        }

        [Fact]
        public void Map_Should_Return_Model()
        {
            SetupValidPayload();
            SetupValidConfig();

            var result = _itemUnderTest.Map(_payload, _config);

            result.ShouldNotBeNull();
        }

        private void SetupValidPayload()
        {
            _payload = new Dictionary<string, object>
            {
                {"firstname", "Bob" },
                {"surname", "Bobbins" }
            };
        }

        private void SetupValidConfig()
        {
            _config = new MappingConfig
            {
                MappingDictionary = new Dictionary<string, string> {{"name", "firstname,surname"}}
            };

        }
    }
}