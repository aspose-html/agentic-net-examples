// Register HtmlDocument and HttpClient services via dependency injection for testability.

using System;
using System.Net.Http;
using System.Collections.Generic;
using Aspose.Html;

class SimpleServiceProvider : IDisposable
{
    private readonly Dictionary<Type, Func<object>> _registrations = new Dictionary<Type, Func<object>>();
    private readonly List<IDisposable> _disposables = new List<IDisposable>();

    public void Register<TService>(Func<TService> factory)
    {
        _registrations[typeof(TService)] = () => factory();
    }

    public TService GetService<TService>()
    {
        if (_registrations.TryGetValue(typeof(TService), out var factory))
        {
            var instance = (TService)factory();
            if (instance is IDisposable disposable)
                _disposables.Add(disposable);
            return instance;
        }
        throw new InvalidOperationException($"Service of type {typeof(TService)} is not registered.");
    }

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}

class Program
{
    static Aspose.Html.HTMLDocument createDocumentMethod(string htmlContent, string baseUrl)
    {
        return new Aspose.Html.HTMLDocument(htmlContent, baseUrl);
    }

    static string loadHtmlMethod()
    {
        return "<html><body><h1>Hello DI</h1></body></html>";
    }

    static void Main()
    {
        try
        {
            using (var provider = new SimpleServiceProvider())
            {
                // Register HttpClient
                provider.Register<HttpClient>(() => new HttpClient());

                // Register HTMLDocument
                provider.Register<Aspose.Html.HTMLDocument>(() =>
                    createDocumentMethod(loadHtmlMethod(), "about:blank"));

                // Resolve services
                var httpClient = provider.GetService<HttpClient>();
                var document = provider.GetService<Aspose.Html.HTMLDocument>();

                // Use the document
                string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine("Document OuterHTML:");
                Console.WriteLine(outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}