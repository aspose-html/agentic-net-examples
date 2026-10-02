// Create a Configuration instance and retrieve IUserAgentService to customize the user‑agent string.

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Html.Configuration config = new Aspose.Html.Configuration())
            {
                Aspose.Html.Services.IUserAgentService userAgentService = config.GetService<Aspose.Html.Services.IUserAgentService>();
                // Example customization (UserStyleSheet is available)
                userAgentService.UserStyleSheet = "body { font-family: Arial; }";
                System.Console.WriteLine("IUserAgentService retrieved and UserStyleSheet set.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}