// Insert a subheading under a specified parent heading using the MarkdownSyntaxFactory to create nodes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;

            Aspose.Html.HTMLHeadingElement parentHeading = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            Aspose.Html.Dom.Text parentText = document.CreateTextNode("Parent Heading");
            parentHeading.AppendChild(parentText);

            Aspose.Html.HTMLHeadingElement subHeading = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h2");
            Aspose.Html.Dom.Text subText = document.CreateTextNode("Subheading");
            subHeading.AppendChild(subText);

            body.AppendChild(parentHeading);
            body.AppendChild(subHeading);

            document.Save(outputPath);

            Console.WriteLine("HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}