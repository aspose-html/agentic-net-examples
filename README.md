# Aspose.HTML for .NET — Agentic Examples

Agentic, build-validated C# code examples for **Aspose.HTML for .NET** covering HTML conversion, DOM manipulation, and web content extraction. Every example compiles and runs successfully. Includes `agents.md` guides optimized for AI coding agents.

## About Aspose.HTML for .NET

[Aspose.HTML for .NET](https://products.aspose.com/html/net/) is an HTML document manipulation and conversion library for .NET applications. It provides a full DOM implementation and lets developers parse, edit, render, and convert HTML documents programmatically without a browser.

**Key capabilities:**
- Convert HTML to PDF, image (PNG/JPEG), XPS, Markdown, and EPUB
- Parse and query the DOM with a standards-based API, including XPath and traversal (`NodeIterator`/`TreeWalker`)
- Render HTML with CSS, including HTML5 Canvas content, to raster or vector output
- Load HTML from local files, in-memory strings, or fetch it live from a remote URL
- Extract embedded assets — images, SVG, stylesheets — from an HTML document or a web page
- Observe and react to DOM mutations programmatically
- Produce custom in-memory or streamed output via `ICreateStreamProvider`

## Install

```bash
dotnet add package Aspose.HTML
```

Or via NuGet Package Manager:
```
Install-Package Aspose.HTML
```

Requires .NET SDK 10.0 or later.

## Statistics

| Metric | Value |
|--------|-------|
| Total Examples | 1807 |
| Categories | 18 |
| Overall Pass Rate | 100.0% |
| Package Version | Aspose.HTML 26.9 |
| Last Updated | 2026-10-02 |

## Repository Structure

```
agents.md
README.md
+-- advanced-html-editing/
+-- data-extraction/
+-- epub-converter/
+-- extract-images-from-website/
+-- extract-svg-from-website/
+-- fine-tuning-converters/
+-- html-converter/
+-- html-navigation/
+-- markdown-converter/
+-- markdown-processing/
+-- message-handlers/
+-- mhtml-converter/
+-- save-file-from-url/
+-- svg-converter/
+-- web-accessibility/
+-- website-to-html/
+-- working-with-html-documents/
+-- working-with-html-templates/
```

## Categories

| Category | Examples | Pass Rate | Details |
|----------|----------|-----------|---------|
| [Advanced Html Editing](./advanced-html-editing/) | 37 | 100.0% | [agents.md](./advanced-html-editing/agents.md) |
| [Data Extraction](./data-extraction/) | 81 | 100.0% | [agents.md](./data-extraction/agents.md) |
| [Epub Converter](./epub-converter/) | 143 | 100.0% | [agents.md](./epub-converter/agents.md) |
| [Extract Images From Website](./extract-images-from-website/) | 37 | 100.0% | [agents.md](./extract-images-from-website/agents.md) |
| [Extract Svg From Website](./extract-svg-from-website/) | 30 | 100.0% | [agents.md](./extract-svg-from-website/agents.md) |
| [Fine Tuning Converters](./fine-tuning-converters/) | 121 | 100.0% | [agents.md](./fine-tuning-converters/agents.md) |
| [Html Converter](./html-converter/) | 198 | 100.0% | [agents.md](./html-converter/agents.md) |
| [Html Navigation](./html-navigation/) | 120 | 100.0% | [agents.md](./html-navigation/agents.md) |
| [Markdown Converter](./markdown-converter/) | 79 | 100.0% | [agents.md](./markdown-converter/agents.md) |
| [Markdown Processing](./markdown-processing/) | 120 | 100.0% | [agents.md](./markdown-processing/agents.md) |
| [Message Handlers](./message-handlers/) | 98 | 100.0% | [agents.md](./message-handlers/agents.md) |
| [Mhtml Converter](./mhtml-converter/) | 107 | 100.0% | [agents.md](./mhtml-converter/agents.md) |
| [Save File From Url](./save-file-from-url/) | 28 | 100.0% | [agents.md](./save-file-from-url/agents.md) |
| [Svg Converter](./svg-converter/) | 105 | 100.0% | [agents.md](./svg-converter/agents.md) |
| [Web Accessibility](./web-accessibility/) | 96 | 100.0% | [agents.md](./web-accessibility/agents.md) |
| [Website to Html](./website-to-html/) | 30 | 100.0% | [agents.md](./website-to-html/agents.md) |
| [Working With Html Documents](./working-with-html-documents/) | 332 | 100.0% | [agents.md](./working-with-html-documents/agents.md) |
| [Working With Html Templates](./working-with-html-templates/) | 45 | 100.0% | [agents.md](./working-with-html-templates/agents.md) |

## Frequently Asked Questions

### How do I convert HTML to PDF in Aspose.HTML for .NET?

Load the document with `HTMLDocument`, then call `Converter.ConvertHTML(document, new PdfSaveOptions(), outputPath)`, or use the `Rendering.Pdf` namespace's `PdfDevice` directly when you need lower-level control (custom page size/margins via `PdfRenderingOptions`). See `html-converter` and `fine-tuning-converters`.

### How do I extract images from an HTML page or website?

Load the page (from a file, string, or a live URL via `HttpClient`), locate `<img>` elements or CSS background images through the DOM, and save each one via `ImageSaveOptions` or by reading the underlying resource stream directly. See `extract-images-from-website`.

### How do I convert HTML to Markdown?

Use `Converter.ConvertHTML(document, new MarkdownSaveOptions(), outputPath)`. See `markdown-converter` and `markdown-processing`.

### How do I query the DOM with XPath in Aspose.HTML?

Use `HTMLDocument.CreateNodeIterator` / `Evaluate` from the `Aspose.Html.Dom.XPath` namespace against an `HTMLDocument`, which implements the standard DOM `Document` interface. See `data-extraction` and `html-navigation`.

### How do I render HTML to an image (PNG/JPEG)?

Convert with `Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Png), outputPath)`, or use `ICreateStreamProvider` when you need the bytes in memory rather than on disk. See `html-converter`.

### How do I extract SVG content from an HTML page?

Locate `<svg>` elements via the DOM (`Aspose.Html.Dom.Svg`), then save each `SVGDocument` directly or via a resource handler for embedded SVG assets. See `extract-svg-from-website`.

### Why do I get `CS0535` on my `ICreateStreamProvider` implementation?

The interface requires exactly four members: two `GetStream` overloads, `ReleaseStream`, and `Dispose`. An incomplete implementation fails to compile — see the Boundaries section in [AGENTS.md](./AGENTS.md).

### Can I convert HTML to EPUB?

Yes — `Converter.ConvertHTML` accepts `EpubSaveOptions` for e-book output. See `epub-converter`.

### Can these examples be used by AI coding agents like Claude, Copilot, or Cursor?

Yes — the repository ships an `AGENTS.md` at root and a lowercase `agents.md` in each category folder, plus `.well-known/agent.json`, `llm.txt`, and a machine-readable `index.json`. Point your agent at the repo's raw URLs and it can browse examples programmatically.

### Do I need an Aspose.HTML license to run these examples?

The library runs in evaluation mode without a license (with some output restrictions). For production use, apply a license via `new License().SetLicense(path)`. Purchase / trial options: https://purchase.aspose.com/buy.

## How to Use

Each example is a self-contained C# file. Clone the repository and run any example directly:

```bash
git clone https://github.com/aspose-html/agentic-net-examples.git
cd agentic-net-examples

# Navigate to a category
cd html-converter

# Create a console project, add the package, and run an example
dotnet new console -o ExampleRunner
cd ExampleRunner
dotnet add package Aspose.HTML

# Copy any .cs file from the category as Program.cs and run
cp ../convert-html-to-pdf.cs Program.cs
dotnet run
```

## Example

Convert an HTML file to PDF:

```csharp
using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        using (var document = new HTMLDocument("input.html"))
        {
            Converter.ConvertHTML(document, new PdfSaveOptions(), "output.pdf");
            Console.WriteLine("Saved output.pdf");
        }
    }
}
```

Query the DOM with XPath:

```csharp
using System;
using Aspose.Html;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        using (var document = new HTMLDocument("input.html"))
        {
            var result = document.Evaluate("//a/@href", document, null, XPathResultType.Any, null);
            XPathNavigator? node;
            while ((node = result.IterateNext()) != null)
            {
                Console.WriteLine(node.Value);
            }
        }
    }
}
```

## For AI Coding Agents

This repository includes an [`AGENTS.md`](./AGENTS.md) file at the root and a lowercase `agents.md` in each category folder. These files provide AI coding agents with:

- Required namespaces and using directives for each category
- Correct API property paths and patterns
- Common pitfalls and prohibited patterns
- Example code fragments for key operations

If you are an AI coding agent generating Aspose.HTML for .NET code, read the relevant `agents.md` before generating examples to avoid common API mistakes.

## Prerequisites

- .NET SDK 10.0 or later
- Aspose.HTML for .NET 26.9 (via NuGet)

A valid [Aspose license](https://purchase.aspose.com/buy) is required for production use. For evaluation, examples run without a license but output may include evaluation notices.

## Agentic .NET Ecosystem

Other Aspose products with agentic, build-validated example repositories:

| Product | Repository | Focus |
|---------|-----------|-------|
| Aspose.Words for .NET | [aspose-words/agentic-net-examples](https://github.com/aspose-words/agentic-net-examples) | Word processing, DOCX, mail merge |
| Aspose.Cells for .NET | [aspose-cells/agentic-net-examples](https://github.com/aspose-cells/agentic-net-examples) | Spreadsheets, Excel, charts |
| Aspose.BarCode for .NET | [aspose-barcode/agentic-net-examples](https://github.com/aspose-barcode/agentic-net-examples) | Barcode generation and recognition |
| Aspose.Imaging for .NET | [aspose-imaging/agentic-net-examples](https://github.com/aspose-imaging/agentic-net-examples) | Image conversion, manipulation |
| Aspose.Slides for .NET | [aspose-slides/agentic-net-examples](https://github.com/aspose-slides/agentic-net-examples) | Presentations, PowerPoint |
| Aspose.Email for .NET | [aspose-email/agentic-net-examples](https://github.com/aspose-email/agentic-net-examples) | Email, calendars, messaging |
| Aspose.PDF for .NET | [aspose-pdf/agentic-net-examples](https://github.com/aspose-pdf/agentic-net-examples) | PDF creation, conversion and manipulation |

## Related Resources

### Official Documentation
- [Aspose.HTML for .NET Documentation](https://docs.aspose.com/html/net/) — Guides, tutorials, and feature overviews
- [API Reference](https://reference.aspose.com/html/net/) — Complete class/method reference
- [Release Notes](https://releases.aspose.com/html/net/release-notes/) — Version history and changelogs

### Downloads & Packages
- [NuGet Package](https://www.nuget.org/packages/Aspose.HTML/) — Install via `dotnet add package Aspose.HTML`
- [Direct Downloads](https://releases.aspose.com/html/net/) — MSI/ZIP installers and DLLs

### Community & Support
- [Aspose.HTML Forum](https://forum.aspose.com/c/html) — Community Q&A and official support
- [Aspose Blog - HTML](https://blog.aspose.com/category/html/) — Tutorials, tips, and product updates
- [GitHub Issues](https://github.com/aspose-html/agentic-net-examples/issues) — Bug reports and feature requests

### Licensing & Purchase
- [Purchase](https://purchase.aspose.com/buy) — Commercial license options
- [Temporary License](https://purchase.aspose.com/temporary-license/) — Full-feature evaluation license

## License

All examples use [Aspose.HTML for .NET](https://products.aspose.com/html/net/) and require a valid license for production use. See [licensing options](https://purchase.aspose.com/buy).

---

*This repository is maintained by automated code generation. For AI-friendly guidance, see [AGENTS.md](./AGENTS.md). Last updated: 2026-10-02*

<!-- AUTOGENERATED:START -->
Updated: 2026-10-02 | Examples: 1807 | Categories: 18 | Package: Aspose.HTML 26.9
<!-- AUTOGENERATED:END -->
