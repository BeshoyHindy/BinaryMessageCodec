using System.Text;
using static System.Text.Encoding;

namespace BinaryMessageCodec.Library;

public static class BinaryCodecExtensions
{

    public static void WriteAsciiString(this BinaryWriter writer, string value)
    {
        //  check header limit
        if (value.Length > 1024)
            throw new ArgumentOutOfRangeException(nameof(value), "length exceeded the limit!");

        var bytes = Encoding.ASCII.GetBytes(value);
        writer.Write((byte)value.Length);
        writer.Write(bytes);
    }
    public static string ReadAsciiString(this BinaryReader reader) => ASCII.GetString(reader.ReadBytes(reader.ReadByte()));

}