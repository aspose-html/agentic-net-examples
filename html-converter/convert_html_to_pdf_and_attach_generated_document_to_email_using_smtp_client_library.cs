// Convert HTML to PDF and attach the generated document to an email using SMTP client library.

using System;
using System.IO;
using System.Net.Mail;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream) { }

    public void Dispose()
    {
        foreach (var s in Streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "");
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                var pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                byte[] pdfBytes = pdfStream.ToArray();

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("sender@example.com");
                    message.To.Add("recipient@example.com");
                    message.Subject = "HTML to PDF Attachment";
                    message.Body = "Please find the PDF attached.";

                    using (var attachmentStream = new MemoryStream(pdfBytes))
                    {
                        var attachment = new Attachment(attachmentStream, "document.pdf", "application/pdf");
                        message.Attachments.Add(attachment);

                        using (var client = new SmtpClient("localhost", 25))
                        {
                            // client.Credentials = new System.Net.NetworkCredential("username", "password");
                            client.Send(message);
                        }
                    }
                }
            }

            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}