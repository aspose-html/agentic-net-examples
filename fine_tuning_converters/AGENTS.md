---
name: fine_tuning_converters
description: C# examples for fine_tuning_converters using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – fine_tuning_converters

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **fine_tuning_converters** category.
This folder contains standalone C# examples for fine_tuning_converters operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

## Scope

- **Category name**: fine_tuning_converters  
- **Total examples**: 121  
- **Typical workflow**:  
  1. **Load** – read an HTML, MHTML, EPUB, SVG, or Markdown source into an `HTMLDocument` (or related document type).  
  2. **Bind / Prepare** – optionally adjust page size, margins, background colour, CSS media type, or flatten form fields using rendering or save‑options objects.  
  3. **Convert** – invoke `Converter.ConvertHTML`, `Converter.ConvertMHTML`, `Converter.ConvertEPUB`, or the dedicated renderers (`PdfRenderer`, `ImageRenderer`, `XpsRenderer`, etc.).  
  4. **Render / Save** – write the output to a file, stream, or device (`PdfDevice`, `ImageDevice`, `XpsDevice`) while optionally logging progress or handling errors.

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | Core language constructs, console output |
| Aspose.Html | Core HTML document model and conversion entry points |
| Aspose.Html.Saving | Save‑option classes (e.g., `PdfSaveOptions`) |
| Aspose.Html.Converters | High‑level `Converter` static methods |
| Aspose.Html.Drawing | Length, Size, Margin definitions |
| Aspose.Html.Rendering.Pdf | PDF rendering devices and options |
| System.IO | File and directory handling |
| Aspose.Html.Rendering | Base rendering abstractions |
| Aspose.Html.Rendering.Image | Image rendering devices and options |
| System.Drawing | Colours, fonts, and other GDI+ structures |
| Aspose.Html.Rendering.Doc | DOC rendering devices and options |
| Aspose.Html.Dom.Svg | SVG document handling |
| System.Collections.Generic | Generic collections used in examples |
| Aspose.Html.IO | Stream providers for custom I/O |
| Aspose.Html.Dom | DOM manipulation helpers |
| Aspose.Html.Rendering.Xps | XPS rendering devices and options |
| System.Threading.Tasks | Asynchronous batch processing |
| System.Linq | LINQ queries for file enumeration |
| System.Net.Http | HTTP client usage for remote resources |
| System.Text | Encoding utilities |
| Aspose.Html.Services | User‑agent service configuration |

### How to import them

```csharp
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;

using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Services;
```

## Common Code Pattern

