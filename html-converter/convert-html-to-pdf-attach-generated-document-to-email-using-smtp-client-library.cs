// Convert HTML to PDF and attach the generated document to an email using SMTP client library.

using System;
using System.IO;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1><p>This PDF was generated from HTML.</p></body></html>";
            string baseUri = "about:blank";

            // Output PDF path
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

            // Prepare email
            var message = new MailMessage();
            message.From = new MailAddress("sender@example.com");
            message.To.Add("recipient@example.com");
            message.Subject = "HTML to PDF conversion result";
            message.Body = "Please find the attached PDF generated from HTML.";
            message.Attachments.Add(new Attachment(outputPdfPath));

            // Configure SMTP client (replace with real credentials)
            using (var smtp = new SmtpClient("smtp.example.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("username", "password");
                smtp.Send(message);
            }

            Console.WriteLine("PDF generated and email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}