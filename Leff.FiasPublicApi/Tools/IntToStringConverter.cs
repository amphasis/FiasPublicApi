using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Tools
{
    public class IntToStringConverter : JsonConverter<int>
    {
        public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer)
        {
            string stringValue = value.ToString(CultureInfo.InvariantCulture);
            writer.WriteValue(stringValue);
        }

        public override int ReadJson(JsonReader reader, Type objectType, int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string stringValue = reader.ReadAsString();
            bool isEmpty = string.IsNullOrWhiteSpace(stringValue);
            if (isEmpty) return default;
            if (int.TryParse(stringValue, out int value)) return value;
            string message = $"Could not convert value \"{stringValue}\" to int for path {reader.Path}";
            throw new JsonReaderException(message);
        }
    }
}