---
name: epub_converter
description: C# examples for epub_converter using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – epub_converter

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **epub_converter** category.
This folder contains standalone C# examples for epub_converter operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: `epub_converter`  
- **Total examples**: **143**  
- **Typical workflow**:  
  1. **Load** – Open the source EPUB file (usually via `File.OpenRead`).  
  2. **Bind / Configure** – Prepare conversion options (`ImageSaveOptions`, `PdfSaveOptions`, `DocSaveOptions`, etc.) and, when needed, bind data or CSS.  
  3. **Convert** – Call the appropriate static method on `Converter` (`ConvertEPUB`, `ConvertHTML`, etc.) to produce the target format (PDF, PNG, GIF, DOCX, BMP, TIFF, XPS, …).  
  4. **Render / Persist** – Write the result to a file, stream, or HTTP response, optionally logging progress or metadata.

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | 143 |
| Aspose.Html.Saving | 143 |
| Aspose.Html.Converters | 140 |
| System.IO | 137 |
| Aspose.Html.Rendering.Image | 98 |
| System.Collections.Generic | 37 |
| Aspose.Html.IO | 35 |
| Aspose.Html | 26 |
| Aspose.Html.Drawing | 16 |
| System.Threading.Tasks | 9 |
| Aspose.Html.Rendering | 8 |
| System.Drawing | 7 |
| System.IO.Compression | 5 |
| Aspose.Html.Services | 5 |
| System.Security.Cryptography | 4 |
| System.Diagnostics | 3 |
| System.Linq | 2 |
| System.Net.Sockets | 2 |
| System.Net.Http | 2 |
| System.Threading | 2 |
| System.Net | 1 |
| System.Net.WebSockets | 1 |
| System.Text | 1 |

### How to import them

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Services;
```

---

## Common Code Pattern

Below is a representative pattern that appears in many examples (loading an EPUB, configuring options, converting to PNG, and writing the result to disk).

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        // 1️⃣ Load the source EPUB file as a read‑only stream
        using (FileStream epubStream = File.OpenRead(@"C:\Input\sample.epub"))
        {
            // 2️⃣ Configure image‑specific save options (e.g., PNG, DPI, background)
            ImageSaveOptions saveOptions = new ImageSaveOptions(SaveFormat.Png)
            {
                DpiX = 300,
                DpiY = 300,
                BackgroundColor = System.Drawing.Color.White,
                // Optional: limit to a page range
                // PageSetup = new PageSetup { StartPage = 1, EndPage = 5 }
            };

            // 3️⃣ Convert the EPUB to a series of PNG images (one per page)
            // The method returns a collection of streams – each stream holds one page image
            var imageStreams = Converter.ConvertEPUB(epubStream, saveOptions);

            // 4️⃣ Persist each page image
            int pageIndex = 1;
            foreach (var stream in imageStreams)
            {
                string outPath = Path.Combine(@"C:\Output", $"page_{pageIndex}.png");
                using (FileStream outFile = File.Create(outPath))
                {
                    stream.CopyTo(outFile);
                }
                Console.WriteLine($"Page {pageIndex} saved to {outPath}");
                pageIndex++;
            }
        }

        Console.WriteLine("Conversion completed.");
    }
}
```

*Key points demonstrated*:

* Proper **using** statements for deterministic disposal of streams.  
* Centralised **ImageSaveOptions** to control DPI, background, and page range.  
* Iterating over the returned **IEnumerable\<Stream\>** to write each page individually.  
* Console logging for traceability.

