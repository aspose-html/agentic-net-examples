---
name: aspose-html-examples
description: AI-friendly C# code examples for Aspose.HTML for .NET
language: csharp
framework: net9.0
package: Aspose.Html 26.4.0
---

# Aspose.HTML for .NET Examples

AI-friendly repository containing validated C# examples for Aspose.HTML for .NET API.

## Persona

You are a C# developer specializing in HTML processing, document conversion, DOM manipulation, web resource extraction, and rendering workflows using **Aspose.HTML for .NET**.

When working in this repository:
- Each `.cs` file is a **standalone Console Application** — do not create multi-file projects.
- All examples must **compile and run** without errors using `dotnet build` and `dotnet run`.
- Preserve the user task intent, but only implement properties and APIs that are supported by Aspose.HTML for .NET.
- Prefer compile-safe code over invented or speculative APIs.
- Use the category-level `AGENTS.md` file for local conventions and the root rules below for repository-wide boundaries.
- Use the **Command Reference** section for build/run commands.

## Repository Overview

This repository contains **1802** working code examples demonstrating Aspose.HTML for .NET capabilities.

**Statistics** (as of 2026-05-06):
- Total Examples: 1802
- Categories: 18
- Target Framework: net9.0
- NuGet Package: Aspose.Html 26.4.0

## Category Details

### advanced_html_editing
- Examples: 37
- Guide: [AGENTS.md](./advanced_html_editing/AGENTS.md)

### data_extraction
- Examples: 81
- Guide: [AGENTS.md](./data_extraction/AGENTS.md)

### epub_converter
- Examples: 143
- Guide: [AGENTS.md](./epub_converter/AGENTS.md)

### extract_images_from_website
- Examples: 37
- Guide: [AGENTS.md](./extract_images_from_website/AGENTS.md)

### extract_svg_from_website
- Examples: 30
- Guide: [AGENTS.md](./extract_svg_from_website/AGENTS.md)

### fine_tuning_converters
- Examples: 121
- Guide: [AGENTS.md](./fine_tuning_converters/AGENTS.md)

### html_converter
- Examples: 198
- Guide: [AGENTS.md](./html_converter/AGENTS.md)

### html_navigation
- Examples: 120
- Guide: [AGENTS.md](./html_navigation/AGENTS.md)

### markdown_converter
- Examples: 78
- Guide: [AGENTS.md](./markdown_converter/AGENTS.md)

### markdown_processing
- Examples: 119
- Guide: [AGENTS.md](./markdown_processing/AGENTS.md)

### message_handlers
- Examples: 98
- Guide: [AGENTS.md](./message_handlers/AGENTS.md)

### mhtml_converter
- Examples: 107
- Guide: [AGENTS.md](./mhtml_converter/AGENTS.md)

### save_file_from_url
- Examples: 28
- Guide: [AGENTS.md](./save_file_from_url/AGENTS.md)

### svg_converter
- Examples: 105
- Guide: [AGENTS.md](./svg_converter/AGENTS.md)

### web_accessibility
- Examples: 96
- Guide: [AGENTS.md](./web_accessibility/AGENTS.md)

### website_to_html
- Examples: 30
- Guide: [AGENTS.md](./website_to_html/AGENTS.md)

### working_with_html_documents
- Examples: 329
- Guide: [AGENTS.md](./working_with_html_documents/AGENTS.md)

### working_with_html_templates
- Examples: 45
- Guide: [AGENTS.md](./working_with_html_templates/AGENTS.md)

## Repository Structure

Examples are organized by feature category:

