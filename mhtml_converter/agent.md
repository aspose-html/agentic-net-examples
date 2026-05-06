---
name: mhtml_converter
description: C# examples for mhtml_converter using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – mhtml_converter

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **mhtml_converter** category.
This folder contains standalone C# examples for mhtml_converter operations.
See the root [agent.md](../agent.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: `mhtml_converter`  
- **Total examples**: **107**  
- **Typical workflow**:  
  1. **Load** – read an MHTML file (or HTML source) from disk, a stream, or a network location.  
  2. **Bind** – (optional) inject data, set document options, or apply transformations before conversion.  
  3. **Convert** – call `Converter.ConvertMHTML` (or `Converter.ConvertHTML`) with the appropriate `SaveOptions` (e.g., `PdfSaveOptions`, `ImageSaveOptions`, `XpsSaveOptions`).  
  4. **Render / Save** – write the resulting file to the target location, optionally post‑process (e.g., add metadata, compress, encrypt).

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | Core .NET types (Console, DateTime, etc.) |
| Aspose.Html.Saving | Save‑option classes (PdfSaveOptions, ImageSaveOptions, etc.) |
| Aspose.Html.Converters | `Converter` class for all conversion operations |
| System.IO | File and stream handling |
| Aspose.Html.Rendering.Image | Image rendering pipeline |
| Aspose.Html | Root namespace for Aspose.HTML types |
| System.Collections.Generic | Generic collections used in helpers & tests |
| Aspose.Html.IO | Stream‑provider interfaces |
| System.Drawing | Image‑related structs (Color, ImageFormat) |
| System.Threading | Task‑based async patterns & cancellation |
| System.Diagnostics | Performance measurement (Stopwatch, etc.) |
| System.Threading.Tasks | `Task`‑based async helpers |
| System.Text.Json | JSON configuration handling |
| System.IO.Compression | ZIP archive creation for post‑conversion packaging |
| Aspose.Html.Drawing | Drawing utilities (if needed) |
| Aspose.Html.Rendering.Pdf.Encryption | PDF encryption algorithms |
| Aspose.Html.Rendering.Pdf | PDF rendering specifics |
| Aspose.Html.Loading | Loading options for HTML/MHTML |
| Aspose.Html.Net | .NET‑specific extensions |
| Aspose.Html.Services | Service registration (logging, etc.) |
| System.Net.Http | HTTP client for remote MHTML sources |
| System.Security.Cryptography | Cryptographic helpers (hashing) |
| System.Drawing.Imaging | Advanced image format settings |
| Aspose.Html.Rendering | General rendering services |

### How to import them

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using System.IO.Compression;
using System.Net.Http;
using System.Security.Cryptography;

using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Loading;
using Aspose.Html.IO;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Net;
using Aspose.Html.Services;
```

---

## Common Code Pattern

Below is a **realistic** skeleton that appears in most examples.  
It demonstrates loading an MHTML file, optional data binding, conversion, and saving the result.

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;   // for image output
using Aspose.Html.Rendering.Pdf;     // for PDF output

class Program
{
    static void Main()
    {
        // 1️⃣ Load the source MHTML file
        string sourcePath = @"C:\Input\sample.mhtml";
        using FileStream sourceStream = File.OpenRead(sourcePath);

        // 2️⃣ (Optional) Bind data or modify the document before conversion
        //    For example, change the title or inject CSS.
        //    This step is omitted when no binding is required.

        // 3️⃣ Choose the desired output format and configure save options
        //    Example: convert to PDF with default options
        var pdfOptions = new PdfSaveOptions();

        // 4️⃣ Perform the conversion
        string outputPath = Path.ChangeExtension(sourcePath, ".pdf");
        using FileStream outputStream = File.Create(outputPath);
        Converter.ConvertMHTML(sourceStream, outputStream, pdfOptions);

        // 5️⃣ Log the result
        Console.WriteLine($"Conversion completed: {outputPath}");
    }
}
```

*Replace `PdfSaveOptions` with `ImageSaveOptions`, `XpsSaveOptions`, `DocSaveOptions`, etc., depending on the target format.*

---

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Aspose.Html | 107 |
| Console.WriteLine | 106 |
| System.IO | 97 |
| File.OpenRead | 81 |
| Converter.ConvertMHTML | 76 |
| Rendering.Image | 42 |
| ImageSaveOptions | 41 |
| PdfSaveOptions | 31 |
| Path.Combine | 25 |
| ImageFormat.Jpeg | 18 |
| DocSaveOptions | 17 |
| XpsSaveOptions | 16 |
| ImageFormat.Png | 14 |
| Converter.ConvertHTML | 13 |
| Directory.CreateDirectory | 13 |
| System.Collections | 13 |
| Path.ChangeExtension | 12 |
| Aspose.HTML | 12 |
| ImageFormat.Bmp | 12 |
| MemoryStream | 11 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [apply_custom_color_profile_image_save_options_export_mhtml_to_png_color_critical_workflows.cs](./apply_custom_color_profile_image_save_options_export_mhtml_to_png_color_critical_workflows.cs) | Apply Custom Color Profile Image Save Options Export Mhtml To Png Color Critical Workflows | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [apply_password_protection_to_pdf_output_generated_from_mhtml_using_pdfsaveoptions_encryption.cs](./apply_password_protection_to_pdf_output_generated_from_mhtml_using_pdfsaveoptions_encryption.cs) | Apply Password Protection To Pdf Output Generated From Mhtml Using Pdfsaveoptions Encryption | PdfEncryptionAlgorithm.RC4_128, Converter.ConvertMHTML, Rendering.Pdf, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [auto_delete_source_mhtml_files_after_successful_pdf_conversion_save_space.cs](./auto_delete_source_mhtml_files_after_successful_pdf_conversion_save_space.cs) | Auto Delete Source Mhtml Files After Successful Pdf Conversion Save Space | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [batch_conversion_multiple_mhtml_files_to_pdf_using_foreach_loop_and_converter.cs](./batch_conversion_multiple_mhtml_files_to_pdf_using_foreach_loop_and_converter.cs) | Batch Conversion Multiple Mhtml Files To Pdf Using Foreach Loop And Converter | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [benchmark_conversion_time_mhtml_to_gif_using_different_quality_levels.cs](./benchmark_conversion_time_mhtml_to_gif_using_different_quality_levels.cs) | Benchmark Conversion Time Mhtml To Gif Using Different Quality Levels | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, System.Diagnostics | Demonstrates a specific Aspose.HTML operation. |
| [compress_resulting_pdf_using_third_party_library_after_mhtml_conversion.cs](./compress_resulting_pdf_using_third_party_library_after_mhtml_conversion.cs) | Compress Resulting Pdf Using Third Party Library After Mhtml Conversion | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, FileMode.Create | Demonstrates a specific Aspose.HTML operation. |
| [configure_color_depth_8bit_png_output_for_reduced_file_size.cs](./configure_color_depth_8bit_png_output_for_reduced_file_size.cs) | Configure Color Depth 8Bit Png Output For Reduced File Size | Console.WriteLine, Aspose.HTML, ImageFormat.Png, Converter.ConvertHTML, ImageSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [configure_docsaveoptions_enforce_openxml_strict_compliance_generating_docx_from_mhtml_enterprise_standards.cs](./configure_docsaveoptions_enforce_openxml_strict_compliance_generating_docx_from_mhtml_enterprise_standards.cs) | Configure Docsaveoptions Enforce Openxml Strict Compliance Generating Docx From Mhtml Enterprise Standards | DocSaveOptions, Console.WriteLine, Aspose.HTML, File.OpenRead, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_enable_progressive_rendering_jpeg_output_converting_large_mhtml_files.cs](./configure_imagesaveoptions_enable_progressive_rendering_jpeg_output_converting_large_mhtml_files.cs) | Configure Imagesaveoptions Enable Progressive Rendering Jpeg Output Converting Large Mhtml Files | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, ImageFormat.Jpeg | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_set_background_color_when_converting_mhtml_to_bmp.cs](./configure_imagesaveoptions_set_background_color_when_converting_mhtml_to_bmp.cs) | Configure Imagesaveoptions Set Background Color When Converting Mhtml To Bmp | ImageFormat.Bmp, System.Drawing, Converter.ConvertMHTML, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_set_background_transparency_png_output_source_mhtml_contains_transparent_elements.cs](./configure_imagesaveoptions_set_background_transparency_png_output_source_mhtml_contains_transparent_elements.cs) | Configure Imagesaveoptions Set Background Transparency Png Output Source Mhtml Contains Transparent Elements | System.Drawing, Converter.ConvertMHTML, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_set_compression_level_bmp_output_converting_mhtml_files.cs](./configure_imagesaveoptions_set_compression_level_bmp_output_converting_mhtml_files.cs) | Configure Imagesaveoptions Set Compression Level Bmp Output Converting Mhtml Files | ImageFormat.Bmp, Console.WriteLine, Aspose.HTML, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_set_jpeg_subsampling_factor_optimized_file_size_mhtml_conversion.cs](./configure_imagesaveoptions_set_jpeg_subsampling_factor_optimized_file_size_mhtml_conversion.cs) | Configure Imagesaveoptions Set Jpeg Subsampling Factor Optimized File Size Mhtml Conversion | Console.WriteLine, Aspose.HTML, File.OpenRead, Converter.ConvertMHTML | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_set_pixel_format_24bit_converting_mhtml_to_bmp_compatibility.cs](./configure_imagesaveoptions_set_pixel_format_24bit_converting_mhtml_to_bmp_compatibility.cs) | Configure Imagesaveoptions Set Pixel Format 24Bit Converting Mhtml To Bmp Compatibility | ImageFormat.Bmp, Converters.Converter, Console.WriteLine, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [configure_image_save_options_lossless_png_output_image_fidelity.cs](./configure_image_save_options_lossless_png_output_image_fidelity.cs) | Configure Image Save Options Lossless Png Output Image Fidelity | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [configure_pdfsaveoptions_disable_pdfa_compliance_converting_mhtml_pdf_output.cs](./configure_pdfsaveoptions_disable_pdfa_compliance_converting_mhtml_pdf_output.cs) | Configure Pdfsaveoptions Disable Pdfa Compliance Converting Mhtml Pdf Output | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [configure_pdfsaveoptions_embed_custom_javascript_action_opens_url_on_pdf_open.cs](./configure_pdfsaveoptions_embed_custom_javascript_action_opens_url_on_pdf_open.cs) | Configure Pdfsaveoptions Embed Custom Javascript Action Opens Url On Pdf Open | File.WriteAllText, Console.WriteLine, Aspose.HTML, PdfSaveOptions, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [configure_pdfsaveoptions_embed_fonts_set_document_permissions_before_converting_mhtml_to_pdf.cs](./configure_pdfsaveoptions_embed_fonts_set_document_permissions_before_converting_mhtml_to_pdf.cs) | Configure Pdfsaveoptions Embed Fonts Set Document Permissions Before Converting Mhtml To Pdf | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, PdfPermissions.Modify | Demonstrates a specific Aspose.HTML operation. |
| [configure_pdfsaveoptions_enable_fast_web_view_pdf_output_large_mhtml_documents.cs](./configure_pdfsaveoptions_enable_fast_web_view_pdf_output_large_mhtml_documents.cs) | Configure Pdfsaveoptions Enable Fast Web View Pdf Output Large Mhtml Documents | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [configure_pdfsaveoptions_flatten_form_fields_converting_mhtml_pdf_read_only_documents.cs](./configure_pdfsaveoptions_flatten_form_fields_converting_mhtml_pdf_read_only_documents.cs) | Configure Pdfsaveoptions Flatten Form Fields Converting Mhtml Pdf Read Only Documents | FormFieldBehaviour.Flattened, Console.WriteLine, Converter.ConvertMHTML, Rendering.Pdf, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [configure_pdfsaveoptions_set_custom_document_title_metadata_based_on_source_mhtml_filename.cs](./configure_pdfsaveoptions_set_custom_document_title_metadata_based_on_source_mhtml_filename.cs) | Configure Pdfsaveoptions Set Custom Document Title Metadata Based On Source Mhtml Filename | DocumentInfo.Title, Converters.Converter, Console.WriteLine, System.IO, Saving.PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [configure_pdfsaveoptions_set_custom_pdf_version_number_compatibility_older_readers.cs](./configure_pdfsaveoptions_set_custom_pdf_version_number_compatibility_older_readers.cs) | Configure Pdfsaveoptions Set Custom Pdf Version Number Compatibility Older Readers | Converters.Converter, Console.WriteLine, Aspose.HTML, PdfSaveOptions, Aspose.Html | Converts HTML content to another format using Aspose.HTML. |
| [configure_xps_save_options_enable_document_outline_generation_converting_mhtml_to_xps.cs](./configure_xps_save_options_enable_document_outline_generation_converting_mhtml_to_xps.cs) | Configure Xps Save Options Enable Document Outline Generation Converting Mhtml To Xps | XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [configure_xps_save_options_specific_printer_dpi_setting_mhtml_to_xps_conversion.cs](./configure_xps_save_options_specific_printer_dpi_setting_mhtml_to_xps_conversion.cs) | Configure Xps Save Options Specific Printer Dpi Setting Mhtml To Xps Conversion | XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_mhtml_file_to_xps_format_custom_page_dimensions_xpssaveoptions.cs](./convert_mhtml_file_to_xps_format_custom_page_dimensions_xpssaveoptions.cs) | Convert Mhtml File To Xps Format Custom Page Dimensions Xpssaveoptions | Length.FromInches, XpsSaveOptions, System.Drawing, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_mhtml_to_pdf_and_extract_text_using_pdf_parsing_library.cs](./convert_mhtml_to_pdf_and_extract_text_using_pdf_parsing_library.cs) | Convert Mhtml To Pdf And Extract Text Using Pdf Parsing Library | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, PdfSaveOptions, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_mhtml_to_pdf_and_merge_resulting_pdf_with_another_document_using_external_library.cs](./convert_mhtml_to_pdf_and_merge_resulting_pdf_with_another_document_using_external_library.cs) | Convert Mhtml To Pdf And Merge Resulting Pdf With Another Document Using External Library | PdfSharp.Pdf, Console.WriteLine, Converter.ConvertMHTML, FileMode.Create, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_mhtml_to_xps_extract_xps_package_contents_analysis.cs](./convert_mhtml_to_xps_extract_xps_package_contents_analysis.cs) | Convert Mhtml To Xps Extract Xps Package Contents Analysis | XpsSaveOptions, ZipFile.OpenRead, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_batch_script_processes_all_mhtml_files_in_directory_outputs_pdfs_with_timestamped_names.cs](./create_batch_script_processes_all_mhtml_files_in_directory_outputs_pdfs_with_timestamped_names.cs) | Create Batch Script Processes All Mhtml Files In Directory Outputs Pdfs With Timestamped Names | DateTime.Now, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_command_line_tool_accepts_input_mhtml_path_output_format_argument_conversion.cs](./create_command_line_tool_accepts_input_mhtml_path_output_format_argument_conversion.cs) | Create Command Line Tool Accepts Input Mhtml Path Output Format Argument Conversion | DocSaveOptions, XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [create_console_application_reads_mhtml_paths_from_text_file_and_converts_each_to_png.cs](./create_console_application_reads_mhtml_paths_from_text_file_and_converts_each_to_png.cs) | Create Console Application Reads Mhtml Paths From Text File And Converts Each To Png | File.ReadAllLines, Converter.ConvertMHTML, System.IO, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [create_docsaveoptions_instance_set_compatibility_mode_before_converting_mhtml_to_docx.cs](./create_docsaveoptions_instance_set_compatibility_mode_before_converting_mhtml_to_docx.cs) | Create Docsaveoptions Instance Set Compatibility Mode Before Converting Mhtml To Docx | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_function_accepts_stream_provider_returns_converted_image_size_bytes.cs](./create_function_accepts_stream_provider_returns_converted_image_size_bytes.cs) | Create Function Accepts Stream Provider Returns Converted Image Size Bytes | System.Collections, ImageFormat.Bmp, Stream.Length, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [create_helper_converts_mhtml_to_multiple_image_formats_returns_dictionary_of_format_to_stream_mappings.cs](./create_helper_converts_mhtml_to_multiple_image_formats_returns_dictionary_of_format_to_stream_mappings.cs) | Create Helper Converts Mhtml To Multiple Image Formats Returns Dictionary Of Format To Stream Mappings | File.ReadAllBytes, ImageFormat.Png, Path.GetTempPath, Key.ToUpper, Stream.Position | Demonstrates a specific Aspose.HTML operation. |
| [create_helper_validates_output_file_path_accessibility_before_mhtml_conversion_avoid_io_errors.cs](./create_helper_validates_output_file_path_accessibility_before_mhtml_conversion_avoid_io_errors.cs) | Create Helper Validates Output File Path Accessibility Before Mhtml Conversion Avoid Io Errors | FileMode.CreateNew, Path.GetRandomFileName, FileAccess.Write, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [create_jpeg_image_from_mhtml_using_compression_quality_image_save_options_configuration.cs](./create_jpeg_image_from_mhtml_using_compression_quality_image_save_options_configuration.cs) | Create Jpeg Image From Mhtml Using Compression Quality Image Save Options Configuration | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead, ImageFormat.Jpeg, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [create_method_return_mime_type_of_converted_output_based_on_selected_save_options.cs](./create_method_return_mime_type_of_converted_output_based_on_selected_save_options.cs) | Create Method Return Mime Type Of Converted Output Based On Selected Save Options | ImageFormat.Bmp, Console.WriteLine, ImageFormat.Png, PdfSaveOptions, ImageFormat.Jpeg | Demonstrates a specific Aspose.HTML operation. |
| [create_powershell_function_wraps_conversion_calls_returns_output_file_path_string.cs](./create_powershell_function_wraps_conversion_calls_returns_output_file_path_string.cs) | Create Powershell Function Wraps Conversion Calls Returns Output File Path String | Console.WriteLine, Aspose.HTML, Aspose.Html, Converter.ConvertMarkdown, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [create_powershell_module_wraps_dotnet_converter_methods_quick_mhtml_to_image_conversion.cs](./create_powershell_module_wraps_dotnet_converter_methods_quick_mhtml_to_image_conversion.cs) | Create Powershell Module Wraps Dotnet Converter Methods Quick Mhtml To Image Conversion | ImageFormat.Bmp, Console.WriteLine, Converter.ConvertMHTML, System.IO, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [create_reusable_class_abstracts_converter_calls_supported_mhtml_output_formats.cs](./create_reusable_class_abstracts_converter_calls_supported_mhtml_output_formats.cs) | Create Reusable Class Abstracts Converter Calls Supported Mhtml Output Formats | MhtmlConverterHelper.ConvertToImage, ImageFormat.Png, Path.GetFileNameWithoutExtension, Rendering.Image, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_reusable_configuration_file_storing_default_pdfsaveoptions_values_for_all_mhtml_conversions.cs](./create_reusable_configuration_file_storing_default_pdfsaveoptions_values_for_all_mhtml_conversions.cs) | Create Reusable Configuration File Storing Default Pdfsaveoptions Values For All Mhtml Conversions | Console.WriteLine, Converter.ConvertMHTML, Rendering.Pdf, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_reusable_extension_method_wraps_converter_convertmhtml_with_default_options_quick_usage.cs](./create_reusable_extension_method_wraps_converter_convertmhtml_with_default_options_quick_usage.cs) | Create Reusable Extension Method Wraps Converter Convertmhtml With Default Options Quick Usage | XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_unit_test_ensures_pdf_output_contains_expected_number_of_pages_after_conversion.cs](./create_unit_test_ensures_pdf_output_contains_expected_number_of_pages_after_conversion.cs) | Create Unit Test Ensures Pdf Output Contains Expected Number Of Pages After Conversion | File.WriteAllText, Console.WriteLine, System.IO, FileInfo, AppDomain.CurrentDomain | Converts HTML content to another format using Aspose.HTML. |
| [create_unit_test_verifies_docx_conversion_fails_gracefully_when_fonts_missing.cs](./create_unit_test_verifies_docx_conversion_fails_gracefully_when_fonts_missing.cs) | Create Unit Test Verifies Docx Conversion Fails Gracefully When Fonts Missing | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_unit_test_verifies_generated_tiff_file_contains_expected_number_of_pages.cs](./create_unit_test_verifies_generated_tiff_file_contains_expected_number_of_pages.cs) | Create Unit Test Verifies Generated Tiff File Contains Expected Number Of Pages | System.Collections, Console.WriteLine, Streams.Count, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [create_unit_test_verifies_imagesaveoptions_applies_jpeg_quality_level_during_conversion.cs](./create_unit_test_verifies_imagesaveoptions_applies_jpeg_quality_level_during_conversion.cs) | Create Unit Test Verifies Imagesaveoptions Applies Jpeg Quality Level During Conversion | File.WriteAllText, Console.WriteLine, System.IO, FileInfo, ImageFormat.Jpeg | Demonstrates a specific Aspose.HTML operation. |
| [develop_background_worker_processes_queue_mhtml_files_converts_each_to_pdf_asynchronously.cs](./develop_background_worker_processes_queue_mhtml_files_converts_each_to_pdf_asynchronously.cs) | Develop Background Worker Processes Queue Mhtml Files Converts Each To Pdf Asynchronously | System.Collections, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [develop_console_program_reads_conversion_parameters_from_json_and_processes_mhtml.cs](./develop_console_program_reads_conversion_parameters_from_json_and_processes_mhtml.cs) | Develop Console Program Reads Conversion Parameters From Json And Processes Mhtml | Console.WriteLine, System.IO, MHTMLSaveOptions, Converter.ConvertHTML, JsonSerializer.Deserialize | Converts HTML content to another format using Aspose.HTML. |
| [develop_console_utility_accepts_json_configuration_specifying_input_paths_and_desired_output_formats.cs](./develop_console_utility_accepts_json_configuration_specifying_input_paths_and_desired_output_formats.cs) | Develop Console Utility Accepts Json Configuration Specifying Input Paths And Desired Output Formats | TemplateData, StringComparison.OrdinalIgnoreCase, Converter.ConvertHTML, Path.GetTempPath, MarkdownSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [develop_gui_application_lets_users_select_mhtml_files_choose_output_format_dropdown.cs](./develop_gui_application_lets_users_select_mhtml_files_choose_output_format_dropdown.cs) | Develop Gui Application Lets Users Select Mhtml Files Choose Output Format Dropdown | DocSaveOptions, XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [develop_logging_interceptor_converter_method_entry_exit_timestamps_metrics.cs](./develop_logging_interceptor_converter_method_entry_exit_timestamps_metrics.cs) | Develop Logging Interceptor Converter Method Entry Exit Timestamps Metrics | System.Collections, XpsSaveOptions, DateTime.Now, Console.WriteLine, Streams.Count | Demonstrates a specific Aspose.HTML operation. |
| [develop_logging_provider_writes_conversion_details_to_console_and_rotating_log_file.cs](./develop_logging_provider_writes_conversion_details_to_console_and_rotating_log_file.cs) | Develop Logging Provider Writes Conversion Details To Console And Rotating Log File | Configuration, StreamWriter, HTMLDocument, LoggingMessageHandler, Service.MessageHandlers | Creates or manipulates an HTML document. |
| [develop_powershell_script_calls_dotnet_batch_convert_mhtml_files_to_docx.cs](./develop_powershell_script_calls_dotnet_batch_convert_mhtml_files_to_docx.cs) | Develop Powershell Script Calls Dotnet Batch Convert Mhtml Files To Docx | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [develop_retry_policy_using_polly_handles_transient_io_errors_during_mhtml_to_pdf_conversion.cs](./develop_retry_policy_using_polly_handles_transient_io_errors_during_mhtml_to_pdf_conversion.cs) | Develop Retry Policy Using Polly Handles Transient Io Errors During Mhtml To Pdf Conversion | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, Exception | Demonstrates a specific Aspose.HTML operation. |
| [develop_test_harness_measures_memory_usage_in_memory_mhtml_to_tiff_conversion.cs](./develop_test_harness_measures_memory_usage_in_memory_mhtml_to_tiff_conversion.cs) | Develop Test Harness Measures Memory Usage In Memory Mhtml To Tiff Conversion | Console.WriteLine, GC.GetTotalMemory, System.IO, File.OpenRead, Converter.ConvertMHTML | Demonstrates a specific Aspose.HTML operation. |
| [develop_test_measures_cpu_usage_bulk_conversion_mhtml_to_gif.cs](./develop_test_measures_cpu_usage_bulk_conversion_mhtml_to_gif.cs) | Develop Test Measures Cpu Usage Bulk Conversion Mhtml To Gif | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, Used.TotalSeconds | Demonstrates a specific Aspose.HTML operation. |
| [develop_utility_reads_mhtml_network_stream_saves_xps_temporary_folder.cs](./develop_utility_reads_mhtml_network_stream_saves_xps_temporary_folder.cs) | Develop Utility Reads Mhtml Network Stream Saves Xps Temporary Folder | FileMode.Create, System.Threading, Path.GetTempPath, Stream.Position, Generic.List | Demonstrates a specific Aspose.HTML operation. |
| [develop_windows_forms_app_display_preview_of_converted_image_before_saving_to_disk.cs](./develop_windows_forms_app_display_preview_of_converted_image_before_saving_to_disk.cs) | Develop Windows Forms App Display Preview Of Converted Image Before Saving To Disk | DocSaveOptions, XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [develop_windows_service_monitors_folder_new_mhtml_files_converts_to_pdf.cs](./develop_windows_service_monitors_folder_new_mhtml_files_converts_to_pdf.cs) | Develop Windows Service Monitors Folder New Mhtml Files Converts To Pdf | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [export_mhtml_to_gif_transparent_background_imagesaveoptions.cs](./export_mhtml_to_gif_transparent_background_imagesaveoptions.cs) | Export Mhtml To Gif Transparent Background Imagesaveoptions | System.Drawing, Aspose.HTML, System.IO, File.OpenRead, Color.Transparent | Demonstrates a specific Aspose.HTML operation. |
| [generate_bmp_file_from_mhtml_source_preserving_color_depth_default_options.cs](./generate_bmp_file_from_mhtml_source_preserving_color_depth_default_options.cs) | Generate Bmp File From Mhtml Source Preserving Color Depth Default Options | ImageFormat.Bmp, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [generate_multi_page_tiff_from_single_mhtml_file_setting_multipage_flag.cs](./generate_multi_page_tiff_from_single_mhtml_file_setting_multipage_flag.cs) | Generate Multi Page Tiff From Single Mhtml File Setting Multipage Flag | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [helper_converts_mhtml_to_multiple_image_formats_single_pass_parallel_tasks.cs](./helper_converts_mhtml_to_multiple_image_formats_single_pass_parallel_tasks.cs) | Helper Converts Mhtml To Multiple Image Formats Single Pass Parallel Tasks | ImageFormat.Bmp, Converters.Converter, File.ReadAllBytes, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [implement_asynchronous_conversion_of_mhtml_to_pdf_using_task_run_and_converter_convertmhtml_method.cs](./implement_asynchronous_conversion_of_mhtml_to_pdf_using_task_run_and_converter_convertmhtml_method.cs) | Implement Asynchronous Conversion Of Mhtml To Pdf Using Task Run And Converter Convertmhtml Method | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, System.Threading | Demonstrates a specific Aspose.HTML operation. |
| [implement_cancellation_token_abort_mhtml_to_xps_conversion_on_user_termination.cs](./implement_cancellation_token_abort_mhtml_to_xps_conversion_on_user_termination.cs) | Implement Cancellation Token Abort Mhtml To Xps Conversion On User Termination | System.Collections, XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [implement_error_handling_catches_conversion_exceptions_logs_file_path_failed_mhtml.cs](./implement_error_handling_catches_conversion_exceptions_logs_file_path_failed_mhtml.cs) | Implement Error Handling Catches Conversion Exceptions Logs File Path Failed Mhtml | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [implement_feature_allows_users_specify_image_dpi_in_imagesaveoptions_for_png_output.cs](./implement_feature_allows_users_specify_image_dpi_in_imagesaveoptions_for_png_output.cs) | Implement Feature Allows Users Specify Image Dpi In Imagesaveoptions For Png Output | Console.WriteLine, Aspose.Html, Saving.ImageSaveOptions, Converters.Converter, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [implement_feature_logs_sha256_hash_converted_file_integrity_verification.cs](./implement_feature_logs_sha256_hash_converted_file_integrity_verification.cs) | Implement Feature Logs Sha256 Hash Converted File Integrity Verification | DocSaveOptions, File.ReadAllBytes, Console.WriteLine, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [implement_feature_users_select_multiple_mhtml_files_convert_single_pdf_document.cs](./implement_feature_users_select_multiple_mhtml_files_convert_single_pdf_document.cs) | Implement Feature Users Select Multiple Mhtml Files Convert Single Pdf Document | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, Saving.PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [implement_feature_validates_converted_pdf_not_password_protected_unless_explicitly_set.cs](./implement_feature_validates_converted_pdf_not_password_protected_unless_explicitly_set.cs) | Implement Feature Validates Converted Pdf Not Password Protected Unless Explicitly Set | Converter.ConvertHTML, Aspose.Html, PdfSaveOptions, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [implement_feature_writes_conversion_logs_to_json_file_for_downstream_processing.cs](./implement_feature_writes_conversion_logs_to_json_file_for_downstream_processing.cs) | Implement Feature Writes Conversion Logs To Json File For Downstream Processing | System.Collections, File.WriteAllText, XpsSaveOptions, Console.WriteLine, Streams.Count | Demonstrates a specific Aspose.HTML operation. |
| [implement_file_watcher_triggers_mhtml_to_gif_conversion_on_new_file_in_directory.cs](./implement_file_watcher_triggers_mhtml_to_gif_conversion_on_new_file_in_directory.cs) | Implement File Watcher Triggers Mhtml To Gif Conversion On New File In Directory | FileSystemWatcher, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [implement_logging_conversion_parameters_such_as_output_format_save_options_audit_trails.cs](./implement_logging_conversion_parameters_such_as_output_format_save_options_audit_trails.cs) | Implement Logging Conversion Parameters Such As Output Format Save Options Audit Trails | Console.WriteLine, System.IO, PdfSaveOptions, Converter.ConvertHTML, Path.GetFullPath | Converts HTML content to another format using Aspose.HTML. |
| [implement_method_returns_stream_converted_jpeg_image_for_further_processing.cs](./implement_method_returns_stream_converted_jpeg_image_for_further_processing.cs) | Implement Method Returns Stream Converted Jpeg Image For Further Processing | System.Collections, Console.WriteLine, Streams.Count, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [implement_method_return_dictionary_mapping_supported_output_format_to_conversion_success_flag.cs](./implement_method_return_dictionary_mapping_supported_output_format_to_conversion_success_flag.cs) | Implement Method Return Dictionary Mapping Supported Output Format To Conversion Success Flag | ImageFormat.Png, Path.GetTempPath, ImageFormat.Gif, StringComparer.OrdinalIgnoreCase, ArgumentException | Demonstrates a specific Aspose.HTML operation. |
| [implement_progress_reporter_updates_ui_converting_mhtml_files_to_pdf.cs](./implement_progress_reporter_updates_ui_converting_mhtml_files_to_pdf.cs) | Implement Progress Reporter Updates Ui Converting Mhtml Files To Pdf | Console.WriteLine, Converter.ConvertMHTML, System.IO, Files.Length, Path.GetFileName | Demonstrates a specific Aspose.HTML operation. |
| [implement_retry_loop_mhtml_to_png_conversion_up_to_five_times_incremental_delays.cs](./implement_retry_loop_mhtml_to_png_conversion_up_to_five_times_incremental_delays.cs) | Implement Retry Loop Mhtml To Png Conversion Up To Five Times Incremental Delays | Converters.Converter, Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [implement_retry_mechanism_attempts_mhtml_to_xps_conversion_up_to_three_times_on_failure.cs](./implement_retry_mechanism_attempts_mhtml_to_xps_conversion_up_to_three_times_on_failure.cs) | Implement Retry Mechanism Attempts Mhtml To Xps Conversion Up To Three Times On Failure | XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [integrate_mhtml_docx_conversion_aspnet_mvc_controller_download.cs](./integrate_mhtml_docx_conversion_aspnet_mvc_controller_download.cs) | Integrate Mhtml Docx Conversion Aspnet Mvc Controller Download | DocSaveOptions, File.ReadAllBytes, Console.WriteLine, Guid.NewGuid, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [load_mhtml_file_from_disk_and_convert_to_pdf_using_default_settings.cs](./load_mhtml_file_from_disk_and_convert_to_pdf_using_default_settings.cs) | Load Mhtml File From Disk And Convert To Pdf Using Default Settings | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [log_conversion_duration_output_file_path_using_structured_logger_after_each_mhtml_conversion.cs](./log_conversion_duration_output_file_path_using_structured_logger_after_each_mhtml_conversion.cs) | Log Conversion Duration Output File Path Using Structured Logger After Each Mhtml Conversion | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, Path.GetFileName | Demonstrates a specific Aspose.HTML operation. |
| [log_source_mhtml_file_size_before_conversion_performance_analysis.cs](./log_source_mhtml_file_size_before_conversion_performance_analysis.cs) | Log Source Mhtml File Size Before Conversion Performance Analysis | XpsSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [produce_tiff_image_from_mhtml_with_lzw_compression.cs](./produce_tiff_image_from_mhtml_with_lzw_compression.cs) | Produce Tiff Image From Mhtml With Lzw Compression | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [read_mhtml_stream_generate_docx_docsaveoptions_metadata.cs](./read_mhtml_stream_generate_docx_docsaveoptions_metadata.cs) | Read Mhtml Stream Generate Docx Docsaveoptions Metadata | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [script_archives_converted_docx_files_to_zip_after_successful_mhtml_conversion.cs](./script_archives_converted_docx_files_to_zip_after_successful_mhtml_conversion.cs) | Script Archives Converted Docx Files To Zip After Successful Mhtml Conversion | Converters.Converter, Console.WriteLine, System.IO, File.OpenRead, FileMode.Create | Demonstrates a specific Aspose.HTML operation. |
| [script_archives_original_mhtml_files_after_successful_conversion_to_docx.cs](./script_archives_original_mhtml_files_after_successful_conversion_to_docx.cs) | Script Archives Original Mhtml Files After Successful Conversion To Docx | DocSaveOptions, File.Move, Console.WriteLine, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [set_custom_margins_and_page_size_in_pdfsaveoptions_while_converting_mhtml_to_pdf_for_printing.cs](./set_custom_margins_and_page_size_in_pdfsaveoptions_while_converting_mhtml_to_pdf_for_printing.cs) | Set Custom Margins And Page Size In Pdfsaveoptions While Converting Mhtml To Pdf For Printing | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [set_preserve_exif_metadata_during_mhtml_to_jpeg_conversion.cs](./set_preserve_exif_metadata_during_mhtml_to_jpeg_conversion.cs) | Set Preserve Exif Metadata During Mhtml To Jpeg Conversion | Console.WriteLine, Aspose.HTML, System.IO, File.OpenRead, Converter.ConvertMHTML | Demonstrates a specific Aspose.HTML operation. |
| [transform_mhtml_content_to_high_resolution_png_using_image_save_options_dpi_settings.cs](./transform_mhtml_content_to_high_resolution_png_using_image_save_options_dpi_settings.cs) | Transform Mhtml Content To High Resolution Png Using Image Save Options Dpi Settings | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [unit_test_conversion_to_docx_preserves_paragraph_spacing_original_mhtml.cs](./unit_test_conversion_to_docx_preserves_paragraph_spacing_original_mhtml.cs) | Unit Test Conversion To Docx Preserves Paragraph Spacing Original Mhtml | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [unit_test_verifies_conversion_fails_gracefully_with_invalid_source_mhtml_file_path.cs](./unit_test_verifies_conversion_fails_gracefully_with_invalid_source_mhtml_file_path.cs) | Unit Test Verifies Conversion Fails Gracefully With Invalid Source Mhtml File Path | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [unit_test_verify_image_dimensions_match_expected_after_mhtml_to_bmp_conversion.cs](./unit_test_verify_image_dimensions_match_expected_after_mhtml_to_bmp_conversion.cs) | Unit Test Verify Image Dimensions Match Expected After Mhtml To Bmp Conversion | ImageFormat.Bmp, Image.FromFile, System.Drawing, Converter.ConvertMHTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [use_docsaveoptions_set_default_font_fallback_converting_mhtml_unsupported_fonts_to_docx.cs](./use_docsaveoptions_set_default_font_fallback_converting_mhtml_unsupported_fonts_to_docx.cs) | Use Docsaveoptions Set Default Font Fallback Converting Mhtml Unsupported Fonts To Docx | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [use_docsaveoptions_set_document_language_property_converting_mhtml_to_docx_localization.cs](./use_docsaveoptions_set_document_language_property_converting_mhtml_to_docx_localization.cs) | Use Docsaveoptions Set Document Language Property Converting Mhtml To Docx Localization | DocSaveOptions, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [use_icreatestreamprovider_write_converted_jpeg_data_directly_cloud_storage_stream.cs](./use_icreatestreamprovider_write_converted_jpeg_data_directly_cloud_storage_stream.cs) | Use Icreatestreamprovider Write Converted Jpeg Data Directly Cloud Storage Stream | Image.CopyTo, System.Collections, SeekOrigin.Begin, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [use_pdfsaveoptions_embed_custom_icc_profile_color_management_mhtml_to_pdf_conversion.cs](./use_pdfsaveoptions_embed_custom_icc_profile_color_management_mhtml_to_pdf_conversion.cs) | Use Pdfsaveoptions Embed Custom Icc Profile Color Management Mhtml To Pdf Conversion | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, PdfSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [use_xpssaveoptions_define_document_author_title_metadata_converting_mhtml_xps.cs](./use_xpssaveoptions_define_document_author_title_metadata_converting_mhtml_xps.cs) | Use Xpssaveoptions Define Document Author Title Metadata Converting Mhtml Xps | XpsSaveOptions, Console.WriteLine, Aspose.HTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [validate_output_pdf_file_exists_and_size_exceeds_minimum_threshold_after_conversion.cs](./validate_output_pdf_file_exists_and_size_exceeds_minimum_threshold_after_conversion.cs) | Validate Output Pdf File Exists And Size Exceeds Minimum Threshold After Conversion | File.WriteAllText, Console.WriteLine, Aspose.HTML, System.IO, FileInfo | Converts HTML content to another format using Aspose.HTML. |
| [windows_service_retry_failed_mhtml_to_tiff_conversions_exponential_backoff.cs](./windows_service_retry_failed_mhtml_to_tiff_conversions_exponential_backoff.cs) | Windows Service Retry Failed Mhtml To Tiff Conversions Exponential Backoff | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, Exception | Demonstrates a specific Aspose.HTML operation. |
| [write_code_convert_mhtml_to_gif_and_create_animated_gif_sequence_from_multiple_pages.cs](./write_code_convert_mhtml_to_gif_and_create_animated_gif_sequence_from_multiple_pages.cs) | Write Code Convert Mhtml To Gif And Create Animated Gif Sequence From Multiple Pages | Encoder.SaveFlag, Image.FromFile, StringComparison.OrdinalIgnoreCase, Frame.Save, Path.GetTempFileName | Demonstrates a specific Aspose.HTML operation. |
| [write_code_convert_mhtml_to_pdf_and_embed_generated_cover_page_from_separate_html.cs](./write_code_convert_mhtml_to_pdf_and_embed_generated_cover_page_from_separate_html.cs) | Write Code Convert Mhtml To Pdf And Embed Generated Cover Page From Separate Html | Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead, PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [write_code_convert_pdf_add_digital_signature_using_external_library.cs](./write_code_convert_pdf_add_digital_signature_using_external_library.cs) | Write Code Convert Pdf Add Digital Signature Using External Library | Console.WriteLine, Aspose.Html, Saving.PdfSaveOptions, Converters.Converter, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [write_code_convert_pdf_split_into_individual_pages_using_pdf_library.cs](./write_code_convert_pdf_split_into_individual_pages_using_pdf_library.cs) | Write Code Convert Pdf Split Into Individual Pages Using Pdf Library | Console.WriteLine, Aspose.HTML, PdfSaveOptions, Converter.ConvertHTML, Aspose.Html | Converts HTML content to another format using Aspose.HTML. |
| [write_code_to_convert_pdf_and_add_table_of_contents_using_pdf_manipulation_library.cs](./write_code_to_convert_pdf_and_add_table_of_contents_using_pdf_manipulation_library.cs) | Write Code To Convert Pdf And Add Table Of Contents Using Pdf Manipulation Library | System.Collections, Generic.List, Console.WriteLine, System.IO, Provider.Streams | Converts HTML content to another format using Aspose.HTML. |
| [write_method_validates_mime_type_source_stream_before_mhtml_conversion.cs](./write_method_validates_mime_type_source_stream_before_mhtml_conversion.cs) | Write Method Validates Mime Type Source Stream Before Mhtml Conversion | SeekOrigin.Begin, Console.WriteLine, Converter.ConvertMHTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [write_unit_tests_verifying_mhtml_to_png_conversion_produces_image_with_expected_dimensions.cs](./write_unit_tests_verifying_mhtml_to_png_conversion_produces_image_with_expected_dimensions.cs) | Write Unit Tests Verifying Mhtml To Png Conversion Produces Image With Expected Dimensions | Image.FromFile, Path.GetTempPath, Saving.MHTMLSaveOptions, File.WriteAllText, File.OpenRead | Creates or manipulates an HTML document. |
| [write_wrapper_method_selects_appropriate_image_save_options_based_on_desired_output_image_format.cs](./write_wrapper_method_selects_appropriate_image_save_options_based_on_desired_output_image_format.cs) | Write Wrapper Method Selects Appropriate Image Save Options Based On Desired Output Image Format | ImageFormat.Bmp, Console.WriteLine, ImageFormat.Png, ImageFormat.Jpeg, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |

