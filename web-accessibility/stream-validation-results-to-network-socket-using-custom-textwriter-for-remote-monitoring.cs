// Stream validation results to a network socket using a custom TextWriter for remote monitoring.

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

class NetworkTextWriter : TextWriter
{
    private readonly NetworkStream _stream;
    public NetworkTextWriter(NetworkStream stream)
    {
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
    }

    public override Encoding Encoding => Encoding.UTF8;

    public override void Write(char value)
    {
        Write(value.ToString());
    }

    public override void Write(string value)
    {
        if (value == null) return;
        byte[] bytes = Encoding.GetBytes(value);
        _stream.Write(bytes, 0, bytes.Length);
    }

    public override void Write(char[] buffer, int index, int count)
    {
        if (buffer == null) return;
        Write(new string(buffer, index, count));
    }

    public override void Flush()
    {
        _stream.Flush();
        base.Flush();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _stream.Dispose();
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
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            string baseUri = "about:blank";

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                // Create accessibility validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Connect to remote monitoring socket
                using (TcpClient client = new TcpClient("127.0.0.1", 9000))
                using (NetworkStream networkStream = client.GetStream())
                using (NetworkTextWriter writer = new NetworkTextWriter(networkStream))
                {
                    // Stream validation results as XML
                    validationResult.SaveTo(writer, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    writer.Flush();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}