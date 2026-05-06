---
name: advanced_html_editing
description: C# examples for advanced_html_editing using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – advanced_html_editing

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **advanced_html_editing** category.
This folder contains standalone C# examples for advanced_html_editing operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: advanced_html_editing  
- **Total examples**: 37  
- **Typical workflow**:  
  1. **Load** – read an HTML, Markdown, EPUB or XML source into an `HTMLDocument`.  
  2. **Bind / Manipulate** – use the DOM (`Body.AppendChild`, `Dom.Canvas`, etc.) to draw, add CSS, or modify content.  
  3. **Convert** – invoke a converter (`Converter.ConvertHTML`, `Converter.ConvertMarkdown`, `Converter.ConvertEPUB`) with appropriate save options (`ImageSaveOptions`, `PdfSaveOptions`).  
  4. **Render / Export** – write the result to an image, PDF, or stream using devices (`ImageDevice`, `PdfDevice`) and log progress with `Console.WriteLine`.

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | 37 |
| Aspose.Html | 34 |
| Aspose.Html.Saving | 24 |
| Aspose.Html.Dom.Canvas | 19 |
| Aspose.Html.Converters | 19 |
| System.IO | 14 |
| Aspose.Html.Rendering.Image | 14 |
| Aspose.Html.Rendering.Pdf | 13 |
| Aspose.Html.Dom | 11 |
| Aspose.Html.IO | 9 |
| System.Collections.Generic | 8 |
| Aspose.Html.Services | 3 |
| Aspose.Html.Drawing | 2 |
| System.IO.Compression | 1 |
| Aspose.Html.Dom.Mutations | 1 |
| System.Drawing | 1 |
| Aspose.Html.Rendering | 1 |
| System.Xml.Linq | 1 |

### How to import them

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Xml.Linq;

using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Dom.Mutations;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Services;
using Aspose.Html.Drawing;
```

---

## Common Code Pattern

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        // 1️⃣ Load an HTML document (from file, string or stream)
        var htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "template.html");
        var document = new HTMLDocument(htmlPath);

        // 2️⃣ Manipulate the DOM – add a canvas and draw something
        var canvas = document.CreateElement("canvas");
        canvas.SetAttribute("width", "800");
        canvas.SetAttribute("height", "600");
        document.Body.AppendChild(canvas);

        var ctx = (ICanvasRenderingContext2D)canvas.GetContext("2d");
        ctx.FillStyle = "linear-gradient(to right, #ff7e5f, #feb47b)";
        ctx.FillRect(0, 0, 800, 600);

        // 3️⃣ Convert to the desired output (JPEG image in this case)
        var saveOptions = new ImageSaveOptions(ImageFormat.Jpeg)
        {
            DpiX = 300,
            DpiY = 300
        };
        using var device = new ImageDevice("output.jpg", saveOptions);
        document.RenderTo(device);

        // 4️⃣ Log the result
        Console.WriteLine("Canvas rendered and saved as JPEG successfully.");
    }
}
```

*The pattern above is the backbone of every example in this folder – load, edit, convert, render, and log.*

