---
name: markdown-converter
description: C# examples for Markdown Converter using Aspose.HTML for .NET
language: csharp
framework: net10.0
parent: ../AGENTS.md
---

# AGENTS - Markdown Converter

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET,
working within the **Markdown Converter** category.
This folder contains standalone C# examples for Markdown Converter operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;`
- `using System.IO;`
- `using Aspose.Html;`
- `using Aspose.Html.Dom;`
- `using Aspose.Html.Converters;`
- `using Aspose.Html.Drawing;`
- `using Aspose.Html.IO;`
- `using Aspose.Html.Rendering.Doc;`
- `using Aspose.Html.Rendering.Image;`
- `using Aspose.Html.Rendering.Pdf;`
- `using Aspose.Html.Rendering.Pdf.Encryption;`
- `using Aspose.Html.Saving;`

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [add-command-line-option-specify-custom-pdfsaveoptions-json-file-overrides-default-pdf-conversion-settings.cs](./add-command-line-option-specify-custom-pdfsaveoptions-json-file-overrides-default-pdf-conversion-settings.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Add a command‑line option to specify custom PdfSaveOptions JSON file that overrides defaul... |
| [add-configuration-flag-enable-disable-intermediate-html-file-generation-conversion-pipelines.cs](./add-configuration-flag-enable-disable-intermediate-html-file-generation-conversion-pipelines.cs) | `Converter`, `Configuration` | Add a configuration flag to enable or disable intermediate HTML file generation during con... |
| [add-support-converting-markdown-files-in-subfolders-recursively-scan-directories-batch-processing.cs](./add-support-converting-markdown-files-in-subfolders-recursively-scan-directories-batch-processing.cs) | `MarkdownSaveOptions` | Add support for converting Markdown files located in subfolders by recursively scanning di... |
| [apply-custom-color-palette-when-converting-markdown-to-gif.cs](./apply-custom-color-palette-when-converting-markdown-to-gif.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions` | Apply a custom color palette in ImageSaveOptions when converting Markdown to GIF format. |
| [apply-custom-pdf-metadata-author-title-using-pdfsaveoptions-before-conversion.cs](./apply-custom-pdf-metadata-author-title-using-pdfsaveoptions-before-conversion.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Apply custom PDF metadata such as author and title using PdfSaveOptions before conversion. |
| [apply-custom-resolution-setting-image-save-options-when-converting-markdown-to-gif-images.cs](./apply-custom-resolution-setting-image-save-options-when-converting-markdown-to-gif-images.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions` | Apply a custom resolution setting in ImageSaveOptions when converting Markdown to GIF imag... |
| [apply-imagesaveoptions-specify-background-color-converting-markdown-to-bmp-image.cs](./apply-imagesaveoptions-specify-background-color-converting-markdown-to-bmp-image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Apply ImageSaveOptions to specify background color when converting Markdown to a BMP image... |
| [batch-conversion-markdown-to-docx-individual-docsaveoptions-per-file.cs](./batch-conversion-markdown-to-docx-individual-docsaveoptions-per-file.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Implement batch conversion of Markdown files to DOCX with individual DocSaveOptions for ea... |
| [batch-conversion-of-markdown-files-in-folder-to-pdf-using-foreach-loop.cs](./batch-conversion-of-markdown-files-in-folder-to-pdf-using-foreach-loop.cs) | `PdfSaveOptions`, `MarkdownSaveOptions`, `Converter` | Perform batch conversion of all Markdown files in a folder to PDF using a foreach loop. |
| [batch-convert-markdown-files-to-jpeg-with-uniform-quality.cs](./batch-convert-markdown-files-to-jpeg-with-uniform-quality.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Batch convert all Markdown files in a folder to JPEG images applying a uniform quality lev... |
| [batch-convert-markdown-files-to-xps-preserving-original-file-timestamps.cs](./batch-convert-markdown-files-to-xps-preserving-original-file-timestamps.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `Converter` | Batch convert Markdown files to XPS while preserving original file timestamps in the outpu... |
| [batch-process-markdown-files-convert-to-tiff-lossless-compression.cs](./batch-process-markdown-files-convert-to-tiff-lossless-compression.cs) | `MarkdownSaveOptions` | Batch process a set of Markdown files, converting each to TIFF with lossless compression e... |
| [configure-docsaveoptions-embed-fonts-docx-output-consistent-rendering-across-platforms.cs](./configure-docsaveoptions-embed-fonts-docx-output-consistent-rendering-across-platforms.cs) | `HTMLSaveOptions` | Configure DocSaveOptions to embed fonts in the DOCX output for consistent rendering across... |
| [configure-imagesaveoptions-jpeg-output-convert-html-document-to-image.cs](./configure-imagesaveoptions-jpeg-output-convert-html-document-to-image.cs) | `ImageSaveOptions`, `HTMLSaveOptions`, `Converter`, `HTMLDocument` | Configure ImageSaveOptions for JPEG output and convert an HTML document to an image. |
| [configure-pdf-encryption-password-to-protect-generated-pdf-from-unauthorized-access.cs](./configure-pdf-encryption-password-to-protect-generated-pdf-from-unauthorized-access.cs) | `PdfSaveOptions`, `HTMLSaveOptions` | Configure PDF encryption password via PdfSaveOptions.Password to protect the generated PDF... |
| [convert-collection-markdown-strings-to-individual-png-files-parallel-processing.cs](./convert-collection-markdown-strings-to-individual-png-files-parallel-processing.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Convert a collection of Markdown strings to individual PNG files using parallel processing... |
| [convert-html-content-to-svg-using-svgsaveoptions.cs](./convert-html-content-to-svg-using-svgsaveoptions.cs) | `SVGDocument`, `HTMLSaveOptions`, `Converter` | Convert HTML content to SVG using SvgSaveOptions. |
| [convert-large-markdown-to-bmp-streaming-avoid-high-memory.cs](./convert-large-markdown-to-bmp-streaming-avoid-high-memory.cs) | `MarkdownSaveOptions`, `Converter` | Convert a large Markdown file to BMP format using streaming to avoid high memory consumpti... |
| [convert-markdown-document-containing-code-blocks-to-html-preserving-syntax-highlighting.cs](./convert-markdown-document-containing-code-blocks-to-html-preserving-syntax-highlighting.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown document containing code blocks to an HTML file preserving syntax highl... |
| [convert-markdown-document-to-html-and-save-result-to-memory-stream-for-further-processing.cs](./convert-markdown-document-to-html-and-save-result-to-memory-stream-for-further-processing.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown document to HTML and save the result to a memory stream for further pro... |
| [convert-markdown-string-directly-to-html-using-convertmarkdown-argument.cs](./convert-markdown-string-directly-to-html-using-convertmarkdown-argument.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown string directly to HTML by calling ConvertMarkdown with the string argu... |
| [convert-markdown-string-to-html-export-tiff-with-compression.cs](./convert-markdown-string-to-html-export-tiff-with-compression.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown string to HTML and then export the result as a TIFF file with compressi... |
| [convert-markdown-to-docx-with-page-size-and-orientation-using-docsaveoptions-pagesetup.cs](./convert-markdown-to-docx-with-page-size-and-orientation-using-docsaveoptions-pagesetup.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions`, `PdfRenderingOptions`, `Converter` | Convert Markdown to DOCX while setting page size and orientation via DocSaveOptions PageSe... |
| [convert-markdown-to-gif-limit-animation-frame-rate-imagesaveoptions.cs](./convert-markdown-to-gif-limit-animation-frame-rate-imagesaveoptions.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Convert a Markdown file to GIF format while limiting the animation frame rate using ImageS... |
| [convert-markdown-to-html-and-use-html-document-api-to-render-as-bmp-image.cs](./convert-markdown-to-html-and-use-html-document-api-to-render-as-bmp-image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter`, `HTMLDocument` | Convert Markdown to HTML and then use the HTMLDocument API to render it as a BMP image. |
| [convert-markdown-to-html-apply-css-styling-save-output-as-png-image.cs](./convert-markdown-to-html-apply-css-styling-save-output-as-png-image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Convert Markdown to HTML, apply CSS styling, and then save the output as a PNG image. |
| [convert-markdown-to-png-with-transparent-background-configuring-imagesaveoptions.cs](./convert-markdown-to-png-with-transparent-background-configuring-imagesaveoptions.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Convert Markdown to PNG with transparent background by configuring ImageSaveOptions approp... |
| [create-command-line-tool-input-markdown-path-output-format-conversion.cs](./create-command-line-tool-input-markdown-path-output-format-conversion.cs) | `MarkdownSaveOptions`, `Converter` | Create a command‑line tool that accepts input Markdown path and output format arguments fo... |
| [create-console-application-watches-directory-converts-new-markdown-files-to-jpeg-automatically.cs](./create-console-application-watches-directory-converts-new-markdown-files-to-jpeg-automatically.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Create a console application that watches a directory and converts new Markdown files to J... |
| [create-png-image-from-markdown-using-imagesaveoptions-default-compression.cs](./create-png-image-from-markdown-using-imagesaveoptions-default-compression.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Create a PNG image from Markdown using ImageSaveOptions with ImageFormat.Png and default c... |
| [create-powershell-script-iterates-markdown-files-converts-each-tiff-image.cs](./create-powershell-script-iterates-markdown-files-converts-each-tiff-image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Create a PowerShell script that iterates over Markdown files and converts each to a TIFF i... |
| [create-reusable-configuration-class-holding-default-pdf-doc-image-save-options-instances.cs](./create-reusable-configuration-class-holding-default-pdf-doc-image-save-options-instances.cs) | `HTMLSaveOptions`, `Configuration` | Create a reusable configuration class that holds default PdfSaveOptions, DocSaveOptions, a... |
| [create-reusable-extension-method-wrapping-convertmarkdown-returning-htmldocument-for-further-processing.cs](./create-reusable-extension-method-wrapping-convertmarkdown-returning-htmldocument-for-further-processing.cs) | `MarkdownSaveOptions`, `HTMLDocument` | Create a reusable extension method that wraps ConvertMarkdown and returns an HTMLDocument ... |
| [create-reusable-method-accepting-markdown-path-and-target-format-enum-returning-output-file-path.cs](./create-reusable-method-accepting-markdown-path-and-target-format-enum-returning-output-file-path.cs) | `MarkdownSaveOptions` | Create a reusable method that accepts a Markdown path and target format enum, returning th... |
| [create-windows-service-convert-incoming-markdown-emails-to-png-attachments-real-time.cs](./create-windows-service-convert-incoming-markdown-emails-to-png-attachments-real-time.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Create a Windows service that converts incoming Markdown emails to PNG attachments in real... |
| [customize-font-embedding-settings-in-xpssaveoptions-while-converting-markdown-to-xps.cs](./customize-font-embedding-settings-in-xpssaveoptions-while-converting-markdown-to-xps.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Customize the font embedding settings in XpsSaveOptions while converting Markdown to XPS f... |
| [dispose-htmldocument-after-conversion-release-unmanaged-resources-avoid-memory-leaks.cs](./dispose-htmldocument-after-conversion-release-unmanaged-resources-avoid-memory-leaks.cs) | `Converter`, `HTMLDocument` | Dispose the HTMLDocument after conversion to release unmanaged resources and avoid memory ... |
| [ensure-png-images-from-markdown-have-minimum-300-dpi-resolution-by-configuring-image-save-options.cs](./ensure-png-images-from-markdown-have-minimum-300-dpi-resolution-by-configuring-image-save-options.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Ensure PNG images produced from Markdown have a minimum resolution of 300 DPI by setting I... |
| [ensure-temporary-html-files-deleted-after-final-output-saved.cs](./ensure-temporary-html-files-deleted-after-final-output-saved.cs) | `Converter` | Ensure that temporary HTML files created during conversion are deleted after the final out... |
| [export-markdown-content-as-svg-vector-graphic-using-svg-save-options-with-converthtml.cs](./export-markdown-content-as-svg-vector-graphic-using-svg-save-options-with-converthtml.cs) | `SVGDocument`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Export Markdown content as an SVG vector graphic by passing SvgSaveOptions to ConvertHTML. |
| [fine-tune-page-orientation-xpssaveoptions-converting-markdown-landscape-xps.cs](./fine-tune-page-orientation-xpssaveoptions-converting-markdown-landscape-xps.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Fine‑tune the page orientation in XpsSaveOptions when converting Markdown to landscape XPS... |
| [generate-high-quality-jpg-image-from-markdown-configuring-jpegquality-100.cs](./generate-high-quality-jpg-image-from-markdown-configuring-jpegquality-100.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Generate a high‑quality JPG image from Markdown by configuring ImageSaveOptions JpegQualit... |
| [generate-pdf-preview-converting-markdown-to-html-then-to-xps-document.cs](./generate-pdf-preview-converting-markdown-to-html-then-to-xps-document.cs) | `PdfSaveOptions`, `MarkdownSaveOptions`, `XpsSaveOptions` | Generate a PDF preview by converting Markdown to HTML and then to an XPS document. |
| [generate-xps-file-from-markdown-document-embed-custom-metadata.cs](./generate-xps-file-from-markdown-document-embed-custom-metadata.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Generate an XPS file from a Markdown document and embed custom metadata via XpsSaveOptions... |
| [implement-command-line-argument-parser-mapping-short-flags-output-formats-conversion-utility.cs](./implement-command-line-argument-parser-mapping-short-flags-output-formats-conversion-utility.cs) | `Converter` | Implement a command‑line argument parser that maps short flags to output formats for the c... |
| [implement-command-line-tool-accepting-markdown-file-path-outputting-html-file.cs](./implement-command-line-tool-accepting-markdown-file-path-outputting-html-file.cs) | `MarkdownSaveOptions` | Implement a command‑line tool that accepts a Markdown file path and outputs an HTML file. |
| [implement-error-handling-missing-markdown-files-batch-conversion-jpeg-images.cs](./implement-error-handling-missing-markdown-files-batch-conversion-jpeg-images.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Implement error handling for missing Markdown files during batch conversion to JPEG images... |
| [implement-real-time-markdown-to-jpeg-conversion-wpf-application-using-async-methods.cs](./implement-real-time-markdown-to-jpeg-conversion-wpf-application-using-async-methods.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Implement real‑time conversion of Markdown to JPEG within a WPF application using async me... |
| [load-markdown-file-convert-to-html-embed-html-into-xps-document.cs](./load-markdown-file-convert-to-html-embed-html-into-xps-document.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `Converter`, `HTMLDocument` | Load a Markdown file, convert it to HTML, and embed the HTML into an XPS document. |
| [load-markdown-file-from-disk-and-convert-to-html-file-using-convertmarkdown.cs](./load-markdown-file-from-disk-and-convert-to-html-file-using-convertmarkdown.cs) | `MarkdownSaveOptions`, `Converter`, `HTMLDocument` | Load a Markdown file from disk and convert it to an HTML file using ConvertMarkdown. |
| [load-markdown-file-local-file-system-convert-to-xps-document-default-settings.cs](./load-markdown-file-local-file-system-convert-to-xps-document-default-settings.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `Converter` | Load a Markdown file from the local file system and convert it to an XPS document using de... |
| [load-markdown-string-convert-to-png-image-with-custom-dpi.cs](./load-markdown-string-convert-to-png-image-with-custom-dpi.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Load a Markdown string and convert it to a PNG image with custom DPI using ImageSaveOption... |
| [load-multiple-markdown-documents-list-merge-single-html-output-file.cs](./load-multiple-markdown-documents-list-merge-single-html-output-file.cs) | `MarkdownSaveOptions`, `HTMLDocument` | Load multiple Markdown documents from a list and merge them into a single HTML output file... |
| [produce-xps-document-from-markdown-with-xpssaveoptions-converthtml-method.cs](./produce-xps-document-from-markdown-with-xpssaveoptions-converthtml-method.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Produce an XPS document from Markdown by supplying XpsSaveOptions to the ConvertHTML metho... |
| [real-time-conversion-markdown-stream-to-png-format-without-intermediate-files.cs](./real-time-conversion-markdown-stream-to-png-format-without-intermediate-files.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Perform real‑time conversion of a Markdown stream to PNG format without writing intermedia... |
| [save-html-document-as-pdf-pdf-save-options-convert-html.cs](./save-html-document-as-pdf-pdf-save-options-convert-html.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `HTMLDocument` | Save the resulting HTMLDocument as a PDF file by providing PdfSaveOptions to ConvertHTML. |
| [set-compression-level-imagesaveoptions-when-converting-markdown-to-png-for-web-optimization.cs](./set-compression-level-imagesaveoptions-when-converting-markdown-to-png-for-web-optimization.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set the compression level in ImageSaveOptions when converting Markdown to PNG for web opti... |
| [set-docx-document-language-property-to-support-localization-after-conversion.cs](./set-docx-document-language-property-to-support-localization-after-conversion.cs) | `HTMLSaveOptions`, `Converter` | Set DOCX document language property via DocSaveOptions.Language to support localization af... |
| [set-docx-page-setup-track-revisions-change-tracking.cs](./set-docx-page-setup-track-revisions-change-tracking.cs) | `HTMLSaveOptions` | Set DOCX page setup to track revisions using DocSaveOptions.TrackRevisions for change trac... |
| [set-image-dpi-150-image-save-options-png-output-balance-quality-file-size.cs](./set-image-dpi-150-image-save-options-png-output-balance-quality-file-size.cs) | `ImageSaveOptions`, `HTMLSaveOptions` | Set image DPI in ImageSaveOptions to 150 for PNG output to balance quality and file size. |
| [set-image-quality-parameter-in-imagesaveoptions-while-converting-markdown-to-jpeg-with-high-fidelity.cs](./set-image-quality-parameter-in-imagesaveoptions-while-converting-markdown-to-jpeg-with-high-fidelity.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set image quality parameter in ImageSaveOptions while converting Markdown to JPEG with hig... |
| [set-image-width-height-in-imagesaveoptions-when-converting-markdown-to-png.cs](./set-image-width-height-in-imagesaveoptions-when-converting-markdown-to-png.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set image width and height in ImageSaveOptions when converting Markdown to a PNG file. |
| [set-imagesaveoptions-background-color-to-white-to-avoid-transparent-backgrounds-in-jpg-images-generated-from-markdown.cs](./set-imagesaveoptions-background-color-to-white-to-avoid-transparent-backgrounds-in-jpg-images-generated-from-markdown.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set ImageSaveOptions.BackgroundColor to white to avoid transparent backgrounds in JPG imag... |
| [set-imagesaveoptions-imageformat-svg-when-converting-markdown-to-svg-ensure-correct-output-type.cs](./set-imagesaveoptions-imageformat-svg-when-converting-markdown-to-svg-ensure-correct-output-type.cs) | `SVGDocument`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set ImageSaveOptions.ImageFormat to Svg when converting Markdown to SVG to ensure correct ... |
| [set-pdf-page-margins-top-bottom-left-right-before-conversion.cs](./set-pdf-page-margins-top-bottom-left-right-before-conversion.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `PdfRenderingOptions`, `Converter` | Set PDF page margins using PdfSaveOptions.MarginTop, MarginBottom, MarginLeft, and MarginR... |
| [unit-test-verifies-markdown-blockquote-conversion-to-html-and-png.cs](./unit-test-verifies-markdown-blockquote-conversion-to-html-and-png.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Create a unit test that verifies Markdown blockquote conversion to HTML and then to PNG. |
| [use-aspose-html-converters-namespace-alias-to-shorten-code-references-large-conversion-projects.cs](./use-aspose-html-converters-namespace-alias-to-shorten-code-references-large-conversion-projects.cs) | `Converter` | Use the Aspose.Html.Converters namespace alias to shorten code references in large convers... |
| [use-aspose-html-converters-namespace-exclusively-keep-conversion-code-concise-avoid-fully-qualified-type-names.cs](./use-aspose-html-converters-namespace-exclusively-keep-conversion-code-concise-avoid-fully-qualified-type-names.cs) | `Converter` | Use Aspose.Html.Converters namespace exclusively to keep conversion code concise and avoid... |
| [use-imagesaveoptions-specify-color-depth-converting-markdown-bmp.cs](./use-imagesaveoptions-specify-color-depth-converting-markdown-bmp.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions` | Use ImageSaveOptions to specify color depth when converting Markdown to BMP format. |
| [use-memorystream-convert-markdown-string-to-pdf-without-intermediate-files.cs](./use-memorystream-convert-markdown-string-to-pdf-without-intermediate-files.cs) | `PdfSaveOptions`, `MarkdownSaveOptions`, `Converter` | Use MemoryStream to convert a Markdown string to PDF without creating intermediate files o... |
| [use-stringreader-feed-markdown-content-directly-into-converter-output-xps-document.cs](./use-stringreader-feed-markdown-content-directly-into-converter-output-xps-document.cs) | `MarkdownSaveOptions`, `XpsSaveOptions` | Use a StringReader to feed Markdown content directly into the converter and output an XPS ... |
| [use-try-finally-block-to-guarantee-disposal-of-htmldocument-when-exception-occurs-during-conversion.cs](./use-try-finally-block-to-guarantee-disposal-of-htmldocument-when-exception-occurs-during-conversion.cs) | `Converter`, `HTMLDocument` | Use a try‑finally block to guarantee disposal of HtmlDocument even when an exception occur... |
| [use-xpssaveoptions-embed-custom-font-family-markdown-xps-conversion.cs](./use-xpssaveoptions-embed-custom-font-family-markdown-xps-conversion.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions`, `Converter` | Use XpsSaveOptions to embed a custom font family during Markdown to XPS conversion. |
| [use-xpssaveoptions-enable-document-outline-generation-converting-markdown-to-xps.cs](./use-xpssaveoptions-enable-document-outline-generation-converting-markdown-to-xps.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Use XpsSaveOptions to enable document outline generation when converting Markdown to XPS. |
| [use-xpssaveoptions-set-page-size-before-converting-markdown-xps-document.cs](./use-xpssaveoptions-set-page-size-before-converting-markdown-xps-document.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions`, `PdfRenderingOptions` | Use XpsSaveOptions to set page size before converting a Markdown file to an XPS document. |
| [utility-reads-markdown-from-stream-writes-html-output-to-another-stream.cs](./utility-reads-markdown-from-stream-writes-html-output-to-another-stream.cs) | `MarkdownSaveOptions` | Write a utility that reads Markdown from a stream and writes the HTML output to another st... |
| [validate-generated-html-file-reading-contents-checking-expected-heading-tags.cs](./validate-generated-html-file-reading-contents-checking-expected-heading-tags.cs) |  | Validate the generated HTML file by reading its contents and checking for expected heading... |
| [validate-intermediate-html-document-contains-expected-img-tags-before-converting-image-formats.cs](./validate-intermediate-html-document-contains-expected-img-tags-before-converting-image-formats.cs) | `ImageSaveOptions`, `HTMLDocument` | Validate that the intermediate HTMLDocument contains expected <img> tags before converting... |
| [verify-pdf-output-contains-correct-number-of-pages-opening-file-with-pdf-reader-library.cs](./verify-pdf-output-contains-correct-number-of-pages-opening-file-with-pdf-reader-library.cs) | `PdfSaveOptions` | Verify PDF output contains the correct number of pages by opening the file with a PDF read... |

## Category Statistics
- Total examples: 79
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `HTMLDocument`
- `MarkdownSaveOptions`
- `ImageSaveOptions`
- `XpsSaveOptions`
- `PdfSaveOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-10-02 | Examples: 79
<!-- AUTOGENERATED:END -->
