using System.Text;

namespace BinaryMessageCodec.Library;
public class MessageCodec : IMessageCodec
{
    public byte[] Encode(Message message)
    {

        if (message == null)
            throw new ArgumentNullException(nameof(message));

        if (message.Headers == null)
            throw new ArgumentNullException(nameof(message.Headers));

        if (message.Payload == null)
            throw new ArgumentNullException(nameof(message.Payload));


        using (var stream = new MemoryStream())
        {
            using (var writer = new BinaryWriter(stream))
            {
                // Encode headers
                writer.Write((byte)message.Headers.Count);
                foreach (var header in message.Headers)
                {
                    EncodeHeader(writer, header);
                }

                // Encode payload
                if (message.Payload.Length > 256 * 1024)
                    throw new ArgumentOutOfRangeException("Payload size limit exceeded.");

                writer.Write(message.Payload.Length);
                writer.Write(message.Payload);
            }

            return stream.ToArray();
        }
    }
    public Message Decode(byte[] data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        var message = new Message();

        using (var stream = new MemoryStream(data))
        {
            using (var reader = new BinaryReader(stream))
            {
                // Decode headers
                var headerCount = reader.ReadByte();
                for (var i = 0; i < headerCount; i++)
                {
                    var header = DecodeHeader(reader);
                    message.Headers.Add(header.Key, header.Value);
                }

                // Decode payload
                var payloadLen = reader.ReadInt32();
                message.Payload = reader.ReadBytes(payloadLen);
            }
        }

        return message;
    }
    private void EncodeHeader(BinaryWriter writer, KeyValuePair<string, string> header)
    {
        writer.WriteAsciiString(header.Key);
        writer.WriteAsciiString(header.Value);
    }

    private KeyValuePair<string, string> DecodeHeader(BinaryReader reader)
    {
        var name = reader.ReadAsciiString();
        var value = reader.ReadAsciiString();
        return new KeyValuePair<string, string>(name, value);
    }


}
