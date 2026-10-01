// Convert HTML to GIF and embed the resulting image as an inline attachment in an HTML email body.

using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output GIF paths
            string htmlPath = "sample.html";
            string gifPath = "output.gif";

            // Create a simple HTML file
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set image save options for GIF format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, gifPath);

            // Prepare an email with the GIF as an inline attachment
            MailMessage message = new MailMessage();
            message.From = new MailAddress("sender@example.com");
            message.To.Add(new MailAddress("recipient@example.com"));
            message.Subject = "HTML to GIF Inline Image Example";

            // HTML body referencing the inline image via Content-ID
            string htmlBody = "<html><body><h2>Embedded GIF Image</h2><img src=\"cid:gifImage\" alt=\"GIF\"/></body></html>";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

            // Create linked resource for the GIF
            LinkedResource inlineGif = new LinkedResource(gifPath, MediaTypeNames.Image.Gif);
            inlineGif.ContentId = "gifImage";
            inlineGif.TransferEncoding = TransferEncoding.Base64;
            alternateView.LinkedResources.Add(inlineGif);

            message.AlternateViews.Add(alternateView);

            // Demonstrate that the email is prepared
            Console.WriteLine("Email prepared successfully.");
            Console.WriteLine("Subject: " + message.Subject);
            Console.WriteLine("Body: " + htmlBody);
            Console.WriteLine("Inline GIF path: " + gifPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}