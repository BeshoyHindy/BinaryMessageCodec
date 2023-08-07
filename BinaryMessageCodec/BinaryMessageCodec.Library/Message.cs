﻿namespace BinaryMessageCodec.Library;

public class Message
{
    public Dictionary<string, string>? Headers { get; set; }
    public byte[] Payload { get; set; }

    public Message()
    {
        Headers = new Dictionary<string, string>();
        Payload = Array.Empty<byte>();
    }
}