---

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Aspose.Html | 143 |
| Console.WriteLine | 141 |
| System.IO | 139 |
| File.OpenRead | 131 |
| Converter.ConvertEPUB | 131 |
| ImageSaveOptions | 113 |
| Rendering.Image | 98 |
| ImageFormat.Gif | 38 |
| System.Collections | 37 |
| MemoryStream | 34 |
| Path.Combine | 33 |
| MemoryStreamProvider | 31 |
| Directory.CreateDirectory | 29 |
| Streams.Add | 25 |
| ImageFormat.Bmp | 21 |
| ImageFormat.Tiff | 20 |
| ImageFormat.Jpeg | 20 |
| Streams.Count | 18 |
| Stream.Position | 18 |
| PageSetup.AnyPage | 16 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [apply_uniform_dpi_setting_in_imagesaveoptions_to_ensure_consistent_resolution_across_all_gif_pages.cs](./apply_uniform_dpi_setting_in_imagesaveoptions_to_ensure_consistent_resolution_across_all_gif_pages.cs) | Apply Uniform Dpi Setting In Imagesaveoptions To Ensure Consistent Resolution Across All Gif Pages | HTMLDocument, Rendering.Image, Console.WriteLine, Converter.ConvertHTML, Page | Converts HTML content to another format using Aspose.HTML. |
| [batch_convert_epub_collection_to_tiff_files_foreach_loop_default_settings.cs](./batch_convert_epub_collection_to_tiff_files_foreach_loop_default_settings.cs) | Batch Convert Epub Collection To Tiff Files Foreach Loop Default Settings | Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB, Directory.GetFiles | Demonstrates a specific Aspose.HTML operation. |
| [batch_convert_epub_files_in_directory_to_jpeg_images_with_loop.cs](./batch_convert_epub_files_in_directory_to_jpeg_images_with_loop.cs) | Batch Convert Epub Files In Directory To Jpeg Images With Loop | Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg, Directory.GetFiles | Demonstrates a specific Aspose.HTML operation. |
| [batch_process_multiple_epub_files_to_png_images_by_programmatically_invoking_converter_convert_epub_for_each_entry.cs](./batch_process_multiple_epub_files_to_png_images_by_programmatically_invoking_converter_convert_epub_for_each_entry.cs) | Batch Process Multiple Epub Files To Png Images By Programmatically Invoking Converter Convert Epub For Each Entry | Console.WriteLine, System.IO, File.OpenRead, Directory.GetFiles, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [batch_transform_epub_documents_into_gif_animations_iterating_source_files_calling_converter_convertepub.cs](./batch_transform_epub_documents_into_gif_animations_iterating_source_files_calling_converter_convertepub.cs) | Batch Transform Epub Documents Into Gif Animations Iterating Source Files Calling Converter Convertepub | Console.WriteLine, System.IO, File.OpenRead, Directory.GetFiles, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_limit_gif_size_reducing_color_depth_epub_conversion.cs](./configure_imagesaveoptions_limit_gif_size_reducing_color_depth_epub_conversion.cs) | Configure Imagesaveoptions Limit Gif Size Reducing Color Depth Epub Conversion | Console.WriteLine, System.IO, File.OpenRead, Path.Combine, ImageFormat.Gif | Demonstrates a specific Aspose.HTML operation. |
| [configure_imagesaveoptions_transparent_background_epub_content_to_gif_images.cs](./configure_imagesaveoptions_transparent_background_epub_content_to_gif_images.cs) | Configure Imagesaveoptions Transparent Background Epub Content To Gif Images | System.Drawing, Console.WriteLine, System.IO, File.OpenRead, Color.Transparent | Demonstrates a specific Aspose.HTML operation. |
| [configure_image_save_options_embed_color_profiles_in_resulting_gif_for_accurate_color_representation.cs](./configure_image_save_options_embed_color_profiles_in_resulting_gif_for_accurate_color_representation.cs) | Configure Image Save Options Embed Color Profiles In Resulting Gif For Accurate Color Representation | HTMLDocument, Rendering.Image, Console.WriteLine, Converter.ConvertHTML, ImageSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [convert_drm_free_epub_to_png_handling_encryption_exceptions_conversion_process.cs](./convert_drm_free_epub_to_png_handling_encryption_exceptions_conversion_process.cs) | Convert Drm Free Epub To Png Handling Encryption Exceptions Conversion Process | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_each_page_of_epub_to_separate_jpeg_files_specifying_page_range.cs](./convert_each_page_of_epub_to_separate_jpeg_files_specifying_page_range.cs) | Convert Each Page Of Epub To Separate Jpeg Files Specifying Page Range | System.Collections, Console.WriteLine, System.IO, File.OpenRead, File.Create | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_chapter_to_gif_start_end_page_numbers_imagesaveoptions.cs](./convert_epub_chapter_to_gif_start_end_page_numbers_imagesaveoptions.cs) | Convert Epub Chapter To Gif Start End Page Numbers Imagesaveoptions | PageSetup.StartPage, Console.WriteLine, System.IO, File.OpenRead, PageSetup.EndPage | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_document_to_bmp_format_using_default_image_options.cs](./convert_epub_document_to_bmp_format_using_default_image_options.cs) | Convert Epub Document To Bmp Format Using Default Image Options | ImageFormat.Bmp, Console.WriteLine, Aspose.HTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_document_to_tiff_image_using_converter_convert_epub_no_custom_options.cs](./convert_epub_document_to_tiff_image_using_converter_convert_epub_no_custom_options.cs) | Convert Epub Document To Tiff Image Using Converter Convert Epub No Custom Options | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_files_directory_to_pdf_using_parallel_foreach_default_pdfsaveoptions.cs](./convert_epub_files_directory_to_pdf_using_parallel_foreach_default_pdfsaveoptions.cs) | Convert Epub Files Directory To Pdf Using Parallel Foreach Default Pdfsaveoptions | Parallel.ForEach, Console.WriteLine, System.IO, File.OpenRead, System.Threading | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_paths_to_docx_using_reusable_method_with_save_options.cs](./convert_epub_file_paths_to_docx_using_reusable_method_with_save_options.cs) | Convert Epub File Paths To Docx Using Reusable Method With Save Options | DocSaveOptions, Console.WriteLine, System.IO, File.OpenRead, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_docx_and_save_output_to_user_specified_directory.cs](./convert_epub_file_to_docx_and_save_output_to_user_specified_directory.cs) | Convert Epub File To Docx And Save Output To User Specified Directory | DocSaveOptions, Console.WriteLine, System.IO, Path.Combine, Path.GetFileNameWithoutExtension | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_docx_ensure_output_directory_exists_before_writing.cs](./convert_epub_file_to_docx_ensure_output_directory_exists_before_writing.cs) | Convert Epub File To Docx Ensure Output Directory Exists Before Writing | DocSaveOptions, Console.WriteLine, System.IO, Path.Combine, Directory.Exists | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_docx_preserving_original_document_styles_and_headings.cs](./convert_epub_file_to_docx_preserving_original_document_styles_and_headings.cs) | Convert Epub File To Docx Preserving Original Document Styles And Headings | DocSaveOptions, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_docx_using_default_conversion_settings.cs](./convert_epub_file_to_docx_using_default_conversion_settings.cs) | Convert Epub File To Docx Using Default Conversion Settings | DocSaveOptions, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_docx_using_filestream_read_only_access.cs](./convert_epub_file_to_docx_using_filestream_read_only_access.cs) | Convert Epub File To Docx Using Filestream Read Only Access | DocSaveOptions, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_gif_format_using_converter_convertepub_default_configuration.cs](./convert_epub_file_to_gif_format_using_converter_convertepub_default_configuration.cs) | Convert Epub File To Gif Format Using Converter Convertepub Default Configuration | Console.WriteLine, System.IO, File.OpenRead, Path.GetDirectoryName, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_jpeg_using_static_converter_convert_epub_method_default_settings.cs](./convert_epub_file_to_jpeg_using_static_converter_convert_epub_method_default_settings.cs) | Convert Epub File To Jpeg Using Static Converter Convert Epub Method Default Settings | Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_multiple_image_formats_single_pass_batch_processing_loop.cs](./convert_epub_file_to_multiple_image_formats_single_pass_batch_processing_loop.cs) | Convert Epub File To Multiple Image Formats Single Pass Batch Processing Loop | ImageFormat.Bmp, Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_pdf_ensure_output_directory_exists_before_writing.cs](./convert_epub_file_to_pdf_ensure_output_directory_exists_before_writing.cs) | Convert Epub File To Pdf Ensure Output Directory Exists Before Writing | Console.WriteLine, System.IO, PdfSaveOptions, Path.Combine, Directory.Exists | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_pdf_return_memorystream.cs](./convert_epub_file_to_pdf_return_memorystream.cs) | Convert Epub File To Pdf Return Memorystream | System.Collections, FileAccess.Write, Stream.Length, Console.WriteLine, Streams.Count | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_pdf_using_statements_ensure_filestream_resources_disposed.cs](./convert_epub_file_to_pdf_using_statements_ensure_filestream_resources_disposed.cs) | Convert Epub File To Pdf Using Statements Ensure Filestream Resources Disposed | System.Collections, FileAccess.Write, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_pdf_using_static_converter_convert_epub_method_with_default_options.cs](./convert_epub_file_to_pdf_using_static_converter_convert_epub_method_with_default_options.cs) | Convert Epub File To Pdf Using Static Converter Convert Epup Method With Default Options | Console.WriteLine, System.IO, File.OpenRead, PdfSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_file_to_xps_using_static_converter_method_default_options.cs](./convert_epub_file_to_xps_using_static_converter_method_default_options.cs) | Convert Epub File To Xps Using Static Converter Method Default Options | XpsSaveOptions, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_png_validate_output_comparing_calculated_hash_with_expected_value_stored_in_metadata.cs](./convert_epub_png_validate_output_comparing_calculated_hash_with_expected_value_stored_in_metadata.cs) | Convert Epub Png Validate Output Comparing Calculated Hash With Expected Value Stored In Metadata | Hash.ToLowerInvariant, Converters.Converter, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_adding_title_metadata_via_imagesaveoptions_preserve_document_information.cs](./convert_epub_to_bmp_adding_title_metadata_via_imagesaveoptions_preserve_document_information.cs) | Convert Epub To Bmp Adding Title Metadata Via Imagesaveoptions Preserve Document Information | ImageFormat.Bmp, Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_and_bundle_page_images_into_zip_using_system_io_compression_utilities.cs](./convert_epub_to_bmp_and_bundle_page_images_into_zip_using_system_io_compression_utilities.cs) | Convert Epub To Bmp And Bundle Page Images Into Zip Using System Io Compression Utilities | System.Collections, ImageFormat.Bmp, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_and_send_bitmap_data_over_network_stream_using_custom_response_handler.cs](./convert_epub_to_bmp_and_send_bitmap_data_over_network_stream_using_custom_response_handler.cs) | Convert Epub To Bmp And Send Bitmap Data Over Network Stream Using Custom Response Handler | Stream.Flush, Stream.Position, File.OpenRead, Stream.CopyTo, ImageFormat.Bmp | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_background_color_light_gray_improve_visual_contrast.cs](./convert_epub_to_bmp_background_color_light_gray_improve_visual_contrast.cs) | Convert Epub To Bmp Background Color Light Gray Improve Visual Contrast | ImageFormat.Bmp, Color.LightGray, System.Drawing, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_inject_custom_stylesheet_rules_via_imagesaveoptions_modify_page_appearance.cs](./convert_epub_to_bmp_inject_custom_stylesheet_rules_via_imagesaveoptions_modify_page_appearance.cs) | Convert Epub To Bmp Inject Custom Stylesheet Rules Via Imagesaveoptions Modify Page Appearance | Configuration, ImageFormat.Bmp, Css.MediaType, MediaType.Print, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_record_source_path_output_location_and_options_log.cs](./convert_epub_to_bmp_record_source_path_output_location_and_options_log.cs) | Convert Epub To Bmp Record Source Path Output Location And Options Log | File.WriteAllText, ImageFormat.Bmp, Converters.Converter, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_set_imagesaveoptions_pagesize_match_output_dimensions.cs](./convert_epub_to_bmp_set_imagesaveoptions_pagesize_match_output_dimensions.cs) | Convert Epub To Bmp Set Imagesaveoptions Pagesize Match Output Dimensions | ImageFormat.Bmp, Converters.Converter, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_store_image_bytes_in_memory_stream_via_provider.cs](./convert_epub_to_bmp_store_image_bytes_in_memory_stream_via_provider.cs) | Convert Epub To Bmp Store Image Bytes In Memory Stream Via Provider | System.Collections, ImageFormat.Bmp, Console.WriteLine, Streams.Count, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_using_css_media_type_screen_emulate_screen_display_styling_rendering.cs](./convert_epub_to_bmp_using_css_media_type_screen_emulate_screen_display_styling_rendering.cs) | Convert Epub To Bmp Using Css Media Type Screen Emulate Screen Display Styling Rendering | ImageFormat.Bmp, ImageSaveOptions.CssMediaType, Css.MediaType, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_using_filestream_save_image_explicit_resource_management.cs](./convert_epub_to_bmp_using_filestream_save_image_explicit_resource_management.cs) | Convert Epub To Bmp Using Filestream Save Image Explicit Resource Management | System.Collections, ImageFormat.Bmp, FileAccess.Write, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_using_imagesaveoptions_specify_200dpi_sharper_bitmap_images.cs](./convert_epub_to_bmp_using_imagesaveoptions_specify_200dpi_sharper_bitmap_images.cs) | Convert Epub To Bmp Using Imagesaveoptions Specify 200Dpi Sharper Bitmap Images | ImageFormat.Bmp, Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_using_static_converter_and_verify_bitmap_integrity.cs](./convert_epub_to_bmp_using_static_converter_and_verify_bitmap_integrity.cs) | Convert Epub To Bmp Using Static Converter And Verify Bitmap Integrity | ImageFormat.Bmp, System.Drawing, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_with_imagesaveoptions_compressionlevel_reduce_file_size_without_losing_detail.cs](./convert_epub_to_bmp_with_imagesaveoptions_compressionlevel_reduce_file_size_without_losing_detail.cs) | Convert Epub To Bmp With Imagesaveoptions Compressionlevel Reduce File Size Without Losing Detail | ImageFormat.Bmp, ImageSaveOptions.CompressionLevel, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_with_margins_10_pixels_all_sides.cs](./convert_epub_to_bmp_with_margins_10_pixels_all_sides.cs) | Convert Epub To Bmp With Margins 10 Pixels All Sides | ImageFormat.Bmp, Console.WriteLine, System.IO, File.OpenRead, Page | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_bmp_with_progress_logging_callback.cs](./convert_epub_to_bmp_with_progress_logging_callback.cs) | Convert Epub To Bmp With Progress Logging Callback | ImageFormat.Bmp, FileAccess.Write, LoggingStreamProvider, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_docx_using_filestream_create_new_mode.cs](./convert_epub_to_docx_using_filestream_create_new_mode.cs) | Convert Epub To Docx Using Filestream Create New Mode | DocSaveOptions, System.Collections, FileMode.CreateNew, FileAccess.Write, Stream.WriteTo | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_and_confirm_output_correctness_by_matching_hash_with_known_good_checksum.cs](./convert_epub_to_gif_and_confirm_output_correctness_by_matching_hash_with_known_good_checksum.cs) | Convert Epub To Gif And Confirm Output Correctness By Matching Hash With Known Good Checksum | Console.WriteLine, System.IO, File.OpenRead, Checksum.ToLowerInvariant, System.Security | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_append_conversion_results_file_size_duration_to_audit_log.cs](./convert_epub_to_gif_append_conversion_results_file_size_duration_to_audit_log.cs) | Convert Epub To Gif Append Conversion Results File Size Duration To Audit Log | File.AppendAllText, DateTime.Now, Console.WriteLine, Aspose.HTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_apply_pagesize_for_consistent_frame_sizes.cs](./convert_epub_to_gif_apply_pagesize_for_consistent_frame_sizes.cs) | Convert Epub To Gif Apply Pagesize For Consistent Frame Sizes | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions.PageSize, Page | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_extracting_animated_frames_default_settings.cs](./convert_epub_to_gif_extracting_animated_frames_default_settings.cs) | Convert Epub To Gif Extracting Animated Frames Default Settings | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_obtain_output_stream_via_icreatestreamprovider_in_memory.cs](./convert_epub_to_gif_obtain_output_stream_via_icreatestreamprovider_in_memory.cs) | Convert Epub To Gif Obtain Output Stream Via Icreatestreamprovider In Memory | System.Collections, Console.WriteLine, Streams.Count, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_recording_overall_conversion_statistics_output_to_console_monitoring.cs](./convert_epub_to_gif_recording_overall_conversion_statistics_output_to_console_monitoring.cs) | Convert Epub To Gif Recording Overall Conversion Statistics Output To Console Monitoring | Console.WriteLine, System.IO, File.OpenRead, FileInfo, Stopwatch.StartNew | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_set_background_color_black_dark_mode_compatible_animation.cs](./convert_epub_to_gif_set_background_color_black_dark_mode_compatible_animation.cs) | Convert Epub To Gif Set Background Color Black Dark Mode Compatible Animation | System.Drawing, Console.WriteLine, System.IO, File.OpenRead, Color.Black | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_stream_animated_via_httpresponse_immediate_client_consumption.cs](./convert_epub_to_gif_stream_animated_via_httpresponse_immediate_client_consumption.cs) | Convert Epub To Gif Stream Animated Via Httpresponse Immediate Client Consumption | System.Threading, Client.GetStreamAsync, Stream.Position, ImageFormat.Gif, Stream.Length | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_using_css_media_type_screen_to_reflect_screen_based_css_rules_during_rendering.cs](./convert_epub_to_gif_using_css_media_type_screen_to_reflect_screen_based_css_rules_during_rendering.cs) | Convert Epub To Gif Using Css Media Type Screen To Reflect Screen Based Css Rules During Rendering | ImageSaveOptions.CssMediaType, Css.MediaType, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_using_filestream_target_to_store_generated_animation_file_safely.cs](./convert_epub_to_gif_using_filestream_target_to_store_generated_animation_file_safely.cs) | Convert Epub To Gif Using Filestream Target To Store Generated Animation File Safely | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_gif_with_72_dpi_image_save_options_match_screen_resolution.cs](./convert_epub_to_gif_with_72_dpi_image_save_options_match_screen_resolution.cs) | Convert Epub To Gif With 72 Dpi Image Save Options Match Screen Resolution | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_and_compress_all_generated_images_into_single_zip_archive_for_distribution.cs](./convert_epub_to_jpeg_and_compress_all_generated_images_into_single_zip_archive_for_distribution.cs) | Convert Epub To Jpeg And Compress All Generated Images Into Single Zip Archive For Distribution | FileMode.Create, Streams.Count, File.OpenRead, FileStream, ZipArchive | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_and_embed_custom_exif_author_metadata_using_imagesaveoptions_before_saving.cs](./convert_epub_to_jpeg_and_embed_custom_exif_author_metadata_using_imagesaveoptions_before_saving.cs) | Convert Epub To Jpeg And Embed Custom Exif Author Metadata Using Imagesaveoptions Before Saving | Console.WriteLine, Aspose.HTML, System.IO, File.OpenRead, ImageFormat.Jpeg | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_apply_dark_mode_css_override.cs](./convert_epub_to_jpeg_apply_dark_mode_css_override.cs) | Convert Epub To Jpeg Apply Dark Mode Css Override | ImageSaveOptions.CssMediaType, Css.MediaType, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_asynchronously_avoid_blocking_calling_thread.cs](./convert_epub_to_jpeg_asynchronously_avoid_blocking_calling_thread.cs) | Convert Epub To Jpeg Asynchronously Avoid Blocking Calling Thread | Console.WriteLine, System.IO, File.OpenRead, System.Threading, Task.Run | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_compute_sha256_hash_of_output_to_verify_integrity.cs](./convert_epub_to_jpeg_compute_sha256_hash_of_output_to_verify_integrity.cs) | Convert Epub To Jpeg Compute Sha256 Hash Of Output To Verify Integrity | Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg, System.Security | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_custom_page_size_imagesaveoptions_precise_layout.cs](./convert_epub_to_jpeg_custom_page_size_imagesaveoptions_precise_layout.cs) | Convert Epub To Jpeg Custom Page Size Imagesaveoptions Precise Layout | System.Drawing, Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_set_background_color_white_consistent_pages.cs](./convert_epub_to_jpeg_set_background_color_white_consistent_pages.cs) | Convert Epub To Jpeg Set Background Color White Consistent Pages | Converters.Converter, System.Drawing, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_with_css_media_type_print_for_print_optimized_rendering.cs](./convert_epub_to_jpeg_with_css_media_type_print_for_print_optimized_rendering.cs) | Convert Epub To Jpeg With Css Media Type Print For Print Optimized Rendering | ImageSaveOptions.CssMediaType, Css.MediaType, MediaType.Print, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_with_imagesaveoptions_dpix_dpiy_300_high_resolution.cs](./convert_epub_to_jpeg_with_imagesaveoptions_dpix_dpiy_300_high_resolution.cs) | Convert Epub To Jpeg With Imagesaveoptions Dpix Dpiy 300 High Resolution | Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_with_image_save_options_margins_white_borders_each_page.cs](./convert_epub_to_jpeg_with_image_save_options_margins_white_borders_each_page.cs) | Convert Epub To Jpeg With Image Save Options Margins White Borders Each Page | System.Drawing, Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_write_conversion_parameters_and_timestamps_to_log_auditing.cs](./convert_epub_to_jpeg_write_conversion_parameters_and_timestamps_to_log_auditing.cs) | Convert Epub To Jpeg Write Conversion Parameters And Timestamps To Log Auditing | Environment.NewLine, File.AppendAllText, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_write_resulting_image_to_httpresponse_output_stream.cs](./convert_epub_to_jpeg_write_resulting_image_to_httpresponse_output_stream.cs) | Convert Epub To Jpeg Write Resulting Image To Httpresponse Output Stream | HttpResponse.OutputStream, System.Collections, Console.OpenStandardOutput, Streams.Count, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpeg_writing_result_to_filestream_using_block.cs](./convert_epub_to_jpeg_writing_result_to_filestream_using_block.cs) | Convert Epub To Jpeg Writing Result To Filestream Using Block | System.Collections, FileAccess.Write, Console.WriteLine, Streams.Count, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_jpg_images_using_default_settings_each_page_separate_file.cs](./convert_epub_to_jpg_images_using_default_settings_each_page_separate_file.cs) | Convert Epub To Jpg Images Using Default Settings Each Page Separate File | System.Collections, Console.WriteLine, Streams.Count, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_pdf_apply_custom_css_styles_using_pdfsaveoptions.cs](./convert_epub_to_pdf_apply_custom_css_styles_using_pdfsaveoptions.cs) | Convert Epub To Pdf Apply Custom Css Styles Using Pdfsaveoptions | Configuration, Console.WriteLine, System.IO, File.OpenRead, Agent.UserStyleSheet | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_pdf_custom_page_size_margins.cs](./convert_epub_to_pdf_custom_page_size_margins.cs) | Convert Epub To Pdf Custom Page Size Margins | Console.WriteLine, System.IO, File.OpenRead, PdfSaveOptions, Page | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_pdf_specifying_output_path_using_path_combine_platform_independent.cs](./convert_epub_to_pdf_specifying_output_path_using_path_combine_platform_independent.cs) | Convert Epub To Pdf Specifying Output Path Using Path Combine Platform Independent | Converters.Converter, Console.WriteLine, System.IO, Saving.PdfSaveOptions, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_pdf_using_filestream_create_new_mode.cs](./convert_epub_to_pdf_using_filestream_create_new_mode.cs) | Convert Epub To Pdf Using Filestream Create New Mode | System.Collections, FileMode.CreateNew, FileAccess.Write, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_pdf_via_filestream_readonly.cs](./convert_epub_to_pdf_via_filestream_readonly.cs) | Convert Epub To Pdf Via Filestream Readonly | Console.WriteLine, System.IO, File.OpenRead, PdfSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_and_generate_pdf_summary_of_conversion_parameters_for_documentation.cs](./convert_epub_to_png_and_generate_pdf_summary_of_conversion_parameters_for_documentation.cs) | Convert Epub To Png And Generate Pdf Summary Of Conversion Parameters For Documentation | Console.WriteLine, System.IO, File.OpenRead, PdfSaveOptions, Path.GetDirectoryName | Converts HTML content to another format using Aspose.HTML. |
| [convert_epub_to_png_and_pipe_image_bytes_into_websocket_stream_real_time_delivery.cs](./convert_epub_to_png_and_pipe_image_bytes_into_websocket_stream_real_time_delivery.cs) | Convert Epub To Png And Pipe Image Bytes Into Websocket Stream Real Time Delivery | System.Threading, ClientWebSocket, CancellationToken.None, File.OpenRead, Stream.ToArray | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_and_set_css_media_type_to_all_for_comprehensive_css_handling.cs](./convert_epub_to_png_and_set_css_media_type_to_all_for_comprehensive_css_handling.cs) | Convert Epub To Png And Set Css Media Type To All For Comprehensive Css Handling | MediaType.All, ImageSaveOptions.CssMediaType, Console.WriteLine, Aspose.HTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_create_zip_package_containing_every_page_image_for_easy_download.cs](./convert_epub_to_png_create_zip_package_containing_every_page_image_for_easy_download.cs) | Convert Epub To Png Create Zip Package Containing Every Page Image For Easy Download | System.Collections, Console.WriteLine, System.IO, File.OpenRead, FileMode.Create | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_define_image_save_options_margins_uniform_padding.cs](./convert_epub_to_png_define_image_save_options_margins_uniform_padding.cs) | Convert Epub To Png Define Image Save Options Margins Uniform Padding | Console.WriteLine, System.IO, File.OpenRead, Page, ImageSaveOptions.Margins | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_images_custom_dpi_setting_save_options.cs](./convert_epub_to_png_images_custom_dpi_setting_save_options.cs) | Convert Epub To Png Images Custom Dpi Setting Save Options | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_log_each_page_conversion_status_success_error_messages.cs](./convert_epub_to_png_log_each_page_conversion_status_success_error_messages.cs) | Convert Epub To Png Log Each Page Conversion Status Success Error Messages | System.Collections, Console.WriteLine, Aspose.HTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_pipe_output_into_filestream_efficient_disk_writing.cs](./convert_epub_to_png_pipe_output_into_filestream_efficient_disk_writing.cs) | Convert Epub To Png Pipe Output Into Filestream Efficient Disk Writing | Image.CopyTo, System.Collections, Console.WriteLine, Aspose.HTML, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_returning_image_data_via_custom_icreatestreamprovider_implementation.cs](./convert_epub_to_png_returning_image_data_via_custom_icreatestreamprovider_implementation.cs) | Convert Epub To Png Returning Image Data Via Custom Icreatestreamprovider Implementation | System.Collections, Stream.Length, Console.WriteLine, System.IO, Streams.Clear | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_using_default_rendering.cs](./convert_epub_to_png_using_default_rendering.cs) | Convert Epub To Png Using Default Rendering | Console.WriteLine, System.IO, File.OpenRead, Path.Combine, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_using_imagesaveoptions_define_specific_page_size_control_image_scaling.cs](./convert_epub_to_png_using_imagesaveoptions_define_specific_page_size_control_image_scaling.cs) | Convert Epub To Png Using Imagesaveoptions Define Specific Page Size Control Image Scaling | Console.WriteLine, System.IO, File.OpenRead, Page, Size | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_with_compression_level_6_moderate_efficiency.cs](./convert_epub_to_png_with_compression_level_6_moderate_efficiency.cs) | Convert Epub To Png With Compression Level 6 Moderate Efficiency | ImageSaveOptions.CompressionLevel, Console.WriteLine, System.IO, File.OpenRead, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_with_imagesaveoptions_cssmediatype_print_and_custom_css_high_contrast_output.cs](./convert_epub_to_png_with_imagesaveoptions_cssmediatype_print_and_custom_css_high_contrast_output.cs) | Convert Epub To Png With Imagesaveoptions Cssmediatype Print And Custom Css High Contrast Output | Configuration, ImageSaveOptions.CssMediaType, MediaType.Print, Console.WriteLine, Agent.UserStyleSheet | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_with_iprogress_real_time_updates.cs](./convert_epub_to_png_with_iprogress_real_time_updates.cs) | Convert Epub To Png With Iprogress Real Time Updates | System.Collections, Console.WriteLine, Aspose.HTML, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_png_with_transparent_background_using_imagesaveoptions_backgroundcolor.cs](./convert_epub_to_png_with_transparent_background_using_imagesaveoptions_backgroundcolor.cs) | Convert Epub To Png With Transparent Background Using Imagesaveoptions Backgroundcolor | System.Drawing, Console.WriteLine, System.IO, File.OpenRead, Color.Transparent | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_and_archive_output_files_into_zip_to_simplify_file_management.cs](./convert_epub_to_tiff_and_archive_output_files_into_zip_to_simplify_file_management.cs) | Convert Epub To Tiff And Archive Output Files Into Zip To Simplify File Management | Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB, Path.GetFileName | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_and_attach_creation_date_metadata_using_imagesaveoptions_to_track_conversion_time.cs](./convert_epub_to_tiff_and_attach_creation_date_metadata_using_imagesaveoptions_to_track_conversion_time.cs) | Convert Epub To Tiff And Attach Creation Date Metadata Using Imagesaveoptions To Track Conversion Time | Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_and_generate_csv_report_page_file_name_size_conversion_time.cs](./convert_epub_to_tiff_and_generate_csv_report_page_file_name_size_conversion_time.cs) | Convert Epub To Tiff And Generate Csv Report Page File Name Size Conversion Time | System.Text, File.WriteAllText, File.OpenRead, Converters.Converter, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_and_generate_log_summarizing_image_dimensions_and_compression_settings.cs](./convert_epub_to_tiff_and_generate_log_summarizing_image_dimensions_and_compression_settings.cs) | Convert Epub To Tiff And Generate Log Summarizing Image Dimensions And Compression Settings | System.Drawing, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_open_filestream_pass_to_converter_convert_epub_with_options.cs](./convert_epub_to_tiff_open_filestream_pass_to_converter_convert_epub_with_options.cs) | Convert Epub To Tiff Open Filestream Pass To Converter Convert Epub With Options | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_sha1_hash_verification_precomputed_reference_integrity.cs](./convert_epub_to_tiff_sha1_hash_verification_precomputed_reference_integrity.cs) | Convert Epub To Tiff Sha1 Hash Verification Precomputed Reference Integrity | Hash.ToLowerInvariant, SHA1.Create, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_using_imagesaveoptions_margins_ensure_consistent_spacing_around_rendered_pages.cs](./convert_epub_to_tiff_using_imagesaveoptions_margins_ensure_consistent_spacing_around_rendered_pages.cs) | Convert Epub To Tiff Using Imagesaveoptions Margins Ensure Consistent Spacing Around Rendered Pages | Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB, Page | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_using_imagesaveoptions_pagesize_to_enforce_exact_page_dimensions_during_rendering.cs](./convert_epub_to_tiff_using_imagesaveoptions_pagesize_to_enforce_exact_page_dimensions_during_rendering.cs) | Convert Epub To Tiff Using Imagesaveoptions Pagesize To Enforce Exact Page Dimensions During Rendering | System.Drawing, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_using_user_defined_css_via_imagesaveoptions_control_rendering_styles.cs](./convert_epub_to_tiff_using_user_defined_css_via_imagesaveoptions_control_rendering_styles.cs) | Convert Epub To Tiff Using User Defined Css Via Imagesaveoptions Control Rendering Styles | Services.IUserAgentService, Converters.Converter, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_with_custom_background_color_using_imagesaveoptions_match_document_theme.cs](./convert_epub_to_tiff_with_custom_background_color_using_imagesaveoptions_match_document_theme.cs) | Convert Epub To Tiff With Custom Background Color Using Imagesaveoptions Match Document Theme | Color.LightGray, System.Drawing, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_with_imagesaveoptions_compression_lzw_lossless.cs](./convert_epub_to_tiff_with_imagesaveoptions_compression_lzw_lossless.cs) | Convert Epub To Tiff With Imagesaveoptions Compression Lzw Lossless | ImageSaveOptions.Compression, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_with_imagesaveoptions_cssmediatype_print_apply_print_styles.cs](./convert_epub_to_tiff_with_imagesaveoptions_cssmediatype_print_apply_print_styles.cs) | Convert Epub To Tiff With Imagesaveoptions Cssmediatype Print Apply Print Styles | Options.Css, ImageSaveOptions.CssMediaType, MediaType.Print, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_with_imagesaveoptions_dpix_dpiy_600_ultra_high_definition_scans.cs](./convert_epub_to_tiff_with_imagesaveoptions_dpix_dpiy_600_ultra_high_definition_scans.cs) | Convert Epub To Tiff With Imagesaveoptions Dpix Dpiy 600 Ultra High Definition Scans | Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_tiff_with_lzw_compression_enabled_conversion_options.cs](./convert_epub_to_tiff_with_lzw_compression_enabled_conversion_options.cs) | Convert Epub To Tiff With Lzw Compression Enabled Conversion Options | Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_xps_ensuring_output_directory_exists_before_writing.cs](./convert_epub_to_xps_ensuring_output_directory_exists_before_writing.cs) | Convert Epub To Xps Ensuring Output Directory Exists Before Writing | XpsSaveOptions, Console.WriteLine, System.IO, File.OpenRead, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_xps_filestream_read_only.cs](./convert_epub_to_xps_filestream_read_only.cs) | Convert Epub To Xps Filestream Read Only | XpsSaveOptions, Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_xps_specifying_custom_page_dimensions_xpssaveoptions.cs](./convert_epub_to_xps_specifying_custom_page_dimensions_xpssaveoptions.cs) | Convert Epub To Xps Specifying Custom Page Dimensions Xpssaveoptions | XpsSaveOptions, Color.LightGray, System.Drawing, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_xps_using_filestream_create_new_mode.cs](./convert_epub_to_xps_using_filestream_create_new_mode.cs) | Convert Epub To Xps Using Filestream Create New Mode | System.Collections, XpsSaveOptions, FileMode.CreateNew, FileAccess.Write, Stream.WriteTo | Demonstrates a specific Aspose.HTML operation. |
| [convert_epub_to_xps_with_custom_css_using_xpssaveoptions.cs](./convert_epub_to_xps_with_custom_css_using_xpssaveoptions.cs) | Convert Epub To Xps With Custom Css Using Xpssaveoptions | Configuration, XpsSaveOptions, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [convert_large_epub_to_bmp_streaming_input_output_minimize_memory_consumption.cs](./convert_large_epub_to_bmp_streaming_input_output_minimize_memory_consumption.cs) | Convert Large Epub To Bmp Streaming Input Output Minimize Memory Consumption | Stream.Flush, Stream.Position, Streams.Count, File.OpenRead, Stream.CopyTo | Demonstrates a specific Aspose.HTML operation. |
| [convert_multiple_epub_files_folder_to_gifs_using_loop_shared_imagesaveoptions.cs](./convert_multiple_epub_files_folder_to_gifs_using_loop_shared_imagesaveoptions.cs) | Convert Multiple Epub Files Folder To Gifs Using Loop Shared Imagesaveoptions | Console.WriteLine, System.IO, File.OpenRead, Path.GetFileName, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [convert_password_protected_epub_to_jpeg_with_decryption_password_before_converter.cs](./convert_password_protected_epub_to_jpeg_with_decryption_password_before_converter.cs) | Convert Password Protected Epub To Jpeg With Decryption Password Before Converter | Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [convert_protected_epub_to_gif_ensure_conversion_routine_catches_authentication_errors_gracefully.cs](./convert_protected_epub_to_gif_ensure_conversion_routine_catches_authentication_errors_gracefully.cs) | Convert Protected Epub To Gif Ensure Conversion Routine Catches Authentication Errors Gracefully | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [create_batch_processing_method_accepts_epub_path_list_outputs_corresponding_gif_files.cs](./create_batch_processing_method_accepts_epub_path_list_outputs_corresponding_gif_files.cs) | Create Batch Processing Method Accepts Epub Path List Outputs Corresponding Gif Files | System.Collections, Console.WriteLine, System.IO, File.OpenRead, Path.Combine | Demonstrates a specific Aspose.HTML operation. |
| [create_bmp_thumbnail_initial_page_epub_imagesaveoptions.cs](./create_bmp_thumbnail_initial_page_epub_imagesaveoptions.cs) | Create Bmp Thumbnail Initial Page Epub Imagesaveoptions | ImageFormat.Bmp, Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [create_command_line_utility_accepts_epub_input_path_gif_output_path_arguments.cs](./create_command_line_utility_accepts_epub_input_path_gif_output_path_arguments.cs) | Create Command Line Utility Accepts Epub Input Path Gif Output Path Arguments | Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Gif, ImageSaveOptions | Demonstrates a specific Aspose.HTML operation. |
| [create_converter_instance_set_custom_imagesaveoptions_convert_specific_epub_page_to_gif.cs](./create_converter_instance_set_custom_imagesaveoptions_convert_specific_epub_page_to_gif.cs) | Create Converter Instance Set Custom Imagesaveoptions Convert Specific Epub Page To Gif | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [create_gif_thumbnail_first_epub_page_converting_single_page_limiting_animation_frames.cs](./create_gif_thumbnail_first_epub_page_converting_single_page_limiting_animation_frames.cs) | Create Gif Thumbnail First Epub Page Converting Single Page Limiting Animation Frames | Console.WriteLine, System.IO, File.OpenRead, Page, Margin | Demonstrates a specific Aspose.HTML operation. |
| [create_individual_tiff_images_for_each_epub_page_using_imagesaveoptions_pagenumber_during_conversion.cs](./create_individual_tiff_images_for_each_epub_page_using_imagesaveoptions_pagenumber_during_conversion.cs) | Create Individual Tiff Images For Each Epub Page Using Imagesaveoptions Pagenumber During Conversion | System.Collections, Console.WriteLine, Streams.Count, System.IO, Streams.Clear | Demonstrates a specific Aspose.HTML operation. |
| [create_scheduled_task_periodically_convert_newly_added_epub_files_to_gifs.cs](./create_scheduled_task_periodically_convert_newly_added_epub_files_to_gifs.cs) | Create Scheduled Task Periodically Convert Newly Added Ep

