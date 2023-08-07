using BinaryMessageCodec.Library;
using System.Text;

namespace BinaryMessageCodec.Test
{
    public class MessageCodecTests
    {

        private readonly IMessageCodec _codec; 

        public MessageCodecTests()
        {
            _codec = new MessageCodec();
        }

        [Fact]
        public void TestEncodeDecode()
        {

            var originalMessage = new Message
            {
                Headers = new Dictionary<string, string> { { "header1", "value1" }, { "header2", "value2" } },
                Payload = System.Text.Encoding.UTF8.GetBytes("payload test data")
            };



            var encodedMessage = _codec.Encode(originalMessage);
            var decodedMessage = _codec.Decode(encodedMessage);


            Assert.Equal(originalMessage.Headers.Count, decodedMessage.Headers.Count);
            foreach (var header in originalMessage.Headers)
            {
                Assert.True(decodedMessage.Headers.ContainsKey(header.Key));
                Assert.Equal(header.Value, decodedMessage.Headers[header.Key]);
            }
            Assert.Equal(originalMessage.Payload, decodedMessage.Payload);
        }


        [Fact]
        public void TestEmptyPayload()
        {
            var originalMessage = new Message
            {
                Headers = new Dictionary<string, string> { { "header1", "value1" } },
                Payload = Array.Empty<byte>()
            };

            var encodedMessage = _codec.Encode(originalMessage);
            var decodedMessage = _codec.Decode(encodedMessage);

            Assert.Equal(originalMessage.Headers, decodedMessage.Headers);
            Assert.Empty(decodedMessage.Payload);
        }

        [Fact]
        public void TestNoHeaders()
        {
            var originalMessage = new Message
            {
                Headers = new Dictionary<string, string>(),
                Payload = Encoding.UTF8.GetBytes("Payload Data for testing")
            };

            var encodedMessage = _codec.Encode(originalMessage);
            var decodedMessage = _codec.Decode(encodedMessage);

            Assert.Empty(decodedMessage.Headers);
            Assert.Equal(originalMessage.Payload, decodedMessage.Payload);
        }

        [Fact]
        public void TestNullHeadersOrPayload()
        {
            var originalMessage = new Message
            {
                Headers = null,
                Payload = Encoding.UTF8.GetBytes("Payload Data for testing")
            };

            Assert.Throws<ArgumentNullException>(() => _codec.Encode(originalMessage));

            originalMessage.Headers = new Dictionary<string, string> { { "header1", "value1" } };
            originalMessage.Payload = null;

            Assert.Throws<ArgumentNullException>(() => _codec.Encode(originalMessage));
        }
    }
}
