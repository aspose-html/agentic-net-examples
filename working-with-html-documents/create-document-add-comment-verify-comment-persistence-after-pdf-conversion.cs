// Create a document, add a comment explaining purpose, and verify comment persists after conversion to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare temporary folder and file paths
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExample");
            Directory.CreateDirectory(tempDir);
            string htmlPath = Path.Combine(tempDir, "sample.html");
            string pdfPath = Path.Combine(tempDir, "sample.pdf");

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Add a comment node explaining the purpose
            Aspose.Html.Dom.Comment commentNode = document.CreateComment("This document is generated for PDF conversion test.");
            document.InsertBefore(commentNode, document.DocumentElement);

            // Verify the comment exists before conversion
            bool commentFound = false;
            foreach (Aspose.Html.Dom.Node node in document.ChildNodes)
            {
                if (node.NodeType == Aspose.Html.Dom.Node.COMMENT_NODE &&
                    node.NodeValue != null &&
                    node.NodeValue.Contains("PDF conversion test"))
                {
                    commentFound = true;
                    break;
                }
            }
            if (!commentFound)
                throw new Exception("Comment not found in HTML document before conversion.");

            // Convert HTML document to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            // Verify PDF file was created and is not empty
            FileInfo pdfInfo = new FileInfo(pdfPath);
            if (!pdfInfo.Exists || pdfInfo.Length == 0)
                throw new Exception("PDF conversion failed or output file is empty.");

            // Verify the comment still exists after conversion
            bool commentFoundAfter = false;
            foreach (Aspose.Html.Dom.Node node in document.ChildNodes)
            {
                if (node.NodeType == Aspose.Html.Dom.Node.COMMENT_NODE &&
                    node.NodeValue != null &&
                    node.NodeValue.Contains("PDF conversion test"))
                {
                    commentFoundAfter = true;
                    break;
                }
            }
            if (!commentFoundAfter)
                throw new Exception("Comment missing after conversion.");

            Console.WriteLine("Conversion succeeded and comment persisted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}