*All 107 examples are listed above.*

---

## Category‑Specific Tips

### Key API Surface
- **Conversion Core**: `Converter.ConvertMHTML`, `Converter.ConvertHTML`
- **Save Options**: `PdfSaveOptions`, `ImageSaveOptions`, `DocSaveOptions`, `XpsSaveOptions`
- **Image Formats**: `ImageFormat.Png`, `ImageFormat.Jpeg`, `ImageFormat.Bmp`, `ImageFormat.Gif`
- **File I/O**: `File.OpenRead`, `File.Create`, `Path.ChangeExtension`, `Directory.CreateDirectory`
- **Metadata & Security**: `PdfEncryptionAlgorithm`, `PdfPermissions`, `DocumentInfo.Title`, `PdfSaveOptions.EmbedIccProfile`
- **Performance / Diagnostics**: `Console.WriteLine`, `System.Diagnostics.Stopwatch`, `GC.GetTotalMemory`

### Rules
1. **Always dispose streams** – use `using` blocks for source and destination streams to avoid file‑handle leaks.  
2. **Match SaveOptions to output** – e.g., `PdfSaveOptions` for PDF, `ImageSaveOptions` for PNG/JPEG/GIF/TIFF.  
3. **Set explicit file extensions** – `Path.ChangeExtension(source, ".pdf")` prevents mismatched output.  
4. **Validate input existence** before conversion; log a clear error if the file is missing.  
5. **When binding data**, perform it on an `HTMLDocument` before calling the converter; the converter works on the final rendered DOM.  
6. **For large batches**, reuse a single `PdfSaveOptions`/`ImageSaveOptions` instance to reduce GC pressure.  
7. **Security** – if a PDF must be protected, configure `PdfEncryptionAlgorithm` and `PdfPermissions` **before** conversion.  
8. **Image DPI / Color Depth** – set `ImageSaveOptions.DpiX/DpiY` and `ImageSaveOptions.ColorDepth` for size‑critical scenarios.  
9. **Async conversions** – wrap `Converter.ConvertMHTML` in `Task.Run` and respect `CancellationToken` for UI responsiveness.  
10. **Post‑conversion verification** – check file size, page count, or image dimensions to ensure the conversion succeeded.