ub Files To Gifs | TimeSpan.Zero, System.Threading, Timer, Path.GetFileNameWithoutExtension, ImageFormat.Gif | Demonstrates a specific Aspose.HTML operation. |
| [dispose_converter_object_and_open_streams_after_epub_to_gif_conversion.cs](./dispose_converter_object_and_open_streams_after_epub_to_gif_conversion.cs) | Dispose Converter Object And Open Streams After Epub To Gif Conversion | System.Collections, Console.WriteLine, Streams.Count, System.IO, Streams.Clear | Demonstrates a specific Aspose.HTML operation. |
| [execute_parallel_epub_to_png_conversions_across_cpu_cores_thread_safe_imagesaveoptions_usage.cs](./execute_parallel_epub_to_png_conversions_across_cpu_cores_thread_safe_imagesaveoptions_usage.cs) | Execute Parallel Epub To Png Conversions Across Cpu Cores Thread Safe Imagesaveoptions Usage | Parallel.ForEach, Console.WriteLine, System.IO, File.OpenRead, System.Threading | Demonstrates a specific Aspose.HTML operation. |
| [export_every_page_epub_as_individual_bmp_images_using_imagesaveoptions_control_per_page_rendering.cs](./export_every_page_epub_as_individual_bmp_images_using_imagesaveoptions_control_per_page_rendering.cs) | Export Every Page Epub As Individual Bmp Images Using Imagesaveoptions Control Per Page Rendering | System.Collections, ImageFormat.Bmp, Console.WriteLine, Streams.Count, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [extract_tiff_thumbnail_opening_page_epub_converter_convert_epub_page_range_zero.cs](./extract_tiff_thumbnail_opening_page_epub_converter_convert_epub_page_range_zero.cs) | Extract Tiff Thumbnail Opening Page Epub Converter Convert Epub Page Range Zero | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [generate_separate_png_files_for_each_epub_page_configure_imagesaveoptions_output_one_image_per_page.cs](./generate_separate_png_files_for_each_epub_page_configure_imagesaveoptions_output_one_image_per_page.cs) | Generate Separate Png Files For Each Epub Page Configure Imagesaveoptions Output One Image Per Page | System.Collections, Console.WriteLine, Streams.Count, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [implement_logging_input_epub_metadata_before_conversion_assist_troubleshooting_output_gif_issues.cs](./implement_logging_input_epub_metadata_before_conversion_assist_troubleshooting_output_gif_issues.cs) | Implement Logging Input Epub Metadata Before Conversion Assist Troubleshooting Output Gif Issues | System.Linq, Console.WriteLine, System.IO, File.OpenRead, StringComparison.OrdinalIgnoreCase | Demonstrates a specific Aspose.HTML operation. |
| [implement_retry_mechanism_epub_to_gif_conversion_up_to_three_times_on_failure.cs](./implement_retry_mechanism_epub_to_gif_conversion_up_to_three_times_on_failure.cs) | Implement Retry Mechanism Epub To Gif Conversion Up To Three Times On Failure | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [integrate_epub_to_gif_conversion_into_aspnet_mvc_controller_action_for_on_demand_rendering.cs](./integrate_epub_to_gif_conversion_into_aspnet_mvc_controller_action_for_on_demand_rendering.cs) | Integrate Epub To Gif Conversion Into Aspnet Mvc Controller Action For On Demand Rendering | Console.WriteLine, System.IO, File.OpenRead, Converter.ConvertEPUB, ImageFormat.Gif | Demonstrates a specific Aspose.HTML operation. |
| [load_epub_file_from_disk_convert_to_gif_default_settings.cs](./load_epub_file_from_disk_convert_to_gif_default_settings.cs) | Load Epub File From Disk Convert To Gif Default Settings | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [measure_conversion_time_recording_timestamps_before_after_converter_convert_epub_performance_analysis.cs](./measure_conversion_time_recording_timestamps_before_after_converter_convert_epub_performance_analysis.cs) | Measure Conversion Time Recording Timestamps Before After Converter Convert Epub Performance Analysis | System.Collections, XpsSaveOptions, DateTime.Now, Console.WriteLine, Streams.Count | Demonstrates a specific Aspose.HTML operation. |
| [parallelize_conversion_multiple_epub_files_to_jpeg_parallel_foreach_improve_processing_throughput.cs](./parallelize_conversion_multiple_epub_files_to_jpeg_parallel_foreach_improve_processing_throughput.cs) | Parallelize Conversion Multiple Epub Files To Jpeg Parallel Foreach Improve Processing Throughput | System.Threading, Path.GetFileNameWithoutExtension, Stream.Position, Parallel.ForEach, Streams.Count | Demonstrates a specific Aspose.HTML operation. |
| [parallel_convert_collection_epub_documents_to_bmp_images_concurrent_tasks_reduce_runtime.cs](./parallel_convert_collection_epub_documents_to_bmp_images_concurrent_tasks_reduce_runtime.cs) | Parallel Convert Collection Epub Documents To Bmp Images Concurrent Tasks Reduce Runtime | System.Collections, ImageFormat.Bmp, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [perform_parallel_epub_to_gif_conversions_with_parallelism_limit_to_avoid_overwhelming_system_resources.cs](./perform_parallel_epub_to_gif_conversions_with_parallelism_limit_to_avoid_overwhelming_system_resources.cs) | Perform Parallel Epub To Gif Conversions With Parallelism Limit To Avoid Overwhelming System Resources | System.Collections, Parallel.ForEach, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [run_parallel_epub_to_tiff_conversions_taskrun_foreach_file_handling_exceptions_individually.cs](./run_parallel_epub_to_tiff_conversions_taskrun_foreach_file_handling_exceptions_individually.cs) | Run Parallel Epub To Tiff Conversions Taskrun Foreach File Handling Exceptions Individually | Console.WriteLine, System.IO, Files.Length, File.OpenRead, System.Threading | Demonstrates a specific Aspose.HTML operation. |
| [set_imagesaveoptions_background_color_to_white_ensure_consistent_background_across_all_generated_gifs.cs](./set_imagesaveoptions_background_color_to_white_ensure_consistent_background_across_all_generated_gifs.cs) | Set Imagesaveoptions Background Color To White Ensure Consistent Background Across All Generated Gifs | Converters.Converter, System.Drawing, Console.WriteLine, ImageFormat.Gif, Saving.ImageSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [set_imagesaveoptions_compressionlevel_optimize_gif_file_size_without_sacrificing_visual_quality_significantly.cs](./set_imagesaveoptions_compressionlevel_optimize_gif_file_size_without_sacrificing_visual_quality_significantly.cs) | Set Imagesaveoptions Compressionlevel Optimize Gif File Size Without Sacrificing Visual Quality Significantly | HTMLDocument, Rendering.Image, ImageSaveOptions.CompressionLevel, Console.WriteLine, Aspose.HTML | Converts HTML content to another format using Aspose.HTML. |
| [stream_epub_content_from_network_source_into_memorystream_before_converting_to_gif.cs](./stream_epub_content_from_network_source_into_memorystream_before_converting_to_gif.cs) | Stream Epub Content From Network Source Into Memorystream Before Converting To Gif | System.Collections, Console.WriteLine, System.IO, File.Create, Client.GetStreamAsync | Demonstrates a specific Aspose.HTML operation. |
| [test_conversion_of_epub_with_embedded_fonts_to_verify_glyphs_render_correctly_in_gif_output.cs](./test_conversion_of_epub_with_embedded_fonts_to_verify_glyphs_render_correctly_in_gif_output.cs) | Test Conversion Of Epub With Embedded Fonts To Verify Glyphs Render Correctly In Gif Output | Console.WriteLine, System.IO, File.OpenRead, ImageSaveOptions, Converter.ConvertEPUB | Demonstrates a specific Aspose.HTML operation. |
| [use_custom_stream_provider_store_gif_output_directly_cloud_storage_bucket.cs](./use_custom_stream_provider_store_gif_output_directly_cloud_storage_bucket.cs) | Use Custom Stream Provider Store Gif Output Directly Cloud Storage Bucket | CloudStorage.Upload, System.Collections, Console.WriteLine, CloudGifStreamProvider, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [use_try_finally_block_guarantee_disposal_of_streams_even_when_conversion_throws_exceptions.cs](./use_try_finally_block_guarantee_disposal_of_streams_even_when_conversion_throws_exceptions.cs) | Use Try Finally Block Guarantee Disposal Of Streams Even When Conversion Throws Exceptions | System.Collections, XpsSaveOptions, Console.WriteLine, System.IO, File.OpenRead | Demonstrates a specific Aspose.HTML operation. |
| [validate_generated_gif_file_exists_and_nonzero_size_after_conversion.cs](./validate_generated_gif_file_exists_and_nonzero_size_after_conversion.cs) | Validate Generated Gif File Exists And Nonzero Size After Conversion | HTMLDocument, Console.WriteLine, System.IO, FileInfo, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [validate_gif_file_header_conforms_to_gif89a_specification_after_conversion.cs](./validate_gif_file_header_conforms_to_gif89a_specification_after_conversion.cs) | Validate Gif File Header Conforms To Gif89A Specification After Conversion | Converters.Converter, FileAccess.Read, FileMode.Open, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [verify_converter_releases_unmanaged_resources_check_memory_usage_multiple_conversions.cs](./verify_converter_releases_unmanaged_resources_check_memory_usage_multiple_conversions.cs) | Verify Converter Releases Unmanaged Resources Check Memory Usage Multiple Conversions | System.Collections, Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Png | Demonstrates a specific Aspose.HTML operation. |

