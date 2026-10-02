// Set the HTTP method to GET in RequestMessage.

using System;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            using (Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com"))
            {
                request.Method = Aspose.Html.Net.HttpMethod.Get;

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
                {
                    System.Console.WriteLine("Document title: " + document.Title);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}