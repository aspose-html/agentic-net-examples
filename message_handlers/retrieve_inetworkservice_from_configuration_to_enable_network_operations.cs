// Retrieve the INetworkService from the Configuration object to enable network operations.

using System;
using Aspose.Html;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            Console.WriteLine(networkService != null ? "INetworkService retrieved successfully." : "Failed to retrieve INetworkService.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}