---
name: markdown_converter
description: C# examples for markdown_converter using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – markdown_converter

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **markdown_converter** category.
This folder contains standalone C# examples for markdown_converter operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

## Scope

- **Category name**: markdown_converter  
- **Total examples**: 78  
- **Typical workflow**:  
  1. **Load** the Markdown source (file, string, or stream).  
  2. **Bind** any required data or resources (e.g., images, CSS).  
  3. **Convert** the Markdown to an intermediate HTML document using `Converter.ConvertMarkdown`.  
  4. **Render** the HTML to the desired output format (PDF, DOCX, PNG, etc.) with the appropriate `SaveOptions` and `Rendering` classes.

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | 78 |
| Aspose.Html.Converters | 73 |
| Aspose.Html.Saving | 64 |
| Aspose.Html | 62 |
| System.IO | 36 |
| Aspose.Html.Rendering.Image | 24 |
| Aspose.Html.Drawing | 7 |
| System.Drawing | 5 |
| System.Text | 4 |
| System.Collections.Generic | 4 |
| Aspose.Html.IO | 3 |
| Aspose.Html.Dom | 2 |
| System.Threading.Tasks | 2 |
| Aspose.Html.Rendering.Pdf | 2 |
| System.Text.Json | 1 |
| Aspose.Html.Rendering.Doc | 1 |
| Aspose.Html.Rendering.Pdf.Encryption | 1 |
| Aspose.Html.Dom.Svg | 1 |
| Aspose.Html.Dom.Svg.Saving | 1 |
| System.Linq | 1 |
| Aspose.Html.Rendering | 1 |

### How to import them

```csharp
using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;

using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Drawing;
using Aspose.Html.IO;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Dom.Svg.Saving;
```

