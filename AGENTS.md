---
name: aspose-html-examples
description: AI-friendly C# code examples for Aspose.HTML for .NET
language: csharp
framework: net10.0
package: Aspose.HTML
---

# Aspose.HTML for .NET Examples

AI-friendly repository containing validated C# examples for the Aspose.HTML for .NET API.

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET.
When working in this repository:
- Each `.cs` file is a **standalone Console Application** - do not create multi-file projects
- All examples must **compile and run** without errors using `dotnet build` and `dotnet run`
- Follow the conventions, boundaries, and anti-patterns documented below exactly
- Use the **Command Reference** section for build/run commands

## Capabilities

This agent generates validated C# examples for the following Aspose.HTML for .NET operations:

- **HTML Conversion** — HTML to PDF, image (PNG/JPEG), XPS, Markdown, and EPUB
- **DOM Navigation & Querying** — XPath evaluation, NodeIterator/TreeWalker traversal, DOM manipulation
- **Data Extraction** — Extracting images, SVG, and other assets from HTML and remote web pages
- **Advanced Editing** — DOM mutation observers, HTML5 Canvas rendering, in-place document editing
- **Fine-Tuning Conversion** — Custom page size/margins, rendering options, encryption on PDF output
- **Loading & Input** — Loading HTML from local files, in-memory strings, or remote URLs via `HttpClient`
- **Custom Output** — In-memory/streamed output via `ICreateStreamProvider`

**Input:** Natural language description of an HTML processing operation
**Output:** Standalone C# console application (compiles and runs with `dotnet run`)

## Repository Overview

This repository contains **1807** working code examples demonstrating Aspose.HTML for .NET capabilities.

**Statistics** (as of 2026-10-01):
- Total Examples: 1807
- Categories: 18
- Overall Pass Rate: 100.0%
- Package Version: Aspose.HTML 26.8

## Category Details

### advanced-html-editing
- Examples: 37
- Guide: [agents.md](./advanced-html-editing/agents.md)

### data-extraction
- Examples: 81
- Guide: [agents.md](./data-extraction/agents.md)

### epub-converter
- Examples: 143
- Guide: [agents.md](./epub-converter/agents.md)

### extract-images-from-website
- Examples: 37
- Guide: [agents.md](./extract-images-from-website/agents.md)

### extract-svg-from-website
- Examples: 30
- Guide: [agents.md](./extract-svg-from-website/agents.md)

### fine-tuning-converters
- Examples: 121
- Guide: [agents.md](./fine-tuning-converters/agents.md)

### html-converter
- Examples: 198
- Guide: [agents.md](./html-converter/agents.md)

### html-navigation
- Examples: 120
- Guide: [agents.md](./html-navigation/agents.md)

### markdown-converter
- Examples: 79
- Guide: [agents.md](./markdown-converter/agents.md)

### markdown-processing
- Examples: 120
- Guide: [agents.md](./markdown-processing/agents.md)

### message-handlers
- Examples: 98
- Guide: [agents.md](./message-handlers/agents.md)

### mhtml-converter
- Examples: 107
- Guide: [agents.md](./mhtml-converter/agents.md)

### save-file-from-url
- Examples: 28
- Guide: [agents.md](./save-file-from-url/agents.md)

### svg-converter
- Examples: 105
- Guide: [agents.md](./svg-converter/agents.md)

### web-accessibility
- Examples: 96
- Guide: [agents.md](./web-accessibility/agents.md)

### website-to-html
- Examples: 30
- Guide: [agents.md](./website-to-html/agents.md)

### working-with-html-documents
- Examples: 332
- Guide: [agents.md](./working-with-html-documents/agents.md)

### working-with-html-templates
- Examples: 45
- Guide: [agents.md](./working-with-html-templates/agents.md)

## Boundaries

Mined from this pipeline's own generation policies (`optimized_core_policies.json`) — real
constraints that come up repeatedly when working with this API, not invented advice.

### Always

#### Use the file-path overload for simple file output
```csharp
document.Save(new PdfSaveOptions(), "output.pdf");
// Only reach for ICreateStreamProvider when the task genuinely needs
// in-memory/streamed output -- it is not the default path.
```

#### Implement ICreateStreamProvider completely, if you use it at all
```csharp
public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
{
    public System.IO.Stream GetStream(string name, string extension) => new System.IO.MemoryStream();
    public System.IO.Stream GetStream(string name, string extension, int page) => new System.IO.MemoryStream();
    public void ReleaseStream(System.IO.Stream stream) { /* read/dispose as needed */ }
    public void Dispose() { }
}
// A partial implementation of these four members will not compile.
```

#### Save the result of ConvertTemplate explicitly
```csharp
HTMLDocument result = Converter.ConvertTemplate(templatePath, dataPath);
result.Save("output.html");
// ConvertTemplate does not accept an outputPath parameter.
```

### Never

- Never pass a `MemoryStream` directly to a `Converter` method for image conversion — use `ICreateStreamProvider`
- Never mix `Converter` (direct conversion) and `Rendering`-namespace APIs (`PdfDevice`, `PdfRenderingOptions`) arbitrarily — use `Rendering` only when the task needs lower-level control the `Converter` overloads don't expose
- Never use APIs from other Aspose products (`Aspose.PDF`, `Aspose.Words`) inside an Aspose.HTML example
- Never block on `Console.ReadLine()`/`Console.ReadKey()` — every example must run to completion unattended
- Never invent a property, method, or enum value that isn't in the real Aspose.HTML API surface

## Repository Structure

```
agents.md
index.json
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

## Category Index

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

## Command Reference

```bash
dotnet new console -n ExampleProject --framework net10.0
dotnet add package Aspose.HTML
dotnet build --configuration Release --verbosity minimal
dotnet run
```

### Project File (.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Aspose.HTML" Version="26.8" />
  </ItemGroup>
</Project>
```

## Common Error Codes

| Code | Meaning | Fix |
|------|---------|-----|
| `CS0535` | Interface member not implemented | `ICreateStreamProvider` needs all 4 members — see Boundaries above |
| `CS1061` | Member does not exist on type | Verify property path; check the Aspose.HTML API reference |
| `CS0246` | Type or namespace not found | Add the missing `using Aspose.Html...;` |
| `CS1502` | Argument type mismatch | `Converter` image overloads take `ICreateStreamProvider`, not `MemoryStream` |

<!-- AUTOGENERATED:START -->
Updated: 2026-10-01 | Examples: 1807 | Categories: 18 | Package: Aspose.HTML 26.8
<!-- AUTOGENERATED:END -->

---
*This repository is maintained by automated code generation. Last updated: 2026-10-01 | Total examples: 1807*