---

## Warnings

- **Template‑binding mismatches** – if placeholders in the MHTML are not replaced, the output may contain raw tokens. Always verify the binding step.  
- **Missing resources** – external CSS, images, or fonts referenced by the MHTML must be accessible; otherwise the rendered output will be incomplete.  
- **File‑path issues** – using relative paths without `Path.GetFullPath` can cause `FileNotFoundException` when the working directory changes.  
- **Memory pressure** – converting many large MHTML files to high‑resolution images in a single process can exhaust RAM; consider streaming or processing in batches.  
- **Thread‑safety** – `Converter` instances are **not** thread‑safe; create a new instance per thread or protect calls with a lock.  
- **PDF/A compliance** – enabling PDF/A without providing required metadata may cause the conversion to fail or produce non‑compliant files.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – the example must compile and run without external project references other than the listed namespaces.  
2. **Console logging** – start with `Console.WriteLine` to indicate the step being performed and the output path.  
3. **Follow the common pattern** – load → (optional bind) → configure `SaveOptions` → `Converter.Convert…` → save.  
4. **Naming** – file name should be **PascalCase** and start with the operation, e.g., `Convert_Mhtml_To_Pdf_With_Custom_Margins.cs`.  
5. **Update statistics** – after adding a file, increment `total_examples` and add the new namespace/API counts to the top‑level JSON (maintained by the repository).  
6. **Add to the table** – insert a new row in the **Files in this folder** table with a clickable link, a concise title, up to five key APIs, and a short description.  
7. **Unit test** – if the example introduces a new feature (e.g., a new `SaveOptions` property), add a corresponding unit test in the `Tests` folder following the existing naming convention.  

---