---
name: data_extraction
description: C# examples for data_extraction using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – data_extraction

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **data_extraction** category.
This folder contains standalone C# examples for data_extraction operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: `data_extraction`  
- **Total examples**: **81**  
- **Typical workflow**:  
  1. **Load** – Retrieve an HTML document from a file, URL or string (`new HTMLDocument(...)`).  
  2. **Bind / Traverse** – Use DOM traversal, CSS selectors or XPath to locate elements (`Document.QuerySelectorAll`, `XPath`, `Dom.Traversal`).  
  3. **Convert / Extract** – Pull attributes, inner/outer HTML, text content, or binary resources (`Element.GetAttribute`, `Element.OuterHTML`, `Content.ReadAsByteArray`).  
  4. **Render / Save** – Persist extracted data, download resources, or re‑save the page (`HTMLSaveOptions`, `File.WriteAllBytes`, `Console.WriteLine`).

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | Core .NET types |
| Aspose.Html | Primary HTML processing API |
| Aspose.Html.Dom | DOM manipulation (elements, nodes) |
| System.IO | File and path handling |
| Aspose.Html.Collections | Collection helpers for DOM |
| Aspose.Html.Net | Network utilities (`Context.Network`) |
| Aspose.Html.Saving | Save options and resource handling |
| System.Net.Http | HTTP request/response (`Content.ReadAsByteArray`) |
| System.Collections.Generic | Generic collections |
| Aspose.Html.Dom.XPath | XPath evaluation |
| Aspose.Html.Dom.Traversal | Tree traversal utilities |
| Aspose.Html.Dom.Traversal.Filters | Custom node filters |
| System.Threading.Tasks | Async/await patterns |
| Aspose.Html.Dom.Svg | SVG DOM support |
| System.Threading | Thread‑level control |
| System.Text | Encoding utilities |
| Aspose.Html.Services | Service‑related helpers |
| System.Security.Cryptography | Hashing for duplicate detection |
| System.Text.Json | JSON serialization |
| Aspose.Html.Rendering | Rendering engines |
| Aspose.Html.Rendering.Pdf | PDF rendering |
| System.Drawing | Image handling |
| Aspose.Html.Saving.ResourceHandlers | Resource handling extensions |
| System.Net | Low‑level networking |
| System.Diagnostics | Diagnostics and logging |
| System.Collections.Concurrent | Thread‑safe collections |
| Aspose.Html.Converters | Format conversion helpers |
| Aspose.Html.IO | I/O abstractions |
| Aspose.Html.Rendering.Image | Image rendering |

### How to import them

```csharp
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Drawing;

using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Collections;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Services;
using Aspose.Html.Converters;
using Aspose.Html.IO;
```

---

## Common Code Pattern

Below is a representative skeleton that appears in many examples – loading a page, extracting data, and persisting the result.

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Net;

