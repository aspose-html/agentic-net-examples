---
name: advanced-html-editing
description: C# examples for Advanced Html Editing using Aspose.HTML for .NET
language: csharp
framework: net10.0
parent: ../AGENTS.md
---

# AGENTS - Advanced Html Editing

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET,
working within the **Advanced Html Editing** category.
This folder contains standalone C# examples for Advanced Html Editing operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;`
- `using System.IO;`
- `using Aspose.Html;`
- `using Aspose.Html.Dom;`
- `using Aspose.Html.Dom.Canvas;`
- `using Aspose.Html.Dom.Mutations;`
- `using Aspose.Html.Converters;`
- `using Aspose.Html.Rendering;`
- `using Aspose.Html.Rendering.Image;`
- `using Aspose.Html.Rendering.Pdf;`
- `using Aspose.Html.Saving;`
- `using Aspose.Html.IO;`

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [apply-linear-gradient-fill-canvas-rectangle-and-export-drawing-jpeg-image.cs](./apply-linear-gradient-fill-canvas-rectangle-and-export-drawing-jpeg-image.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Apply a linear gradient fill to a canvas rectangle, and export the drawing as a JPEG image... |
| [configure-htmlloadoptions-disable-external-resources-render-canvas-convert-jpeg-safely.cs](./configure-htmlloadoptions-disable-external-resources-render-canvas-convert-jpeg-safely.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `Converter` | Configure HtmlLoadOptions to disable external resources, then render canvas and convert to... |
| [configure-imagesaveoptions-set-jpeg-dpi-300-render-high-resolution-canvas-save.cs](./configure-imagesaveoptions-set-jpeg-dpi-300-render-high-resolution-canvas-save.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `HTMLSaveOptions` | Configure ImageSaveOptions to set JPEG DPI to 300, then render a high‑resolution canvas an... |
| [configure-pdf-save-settings-with-custom-margins-then-convert-html-file-containing-canvas-to-pdf.cs](./configure-pdf-save-settings-with-custom-margins-then-convert-html-file-containing-canvas-to-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Configure PdfSaveOptions with custom margins, then convert an HTML file containing canvas ... |
| [configure-pdfsaveoptions-embed-xmp-metadata-convert-canvas-rich-html-document-to-pdf.cs](./configure-pdfsaveoptions-embed-xmp-metadata-convert-canvas-rich-html-document-to-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Configure PdfSaveOptions to embed XMP metadata, then convert a canvas‑rich HTML document t... |
| [convert-html-document-canvas-element-to-jpeg-using-imagesaveoptions.cs](./convert-html-document-canvas-element-to-jpeg-using-imagesaveoptions.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `HTMLSaveOptions`, `Converter` | Convert an HTML document containing a canvas element to JPEG using ImageSaveOptions. |
| [create-batch-process-reads-html-strings-draws-watermarks-on-canvases-writes-jpeg-outputs.cs](./create-batch-process-reads-html-strings-draws-watermarks-on-canvases-writes-jpeg-outputs.cs) | `ImageSaveOptions` | Create a batch process that reads HTML strings, draws watermarks on canvases, and writes J... |
| [create-canvas-html-string-draw-gradient-save-jpeg-image.cs](./create-canvas-html-string-draw-gradient-save-jpeg-image.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Create a canvas element in an HTML string, draw a gradient, and save output as a JPEG imag... |
| [create-css-aspose-rule-adds-drop-shadow-to-all-canvas-elements-pdf.cs](./create-css-aspose-rule-adds-drop-shadow-to-all-canvas-elements-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions` | Create a CSS -aspose- rule that adds a drop shadow to all canvas elements in PDF. |
| [create-css-aspose-rule-background-color-all-canvas-elements-pdf.cs](./create-css-aspose-rule-background-color-all-canvas-elements-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions` | Create a CSS -aspose- rule that adds a background color to all canvas elements in the PDF. |
| [create-css-rule-using-aspose-page-margin-add-printable-margins-around-canvas-content.cs](./create-css-rule-using-aspose-page-margin-add-printable-margins-around-canvas-content.cs) | `HTMLCanvasElement` | Create a CSS rule using -aspose- page‑margin to add printable margins around canvas conten... |
| [create-custom-css-extension-adds-aspose-page-number-footer-verify-pdf-output.cs](./create-custom-css-extension-adds-aspose-page-number-footer-verify-pdf-output.cs) | `PdfSaveOptions` | Create a custom CSS extension that adds a -aspose- page‑number footer, and verify in PDF o... |
| [create-custom-icreastreamprovider-writes-jpeg-streams-to-network-location-during-conversion.cs](./create-custom-icreastreamprovider-writes-jpeg-streams-to-network-location-during-conversion.cs) | `ICreateStreamProvider`, `ImageSaveOptions`, `Converter` | Create a custom ICreateStreamProvider that writes JPEG streams to a network location durin... |
| [create-pdf-device-file-path-attach-htmldocument-save-canvas-output.cs](./create-pdf-device-file-path-attach-htmldocument-save-canvas-output.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Create a PDF device with a file path, attach it to an HTMLDocument, and save the canvas ou... |
| [custom-stream-provider-compress-jpeg-pages-with-gzip-before-saving-to-disk.cs](./custom-stream-provider-compress-jpeg-pages-with-gzip-before-saving-to-disk.cs) | `ICreateStreamProvider`, `ImageSaveOptions` | Implement a custom stream provider that compresses JPEG pages using GZip before saving to ... |
| [draw-series-concentric-circles-on-canvas-export-each-page-separate-jpeg-streams.cs](./draw-series-concentric-circles-on-canvas-export-each-page-separate-jpeg-streams.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Draw a series of concentric circles on a canvas, then export each page as separate JPEG st... |
| [enable-css-extensions-add-aspose-header-rule-verify-header-appears-in-converted-pdf.cs](./enable-css-extensions-add-aspose-header-rule-verify-header-appears-in-converted-pdf.cs) | `PdfSaveOptions` | Enable CSS extensions, add a -aspose- header rule, and verify header appears in converted ... |
| [enable-css-extensions-add-custom-aspose-margin-rule-convert-html-to-pdf.cs](./enable-css-extensions-add-custom-aspose-margin-rule-convert-html-to-pdf.cs) | `PdfSaveOptions`, `Converter` | Enable CSS extensions, add a custom -aspose- margin rule, then convert the HTML to PDF. |
| [enable-css-extensions-define-aspose-page-break-rule-verify-pdf-pagination-after-conversion.cs](./enable-css-extensions-define-aspose-page-break-rule-verify-pdf-pagination-after-conversion.cs) | `PdfSaveOptions`, `Converter` | Enable CSS extensions, define a -aspose- page‑break rule, and verify PDF pagination after ... |
| [implement-custom-stream-provider-writes-pdf-output-streams-to-disk-using-icreatestreamprovider-during-html-to-pdf-conver.cs](./implement-custom-stream-provider-writes-pdf-output-streams-to-disk-using-icreatestreamprovider-during-html-to-pdf-conver.cs) | `ICreateStreamProvider`, `PdfSaveOptions`, `Converter` | Implement a custom stream provider that writes PDF output streams to disk using ICreateStr... |
| [implement-icreatestreamprovider-supply-file-streams-multi-page-html-to-jpeg-conversion.cs](./implement-icreatestreamprovider-supply-file-streams-multi-page-html-to-jpeg-conversion.cs) | `ICreateStreamProvider`, `ImageSaveOptions`, `Converter` | Implement ICreateStreamProvider to supply file streams for multi‑page HTML to JPEG convers... |
| [iterate-list-markdown-sources-add-watermark-canvas-overlay-output-pdfs.cs](./iterate-list-markdown-sources-add-watermark-canvas-overlay-output-pdfs.cs) | `HTMLCanvasElement`, `MarkdownSaveOptions` | Iterate over a list of Markdown sources, add a watermark canvas overlay, and output PDFs. |
| [iterate-over-directory-html-files-draw-border-each-canvas-save-pdfs.cs](./iterate-over-directory-html-files-draw-border-each-canvas-save-pdfs.cs) | `HTMLCanvasElement` | Iterate over a directory of HTML files, draw a border on each canvas, and save PDFs. |
| [load-epub-locate-canvas-draw-text-export-pdf.cs](./load-epub-locate-canvas-draw-text-export-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `EpubSaveOptions` | Load an EPUB file, locate its canvas element, draw text, and export the page as PDF. |
| [load-html-file-attach-mutationobserver-to-canvas-log-drawing-changes-to-console.cs](./load-html-file-attach-mutationobserver-to-canvas-log-drawing-changes-to-console.cs) | `MutationObserver`, `HTMLCanvasElement`, `HTMLDocument` | Load an HTML file, attach a MutationObserver to the canvas, and log drawing changes to con... |
| [load-html-file-edit-canvas-graphics-export-to-pdf.cs](./load-html-file-edit-canvas-graphics-export-to-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Load an HTML file, edit its canvas graphics, and export the result to a PDF file. |
| [load-markdown-file-with-embedded-canvas-add-drop-shadow-effect-convert-to-pdf.cs](./load-markdown-file-with-embedded-canvas-add-drop-shadow-effect-convert-to-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `MarkdownSaveOptions`, `Converter` | Load a Markdown file with embedded canvas, add a drop shadow effect, and convert to PDF. |
| [load-markdown-source-embed-canvas-render-shapes-via-icanvasrenderingcontext2d-save-pdf.cs](./load-markdown-source-embed-canvas-render-shapes-via-icanvasrenderingcontext2d-save-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `MarkdownSaveOptions` | Load a Markdown source, embed a canvas, render shapes via ICanvasRenderingContext2D, and s... |
| [load-mhtml-email-archive-edit-canvas-drawing-export-modified-content-jpeg.cs](./load-mhtml-email-archive-edit-canvas-drawing-export-modified-content-jpeg.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `HTMLDocument` | Load an MHTML email archive, edit its canvas drawing, and export the modified content to J... |
| [load-multiple-html-files-apply-same-canvas-drawing-routine-generate-combined-pdf-booklet.cs](./load-multiple-html-files-apply-same-canvas-drawing-routine-generate-combined-pdf-booklet.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Load multiple HTML files, apply the same canvas drawing routine, and generate a combined P... |
| [load-xhtml-page-modify-canvas-text-content-save-result-pdf.cs](./load-xhtml-page-modify-canvas-text-content-save-result-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Load a XHTML page, modify its canvas text content, and save the result as a PDF file. |
| [load-xml-document-transform-to-html-with-canvas-element-convert-to-pdf.cs](./load-xml-document-transform-to-html-with-canvas-element-convert-to-pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `Converter`, `HTMLDocument` | Load an XML document, transform it to HTML with a canvas element, and convert to PDF. |
| [set-htmlloadoptions-preserve-whitespace-render-canvas-export-pdf-preserving-layout.cs](./set-htmlloadoptions-preserve-whitespace-render-canvas-export-pdf-preserving-layout.cs) | `HTMLCanvasElement`, `PdfSaveOptions` | Set HtmlLoadOptions to preserve whitespace, then render a canvas and export to PDF preserv... |
| [use-icanvasrenderingcontext2d-draw-bezier-curve-save-high-resolution-jpeg.cs](./use-icanvasrenderingcontext2d-draw-bezier-curve-save-high-resolution-jpeg.cs) | `ImageSaveOptions` | Use ICanvasRenderingContext2D to draw a bezier curve, then save the drawing as a high‑reso... |
| [use-icanvasrenderingcontext2d-draw-rotated-text-string-on-canvas-save-jpeg.cs](./use-icanvasrenderingcontext2d-draw-rotated-text-string-on-canvas-save-jpeg.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Use ICanvasRenderingContext2D to draw a rotated text string on a canvas and save as JPEG. |
| [use-mutationobserver-detect-canvas-element-changes-trigger-automatic-pdf-regeneration.cs](./use-mutationobserver-detect-canvas-element-changes-trigger-automatic-pdf-regeneration.cs) | `MutationObserver`, `HTMLCanvasElement`, `PdfSaveOptions` | Use MutationObserver to detect canvas element changes, then trigger automatic PDF regenera... |
| [use-mutationobserver-monitor-canvas-attribute-changes-automatically-adjust-pdf-page-orientation.cs](./use-mutationobserver-monitor-canvas-attribute-changes-automatically-adjust-pdf-page-orientation.cs) | `MutationObserver`, `HTMLCanvasElement`, `PdfSaveOptions` | Use MutationObserver to monitor attribute changes on canvas and automatically adjust PDF p... |

## Category Statistics
- Total examples: 37
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `HTMLDocument`
- `PdfDevice`
- `ImageSaveOptions`
- `PdfSaveOptions`
- `MemoryStreamProvider`
- `MutationObserver`
- `HTMLCanvasElement`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-10-30 | Examples: 37
<!-- AUTOGENERATED:END -->