---

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Console.WriteLine | 37 |
| Aspose.Html | 37 |
| HTMLDocument | 27 |
| Dom.Canvas | 19 |
| Body.AppendChild | 18 |
| System.IO | 16 |
| ImageFormat.Jpeg | 13 |
| Converter.ConvertHTML | 13 |
| ImageSaveOptions | 13 |
| Rendering.Image | 13 |
| Rendering.Pdf | 13 |
| PdfDevice | 12 |
| System.Collections | 8 |
| PdfSaveOptions | 8 |
| MemoryStreamProvider | 7 |
| MemoryStream | 7 |
| Path.Combine | 7 |
| SeekOrigin.Begin | 6 |
| File.Create | 6 |
| Directory.GetCurrentDirectory | 5 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [Apply Linear Gradient Fill To Canvas Rectangle And Export Drawing As Jpeg Image](./apply_linear_gradient_fill_to_canvas_rectangle_and_export_drawing_as_jpeg_image.cs) | Apply Linear Gradient Fill To Canvas Rectangle And Export Drawing As Jpeg Image | HTMLDocument, Body.AppendChild, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Configure Html Load Options Disable External Resources Render Canvas Convert To Jpeg Safely](./configure_html_load_options_disable_external_resources_render_canvas_convert_to_jpeg_safely.cs) | Configure Html Load Options Disable External Resources Render Canvas Convert To Jpeg Safely | HTMLDocument, ImageFormat.Jpeg, ImageDevice | Creates or manipulates an HTML document. |
| [Configure Imagesaveoptions Set Jpeg Dpi 300 Render High Resolution Canvas Save](./configure_imagesaveoptions_set_jpeg_dpi_300_render_high_resolution_canvas_save.cs) | Configure Imagesaveoptions Set Jpeg Dpi 300 Render High Resolution Canvas Save | Rendering.Image, ImageFormat.Jpeg, ImageSaveOptions | Creates or manipulates an HTML document. |
| [Configure Pdfsaveoptions Custom Margins Convert Html Canvas To Pdf](./configure_pdfsaveoptions_custom_margins_convert_html_canvas_to_pdf.cs) | Configure Pdfsaveoptions Custom Margins Convert Html Canvas To Pdf | Length.FromInches, PdfSaveOptions, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Configure Pdfsaveoptions Embed Xmp Metadata Convert Canvas Rich Html To Pdf](./configure_pdfsaveoptions_embed_xmp_metadata_convert_canvas_rich_html_to_pdf.cs) | Configure Pdfsaveoptions Embed Xmp Metadata Convert Canvas Rich Html To Pdf | PdfSaveOptions, Converter.ConvertHTML, Aspose.Html | Converts HTML content to another format using Aspose.HTML. |
| [Convert Html Document Containing Canvas To Jpeg Using Imagesaveoptions](./convert_html_document_containing_canvas_to_jpeg_using_imagesaveoptions.cs) | Convert Html Document Containing Canvas To Jpeg Using Imagesaveoptions | HTMLDocument, ImageFormat.Jpeg, ImageSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Create Batch Process Reads Html Strings Draws Watermarks On Canvases Writes Jpeg Outputs](./create_batch_process_reads_html_strings_draws_watermarks_on_canvases_writes_jpeg_outputs.cs) | Create Batch Process Reads Html Strings Draws Watermarks On Canvases Writes Jpeg Outputs | HTMLDocument, Body.AppendChild, ImageFormat.Jpeg | Converts HTML content to another format using Aspose.HTML. |
| [Create Canvas Element In Html String Draw Gradient Save Output As Jpeg Image](./create_canvas_element_in_html_string_draw_gradient_save_output_as_jpeg_image.cs) | Create Canvas Element In Html String Draw Gradient Save Output As Jpeg Image | HTMLDocument, Body.AppendChild, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Create Css Aspose Rule Adds Drop Shadow All Canvas Elements Pdf](./create_css_aspose_rule_adds_drop_shadow_all_canvas_elements_pdf.cs) | Create Css Aspose Rule Adds Drop Shadow All Canvas Elements Pdf | Body.AppendChild, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Create Css Aspose Rule Background Color Canvas Elements Pdf](./create_css_aspose_rule_background_color_canvas_elements_pdf.cs) | Create Css Aspose Rule Background Color Canvas Elements Pdf | Body.AppendChild, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Create Css Rule Aspose Page Margin Printable Margins Canvas Content](./create_css_rule_aspose_page_margin_printable_margins_canvas_content.cs) | Create Css Rule Aspose Page Margin Printable Margins Canvas Content | Body.AppendChild, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Create Custom Css Extension Adds Aspose Page Number Footer Verify Pdf Output](./create_custom_css_extension_adds_aspose_page_number_footer_verify_pdf_output.cs) | Create Custom Css Extension Adds Aspose Page Number Footer Verify Pdf Output | Services.IUserAgentService, Converters.Converter, Configuration.Create | Converts HTML content to another format using Aspose.HTML. |
| [Create Custom Stream Provider Writing Jpeg Streams To Network Location During Conversion](./create_custom_stream_provider_writing_jpeg_streams_to_network_location_during_conversion.cs) | Create Custom Stream Provider Writing Jpeg Streams To Network Location During Conversion | System.Collections, FileAccess.Write, Aspose.HTML | Demonstrates a specific Aspose.HTML operation. |
| [Create Pdf Device With File Path Attach To Html Document And Save Canvas Output](./create_pdf_device_with_file_path_attach_to_html_document_and_save_canvas_output.cs) | Create Pdf Device With File Path Attach To Html Document And Save Canvas Output | Body.AppendChild, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Draw Series Of Concentric Circles On Canvas Export Each Page As Separate Jpeg Streams](./draw_series_of_concentric_circles_on_canvas_export_each_page_as_separate_jpeg_streams.cs) | Draw Series Of Concentric Circles On Canvas Export Each Page As Separate Jpeg Streams | Body.AppendChild, Dom.Canvas, HTMLDocument | Converts HTML content to another format using Aspose.HTML. |
| [Enable Css Extensions Add Aspose Header Rule Verify Header Appears In Converted Pdf](./enable_css_extensions_add_aspose_header_rule_verify_header_appears_in_converted_pdf.cs) | Enable Css Extensions Add Aspose Header Rule Verify Header Appears In Converted Pdf | File.WriteAllText, Services.IUserAgentService, Converters.Converter | Converts HTML content to another format using Aspose.HTML. |
| [Enable Css Extensions Add Custom Aspose Margin Rule Convert Html To Pdf](./enable_css_extensions_add_custom_aspose_margin_rule_convert_html_to_pdf.cs) | Enable Css Extensions Add Custom Aspose Margin Rule Convert Html To Pdf | Converters.Converter, Configuration.Create, PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Enable Css Extensions Define Aspose Page Break Rule Verify Pdf Pagination After Conversion](./enable_css_extensions_define_aspose_page_break_rule_verify_pdf_pagination_after_conversion.cs) | Enable Css Extensions Define Aspose Page Break Rule Verify Pdf Pagination After Conversion | File.WriteAllText, PdfSaveOptions, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Implement Custom Stream Provider Compress Jpeg Pages Gzip Before Saving To Disk](./implement_custom_stream_provider_compress_jpeg_pages_gzip_before_saving_to_disk.cs) | Implement Custom Stream Provider Compress Jpeg Pages Gzip Before Saving To Disk | System.Collections, Stream.Seek, Streams.Count | Demonstrates a specific Aspose.HTML operation. |
| [Implement Custom Stream Provider Writing Pdf Output To Disk Using Icreatestreamprovider Html To Pdf Conversion](./implement_custom_stream_provider_writing_pdf_output_to_disk_using_icreatestreamprovider_html_to_pdf_conversion.cs) | Implement Custom Stream Provider Writing Pdf Output To Disk Using Icreatestreamprovider Html To Pdf Conversion | File.WriteAllText, FileAccess.Write, Aspose.HTML | Converts HTML content to another format using Aspose.HTML. |
| [Implement Stream Provider Supply File Streams Multi Page Html To Jpeg Conversion](./implement_stream_provider_supply_file_streams_multi_page_html_to_jpeg_conversion.cs) | Implement Stream Provider Supply File Streams Multi Page Html To Jpeg Conversion | FileMode.Create, Converter.ConvertHTML, Stream.CopyTo | Converts HTML content to another format using Aspose.HTML. |
| [Iterate Over Directory Html Files Draw Border Each Canvas Save Pdfs](./iterate_over_directory_html_files_draw_border_each_canvas_save_pdfs.cs) | Iterate Over Directory Html Files Draw Border Each Canvas Save Pdfs | Body.AppendChild, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Iterate Over List Of Markdown Sources Add Watermark Canvas Overlay Output Pdfs](./iterate_over_list_of_markdown_sources_add_watermark_canvas_overlay_output_pdfs.cs) | Iterate Over List Of Markdown Sources Add Watermark Canvas Overlay Output Pdfs | Converter.ConvertMarkdown, Rendering.Pdf, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Load Epub Locate Canvas Draw Text Export Page Pdf](./load_epub_locate_canvas_draw_text_export_page_pdf.cs) | Load Epub Locate Canvas Draw Text Export Page Pdf | File.OpenRead, PdfSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [Load Html File Attach Mutationobserver Canvas Log Drawing Changes Console](./load_html_file_attach_mutationobserver_canvas_log_drawing_changes_console.cs) | Load Html File Attach Mutationobserver Canvas Log Drawing Changes Console | MutationObserver, Aspose.Html, Dom.Canvas | Creates or manipulates an HTML document. |
| [Load Html File Edit Canvas Graphics Export To Pdf](./load_html_file_edit_canvas_graphics_export_to_pdf.cs) | Load Html File Edit Canvas Graphics Export To Pdf | HTMLDocument, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Load Markdown Embed Canvas Render Shapes Icanvasrenderingcontext2d Save Pdf](./load_markdown_embed_canvas_render_shapes_icanvasrenderingcontext2d_save_pdf.cs) | Load Markdown Embed Canvas Render Shapes Icanvasrenderingcontext2d Save Pdf | Converters.Converter, System.Drawing, Saving.PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Load Markdown File With Embedded Canvas Add Drop Shadow Effect Convert To Pdf](./load_markdown_file_with_embedded_canvas_add_drop_shadow_effect_convert_to_pdf.cs) | Load Markdown File With Embedded Canvas Add Drop Shadow Effect Convert To Pdf | Converter.ConvertMarkdown, System.Drawing, PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Load Mhtml Email Archive Edit Canvas Drawing Export Modified Content To Jpeg](./load_mhtml_email_archive_edit_canvas_drawing_export_modified_content_to_jpeg.cs) | Load Mhtml Email Archive Edit Canvas Drawing Export Modified Content To Jpeg | HTMLDocument, ImageFormat.Jpeg, ImageDevice | Creates or manipulates an HTML document. |
| [Load Multiple Html Files Apply Same Canvas Drawing Routine Generate Combined Pdf Booklet](./load_multiple_html_files_apply_same_canvas_drawing_routine_generate_combined_pdf_booklet.cs) | Load Multiple Html Files Apply Same Canvas Drawing Routine Generate Combined Pdf Booklet | Body.AppendChild, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Load Xhtml Page Modify Canvas Text Content Save As Pdf](./load_xhtml_page_modify_canvas_text_content_save_as_pdf.cs) | Load Xhtml Page Modify Canvas Text Content Save As Pdf | Rendering.Pdf, PdfDevice, Dom.Canvas | Creates or manipulates an HTML document. |
| [Load Xml Document Transform To Html With Canvas And Convert To Pdf](./load_xml_document_transform_to_html_with_canvas_and_convert_to_pdf.cs) | Load Xml Document Transform To Html With Canvas And Convert To Pdf | HTMLDocument, Rendering.Pdf, System.Xml | Creates or manipulates an HTML document. |
| [Set Html Load Options Preserve Whitespace Render Canvas Export Pdf Preserving Layout](./set_html_load_options_preserve_whitespace_render_canvas_export_pdf_preserving_layout.cs) | Set Html Load Options Preserve Whitespace Render Canvas Export Pdf Preserving Layout | Rendering.Pdf, PdfDevice, Aspose.Html | Creates or manipulates an HTML document. |
| [Use Icanvasrenderingcontext2d Draw Bezier Curve Save Highresolution Jpeg](./use_icanvasrenderingcontext2d_draw_bezier_curve_save_highresolution_jpeg.cs) | Use Icanvasrenderingcontext2d Draw Bezier Curve Save Highresolution Jpeg | HTMLDocument, Body.AppendChild, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Use Icanvasrenderingcontext2d Draw Rotated Text String On Canvas Save As Jpeg](./use_icanvasrenderingcontext2d_draw_rotated_text_string_on_canvas_save_as_jpeg.cs) | Use Icanvasrenderingcontext2d Draw Rotated Text String On Canvas Save As Jpeg | Converter.ConvertHTML, Stream.Seek, Streams.Count | Converts HTML content to another format using Aspose.HTML. |
| [Use Mutationobserver Detect Canvas Changes Trigger Automatic Pdf Regeneration](./use_mutationobserver_detect_canvas_changes_trigger_automatic_pdf_regeneration.cs) | Use Mutationobserver Detect Canvas Changes Trigger Automatic Pdf Regeneration | MutationObserver, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |
| [Use Mutationobserver Monitor Canvas Attribute Changes Automatically Adjust Pdf Page Orientation](./use_mutationobserver_monitor_canvas_attribute_changes_automatically_adjust_pdf_page_orientation.cs) | Use Mutationobserver Monitor Canvas Attribute Changes Automatically Adjust Pdf Page Orientation | MutationObserver, Rendering.Pdf, PdfDevice | Creates or manipulates an HTML document. |

