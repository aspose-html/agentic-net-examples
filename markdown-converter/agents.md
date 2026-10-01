---
name: markdown-converter
description: C# examples for Markdown Converter using Aspose.HTML for .NET
language: csharp
framework: net10.0
parent: ../agents.md
---

# AGENTS - Markdown Converter

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET,
working within the **Markdown Converter** category.
This folder contains standalone C# examples for Markdown Converter operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

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
| [add_command_line_option_specify_custom_pdf_save_options_json_file_overrides_default_pdf_conversion_settings.cs](./add_command_line_option_specify_custom_pdf_save_options_json_file_overrides_default_pdf_conversion_settings.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Add a command‑line option to specify custom PdfSaveOptions JSON file that overrides defaul... |
| [add_configuration_flag_enable_disable_intermediate_html_file_generation_conversion_pipelines.cs](./add_configuration_flag_enable_disable_intermediate_html_file_generation_conversion_pipelines.cs) | `Converter`, `Configuration` | Add a configuration flag to enable or disable intermediate HTML file generation during con... |
| [add_support_converting_markdown_files_in_subfolders_recursively_scanning_directories_batch_processing.cs](./add_support_converting_markdown_files_in_subfolders_recursively_scanning_directories_batch_processing.cs) | `MarkdownSaveOptions` | Add support for converting Markdown files located in subfolders by recursively scanning di... |
| [apply_custom_color_palette_imagesaveoptions_converting_markdown_to_gif.cs](./apply_custom_color_palette_imagesaveoptions_converting_markdown_to_gif.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions` | Apply a custom color palette in ImageSaveOptions when converting Markdown to GIF format. |
| [apply_custom_pdf_metadata_author_title_using_pdfsaveoptions_before_conversion.cs](./apply_custom_pdf_metadata_author_title_using_pdfsaveoptions_before_conversion.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `Converter` | Apply custom PDF metadata such as author and title using PdfSaveOptions before conversion. |
| [apply_custom_resolution_setting_imagesaveoptions_converting_markdown_to_gif_images.cs](./apply_custom_resolution_setting_imagesaveoptions_converting_markdown_to_gif_images.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions` | Apply a custom resolution setting in ImageSaveOptions when converting Markdown to GIF imag... |
| [apply_imagesaveoptions_specify_background_color_converting_markdown_to_bmp_image.cs](./apply_imagesaveoptions_specify_background_color_converting_markdown_to_bmp_image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Apply ImageSaveOptions to specify background color when converting Markdown to a BMP image... |
| [batch_conversion_of_all_markdown_files_in_folder_to_pdf_using_foreach_loop.cs](./batch_conversion_of_all_markdown_files_in_folder_to_pdf_using_foreach_loop.cs) | `PdfSaveOptions`, `MarkdownSaveOptions`, `Converter` | Perform batch conversion of all Markdown files in a folder to PDF using a foreach loop. |
| [batch_convert_all_markdown_files_in_folder_to_jpeg_images_uniform_quality.cs](./batch_convert_all_markdown_files_in_folder_to_jpeg_images_uniform_quality.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Batch convert all Markdown files in a folder to JPEG images applying a uniform quality lev... |
| [batch_convert_markdown_files_to_xps_preserving_original_file_timestamps_output.cs](./batch_convert_markdown_files_to_xps_preserving_original_file_timestamps_output.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `Converter` | Batch convert Markdown files to XPS while preserving original file timestamps in the outpu... |
| [batch_process_set_markdown_files_each_to_tiff_with_lossless_compression.cs](./batch_process_set_markdown_files_each_to_tiff_with_lossless_compression.cs) | `MarkdownSaveOptions` | Batch process a set of Markdown files, converting each to TIFF with lossless compression e... |
| [configure_docsaveoptions_embed_fonts_docx_output_consistent_rendering_across_platforms.cs](./configure_docsaveoptions_embed_fonts_docx_output_consistent_rendering_across_platforms.cs) | `HTMLSaveOptions` | Configure DocSaveOptions to embed fonts in the DOCX output for consistent rendering across... |
| [configure_image_save_options_jpeg_output_and_convert_html_document_to_image.cs](./configure_image_save_options_jpeg_output_and_convert_html_document_to_image.cs) | `ImageSaveOptions`, `HTMLSaveOptions`, `Converter`, `HTMLDocument` | Configure ImageSaveOptions for JPEG output and convert an HTML document to an image. |
| [configure_pdf_encryption_password_pdfsaveoptions_password_protect_generated_pdf_unauthorized_access.cs](./configure_pdf_encryption_password_pdfsaveoptions_password_protect_generated_pdf_unauthorized_access.cs) | `PdfSaveOptions`, `HTMLSaveOptions` | Configure PDF encryption password via PdfSaveOptions.Password to protect the generated PDF... |
| [convert_collection_markdown_strings_individual_png_files_parallel_processing.cs](./convert_collection_markdown_strings_individual_png_files_parallel_processing.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Convert a collection of Markdown strings to individual PNG files using parallel processing... |
| [convert_html_content_to_svg_using_svgsaveoptions.cs](./convert_html_content_to_svg_using_svgsaveoptions.cs) | `SVGDocument`, `HTMLSaveOptions`, `Converter` | Convert HTML content to SVG using SvgSaveOptions. |
| [convert_large_markdown_file_to_bmp_using_streaming_avoid_high_memory_consumption.cs](./convert_large_markdown_file_to_bmp_using_streaming_avoid_high_memory_consumption.cs) | `MarkdownSaveOptions`, `Converter` | Convert a large Markdown file to BMP format using streaming to avoid high memory consumpti... |
| [convert_markdown_document_to_html_and_save_result_to_memory_stream_for_further_processing.cs](./convert_markdown_document_to_html_and_save_result_to_memory_stream_for_further_processing.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown document to HTML and save the result to a memory stream for further pro... |
| [convert_markdown_document_with_code_blocks_to_html_preserving_syntax_highlighting.cs](./convert_markdown_document_with_code_blocks_to_html_preserving_syntax_highlighting.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown document containing code blocks to an HTML file preserving syntax highl... |
| [convert_markdown_file_to_gif_animation_frame_rate_limit_image_save_options.cs](./convert_markdown_file_to_gif_animation_frame_rate_limit_image_save_options.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Convert a Markdown file to GIF format while limiting the animation frame rate using ImageS... |
| [convert_markdown_string_directly_to_html_using_convertmarkdown_argument.cs](./convert_markdown_string_directly_to_html_using_convertmarkdown_argument.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown string directly to HTML by calling ConvertMarkdown with the string argu... |
| [convert_markdown_string_to_html_and_export_as_tiff_with_compression.cs](./convert_markdown_string_to_html_and_export_as_tiff_with_compression.cs) | `MarkdownSaveOptions`, `Converter` | Convert a Markdown string to HTML and then export the result as a TIFF file with compressi... |
| [convert_markdown_to_docx_with_page_size_and_orientation_via_docsaveoptions_pagesetup.cs](./convert_markdown_to_docx_with_page_size_and_orientation_via_docsaveoptions_pagesetup.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions`, `PdfRenderingOptions`, `Converter` | Convert Markdown to DOCX while setting page size and orientation via DocSaveOptions PageSe... |
| [convert_markdown_to_html_and_render_with_html_document_api_as_bmp_image.cs](./convert_markdown_to_html_and_render_with_html_document_api_as_bmp_image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter`, `HTMLDocument` | Convert Markdown to HTML and then use the HTMLDocument API to render it as a BMP image. |
| [convert_markdown_to_html_apply_css_styling_save_output_as_png_image.cs](./convert_markdown_to_html_apply_css_styling_save_output_as_png_image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Convert Markdown to HTML, apply CSS styling, and then save the output as a PNG image. |
| [convert_markdown_to_png_with_transparent_background_using_image_save_options.cs](./convert_markdown_to_png_with_transparent_background_using_image_save_options.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Convert Markdown to PNG with transparent background by configuring ImageSaveOptions approp... |
| [create_command_line_tool_accepts_input_markdown_path_output_format_arguments_conversion.cs](./create_command_line_tool_accepts_input_markdown_path_output_format_arguments_conversion.cs) | `MarkdownSaveOptions`, `Converter` | Create a command‑line tool that accepts input Markdown path and output format arguments fo... |
| [create_console_application_watches_directory_converts_new_markdown_files_to_jpeg_automatically.cs](./create_console_application_watches_directory_converts_new_markdown_files_to_jpeg_automatically.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Create a console application that watches a directory and converts new Markdown files to J... |
| [create_png_image_from_markdown_using_imagesaveoptions_imageformat_png_default_compression.cs](./create_png_image_from_markdown_using_imagesaveoptions_imageformat_png_default_compression.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Create a PNG image from Markdown using ImageSaveOptions with ImageFormat.Png and default c... |
| [create_powershell_script_iterates_markdown_files_converts_each_tiff_image.cs](./create_powershell_script_iterates_markdown_files_converts_each_tiff_image.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Create a PowerShell script that iterates over Markdown files and converts each to a TIFF i... |
| [create_reusable_configuration_class_holding_default_pdf_save_options_doc_save_options_image_save_options_instances.cs](./create_reusable_configuration_class_holding_default_pdf_save_options_doc_save_options_image_save_options_instances.cs) | `HTMLSaveOptions`, `Configuration` | Create a reusable configuration class that holds default PdfSaveOptions, DocSaveOptions, a... |
| [create_reusable_extension_method_wraps_convertmarkdown_returns_htmldocument_for_further_processing.cs](./create_reusable_extension_method_wraps_convertmarkdown_returns_htmldocument_for_further_processing.cs) | `MarkdownSaveOptions`, `HTMLDocument` | Create a reusable extension method that wraps ConvertMarkdown and returns an HTMLDocument ... |
| [create_reusable_method_accepting_markdown_path_and_target_format_enum_returning_output_file_path.cs](./create_reusable_method_accepting_markdown_path_and_target_format_enum_returning_output_file_path.cs) | `MarkdownSaveOptions` | Create a reusable method that accepts a Markdown path and target format enum, returning th... |
| [create_unit_test_verifies_markdown_blockquote_conversion_to_html_then_to_png.cs](./create_unit_test_verifies_markdown_blockquote_conversion_to_html_then_to_png.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Create a unit test that verifies Markdown blockquote conversion to HTML and then to PNG. |
| [create_windows_service_converts_incoming_markdown_emails_to_png_attachments_real_time.cs](./create_windows_service_converts_incoming_markdown_emails_to_png_attachments_real_time.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Create a Windows service that converts incoming Markdown emails to PNG attachments in real... |
| [customize_font_embedding_settings_in_xps_save_options_while_converting_markdown_to_xps_format.cs](./customize_font_embedding_settings_in_xps_save_options_while_converting_markdown_to_xps_format.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Customize the font embedding settings in XpsSaveOptions while converting Markdown to XPS f... |
| [dispose_html_document_after_conversion_release_unmanaged_resources_avoid_memory_leaks.cs](./dispose_html_document_after_conversion_release_unmanaged_resources_avoid_memory_leaks.cs) | `Converter`, `HTMLDocument` | Dispose the HTMLDocument after conversion to release unmanaged resources and avoid memory ... |
| [ensure_png_images_from_markdown_minimum_300_dpi_resolution_using_image_save_options.cs](./ensure_png_images_from_markdown_minimum_300_dpi_resolution_using_image_save_options.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Ensure PNG images produced from Markdown have a minimum resolution of 300 DPI by setting I... |
| [ensure_temporary_html_files_deleted_after_final_output_saved.cs](./ensure_temporary_html_files_deleted_after_final_output_saved.cs) | `Converter` | Ensure that temporary HTML files created during conversion are deleted after the final out... |
| [export_markdown_content_as_svg_vector_graphic_using_svg_save_options_with_converthtml.cs](./export_markdown_content_as_svg_vector_graphic_using_svg_save_options_with_converthtml.cs) | `SVGDocument`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Export Markdown content as an SVG vector graphic by passing SvgSaveOptions to ConvertHTML. |
| [fine_tune_page_orientation_xps_save_options_converting_markdown_landscape_xps.cs](./fine_tune_page_orientation_xps_save_options_converting_markdown_landscape_xps.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Fine‑tune the page orientation in XpsSaveOptions when converting Markdown to landscape XPS... |
| [generate_high_quality_jpg_image_from_markdown_configuring_jpegquality_100.cs](./generate_high_quality_jpg_image_from_markdown_configuring_jpegquality_100.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Generate a high‑quality JPG image from Markdown by configuring ImageSaveOptions JpegQualit... |
| [generate_pdf_preview_markdown_to_html_to_xps_document.cs](./generate_pdf_preview_markdown_to_html_to_xps_document.cs) | `PdfSaveOptions`, `MarkdownSaveOptions`, `XpsSaveOptions` | Generate a PDF preview by converting Markdown to HTML and then to an XPS document. |
| [generate_xps_file_from_markdown_and_embed_custom_metadata.cs](./generate_xps_file_from_markdown_and_embed_custom_metadata.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Generate an XPS file from a Markdown document and embed custom metadata via XpsSaveOptions... |
| [implement_batch_conversion_markdown_to_docx_with_individual_docsaveoptions_per_file.cs](./implement_batch_conversion_markdown_to_docx_with_individual_docsaveoptions_per_file.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Implement batch conversion of Markdown files to DOCX with individual DocSaveOptions for ea... |
| [implement_command_line_parser_short_flags_output_formats_conversion_utility.cs](./implement_command_line_parser_short_flags_output_formats_conversion_utility.cs) | `Converter` | Implement a command‑line argument parser that maps short flags to output formats for the c... |
| [implement_command_line_tool_accepts_markdown_file_path_outputs_html_file.cs](./implement_command_line_tool_accepts_markdown_file_path_outputs_html_file.cs) | `MarkdownSaveOptions` | Implement a command‑line tool that accepts a Markdown file path and outputs an HTML file. |
| [implement_error_handling_for_missing_markdown_files_during_batch_conversion_to_jpeg_images.cs](./implement_error_handling_for_missing_markdown_files_during_batch_conversion_to_jpeg_images.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Implement error handling for missing Markdown files during batch conversion to JPEG images... |
| [implement_real_time_conversion_markdown_to_jpeg_wpf_application_async_methods.cs](./implement_real_time_conversion_markdown_to_jpeg_wpf_application_async_methods.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Implement real‑time conversion of Markdown to JPEG within a WPF application using async me... |
| [load_markdown_file_convert_html_embed_html_into_xps_document.cs](./load_markdown_file_convert_html_embed_html_into_xps_document.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `Converter`, `HTMLDocument` | Load a Markdown file, convert it to HTML, and embed the HTML into an XPS document. |
| [load_markdown_file_from_disk_and_convert_to_html_using_convertmarkdown.cs](./load_markdown_file_from_disk_and_convert_to_html_using_convertmarkdown.cs) | `MarkdownSaveOptions`, `Converter`, `HTMLDocument` | Load a Markdown file from disk and convert it to an HTML file using ConvertMarkdown. |
| [load_markdown_file_from_local_file_system_and_convert_to_xps_document_using_default_settings.cs](./load_markdown_file_from_local_file_system_and_convert_to_xps_document_using_default_settings.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `Converter` | Load a Markdown file from the local file system and convert it to an XPS document using de... |
| [load_markdown_string_convert_to_png_custom_dpi_image_save_options.cs](./load_markdown_string_convert_to_png_custom_dpi_image_save_options.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions`, `Converter` | Load a Markdown string and convert it to a PNG image with custom DPI using ImageSaveOption... |
| [load_multiple_markdown_documents_list_merge_single_html_output.cs](./load_multiple_markdown_documents_list_merge_single_html_output.cs) | `MarkdownSaveOptions`, `HTMLDocument` | Load multiple Markdown documents from a list and merge them into a single HTML output file... |
| [produce_xps_document_from_markdown_using_xpssaveoptions_converthtml_method.cs](./produce_xps_document_from_markdown_using_xpssaveoptions_converthtml_method.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Produce an XPS document from Markdown by supplying XpsSaveOptions to the ConvertHTML metho... |
| [real_time_conversion_markdown_stream_to_png_without_intermediate_files.cs](./real_time_conversion_markdown_stream_to_png_without_intermediate_files.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `Converter` | Perform real‑time conversion of a Markdown stream to PNG format without writing intermedia... |
| [save_html_document_as_pdf_using_pdf_save_options_convert_html.cs](./save_html_document_as_pdf_using_pdf_save_options_convert_html.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `HTMLDocument` | Save the resulting HTMLDocument as a PDF file by providing PdfSaveOptions to ConvertHTML. |
| [set_compression_level_in_imagesaveoptions_when_converting_markdown_to_png_for_web_optimization.cs](./set_compression_level_in_imagesaveoptions_when_converting_markdown_to_png_for_web_optimization.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set the compression level in ImageSaveOptions when converting Markdown to PNG for web opti... |
| [set_docx_document_language_property_via_docsaveoptions_language_to_support_localization_after_conversion.cs](./set_docx_document_language_property_via_docsaveoptions_language_to_support_localization_after_conversion.cs) | `HTMLSaveOptions`, `Converter` | Set DOCX document language property via DocSaveOptions.Language to support localization af... |
| [set_docx_page_setup_to_track_revisions_for_change_tracking.cs](./set_docx_page_setup_to_track_revisions_for_change_tracking.cs) | `HTMLSaveOptions` | Set DOCX page setup to track revisions using DocSaveOptions.TrackRevisions for change trac... |
| [set_image_dpi_150_in_image_save_options_for_png_output_balance_quality_and_file_size.cs](./set_image_dpi_150_in_image_save_options_for_png_output_balance_quality_and_file_size.cs) | `ImageSaveOptions`, `HTMLSaveOptions` | Set image DPI in ImageSaveOptions to 150 for PNG output to balance quality and file size. |
| [set_image_quality_parameter_in_imagesaveoptions_while_converting_markdown_to_jpeg_with_high_fidelity.cs](./set_image_quality_parameter_in_imagesaveoptions_while_converting_markdown_to_jpeg_with_high_fidelity.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set image quality parameter in ImageSaveOptions while converting Markdown to JPEG with hig... |
| [set_image_width_and_height_in_imagesaveoptions_when_converting_markdown_to_png.cs](./set_image_width_and_height_in_imagesaveoptions_when_converting_markdown_to_png.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set image width and height in ImageSaveOptions when converting Markdown to a PNG file. |
| [set_imagesaveoptions_backgroundcolor_to_white_avoid_transparent_backgrounds_in_jpg_images_generated_from_markdown.cs](./set_imagesaveoptions_backgroundcolor_to_white_avoid_transparent_backgrounds_in_jpg_images_generated_from_markdown.cs) | `ImageSaveOptions`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set ImageSaveOptions.BackgroundColor to white to avoid transparent backgrounds in JPG imag... |
| [set_imagesaveoptions_imageformat_to_svg_when_converting_markdown_to_svg_ensure_correct_output_type.cs](./set_imagesaveoptions_imageformat_to_svg_when_converting_markdown_to_svg_ensure_correct_output_type.cs) | `SVGDocument`, `MarkdownSaveOptions`, `HTMLSaveOptions` | Set ImageSaveOptions.ImageFormat to Svg when converting Markdown to SVG to ensure correct ... |
| [set_pdf_page_margins_top_bottom_left_right_preconversion.cs](./set_pdf_page_margins_top_bottom_left_right_preconversion.cs) | `PdfSaveOptions`, `HTMLSaveOptions`, `PdfRenderingOptions`, `Converter` | Set PDF page margins using PdfSaveOptions.MarginTop, MarginBottom, MarginLeft, and MarginR... |
| [use_aspose_html_converters_namespace_alias_to_shorten_code_references_in_large_conversion_projects.cs](./use_aspose_html_converters_namespace_alias_to_shorten_code_references_in_large_conversion_projects.cs) | `Converter` | Use the Aspose.Html.Converters namespace alias to shorten code references in large convers... |
| [use_aspose_html_converters_namespace_exclusively_keep_conversion_code_concise_avoid_fully_qualified_type_names.cs](./use_aspose_html_converters_namespace_exclusively_keep_conversion_code_concise_avoid_fully_qualified_type_names.cs) | `Converter` | Use Aspose.Html.Converters namespace exclusively to keep conversion code concise and avoid... |
| [use_imagesaveoptions_specify_color_depth_converting_markdown_to_bmp.cs](./use_imagesaveoptions_specify_color_depth_converting_markdown_to_bmp.cs) | `MarkdownSaveOptions`, `HTMLSaveOptions` | Use ImageSaveOptions to specify color depth when converting Markdown to BMP format. |
| [use_memorystream_convert_markdown_string_to_pdf_without_intermediate_files.cs](./use_memorystream_convert_markdown_string_to_pdf_without_intermediate_files.cs) | `PdfSaveOptions`, `MarkdownSaveOptions`, `Converter` | Use MemoryStream to convert a Markdown string to PDF without creating intermediate files o... |
| [use_stringreader_feed_markdown_content_directly_into_converter_output_xps_document.cs](./use_stringreader_feed_markdown_content_directly_into_converter_output_xps_document.cs) | `MarkdownSaveOptions`, `XpsSaveOptions` | Use a StringReader to feed Markdown content directly into the converter and output an XPS ... |
| [use_try_finally_block_to_guarantee_disposal_of_html_document_even_when_exception_occurs_during_conversion.cs](./use_try_finally_block_to_guarantee_disposal_of_html_document_even_when_exception_occurs_during_conversion.cs) | `Converter`, `HTMLDocument` | Use a try‑finally block to guarantee disposal of HtmlDocument even when an exception occur... |
| [use_xpssaveoptions_embed_custom_font_family_markdown_to_xps_conversion.cs](./use_xpssaveoptions_embed_custom_font_family_markdown_to_xps_conversion.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions`, `Converter` | Use XpsSaveOptions to embed a custom font family during Markdown to XPS conversion. |
| [use_xpssaveoptions_enable_document_outline_generation_converting_markdown_to_xps.cs](./use_xpssaveoptions_enable_document_outline_generation_converting_markdown_to_xps.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions` | Use XpsSaveOptions to enable document outline generation when converting Markdown to XPS. |
| [use_xpssaveoptions_set_page_size_before_converting_markdown_file_to_xps_document.cs](./use_xpssaveoptions_set_page_size_before_converting_markdown_file_to_xps_document.cs) | `MarkdownSaveOptions`, `XpsSaveOptions`, `HTMLSaveOptions`, `PdfRenderingOptions` | Use XpsSaveOptions to set page size before converting a Markdown file to an XPS document. |
| [validate_generated_html_file_reading_contents_checking_expected_heading_tags.cs](./validate_generated_html_file_reading_contents_checking_expected_heading_tags.cs) |  | Validate the generated HTML file by reading its contents and checking for expected heading... |
| [validate_intermediate_html_document_contains_expected_img_tags_before_converting_to_image_formats.cs](./validate_intermediate_html_document_contains_expected_img_tags_before_converting_to_image_formats.cs) | `ImageSaveOptions`, `HTMLDocument` | Validate that the intermediate HTMLDocument contains expected <img> tags before converting... |
| [verify_pdf_output_contains_correct_number_of_pages_opening_file_with_pdf_reader_library.cs](./verify_pdf_output_contains_correct_number_of_pages_opening_file_with_pdf_reader_library.cs) | `PdfSaveOptions` | Verify PDF output contains the correct number of pages by opening the file with a PDF read... |
| [write_utility_reads_markdown_from_stream_writes_html_output_to_another_stream.cs](./write_utility_reads_markdown_from_stream_writes_html_output_to_another_stream.cs) | `MarkdownSaveOptions` | Write a utility that reads Markdown from a stream and writes the HTML output to another st... |

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
Updated: 2026-10-01 | Examples: 79
<!-- AUTOGENERATED:END -->
