// Convert HTML to PDF and attach the generated document to an email using SMTP client library.

using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPdfEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Source HTML URL
                string htmlUrl = "https://example.com";

                // Output PDF file path
                string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "converted.pdf");

                // Load HTML document from URL
                HTMLDocument document = new HTMLDocument(htmlUrl);

                // Set PDF conversion options (default)
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert HTML to PDF and save to file
                Converter.ConvertHTML(document, options, outputPdfPath);

                // Prepare email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sender@example.com");
                mail.To.Add("recipient@example.com");
                mail.Subject = "Converted PDF Document";
                mail.Body = "Please find the attached PDF generated from HTML.";

                // Attach the generated PDF
                mail.Attachments.Add(new Attachment(outputPdfPath));

                // Configure SMTP client (replace with actual server details)
                SmtpClient smtp = new SmtpClient("smtp.example.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("smtp_user", "smtp_password");

                // Send the email
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}