---

## Category‑Specific Tips

### Key API Surface
- **HTMLDocument** – entry point for loading any markup.
- **Dom.Canvas** & **ICanvasRenderingContext2D** – draw shapes, gradients, text.
- **Body.AppendChild** – inject new elements (canvas, style, script).
- **Converter** (ConvertHTML, ConvertMarkdown, ConvertEPUB) – one‑liner conversion.
- **ImageSaveOptions / PdfSaveOptions** – control DPI, quality, metadata.
- **Rendering.Image** & **Rendering.Pdf** – device factories for output.
- **PdfDevice** – stream‑oriented PDF writer.
- **Console.WriteLine** – standard logging for examples.

### Rules
1. **Dispose devices** (`using` block) to flush buffers and release native resources.  
2. **Set explicit DPI** (e.g., 300) when high‑resolution raster output is required.  
3. **Prefer `SeekOrigin.Begin`** when re‑using streams to avoid hidden offsets.  
4. **When using CSS extensions**, register the user‑style‑sheet via `Configuration.Create().UserStyleSheet`.  
5. **Always validate external resources** (images, fonts) are reachable; otherwise disable them via `HtmlLoadOptions`.  
6. **For multi‑page output**, iterate over `document.Pages` (or stream collections) and create a new device per page.  
7. **When writing to network locations**, ensure the stream provider implements proper buffering and error handling.

---

## Warnings

- **Template‑binding mismatches** – placeholders in HTML strings must exactly match the data keys; otherwise the rendered output will contain raw tokens.
- **Missing external resources** (fonts, images) cause blank areas in the canvas; use `HtmlLoadOptions` to disable external loading if not needed.
- **File‑path issues** – relative paths are resolved against the current working directory; prefer `Path.Combine(Directory.GetCurrentDirectory(), ...)`.
- **Memory pressure** – rendering large canvases at high DPI can exhaust memory; consider streaming output or lowering DPI.
- **Concurrent device usage** – a single `PdfDevice` or `ImageDevice` instance is **not** thread‑safe; create a new instance per thread.

---

## Guidelines for Adding New Examples

1. **Self‑contained code** – include all `using` directives, create/clean temporary files inside the example.  
2. **Console logging** – start with `Console.WriteLine("Step …")` and end with a success message.  
3. **Follow the common pattern** – Load → Manipulate → Convert → Render.  
4. **Naming convention** – `Action_Entity_Operation_Detail.cs` (e.g., `Add_Watermark_To_Canvas_And_Save_As_Jpeg.cs`).  
5. **Update statistics** – increment `total_examples`, adjust namespace and API counts in `agents.md` when a new file is added.  
---
