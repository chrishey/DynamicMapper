using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Dynamic.Mapper
{
    public class MappingClass
    {
        public EndModel Map(Dictionary<string, object> payload, MappingConfig config)
        {
            // create a dynamic object from the payload
            var interimModel = new ExpandoObject() as IDictionary<string, object>;
            var model = new EndModel();

            foreach (var configEntry in config.MappingDictionary)
            {
                var valuesArray = configEntry.Value.Split(',');
                var payloadValue = string.Empty;

                foreach (var value in valuesArray)
                {
                    // get the values off the payload
                    payloadValue += payload[value];
                }

                interimModel[configEntry.Key] = payloadValue;
            }

            foreach (var interimModelKey in interimModel.Keys)
            {
                // find the property on the EndModel that the key refers to
                var modelProperty = model.GetType().GetProperty(interimModelKey, BindingFlags.IgnoreCase);
                if(modelProperty == null) continue;
                modelProperty.SetValue(model, interimModel[interimModelKey]);
            }

            return model;
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
