# Aspose.HTML for .NET Examples

AI-friendly repository containing validated C# examples for Aspose.HTML for .NET API.

## Overview

This repository provides working code examples demonstrating Aspose.HTML for .NET capabilities. All examples are automatically generated, compiled, and validated using the Aspose.HTML Examples Generator.

| Metric | Value |
|--------|-------|
| Total examples | 1802 |
| Categories | 19 |
| Target framework | net9.0 |
| Aspose.HTML version | 26.4.0 |
| Last updated | 2026-05-06 |

## Repository Structure

Examples are organized by feature category:

- `advanced_html_editing/` - 37 example(s)
- `data_extraction/` - 81 example(s)
- `epub_converter/` - 143 example(s)
- `extract_images_from_website/` - 37 example(s)
- `extract_svg_from_website/` - 30 example(s)
- `fine_tuning_converters/` - 121 example(s)
- `html_converter/` - 198 example(s)
- `html_navigation/` - 120 example(s)
- `markdown_converter/` - 78 example(s)
- `markdown_processing/` - 119 example(s)
- `message_handlers/` - 98 example(s)
- `mhtml_converter/` - 107 example(s)
- `save_file_from_url/` - 28 example(s)
- `svg_converter/` - 105 example(s)
- `web_accessibility/` - 96 example(s)
- `website_to_html/` - 30 example(s)
- `working_with_html_documents/` - 329 example(s)
- `working_with_html_templates/` - 45 example(s)

Each category contains standalone `.cs` files that can be compiled and run independently.

## Getting Started

### Prerequisites

- .NET SDK (net9.0 or compatible version)
- Aspose.HTML for .NET NuGet package (26.4.0)
- Valid Aspose license (for production use)

### Running Examples

Each example is a self-contained C# file. To run an example:

```bash
cd <CategoryFolder>
dotnet new console -o ExampleProject
cd ExampleProject
dotnet add package Aspose.Html --version 26.x.x
# Copy the example .cs file as Program.cs
dotnet run
```

## Code Patterns

### Loading an HTML Document
```csharp
using Aspose.Html;

using (var document = new HTMLDocument("input.html"))
{
    // Work with document
}
```

### Converting HTML to PDF

```csharp
using Aspose.Html.Converters;
using Aspose.Html.Saving;

Converter.ConvertHTML("input.html", new PdfSaveOptions(), "output.pdf");
```

### Error Handling
```csharp
if (!File.Exists(inputPath))
{
    Console.Error.WriteLine($"Error: File not found - {inputPath}");
    return;
}

try
{
    // Operations
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error: {ex.Message}");
}
```

## Important Notes

- DOM-based processing using HTMLDocument
- Wrap IDisposable objects in using blocks
- Use Console.WriteLine / Console.Error
- Use Aspose.Html.Drawing instead of System.Drawing
- Use Converter API for format conversions
- Each example is independent and runnable

## Documentation

- Each category folder contains an `agents.md`

## Related Resources

### Official Documentation

- [Aspose.HTML for .NET Documentation](https://docs.aspose.com/html/net/)
- [API Reference](https://reference.aspose.com/html/net/)
- [Release Notes](https://releases.aspose.com/html/net/release-notes/)

### Downloads & Packages

- [NuGet Package](https://www.nuget.org/packages/Aspose.Html)
- [Direct Downloads](https://releases.aspose.com/html/net/)

### Community & Support

- [Aspose.HTML Forum](https://forum.aspose.com/c/html/)
- [Aspose Blog - HTML](https://blog.aspose.com/categories/aspose.html-product-family/)
- [GitHub Issues](https://github.com/aspose-html/agentic-net-examples/issues)

### Licensing & Purchase

- [Purchase](https://purchase.aspose.com/buy)
- [Temporary License](https://purchase.aspose.com/temporary-license/)

## License

All examples use [Aspose.HTML for .NET](https://products.aspose.com/html/net/) and require a valid license for production use. See [licensing options](https://purchase.aspose.com/buy).

---

*This repository is maintained by automated code generation. Last updated: 2026-05-06*
