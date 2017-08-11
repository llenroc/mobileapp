using FluentAssertions;
using System;
using Newtonsoft.Json;
using JsonSerializer = Toggl.Ultrawave.Serialization.JsonSerializer;

namespace Toggl.Ultrawave.Tests
{
    public static class SerializationHelper
    {
        private static readonly JsonSerializer serializer = new JsonSerializer();

        internal static void CanBeDeserialized<T>(string validJson, T validObject)
        {
            var actual = serializer.Deserialize<T>(validJson);

            actual.Should().NotBeNull();
            actual.ShouldBeEquivalentTo(validObject);
        }

        internal static void CanBeSerialized<T>(string validJson, T validObject)
        {
            var actualJson = serializer.Serialize(validObject);

            actualJson.Should().Be(validJson);
        }
        
        internal static void DeserializationShouldFail<T>(string invalidJson)
        {
            Action deserialization = () => serializer.Deserialize<T>(invalidJson);
            
            deserialization.ShouldThrow<JsonSerializationException>();
        }
    }
}
