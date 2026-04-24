// Convert HTML to GIF and embed the resulting image as an inline attachment in an HTML email body.

using System;
using System.IO;
using System.Net.Mail;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string htmlPath = "input.html";
            string gifPath = "output.gif";

            // Convert HTML to GIF
            HTMLDocument document = new HTMLDocument(htmlPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, gifPath);

            // Prepare email with inline GIF
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("sender@example.com");
            mail.To.Add("recipient@example.com");
            mail.Subject = "HTML Email with Inline GIF";

            // HTML body referencing the inline image via Content-ID
            string htmlBody = @"<html><body><h1>Embedded GIF</h1><img src=""cid:EmbeddedGif"" /></body></html>";

            // Create AlternateView for HTML
            AlternateView av = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

            // Attach the GIF as a linked resource
            LinkedResource gifResource = new LinkedResource(gifPath);
            gifResource.ContentId = "EmbeddedGif";
            gifResource.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            av.LinkedResources.Add(gifResource);

            mail.AlternateViews.Add(av);
            mail.IsBodyHtml = true;

            // Send email (SMTP configuration placeholder)
            using (SmtpClient smtp = new SmtpClient("smtp.example.com", 587))
            {
                smtp.Credentials = new System.Net.NetworkCredential("username", "password");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}