*The table above lists **all 143** example files present in the `epub_converter` folder.*

---

## Category‑Specific Tips

### Key API Surface
- **Converter.ConvertEPUB** – core entry point for all EPUB → target format conversions.  
- **ImageSaveOptions / PdfSaveOptions / DocSaveOptions / XpsSaveOptions** – configure DPI, page size, background, compression, CSS media type, etc.  
- **File.OpenRead**, **File.Create**, **Path.Combine** – standard file‑system handling.  
- **Console.WriteLine** – used for progress, diagnostics, and audit logging.  
- **Streams** collection – holds per‑page image streams returned by the converter; always enumerate and dispose.

### Rules
1. **Always open the source EPUB with a read‑only `FileStream`** (`File.OpenRead`) inside a `using` block.  
2. **Create the output directory** (`Directory.CreateDirectory`) before writing any files.  
3. **Configure an appropriate `*SaveOptions` object** before calling `Converter.ConvertEPUB`.  
   * DPI ≥ 300 for print‑quality images, 72 DPI for screen‑size GIFs.  
   * Set `BackgroundColor` for formats that support transparency.  
   * Use `CssMediaType` (`Print`, `Screen`, `All`) to control CSS rendering.  
4. **Iterate the returned `IEnumerable<Stream>`**; copy each stream to a file or another destination and **dispose** it promptly.  
5. **Log start/end timestamps** (`DateTime.Now`) and any exceptions; this aids troubleshooting and performance analysis.  
6. **When processing many files**, prefer `Parallel.ForEach` with a bounded degree of parallelism to avoid exhausting memory.  
7. **For password‑protected EPUBs**, set the decryption password on the `ImageSaveOptions` (or relevant option) **before** conversion.  
8. **Validate output** – check file existence, size, and (for GIF) header (`GIF89a`).  

