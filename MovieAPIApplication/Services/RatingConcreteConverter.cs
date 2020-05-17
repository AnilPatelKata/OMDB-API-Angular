using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPIApplication.Services
{
    public class RatingConcreteConverter<I, T> : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(I);
        }
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(I));
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JArray jsonArray = JArray.Load(reader);
            var deserialized = (List<T>)Activator.CreateInstance(typeof(List<T>));
            serializer.Populate(jsonArray.CreateReader(), deserialized);
            List<I> interfaceList = new List<I>(deserialized.Cast<I>());
            if (interfaceList.Any())
            {
                return interfaceList;
            }

            return null;
        }
    }
}
