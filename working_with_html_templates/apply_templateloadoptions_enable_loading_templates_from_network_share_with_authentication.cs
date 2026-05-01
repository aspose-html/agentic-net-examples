// Apply TemplateLoadOptions to enable loading templates from a network share with authentication.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class NetworkCredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.ICredentials _credentials;
    public NetworkCredentialHandler(System.Net.ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credentials;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var handler = new NetworkCredentialHandler(new System.Net.NetworkCredential("username", "password"));
            var configuration = new Configuration();
            var networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(handler);
            var loadOptions = new TemplateLoadOptions();
            var data = new TemplateData("data.json");
            var templateUrl = new Url(@"\\server\share\template.html");
            var resultDocument = Converter.ConvertTemplate(templateUrl, configuration, data, loadOptions);
            resultDocument.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}