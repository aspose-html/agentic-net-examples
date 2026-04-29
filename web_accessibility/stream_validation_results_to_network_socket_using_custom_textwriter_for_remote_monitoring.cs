// Stream validation results to a network socket using a custom TextWriter for remote monitoring.

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class NetworkTextWriter : TextWriter
{
    private readonly NetworkStream _stream;
    public NetworkTextWriter(NetworkStream stream) => _stream = stream;
    public override Encoding Encoding => Encoding.UTF8;
    public override void Write(char value)
    {
        var buffer = Encoding.GetBytes(new[] { value });
        _stream.Write(buffer, 0, buffer.Length);
    }
    public override void Write(string value)
    {
        if (value == null) return;
        var buffer = Encoding.GetBytes(value);
        _stream.Write(buffer, 0, buffer.Length);
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _stream?.Dispose();
        }
        base.Dispose(disposing);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string host = "127.0.0.1";
            int port = 9000;

            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream networkStream = client.GetStream())
            using (NetworkTextWriter writer = new NetworkTextWriter(networkStream))
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);
                validationResult.SaveTo(writer, ValidationResultSaveFormat.XML);
                writer.Flush();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}