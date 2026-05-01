// Create a Configuration instance and retrieve IUserAgentService to customize the user‑agent string.

using System;
using Aspose.Html;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            using (Configuration config = new Configuration())
            {
                // Retrieve the IUserAgentService from the configuration
                IUserAgentService userAgentService = config.GetService<IUserAgentService>();

                // Customize the user‑agent string if the API provides such a property
                // userAgentService.UserAgent = "MyCustomUserAgent/1.0";

                // Example of customization: set a custom stylesheet
                userAgentService.UserStyleSheet = "body { font-family: Arial; }";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}