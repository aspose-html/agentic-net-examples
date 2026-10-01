---
name: advanced-html-editing
description: C# examples for Advanced Html Editing using Aspose.HTML for .NET
language: csharp
framework: net10.0
parent: ../agents.md
---

# AGENTS - Advanced Html Editing

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET,
working within the **Advanced Html Editing** category.
This folder contains standalone C# examples for Advanced Html Editing operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

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
| [apply_linear_gradient_fill_to_canvas_rectangle_and_export_drawing_as_jpeg_image.cs](./apply_linear_gradient_fill_to_canvas_rectangle_and_export_drawing_as_jpeg_image.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Apply a linear gradient fill to a canvas rectangle, and export the drawing as a JPEG image... |
| [configure_html_load_options_disable_external_resources_render_canvas_convert_to_jpeg_safely.cs](./configure_html_load_options_disable_external_resources_render_canvas_convert_to_jpeg_safely.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `Converter` | Configure HtmlLoadOptions to disable external resources, then render canvas and convert to... |
| [configure_imagesaveoptions_set_jpeg_dpi_300_render_high_resolution_canvas_save.cs](./configure_imagesaveoptions_set_jpeg_dpi_300_render_high_resolution_canvas_save.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `HTMLSaveOptions` | Configure ImageSaveOptions to set JPEG DPI to 300, then render a high‑resolution canvas an... |
| [configure_pdfsaveoptions_custom_margins_convert_html_canvas_to_pdf.cs](./configure_pdfsaveoptions_custom_margins_convert_html_canvas_to_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Configure PdfSaveOptions with custom margins, then convert an HTML file containing canvas ... |
| [configure_pdfsaveoptions_embed_xmp_metadata_convert_canvas_rich_html_document_to_pdf.cs](./configure_pdfsaveoptions_embed_xmp_metadata_convert_canvas_rich_html_document_to_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Configure PdfSaveOptions to embed XMP metadata, then convert a canvas‑rich HTML document t... |
| [convert_html_document_canvas_to_jpeg_image_save_options.cs](./convert_html_document_canvas_to_jpeg_image_save_options.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `HTMLSaveOptions`, `Converter` | Convert an HTML document containing a canvas element to JPEG using ImageSaveOptions. |
| [create_batch_process_reads_html_strings_draws_watermarks_on_canvases_writes_jpeg_outputs.cs](./create_batch_process_reads_html_strings_draws_watermarks_on_canvases_writes_jpeg_outputs.cs) | `ImageSaveOptions` | Create a batch process that reads HTML strings, draws watermarks on canvases, and writes J... |
| [create_canvas_element_html_string_draw_gradient_save_output_jpeg_image.cs](./create_canvas_element_html_string_draw_gradient_save_output_jpeg_image.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Create a canvas element in an HTML string, draw a gradient, and save output as a JPEG imag... |
| [create_css_aspose_rule_adds_background_color_to_canvas_elements_pdf.cs](./create_css_aspose_rule_adds_background_color_to_canvas_elements_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions` | Create a CSS -aspose- rule that adds a background color to all canvas elements in the PDF. |
| [create_css_aspose_rule_adds_drop_shadow_to_all_canvas_elements_in_pdf.cs](./create_css_aspose_rule_adds_drop_shadow_to_all_canvas_elements_in_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions` | Create a CSS -aspose- rule that adds a drop shadow to all canvas elements in PDF. |
| [create_css_rule_using_aspose_page_margin_to_add_printable_margins_around_canvas_content.cs](./create_css_rule_using_aspose_page_margin_to_add_printable_margins_around_canvas_content.cs) | `HTMLCanvasElement` | Create a CSS rule using -aspose- page‑margin to add printable margins around canvas conten... |
| [create_custom_css_extension_adds_aspose_page_number_footer_verify_pdf_output.cs](./create_custom_css_extension_adds_aspose_page_number_footer_verify_pdf_output.cs) | `PdfSaveOptions` | Create a custom CSS extension that adds a -aspose- page‑number footer, and verify in PDF o... |
| [create_custom_stream_provider_writes_jpeg_streams_to_network_location_during_conversion.cs](./create_custom_stream_provider_writes_jpeg_streams_to_network_location_during_conversion.cs) | `ICreateStreamProvider`, `ImageSaveOptions`, `Converter` | Create a custom ICreateStreamProvider that writes JPEG streams to a network location durin... |
| [create_pdf_device_with_file_path_attach_to_html_document_and_save_canvas_output.cs](./create_pdf_device_with_file_path_attach_to_html_document_and_save_canvas_output.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Create a PDF device with a file path, attach it to an HTMLDocument, and save the canvas ou... |
| [draw_series_concentric_circles_canvas_export_each_page_separate_jpeg_streams.cs](./draw_series_concentric_circles_canvas_export_each_page_separate_jpeg_streams.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Draw a series of concentric circles on a canvas, then export each page as separate JPEG st... |
| [enable_css_extensions_add_aspose_header_rule_verify_header_appears_in_converted_pdf.cs](./enable_css_extensions_add_aspose_header_rule_verify_header_appears_in_converted_pdf.cs) | `PdfSaveOptions` | Enable CSS extensions, add a -aspose- header rule, and verify header appears in converted ... |
| [enable_css_extensions_add_custom_aspose_margin_rule_convert_html_to_pdf.cs](./enable_css_extensions_add_custom_aspose_margin_rule_convert_html_to_pdf.cs) | `PdfSaveOptions`, `Converter` | Enable CSS extensions, add a custom -aspose- margin rule, then convert the HTML to PDF. |
| [enable_css_extensions_define_aspose_page_break_rule_verify_pdf_pagination_after_conversion.cs](./enable_css_extensions_define_aspose_page_break_rule_verify_pdf_pagination_after_conversion.cs) | `PdfSaveOptions`, `Converter` | Enable CSS extensions, define a -aspose- page‑break rule, and verify PDF pagination after ... |
| [implement_custom_stream_provider_writing_pdf_output_streams_to_disk_using_icreatestreamprovider_during_html_to_pdf_conve.cs](./implement_custom_stream_provider_writing_pdf_output_streams_to_disk_using_icreatestreamprovider_during_html_to_pdf_conve.cs) | `ICreateStreamProvider`, `PdfSaveOptions`, `Converter` | Implement a custom stream provider that writes PDF output streams to disk using ICreateStr... |
| [implement_stream_provider_compress_jpeg_pages_gzip_before_saving_disk.cs](./implement_stream_provider_compress_jpeg_pages_gzip_before_saving_disk.cs) | `ICreateStreamProvider`, `ImageSaveOptions` | Implement a custom stream provider that compresses JPEG pages using GZip before saving to ... |
| [implement_stream_provider_multi_page_html_to_jpeg_conversion.cs](./implement_stream_provider_multi_page_html_to_jpeg_conversion.cs) | `ICreateStreamProvider`, `ImageSaveOptions`, `Converter` | Implement ICreateStreamProvider to supply file streams for multi‑page HTML to JPEG convers... |
| [iterate_list_markdown_sources_add_watermark_canvas_overlay_output_pdfs.cs](./iterate_list_markdown_sources_add_watermark_canvas_overlay_output_pdfs.cs) | `HTMLCanvasElement`, `MarkdownSaveOptions` | Iterate over a list of Markdown sources, add a watermark canvas overlay, and output PDFs. |
| [iterate_over_directory_of_html_files_draw_border_on_each_canvas_save_pdfs.cs](./iterate_over_directory_of_html_files_draw_border_on_each_canvas_save_pdfs.cs) | `HTMLCanvasElement` | Iterate over a directory of HTML files, draw a border on each canvas, and save PDFs. |
| [load_epub_file_locate_canvas_element_draw_text_export_page_pdf.cs](./load_epub_file_locate_canvas_element_draw_text_export_page_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `EpubSaveOptions` | Load an EPUB file, locate its canvas element, draw text, and export the page as PDF. |
| [load_html_file_attach_mutationobserver_canvas_log_drawing_changes_console.cs](./load_html_file_attach_mutationobserver_canvas_log_drawing_changes_console.cs) | `MutationObserver`, `HTMLCanvasElement`, `HTMLDocument` | Load an HTML file, attach a MutationObserver to the canvas, and log drawing changes to con... |
| [load_html_file_edit_canvas_graphics_export_result_pdf.cs](./load_html_file_edit_canvas_graphics_export_result_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Load an HTML file, edit its canvas graphics, and export the result to a PDF file. |
| [load_markdown_file_with_embedded_canvas_add_drop_shadow_effect_convert_to_pdf.cs](./load_markdown_file_with_embedded_canvas_add_drop_shadow_effect_convert_to_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `MarkdownSaveOptions`, `Converter` | Load a Markdown file with embedded canvas, add a drop shadow effect, and convert to PDF. |
| [load_markdown_source_embed_canvas_render_shapes_icanvasrenderingcontext2d_save_pdf.cs](./load_markdown_source_embed_canvas_render_shapes_icanvasrenderingcontext2d_save_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `MarkdownSaveOptions` | Load a Markdown source, embed a canvas, render shapes via ICanvasRenderingContext2D, and s... |
| [load_mhtml_email_archive_edit_canvas_drawing_export_modified_content_to_jpeg.cs](./load_mhtml_email_archive_edit_canvas_drawing_export_modified_content_to_jpeg.cs) | `HTMLCanvasElement`, `ImageSaveOptions`, `HTMLDocument` | Load an MHTML email archive, edit its canvas drawing, and export the modified content to J... |
| [load_multiple_html_files_apply_same_canvas_drawing_routine_generate_combined_pdf_booklet.cs](./load_multiple_html_files_apply_same_canvas_drawing_routine_generate_combined_pdf_booklet.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Load multiple HTML files, apply the same canvas drawing routine, and generate a combined P... |
| [load_xhtml_page_modify_canvas_text_content_save_as_pdf.cs](./load_xhtml_page_modify_canvas_text_content_save_as_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `HTMLDocument` | Load a XHTML page, modify its canvas text content, and save the result as a PDF file. |
| [load_xml_document_transform_to_html_with_canvas_and_convert_to_pdf.cs](./load_xml_document_transform_to_html_with_canvas_and_convert_to_pdf.cs) | `HTMLCanvasElement`, `PdfSaveOptions`, `Converter`, `HTMLDocument` | Load an XML document, transform it to HTML with a canvas element, and convert to PDF. |
| [set_html_load_options_preserve_whitespace_render_canvas_export_pdf_preserving_layout.cs](./set_html_load_options_preserve_whitespace_render_canvas_export_pdf_preserving_layout.cs) | `HTMLCanvasElement`, `PdfSaveOptions` | Set HtmlLoadOptions to preserve whitespace, then render a canvas and export to PDF preserv... |
| [use_icanvasrenderingcontext2d_draw_bezier_curve_save_highresolution_jpeg.cs](./use_icanvasrenderingcontext2d_draw_bezier_curve_save_highresolution_jpeg.cs) | `ImageSaveOptions` | Use ICanvasRenderingContext2D to draw a bezier curve, then save the drawing as a high‑reso... |
| [use_icanvasrenderingcontext2d_draw_rotated_text_string_on_canvas_save_as_jpeg.cs](./use_icanvasrenderingcontext2d_draw_rotated_text_string_on_canvas_save_as_jpeg.cs) | `HTMLCanvasElement`, `ImageSaveOptions` | Use ICanvasRenderingContext2D to draw a rotated text string on a canvas and save as JPEG. |
| [use_mutationobserver_detect_canvas_element_changes_trigger_automatic_pdf_regeneration.cs](./use_mutationobserver_detect_canvas_element_changes_trigger_automatic_pdf_regeneration.cs) | `MutationObserver`, `HTMLCanvasElement`, `PdfSaveOptions` | Use MutationObserver to detect canvas element changes, then trigger automatic PDF regenera... |
| [use_mutationobserver_monitor_attribute_changes_on_canvas_and_automatically_adjust_pdf_page_orientation.cs](./use_mutationobserver_monitor_attribute_changes_on_canvas_and_automatically_adjust_pdf_page_orientation.cs) | `MutationObserver`, `HTMLCanvasElement`, `PdfSaveOptions` | Use MutationObserver to monitor attribute changes on canvas and automatically adjust PDF p... |

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
Updated: 2026-10-01 | Examples: 37
<!-- AUTOGENERATED:END -->