Below is a representative pattern that appears across many examples in this category.  
It demonstrates loading an HTML file, configuring PDF rendering options (margins, background colour, page size), converting the document, and writing the result to disk while logging progress.

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        // 1️⃣ Load the source HTML document.
        string htmlPath = @"C:\Samples\input.html";
        using var document = new HTMLDocument(htmlPath);

        // 2️⃣ Prepare rendering options – custom page size, margins, background colour.
        var pdfOptions = new PdfRenderingOptions
        {
            // Page size: 8.5" × 11"
            PageSize = new Size(Length.FromInches(8.5), Length.FromInches(11)),
            // Uniform 0.5" margins on all sides
            Margin = new Margin(Length.FromInches(0.5)),
            // Light‑gray background for visual branding
            BackgroundColor = System.Drawing.Color.LightGray
        };

        // 3️⃣ Create a PDF device that writes directly to a file.
        string pdfPath = @"C:\Samples\output.pdf";
        using var pdfDevice = new PdfDevice(pdfPath, pdfOptions);

        // 4️⃣ Render the HTML to PDF.
        Console.WriteLine("Rendering HTML to PDF...");
        document.RenderTo(pdfDevice);
        Console.WriteLine($"PDF generated successfully at: {pdfPath}");
    }
}
```

*Adjust the namespaces, options, and device type (`ImageDevice`, `XpsDevice`, etc.) to match the target format.*

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Console.WriteLine | 121 |
| Aspose.Html | 121 |
| HTMLDocument | 62 |
| PageSetup.AnyPage | 45 |
| System.IO | 43 |
| Rendering.Pdf | 41 |
| Page | 40 |
| Size | 38 |
| Converter.ConvertHTML | 36 |
| PdfSaveOptions | 29 |
| PdfDevice | 27 |
| Margin | 26 |
| PdfRenderingOptions | 25 |
| Path.Combine | 23 |
| Length.FromInches | 22 |
| System.Drawing | 21 |
| Rendering.Image | 21 |
| ImageFormat.Jpeg | 20 |
| Directory.GetFiles | 19 |
| Directory.CreateDirectory | 19 |

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [apply_custom_0_2_inch_left_margin_to_pdf_output_using_margin_left.cs](./apply_custom_0_2_inch_left_margin_to_pdf_output_using_margin_left.cs) | Apply Custom 0.2 Inch Left Margin To Pdf Output Using Margin Left | PdfRenderingOptions, Rendering.Pdf, PdfDevice | Sets a 0.2‑inch left margin for PDF output via `PdfRenderingOptions.MarginLeft`. |
| [apply_custom_1inch_top_margin_to_pdf_output_configuring_margin_top_before_rendering.cs](./apply_custom_1inch_top_margin_to_pdf_output_configuring_margin_top_before_rendering.cs) | Apply Custom 1Inch Top Margin To Pdf Output Configuring Margin Top Before Rendering | Length.FromInches, PdfRenderingOptions, PdfDevice | Configures a 1‑inch top margin before rendering the PDF. |
| [apply_custom_600x800_pixel_page_size_to_pdf_output_before_rendering.cs](./apply_custom_600x800_pixel_page_size_to_pdf_output_before_rendering.cs) | Apply Custom 600X800 Pixel Page Size To Pdf Output Before Rendering | PdfRenderingOptions, PdfDevice, Page | Demonstrates custom pixel‑based page dimensions for PDF generation. |
| [apply_custom_background_color_to_all_outputs_using_shared_rendering_options_instance_per_device.cs](./apply_custom_background_color_to_all_outputs_using_shared_rendering_options_instance_per_device.cs) | Apply Custom Background Color To All Outputs Using Shared Rendering Options Instance Per Device | PdfRenderingOptions, System.Drawing, Color.AliceBlue | Shows how a single `PdfRenderingOptions` instance can set a background colour for multiple devices. |
| [apply_uniform_1centimeter_right_margin_to_all_docx_outputs_configuring_docrenderingoptions_globally.cs](./apply_uniform_1centimeter_right_margin_to_all_docx_outputs_configuring_docrenderingoptions_globally.cs) | Apply Uniform 1Centimeter Right Margin To All Docx Outputs Configuring Docrenderingoptions Globally | DocSaveOptions, Converter.ConvertHTML, Size | Sets a 1 cm right margin for every DOCX conversion using global `DocSaveOptions`. |
| [apply_uniform_2cm_top_margin_to_all_pdf_outputs_globally_configure_rendering_options.cs](./apply_uniform_2cm_top_margin_to_all_pdf_outputs_globally_configure_rendering_options.cs) | Apply Uniform 2Cm Top Margin To All Pdf Outputs Globally Configure Rendering Options | Length.FromInches, PdfRenderingOptions, PdfDevice | Applies a 2 cm top margin to all PDFs via a shared `PdfRenderingOptions`. |
| [apply_white_background_color_to_pdf_output_configure_background_color_before_rendering.cs](./apply_white_background_color_to_pdf_output_configure_background_color_before_rendering.cs) | Apply White Background Color To Pdf Output Configure Background Color Before Rendering | System.Drawing, RenderingOptions.BackgroundColor, PdfSaveOptions | Configures a white background for PDF output before rendering. |
| [batch_convert_directory_html_files_to_high_resolution_jpgs_iterating_converthtml_with_image_rendering_options.cs](./batch_convert_directory_html_files_to_high_resolution_jpgs_iterating_converthtml_with_image_rendering_options.cs) | Batch Convert Directory Html Files To High Resolution Jpgs Iterating Converthtml With Image Rendering Options | HTMLDocument, ImageFormat.Jpeg, Directory.GetFiles | Converts every HTML file in a folder to high‑resolution JPEGs using `ImageRenderingOptions`. |
| [batch_convert_directory_mhtml_files_to_jpg_setting_image_resolution_150_dpi.cs](./batch_convert_directory_mhtml_files_to_jpg_setting_image_resolution_150_dpi.cs) | Batch Convert Directory Mhtml Files To Jpg Setting Image Resolution 150 Dpi | ImageRenderingOptions, MhtmlRenderer, File.OpenRead | Renders MHTML files to JPEG at 150 dpi. |
| [batch_convert_epub_files_to_pdf_uniform_1inch_margin_all_sides_for_consistency.cs](./batch_convert_epub_files_to_pdf_uniform_1inch_margin_all_sides_for_consistency.cs) | Batch Convert Epub Files To Pdf Uniform 1Inch Margin All Sides For Consistency | PageSetup.AnyPage, Length.FromInches, File.OpenRead | Converts EPUBs to PDF with a consistent 1‑inch margin on every side. |
| [batch_convert_folder_html_files_to_pdf_using_converter_converthtml_foreach_loop.cs](./batch_convert_folder_html_files_to_pdf_using_converter_converthtml_foreach_loop.cs) | Batch Convert Folder Html Files To Pdf Using Converter Converthtml Foreach Loop | PdfSaveOptions, Directory.GetFiles, Converter.ConvertHTML | Simple foreach‑loop batch conversion of HTML to PDF. |
| [batch_convert_html_files_to_jpg_logging_resolution_and_background_color_settings_for_audit.cs](./batch_convert_html_files_to_jpg_logging_resolution_and_background_color_settings_for_audit.cs) | Batch Convert Html Files To Jpg Logging Resolution And Background Color Settings For Audit | HTMLDocument, System.Drawing, Path.GetFileName | Generates JPEGs while logging resolution and background colour for audit purposes. |
| [batch_convert_html_files_to_pdf_naming_each_output_with_original_filename_plus_suffix.cs](./batch_convert_html_files_to_pdf_naming_each_output_with_original_filename_plus_suffix.cs) | Batch Convert Html Files To Pdf Naming Each Output With Original Filename Plus Suffix | Path.GetDirectoryName, Converter.ConvertHTML, CustomStreamProvider | Saves PDFs with the original filename plus a custom suffix. |
| [batch_convert_html_files_to_pdf_with_progress_callback_monitor_conversion_status.cs](./batch_convert_html_files_to_pdf_with_progress_callback_monitor_conversion_status.cs) | Batch Convert Html Files To Pdf With Progress Callback Monitor Conversion Status | Configuration, Files.Length, Path.GetFileName | Demonstrates progress‑callback usage during batch PDF conversion. |
| [batch_convert_html_files_to_xps_with_uniform_0_4_inch_left_margin.cs](./batch_convert_html_files_to_xps_with_uniform_0_4_inch_left_margin.cs) | Batch Convert Html Files To Xps With Uniform 0.4 Inch Left Margin | Length.FromInches, HTMLDocument, XpsSaveOptions | Applies a 0.4‑inch left margin to every XPS output in a batch. |
| [batch_convert_mhtml_files_to_pdf_uniform_0_5inch_margin_all_sides.cs](./batch_convert_mhtml_files_to_pdf_uniform_0_5inch_margin_all_sides.cs) | Batch Convert Mhtml Files To Pdf Uniform 0.5Inch Margin All Sides | PageSetup.AnyPage, Converter.ConvertMHTML, File.OpenRead | Converts MHTML to PDF with a uniform 0.5‑inch margin. |
| [batch_convert_mixed_html_mhtml_files_to_flattened_pdfs_loop_shared_options.cs](./batch_convert_mixed_html_mhtml_files_to_flattened_pdfs_loop_shared_options.cs) | Batch Convert Mixed Html Mhtml Files To Flattened PDFs Loop Shared Options | FormFieldBehaviour.Flattened, Converters.Converter, Rendering.Pdf | Flattens form fields while converting a mixed collection of HTML/MHTML files. |
| [batch_process_folder_svg_files_to_pdf_with_0_2_inch_margin_all_sides.cs](./batch_process_folder_svg_files_to_pdf_with_0_2_inch_margin_all_sides.cs) | Batch Process Folder Svg Files To Pdf With 0.2 Inch Margin All Sides | PageSetup.AnyPage, PdfSaveOptions, Directory.GetFiles | Renders SVGs to PDF with a 0.2‑inch margin on every side. |
| [batch_process_html_files_to_xps_with_audit_logging.cs](./batch_process_html_files_to_xps_with_audit_logging.cs) | Batch Process Html Files To Xps With Audit Logging | XpsSaveOptions, Path.GetFileName, Directory.GetFiles | Converts HTML to XPS while writing an audit log. |
| [batch_process_svg_files_to_pdf_applying_adjust_to_widest_page_each_conversion.cs](./batch_process_svg_files_to_pdf_applying_adjust_to_widest_page_each_conversion.cs) | Batch Process Svg Files To Pdf Applying Adjust To Widest Page Each Conversion | PdfSaveOptions, Directory.GetFiles, Path.Combine | Enables `AdjustToWidestPage` per SVG conversion to fit content. |
| [configure_page_orientation_landscape_0_75_inch_margins_all_sides.cs](./configure_page_orientation_landscape_0_75_inch_margins_all_sides.cs) | Configure Page Orientation Landscape 0.75 Inch Margins All Sides | Length.FromInches, Rendering.Doc, Page | Sets landscape orientation with 0.75‑inch margins for DOC rendering. |
| [configure_pdf_rendering_options_disable_background_rendering_resulting_pdf_transparent_background.cs](./configure_pdf_rendering_options_disable_background_rendering_resulting_pdf_transparent_background.cs) | Configure Pdf Rendering Options Disable Background Rendering Resulting Pdf Transparent Background | PdfRenderingOptions, System.Drawing, Color.Transparent | Disables background drawing to produce a transparent PDF. |
| [configure_pdf_rendering_options_set_left_and_right_margins_0_5_inches_balanced_layout.cs](./configure_pdf_rendering_options_set_left_and_right_margins_0_5_inches_balanced_layout.cs) | Configure Pdf Rendering Options Set Left And Right Margins 0.5 Inches Balanced Layout | Length.FromInches, PdfRenderingOptions, PdfDevice | Sets symmetric 0.5‑inch side margins for balanced PDF layout. |
| [configure_pdf_rendering_options_set_right_margin_0_75_inches_ensuring_consistent_right_hand_spacing.cs](./configure_pdf_rendering_options_set_right_margin_0_75_inches_ensuring_consistent_right_hand_spacing.cs) | Configure Pdf Rendering Options Set Right Margin 0.75 Inches Ensuring Consistent Right Hand Spacing | Length.FromInches, PdfRenderingOptions, PdfDevice | Adjusts right margin to 0.75 inches for consistent right‑hand spacing. |
| [configure_pdf_rendering_options_set_top_bottom_margins_2_centimeters_uniform_spacing.cs](./configure_pdf_rendering_options_set_top_bottom_margins_2_centimeters_uniform_spacing.cs) | Configure Pdf Rendering Options Set Top Bottom Margins 2 Centimeters Uniform Spacing | Length.FromInches, PdfRenderingOptions, PdfDevice | Applies 2 cm top and bottom margins uniformly. |
| [configure_set_resolution_and_background_color_for_consistent_jpg_output_across_conversions.cs](./configure_set_resolution_and_background_color_for_consistent_jpg_output_across_conversions.cs) | Configure Set Resolution And Background Color For Consistent Jpg Output Across Conversions | HTMLDocument, ImageRenderingOptions, System.Drawing | Sets DPI and background colour to ensure consistent JPEG output. |
| [configure_top_and_bottom_margins_0_25_inches_compact_pages.cs](./configure_top_and_bottom_margins_0_25_inches_compact_pages.cs) | Configure Top And Bottom Margins 0.25 Inches Compact Pages | Length.FromInches, PdfRenderingOptions, PdfDevice | Creates compact pages with 0.25‑inch vertical margins. |
| [convert_epub_to_pdf_preserving_embedded_fonts_default_rendering_behavior.cs](./convert_epub_to_pdf_preserving_embedded_fonts_default_rendering_behavior.cs) | Convert Epub To Pdf Preserving Embedded Fonts Default Rendering Behavior | Console.WriteLine, File.OpenRead, PdfSaveOptions | Converts EPUB to PDF while preserving embedded fonts. |
| [convert_epub_to_pdf_set_left_and_right_margins_0_5_inches_balanced_appearance.cs](./convert_epub_to_pdf_set_left_and_right_margins_0_5_inches_balanced_appearance.cs) | Convert Epub To Pdf Set Left And Right Margins 0.5 Inches Balanced Appearance | Console.WriteLine, File.OpenRead, PdfSaveOptions | Applies 0.5‑inch side margins during EPUB‑to‑PDF conversion. |
| [convert_epub_to_xps_using_epubrenderer_xpsdevice_specifying_1inch_page_margins.cs](./convert_epub_to_xps_using_epubrenderer_xpsdevice_specifying_1inch_page_margins.cs) | Convert Epub To Xps Using Epubrenderer Xpsdevice Specifying 1Inch Page Margins | Length.FromInches, XpsRenderingOptions, File.OpenRead | Generates XPS from EPUB with 1‑inch page margins. |
| [convert_html_file_to_pdf_set_background_color_light_blue_branding.cs](./convert_html_file_to_pdf_set_background_color_light_blue_branding.cs) | Convert Html File To Pdf Set Background Color Light Blue Branding | PdfRenderingOptions, System.Drawing, PdfDevice | Sets a light‑blue background for PDF branding. |
| [convert_html_image_rendering_options_produce_jpg_files_from_remote_html_url_list.cs](./convert_html_image_rendering_options_produce_jpg_files_from_remote_html_url_list.cs) | Convert Html Image Rendering Options Produce Jpg Files From Remote Html Url List | Directory.CreateDirectory, Aspose.HTML, System.Threading | Downloads remote HTML pages and renders them to JPEGs. |
| [convert_html_memory_stream_to_pdf_pdfsaveoptions_flattening_enabled_avoid_intermediate_files.cs](./convert_html_memory_stream_to_pdf_pdfsaveoptions_flattening_enabled_avoid_intermediate_files.cs) | Convert Html Memory Stream To Pdf Pdfsaveoptions Flattening Enabled Avoid Intermediate Files | System.Collections, Encoding.UTF8, Stream.Length | Converts an in‑memory HTML stream to a flattened PDF without temp files. |
| [convert_html_to_docx_preserving_table_structures_default_options.cs](./convert_html_to_docx_preserving_table_structures_default_options.cs) | Convert Html To Docx Preserving Table Structures Default Options | Rendering.Doc, DocDevice, Aspose.Html | Converts HTML to DOCX while keeping table layouts intact. |
| [convert_html_to_jpg_preserve_original_aspect_ratio_without_explicit_width_height.cs](./convert_html_to_jpg_preserve_original_aspect_ratio_without_explicit_width_height.cs) | Convert Html To Jpg Preserve Original Aspect Ratio Without Explicit Width Height | PageSetup.PageLayoutOptions, HTMLDocument, ImageRenderingOptions | Renders HTML to JPEG preserving the original aspect ratio automatically. |
| [convert_html_to_pdf_disabling_background_rendering_transparent_background_document.cs](./convert_html_to_pdf_disabling_background_rendering_transparent_background_document.cs) | Convert Html To Pdf Disabling Background Rendering Transparent Background Document | PdfRenderingOptions, System.Drawing, Color.Transparent | Produces a PDF with a transparent background by disabling background rendering. |
| [convert_html_to_pdf_embed_all_fonts_using_default_rendering_options.cs](./convert_html_to_pdf_embed_all_fonts_using_default_rendering_options.cs) | Convert Html To Pdf Embed All Fonts Using Default Rendering Options | PdfSaveOptions, Converter.ConvertHTML, HTMLDocument | Embeds all fonts during HTML‑to‑PDF conversion with default options. |
| [convert_html_to_pdf_with_custom_page_size_and_margins.cs](./convert_html_to_pdf_with_custom_page_size_and_margins.cs) | Convert Html To Pdf With Custom Page Size And Margins | Rendering.Pdf, Drawing.Size, Drawing.Length | Demonstrates custom page dimensions and margins for PDF output. |
| [convert_html_to_xps_define_custom_top_bottom_margins_using_xps_rendering_options.cs](./convert_html_to_xps_define_custom_top_bottom_margins_using_xps_rendering_options.cs) | Convert Html To Xps Define Custom Top Bottom Margins Using Xps Rendering Options | Converters.Converter, Saving.XpsSaveOptions, Drawing.Size | Sets custom top/bottom margins for XPS conversion. |
| [convert_html_with_xps_rendering_options_produce_xps_files_from_html_custom_bottom_margin.cs](./convert_html_with_xps_rendering_options_produce_xps_files_from_html_custom_bottom_margin.cs) | Convert Html With Xps Rendering Options Produce Xps Files From Html Custom Bottom Margin | Length.FromInches, XpsSaveOptions, Converter.ConvertHTML | Applies a custom bottom margin when generating XPS from HTML. |
| [convert_markdown_to_html_inject_custom_css_head_save_styled_page.cs](./convert_markdown_to_html_inject_custom_css_head_save_styled_page.cs) | Convert Markdown To Html Inject Custom Css Head Save Styled Page | Encoding.UTF8, Element.TextContent, Converter.ConvertMarkdown | Converts Markdown to HTML and injects a custom CSS block into the `<head>`. |
| [convert_mhtml_to_pdf_with_custom_page_dimensions_pdfdevice_anypage.cs](./convert_mhtml_to_pdf_with_custom_page_dimensions_pdfdevice_anypage.cs) | Convert Mhtml To Pdf With Custom Page Dimensions Pdfdevice Anypage | MhtmlRenderer, PdfRenderingOptions, File.OpenRead | Renders MHTML to PDF with custom page size using `PdfDevice.AnyPage`. |
| [convert_svg_file_pdf_automatically_adjust_page_size_widest_element_using_adjusttowidestpage.cs](./convert_svg_file_pdf_automatically_adjust_page_size_widest_element_using_adjusttowidestpage.cs) | Convert Svg File Pdf Automatically Adjust Page Size Widest Element Using Adjusttowidestpage | PageSetup.AnyPage, PdfRenderingOptions, PdfDevice | Enables automatic page‑size adjustment to the widest SVG element. |
| [convert_svg_to_jpg_72dpi_transparent_background_web_thumbnails.cs](./convert_svg_to_jpg_72dpi_transparent_background_web_thumbnails.cs) | Convert Svg To Jpg 72Dpi Transparent Background Web Thumbnails | System.Drawing, Color.Transparent, ImageFormat.Jpeg | Generates 72 dpi transparent‑background JPEG thumbnails from SVG. |
| [convert_svg_to_jpg_using_imagedevice_72dpi_web_optimized_image_size.cs](./convert_svg_to_jpg_using_imagedevice_72dpi_web_optimized_image_size.cs) | Convert Svg To Jpg Using Imagedevice 72Dpi Web Optimized Image Size | ImageFormat.Jpeg, SVGDocument, ImageSaveOptions | Uses `ImageDevice` to create web‑optimized 72 dpi JPEGs from SVG. |
| [create_image_device_jpg_output_600dpi_resolution_white_background_high_quality_prints.cs](./create_image_device_jpg_output_600dpi_resolution_white_background_high_quality_prints.cs) | Create Image Device Jpg Output 600Dpi Resolution White Background High Quality Prints | ImageRenderingOptions, System.Drawing, ImageFormat.Jpeg | Configures a 600 dpi JPEG with white background for print quality. |
| [create_image_device_jpg_output_anti_aliasing_enabled_white_background_clean_visuals.cs](./create_image_device_jpg_output_anti_aliasing_enabled_white_background_clean_visuals.cs) | Create Image Device Jpg Output Anti Aliasing Enabled White Background Clean Visuals | HTMLDocument, ImageRenderingOptions, System.Drawing | Enables anti‑aliasing and white background for crisp JPEG output. |
| [create_image_device_jpg_output_black_background_set_background_color.cs](./create_image_device_jpg_output_black_background_set_background_color.cs) | Create Image Device Jpg Output Black Background Set Background Color | ImageRenderingOptions, System.Drawing, RenderingOptions.BackgroundColor | Sets a black background colour for JPEG rendering. |
| [create_pdfdevice_custom_page_size_5_by_7_inches_for_small_format_pdf_generation.cs](./create_pdfdevice_custom_page_size_5_by_7_inches_for_small_format_pdf_generation.cs) | Create Pdfdevice Custom Page Size 5 By 7 Inches For Small Format Pdf Generation | PdfRenderingOptions, Rendering.Pdf, PdfDevice | Generates PDFs sized 5 × 7 inches for small‑format documents. |
| [create_pdfdevice_portrait_orientation_1inch_margins_all_sides.cs](./create_pdfdevice_portrait_orientation_1inch_margins_all_sides.cs) | Create Pdfdevice Portrait Orientation 1Inch Margins All Sides | Length.FromInches, PdfRenderingOptions, PdfDevice | Sets portrait orientation with 1‑inch margins on every side. |
| [create_pdfdevice_with_adjust_to_widest_page_disabled_keep_original_page_widths_conversion.cs](./create_pdfdevice_with_adjust_to_widest_page_disabled_keep_original_page_widths_conversion.cs) | Create Pdfdevice With Adjust To Widest Page Disabled Keep Original Page Widths Conversion | Rendering.Pdf, PageSetup.AdjustToWidestPage, Console.WriteLine | Disables automatic widening, preserving original page widths. |
| [create_style_element_with_css_rules_append_to_html_head_generate_final_document.cs](./create_style_element_with_css_rules_append_to_html_head_generate_final_document.cs) | Create Style Element With Css Rules Append To Html Head Generate Final Document | DocumentElement.InsertBefore, Element.AppendChild, HTMLDocument | Programmatically injects a `<style>` block into the HTML `<head>`. |
| [detect_missing_css_files_during_html_conversion_fallback_to_default_styles_continue_processing_remaining_files.cs](./detect_missing_css_files_during_html_conversion_fallback_to_default_styles_continue_processing_remaining_files.cs) | Detect Missing Css Files During Html Conversion Fallback To Default Styles Continue Processing Remaining Files | XpsSaveOptions, Directory.GetFiles, Converter.ConvertHTML | Handles missing CSS gracefully by falling back to defaults. |
| [dispose_html_document_and_pdf_save_options_objects_after_each_conversion_to_free_unmanaged_resources_promptly.cs](./dispose_html_document_and_pdf_save_options_objects_after_each_conversion_to_free_unmanaged_resources_promptly.cs) | Dispose Html Document And Pdf Save Options Objects After Each Conversion To Free Unmanaged Resources Promptly | FormFieldBehaviour.Flattened, Rendering.Pdf, PdfSaveOptions | Shows proper disposal of resources after each conversion. |
| [each_conversion_verify_output_pdf_html_file_exists_not_empty_before_proceeding.cs](./each_conversion_verify_output_pdf_html_file_exists_not_empty_before_proceeding.cs) | Each Conversion Verify Output Pdf Html File Exists Not Empty Before Proceeding | Converters.Converter, FileInfo, Saving.PdfSaveOptions | Validates that each generated PDF is non‑empty before moving on. |
| [enable_anti_aliasing_for_image_conversion_to_produce_smoother_jpg_output_from_html_content.cs](./enable_anti_aliasing_for_image_conversion_to_produce_smoother_jpg_output_from_html_content.cs) | Enable Anti Aliasing For Image Conversion To Produce Smoother Jpg Output From Html Content | ImageFormat.Jpeg, Converter.ConvertHTML, ImageSaveOptions | Turns on anti‑aliasing for higher‑quality JPEGs. |
| [ensure_unicode_characters_render_correctly_setting_appropriate_encoding_loading_html_files_conversion.cs](./ensure_unicode_characters_render_correctly_setting_appropriate_encoding_loading_html_files_conversion.cs) | Ensure Unicode Characters Render Correctly Setting Appropriate Encoding Loading Html Files Conversion | Encoding.GetEncoding, Path.GetDirectoryName, Converter.ConvertHTML | Sets proper encoding to preserve Unicode characters during conversion. |
| [generate_high_resolution_jpg_from_html_setting_image_rendering_options_resolution_dpi_300.cs](./generate_high_resolution_jpg_from_html_setting_image_rendering_options_resolution_dpi_300.cs) | Generate High Resolution Jpg From Html Setting Image Rendering Options Resolution Dpi 300 | ImageRenderingOptions.ResolutionDpi, HTMLDocument, ImageFormat.Jpeg | Produces 300 dpi JPEGs from HTML. |
| [generate_jpg_from_svg_using_imagedevice_300_dpi_white_background_color.cs](./generate_jpg_from_svg_using_imagedevice_300_dpi_white_background_color.cs) | Generate Jpg From Svg Using Imagedevice 300 Dpi White Background Color | Converters.Converter, System.Drawing, SVGDocument | Renders SVG to 300 dpi JPEG with white background. |
| [generate_unique_css_style_block_for_each_markdown_document_based_on_metadata_before_html_conversion.cs](./generate_unique_css_style_block_for_each_markdown_document_based_on_metadata_before_html_conversion.cs) | Generate Unique Css Style Block For Each Markdown Document Based On Metadata Before Html Conversion | Encoding.UTF8, Element.TextContent, Converter.ConvertMarkdown | Creates per‑document CSS based on metadata before conversion. |
| [implement_asynchronous_batch_processing_convert_thousands_html_files_to_flattened_pdfs_without_blocking_ui_thread.cs](./implement_asynchronous_batch_processing_convert_thousands_html_files_to_flattened_pdfs_without_blocking_ui_thread.cs) | Implement Asynchronous Batch Processing Convert Thousands Html Files To Flattened PDFs Without Blocking Ui Thread | System.Linq, Task.WhenAll, FormFieldBehaviour.Flattened | Uses async/await to process large batches without UI freeze. |
| [inspect_html_head_confirm_style_element_before_existing_links_css_injection.cs](./inspect_html_head_confirm_style_element_before_existing_links_css_injection.cs) | Inspect Html Head Confirm Style Element Before Existing Links Css Injection | Math.Min, System.Linq, HTMLDocument | Checks for existing `<style>` tags before injecting new CSS. |
| [load_html_file_set_formfield_behaviour_flattened_convert_static_pdf.cs](./load_html_file_set_formfield_behaviour_flattened_convert_static_pdf.cs) | Load Html File Set Formfield Behaviour Flattened Convert Static Pdf | FormFieldBehaviour.Flattened, Rendering.Pdf, PdfSaveOptions | Flattens interactive form fields to produce a static PDF. |
| [load_mhtml_document_configure_flattened_pdf_save_options_convert_non_interactive_pdf.cs](./load_mhtml_document_configure_flattened_pdf_save_options_convert_non_interactive_pdf.cs) | Load Mhtml Document Configure Flattened Pdf Save Options Convert Non Interactive Pdf | FormFieldBehaviour.Flattened, Converter.ConvertMHTML, Rendering.Pdf | Converts MHTML to a non‑interactive (flattened) PDF. |
| [load_shared_css_file_once_and_inject_into_each_generated_html_document_during_batch_markdown_conversion.cs](./load_shared_css_file_once_and_inject_into_each_generated_html_document_during_batch_markdown_conversion.cs) | Load Shared Css File Once And Inject Into Each Generated Html Document During Batch Markdown Conversion | Encoding.UTF8, Element.TextContent, Converter.ConvertMarkdown | Reuses a single CSS file across many Markdown‑to‑HTML conversions. |
| [log_successful_conversions_with_source_and_destination_paths_and_timestamp_to_csv_audit.cs](./log_successful_conversions_with_source_and_destination_paths_and_timestamp_to_csv_audit.cs) | Log Successful Conversions With Source And Destination Paths And Timestamp To Csv Audit | StreamWriter, DateTime.Now, PdfSaveOptions | Writes conversion audit entries to a CSV file. |
| [merge_three_html_files_into_single_pdf_invoking_htmlrenderer_renderto_sequentially_same_pdfdevice.cs](./merge_three_html_files_into_single_pdf_invoking_htmlrenderer_renderto_sequentially_same_pdfdevice.cs) | Merge Three Html Files Into Single Pdf Invoking Htmlrenderer Renderto Sequentially Same Pdfdevice | Rendering.HtmlRenderer, Rendering.Pdf, HtmlRenderer.RenderTo | Merges multiple HTML sources into one PDF using a single `PdfDevice`. |
| [open_resulting_pdf_confirm_interactive_form_fields_not_editable_successful_flattening.cs](./open_resulting_pdf_confirm_interactive_form_fields_not_editable_successful_flattening.cs) | Open Resulting Pdf Confirm Interactive Form Fields Not Editable Successful Flattening | FormFieldBehaviour.Flattened, Rendering.Pdf, PdfSaveOptions | Verifies that form fields are flattened after conversion. |
| [process_directory_html_files_applying_identical_flattened_pdf_save_options_each_conversion.cs](./process_directory_html_files_applying_identical_flattened_pdf_save_options_each_conversion.cs) | Process Directory Html Files Applying Identical Flattened Pdf Save Options Each Conversion | FormFieldBehaviour.Flattened, Rendering.Pdf, PdfSaveOptions | Applies the same flattening options to every HTML file in a folder. |
| [process_multiple_epub_files_in_parallel_convert_to_docx_using_epubrenderer_docdevice.cs](./process_multiple_epub_files_in_parallel_convert_to_docx_using_epubrenderer_docdevice.cs) | Process Multiple Epub Files In Parallel Convert To Docx Using Epubrenderer Docdevice | EpubRenderer, Rendering.Doc, Parallel.ForEach | Parallel conversion of EPUBs to DOCX using `DocDevice`. |
| [provide_base_url_converthtml_correctly_resolve_relative_links_resources_during_pdf_generation.cs](./provide_base_url_converthtml_correctly_resolve_relative_links_resources_during_pdf_generation.cs) | Provide Base Url Converthtml Correctly Resolve Relative Links Resources During Pdf Generation | Converter.ConvertHTML, PdfSaveOptions, Console.WriteLine | Supplies a base URL so relative resources resolve correctly. |
| [provide_base_url_in_htmlloadoptions_when_converting_mhtml_to_ensure_relative_links_resolve_correctly_in_pdf.cs](./provide_base_url_in_htmlloadoptions_when_converting_mhtml_to_ensure_relative_links_resolve_correctly_in_pdf.cs) | Provide Base Url In Htmlloadoptions When Converting Mhtml To Ensure Relative Links Resolve Correctly In Pdf | Converter.ConvertMHTML, File.OpenRead, PdfSaveOptions | Uses `HtmlLoadOptions.BaseUrl` for proper resource resolution. |
| [read_markdown_file_into_stream_convert_to_html_save_output_to_target_folder.cs](./read_markdown_file_into_stream_convert_to_html_save_output_to_target_folder.cs) | Read Markdown File Into Stream Convert To Html Save Output To Target Folder | Converter.ConvertMarkdown, Directory.GetCurrentDirectory, Path.Combine | Reads a Markdown file via stream, converts to HTML, and saves it. |
| [render_epub_to_docx_custom_page_size_8_5_by_13_inches.cs](./render_epub_to_docx_custom_page_size_8_5_by_13_inches.cs) | Render Epub To Docx Custom Page Size 8.5 By 13 Inches | DocSaveOptions, Length.FromInches, File.OpenRead | Generates DOCX with a custom 8.5 × 13 inches page size. |
| [render_epub_to_pdf_top_bottom_margins_15_points_balanced_layout.cs](./render_epub_to_pdf_top_bottom_margins_15_points_balanced_layout.cs) | Render Epub To Pdf Top Bottom Margins 15 Points Balanced Layout | PdfRenderingOptions, EpubRenderer, Rendering.Pdf | Applies 15‑point top/bottom margins for balanced PDF layout. |
| [render_epub_to_pdf_with_custom_top_margin_25_points_for_header_space.cs](./render_epub_to_pdf_with_custom_top_margin_25_points_for_header_space.cs) | Render Epub To Pdf With Custom Top Margin 25 Points For Header Space | Rendering.EpubRenderer, Rendering.Pdf, File.OpenRead | Adds a 25‑point top margin to leave space for a header. |
| [render_html_document_to_xps_landscape_orientation_pageorientation.cs](./render_html_document_to_xps_landscape_orientation_pageorientation.cs) | Render Html Document To Xps Landscape Orientation Pageorientation | Length.FromInches, XpsRenderingOptions, Rendering.Xps | Renders HTML to XPS in landscape orientation. |
| [render_html_to_docx_custom_page_size_8_5by14_inches_docrenderingoptions.cs](./render_html_to_docx_custom_page_size_8_5by14_inches_docrenderingoptions.cs) | Render Html To Docx Custom Page Size 8.5By14 Inches Docrenderingoptions | Rendering.Doc, Drawing.Size, Drawing.Page | Generates DOCX with a custom 8.5 × 14 inches page size. |
| [render_html_to_docx_with_custom_page_orientation_landscape.cs](./render_html_to_docx_with_custom_page_orientation_landscape.cs) | Render Html To Docx With Custom Page Orientation Landscape | Length.FromInches, Rendering.Doc, DocDevice | Produces a landscape‑oriented DOCX. |
| [render_html_to_docx_with_portrait_orientation_and_1inch_page_margins.cs](./render_html_to_docx_with_portrait_orientation_and_1inch_page_margins.cs) | Render Html To Docx With Portrait Orientation And 1Inch Page Margins | Length.FromInches, Rendering.Doc, DocDevice | Creates a portrait DOCX with 1‑inch margins. |
| [render_html_to_pdf_custom_background_light_gray_subtle_visual_effect.cs](./render_html_to_pdf_custom_background_light_gray_subtle_visual_effect.cs) | Render Html To Pdf Custom Background Light Gray Subtle Visual Effect | PdfRenderingOptions, Color.LightGray, Rendering.Pdf | Applies a light‑gray background to the PDF for a subtle effect. |
| [render_html_to_pdf_custom_page_orientation_landscape_0_5_inch_margins_all_sides.cs](./render_html_to_pdf_custom_page_orientation_landscape_0_5_inch_margins_all_sides.cs) | Render Html To Pdf Custom Page Orientation Landscape 0.5 Inch Margins All Sides | Converters.Converter, Saving.PdfSaveOptions, Drawing.Size | Generates a landscape PDF with 0.5‑inch margins on every side. |
| [render_html_to_pdf_custom_right_margin_12_points_for_binding_requirements.cs](./render_html_to_pdf_custom_right_margin_12_points_for_binding_requirements.cs) | Render Html To Pdf Custom Right Margin 12 Points For Binding Requirements | Length.FromInches, PdfRenderingOptions, PdfDevice | Sets a 12‑point right margin to accommodate binding. |
| [render_html_to_pdf_embed_external_css_files_ensure_default_rendering_includes_linked_resources.cs](./render_html_to_pdf_embed_external_css_files_ensure_default_rendering_includes_linked_resources.cs) | Render Html To Pdf Embed External Css Files Ensure Default Rendering Includes Linked Resources | Rendering.Pdf, System.IO, PdfDevice | Ensures external CSS files are embedded during PDF rendering. |
| [render_html_to_pdf_with_adjust_to_widest_page_enabled_automatically_fit_content_each_page.cs](./render_html_to_pdf_with_adjust_to_widest_page_enabled_automatically_fit_content_each_page.cs) | Render Html To Pdf With Adjust To Widest Page Enabled Automatically Fit Content Each Page | PageSetup.AnyPage, PdfRenderingOptions, PdfDevice | Enables automatic widening to fit the widest content on each page. |
| [render_html_to_xps_custom_left_margin_8pt_align_content_precisely.cs](./render_html_to_xps_custom_left_margin_8pt_align_content_precisely.cs) | Render Html To Xps Custom Left Margin 8Pt Align Content Precisely | Length.FromInches, XpsSaveOptions, Converter.ConvertHTML | Sets an 8‑pt left margin for precise XPS layout. |
| [render_html_to_xps_with_custom_left_margin_of_10_millimeters.cs](./render_html_to_xps_with_custom_left_margin_of_10_millimeters.cs) | Render Html To Xps With Custom Left Margin Of 10 Millimeters | Length.FromInches, XpsSaveOptions, XpsRenderingOptions.MarginLeft | Applies a 10 mm left margin for XPS output. |
| [render_mhtml_document_to_jpg_300_dpi_resolution_white_background_print_ready_images.cs](./render_mhtml_document_to_jpg_300_dpi_resolution_white_background_print_ready_images.cs) | Render Mhtml Document To Jpg 300 Dpi Resolution White Background Print Ready Images | System.Drawing, Converter.ConvertMHTML, File.OpenRead | Produces 300 dpi JPEGs with white background from MHTML. |
| [render_mhtml_document_to_pdf_custom_page_orientation_portrait_vertical_layout.cs](./render_mhtml_document_to_pdf_custom_page_orientation_portrait_vertical_layout.cs) | Render Mhtml Document To Pdf Custom Page Orientation Portrait Vertical Layout | MhtmlRenderer, PdfRenderingOptions, Rendering.Pdf | Generates a portrait‑oriented PDF from MHTML. |
| [render_mhtml_file_to_xps_with_adjust_to_widest_page_true_optimal_page_fitting.cs](./render_mhtml_file_to_xps_with_adjust_to_widest_page_true_optimal_page_fitting.cs) | Render Mhtml File To Xps With Adjust To Widest Page True Optimal Page Fitting | XpsSaveOptions, Aspose.HTML, File.OpenRead | Enables `AdjustToWidestPage` for optimal XPS page fitting. |
| [render_multiple_html_files_to_single_docx_document_sequentially_invoking_render_to_docdevice.cs](./render_multiple_html_files_to_single_docx_document_sequentially_invoking_render_to_docdevice.cs) | Render Multiple Html Files To Single Docx Document Sequentially Invoking Render To Docdevice | Rendering.Doc, DocDevice, HtmlRenderer.RenderTo | Merges several HTML files into one DOCX using a single `DocDevice`. |
| [render_multiple_html_files_to_single_xps_document_sequentially_using_htmlrenderer_renderto_one_xpsdevice.cs](./render_multiple_html_files_to_single_xps_document_sequentially_using_htmlrenderer_renderto_one_xpsdevice.cs) | Render Multiple Html Files To Single Xps Document Sequentially Using Htmlrenderer Renderto One Xpsdevice | Rendering.Xps, XpsDevice, HtmlRenderer.RenderTo | Combines multiple HTML files into a single XPS document. |
| [render_multiple_mhtml_files_into_single_pdf_using_one_pdfdevice_and_mhtmlrenderer_renderto_each.cs](./render_multiple_mhtml_files_into_single_pdf_using_one_pdfdevice_and_mhtmlrenderer_renderto_each.cs) | Render Multiple Mhtml Files Into Single Pdf Using One Pdfdevice And Mhtmlrenderer Renderto Each | MhtmlRenderer, Rendering.Pdf, File.OpenRead | Streams several MHTML files into a single PDF using one `PdfDevice`. |
| [render_svg_image_to_pdf_using_pdfdevice_anypage_600x500_pixels.cs](./render_svg_image_to_pdf_using_pdfdevice_anypage_600x500_pixels.cs) | Render Svg Image To Pdf Using Pdfdevice Anypage 600X500 Pixels | PageSetup.AnyPage, PdfRenderingOptions, PdfDevice | Renders an SVG to PDF with a 600 × 500 pixel page size. |
| [render_svg_to_pdf_custom_background_color_light_gray_pdfdevice.cs](./render_svg_to_pdf_custom_background_color_light_gray_pdfdevice.cs) | Render Svg To Pdf Custom Background Color Light Gray Pdfdevice | PageSetup.AnyPage, PdfRenderingOptions, Color.LightGray | Applies a light‑gray background when converting SVG to PDF. |
| [resize_embedded_images_in_html_before_pdf_conversion_reduce_final_pdf_size_preserving_quality.cs](./resize_embedded_images_in_html_before_pdf_conversion_reduce_final_pdf_size_preserving_quality.cs) | Resize Embedded Images In Html Before Pdf Conversion Reduce Final Pdf Size Preserving Quality | Converters.Converter, System.Drawing, Saving.PdfSaveOptions | Down‑samples embedded images to shrink PDF size while keeping quality. |
| [set_anti_aliasing_false_for_faster_jpg_generation_when_visual_quality_secondary.cs](./set_anti_aliasing_false_for_faster_jpg_generation_when_visual_quality_secondary.cs) | Set Anti Aliasing False For Faster Jpg Generation When Visual Quality Secondary | ImageRenderingOptions.AntiAliasing, ImageFormat.Jpeg, Converter.ConvertHTML | Disables anti‑aliasing for speed‑optimized JPEG generation. |
| [set_anti_aliasing_true_resolution_dpi_300_high_quality_jpg_conversion.cs](./set_anti_aliasing_true_resolution_dpi_300_high_quality_jpg_conversion.cs) | Set Anti Aliasing True Resolution Dpi 300 High Quality Jpg Conversion | ImageRenderingOptions.AntiAliasing, ImageFormat.Jpeg, Rendering.Image | Enables anti‑aliasing and 300 dpi for high‑quality JPEGs. |
| [set_cssoptions_mediatype_screen_when_converting_html_to_jpg_capture_onscreen_appearance.cs](./set_cssoptions_mediatype_screen_when_converting_html_to_jpg_capture_onscreen_appearance.cs) | Set Cssoptions Mediatype Screen When Converting Html To Jpg Capture Onscreen Appearance | Rendering.Image, CssOptions.MediaType, ImageFormat.Jpeg | Forces `screen` media type to capture on‑screen styling in JPEGs. |
| [set_cssoptions_mediatype_to_screen_when_converting_html_to_docx_retain_onscreen_styling.cs](./set_cssoptions_mediatype_to_screen_when_converting_html_to_docx_retain_onscreen_styling.cs) | Set Cssoptions Mediatype To Screen When Converting Html To Docx Retain Onscreen Styling | DocSaveOptions, CssOptions.MediaType, Converter.ConvertHTML | Uses `screen` media type so DOCX reflects on‑screen CSS. |
| [set_cssoptions_media_type_to_print_for_xps_conversion_reflect_printed_media_styling.cs](./set_cssoptions_media_type_to_print_for_xps_conversion_reflect_printed_media_styling.cs) | Set Cssoptions Media Type To Print For Xps Conversion Reflect Printed Media Styling | Services.IUserAgentService, CssOptions.MediaType, Saving.XpsSaveOptions | Sets `print` media type for XPS to apply print‑specific CSS. |
| [set_css_media_type_print_pdf_conversion_match_printed_page_layout_conventions.cs](./set_css_media_type_print_pdf_conversion_match_printed_page_layout_conventions.cs) | Set Css Media Type Print Pdf Conversion Match Printed Page Layout Conventions | Converters.Converter, MediaType.Print, Saving.PdfSaveOptions | Applies `print` media type during PDF conversion for accurate print layout. |
| [set_css_media_type_screen_converting_html_to_pdf_emulate_on_screen_appearance.cs](./set_css_media_type_screen_converting_html_to_pdf_emulate_on_screen_appearance.cs) | Set Css Media Type Screen Converting Html To Pdf Emulate On Screen Appearance | HTMLDocument, PdfSaveOptions, Converter.ConvertHTML | Uses `screen` media type to emulate browser rendering in PDF. |
| [set_margin_bottom_0_3_inches_tighter_bottom_spacing_pdf_documents.cs](./set_margin_bottom_0_3_inches_tighter_bottom_spacing_pdf_documents.cs) | Set Margin Bottom 0.3 Inches Tighter Bottom Spacing Pdf Documents | Length.FromInches, PdfRenderingOptions, PdfDevice | Reduces bottom margin to 0.3 inches for tighter layout. |
| [set_pdfsaveoptions_compressionlevel_balance_file_size_quality_flattening_pdfs_html_sources.cs](./set_pdfsaveoptions_compressionlevel_balance_file_size_quality_flattening_pdfs_html_sources.cs) | Set Pdfsaveoptions Compressionlevel Balance File Size Quality Flattening Pdfs Html Sources | FormFieldBehaviour.Flattened, PdfSaveOptions.CompressionLevel, Rendering.Pdf | Chooses a balanced compression level while flattening PDFs. |
| [set_pdfsaveoptions_page_size_margin_before_converting_html_to_pdf_control_page_layout.cs](./set_pdfsaveoptions_page_size_margin_before_converting_html_to_pdf_control_page_layout.cs) | Set Pdfsaveoptions Page Size Margin Before Converting Html To Pdf Control Page Layout | Length.FromInches, PdfSaveOptions.PageSize, Converter.ConvertHTML | Sets page size and margins prior to conversion for precise layout control. |
| [set_pdfsaveoptions_title_and_author_before_conversion_embed_custom_metadata_into_flattened_pdf.cs](./set_pdfsaveoptions_title_and_author_before_conversion_embed_custom_metadata_into_flattened_pdf.cs) | Set Pdfsaveoptions Title And Author Before Conversion Embed Custom Metadata Into Flattened Pdf | DocumentInfo.Title, PdfSaveOptions.Title, Aspose.HTML | Embeds title and author metadata into the flattened PDF. |
| [set_pdf_rendering_options_page_size_custom_dimensions_7_by_10_inches_niche_document_formats.cs](./set_pdf_rendering_options_page_size_custom_dimensions_7_by_10_inches_niche_document_formats.cs) | Set Pdf Rendering Options Page Size Custom Dimensions 7 By 10 Inches Niche Document Formats | Length.FromInches, PdfSaveOptions, Page | Configures a 7 × 10 inch page size for specialized PDFs. |
| [set_resolution_dpi_200_for_moderate_quality_jpg_conversion_from_html_content_in_resulting_image.cs](./set_resolution_dpi_200_for_moderate_quality_jpg_conversion_from_html_content_in_resulting_image.cs) | Set Resolution Dpi 200 For Moderate Quality Jpg Conversion From Html Content In Resulting Image | ImageRenderingOptions.ResolutionDpi, HTMLDocument, ImageFormat.Jpeg | Uses 200 dpi for a balance between quality and file size. |
| [specify_pdfsaveoptions_pdfversion_1_7_when_flattening_pdfs_compatibility_modern_viewers.cs](./specify_pdfsaveoptions_pdfversion_1_7_when_flattening_pdfs_compatibility_modern_viewers.cs) | Specify Pdfsaveoptions Pdfversion 1.7 When Flattening Pdfs Compatibility Modern Viewers | FormFieldBehaviour.Flattened, PdfSaveOptions.PdfVersion, Rendering.Pdf | Sets PDF version to 1.7 for maximum viewer compatibility. |
| [stream_large_markdown_files_line_by_line_avoid_loading_entire_content_into_memory.cs](./stream_large_markdown_files_line_by_line_avoid_loading_entire_content_into_memory.cs) | Stream Large Markdown Files Line By Line Avoid Loading Entire Content Into Memory | Converter.ConvertMarkdown, System.IO, File.OpenRead | Processes large Markdown files line‑by‑line to reduce memory usage. |
| [transform_epub_to_docx_using_epubrenderer_docdevice_custom_margin_settings.cs](./transform_epub_to_docx_using_epubrenderer_docdevice_custom_margin_settings.cs) | Transform Epub To Docx Using Epubrenderer Docdevice Custom Margin Settings | EpubRenderer, Rendering.Doc, File.OpenRead | Converts EPUB to DOCX with custom margins via `DocDevice`. |
| [use_converthtml_to_generate_pdf_files_from_html_with_custom_background_color.cs](./use_converthtml_to_generate_pdf_files_from_html_with_custom_background_color.cs) | Use Converthtml To Generate Pdf Files From Html With Custom Background Color | Color.LightGray, PdfSaveOptions, Converter.ConvertHTML | Demonstrates background colour customization during HTML‑to‑PDF conversion. |
| [use_htmlrenderer_renderto_imagedevice_produce_jpg_from_html_300_dpi_resolution.cs](./use_htmlrenderer_renderto_imagedevice_produce_jpg_from_html_300_dpi_resolution.cs) | Use Htmlrenderer Renderto Imagedevice Produce Jpg From Html 300 Dpi Resolution | HTMLDocument, ImageRenderingOptions, HtmlRenderer.RenderTo | Renders HTML to a 300 dpi JPEG via `ImageDevice`. |
| [use_htmlrenderer_renderto_imagedevice_produce_jpg_from_html_while_setting_anti_aliasing.cs](./use_htmlrenderer_renderto_imagedevice_produce_jpg_from_html_while_setting_anti_aliasing.cs) | Use Htmlrenderer Renderto Imagedevice Produce Jpg From Html While Setting Anti Aliasing | HTMLDocument, ImageRenderingOptions, HtmlRenderer | Enables anti‑aliasing for smoother JPEG output. |
| [use_htmlrenderer_renderto_pdfdevice_shared_renderingoptions_apply_common_settings_across_multiple_conversions.cs](./use_htmlrenderer_renderto_pdfdevice_shared_renderingoptions_apply_common_settings_across_multiple_conversions.cs) | Use Htmlrenderer Renderto Pdfdevice Shared Renderingoptions Apply Common Settings Across Multiple Conversions | PdfRenderingOptions, Color.LightGray, Rendering.Pdf | Shares a single `PdfRenderingOptions` instance across many PDF conversions. |
| [use_htmlrenderer_renderto_with_docdevice_to_convert_html_to_docx_applying_custom_margins.cs](./use_htmlrenderer_renderto_with_docdevice_to_convert_html_to_docx_applying_custom_margins.cs) | Use Htmlrenderer Renderto With Docdevice To Convert Html To Docx Applying Custom Margins | Rendering.Doc, DocDevice, Size | Converts HTML to DOCX while applying custom margins via `DocDevice`. |
| [verify_flattened_pdf_programmatically_checking_form_fields_merged_into_single_static_layer.cs](./verify_flattened_pdf_programmatically_checking_form_fields_merged_into_single_static_layer.cs) | Verify Flattened Pdf Programmatically Checking Form Fields Merged Into Single Static Layer | FormFieldBehaviour.Flattened, Converter.ConvertMHTML, PdfSaveOptions | Programmatically confirms that form fields have been flattened. |
| [wrap_batch_conversion_loop_try_catch_capture_log_unexpected_errors.cs](./wrap_batch_conversion_loop_try_catch_capture_log_unexpected_errors.cs) | Wrap Batch Conversion Loop Try Catch Capture Log Unexpected Errors | Path.GetFileNameWithoutExtension, CustomStreamProvider, Stream.Position | Demonstrates robust error handling around a batch conversion loop. |
| [wrap_converthtml_call_in_try_catch_block_to_handle_conversion_errors_and_log_details.cs](./wrap_converthtml_call_in_try_catch_block_to_handle_conversion_errors_and_log_details.cs) | Wrap Converthtml Call In Try Catch Block To Handle Conversion Errors And Log Details | Converter.ConvertHTML, MHTMLSaveOptions, Console.WriteLine | Shows how to catch and log conversion exceptions. |
| [write_pdf_output_of_converthtml_directly_to_memorystream_for_further_processing_without_temporary_file.cs](./write_pdf_output_of_converthtml_directly_to_memorystream_for_further_processing_without_temporary_file.cs) | Write Pdf Output Of Converthtml Directly To Memorystream For Further Processing Without Temporary File | System.Collections, Aspose.HTML, Provider.Streams, Console.WriteLine | Streams PDF output directly to memory for downstream processing. |

*The table above lists **all 121** examples, each linked to its source file, with the most relevant APIs highlighted.*

## Category‑Specific Tips

### Key API Surface
- **Rendering options** (`PdfRenderingOptions`, `XpsRenderingOptions`, `ImageRenderingOptions`) – central for page size, margins, DPI, background colour, anti‑aliasing, and `AdjustToWidestPage`.
- **Devices** (`PdfDevice`, `ImageDevice`, `XpsDevice`, `DocDevice`) – the sink that receives rendered output.
- **Converters** (`Converter.ConvertHTML`, `Converter.ConvertMHTML`, `Converter.ConvertEPUB`) – high‑level entry points for batch or single‑file conversion.
- **Save options** (`PdfSaveOptions`, `DocSaveOptions`, `XpsSaveOptions`) – control flattening, compression, metadata, and PDF version.
- **Utility classes** (`Length`, `Size`, `Margin`) – used to express physical dimensions consistently.

### Rules
1. **Always dispose** `HTMLDocument`, rendering devices, and save‑option objects (`using` or explicit `Dispose`) to free unmanaged resources promptly.  
2. **Set a base URL** (`HtmlLoadOptions.BaseUrl`) when converting files that contain relative links; otherwise resources will be missing.  
3. **Prefer shared rendering options** when multiple files share the same layout (margins, background colour, DPI) – reduces object churn and guarantees consistency.  
4. **Flatten form fields** (`FormFieldBehaviour.Flattened`) when the target PDF must be static; remember to set this on both `PdfSaveOptions` and any `PdfDevice`‑based rendering.  
5. **Adjust DPI** (`ImageRenderingOptions.ResolutionDpi`) before rendering images; higher DPI yields larger files but better quality.  
6. **When using `AdjustToWidestPage`**, be aware that it may enlarge all pages to match the widest element – disable it for original page‑width preservation.  
7. **Log progress** (`Console.WriteLine` or custom logger) especially in batch scenarios; include source and destination paths for auditability.  
8. **Validate output** (file existence, non‑zero length) before proceeding to the next file to catch silent failures early.  
9. **Use `Length.FromInches`** (or `Length.FromMillimeters`) for all margin and size specifications to avoid unit‑conversion errors.  
10. **Set `CssOptions.MediaType`** appropriately (`screen` vs `print`) to ensure the rendered output matches the intended styling context.

## Warnings

- **Template‑binding mismatches** – If you inject CSS or data into the HTML head, verify that the target element exists; otherwise `NullReferenceException` will be thrown.  
- **Missing external resources** – Forgetting to set a base URL or to copy linked CSS/JS files leads to incomplete rendering (blank sections, missing fonts).  
- **File‑path issues** – Hard‑coded absolute paths break on other machines; always build paths with `Path.Combine` and validate existence before use.  
- **Memory pressure** – Rendering large batches without disposing `HTMLDocument` or devices can exhaust unmanaged memory, causing `OutOfMemoryException`. Use `using` blocks or explicit `Dispose`.  
- **Incorrect DPI settings** – Setting an excessively high DPI for image output may produce massive files and long processing times; choose DPI appropriate to the final use case.  
- **Flattening side‑effects** – Enabling `FormFieldBehaviour.Flattened` removes interactivity; ensure this is intended before shipping the PDF.  
- **AdjustToWidestPage side‑effects** – Enabling it can unintentionally increase page count or introduce large white margins; disable when original layout must be preserved.

## Guidelines for Adding New Examples

1. **Self‑contained code** – The example must compile and run without external project references beyond the namespaces listed above.  
2. **Console logging** – Use `Console.WriteLine` to report key steps, input file, output file, and any configuration values.  
3. **Follow the common pattern** – Load → configure rendering/save options → convert/render → log success/failure.  
4. **Naming convention** – File name should be snake_case, title in PascalCase, and reflect the primary operation (e.g., `convert_html_to_pdf_custom_page_size_and_margins.cs`).  
5. **Update statistics** – After adding a file, increment the `total_examples` count and, if new APIs or namespaces are introduced, add them to the respective tables (though new APIs should be avoided per the strict rules).  

---