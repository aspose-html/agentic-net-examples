// Generate a summary report listing each processed URL, output path, and conversion status.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        var items = new List<(string url, string output)>
        {
            ("https://example.com/page1.html", "output1.pdf"),
            ("https://example.com/page2.html", "output2.pdf")
        };
        var results = new List<(string url, string output, string status)>();
        foreach (var item in items)
        {
            try
            {
                var options = new PdfSaveOptions();
                Converter.ConvertHTML(new Url(item.url), options, item.output);
                results.Add((item.url, item.output, "Success"));
            }
            catch (Exception ex)
            {
                results.Add((item.url, item.output, "Failed: " + ex.Message));
            }
        }
        using (var writer = new StreamWriter("summary_report.csv", false))
        {
            writer.WriteLine("URL,OutputPath,Status");
            foreach (var r in results)
            {
                writer.WriteLine($"{r.url},{r.output},{r.status}");
            }
        }
    }
}