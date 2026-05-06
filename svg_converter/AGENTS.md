---
name: svg_converter
description: C# examples for svg_converter using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – svg_converter

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **svg_converter** category.
This folder contains standalone C# examples for svg_converter operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: svg_converter  
- **Total examples**: 105  
- **Typical workflow**:  
  1. **Load** – read an SVG (or HTML) source into an `SVGDocument` / `HTMLDocument`.  
  2. **Bind** – (optional) attach data, set page setup, or adjust rendering options.  
  3. **Convert** – invoke `Converter.ConvertSVG` (or `ConvertHTML`) with the appropriate `SaveOptions` (`ImageSaveOptions`, `PdfSaveOptions`, `XpsSaveOptions`, `DocSaveOptions`, etc.).  
  4. **Render / Persist** – write the result to disk, a stream, or return it to a caller.

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | Core language constructs, console output |
| Aspose.Html.Saving | Save‑option classes (`PdfSaveOptions`, `ImageSaveOptions`, …) |
| Aspose.Html.Converters | Static `Converter` methods |
| Aspose.Html.Rendering.Image | Image rendering pipeline |
| System.IO | File and stream handling |
| Aspose.Html.Dom.Svg | SVG DOM manipulation (`SVGDocument`) |
| System.Drawing | Color, bitmap utilities |
| Aspose.Html.Drawing | Additional drawing helpers |
| Aspose.Html | Root namespace for all Aspose.HTML types |
| System.Collections.Generic | Collections used in examples |
| Aspose.Html.IO | Stream providers |
| System.Diagnostics | Stopwatch, logging |
| Aspose.Html.Rendering.Pdf | PDF rendering specifics |
| System.IO.Compression | Compression utilities (rare) |
| System.Threading | Simple retry / delay logic |
| System.Net.Sockets | Network stream provider example |
| System.Text | Encoding helpers |
| System.Net.Http | HTTP client usage |
| System.Text.Json | JSON logging example |
| System.Net.Sockets | (duplicate – counted once) |

### How to import them

```csharp
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.IO;
using Aspose.Html.Drawing;
```

---

