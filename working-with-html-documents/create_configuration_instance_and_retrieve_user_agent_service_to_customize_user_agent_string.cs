// Create a Configuration instance and retrieve IUserAgentService to customize the user‑agent string.

using System;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = config.GetService<Aspose.Html.Services.IUserAgentService>();
            Console.WriteLine("IUserAgentService retrieved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}