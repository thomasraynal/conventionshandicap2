using ConventionsHandicap.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ConventionsHandicap.Shared
{
    public class PropertyArrayDtoJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Property[]) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Null)
            {
                var jObject = JObject.Load(reader);

                var properties = new List<Property>();

                foreach (var jProperty in jObject)
                {
                    var propertyName = jProperty.Key;
                    var propertyValue = jProperty.Value;
              
                    var property = new Property()
                    {
                        Code = propertyName,
                        Value = propertyValue?.Value<string>()
                    };

                    properties.Add(property);

                }

                return properties.ToArray();

            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (null == value)
            {
                return;
            }

            var properties = value as Property[];

            if (null == properties)
            {
                return;
            }

            writer.WriteStartObject();

            foreach (var item in properties)
            {
                writer.WritePropertyName(item.Code);
                writer.WriteValue(item.Value);
            }

            writer.WriteEndObject();
        }
    }

}