---

## Warnings

- **Template/Data Binding Mismatch** – If an HTML template expects placeholders that are not supplied, the conversion will succeed but the rendered output will contain raw tokens.  
- **Missing Resource Files** – CSS, fonts, or images referenced by the EPUB must be accessible; otherwise rendering may fall back to defaults or produce blank areas.  
- **File Path Issues** – Using relative paths without `Path.Combine` can cause failures on non‑Windows platforms. Always normalise paths.  
- **Memory Pressure** – Converting large EPUBs to high‑resolution images without streaming (e.g., loading all pages into memory) can cause `OutOfMemoryException`. Use streaming patterns (`Stream.CopyTo`, `MemoryStreamProvider`).  
- **Unmanaged Resource Leaks** – Failing to dispose the `Converter` instance or the per‑page streams may keep native handles alive, leading to increased process memory.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – The example must compile on its own, include all required `using` statements, and not rely on external project files.  
2. **Console Logging** – Emit start, progress, and completion messages via `Console.WriteLine`.  
3. **Follow the Standard Flow**:  
   - Open source EPUB (`File.OpenRead`).  
   - Create and configure a `*SaveOptions` object.  
   - Call `Converter.ConvertEPUB`.  
   - Iterate result streams, write to disk or another destination, and dispose.  
4. **Naming Convention** – File name should be lower‑snake‑case, start with the action (`convert_`, `batch_`, `create_`, etc.), and end with the target format (`_to_png.cs`, `_to_gif.cs`, …).  
5. **Update Statistics** – After adding a file, increment the `total_examples` count and, if new namespaces or APIs are introduced, add them to the respective tables.  

---