- `advanced_html_editing/` - 37 example(s); guide: [`AGENTS.md`](./advanced_html_editing/AGENTS.md)
- `data_extraction/` - 81 example(s); guide: [`AGENTS.md`](./data_extraction/AGENTS.md)
- `epub_converter/` - 143 example(s); guide: [`AGENTS.md`](./epub_converter/AGENTS.md)
- `extract_images_from_website/` - 37 example(s); guide: [`AGENTS.md`](./extract_images_from_website/AGENTS.md)
- `extract_svg_from_website/` - 30 example(s); guide: [`AGENTS.md`](./extract_svg_from_website/AGENTS.md)
- `fine_tuning_converters/` - 121 example(s); guide: [`AGENTS.md`](./fine_tuning_converters/AGENTS.md)
- `html_converter/` - 198 example(s); guide: [`AGENTS.md`](./html_converter/AGENTS.md)
- `html_navigation/` - 120 example(s); guide: [`AGENTS.md`](./html_navigation/AGENTS.md)
- `markdown_converter/` - 78 example(s); guide: [`AGENTS.md`](./markdown_converter/AGENTS.md)
- `markdown_processing/` - 119 example(s); guide: [`AGENTS.md`](./markdown_processing/AGENTS.md)
- `message_handlers/` - 98 example(s); guide: [`AGENTS.md`](./message_handlers/AGENTS.md)
- `mhtml_converter/` - 107 example(s); guide: [`AGENTS.md`](./mhtml_converter/AGENTS.md)
- `save_file_from_url/` - 28 example(s); guide: [`AGENTS.md`](./save_file_from_url/AGENTS.md)
- `svg_converter/` - 105 example(s); guide: [`AGENTS.md`](./svg_converter/AGENTS.md)
- `web_accessibility/` - 96 example(s); guide: [`AGENTS.md`](./web_accessibility/AGENTS.md)
- `website_to_html/` - 30 example(s); guide: [`AGENTS.md`](./website_to_html/AGENTS.md)
- `working_with_html_documents/` - 329 example(s); guide: [`AGENTS.md`](./working_with_html_documents/AGENTS.md)
- `working_with_html_templates/` - 45 example(s); guide: [`AGENTS.md`](./working_with_html_templates/AGENTS.md)

Each category folder contains standalone `.cs` files and a category-specific `AGENTS.md` guide.

## Boundaries

### ✅ Always

These rules are mandatory for every example.

#### Use standalone console applications

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Example completed successfully.");
    }
}
```

#### Use explicit, deterministic input and output paths

```csharp
// CORRECT
string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.html");
string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pdf");

// WRONG
// string inputPath = Console.ReadLine();
```

#### Never wait for interactive input

```csharp
// WRONG
// Console.ReadLine();
// Console.ReadKey();
```

Examples must complete automatically. Use inline strings, generated sample files, or fixed paths.

#### Fully qualify ambiguous Aspose.HTML converter calls

```csharp
// CORRECT
Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

// AVOID when ambiguity is possible
// Converter.ConvertHTML(document, options, outputPath);
```

#### Use `using` blocks for disposable documents, streams, and devices

```csharp
using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
{
    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
}
```

#### Create output folders before writing files

```csharp
string outputDirectory = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
System.IO.Directory.CreateDirectory(outputDirectory);
```

#### Validate files before loading them

```csharp
if (!System.IO.File.Exists(inputPath))
{
    Console.Error.WriteLine($"Error: File not found - {inputPath}");
    return;
}
```

#### Use `System.Drawing.Color` where Aspose.HTML save/rendering options require it

```csharp
Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
options.BackgroundColor = System.Drawing.Color.White;
```

#### Use Aspose.HTML drawing types for page setup, sizes, margins, and lengths

```csharp
Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
    new Aspose.Html.Drawing.Size(
        Aspose.Html.Drawing.Length.FromPixels(800),
        Aspose.Html.Drawing.Length.FromPixels(600)),
    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
```

#### Implement custom stream providers when using `ICreateStreamProvider`

```csharp
class FileStreamProvider : Aspose.Html.IO.ICreateStreamProvider
{
    private readonly string outputDirectory;

    public FileStreamProvider(string outputDirectory)
    {
        this.outputDirectory = outputDirectory;
        System.IO.Directory.CreateDirectory(outputDirectory);
    }

    public System.IO.Stream GetStream(string name, string extension)
    {
        string fileName = string.IsNullOrWhiteSpace(name) ? "output" : name;
        string filePath = System.IO.Path.Combine(outputDirectory, fileName + extension);
        return System.IO.File.Create(filePath);
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        string fileName = $"{(string.IsNullOrWhiteSpace(name) ? "output" : name)}_{page}{extension}";
        string filePath = System.IO.Path.Combine(outputDirectory, fileName);
        return System.IO.File.Create(filePath);
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        stream?.Dispose();
    }

