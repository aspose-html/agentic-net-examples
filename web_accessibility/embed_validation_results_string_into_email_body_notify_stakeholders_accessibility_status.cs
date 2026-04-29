// Embed validation results string into an email body to notify stakeholders of accessibility status.

using System;
using System.Net;
using System.Net.Mail;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "path/to/your/file.html";
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
                ValidationResult validationResult = validator.Validate(document);
                string resultString = validationResult.SaveToString();

                string body = $"Accessibility validation results:{Environment.NewLine}{resultString}";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sender@example.com");
                mail.To.Add("recipient@example.com");
                mail.Subject = "Accessibility Validation Report";
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.example.com"))
                {
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("username", "password");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}