## Common Code Pattern

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class SvgConversionDemo
{
    static void Main()
    {
        // 1️⃣ Load the SVG document
        string inputPath = @"C:\Samples\input.svg";
        SVGDocument svgDoc = new SVGDocument(inputPath);

        // 2️⃣ (Optional) Adjust rendering options – e.g., DPI, background, compression
        ImageSaveOptions saveOpts = new ImageSaveOptions(ImageFormat.Png)
        {
            DpiX = 300,
            DpiY = 300,
            BackgroundColor = Color.White,
            Compression = Compression.LZW
        };

        // 3️⃣ Convert to the target format (PNG in this case)
        string outputPath = @"C:\Samples\output.png";
        Converter.ConvertSVG(svgDoc, outputPath, saveOpts);

        // 4️⃣ Log the result
        Console.WriteLine($"SVG converted to PNG successfully: {outputPath}");
    }
}
```

*The pattern above is the backbone of every example in this folder – only the **input**, **output**, **save‑options** and occasional **binding** steps differ.*

---

## Frequently Used APIs

| API | Appearances |
|-----|--------------|
| Console.WriteLine | 105 |
| Aspose.Html | 104 |
| Converter.ConvertSVG | 82 |
| ImageSaveOptions | 63 |
| Rendering.Image | 53 |
| System.IO | 46 |
| SVGDocument | 38 |
| Dom.Svg | 38 |
| Path.Combine | 29 |
| Directory.CreateDirectory | 25 |
| Directory.GetFiles | 25 |
| Path.GetFileNameWithoutExtension | 24 |
| Directory.Exists | 22 |
| XpsSaveOptions | 20 |
| System.Drawing | 20 |
| ImageFormat.Tiff | 16 |
| Path.GetFileName | 15 |
| PdfSaveOptions | 14 |
| Files.Length | 14 |
| ImageFormat.Bmp | 14 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [add_table_of_contents_using_pdfsaveoptions_outlines_when_generating_pdf.cs](./add_table_of_contents_using_pdfsaveoptions_outlines_when_generating_pdf.cs) | Add Table Of Contents Using Pdfsaveoptions Outlines When Generating Pdf | FormFieldBehaviour.Flattened, Rendering.Pdf, PdfSaveOptions | Converts HTML to PDF while adding outline entries for a table of contents. |
| [adjust_imagesaveoptions_gamma_value_improve_brightness_png_conversion.cs](./adjust_imagesaveoptions_gamma_value_improve_brightness_png_conversion.cs) | Adjust Imagesaveoptions Gamma Value Improve Brightness Png Conversion | Console.WriteLine, Converter.ConvertMHTML, File.OpenRead | Shows how to tweak gamma in `ImageSaveOptions` to brighten PNG output. |
| [apply_lzw_compression_image_save_options_converting_svg_to_tiff.cs](./apply_lzw_compression_image_save_options_converting_svg_to_tiff.cs) | Apply Lzw Compression Image Save Options Converting Svg To Tiff | Compression.LZW, ImageSaveOptions, ImageFormat.Tiff | Demonstrates LZW‑compressed TIFF generation from SVG. |
| [apply_xpssaveoptions_set_compression_level_page_size_svg_to_xps_conversion.cs](./apply_xpssaveoptions_set_compression_level_page_size_svg_to_xps_conversion.cs) | Apply Xpssaveoptions Set Compression Level Page Size Svg To Xps Conversion | PageSetup.AnyPage, XpsSaveOptions, Color.AliceBlue | Configures XPS compression and page size for SVG → XPS conversion. |
| [batch_conversion_folder_svg_to_jpeg_uniform_quality.cs](./batch_conversion_folder_svg_to_jpeg_uniform_quality.cs) | Batch Conversion Folder Svg To Jpeg Uniform Quality | Directory.CreateDirectory, Converters.Converter, System.Drawing | Converts every SVG in a folder to JPEG with the same quality setting. |
| [batch_convert_list_of_svg_files_to_various_formats_iterating_save_options_programmatically.cs](./batch_convert_list_of_svg_files_to_various_formats_iterating_save_options_programmatically.cs) | Batch Convert List Of Svg Files To Various Formats Iterating Save Options Programmatically | AnyPage.Size, SVGDocument, Path.GetFileNameWithoutExtension | Shows how to loop through a list and apply different `SaveOptions` per file. |
| [batch_convert_multiple_svg_images_to_gif_format_applying_custom_options_per_file.cs](./batch_convert_multiple_svg_images_to_gif_format_applying_custom_options_per_file.cs) | Batch Convert Multiple Svg Images To Gif Format Applying Custom Options Per File | Directory.CreateDirectory, Converters.Converter, System.Drawing | Generates GIFs from SVGs with per‑file custom settings. |
| [batch_convert_svg_documents_to_docx_with_page_size_and_margins.cs](./batch_convert_svg_documents_to_docx_with_page_size_and_margins.cs) | Batch Convert Svg Documents To Docx With Page Size And Margins | PageSetup.AnyPage, DocSaveOptions, Directory.GetFiles | Converts SVGs to DOCX while enforcing page dimensions and margins. |
| [batch_convert_svg_files_to_tiff_configuring_compression_differently_per_output_file.cs](./batch_convert_svg_files_to_tiff_configuring_compression_differently_per_output_file.cs) | Batch Convert Svg Files To Tiff Configuring Compression Differently Per Output File | SVGDocument, Compression.CCITT3, Compression.Rle | Demonstrates per‑file TIFF compression selection. |
| [batch_convert_svg_folder_to_bmp_using_loop_converter.cs](./batch_convert_svg_folder_to_bmp_using_loop_converter.cs) | Batch Convert Svg Folder To Bmp Using Loop Converter | ImageFormat.Bmp, Console.WriteLine, Directory.GetFiles | Simple loop that converts a folder of SVGs to BMP. |
| [batch_process_svg_files_to_docx_ensuring_each_document_retains_vector_graphic_fidelity_after_conversion.cs](./batch_process_svg_files_to_docx_ensuring_each_document_retains_vector_graphic_fidelity_after_conversion.cs) | Batch Process Svg Files To Docx Ensuring Each Document Retains Vector Graphic Fidelity After Conversion | DocSaveOptions, Path.Combine, Directory.GetFiles | Preserves vector quality when converting SVG → DOCX in bulk. |
| [benchmark_conversion_time_svg_to_jpeg_different_jpeg_quality_settings_find_optimal_performance.cs](./benchmark_conversion_time_svg_to_jpeg_different_jpeg_quality_settings_find_optimal_performance.cs) | Benchmark Conversion Time Svg To Jpeg Different Jpeg Quality Settings Find Optimal Performance | Stopwatch.StartNew, ImageFormat.Jpeg, ImageSaveOptions | Measures conversion speed across JPEG quality levels. |
| [call_converter_convertsvg_with_svgdocument_and_save_options_for_format_conversion.cs](./call_converter_convertsvg_with_svgdocument_and_save_options_for_format_conversion.cs) | Call Converter Convertsvg With Svgdocument And Save Options For Format Conversion | ImageFormat.Jpeg, SVGDocument, Path.Combine | Basic example of using `Converter.ConvertSVG` with explicit options. |
| [capture_conversion_exceptions_log_error_messages_source_file_path_troubleshooting.cs](./capture_conversion_exceptions_log_error_messages_source_file_path_troubleshooting.cs) | Capture Conversion Exceptions Log Error Messages Source File Path Troubleshooting | Converter.ConvertHTML, PdfSaveOptions, Console.WriteLine | Shows try/catch around conversion and logs the source path. |
| [configure_imagesaveoptions_png_output_antialiasing_enabled_improve_visual_quality.cs](./configure_imagesaveoptions_png_output_antialiasing_enabled_improve_visual_quality.cs) | Configure Imagesaveoptions Png Output Antialiasing Enabled Improve Visual Quality | Converters.Converter, ImageSaveOptions, HTMLDocument | Enables antialiasing for PNG output to improve visual fidelity. |
| [configure_image_save_options_png_output_antialiasing_disabled_pixel_perfect_thumbnail_generation.cs](./configure_image_save_options_png_output_antialiasing_disabled_pixel_perfect_thumbnail_generation.cs) | Configure Image Save Options Png Output Antialiasing Disabled Pixel Perfect Thumbnail Generation | ImageFormat.Png, Converter.ConvertHTML, ImageSaveOptions | Disables antialiasing for crisp thumbnail generation. |
| [configure_xpssaveoptions_embed_fonts_within_xps_output_consistent_rendering_across_devices.cs](./configure_xpssaveoptions_embed_fonts_within_xps_output_consistent_rendering_across_devices.cs) | Configure Xpssaveoptions Embed Fonts Within Xps Output Consistent Rendering Across Devices | XpsSaveOptions, Converter.ConvertHTML, HTMLDocument | Embeds fonts in XPS to guarantee identical rendering. |
| [console_application_reads_svg_file_paths_from_text_file_converts_to_xps.cs](./console_application_reads_svg_file_paths_from_text_file_converts_to_xps.cs) | Console Application Reads Svg File Paths From Text File Converts To Xps | XpsSaveOptions, File.ReadAllLines, Path.Trim | Reads a list of SVG paths from a text file and converts each to XPS. |
| [converter_convertsvg_static_method_batch_convert_svg_paths_to_png_files.cs](./converter_convertsvg_static_method_batch_convert_svg_paths_to_png_files.cs) | Converter Convertsvg Static Method Batch Convert Svg Paths To PNG Files | ImageSaveOptions, Path.ChangeExtension, Aspose.Html | One‑liner static method that converts many SVGs to PNG. |
| [convert_multiple_svg_files_in_directory_to_xps_using_loop.cs](./convert_multiple_svg_files_in_directory_to_xps_using_loop.cs) | Convert Multiple Svg Files In Directory To Xps Using Loop | XpsSaveOptions, Directory.GetFiles, Path.Combine | Loop‑based conversion of a directory of SVGs to XPS. |
| [convert_single_svg_file_to_bmp_using_one_line_converter_convertsvg.cs](./convert_single_svg_file_to_bmp_using_one_line_converter_convertsvg.cs) | Convert Single Svg File To Bmp Using One Line Converter Convertsvg | ImageFormat.Bmp, Converter.ConvertSVG, ImageSaveOptions | One‑line conversion of a single SVG to BMP. |
| [convert_svg_document_to_docx_with_new_docsaveoptions_instance.cs](./convert_svg_document_to_docx_with_new_docsaveoptions_instance.cs) | Convert Svg Document To Docx With New Docsaveoptions Instance | Converter.ConvertSVG, Saving.DocSaveOptions, Aspose.Html | Shows creation of a fresh `DocSaveOptions` for SVG → DOCX. |
| [convert_svg_files_nested_subfolders_to_tiff_preserving_directory_structure_output_locations.cs](./convert_svg_files_nested_subfolders_to_tiff_preserving_directory_structure_output_locations.cs) | Convert Svg Files Nested Subfolders To Tiff Preserving Directory Structure Output Locations | Path.GetRelativePath, Path.GetDirectoryName, Directory.GetFiles | Keeps folder hierarchy when bulk‑converting to TIFF. |
| [convert_svg_files_using_relative_paths_source_destination_demonstrating_path_resolution_batch_scripts.cs](./convert_svg_files_using_relative_paths_source_destination_demonstrating_path_resolution_batch_scripts.cs) | Convert Svg Files Using Relative Paths Source Destination Demonstrating Path Resolution Batch Scripts | PdfSaveOptions, Directory.GetFiles, Console.WriteLine | Uses relative paths for source and destination in batch conversion. |
| [convert_svg_files_with_spaces_to_gif_preserving_output_filenames_spacing.cs](./convert_svg_files_with_spaces_to_gif_preserving_output_filenames_spacing.cs) | Convert Svg Files With Spaces To Gif Preserving Output Filenames Spacing | Name.Contains, Path.GetFileName, Directory.GetFiles | Handles file names that contain spaces during SVG → GIF conversion. |
| [convert_svg_files_with_unicode_characters_in_filenames_to_bmp_ensuring_correct_file_path_handling.cs](./convert_svg_files_with_unicode_characters_in_filenames_to_bmp_ensuring_correct_file_path_handling.cs) | Convert Svg Files With Unicode Characters In Filenames To Bmp Ensuring Correct File Path Handling | ImageFormat.Bmp, Directory.GetFiles, Path.Combine | Demonstrates Unicode‑safe path handling for BMP output. |
| [convert_svg_file_to_bmp_by_selecting_bmp_target_in_conversion_api.cs](./convert_svg_file_to_bmp_by_selecting_bmp_target_in_conversion_api.cs) | Convert Svg File To Bmp By Selecting Bmp Target In Conversion Api | ImageFormat.Bmp, ImageSaveOptions, Converter.ConvertSVG | Explicitly selects BMP as the target format via `ImageSaveOptions`. |
| [convert_svg_from_memory_stream_to_bmp_using_convertsvg_overload_image_save_options.cs](./convert_svg_from_memory_stream_to_bmp_using_convertsvg_overload_image_save_options.cs) | Convert Svg From Memory Stream To Bmp Using Convertsvg Overload Image Save Options | File.ReadAllBytes, MemoryStream, ImageSaveOptions | Shows conversion from an in‑memory SVG stream to BMP. |
| [convert_svg_image_to_gif_default_imagesaveoptions_converter_convertsvg.cs](./convert_svg_image_to_gif_default_imagesaveoptions_converter_convertsvg.cs) | Convert Svg Image To Gif Default Imagesaveoptions Converter Convertsvg | Rendering.Image, ImageSaveOptions, Converter.ConvertSVG | Simple SVG → GIF conversion using default `ImageSaveOptions`. |
| [convert_svg_to_bmp_with_antialiasing_and_verify_image_sharpness.cs](./convert_svg_to_bmp_with_antialiasing_and_verify_image_sharpness.cs) | Convert Svg To Bmp With Antialiasing And Verify Image Sharpness | ImageFormat.Bmp, System.Drawing, Color.AliceBlue | Enables antialiasing for BMP output and checks sharpness. |
| [convert_svg_to_bmp_with_dpi_300_image_save_options.cs](./convert_svg_to_bmp_with_dpi_300_image_save_options.cs) | Convert Svg To Bmp With Dpi 300 Image Save Options | ImageFormat.Bmp, SVGDocument, ImageSaveOptions | Sets 300 DPI for high‑resolution BMP conversion. |
| [convert_svg_to_bmp_with_specified_color_depth_adjusting_settings.cs](./convert_svg_to_bmp_with_specified_color_depth_adjusting_settings.cs) | Convert Svg To Bmp With Specified Color Depth Adjusting Settings | ImageFormat.Bmp, System.Drawing, Color.AliceBlue | Adjusts color depth for BMP output. |
| [convert_svg_to_gif_preserving_animation_frames_using_settings.cs](./convert_svg_to_gif_preserving_animation_frames_using_settings.cs) | Convert Svg To Gif Preserving Animation Frames Using Settings | Rendering.Image, ImageSaveOptions, Converter.ConvertSVG | Keeps animation frames when converting SVG → GIF. |
| [convert_svg_to_gif_set_background_color_white_using_imagesaveoptions.cs](./convert_svg_to_gif_set_background_color_white_using_imagesaveoptions.cs) | Convert Svg To Gif Set Background Color White Using Imagesaveoptions | Rendering.Image, System.Drawing, SVGDocument | Forces a white background for GIF output. |
| [convert_svg_to_gif_set_frame_delay_100ms_image_save_options.cs](./convert_svg_to_gif_set_frame_delay_100ms_image_save_options.cs) | Convert Svg To Gif Set Frame Delay 100 Ms Image Save Options | Rendering.Image, ImageSaveOptions, Converter.ConvertSVG | Sets a 100 ms frame delay for the generated GIF. |
| [convert_svg_to_gif_with_transparent_background_configuring_conversion_settings_before_execution.cs](./convert_svg_to_gif_with_transparent_background_configuring_conversion_settings_before_execution.cs) | Convert Svg To Gif With Transparent Background Configuring Conversion Settings Before Execution | Rendering.Image, Color.Transparent, SVGDocument | Produces a GIF with a transparent background. |
| [convert_svg_to_tiff_ccitt_group4_compression_optimal_black_and_white_document_storage.cs](./convert_svg_to_tiff_ccitt_group4_compression_optimal_black_and_white_document_storage.cs) | Convert Svg To Tiff Ccitt Group4 Compression Optimal Black And White Document Storage | SVGDocument, Compression.None, ImageFormat.Tiff | Generates monochrome TIFF using CCITT Group 4 compression. |
| [convert_svg_to_tiff_enable_usebig_endian_compatibility_viewers.cs](./convert_svg_to_tiff_enable_usebig_endian_compatibility_viewers.cs) | Convert Svg To Tiff Enable Usebig Endian Compatibility Viewers | Aspose.HTML, ImageSaveOptions, ImageFormat.Tiff | Enables big‑endian flag for TIFF compatibility. |
| [convert_svg_to_tiff_image_save_options_compression_lzw.cs](./convert_svg_to_tiff_image_save_options_compression_lzw.cs) | Convert Svg To Tiff Image Save Options Compression Lzw | Compression.LZW, SVGDocument, ImageSaveOptions | Applies LZW compression to TIFF output. |
| [convert_svg_to_tiff_no_compression_image_save_options_compression_none.cs](./convert_svg_to_tiff_no_compression_image_save_options_compression_none.cs) | Convert Svg To Tiff No Compression Image Save Options Compression None | ImageSaveOptions.Compression, Compression.None, SVGDocument | Produces uncompressed TIFF files. |
| [convert_svg_to_tiff_set_compression_ccitt_group4_monochrome_output.cs](./convert_svg_to_tiff_set_compression_ccitt_group4_monochrome_output.cs) | Convert Svg To Tiff Set Compression Ccitt Group4 Monochrome Output | SVGDocument, Compression.None, ImageFormat.Tiff | Configures CCITT Group 4 for monochrome TIFF. |
| [convert_svg_to_tiff_set_dpix_dpy_200_higher_resolution.cs](./convert_svg_to_tiff_set_dpix_dpy_200_higher_resolution.cs) | Convert Svg To Tiff Set Dpix Dpy 200 Higher Resolution | SVGDocument, ImageSaveOptions, ImageFormat.Tiff | Sets 200 DPI for high‑resolution TIFF. |
| [convert_svg_to_tiff_with_lzw_compression_by_configuring_save_options_api.cs](./convert_svg_to_tiff_with_lzw_compression_by_configuring_save_options_api.cs) | Convert Svg To Tiff With Lzw Compression By Configuring Save Options Api | Compression.LZW, SVGDocument, ImageSaveOptions | Same as earlier LZW example, emphasizing API usage. |
| [convert_svg_to_xps_preserve_original_color_profiles_disable_color_conversion.cs](./convert_svg_to_xps_preserve_original_color_profiles_disable_color_conversion.cs) | Convert Svg To Xps Preserve Original Color Profiles Disable Color Conversion | XpsSaveOptions, Color.Transparent, Console.WriteLine | Disables color conversion when creating XPS. |
| [convert_svg_to_xps_preserving_embedded_fonts_enable_font_embedding_in_xpssaveoptions.cs](./convert_svg_to_xps_preserving_embedded_fonts_enable_font_embedding_in_xpssaveoptions.cs) | Convert Svg To Xps Preserving Embedded Fonts Enable Font Embedding In Xpssaveoptions | Converter.ConvertSVG, XpsSaveOptions, Aspose.Html | Embeds fonts into the generated XPS. |
| [convert_svg_to_xps_using_one_line_static_method.cs](./convert_svg_to_xps_using_one_line_static_method.cs) | Convert Svg To Xps Using One Line Static Method | Converter.ConvertSVG, XpsSaveOptions, Aspose.Html | One‑liner conversion to XPS. |
| [create_console_application_reads_svg_paths_from_text_file_and_converts_to_pdf.cs](./create_console_application_reads_svg_paths_from_text_file_and_converts_to_pdf.cs) | Create Console Application Reads Svg Paths From Text File And Converts To Pdf | File.ReadAllLines, Path.Trim, PdfSaveOptions | Reads SVG list from a file and converts each to PDF. |
| [create_diagnostic_log_records_source_svg_path_target_format_conversion_duration.cs](./create_diagnostic_log_records_source_svg_path_target_format_conversion_duration.cs) | Create Diagnostic Log Records Source Svg Path Target Format Conversion Duration | System.Diagnostics, Stopwatch.StartNew, Files.Length | Logs conversion duration for each file. |
| [create_method_accepts_svg_path_returns_memorystream_with_xps_result.cs](./create_method_accepts_svg_path_returns_memorystream_with_xps_result.cs) | Create Method Accepts Svg Path Returns Memorystream With Xps Result | XpsSaveOptions, Result.CopyTo, System.IO | Returns an XPS stream from a given SVG path. |
| [create_naming_convention_appends_output_format_suffix_to_original_svg_filename_batch_conversion.cs](./create_naming_convention_appends_output_format_suffix_to_original_svg_filename_batch_conversion.cs) | Create Naming Convention Appends Output Format Suffix To Original Svg Filename Batch Conversion | PdfSaveOptions, Directory.GetFiles, Console.WriteLine | Adds format suffix to output filenames during batch conversion. |
| [create_naming_pattern_includes_conversion_timestamp_saving_bmp_files_from_svg_sources.cs](./create_naming_pattern_includes_conversion_timestamp_saving_bmp_files_from_svg_sources.cs) | Create Naming Pattern Includes Conversion Timestamp Saving Bmp Files From Svg Sources | ImageFormat.Bmp, DateTime.Now, ImageSaveOptions | Uses timestamp in BMP filenames. |
| [create_naming_scheme_adds_sequential_numbers_to_tiff_files_generated_from_svg_folder.cs](./create_naming_scheme_adds_sequential_numbers_to_tiff_files_generated_from_svg_folder.cs) | Create Naming Scheme Adds Sequential Numbers To Tiff Files Generated From Svg Folder | Directory.GetFiles, Path.Combine, Console.WriteLine | Sequential numbering for TIFF outputs. |
| [create_pdfsaveoptions_custom_page_width_height_pdf_conversion.cs](./create_pdfsaveoptions_custom_page_width_height_pdf_conversion.cs) | Create Pdfsaveoptions Custom Page Width Height Pdf Conversion | Length.FromInches, PdfSaveOptions, Page | Sets custom page dimensions for PDF output. |
| [create_powershell_function_wraps_dotnet_converter_api_svg_to_jpeg_conversion_quality_parameter.cs](./create_powershell_function_wraps_dotnet_converter_api_svg_to_jpeg_conversion_quality_parameter.cs) | Create Powershell Function Wraps Dotnet Converter Api Svg To Jpeg Conversion Quality Parameter | ImageFormat.Jpeg, ImageSaveOptions, Converter.ConvertSVG | Exposes conversion as a PowerShell function with quality control. |
| [create_reusable_utility_class_encapsulating_svg_to_xps_conversion_configurable_save_options.cs](./create_reusable_utility_class_encapsulating_svg_to_xps_conversion_configurable_save_options.cs) | Create Reusable Utility Class Encapsulating Svg To Xps Conversion Configurable Save Options | SvgToXpsConverter.Convert, XpsSaveOptions, Color.AliceBlue | Utility class for SVG → XPS with custom options. |
| [create_unit_test_verifies_svg_to_xps_conversion_produces_non_empty_xps_file_stream.cs](./create_unit_test_verifies_svg_to_xps_conversion_produces_non_empty_xps_file_stream.cs) | Create Unit Test Verifies Svg To Xps Conversion Produces Non Empty Xps File Stream | File.WriteAllText, XpsSaveOptions, FileMode.Open | Unit test that checks XPS stream is not empty. |
| [develop_rest_endpoint_receives_svg_data_returns_pdf_using_in_memory_conversion.cs](./develop_rest_endpoint_receives_svg_data_returns_pdf_using_in_memory_conversion.cs) | Develop Rest Endpoint Receives Svg Data Returns Pdf Using In Memory Conversion | PdfSaveOptions, File.WriteAllBytes, Console.WriteLine | ASP.NET endpoint that converts posted SVG to PDF in memory. |
| [dispose_svgdocument_associated_streams_after_conversion_prevent_memory_leaks.cs](./dispose_svgdocument_associated_streams_after_conversion_prevent_memory_leaks.cs) | Dispose Svgdocument Associated Streams After Conversion Prevent Memory Leaks | SVGDocument, Converter.ConvertSVG, PdfSaveOptions | Demonstrates proper disposal of `SVGDocument`. |
| [embed_fonts_in_pdfsaveoptions_during_svg_to_pdf_conversion_for_consistent_text_appearance.cs](./embed_fonts_in_pdfsaveoptions_during_svg_to_pdf_conversion_for_consistent_text_appearance.cs) | Embed Fonts In Pdfsaveoptions During Svg To Pdf Conversion For Consistent Text Appearance | PdfSaveOptions, FontEmbeddingMode, Converter.ConvertSVG | Embeds fonts into PDF output. |
| [enable_high_compression_in_image_save_options_when_generating_bmp_for_archival_purposes.cs](./enable_high_compression_in_image_save_options_when_generating_bmp_for_archival_purposes.cs) | Enable High Compression In Image Save Options When Generating Bmp For Archival Purposes | ImageFormat.Bmp, Compression.Rle, Converter.ConvertHTML | Uses RLE compression for BMP archival. |
| [generate_docx_document_from_svg_image_using_converter_with_appropriate_save_options.cs](./generate_docx_document_from_svg_image_using_converter_with_appropriate_save_options.cs) | Generate Docx Document From Svg Image Using Converter With Appropriate Save Options | DocSaveOptions, Path.Combine, Aspose.Html | Converts SVG to DOCX with proper options. |
| [handle_conversion_exceptions_wrap_converter_convertsvg_calls_try_catch_log_errors.cs](./handle_conversion_exceptions_wrap_converter_convertsvg_calls_try_catch_log_errors.cs) | Handle Conversion Exceptions Wrap Converter Convertsvg Calls Try Catch Log Errors | Converters.Converter, ImageFormat.Jpeg, ImageSaveOptions | Centralised exception handling for SVG conversion. |
| [implement_batch_conversion_multiple_svg_files_to_png_store_results_zip_archive.cs](./implement_batch_conversion_multiple_svg_files_to_png_store_results_zip_archive.cs) | Implement Batch Conversion Multiple Svg Files To PNG Store Results Zip Archive | SVGDocument, Path.GetFileNameWithoutExtension, File.Exists | Converts many SVGs to PNG and zips the results. |
| [implement_error_handling_around_converter_convertsvg_to_catch_and_log_conversion_failures_for_svg_inputs.cs](./implement_error_handling_around_converter_convertsvg_to_catch_and_log_conversion_failures_for_svg_inputs.cs) | Implement Error Handling Around Converter Convertsvg To Catch And Log Conversion Failures For Svg Inputs | Converter.ConvertSVG, Console.WriteLine, ImageFormat.Jpeg | Logs failures per file during batch conversion. |
| [implement_progress_reporter_for_batch_svg_to_docx_conversion_showing_percentage_completed.cs](./implement_progress_reporter_for_batch_svg_to_docx_conversion_showing_percentage_completed.cs) | Implement Progress Reporter For Batch Svg To Docx Conversion Showing Percentage Completed | DocSaveOptions, Files.Length, Console.WriteLine | Simple console progress indicator. |
| [implement_progress_reporter_svg_to_gif_conversion_showing_file_name_index.cs](./implement_progress_reporter_svg_to_gif_conversion_showing_file_name_index.cs) | Implement Progress Reporter Svg To Gif Conversion Showing File Name Index | Directory.CreateDirectory, Files.Length, Path.GetFileName | Reports file name and index during GIF batch conversion. |
| [implement_progress_reporter_svg_to_tiff_batch_conversion_indicating_compression_level_per_file.cs](./implement_progress_reporter_svg_to_tiff_batch_conversion_indicating_compression_level_per_file.cs) | Implement Progress Reporter Svg To Tiff Batch Conversion Indicating Compression Level Per File | Directory.CreateDirectory, Files.Length, Path.GetFileName | Shows compression level per TIFF file. |
| [implement_progress_reporter_updates_after_each_svg_file_converted_to_bmp_in_batch_operation.cs](./implement_progress_reporter_updates_after_each_svg_file_converted_to_bmp_in_batch_operation.cs) | Implement Progress Reporter Updates After Each Svg File Converted To Bmp In Batch Operation | System.Drawing, Files.Length, Path.GetFileName | BMP batch conversion progress. |
| [implement_progress_reporter_updates_percentage_completed_batch_svg_to_png_conversion.cs](./implement_progress_reporter_updates_percentage_completed_batch_svg_to_png_conversion.cs) | Implement Progress Reporter Updates Percentage Completed Batch Svg To Png Conversion | System.Drawing, Files.Length, Path.GetFileName | PNG batch conversion progress. |
| [implement_retry_policy_wait_two_seconds_between_attempts_svg_to_gif_conversion_failures.cs](./implement_retry_policy_wait_two_seconds_between_attempts_svg_to_gif_conversion_failures.cs) | Implement Retry Policy Wait Two Seconds Between Attempts Svg To Gif Conversion Failures | Rendering.Image, Thread.Sleep, ImageSaveOptions | Simple retry with 2‑second delay on GIF conversion failures. |
| [implement_stream_provider_direct_svg_conversion_output_network_stream_remote_storage.cs](./implement_stream_provider_direct_svg_conversion_output_network_stream_remote_storage.cs) | Implement Stream Provider Direct Svg Conversion Output Network Stream Remote Storage | PdfSaveOptions, NetworkStreamProvider, Console.WriteLine | Streams conversion result directly to a network location. |
| [leverage_default_save_options_quickly_convert_svg_to_xps_without_additional_parameters.cs](./leverage_default_save_options_quickly_convert_svg_to_xps_without_additional_parameters.cs) | Leverage Default Save Options Quickly Convert Svg To Xps Without Additional Parameters | Converter.ConvertSVG, XpsSaveOptions, Aspose.Html | Minimal code path for SVG → XPS. |
| [load_svg_document_from_stream_using_memorystream.cs](./load_svg_document_from_stream_using_memorystream.cs) | Load Svg Document From Stream Using Memorystream | Encoding.UTF8, SVGDocument, Console.WriteLine | Loads SVG from a `MemoryStream`. |
| [load_svg_file_from_local_file_system_for_conversion.cs](./load_svg_file_from_local_file_system_for_conversion.cs) | Load Svg File From Local File System For Conversion | Aspose.Html, Dom.Svg, SVGDocument | Simple file‑system load of an SVG. |
| [load_svg_file_from_local_path_into_svgdocument_instance.cs](./load_svg_file_from_local_path_into_svgdocument_instance.cs) | Load Svg File From Local Path Into Svgdocument Instance | Aspose.Html, Dom.Svg, SVGDocument | Same as above with explicit path handling. |
| [load_svg_from_local_path_and_convert_to_xps_with_custom_page_dimensions.cs](./load_svg_from_local_path_and_convert_to_xps_with_custom_page_dimensions.cs) | Load Svg From Local Path And Convert To Xps With Custom Page Dimensions | XpsSaveOptions, System.Drawing, Color.AliceBlue | Sets custom page size for XPS output. |
| [load_svg_from_memory_stream_convert_to_bmp_using_image_save_options.cs](./load_svg_from_memory_stream_convert_to_bmp_using_image_save_options.cs) | Load Svg From Memory Stream Convert To Bmp Using Image Save Options | ImageFormat.Bmp, File.ReadAllBytes, Console.WriteLine | Memory‑stream based BMP conversion. |
| [load_svg_from_url_and_convert_to_docx_with_custom_docsaveoptions.cs](./load_svg_from_url_and_convert_to_docx_with_custom_docsaveoptions.cs) | Load Svg From Url And Convert To Docx With Custom Docsaveoptions | DocSaveOptions, HttpClient, Console.WriteLine | Downloads SVG via HTTP and converts to DOCX. |
| [log_conversion_parameters_source_path_target_format_duration_json.cs](./log_conversion_parameters_source_path_target_format_duration_json.cs) | Log Conversion Parameters Source Path Target Format Duration Json | File.WriteAllText, Stopwatch.StartNew, System.Diagnostics | Writes conversion metadata to a JSON file. |
| [log_each_svg_gif_conversion_recording_output_file_size_applied_image_quality_settings.cs](./log_each_svg_gif_conversion_recording_output_file_size_applied_image_quality_settings.cs) | Log Each Svg Gif Conversion Recording Output File Size Applied Image Quality Settings | Path.GetFileName, FileInfo, Directory.GetFiles | Logs GIF file size and quality used. |
| [log_successful_svg_to_bmp_conversion_source_destination_file_paths_audit_purposes.cs](./log_successful_svg_to_bmp_conversion_source_destination_file_paths_audit_purposes.cs) | Log Successful Svg To Bmp Conversion Source Destination File Paths Audit Purposes | ImageFormat.Bmp, Path.GetFullPath, ImageSaveOptions | Audits successful BMP conversions. |
| [log_svg_to_docx_conversion_including_page_count_and_custom_docsaveoptions_applied.cs](./log_svg_to_docx_conversion_including_page_count_and_custom_docsaveoptions_applied.cs) | Log Svg To Docx Conversion Including Page Count And Custom Docsaveoptions Applied | DocSaveOptions, SVGDocument, Aspose.HTML | Logs DOCX conversion details. |
| [log_svg_to_tiff_conversion_noting_compression_type_and_file_dimensions.cs](./log_svg_to_tiff_conversion_noting_compression_type_and_file_dimensions.cs) | Log Svg To Tiff Conversion Noting Compression Type And File Dimensions | Image.FromFile, Compression.None, Path.GetFileNameWithoutExtension | Records TIFF compression and dimensions. |
| [measure_conversion_performance_svg_to_tiff_different_compression_settings_large_dataset.cs](./measure_conversion_performance_svg_to_tiff_different_compression_settings_large_dataset.cs) | Measure Conversion Performance Svg To Tiff Different Compression Settings Large Dataset | Directory.CreateDirectory, Stopwatch.StartNew, System.Diagnostics | Benchmarks TIFF conversion across compression schemes. |
| [measure_conversion_time_converting_100_svg_files_to_bmp_stopwatch_log_results.cs](./measure_conversion_time_converting_100_svg_files_to_bmp_stopwatch_log_results.cs) | Measure Conversion Time Converting 100 Svg Files To Bmp Stopwatch Log Results | Converters.Converter, System.Drawing, Files.Length | Times bulk BMP conversion of 100 files. |
| [provide_custom_istreamprovider_receive_pdf_output_memory.cs](./provide_custom_istreamprovider_receive_pdf_output_memory.cs) | Provide Custom Istreamprovider Receive Pdf Output Memory | PdfSaveOptions, Converter.ConvertHTML, Console.WriteLine | Custom stream provider for PDF output. |
| [set_imagesaveoptions_background_color_to_white_when_converting_svg_to_jpeg.cs](./set_imagesaveoptions_background_color_to_white_when_converting_svg_to_jpeg.cs) | Set Imagesaveoptions Background Color To White When Converting Svg To Jpeg | System.Drawing, ImageFormat.Jpeg, SVGDocument | Forces white background for JPEG output. |
| [set_imagesaveoptions_color_depth_8_bits_gif_output_reduce_file_size.cs](./set_imagesaveoptions_color_depth_8_bits_gif_output_reduce_file_size.cs) | Set Imagesaveoptions Color Depth 8 Bits Gif Output Reduce File Size | Rendering.Image, ImageSaveOptions, Console.WriteLine | Reduces GIF color depth to 8‑bit. |
| [set_imagesaveoptions_dpi_300_high_resolution_png_printing_applications.cs](./set_imagesaveoptions_dpi_300_high_resolution_png_printing_applications.cs) | Set Imagesaveoptions Dpi 300 High Resolution Png Printing Applications | Converter.ConvertHTML, ImageSaveOptions, Console.WriteLine | Sets 300 DPI for PNG suitable for print. |
| [set_imagesaveoptions_jpeg_quality_to_95_percent_for_high_resolution_jpeg_output.cs](./set_imagesaveoptions_jpeg_quality_to_95_percent_for_high_resolution_jpeg_output.cs) | Set Imagesaveoptions Jpeg Quality To 95 Percent For High Resolution Jpeg Output | ImageFormat.Jpeg, ImageSaveOptions, Aspose.HTML | JPEG quality set to 95 %. |
| [set_imagesaveoptions_transparency_true_converting_svg_to_png_alpha_channel.cs](./set_imagesaveoptions_transparency_true_converting_svg_to_png_alpha_channel.cs) | Set Imagesaveoptions Transparency True Converting Svg To Png Alpha Channel | Color.Transparent, ImageSaveOptions, Aspose.Html | Enables alpha channel for PNG output. |
| [set_image_compression_to_jpeg_quality_80_for_embedded_raster_images.cs](./set_image_compression_to_jpeg_quality_80_for_embedded_raster_images.cs) | Set Image Compression To Jpeg Quality 80 For Embedded Raster Images | PdfSaveOptions, Converter.ConvertHTML, HTMLDocument | JPEG quality 80 for raster images inside PDFs. |
| [set_image_save_options_jpeg_quality_85_percent_before_converting_svg_to_jpg.cs](./set_image_save_options_jpeg_quality_85_percent_before_converting_svg_to_jpg.cs) | Set Image Save Options Jpeg Quality 85 Percent Before Converting Svg To Jpg | ImageFormat.Jpeg, ImageSaveOptions, Aspose.Html | JPEG quality 85 % before conversion. |
| [set_xps_save_options_custom_page_margin_configuration_svg_documents_irregular_dimensions.cs](./set_xps_save_options_custom_page_margin_configuration_svg_documents_irregular_dimensions.cs) | Set Xps Save Options Custom Page Margin Configuration Svg Documents Irregular Dimensions | XpsSaveOptions, SVGDocument, Page | Custom margins for irregular‑size SVGs in XPS. |
| [specify_bits_per_pixel_24_image_save_options_true_color_bmp_output.cs](./specify_bits_per_pixel_24_image_save_options_true_color_bmp_output.cs) | Specify Bits Per Pixel 24 Image Save Options True Color Bmp Output | ImageFormat.Bmp, ImageSaveOptions, Aspose.Html | 24‑bpp true‑color BMP output. |
| [specify_xpssaveoptions_enable_lossless_compression_converting_svg_graphics_xps_documents.cs](./specify_xpssaveoptions_enable_lossless_compression_converting_svg_graphics_xps_documents.cs) | Specify Xpssaveoptions Enable Lossless Compression Converting Svg Graphics Xps Documents | XpsSaveOptions, Converter.ConvertSVG, Aspose.Html | Lossless compression for XPS. |
| [svg_to_bmp_conversion_with_specified_pixel_format_adjusting_parameters.cs](./svg_to_bmp_conversion_with_specified_pixel_format_adjusting_parameters.cs) | Svg To Bmp Conversion With Specified Pixel Format Adjusting Parameters | ImageFormat.Bmp, ImageSaveOptions, Converter.ConvertSVG | BMP conversion with custom pixel format. |
| [test_svg_to_xps_conversion_quickly_by_sending_file_to_online_converter_endpoint.cs](./test_svg_to_xps_conversion_quickly_by_sending_file_to_online_converter_endpoint.cs) | Test Svg To Xps Conversion Quickly By Sending File To Online Converter Endpoint | Converter.ConvertSVG, XpsSaveOptions, Aspose.Html | Sends SVG to a remote service for XPS conversion. |
| [transform_svg_to_high_resolution_tiff_using_custom_dpi_settings_converter.cs](./transform_svg_to_high_resolution_tiff_using_custom_dpi_settings_converter.cs) | Transform Svg To High Resolution Tiff Using Custom Dpi Settings Converter | SVGDocument, Compression.None, ImageSaveOptions | High‑DPI TIFF generation from SVG. |
| [unit_tests_verify_svg_to_png_conversion_expected_dimensions.cs](./unit_tests_verify_svg_to_png_conversion_expected_dimensions.cs) | Unit Tests Verify Svg To Png Conversion Expected Dimensions | Image.FromFile, System.Drawing, Aspose.HTML | Unit test asserting PNG dimensions. |
| [use_filestream_write_xps_output_directly_to_network_share_with_appropriate_permissions.cs](./use_filestream_write_xps_output_directly_to_network_share_with_appropriate_permissions.cs) | Use Filestream Write Xps Output Directly To Network Share With Appropriate Permissions | XpsSaveOptions, FileAccess.Write, Generic.List | Writes XPS directly to a network share. |
| [use_static_converter_convertsvg_sourcepath_destinationpath_one_line_svg_to_pdf.cs](./use_static_converter_convertsvg_sourcepath_destinationpath_one_line_svg_to_pdf.cs) | Use Static Converter Convertsvg Sourcepath Destinationpath One Line Svg To Pdf | Saving.PdfSaveOptions, Converter.ConvertSVG, Aspose.Html | One‑liner SVG → PDF conversion. |
| [using_block_ensure_filestream_disposal_after_writing_converted_xps_data_to_disk.cs](./using_block_ensure_filestream_disposal_after_writing_converted_xps_data_to_disk.cs) | Using Block Ensure Filestream Disposal After Writing Converted Xps Data To Disk | XpsSaveOptions, FileMode.CreateNew, FileAccess.Write | Demonstrates proper `using` for file streams. |
| [write_method_svg_paths_dictionary_mapping_to_xps_byte_array.cs](./write_method_svg_paths_dictionary_mapping_to_xps_byte_array.cs) | Write Method Svg Paths Dictionary Mapping To Xps Byte Array | XpsSaveOptions, File.ReadAllBytes, Guid.NewGuid | Returns XPS as a byte array from a dictionary of paths. |
| [write_wrapper_function_abstracts_converter_convertsvg_calls_for_different_target_formats.cs](./write_wrapper_function_abstracts_converter_convertsvg_calls_for_different_target_formats.cs) | Write Wrapper Function Abstracts Converter Convertsvg Calls For Different Target Formats | DocSaveOptions, XpsSaveOptions, TargetFormat.Pdf, Console.WriteLine | Wrapper that selects target format. |

*(All 105 files are listed above.)*

---

## Category‑Specific Tips

### Key API Surface
- **Conversion Core**: `Converter.ConvertSVG`, `Converter.ConvertHTML`
- **Save Options**: `ImageSaveOptions`, `PdfSaveOptions`, `XpsSaveOptions`, `DocSaveOptions`
- **Document Model**: `SVGDocument`, `HTMLDocument`
- **Compression & Quality**: `Compression.*`, `ImageFormat.*`, `ImageSaveOptions.JpegQuality`, `ImageSaveOptions.DpiX/Y`
- **File & Path Utilities**: `Path.Combine`, `Directory.GetFiles`, `File.ReadAllBytes`, `File.WriteAllBytes`
- **Diagnostics**: `Console.WriteLine`, `Stopwatch`, `System.Diagnostics`

### Rules
1. **Always dispose** `SVGDocument` / `HTMLDocument` and any `FileStream`/`MemoryStream` after conversion.  
2. **Match output format** with the correct `ImageFormat` or specific `SaveOptions` class; mismatched options cause runtime errors.  
3. **Set DPI / ColorDepth** *before* conversion when high‑resolution or archival output is required.  
4. **Use explicit compression** (`Compression.LZW`, `Compression.CCITT3`, etc.) for TIFF to control file size.  
5. **Log** source path, target path, duration, and any option overrides – essential for batch jobs.  
6. **Validate file existence** (`File.Exists` / `Directory.Exists`) before invoking the converter to avoid `FileNotFoundException`.  
7. **When handling Unicode or spaces** in file names, use `Path.GetFullPath` and avoid manual string concatenation.  
8. **For XPS/PDF**, embed fonts (`FontEmbeddingMode`) if the downstream consumer must preserve exact typography.  
9. **Batch loops** should reuse a single `ImageSaveOptions` instance when settings are identical to reduce allocation overhead.  
10. **Error handling**: wrap each `Convert*` call in `try/catch`, log `ex.Message` and continue processing other files.

---

## Warnings

- **Template/Data Binding Mismatch** – If a template expects placeholders that are not supplied, the conversion may succeed but the output will contain raw tokens.  
- **Missing Resources** – External CSS, fonts, or images referenced by the SVG must be reachable; otherwise rendering falls back to defaults or fails.  
- **File‑Path Issues** – Relative paths are resolved against the current working directory; use `Path.GetFullPath` to avoid surprises on different machines.  
- **Memory Pressure** – Converting large SVGs or high‑resolution images in a tight loop can exhaust memory; dispose documents promptly and consider streaming (`IStreamProvider`).  
- **Unsupported Features** – Certain SVG filters or animations are not fully supported in PDF/XPS output; verify the result visually.  
- **Thread Safety** – The static `Converter` methods are thread‑safe, but shared `SaveOptions` instances are **not**; create a fresh options object per thread.

---

## Guidelines for Adding New Examples

1. **Self‑contained** – Include all `using` statements, create any temporary directories, and clean up resources at the end of `Main`.  
2. **Console Logging** – Begin with `Console.WriteLine("Starting …")` and end with a success/failure message; this aligns with existing examples.  
3. **Follow the Common Pattern** – Load → (optional bind) → Convert → (optional render) → Log.  
4. **Naming Convention** – File name should be *PascalCase* with underscores separating logical words, e.g., `Convert_Svg_To_Jpeg_With_Custom_Quality.cs`.  
5. **Update Statistics** – When a new file is added, increment `total_examples` and, if new namespaces or APIs are introduced, add them to the respective tables.  
6. **Documentation** – Keep the `summary` concise but specific; avoid generic “Demonstrates a specific Aspose.HTML operation.”  
7. **Testing** – If the example introduces a new API surface, add a corresponding unit test under the `tests` folder.  

---