    public void Dispose()
    {
    }
}
```


### ⚠️ Ask First

Check with a human before doing any of these:
- Creating multi-file projects.
- Adding NuGet packages beyond `Aspose.Html`.
- Modifying shared infrastructure such as `.csproj` templates, CI files, or repository generators.
- Changing category `agent.md` files unless the task explicitly asks for it.
- Using deprecated APIs without validating the current Aspose.HTML API surface.

### 🚫 Never

- Never use `Console.ReadLine`, `Console.ReadKey`, or any interactive prompt.
- Never invent Aspose.HTML properties, methods, enum values, or helper classes.
- Never assume `MemoryStreamProvider` exists as a built-in Aspose.HTML class; implement it when needed.
- Never use unqualified `Converter` if another namespace may conflict; use `Aspose.Html.Converters.Converter`.
- Never confuse `System.Drawing.Color` with `Aspose.Html.Drawing.Color`.
- Never put page setup classes under `System.Drawing`; use `Aspose.Html.Drawing.Page`, `Size`, `Margin`, and `Length`.
- Never create code that hangs, waits for user input, opens UI dialogs, or depends on manual action.
- Never ignore task intent; if an option is unsupported, skip it safely and keep the rest of the workflow correct.
- Never modify this root `agent.md` or category `agent.md` files from generated examples.

## Common Mistakes (Anti-Patterns)

These are verified mistakes that commonly cause build or runtime failures.

### Ambiguous Converter Reference

```csharp
// WRONG
Converter.ConvertHTML(document, options, outputPath);
```

```csharp
// CORRECT
Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
```

### Interactive Input Is Prohibited

```csharp
// WRONG
Console.Write("Enter file path: ");
string inputPath = Console.ReadLine();
```

```csharp
// CORRECT
string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.html");
```

### Wrong Color Type

```csharp
// WRONG for many save/rendering options
// options.BackgroundColor = Aspose.Html.Drawing.Color.White;
```

```csharp
// CORRECT when option expects System.Drawing.Color
options.BackgroundColor = System.Drawing.Color.White;
```

### Missing Custom Stream Provider Implementation

```csharp
// WRONG
// MemoryStreamProvider provider = new MemoryStreamProvider(); // not guaranteed to exist
```

```csharp
// CORRECT
using (FileStreamProvider provider = new FileStreamProvider(outputDirectory))
{
    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
}
```

### Invalid Save Option Members

```csharp
// WRONG
// options.Encoding = "UTF-8";
// options.EnableExternalCss = true;
// options.EnableViewBox = true;
```

Use only members validated against the current Aspose.HTML API reference.

### Wrong Namespace for SVG Save Options

```csharp
// CORRECT when SVG save options are supported
Aspose.Html.Dom.Svg.Saving.SVGSaveOptions options = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
```

### Invalid Page Setup Types

```csharp
// WRONG
// options.PageSetup.AnyPage = new System.Drawing.Rectangle(0, 0, 800, 600);
```

```csharp
// CORRECT
options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
    new Aspose.Html.Drawing.Size(
        Aspose.Html.Drawing.Length.FromPixels(800),
        Aspose.Html.Drawing.Length.FromPixels(600)),
    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
