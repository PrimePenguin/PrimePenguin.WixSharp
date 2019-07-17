using System;
using Newtonsoft.Json;

namespace WixSharp.Converters
{
    /// <summary>
    /// A custom integer converter that converts null to zero 
    /// </summary>
    public class NullToZeroConverter:JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null || string.IsNullOrEmpty(reader.Value?.ToString())) return 0;
            return Convert.ToInt32(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                int number = Int32.Parse(value.ToString());
                writer.WriteValue(number);
            }
        }

    }
}


