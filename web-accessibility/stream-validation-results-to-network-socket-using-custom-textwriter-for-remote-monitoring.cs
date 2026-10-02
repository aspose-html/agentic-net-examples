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
    public NetworkTextWriter(NetworkStream stream) { _stream = stream; }
    public override Encoding Encoding => Encoding.UTF8;
    public override void Write(char value)
    {
        byte[] buffer = Encoding.GetBytes(new char[] { value });
        _stream.Write(buffer, 0, buffer.Length);
    }
    public override void Write(string value)
    {
        if (value == null) return;
        byte[] buffer = Encoding.GetBytes(value);
        _stream.Write(buffer, 0, buffer.Length);
    }
    public override void WriteLine(string value)
    {
        Write(value + Environment.NewLine);
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
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Sample</h1></body></html>";
            string baseUri = "about:blank";

            using (HTMLDocument document = new HTMLDocument(htmlContent, baseUri))
            {
                var validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);

                using (TcpClient client = new TcpClient("127.0.0.1", 9000))
                using (NetworkStream networkStream = client.GetStream())
                using (NetworkTextWriter writer = new NetworkTextWriter(networkStream))
                {
                    validationResult.SaveTo(writer, ValidationResultSaveFormat.XML);
                    writer.Flush();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}