```

## Domain Knowledge

Cross-cutting rules and API-specific gotchas.

- **HTML documents**: use `Aspose.Html.HTMLDocument` to load HTML from files, URLs, streams, or strings.
- **DOM edits**: use `document.CreateElement`, `document.Body.AppendChild`, `QuerySelector`, and `QuerySelectorAll` for document manipulation.
- **Canvas examples**: use `Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D` for drawing operations.
- **Conversions**: use `Aspose.Html.Converters.Converter.ConvertHTML`, `ConvertEPUB`, `ConvertSVG`, `ConvertMHTML`, and `ConvertMarkdown` with the correct save options.
- **Image output**: use `Aspose.Html.Saving.ImageSaveOptions` and `Aspose.Html.Rendering.Image.ImageFormat` for JPEG, PNG, BMP, GIF, and TIFF workflows.
- **PDF output**: use `Aspose.Html.Saving.PdfSaveOptions` or `Aspose.Html.Rendering.Pdf.PdfDevice` depending on the task.
- **DOCX output**: use `Aspose.Html.Saving.DocSaveOptions`.
- **XPS output**: use `Aspose.Html.Saving.XpsSaveOptions`.
- **MHTML output**: use `Aspose.Html.Saving.MHTMLSaveOptions` where supported.
- **Markdown output**: use `Aspose.Html.Saving.MarkdownSaveOptions`.
- **Stream output**: use `Aspose.Html.IO.ICreateStreamProvider` with a concrete implementation in the same `.cs` file.
- **Networking examples**: use `Aspose.Html.Net.RequestMessage`, `ResponseMessage`, and `Url` only when the task is about downloading, message handlers, or custom network behavior.
- **Accessibility examples**: use `Aspose.Html.Accessibility` and `Aspose.Html.Accessibility.Results` for validation/reporting workflows.

## Frequently Used APIs

| API | Typical Usage |
|-----|---------------|
| `Aspose.Html.HTMLDocument` | Load and manipulate HTML documents |
| `Aspose.Html.Converters.Converter.ConvertHTML` | Convert HTML to PDF, image, DOCX, XPS, Markdown, or MHTML |
| `Aspose.Html.Converters.Converter.ConvertEPUB` | Convert EPUB streams/files to output formats |
| `Aspose.Html.Converters.Converter.ConvertSVG` | Convert SVG documents/content to output formats |
| `Aspose.Html.Converters.Converter.ConvertMHTML` | Convert MHTML archives to output formats |
| `Aspose.Html.Converters.Converter.ConvertMarkdown` | Convert Markdown sources to HTML or other targets |
| `Aspose.Html.Saving.ImageSaveOptions` | Configure raster image output |
| `Aspose.Html.Saving.PdfSaveOptions` | Configure PDF output |
| `Aspose.Html.Saving.DocSaveOptions` | Configure DOC/DOCX output |
| `Aspose.Html.Saving.XpsSaveOptions` | Configure XPS output |
| `Aspose.Html.IO.ICreateStreamProvider` | Provide output streams for multi-file/page output |
| `Aspose.Html.Rendering.Image.ImageDevice` | Render documents directly to image output |
| `Aspose.Html.Rendering.Pdf.PdfDevice` | Render documents directly to PDF output |
| `Aspose.Html.Drawing.Page` | Configure page size and margins |
| `System.IO.Path.Combine` | Build portable file paths |
| `System.IO.Directory.CreateDirectory` | Ensure output folders exist |

## Command Reference

### Build and Run

```bash
# Create a new project if needed
dotnet new console -n ExampleProject --framework net9.0

# Add Aspose.HTML NuGet package
dotnet add package Aspose.Html --version 26.4.0

# Build
dotnet build --configuration Release --verbosity minimal

# Run
dotnet run
```

### Project File (.csproj)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Aspose.Html" Version="26.4.0" />
  </ItemGroup>
</Project>
```

### Environment

- .NET SDK: 9.0 or compatible version
- NuGet: Aspose.Html 26.4.0
- All examples are standalone Console Applications
- Each `.cs` file can be compiled and run independently

## Testing Guide

Every example must pass these verification steps.

### Build Verification

```bash
dotnet build --configuration Release --verbosity minimal
```

- **Success**: Exit code 0 and no `CS` compiler errors.
- **Failure**: Any `error CS####` line indicates a build failure.

### Run Verification

```bash
dotnet run
```

- **Success**: Exit code 0, expected console output, and expected output file(s) created.
- **Failure**: unhandled exceptions, hangs, interactive prompts, missing files, or non-zero exit code.

### Expected Output Patterns

- Console output confirming the operation, for example: `HTML converted successfully`.
- Output files created in the working directory or an `output` subfolder.
- No `NullReferenceException`, `IndexOutOfRangeException`, or unexpected `FileNotFoundException`.

### Common Error Codes

| Code | Meaning | Fix |
|------|---------|-----|
| `CS0104` | Ambiguous type reference | Use fully qualified names |
| `CS1061` | Member does not exist on type | Validate the API member before using it |
| `CS0246` | Type or namespace not found | Add correct namespace or remove unsupported type |
| `CS0029` | Cannot convert type | Use the expected type, especially for colors/options |
| `CS1503` | Wrong argument type | Select the correct converter overload |
| `NETSDK1004` | Assets file missing | Run `dotnet restore` before build |

## How to Use These Examples

### Prerequisites

- .NET SDK 9.0 or compatible version
- Aspose.HTML for .NET package `Aspose.Html` 26.4.0 or compatible version
- NuGet package restore enabled

### Running an Example

1. Navigate to any category folder.
2. Choose a standalone `.cs` file.
3. Create or copy required input files if the example needs them.
4. Compile and run the code in a console project:

```bash
dotnet new console --framework net9.0
cp path/to/example.cs Program.cs
dotnet add package Aspose.Html --version 26.4.0
dotnet run
```

<!-- AUTOGENERATED:START -->
Updated: 2026-05-06 | Examples: 1802 | Categories: 18
<!-- AUTOGENERATED:END -->

---

*This repository is maintained by automated code generation. Last updated: 2026-05-06 | Total examples: 1802*
