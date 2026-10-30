// Create a Configuration instance and retrieve IUserAgentService to customize the user‑agent string.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a Configuration instance
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();

            // Retrieve the IUserAgentService
            Aspose.Html.Services.IUserAgentService userAgentService = config.GetService<Aspose.Html.Services.IUserAgentService>();

            // If the service exposes a UserAgent property, it can be set like this:
            // userAgentService.UserAgent = "MyCustomUserAgent/1.0";

            Console.WriteLine("IUserAgentService retrieved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}