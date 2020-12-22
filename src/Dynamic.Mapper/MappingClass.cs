using System;
using System.Collections.Generic;

namespace Dynamic.Mapper
{
    public class MappingClass
    {
        public EndModel Map(Dictionary<string, object> payload, MappingConfig config)
        {
            return new EndModel();
        }
    }

    public class EndModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
    }

    public class MappingConfig
    {
        public Dictionary<string, string> MappingDictionary { get; set; }
    }
}
