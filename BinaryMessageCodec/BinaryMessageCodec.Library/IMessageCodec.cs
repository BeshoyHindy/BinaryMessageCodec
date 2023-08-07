namespace BinaryMessageCodec.Library;

public interface IMessageCodec
{
    byte[] Encode(Message message);

    Message Decode(byte[] data);

    //Task<byte[]> EncodeAsync(Message message);

    //Task<Message> DecodeAsync(byte[] data);
}