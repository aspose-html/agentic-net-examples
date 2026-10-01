// Design a short‑circuit handler that returns immediate response when specific query parameter is present.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new QueryParameterHandler());

                string url = "https://example.com?skip=true";

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
                {
                    System.Console.WriteLine("Document loaded. Title: " + document.Title);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    class QueryParameterHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            string uriText = context.Request.RequestUri.ToString();
            if (uriText.Contains("?skip"))
            {
                return;
            }
            Next(context);
        }
    }
}