## Common Code Pattern

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MarkdownConversionDemo
{
    static void Main()
    {
        // 1️⃣ Load Markdown (from file, string or stream)
        string markdownPath = @"C:\Docs\sample.md";
        string markdown = File.ReadAllText(markdownPath);

        // 2️⃣ Convert Markdown → HTMLDocument
        HTMLDocument htmlDoc = Converter.ConvertMarkdown(markdown);

        // 3️⃣ (Optional) Bind resources – e.g., add CSS or images
        // htmlDoc.Body.AppendChild(...);

        // 4️⃣ Render to the desired format – here we create a PNG image
        var imgOptions = new ImageSaveOptions(ImageFormat.Png)
        {
            // Example of a common setting
            ImageQuality = 90,
            DpiX = 300,
            DpiY = 300
        };

        string outputPath = Path.ChangeExtension(markdownPath, ".png");
        htmlDoc.Save(outputPath, imgOptions);

        Console.WriteLine($"Markdown converted to PNG: {outputPath}");
    }
}
```

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Aspose.Html | 78 |
| Console.WriteLine | 76 |
| Converter.ConvertHTML | 55 |
| Converter.ConvertMarkdown | 52 |
| System.IO | 39 |
| ImageSaveOptions | 30 |
| Rendering.Image | 24 |
| Path.Combine | 14 |
| XpsSaveOptions | 13 |
| File.WriteAllText | 12 |
| HTMLDocument | 10 |
| Directory.CreateDirectory | 10 |
| MemoryStream | 10 |
| System.Text | 9 |
| ImageFormat.Jpeg | 9 |
| PdfSaveOptions | 8 |
| Directory.GetFiles | 8 |
| Converters.Converter | 8 |
| Encoding.UTF8 | 8 |
| DocSaveOptions | 7 |

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [Add Command Line Option Specify Custom Pdf Save Options Json File Overriding Default Pdf Conversion Settings](./add_command_line_option_specify_custom_pdf_save_options_json_file_overriding_default_pdf_conversion_settings.cs) | Add Command Line Option Specify Custom Pdf Save Options Json File Overriding Default Pdf Conversion Settings | VerticalResolution.Value, System.Drawing, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Add Configuration Flag Enable Disable Intermediate Html File Generation Conversion Pipelines](./add_configuration_flag_enable_disable_intermediate_html_file_generation_conversion_pipelines.cs) | Add Configuration Flag Enable Disable Intermediate Html File Generation Conversion Pipelines | Converter.ConvertMarkdown, Console.WriteLine, PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Add Support For Converting Markdown Files In Subfolders By Recursively Scanning Directories During Batch Processing](./add_support_for_converting_markdown_files_in_subfolders_by_recursively_scanning_directories_during_batch_processing.cs) | Add Support For Converting Markdown Files In Subfolders By Recursively Scanning Directories During Batch Processing | Path.GetRelativePath, Converter.ConvertMarkdown, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Apply Custom Color Palette In Imagesaveoptions When Converting Markdown To Gif](./apply_custom_color_palette_in_imagesaveoptions_when_converting_markdown_to_gif.cs) | Apply Custom Color Palette In Imagesaveoptions When Converting Markdown To Gif | Rendering.Image, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Apply Custom Pdf Metadata Author Title Using Pdfsaveoptions Before Conversion](./apply_custom_pdf_metadata_author_title_using_pdfsaveoptions_before_conversion.cs) | Apply Custom Pdf Metadata Author Title Using Pdfsaveoptions Before Conversion | DocumentInfo.Title, Converters.Converter, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Apply Custom Resolution Setting In Imagesaveoptions When Converting Markdown To Gif Images](./apply_custom_resolution_setting_in_imagesaveoptions_when_converting_markdown_to_gif_images.cs) | Apply Custom Resolution Setting In Imagesaveoptions When Converting Markdown To Gif Images | Rendering.Image, Converters.Converter, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Apply Imagesaveoptions Specify Background Color When Converting Markdown To Bmp Image](./apply_imagesaveoptions_specify_background_color_when_converting_markdown_to_bmp_image.cs) | Apply Imagesaveoptions Specify Background Color When Converting Markdown To Bmp Image | ImageFormat.Bmp, Converter.ConvertMarkdown, System.Drawing | Converts HTML content to another format using Aspose.HTML. |
| [Batch Conversion Markdown Files To Docx Individual Docsaveoptions Per File](./batch_conversion_markdown_files_to_docx_individual_docsaveoptions_per_file.cs) | Batch Conversion Markdown Files To Docx Individual Docsaveoptions Per File | DocSaveOptions, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Batch Conversion Of All Markdown Files In Folder To Pdf Using Foreach Loop](./batch_conversion_of_all_markdown_files_in_folder_to_pdf_using_foreach_loop.cs) | Batch Conversion Of All Markdown Files In Folder To Pdf Using Foreach Loop | Converter.ConvertMarkdown, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Batch Convert All Markdown Files In Folder To Jpeg Images Uniform Quality Level](./batch_convert_all_markdown_files_in_folder_to_jpeg_images_uniform_quality_level.cs) | Batch Convert All Markdown Files In Folder To Jpeg Images Uniform Quality Level | Converter.ConvertMarkdown, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Batch Convert Markdown Files To Xps While Preserving Original File Timestamps In Output](./batch_convert_markdown_files_to_xps_while_preserving_original_file_timestamps_in_output.cs) | Batch Convert Markdown Files To Xps While Preserving Original File Timestamps In Output | File.SetCreationTime, Converters.Converter, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Batch Process Markdown Files Convert To Tiff Lossless Compression Enabled](./batch_process_markdown_files_convert_to_tiff_lossless_compression_enabled.cs) | Batch Process Markdown Files Convert To Tiff Lossless Compression Enabled | Converter.ConvertMarkdown, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Configure Docsaveoptions Embed Fonts Docx Output Consistent Rendering Across Platforms](./configure_docsaveoptions_embed_fonts_docx_output_consistent_rendering_across_platforms.cs) | Configure Docsaveoptions Embed Fonts Docx Output Consistent Rendering Across Platforms | DocSaveOptions, Rendering.Doc, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Configure Imagesaveoptions Jpeg Output Convert Html Document To Image](./configure_imagesaveoptions_jpeg_output_convert_html_document_to_image.cs) | Configure Imagesaveoptions Jpeg Output Convert Html Document To Image | Converters.Converter, Console.WriteLine, ImageFormat.Jpeg | Converts HTML content to another format using Aspose.HTML. |
| [Configure Pdf Encryption Password To Protect Generated Pdf From Unauthorized Access](./configure_pdf_encryption_password_to_protect_generated_pdf_from_unauthorized_access.cs) | Configure Pdf Encryption Password To Protect Generated Pdf From Unauthorized Access | HTMLDocument, PdfSaveOptions.Password, PdfEncryptionAlgorithm.RC4_128 | Converts HTML content to another format using Aspose.HTML. |
| [Convert Html Content To Svg Using Svgsaveoptions](./convert_html_content_to_svg_using_svgsaveoptions.cs) | Convert Html Content To Svg Using Svgsaveoptions | SVGSaveOptions, Console.WriteLine, SVGDocument | Creates or manipulates an HTML document. |
| [Convert Large Markdown To Bmp Using Streaming Avoid High Memory Consumption](./convert_large_markdown_to_bmp_using_streaming_avoid_high_memory_consumption.cs) | Convert Large Markdown To Bmp Using Streaming Avoid High Memory Consumption | ImageFormat.Bmp, Converter.ConvertMarkdown, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Convert Markdown Document To Html And Save Result To Memory Stream For Further Processing](./convert_markdown_document_to_html_and_save_result_to_memory_stream_for_further_processing.cs) | Convert Markdown Document To Html And Save Result To Memory Stream For Further Processing | StreamWriter, Encoding.UTF8, Converter.ConvertMarkdown | Creates or manipulates an HTML document. |
| [Convert Markdown Document With Code Blocks To Html Preserving Syntax Highlighting](./convert_markdown_document_with_code_blocks_to_html_preserving_syntax_highlighting.cs) | Convert Markdown Document With Code Blocks To Html Preserving Syntax Highlighting | Encoding.UTF8, Converter.ConvertMarkdown, Console.WriteLine | Creates or manipulates an HTML document. |
| [Convert Markdown Strings To Individual Png Files Parallel Processing](./convert_markdown_strings_to_individual_png_files_parallel_processing.cs) | Convert Markdown Strings To Individual Png Files Parallel Processing | System.Collections, File.WriteAllText, Parallel.ForEach | Converts HTML content to another format using Aspose.HTML. |
| [Convert Markdown String Directly To Html Using Argument](./convert_markdown_string_directly_to_html_using_argument.cs) | Convert Markdown String Directly To Html Using Argument | Encoding.UTF8, Converter.ConvertMarkdown, Console.WriteLine | Creates or manipulates an HTML document. |
| [Convert Markdown String To Html And Export As Tiff With Compression](./convert_markdown_string_to_html_and_export_as_tiff_with_compression.cs) | Convert Markdown String To Html And Export As Tiff With Compression | File.WriteAllText, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Convert Markdown To Docx With Page Size And Orientation Using Docsaveoptions Pagesetup](./convert_markdown_to_docx_with_page_size_and_orientation_using_docsaveoptions_pagesetup.cs) | Convert Markdown To Docx With Page Size And Orientation Using Docsaveoptions Pagesetup | DocSaveOptions, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Convert Markdown To Gif With Limited Animation Frame Rate Image Save Options](./convert_markdown_to_gif_with_limited_animation_frame_rate_image_save_options.cs) | Convert Markdown To Gif With Limited Animation Frame Rate Image Save Options | Rendering.Image, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Convert Markdown To Html And Render With Htmldocument Api To Bmp Image](./convert_markdown_to_html_and_render_with_htmldocument_api_to_bmp_image.cs) | Convert Markdown To Html And Render With Htmldocument Api To Bmp Image | File.WriteAllText, ImageFormat.Bmp, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Convert Markdown To Html Apply Css Styling Save Output Png Image](./convert_markdown_to_html_apply_css_styling_save_output_png_image.cs) | Convert Markdown To Html Apply Css Styling Save Output Png Image | Encoding.UTF8, Element.TextContent, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Convert Markdown To Png Transparent Background Configure Imagesaveoptions](./convert_markdown_to_png_transparent_background_configure_imagesaveoptions.cs) | Convert Markdown To Png Transparent Background Configure Imagesaveoptions | Converter.ConvertMarkdown, System.Drawing, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Create Command Line Tool Accepts Input Markdown Path Output Format Arguments Conversion](./create_command_line_tool_accepts_input_markdown_path_output_format_arguments_conversion.cs) | Create Command Line Tool Accepts Input Markdown Path Output Format Arguments Conversion | DocSaveOptions, ImageFormat.Bmp, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Create Console Application Watching Directory Converts New Markdown To Jpeg Automatically](./create_console_application_watching_directory_converts_new_markdown_to_jpeg_automatically.cs) | Create Console Application Watching Directory Converts New Markdown To Jpeg Automatically | Converter.ConvertHTML, Path.GetFileNameWithoutExtension, FileSystemWatcher | Converts HTML content to another format using Aspose.HTML. |
| [Create Png Image From Markdown Using Imagesaveoptions Default Compression](./create_png_image_from_markdown_using_imagesaveoptions_default_compression.cs) | Create Png Image From Markdown Using Imagesaveoptions Default Compression | Converter.ConvertMarkdown, Console.WriteLine, ImageFormat.Png | Converts HTML content to another format using Aspose.HTML. |
| [Create Powershell Script Iterates Markdown Files Converts Each Tiff Image](./create_powershell_script_iterates_markdown_files_converts_each_tiff_image.cs) | Create Powershell Script Iterates Markdown Files Converts Each Tiff Image | Converter.ConvertMarkdown, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Create Reusable Configuration Class Holds Default Pdf Save Options Doc Save Options Image Save Options](./create_reusable_configuration_class_holds_default_pdf_save_options_doc_save_options_image_save_options.cs) | Create Reusable Configuration Class Holds Default Pdf Save Options Doc Save Options Image Save Options | DocSaveOptions, FormFieldBehaviour.Flattened, DefaultSaveOptions.PdfOptions | Demonstrates a specific Aspose.HTML operation. |
| [Create Reusable Extension Method Wraps Convertmarkdown Returns Htmldocument For Further Processing](./create_reusable_extension_method_wraps_convertmarkdown_returns_htmldocument_for_further_processing.cs) | Create Reusable Extension Method Wraps Convertmarkdown Returns Htmldocument For Further Processing | Encoding.UTF8, Converter.ConvertMarkdown, Console.WriteLine | Creates or manipulates an HTML document. |
| [Create Reusable Method Accepts Markdown Path And Target Format Enum Returning Output File Path](./create_reusable_method_accepts_markdown_path_and_target_format_enum_returning_output_file_path.cs) | Create Reusable Method Accepts Markdown Path And Target Format Enum Returning Output File Path | Converters.Converter, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Create Unit Test Verifies Markdown Blockquote Conversion To Html Then To Png](./create_unit_test_verifies_markdown_blockquote_conversion_to_html_then_to_png.cs) | Create Unit Test Verifies Markdown Blockquote Conversion To Html Then To Png | File.WriteAllText, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Create Windows Service Convert Incoming Markdown Emails To Png Attachments Real Time](./create_windows_service_convert_incoming_markdown_emails_to_png_attachments_real_time.cs) | Create Windows Service Convert Incoming Markdown Emails To Png Attachments Real Time | Converter.ConvertMarkdown, Console.WriteLine, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Customize Font Embedding Settings In Xpssaveoptions While Converting Markdown To Xps](./customize_font_embedding_settings_in_xpssaveoptions_while_converting_markdown_to_xps.cs) | Customize Font Embedding Settings In Xpssaveoptions While Converting Markdown To Xps | XpsSaveOptions, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Dispose Html Document After Conversion Release Unmanaged Resources Avoid Memory Leaks](./dispose_html_document_after_conversion_release_unmanaged_resources_avoid_memory_leaks.cs) | Dispose Html Document After Conversion Release Unmanaged Resources Avoid Memory Leaks | System.Collections, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Ensure Png Images From Markdown Minimum 300 Dpi By Setting Image Save Options](./ensure_png_images_from_markdown_minimum_300_dpi_by_setting_image_save_options.cs) | Ensure Png Images From Markdown Minimum 300 Dpi By Setting Image Save Options | Converter.ConvertMarkdown, Console.WriteLine, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Ensure Temporary Html Files Deleted After Final Output Saved](./ensure_temporary_html_files_deleted_after_final_output_saved.cs) | Ensure Temporary Html Files Deleted After Final Output Saved | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Fine Tune Page Orientation Xps Save Options Converting Markdown Landscape Xps](./fine_tune_page_orientation_xps_save_options_converting_markdown_landscape_xps.cs) | Fine Tune Page Orientation Xps Save Options Converting Markdown Landscape Xps | Length.FromInches, XpsSaveOptions, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Generate High Quality Jpg Image From Markdown Jpegquality 100](./generate_high_quality_jpg_image_from_markdown_jpegquality_100.cs) | Generate High Quality Jpg Image From Markdown Jpegquality 100 | File.WriteAllText, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Generate Pdf Preview Converting Markdown Html Then Xps Document](./generate_pdf_preview_converting_markdown_html_then_xps_document.cs) | Generate Pdf Preview Converting Markdown Html Then Xps Document | File.WriteAllText, XpsSaveOptions, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Generate Xps File From Markdown And Embed Custom Metadata Via Xps Save Options](./generate_xps_file_from_markdown_and_embed_custom_metadata_via_xps_save_options.cs) | Generate Xps File From Markdown And Embed Custom Metadata Via Xps Save Options | File.WriteAllText, XpsSaveOptions, Color.LightGray | Converts HTML content to another format using Aspose.HTML. |
| [Implement Command Line Argument Parser Maps Short Flags Output Formats Conversion Utility](./implement_command_line_argument_parser_maps_short_flags_output_formats_conversion_utility.cs) | Implement Command Line Argument Parser Maps Short Flags Output Formats Conversion Utility | Converters.Converter, Console.WriteLine, Saving.PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Implement Command Line Tool Accepting Markdown File Path Outputting Html File](./implement_command_line_tool_accepting_markdown_file_path_outputting_html_file.cs) | Implement Command Line Tool Accepting Markdown File Path Outputting Html File | Converter.ConvertMarkdown, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Implement Error Handling For Missing Markdown Files During Batch Conversion To Jpeg Images](./implement_error_handling_for_missing_markdown_files_during_batch_conversion_to_jpeg_images.cs) | Implement Error Handling For Missing Markdown Files During Batch Conversion To Jpeg Images | FileNotFoundException, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Implement Real Time Conversion Markdown Jpeg Wpf Application Async Methods](./implement_real_time_conversion_markdown_jpeg_wpf_application_async_methods.cs) | Implement Real Time Conversion Markdown Jpeg Wpf Application Async Methods | File.WriteAllTextAsync, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Load Markdown File Convert To Html Embed Html Into Xps Document](./load_markdown_file_convert_to_html_embed_html_into_xps_document.cs) | Load Markdown File Convert To Html Embed Html Into Xps Document | XpsSaveOptions, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Load Markdown File From Disk Convert To Html Using Convertmarkdown](./load_markdown_file_from_disk_convert_to_html_using_convertmarkdown.cs) | Load Markdown File From Disk Convert To Html Using Convertmarkdown | Console.WriteLine, Aspose.Html, Converter.ConvertMarkdown | Demonstrates a specific Aspose.HTML operation. |
| [Load Markdown File From Local File System And Convert To Xps Document Using Default Settings](./load_markdown_file_from_local_file_system_and_convert_to_xps_document_using_default_settings.cs) | Load Markdown File From Local File System And Convert To Xps Document Using Default Settings | File.WriteAllText, XpsSaveOptions, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Load Markdown String Convert To Png Image With Custom Dpi Using Imagesaveoptions](./load_markdown_string_convert_to_png_image_with_custom_dpi_using_imagesaveoptions.cs) | Load Markdown String Convert To Png Image With Custom Dpi Using Imagesaveoptions | File.WriteAllText, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Load Multiple Markdown Documents List Merge Single Html Output File](./load_multiple_markdown_documents_list_merge_single_html_output_file.cs) | Load Multiple Markdown Documents List Merge Single Html Output File | Encoding.UTF8, Document.QuerySelector, Body.ChildNodes | Creates or manipulates an HTML document. |
| [Produce Xps Document From Markdown Using Xpssaveoptions Converthtml](./produce_xps_document_from_markdown_using_xpssaveoptions_converthtml.cs) | Produce Xps Document From Markdown Using Xpssaveoptions Converthtml | File.WriteAllText, XpsSaveOptions, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Real Time Conversion Markdown Stream To Png Without Intermediate Files](./real_time_conversion_markdown_stream_to_png_without_intermediate_files.cs) | Real Time Conversion Markdown Stream To Png Without Intermediate Files | System.Linq, System.Collections, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Save Resulting Html Document As Pdf With Pdf Save Options Convert Html](./save_resulting_html_document_as_pdf_with_pdf_save_options_convert_html.cs) | Save Resulting Html Document As Pdf With Pdf Save Options Convert Html | Console.WriteLine, PdfSaveOptions, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Set Background Color To White Avoid Transparent Backgrounds Jpg Images Generated Markdown](./set_background_color_to_white_avoid_transparent_backgrounds_jpg_images_generated_markdown.cs) | Set Background Color To White Avoid Transparent Backgrounds Jpg Images Generated Markdown | Converter.ConvertMarkdown, System.Drawing, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Set Compression Level In Imagesaveoptions When Converting Markdown To Png For Web Optimization](./set_compression_level_in_imagesaveoptions_when_converting_markdown_to_png_for_web_optimization.cs) | Set Compression Level In Imagesaveoptions When Converting Markdown To Png For Web Optimization | Converter.ConvertMarkdown, Console.WriteLine, ImageFormat.Png | Converts HTML content to another format using Aspose.HTML. |
| [Set Docx Document Language Property Via Docsaveoptions Language To Support Localization After Conversion](./set_docx_document_language_property_via_docsaveoptions_language_to_support_localization_after_conversion.cs) | Set Docx Document Language Property Via Docsaveoptions Language To Support Localization After Conversion | DocSaveOptions, Console.WriteLine, Aspose.HTML | Demonstrates a specific Aspose.HTML operation. |
| [Set Docx Page Setup Track Revisions Using Docsaveoptions Trackrevisions Change Tracking](./set_docx_page_setup_track_revisions_using_docsaveoptions_trackrevisions_change_tracking.cs) | Set Docx Page Setup Track Revisions Using Docsaveoptions Trackrevisions Change Tracking | DocSaveOptions, DocSaveOptions.TrackRevisions, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Set Image Dpi To 150 In Image Save Options For Png Output Balance Quality File Size](./set_image_dpi_to_150_in_image_save_options_for_png_output_balance_quality_file_size.cs) | Set Image Dpi To 150 In Image Save Options For Png Output Balance Quality File Size | Console.WriteLine, Aspose.Html, Saving.ImageSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Set Image Quality Parameter In Imagesaveoptions While Converting Markdown To Jpeg High Fidelity](./set_image_quality_parameter_in_imagesaveoptions_while_converting_markdown_to_jpeg_high_fidelity.cs) | Set Image Quality Parameter In Imagesaveoptions While Converting Markdown To Jpeg High Fidelity | File.WriteAllText, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Set Image Save Options Image Format Svg Converting Markdown To Svg Ensure Correct Output Type](./set_image_save_options_image_format_svg_converting_markdown_to_svg_ensure_correct_output_type.cs) | Set Image Save Options Image Format Svg Converting Markdown To Svg Ensure Correct Output Type | WebUtility.HtmlEncode, Console.WriteLine, Aspose.HTML | Converts HTML content to another format using Aspose.HTML. |
| [Set Image Width And Height In Imagesaveoptions Converting Markdown To Png](./set_image_width_and_height_in_imagesaveoptions_converting_markdown_to_png.cs) | Set Image Width And Height In Imagesaveoptions Converting Markdown To Png | Converter.ConvertMarkdown, Console.WriteLine, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Set Pdf Page Margins Using Margin Top Margin Bottom Margin Left Margin Right Before Conversion](./set_pdf_page_margins_using_margin_top_margin_bottom_margin_left_margin_right_before_conversion.cs) | Set Pdf Page Margins Using Margin Top Margin Bottom Margin Left Margin Right Before Conversion | Console.WriteLine, PdfSaveOptions, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Use Aspose Html Converters Namespace Alias To Shorten Code References In Large Conversion Projects](./use_aspose_html_converters_namespace_alias_to_shorten_code_references_in_large_conversion_projects.cs) | Use Aspose Html Converters Namespace Alias To Shorten Code References In Large Conversion Projects | Console.WriteLine, Aspose.Html, Converter.ConvertMarkdown | Demonstrates a specific Aspose.HTML operation. |
| [Use Aspose Html Converters Namespace Exclusively Keep Conversion Code Concise Avoid Fully Qualified Type Names](./use_aspose_html_converters_namespace_exclusively_keep_conversion_code_concise_avoid_fully_qualified_type_names.cs) | Use Aspose Html Converters Namespace Exclusively Keep Conversion Code Concise Avoid Fully Qualified Type Names | Converter.ConvertHTML, Aspose.Html, XpsSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Use Imagesaveoptions Specify Color Depth Converting Markdown To Bmp](./use_imagesaveoptions_specify_color_depth_converting_markdown_to_bmp.cs) | Use Imagesaveoptions Specify Color Depth Converting Markdown To Bmp | File.WriteAllText, ImageFormat.Bmp, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Use Memorystream Convert Markdown String To Pdf Without Intermediate Files](./use_memorystream_convert_markdown_string_to_pdf_without_intermediate_files.cs) | Use Memorystream Convert Markdown String To Pdf Without Intermediate Files | System.Collections, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Use Stringreader Feed Markdown Content Directly Into Converter Output Xps Document](./use_stringreader_feed_markdown_content_directly_into_converter_output_xps_document.cs) | Use Stringreader Feed Markdown Content Directly Into Converter Output Xps Document | Encoding.UTF8, XpsSaveOptions, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Use Try Finally Block To Guarantee Html Document Disposal Even When Exception Occurs During Conversion](./use_try_finally_block_to_guarantee_html_document_disposal_even_when_exception_occurs_during_conversion.cs) | Use Try Finally Block To Guarantee Html Document Disposal Even When Exception Occurs During Conversion | XpsSaveOptions, Console.WriteLine, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Use Xpssaveoptions Embed Custom Font Family During Markdown To Xps Conversion](./use_xpssaveoptions_embed_custom_font_family_during_markdown_to_xps_conversion.cs) | Use Xpssaveoptions Embed Custom Font Family During Markdown To Xps Conversion | XpsSaveOptions, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Use Xpssaveoptions Enable Document Outline Generation When Converting Markdown To Xps](./use_xpssaveoptions_enable_document_outline_generation_when_converting_markdown_to_xps.cs) | Use Xpssaveoptions Enable Document Outline Generation When Converting Markdown To Xps | XpsSaveOptions, Converter.ConvertMarkdown, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Use Xpssaveoptions Set Page Size Before Converting Markdown File To Xps Document](./use_xpssaveoptions_set_page_size_before_converting_markdown_file_to_xps_document.cs) | Use Xpssaveoptions Set Page Size Before Converting Markdown File To Xps Document | Length.FromInches, XpsSaveOptions, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Validate Generated Html File Reading Contents Checking Expected Heading Tags](./validate_generated_html_file_reading_contents_checking_expected_heading_tags.cs) | Validate Generated Html File Reading Contents Checking Expected Heading Tags | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Validate Intermediate Html Document Contains Expected Img Tags Before Converting To Image Formats](./validate_intermediate_html_document_contains_expected_img_tags_before_converting_to_image_formats.cs) | Validate Intermediate Html Document Contains Expected Img Tags Before Converting To Image Formats | HTMLDocument, Console.WriteLine, ImageFormat.Jpeg | Converts HTML content to another format using Aspose.HTML. |
| [Verify Pdf Output Correct Number Of Pages By Opening File With Pdf Reader Library](./verify_pdf_output_correct_number_of_pages_by_opening_file_with_pdf_reader_library.cs) | Verify Pdf Output Correct Number Of Pages By Opening File With Pdf Reader Library | PdfRenderingOptions, Console.WriteLine, Rendering.Pdf | Creates or manipulates an HTML document. |
| [Write Utility Reads Markdown From Stream Writes Html Output To Another Stream](./write_utility_reads_markdown_from_stream_writes_html_output_to_another_stream.cs) | Write Utility Reads Markdown From Stream Writes Html Output To Another Stream | StreamWriter, Encoding.UTF8, Converter.ConvertMarkdown | Creates or manipulates an HTML document. |

## Category-Specific Tips

### Key API Surface
- `Converter.ConvertMarkdown` – primary entry point for Markdown → HTML.  
- `Converter.ConvertHTML` – renders HTML to the final format.  
- `ImageSaveOptions`, `PdfSaveOptions`, `DocSaveOptions`, `XpsSaveOptions` – configure output specifics (resolution, compression, metadata, encryption).  
- `HTMLDocument` – intermediate representation; dispose when done.  
- `Console.WriteLine` – standard logging for examples.

### Rules
1. **Always dispose** `HTMLDocument` (or wrap in `using`) to free unmanaged resources.  
2. **Prefer streaming** (`MemoryStream`, `StringReader`) for large files to keep memory footprint low.  
3. **Set explicit DPI/Quality** in `ImageSaveOptions` when raster output quality matters.  
4. **Validate intermediate HTML** (e.g., check `<img>` tags) before image conversion to avoid silent failures.  
5. **Use consistent namespace imports** – keep the `using Aspose.Html.Converters;` alias if the project is large.  
6. **Handle file‑system errors** (`FileNotFoundException`, path permissions) early and log them.  
7. **When batch processing**, preserve original timestamps if required (`File.SetCreationTime`).  

## Warnings

- **Template/Data Mismatch** – binding data that does not exist in the Markdown template will produce empty placeholders.  
- **Missing Resources** – external CSS, images, or fonts referenced in Markdown must be reachable; otherwise rendering may fall back to defaults.  
- **File Path Issues** – relative paths are resolved against the current working directory; use `Path.GetFullPath` for reliability.  
- **Memory Pressure** – converting many large Markdown files to high‑resolution images can exhaust memory; use streaming or process files sequentially.  
- **Encryption Settings** – setting a password without also configuring the encryption algorithm may lead to unreadable PDFs on some viewers.  

## Guidelines for Adding New Examples

1. **Self‑contained** – the example must compile and run without external project references.  
2. **Console Logging** – use `Console.WriteLine` to report start, success, and error states.  
3. **Follow the Common Pattern** – load → convert → (optional) render → save.  
4. **Naming** – file name should be PascalCase, prefixed with the operation (e.g., `Convert_`, `Batch_`, `Configure_`).  
5. **Update Statistics** – after adding a file, increment `total_examples` and adjust namespace/API counts accordingly.  

---
