// See https://aka.ms/new-console-template for more information

using BinaryMessageCodec.Library;

Console.WriteLine("Testing Binary Message Codec...");

IMessageCodec codec = new MessageCodec();

// test message
var message = new Message
{
    Headers = { { "header1", "value1" }, { "header2", "value2" } },
    Payload = System.Text.Encoding.UTF8.GetBytes("Payload Data")
};

// Encode 
var encodedMessage = codec.Encode(message);
Console.WriteLine("Encoded message: " + BitConverter.ToString(encodedMessage));

// Decode 
var decodedMessage = codec.Decode(encodedMessage);
Console.WriteLine("Decoded message: ");
foreach (var header in decodedMessage.Headers)
{
    Console.WriteLine($"Header: {header.Key}, Value: {header.Value}");
}
Console.WriteLine("Payload: " + System.Text.Encoding.UTF8.GetString(decodedMessage.Payload));


Console.WriteLine("Press any key to exit...");
Console.ReadKey();