class DataExtractionDemo
{
    static void Main()
    {
        // 1️⃣ Load – remote or local HTML document
        var url = new Uri("https://example.com");
        var document = new HTMLDocument(url);

        // 2️⃣ Bind / Traverse – locate all <img> elements
        var images = document.Images; // HTMLCollection of <img>
        foreach (Element img in images)
        {
            // 3️⃣ Convert / Extract – get the absolute URL of the image
            var src = img.GetAttribute("src");
            var absoluteUrl = new Url(src, document.BaseUri).ToString();

            // 4️⃣ Render / Save – download the image and write to disk
            var response = Context.Network.GetResponse(new RequestMessage(absoluteUrl));
            var bytes = response.Content.ReadAsByteArray();

            var fileName = Path.GetFileName(absoluteUrl);
            var outputPath = Path.Combine("output", fileName);
            Directory.CreateDirectory("output");
            File.WriteAllBytes(outputPath, bytes);

            Console.WriteLine($"Saved image: {outputPath}");
        }

        // Optional: re‑save the modified document
        var saveOptions = new HTMLSaveOptions();
        document.Save("output/modified_page.html", saveOptions);
        Console.WriteLine("Document saved.");
    }
}
```

*Key points demonstrated*:

* `HTMLDocument` construction from a `Uri`.
* DOM traversal via collection properties (`document.Images`).
* URL resolution with `Url` class.
* Network download using `Context.Network`.
* Binary handling with `Content.ReadAsByteArray`.
* File I/O (`Path`, `Directory`, `File`).
* Console logging (`Console.WriteLine`).

---

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Console.WriteLine | 81 |
| Aspose.Html | 79 |
| HTMLDocument | 62 |
| System.IO | 27 |
| Url | 17 |
| Path.Combine | 14 |
| Directory.CreateDirectory | 14 |
| Path.GetFileName | 13 |
| StringComparison.OrdinalIgnoreCase | 11 |
| Content.ReadAsByteArray | 11 |
| Context.Network | 11 |
| File.WriteAllBytes | 11 |
| Url.ToString | 10 |
| System.Net | 10 |
| HTMLSaveOptions | 10 |
| ResourceHandlingOptions.MaxHandlingDepth | 10 |
| System.Collections | 10 |
| Element.GetAttribute | 9 |
| HttpClient | 9 |
| RequestMessage | 8 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [Access Document Images Collection Iterate All Img Elements](./access_document_images_collection_iterate_all_img_elements.cs) | Access Document Images Collection Iterate All Img Elements | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Access Document Links Collection Iterate All Icon Link Elements](./access_document_links_collection_iterate_all_icon_link_elements.cs) | Access Document Links Collection Iterate All Icon Link Elements | Element.Href, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [Access Document Svg Elements Collection Iterate All Inline Svg Elements](./access_document_svg_elements_collection_iterate_all_inline_svg_elements.cs) | Access Document Svg Elements Collection Iterate All Inline Svg Elements | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Add Cli Flag Skip Downloading Existing Files Output Directory](./add_cli_flag_skip_downloading_existing_files_output_directory.cs) | Add Cli Flag Skip Downloading Existing Files Output Directory | Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [Allow User Cancel Batch Extraction Cancellationtoken Source](./allow_user_cancel_batch_extraction_cancellationtoken_source.cs) | Allow User Cancel Batch Extraction Cancellationtoken Source | HTMLDocument, Console.WriteLine, Rendering.Pdf | Creates or manipulates an HTML document. |
| [Apply Custom Nodefilter Excluding Display None Nodes During Dom Traversal](./apply_custom_nodefilter_excluding_display_none_nodes_during_dom_traversal.cs) | Apply Custom Nodefilter Excluding Display None Nodes During Dom Traversal | Console.WriteLine, OnlyVisibleFilter, NodeFilter.SHOW_ALL | Creates or manipulates an HTML document. |
| [Apply Custom Nodefilter Extract Script Tags Ignore Other Elements](./apply_custom_nodefilter_extract_script_tags_ignore_other_elements.cs) | Apply Custom Nodefilter Extract Script Tags Ignore Other Elements | Console.WriteLine, Aspose.HTML, NodeFilter.SHOW_ALL | Creates or manipulates an HTML document. |
| [Apply Custom Nodefilter Include Nodes Inner Html Length Over 200 Characters](./apply_custom_nodefilter_include_nodes_inner_html_length_over_200_characters.cs) | Apply Custom Nodefilter Include Nodes Inner Html Length Over 200 Characters | Console.WriteLine, InnerHTML.Length, NodeFilter.SHOW_ELEMENT | Creates or manipulates an HTML document. |
| [Apply Retry Logic Exponential Backoff Failed Download Attempts](./apply_retry_logic_exponential_backoff_failed_download_attempts.cs) | Apply Retry Logic Exponential Backoff Failed Download Attempts | Net.ResponseMessage, Console.WriteLine, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [Batch Download Files From List Of Urls Naming Each File Based On Original Filename](./batch_download_files_from_list_of_urls_naming_each_file_based_on_original_filename.cs) | Batch Download Files From List Of Urls Naming Each File Based On Original Filename | Console.WriteLine, System.IO, Path.GetFileName | Creates or manipulates an HTML document. |
| [Build Command Line Interface Accepts Target Urls Extracts All Supported Resources](./build_command_line_interface_accepts_target_urls_extracts_all_supported_resources.cs) | Build Command Line Interface Accepts Target Urls Extracts All Supported Resources | HTMLDocument, Element.GetAttribute, Url.ToString | Creates or manipulates an HTML document. |
| [Cli Option Limit Maximum Number Resources Extracted Per Page](./cli_option_limit_maximum_number_resources_extracted_per_page.cs) | Cli Option Limit Maximum Number Resources Extracted Per Page | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [Configure Custom Httpclient Headers User Agent String Before Downloading Resources](./configure_custom_httpclient_headers_user_agent_string_before_downloading_resources.cs) | Configure Custom Httpclient Headers User Agent String Before Downloading Resources | Console.WriteLine, Headers.Add, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [Configure Htmlsaveoptions Exclude Javascript Files Saving Website Static Analysis](./configure_htmlsaveoptions_exclude_javascript_files_saving_website_static_analysis.cs) | Configure Htmlsaveoptions Exclude Javascript Files Saving Website Static Analysis | Console.WriteLine, ResourceHandlingOptions.JavaScript, Saving.HTMLSaveOptions | Creates or manipulates an HTML document. |
| [Configure Resource Handling Restrict Saved Resources Same Domain Source Page](./configure_resource_handling_restrict_saved_resources_same_domain_source_page.cs) | Configure Resource Handling Restrict Saved Resources Same Domain Source Page | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, ResourceHandlingOptions.PageUrlRestriction | Creates or manipulates an HTML document. |
| [Create Requestmessage Custom Headers Download Image File From Url](./create_requestmessage_custom_headers_download_image_file_from_url.cs) | Create Requestmessage Custom Headers Download Image File From Url | Console.WriteLine, System.IO, Headers.Add | Creates or manipulates an HTML document. |
| [Detect Duplicate External Svg Files By Comparing Content Hashes Before Saving](./detect_duplicate_external_svg_files_by_comparing_content_hashes_before_saving.cs) | Detect Duplicate External Svg Files By Comparing Content Hashes Before Saving | System.Collections, Encoding.UTF8, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Download Pdf File From Given Url Using Requestmessage Save With Responsemessage](./download_pdf_file_from_given_url_using_requestmessage_save_with_responsemessage.cs) | Download Pdf File From Given Url Using Requestmessage Save With Responsemessage | Console.WriteLine, System.IO, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [Extract Content Attribute Meta Tags Viewport Via Css Selector](./extract_content_attribute_meta_tags_viewport_via_css_selector.cs) | Extract Content Attribute Meta Tags Viewport Via Css Selector | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Extract Email Addresses From Webpage Selecting Anchor Tags With Href Containing Mailto](./extract_email_addresses_from_webpage_selecting_anchor_tags_with_href_containing_mailto.cs) | Extract Email Addresses From Webpage Selecting Anchor Tags With Href Containing Mailto | System.Collections, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [Extract Open Graph Title Property From Page Using Xpath Store Csv File](./extract_open_graph_title_property_from_page_using_xpath_store_csv_file.cs) | Extract Open Graph Title Property From Page Using Xpath Store Csv File | StreamWriter, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Extract Text Content All List Items Within Navigation Menu Css Selector](./extract_text_content_all_list_items_within_navigation_menu_css_selector.cs) | Extract Text Content All List Items Within Navigation Menu Css Selector | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Extract Website Icons Defined By Link Rel Icon Save As Ico](./extract_website_icons_defined_by_link_rel_icon_save_as_ico.cs) | Extract Website Icons Defined By Link Rel Icon Save As Ico | Name.EndsWith, HTMLDocument, Element.GetAttribute | Creates or manipulates an HTML document. |
| [Filter Dom Nodes Include Only Elements With Data Id Attribute Using Custom Nodefilter](./filter_dom_nodes_include_only_elements_with_data_id_attribute_using_custom_nodefilter.cs) | Filter Dom Nodes Include Only Elements With Data Id Attribute Using Custom Nodefilter | DataIdFilter, Console.WriteLine, NodeFilter.SHOW_ALL | Creates or manipulates an HTML document. |
| [Filter Extracted Images By Png Jpg Extension Before Download](./filter_extracted_images_by_png_jpg_extension_before_download.cs) | Filter Extracted Images By Png Jpg Extension Before Download | HTMLDocument, Element.GetAttribute, Url.ToString | Creates or manipulates an HTML document. |
| [Filter Extracted Images Minimum Width Height Before Saving](./filter_extracted_images_minimum_width_height_before_saving.cs) | Filter Extracted Images Minimum Width Height Before Saving | StringComparison.OrdinalIgnoreCase, Path.GetFileName, Client.GetByteArrayAsync | Creates or manipulates an HTML document. |
| [Flatten Extracted Files Into Single Output Folder Ignoring Original Website Paths](./flatten_extracted_files_into_single_output_folder_ignoring_original_website_paths.cs) | Flatten Extracted Files Into Single Output Folder Ignoring Original Website Paths | Console.WriteLine, System.IO, Path.GetFileName | Demonstrates a specific Aspose.HTML operation. |
| [Generate Csv Report Listing Each Extracted Resource Type Url Local Path](./generate_csv_report_listing_each_extracted_resource_type_url_local_path.cs) | Generate Csv Report Listing Each Extracted Resource Type Url Local Path | Handler.Resources, HTMLSaveOptions, OutputUrl.ToString | Creates or manipulates an HTML document. |
| [Generate List External Resource Urls Referenced In Page Using Xpath Save To Csv](./generate_list_external_resource_urls_referenced_in_page_using_xpath_save_to_csv.cs) | Generate List External Resource Urls Referenced In Page Using Xpath Save To Csv | StreamWriter, System.Collections, Console.WriteLine | Creates or manipulates an HTML document. |
| [Generate Seo Report Extracting Title Meta Description Heading Hierarchy From Webpage](./generate_seo_report_extracting_title_meta_description_heading_hierarchy_from_webpage.cs) | Generate Seo Report Extracting Title Meta Description Heading Hierarchy From Webpage | TextContent.Trim, System.Collections, Children.Add | Creates or manipulates an HTML document. |
| [Honor Base Tag When Constructing Absolute Urls Resource Download](./honor_base_tag_when_constructing_absolute_urls_resource_download.cs) | Honor Base Tag When Constructing Absolute Urls Resource Download | Element.GetAttribute, Url.ToString, Console.WriteLine | Creates or manipulates an HTML document. |
| [Identify External Svg Files Referenced By Img Tags Download To Local Storage](./identify_external_svg_files_referenced_by_img_tags_download_to_local_storage.cs) | Identify External Svg Files Referenced By Img Tags Download To Local Storage | Uri.TryCreate, File.WriteAllBytesAsync, System.Threading | Creates or manipulates an HTML document. |
| [Implement Asynchronous Download Resources Using Async Await Each Page](./implement_asynchronous_download_resources_using_async_await_each_page.cs) | Implement Asynchronous Download Resources Using Async Await Each Page | Console.WriteLine, Aspose.HTML, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [Implement Custom Nodefilter Including Only Anchor Elements Collect Link Nodes](./implement_custom_nodefilter_including_only_anchor_elements_collect_link_nodes.cs) | Implement Custom Nodefilter Including Only Anchor Elements Collect Link Nodes | OnlyAnchorFilter, System.Collections, Console.WriteLine | Creates or manipulates an HTML document. |
| [Implement Error Handling For Requestmessage Failures When Downloading Files From Invalid Urls](./implement_error_handling_for_requestmessage_failures_when_downloading_files_from_invalid_urls.cs) | Implement Error Handling For Requestmessage Failures When Downloading Files From Invalid Urls | Console.WriteLine, Content.ReadAsByteArray, Url | Creates or manipulates an HTML document. |
| [Iterate Through Sibling Nodes Of Selected Element And Log Each Node Outer Html](./iterate_through_sibling_nodes_of_selected_element_and_log_each_node_outer_html.cs) | Iterate Through Sibling Nodes Of Selected Element And Log Each Node Outer Html | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Load Html Document Count Number Of Heading Elements H1 To H3 Using Xpath](./load_html_document_count_number_of_heading_elements_h1_to_h3_using_xpath.cs) | Load Html Document Count Number Of Heading Elements H1 To H3 Using Xpath | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |
| [Load Html Document From Remote Url And Extract All Hyperlink Urls With Css Selector](./load_html_document_from_remote_url_and_extract_all_hyperlink_urls_with_css_selector.cs) | Load Html Document From Remote Url And Extract All Hyperlink Urls With Css Selector | Console.WriteLine, Url, Aspose.Html | Creates or manipulates an HTML document. |
| [Load Html Document Normalize Whitespace Text Nodes Save Cleaned Markup](./load_html_document_normalize_whitespace_text_nodes_save_cleaned_markup.cs) | Load Html Document Normalize Whitespace Text Nodes Save Cleaned Markup | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Load Html Document Remove Comment Nodes Save Cleaned Page Locally](./load_html_document_remove_comment_nodes_save_cleaned_page_locally.cs) | Load Html Document Remove Comment Nodes Save Cleaned Page Locally | Console.WriteLine, Aspose.Html, Nodes.Length | Creates or manipulates an HTML document. |
| [Load Html Document Replace Relative Image Urls With Absolute Urls Save Updated File](./load_html_document_replace_relative_image_urls_with_absolute_urls_save_updated_file.cs) | Load Html Document Replace Relative Image Urls With Absolute Urls Save Updated File | Url.ToString, Uri.IsWellFormedUriString, Console.WriteLine | Creates or manipulates an HTML document. |
| [Load Html File Extract Image Source Attributes Selecting Img Tags Css Selector](./load_html_file_extract_image_source_attributes_selecting_img_tags_css_selector.cs) | Load Html File Extract Image Source Attributes Selecting Img Tags Css Selector | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Load Local Html File Retrieve Page Title Using Xpath Expression](./load_local_html_file_retrieve_page_title_using_xpath_expression.cs) | Load Local Html File Retrieve Page Title Using Xpath Expression | Element.TextContent, Console.WriteLine, XPathResultType.Any | Creates or manipulates an HTML document. |
| [Log Errors Encountered During Resource Download To Dedicated Error Log File](./log_errors_encountered_during_resource_download_to_dedicated_error_log_file.cs) | Log Errors Encountered During Resource Download To Dedicated Error Log File | Configuration, HTMLDocument, System.Collections | Creates or manipulates an HTML document. |
| [Log Summary Extracted Resources Including Type And File Path After Extraction](./log_summary_extracted_resources_including_type_and_file_path_after_extraction.cs) | Log Summary Extracted Resources Including Type And File Path After Extraction | File.AppendAllText, File.WriteAllText, Console.WriteLine | Creates or manipulates an HTML document. |
| [Navigate From Document Element To Head Section And List All Linked Stylesheet Urls](./navigate_from_document_element_to_head_section_and_list_all_linked_stylesheet_urls.cs) | Navigate From Document Element To Head Section And List All Linked Stylesheet Urls | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Open Web Page Using Aspose Html Document And Extract Raster Images From Img Tags](./open_web_page_using_aspose_html_document_and_extract_raster_images_from_img_tags.cs) | Open Web Page Using Aspose Html Document And Extract Raster Images From Img Tags | Url.ToString, Console.WriteLine, Aspose.HTML | Creates or manipulates an HTML document. |
| [Parse Html String Collect Text All Paragraph Elements Using Xpath](./parse_html_string_collect_text_all_paragraph_elements_using_xpath.cs) | Parse Html String Collect Text All Paragraph Elements Using Xpath | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |
| [Perform Http Get Request Retrieve Json Data From Api Endpoint Store Response](./perform_http_get_request_retrieve_json_data_from_api_endpoint_store_response.cs) | Perform Http Get Request Retrieve Json Data From Api Endpoint Store Response | Encoding.UTF8, Console.WriteLine, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [Preserve Original Website Directory Hierarchy When Saving Extracted Resources Locally](./preserve_original_website_directory_hierarchy_when_saving_extracted_resources_locally.cs) | Preserve Original Website Directory Hierarchy When Saving Extracted Resources Locally | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [Process List Of Web Page Urls From Text File And Extract Resources From Each Page](./process_list_of_web_page_urls_from_text_file_and_extract_resources_from_each_page.cs) | Process List Of Web Page Urls From Text File And Extract Resources From Each Page | TextContent.Trim, System.Collections, Element.GetAttribute | Creates or manipulates an HTML document. |
| [Programmatically Download Each Extracted Resource Efficiently Using Aspose Html Network Utilities](./programmatically_download_each_extracted_resource_efficiently_using_aspose_html_network_utilities.cs) | Programmatically Download Each Extracted Resource Efficiently Using Aspose Html Network Utilities | Net.ResponseMessage, Console.WriteLine, Aspose.HTML | Creates or manipulates an HTML document. |
| [Raise Progress Events After Each Resource Downloaded Report Extraction Status](./raise_progress_events_after_each_resource_downloaded_report_extraction_status.cs) | Raise Progress Events After Each Resource Downloaded Report Extraction Status | Configuration, ResourceProgressHandler, Console.WriteLine | Creates or manipulates an HTML document. |
| [Resolve Protocol Relative Urls To Absolute Urls Using Url Class](./resolve_protocol_relative_urls_to_absolute_urls_using_url_class.cs) | Resolve Protocol Relative Urls To Absolute Urls Using Url Class | Console.WriteLine, Url, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Resolve Relative Urls To Absolute Using Url Class And Document Baseuri](./resolve_relative_urls_to_absolute_using_url_class_and_document_baseuri.cs) | Resolve Relative Urls To Absolute Using Url Class And Document Baseuri | Element.GetAttribute, Url.ToString, Console.WriteLine | Creates or manipulates an HTML document. |
| [Restrict Saved Resources Whitelist Domains Using Restricted Resource Urls Before Saving](./restrict_saved_resources_whitelist_domains_using_restricted_resource_urls_before_saving.cs) | Restrict Saved Resources Whitelist Domains Using Restricted Resource Urls Before Saving | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, ResourceHandlingOptions.PageUrlRestriction | Creates or manipulates an HTML document. |
| [Retrieve Inline Svg Markup Via Outerhtml And Write Each To Separate Svg File](./retrieve_inline_svg_markup_via_outerhtml_and_write_each_to_separate_svg_file.cs) | Retrieve Inline Svg Markup Via Outerhtml And Write Each To Separate Svg File | Console.WriteLine, Element.OuterHTML, SVGDocument | Creates or manipulates an HTML document. |
| [Retrieve Inner Text Of First Paragraph Inside Div With Specific Class Using Xpath](./retrieve_inner_text_of_first_paragraph_inside_div_with_specific_class_using_xpath.cs) | Retrieve Inner Text Of First Paragraph Inside Div With Specific Class Using Xpath | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |
| [Save Each Downloaded External Svg File To Output Folder With Svg Extension](./save_each_downloaded_external_svg_file_to_output_folder_with_svg_extension.cs) | Save Each Downloaded External Svg File To Output Folder With Svg Extension | UriPartial.Path, Uri, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Save Each Downloaded Image To Specified Output Folder Preserving Original Filenames](./save_each_downloaded_image_to_specified_output_folder_preserving_original_filenames.cs) | Save Each Downloaded Image To Specified Output Folder Preserving Original Filenames | File.WriteAllBytesAsync, Uri, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Save Each Extracted Icon To Output Folder With Appropriate Ico Extension](./save_each_extracted_icon_to_output_folder_with_appropriate_ico_extension.cs) | Save Each Extracted Icon To Output Folder With Appropriate Ico Extension | Name.EndsWith, Uri, Console.WriteLine | Creates or manipulates an HTML document. |
| [Save Each Extracted Inline Svg Markup To Svg File Preserving Original Markup](./save_each_extracted_inline_svg_markup_to_svg_file_preserving_original_markup.cs) | Save Each Extracted Inline Svg Markup To Svg File Preserving Original Markup | Console.WriteLine, Element.OuterHTML, SVGDocument | Creates or manipulates an HTML document. |
| [Save Entire Website To Directory Limiting Depth To Two Levels Using Htmlsaveoptions](./save_entire_website_to_directory_limiting_depth_to_two_levels_using_htmlsaveoptions.cs) | Save Entire Website To Directory Limiting Depth To Two Levels Using Htmlsaveoptions | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [Save Remote Html Page To Disk After Modifying Title Element Using Dom Manipulation](./save_remote_html_page_to_disk_after_modifying_title_element_using_dom_manipulation.cs) | Save Remote Html Page To Disk After Modifying Title Element Using Dom Manipulation | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Save Single Page Htmlsaveoptions Embed All Css Resources Inline Offline Viewing](./save_single_page_htmlsaveoptions_embed_all_css_resources_inline_offline_viewing.cs) | Save Single Page Htmlsaveoptions Embed All Css Resources Inline Offline Viewing | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [Save Single Webpage To Local Folder With Default Htmlsaveoptions And Verify File Creation](./save_single_webpage_to_local_folder_with_default_htmlsaveoptions_and_verify_file_creation.cs) | Save Single Webpage To Local Folder With Default Htmlsaveoptions And Verify File Creation | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [Save Website Preserving Original Folder Structure Using Html Save Options](./save_website_preserving_original_folder_structure_using_html_save_options.cs) | Save Website Preserving Original Folder Structure Using Html Save Options | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [Save Website With Max Handling Depth Zero Capture Only Entry Page](./save_website_with_max_handling_depth_zero_capture_only_entry_page.cs) | Save Website With Max Handling Depth Zero Capture Only Entry Page | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [Select Nodes Using Xpath To Retrieve All Table Rows In Html Table](./select_nodes_using_xpath_to_retrieve_all_table_rows_in_html_table.cs) | Select Nodes Using Xpath To Retrieve All Table Rows In Html Table | Cells.Length, Console.WriteLine, Document.SelectNodes | Creates or manipulates an HTML document. |
| [Set Restricted Resource Urls Block External Javascript Files Website Saving](./set_restricted_resource_urls_block_external_javascript_files_website_saving.cs) | Set Restricted Resource Urls Block External Javascript Files Website Saving | Saving.UrlRestriction, Console.WriteLine, ResourceHandlingOptions.ResourceUrlRestriction | Creates or manipulates an HTML document. |
| [Skip Duplicate Images Comparing Sha256 Hashes Before Saving New Files](./skip_duplicate_images_comparing_sha256_hashes_before_saving_new_files.cs) | Skip Duplicate Images Comparing Sha256 Hashes Before Saving New Files | Uri.AbsolutePath, File.ReadAllBytes, Uri.LocalPath | Creates or manipulates an HTML document. |
| [Store Extracted Resource Metadata Url Size Json Later Analysis](./store_extracted_resource_metadata_url_size_json_later_analysis.cs) | Store Extracted Resource Metadata Url Size Json Later Analysis | File.WriteAllText, Net.ResponseMessage, Console.WriteLine | Creates or manipulates an HTML document. |
| [Traverse Dom Find First Body Child Element Output Tag Name](./traverse_dom_find_first_body_child_element_output_tag_name.cs) | Traverse Dom Find First Body Child Element Output Tag Name | Console.WriteLine, Aspose.Html, Dom.Element | Creates or manipulates an HTML document. |
| [Use Css Selectors Find All Bold Text Elements Replace Inner Html Uppercase Text](./use_css_selectors_find_all_bold_text_elements_replace_inner_html_uppercase_text.cs) | Use Css Selectors Find All Bold Text Elements Replace Inner Html Uppercase Text | InnerHTML.ToUpperInvariant, HTMLDocument, Aspose.Html | Creates or manipulates an HTML document. |
| [Use Css Selectors Find All Elements Class Highlight Change Background Color](./use_css_selectors_find_all_elements_class_highlight_change_background_color.cs) | Use Css Selectors Find All Elements Class Highlight Change Background Color | Style.BackgroundColor, HTMLDocument, Aspose.Html | Creates or manipulates an HTML document. |
| [Use Css Selectors Locate All Video Tags Retrieve Source Urls Further Processing](./use_css_selectors_locate_all_video_tags_retrieve_source_urls_further_processing.cs) | Use Css Selectors Locate All Video Tags Retrieve Source Urls Further Processing | Console.WriteLine, Aspose.Html, Url.ToString | Creates or manipulates an HTML document. |
| [Use Document Queryselectorall Locate Elements With Style Attribute Containing Color Red Change To Blue](./use_document_queryselectorall_locate_elements_with_style_attribute_containing_color_red_change_to_blue.cs) | Use Document Queryselectorall Locate Elements With Style Attribute Containing Color Red Change To Blue | Console.WriteLine, Style.Color, Document.QuerySelectorAll | Creates or manipulates an HTML document. |
| [Use Document Queryselectorall With Css Selector To Obtain All List Items Inside Ordered Lists](./use_document_queryselectorall_with_css_selector_to_obtain_all_list_items_inside_ordered_lists.cs) | Use Document Queryselectorall With Css Selector To Obtain All List Items Inside Ordered Lists | Console.WriteLine, Items.Length, Document.QuerySelectorAll | Creates or manipulates an HTML document. |
| [Use Pageurlrestriction Allow Only Https Urls When Saving Multi Page Website](./use_pageurlrestriction_allow_only_https_urls_when_saving_multi_page_website.cs) | Use Pageurlrestriction Allow Only Https Urls When Saving Multi Page Website | ResourceHandlingOptions.MaxHandlingDepth, Saving.UrlRestriction, Console.WriteLine | Creates or manipulates an HTML document. |
| [Use Parallel Foreach Process Multiple Pages Concurrently Respecting Thread Safety](./use_parallel_foreach_process_multiple_pages_concurrently_respecting_thread_safety.cs) | Use Parallel Foreach Process Multiple Pages Concurrently Respecting Thread Safety | System.Collections, Parallel.ForEach, Interlocked.Increment | Demonstrates a specific Aspose.HTML operation. |
| [Use Xpath Select Table Cells Containing Numeric Values And Calculate Sum Programmatically](./use_xpath_select_table_cells_containing_numeric_values_and_calculate_sum_programmatically.cs) | Use Xpath Select Table Cells Containing Numeric Values And Calculate Sum Programmatically | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |

---

## Category‑Specific Tips

### Key API Surface
* **HTMLDocument** – central object for loading and saving pages.  
* **Dom Traversal / XPath / CSS selectors** – `Document.QuerySelectorAll`, `Dom.Traversal`, `XPathResultType`.  
* **Resource handling** – `HTMLSaveOptions`, `ResourceHandlingOptions.*`, `Saving.URLRestriction`.  
* **Network utilities** – `Context.Network`, `RequestMessage`, `ResponseMessage`, `Content.ReadAsByteArray`.  
* **File I/O** – `Path`, `Directory`, `File`, `Console.WriteLine` for logging.

### Rules
1. **Always resolve URLs** with `new Url(relativeOrAbsolute, document.BaseUri)` before downloading.  
2. **Limit depth** via `ResourceHandlingOptions.MaxHandlingDepth` to avoid runaway crawling.  
3. **Filter early** – apply custom `NodeFilter` or simple string checks (`StringComparison.OrdinalIgnoreCase`) to reduce unnecessary network calls.  
4. **Dispose network responses** (`using var response = ...`) to free sockets.  
5. **Log every step** – `Console.WriteLine` is the de‑facto logger in examples; replace with a proper logger in production.  
6. **Validate file names** (`Path.GetFileName`) to prevent path‑traversal attacks.  
7. **Handle duplicates** – compute hashes (`System.Security.Cryptography`) before writing files.  

---

## Warnings

* **Template‑binding mismatches** – if you modify the DOM (e.g., change `innerHTML`) without updating related selectors, later traversals may fail.  
* **Missing resources** – external URLs that return 404 will cause `Context.Network` to throw; always wrap calls in try/catch.  
* **File‑path issues** – using user‑provided URLs directly in `Path.Combine` can create invalid or unsafe paths.  
* **Memory pressure** – loading very large pages or many binary resources at once can exhaust memory; prefer streaming (`ResponseMessage.Content.ReadAsStream`) when possible.  
* **Thread‑safety** – `HTMLDocument` instances are **not** thread‑safe; create a separate document per parallel task.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – the snippet must compile on its own (include `using` statements, `Main` method, and any required NuGet references).  
2. **Console logging** – use `Console.WriteLine` to output key steps and results.  
3. **Follow the common pattern** – load → locate → extract → save/download.  
4. **Naming** – file name and `title` should be PascalCase with underscores separating logical parts (e.g., `Extract_Images_From_Page_Using_Css_Selector.cs`).  
5. **Update statistics** – after adding a file, increment `total_examples` and the relevant namespace/API counts in the repository’s metadata.  
---
