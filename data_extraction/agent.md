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
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

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
| [access_document_images_collection_iterate_all_img_elements.cs](./access_document_images_collection_iterate_all_img_elements.cs) | Access_Document_Images_Collection_Iterate_All_Img_Elements | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [access_document_links_collection_iterate_all_icon_link_elements.cs](./access_document_links_collection_iterate_all_icon_link_elements.cs) | Access_Document_Links_Collection_Iterate_All_Icon_Link_Elements | Element.Href, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [access_document_svg_elements_collection_iterate_all_inline_svg_elements.cs](./access_document_svg_elements_collection_iterate_all_inline_svg_elements.cs) | Access_Document_Svg_Elements_Collection_Iterate_All_Inline_Svg_Elements | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [add_cli_flag_skip_downloading_existing_files_output_directory.cs](./add_cli_flag_skip_downloading_existing_files_output_directory.cs) | Add_Cli_Flag_Skip_Downloading_Existing_Files_Output_Directory | Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [allow_user_cancel_batch_extraction_cancellationtoken_source.cs](./allow_user_cancel_batch_extraction_cancellationtoken_source.cs) | Allow_User_Cancel_Batch_Extraction_Cancellationtoken_Source | HTMLDocument, Console.WriteLine, Rendering.Pdf | Creates or manipulates an HTML document. |
| [apply_custom_nodefilter_excluding_display_none_nodes_during_dom_traversal.cs](./apply_custom_nodefilter_excluding_display_none_nodes_during_dom_traversal.cs) | Apply_Custom_Nodefilter_Excluding_Display_None_Nodes_During_Dom_Traversal | Console.WriteLine, OnlyVisibleFilter, NodeFilter.SHOW_ALL | Creates or manipulates an HTML document. |
| [apply_custom_nodefilter_extract_script_tags_ignore_other_elements.cs](./apply_custom_nodefilter_extract_script_tags_ignore_other_elements.cs) | Apply_Custom_Nodefilter_Extract_Script_Tags_Ignore_Other_Elements | Console.WriteLine, Aspose.HTML, NodeFilter.SHOW_ALL | Creates or manipulates an HTML document. |
| [apply_custom_nodefilter_include_nodes_inner_html_length_over_200_characters.cs](./apply_custom_nodefilter_include_nodes_inner_html_length_over_200_characters.cs) | Apply_Custom_Nodefilter_Include_Nodes_Inner_Html_Length_Over_200_Characters | Console.WriteLine, InnerHTML.Length, NodeFilter.SHOW_ELEMENT | Creates or manipulates an HTML document. |
| [apply_retry_logic_exponential_backoff_failed_download_attempts.cs](./apply_retry_logic_exponential_backoff_failed_download_attempts.cs) | Apply_Retry_Logic_Exponential_Backoff_Failed_Download_Attempts | Net.ResponseMessage, Console.WriteLine, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [batch_download_files_from_list_of_urls_naming_each_file_based_on_original_filename.cs](./batch_download_files_from_list_of_urls_naming_each_file_based_on_original_filename.cs) | Batch_Download_Files_From_List_Of_Urls_Naming_Each_File_Based_On_Original_Filename | Console.WriteLine, System.IO, Path.GetFileName | Creates or manipulates an HTML document. |
| [build_command_line_interface_accepts_target_urls_extracts_all_supported_resources.cs](./build_command_line_interface_accepts_target_urls_extracts_all_supported_resources.cs) | Build_Command_Line_Interface_Accepts_Target_Urls_Extracts_All_Supported_Resources | HTMLDocument, Element.GetAttribute, Url.ToString | Creates or manipulates an HTML document. |
| [cli_option_limit_maximum_number_resources_extracted_per_page.cs](./cli_option_limit_maximum_number_resources_extracted_per_page.cs) | Cli_Option_Limit_Maximum_Number_Resources_Extracted_Per_Page | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [configure_custom_httpclient_headers_user_agent_string_before_downloading_resources.cs](./configure_custom_httpclient_headers_user_agent_string_before_downloading_resources.cs) | Configure_Custom_Httpclient_Headers_User_Agent_String_Before_Downloading_Resources | Console.WriteLine, Headers.Add, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [configure_htmlsaveoptions_exclude_javascript_files_saving_website_static_analysis.cs](./configure_htmlsaveoptions_exclude_javascript_files_saving_website_static_analysis.cs) | Configure_Htmlsaveoptions_Exclude_Javascript_Files_Saving_Website_Static_Analysis | Console.WriteLine, ResourceHandlingOptions.JavaScript, Saving.HTMLSaveOptions | Creates or manipulates an HTML document. |
| [configure_resource_handling_restrict_saved_resources_same_domain_source_page.cs](./configure_resource_handling_restrict_saved_resources_same_domain_source_page.cs) | Configure_Resource_Handling_Restrict_Saved_Resources_Same_Domain_Source_Page | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, ResourceHandlingOptions.PageUrlRestriction | Creates or manipulates an HTML document. |
| [create_requestmessage_custom_headers_download_image_file_from_url.cs](./create_requestmessage_custom_headers_download_image_file_from_url.cs) | Create_Requestmessage_Custom_Headers_Download_Image_File_From_Url | Console.WriteLine, System.IO, Headers.Add | Creates or manipulates an HTML document. |
| [detect_duplicate_external_svg_files_by_comparing_content_hashes_before_saving.cs](./detect_duplicate_external_svg_files_by_comparing_content_hashes_before_saving.cs) | Detect_Duplicate_External_Svg_Files_By_Comparing_Content_Hashes_Before_Saving | System.Collections, Encoding.UTF8, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [download_pdf_file_from_given_url_using_requestmessage_save_with_responsemessage.cs](./download_pdf_file_from_given_url_using_requestmessage_save_with_responsemessage.cs) | Download_Pdf_File_From_Given_Url_Using_Requestmessage_Save_With_Responsemessage | Console.WriteLine, System.IO, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [extract_content_attribute_meta_tags_viewport_via_css_selector.cs](./extract_content_attribute_meta_tags_viewport_via_css_selector.cs) | Extract_Content_Attribute_Meta_Tags_Viewport_Via_Css_Selector | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [extract_email_addresses_from_webpage_selecting_anchor_tags_with_href_containing_mailto.cs](./extract_email_addresses_from_webpage_selecting_anchor_tags_with_href_containing_mailto.cs) | Extract_Email_Addresses_From_Webpage_Selecting_Anchor_Tags_With_Href_Containing_Mailto | System.Collections, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [extract_open_graph_title_property_from_page_using_xpath_store_csv_file.cs](./extract_open_graph_title_property_from_page_using_xpath_store_csv_file.cs) | Extract_Open_Graph_Title_Property_From_Page_Using_Xpath_Store_Csv_File | StreamWriter, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [extract_text_content_all_list_items_within_navigation_menu_css_selector.cs](./extract_text_content_all_list_items_within_navigation_menu_css_selector.cs) | Extract_Text_Content_All_List_Items_Within_Navigation_Menu_Css_Selector | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [extract_website_icons_defined_by_link_rel_icon_save_as_ico.cs](./extract_website_icons_defined_by_link_rel_icon_save_as_ico.cs) | Extract_Website_Icons_Defined_By_Link_Rel_Icon_Save_As_Ico | Name.EndsWith, HTMLDocument, Element.GetAttribute | Creates or manipulates an HTML document. |
| [filter_dom_nodes_include_only_elements_with_data_id_attribute_using_custom_nodefilter.cs](./filter_dom_nodes_include_only_elements_with_data_id_attribute_using_custom_nodefilter.cs) | Filter_Dom_Nodes_Include_Only_Elements_With_Data_Id_Attribute_Using_Custom_Nodefilter | DataIdFilter, Console.WriteLine, NodeFilter.SHOW_ALL | Creates or manipulates an HTML document. |
| [filter_extracted_images_by_png_jpg_extension_before_download.cs](./filter_extracted_images_by_png_jpg_extension_before_download.cs) | Filter_Extracted_Images_By_Png_Jpg_Extension_Before_Download | HTMLDocument, Element.GetAttribute, Url.ToString | Creates or manipulates an HTML document. |
| [filter_extracted_images_minimum_width_height_before_saving.cs](./filter_extracted_images_minimum_width_height_before_saving.cs) | Filter_Extracted_Images_Minimum_Width_Height_Before_Saving | StringComparison.OrdinalIgnoreCase, Path.GetFileName, Client.GetByteArrayAsync | Creates or manipulates an HTML document. |
| [flatten_extracted_files_into_single_output_folder_ignoring_original_website_paths.cs](./flatten_extracted_files_into_single_output_folder_ignoring_original_website_paths.cs) | Flatten_Extracted_Files_Into_Single_Output_Folder_Ignoring_Original_Website_Paths | Console.WriteLine, System.IO, Path.GetFileName | Demonstrates a specific Aspose.HTML operation. |
| [generate_csv_report_listing_each_extracted_resource_type_url_local_path.cs](./generate_csv_report_listing_each_extracted_resource_type_url_local_path.cs) | Generate_Csv_Report_Listing_Each_Extracted_Resource_Type_Url_Local_Path | Handler.Resources, HTMLSaveOptions, OutputUrl.ToString | Creates or manipulates an HTML document. |
| [generate_list_external_resource_urls_referenced_in_page_using_xpath_save_to_csv.cs](./generate_list_external_resource_urls_referenced_in_page_using_xpath_save_to_csv.cs) | Generate_List_External_Resource_Urls_Referenced_In_Page_Using_Xpath_Save_To_Csv | StreamWriter, System.Collections, Console.WriteLine | Creates or manipulates an HTML document. |
| [generate_seo_report_extracting_title_meta_description_heading_hierarchy_from_webpage.cs](./generate_seo_report_extracting_title_meta_description_heading_hierarchy_from_webpage.cs) | Generate_Seo_Report_Extracting_Title_Meta_Description_Heading_Hierarchy_From_Webpage | TextContent.Trim, System.Collections, Children.Add | Creates or manipulates an HTML document. |
| [honor_base_tag_when_constructing_absolute_urls_resource_download.cs](./honor_base_tag_when_constructing_absolute_urls_resource_download.cs) | Honor_Base_Tag_When_Constructing_Absolute_Urls_Resource_Download | Element.GetAttribute, Url.ToString, Console.WriteLine | Creates or manipulates an HTML document. |
| [identify_external_svg_files_referenced_by_img_tags_download_to_local_storage.cs](./identify_external_svg_files_referenced_by_img_tags_download_to_local_storage.cs) | Identify_External_Svg_Files_Referenced_By_Img_Tags_Download_To_Local_Storage | Uri.TryCreate, File.WriteAllBytesAsync, System.Threading | Creates or manipulates an HTML document. |
| [implement_asynchronous_download_resources_using_async_await_each_page.cs](./implement_asynchronous_download_resources_using_async_await_each_page.cs) | Implement_Asynchronous_Download_Resources_Using_Async_Await_Each_Page | Console.WriteLine, Aspose.HTML, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [implement_custom_nodefilter_including_only_anchor_elements_collect_link_nodes.cs](./implement_custom_nodefilter_including_only_anchor_elements_collect_link_nodes.cs) | Implement_Custom_Nodefilter_Including_Only_Anchor_Elements_Collect_Link_Nodes | OnlyAnchorFilter, System.Collections, Console.WriteLine | Creates or manipulates an HTML document. |
| [implement_error_handling_for_requestmessage_failures_when_downloading_files_from_invalid_urls.cs](./implement_error_handling_for_requestmessage_failures_when_downloading_files_from_invalid_urls.cs) | Implement_Error_Handling_For_Requestmessage_Failures_When_Downloading_Files_From_Invalid_Urls | Console.WriteLine, Content.ReadAsByteArray, Url | Creates or manipulates an HTML document. |
| [iterate_through_sibling_nodes_of_selected_element_and_log_each_node_outer_html.cs](./iterate_through_sibling_nodes_of_selected_element_and_log_each_node_outer_html.cs) | Iterate_Through_Sibling_Nodes_Of_Selected_Element_And_Log_Each_Node_Outer_Html | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [load_html_document_count_number_of_heading_elements_h1_to_h3_using_xpath.cs](./load_html_document_count_number_of_heading_elements_h1_to_h3_using_xpath.cs) | Load_Html_Document_Count_Number_Of_Heading_Elements_H1_To_H3_Using_Xpath | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |
| [load_html_document_from_remote_url_and_extract_all_hyperlink_urls_with_css_selector.cs](./load_html_document_from_remote_url_and_extract_all_hyperlink_urls_with_css_selector.cs) | Load_Html_Document_From_Remote_Url_And_Extract_All_Hyperlink_Urls_With_Css_Selector | Console.WriteLine, Url, Aspose.Html | Creates or manipulates an HTML document. |
| [load_html_document_normalize_whitespace_text_nodes_save_cleaned_markup.cs](./load_html_document_normalize_whitespace_text_nodes_save_cleaned_markup.cs) | Load_Html_Document_Normalize_Whitespace_Text_Nodes_Save_Cleaned_Markup | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [load_html_document_remove_comment_nodes_save_cleaned_page_locally.cs](./load_html_document_remove_comment_nodes_save_cleaned_page_locally.cs) | Load_Html_Document_Remove_Comment_Nodes_Save_Cleaned_Page_Locally | Console.WriteLine, Aspose.Html, Nodes.Length | Creates or manipulates an HTML document. |
| [load_html_document_replace_relative_image_urls_with_absolute_urls_save_updated_file.cs](./load_html_document_replace_relative_image_urls_with_absolute_urls_save_updated_file.cs) | Load_Html_Document_Replace_Relative_Image_Urls_With_Absolute_Urls_Save_Updated_File | Url.ToString, Uri.IsWellFormedUriString, Console.WriteLine | Creates or manipulates an HTML document. |
| [load_html_file_extract_image_source_attributes_selecting_img_tags_css_selector.cs](./load_html_file_extract_image_source_attributes_selecting_img_tags_css_selector.cs) | Load_Html_File_Extract_Image_Source_Attributes_Selecting_Img_Tags_Css_Selector | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [load_local_html_file_retrieve_page_title_using_xpath_expression.cs](./load_local_html_file_retrieve_page_title_using_xpath_expression.cs) | Load_Local_Html_File_Retrieve_Page_Title_Using_Xpath_Expression | Element.TextContent, Console.WriteLine, XPathResultType.Any | Creates or manipulates an HTML document. |
| [log_errors_encountered_during_resource_download_to_dedicated_error_log_file.cs](./log_errors_encountered_during_resource_download_to_dedicated_error_log_file.cs) | Log_Errors_Encountered_During_Resource_Download_To_Dedicated_Error_Log_File | Configuration, HTMLDocument, System.Collections | Creates or manipulates an HTML document. |
| [log_summary_extracted_resources_including_type_and_file_path_after_extraction.cs](./log_summary_extracted_resources_including_type_and_file_path_after_extraction.cs) | Log_Summary_Extracted_Resources_Including_Type_And_File_Path_After_Extraction | File.AppendAllText, File.WriteAllText, Console.WriteLine | Creates or manipulates an HTML document. |
| [navigate_from_document_element_to_head_section_and_list_all_linked_stylesheet_urls.cs](./navigate_from_document_element_to_head_section_and_list_all_linked_stylesheet_urls.cs) | Navigate_From_Document_Element_To_Head_Section_And_List_All_Linked_Stylesheet_Urls | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [open_web_page_using_aspose_html_document_and_extract_raster_images_from_img_tags.cs](./open_web_page_using_aspose_html_document_and_extract_raster_images_from_img_tags.cs) | Open_Web_Page_Using_Aspose_Html_Document_And_Extract_Raster_Images_From_Img_Tags | Url.ToString, Console.WriteLine, Aspose.HTML | Creates or manipulates an HTML document. |
| [parse_html_string_collect_text_all_paragraph_elements_using_xpath.cs](./parse_html_string_collect_text_all_paragraph_elements_using_xpath.cs) | Parse_Html_String_Collect_Text_All_Paragraph_Elements_Using_Xpath | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |
| [perform_http_get_request_retrieve_json_data_from_api_endpoint_store_response.cs](./perform_http_get_request_retrieve_json_data_from_api_endpoint_store_response.cs) | Perform_Http_Get_Request_Retrieve_Json_Data_From_Api_Endpoint_Store_Response | Encoding.UTF8, Console.WriteLine, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [preserve_original_website_directory_hierarchy_when_saving_extracted_resources_locally.cs](./preserve_original_website_directory_hierarchy_when_saving_extracted_resources_locally.cs) | Preserve_Original_Website_Directory_Hierarchy_When_Saving_Extracted_Resources_Locally | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [process_list_of_web_page_urls_from_text_file_and_extract_resources_from_each_page.cs](./process_list_of_web_page_urls_from_text_file_and_extract_resources_from_each_page.cs) | Process_List_Of_Web_Page_Urls_From_Text_File_And_Extract_Resources_From_Each_Page | TextContent.Trim, System.Collections, Element.GetAttribute | Creates or manipulates an HTML document. |
| [programmatically_download_each_extracted_resource_efficiently_using_aspose_html_network_utilities.cs](./programmatically_download_each_extracted_resource_efficiently_using_aspose_html_network_utilities.cs) | Programmatically_Download_Each_Extracted_Resource_Efficiently_Using_Aspose_Html_Network_Utilities | Net.ResponseMessage, Console.WriteLine, Aspose.HTML | Creates or manipulates an HTML document. |
| [raise_progress_events_after_each_resource_downloaded_report_extraction_status.cs](./raise_progress_events_after_each_resource_downloaded_report_extraction_status.cs) | Raise_Progress_Events_After_Each_Resource_Downloaded_Report_Extraction_Status | Configuration, ResourceProgressHandler, Console.WriteLine | Creates or manipulates an HTML document. |
| [resolve_protocol_relative_urls_to_absolute_urls_using_url_class.cs](./resolve_protocol_relative_urls_to_absolute_urls_using_url_class.cs) | Resolve_Protocol_Relative_Urls_To_Absolute_Urls_Using_Url_Class | Console.WriteLine, Url, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [resolve_relative_urls_to_absolute_using_url_class_and_document_baseuri.cs](./resolve_relative_urls_to_absolute_using_url_class_and_document_baseuri.cs) | Resolve_Relative_Urls_To_Absolute_Using_Url_Class_And_Document_Baseuri | Element.GetAttribute, Url.ToString, Console.WriteLine | Creates or manipulates an HTML document. |
| [restrict_saved_resources_whitelist_domains_using_restricted_resource_urls_before_saving.cs](./restrict_saved_resources_whitelist_domains_using_restricted_resource_urls_before_saving.cs) | Restrict_Saved_Resources_Whitelist_Domains_Using_Restricted_Resource_Urls_Before_Saving | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, ResourceHandlingOptions.PageUrlRestriction | Creates or manipulates an HTML document. |
| [retrieve_inline_svg_markup_via_outerhtml_and_write_each_to_separate_svg_file.cs](./retrieve_inline_svg_markup_via_outerhtml_and_write_each_to_separate_svg_file.cs) | Retrieve_Inline_Svg_Markup_Via_Outerhtml_And_Write_Each_To_Separate_Svg_File | Console.WriteLine, Element.OuterHTML, SVGDocument | Creates or manipulates an HTML document. |
| [retrieve_inner_text_of_first_paragraph_inside_div_with_specific_class_using_xpath.cs](./retrieve_inner_text_of_first_paragraph_inside_div_with_specific_class_using_xpath.cs) | Retrieve_Inner_Text_Of_First_Paragraph_Inside_Div_With_Specific_Class_Using_Xpath | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |
| [save_each_downloaded_external_svg_file_to_output_folder_with_svg_extension.cs](./save_each_downloaded_external_svg_file_to_output_folder_with_svg_extension.cs) | Save_Each_Downloaded_External_Svg_File_To_Output_Folder_With_Svg_Extension | UriPartial.Path, Uri, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [save_each_downloaded_image_to_specified_output_folder_preserving_original_filenames.cs](./save_each_downloaded_image_to_specified_output_folder_preserving_original_filenames.cs) | Save_Each_Downloaded_Image_To_Specified_Output_Folder_Preserving_Original_Filenames | File.WriteAllBytesAsync, Uri, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [save_each_extracted_icon_to_output_folder_with_appropriate_ico_extension.cs](./save_each_extracted_icon_to_output_folder_with_appropriate_ico_extension.cs) | Save_Each_Extracted_Icon_To_Output_Folder_With_Appropriate_Ico_Extension | Name.EndsWith, Uri, Console.WriteLine | Creates or manipulates an HTML document. |
| [save_each_extracted_inline_svg_markup_to_svg_file_preserving_original_markup.cs](./save_each_extracted_inline_svg_markup_to_svg_file_preserving_original_markup.cs) | Save_Each_Extracted_Inline_Svg_Markup_To_Svg_File_Preserving_Original_Markup | Console.WriteLine, Element.OuterHTML, SVGDocument | Creates or manipulates an HTML document. |
| [save_entire_website_to_directory_limiting_depth_to_two_levels_using_htmlsaveoptions.cs](./save_entire_website_to_directory_limiting_depth_to_two_levels_using_htmlsaveoptions.cs) | Save_Entire_Website_To_Directory_Limiting_Depth_To_Two_Levels_Using_Htmlsaveoptions | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [save_remote_html_page_to_disk_after_modifying_title_element_using_dom_manipulation.cs](./save_remote_html_page_to_disk_after_modifying_title_element_using_dom_manipulation.cs) | Save_Remote_Html_Page_To_Disk_After_Modifying_Title_Element_Using_Dom_Manipulation | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [save_single_page_htmlsaveoptions_embed_all_css_resources_inline_offline_viewing.cs](./save_single_page_htmlsaveoptions_embed_all_css_resources_inline_offline_viewing.cs) | Save_Single_Page_Htmlsaveoptions_Embed_All_Css_Resources_Inline_Offline_Viewing | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [save_single_webpage_to_local_folder_with_default_htmlsaveoptions_and_verify_file_creation.cs](./save_single_webpage_to_local_folder_with_default_htmlsaveoptions_and_verify_file_creation.cs) | Save_Single_Webpage_To_Local_Folder_With_Default_Htmlsaveoptions_And_Verify_File_Creation | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [save_website_preserving_original_folder_structure_using_html_save_options.cs](./save_website_preserving_original_folder_structure_using_html_save_options.cs) | Save_Website_Preserving_Original_Folder_Structure_Using_Html_Save_Options | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [save_website_with_max_handling_depth_zero_capture_only_entry_page.cs](./save_website_with_max_handling_depth_zero_capture_only_entry_page.cs) | Save_Website_With_Max_Handling_Depth_Zero_Capture_Only_Entry_Page | HTMLSaveOptions, ResourceHandlingOptions.MaxHandlingDepth, Console.WriteLine | Creates or manipulates an HTML document. |
| [select_nodes_using_xpath_to_retrieve_all_table_rows_in_html_table.cs](./select_nodes_using_xpath_to_retrieve_all_table_rows_in_html_table.cs) | Select_Nodes_Using_Xpath_To_Retrieve_All_Table_Rows_In_Html_Table | Cells.Length, Console.WriteLine, Document.SelectNodes | Creates or manipulates an HTML document. |
| [set_restricted_resource_urls_block_external_javascript_files_website_saving.cs](./set_restricted_resource_urls_block_external_javascript_files_website_saving.cs) | Set_Restricted_Resource_Urls_Block_External_Javascript_Files_Website_Saving | Saving.UrlRestriction, Console.WriteLine, ResourceHandlingOptions.ResourceUrlRestriction | Creates or manipulates an HTML document. |
| [skip_duplicate_images_comparing_sha256_hashes_before_saving_new_files.cs](./skip_duplicate_images_comparing_sha256_hashes_before_saving_new_files.cs) | Skip_Duplicate_Images_Comparing_Sha256_Hashes_Before_Saving_New_Files | Uri.AbsolutePath, File.ReadAllBytes, Uri.LocalPath | Creates or manipulates an HTML document. |
| [store_extracted_resource_metadata_url_size_json_later_analysis.cs](./store_extracted_resource_metadata_url_size_json_later_analysis.cs) | Store_Extracted_Resource_Metadata_Url_Size_Json_Later_Analysis | File.WriteAllText, Net.ResponseMessage, Console.WriteLine | Creates or manipulates an HTML document. |
| [traverse_dom_find_first_body_child_element_output_tag_name.cs](./traverse_dom_find_first_body_child_element_output_tag_name.cs) | Traverse_Dom_Find_First_Body_Child_Element_Output_Tag_Name | Console.WriteLine, Aspose.Html, Dom.Element | Creates or manipulates an HTML document. |
| [use_css_selectors_find_all_bold_text_elements_replace_inner_html_uppercase_text.cs](./use_css_selectors_find_all_bold_text_elements_replace_inner_html_uppercase_text.cs) | Use_Css_Selectors_Find_All_Bold_Text_Elements_Replace_Inner_Html_Uppercase_Text | InnerHTML.ToUpperInvariant, HTMLDocument, Aspose.Html | Creates or manipulates an HTML document. |
| [use_css_selectors_find_all_elements_class_highlight_change_background_color.cs](./use_css_selectors_find_all_elements_class_highlight_change_background_color.cs) | Use_Css_Selectors_Find_All_Elements_Class_Highlight_Change_Background_Color | Style.BackgroundColor, HTMLDocument, Aspose.Html | Creates or manipulates an HTML document. |
| [use_css_selectors_locate_all_video_tags_retrieve_source_urls_further_processing.cs](./use_css_selectors_locate_all_video_tags_retrieve_source_urls_further_processing.cs) | Use_Css_Selectors_Locate_All_Video_Tags_Retrieve_Source_Urls_Further_Processing | Console.WriteLine, Aspose.Html, Url.ToString | Creates or manipulates an HTML document. |
| [use_document_queryselectorall_locate_elements_with_style_attribute_containing_color_red_change_to_blue.cs](./use_document_queryselectorall_locate_elements_with_style_attribute_containing_color_red_change_to_blue.cs) | Use_Document_Queryselectorall_Locate_Elements_With_Style_Attribute_Containing_Color_Red_Change_To_Blue | Console.WriteLine, Style.Color, Document.QuerySelectorAll | Creates or manipulates an HTML document. |
| [use_document_queryselectorall_with_css_selector_to_obtain_all_list_items_inside_ordered_lists.cs](./use_document_queryselectorall_with_css_selector_to_obtain_all_list_items_inside_ordered_lists.cs) | Use_Document_Queryselectorall_With_Css_Selector_To_Obtain_All_List_Items_Inside_Ordered_Lists | Console.WriteLine, Items.Length, Document.QuerySelectorAll | Creates or manipulates an HTML document. |
| [use_pageurlrestriction_allow_only_https_urls_when_saving_multi_page_website.cs](./use_pageurlrestriction_allow_only_https_urls_when_saving_multi_page_website.cs) | Use_Pageurlrestriction_Allow_Only_Https_Urls_When_Saving_Multi_Page_Website | ResourceHandlingOptions.MaxHandlingDepth, Saving.UrlRestriction, Console.WriteLine | Creates or manipulates an HTML document. |
| [use_parallel_foreach_process_multiple_pages_concurrently_respecting_thread_safety.cs](./use_parallel_foreach_process_multiple_pages_concurrently_respecting_thread_safety.cs) | Use_Parallel_Foreach_Process_Multiple_Pages_Concurrently_Respecting_Thread_Safety | System.Collections, Parallel.ForEach, Interlocked.Increment | Demonstrates a specific Aspose.HTML operation. |
| [use_xpath_select_table_cells_containing_numeric_values_and_calculate_sum_programmatically.cs](./use_xpath_select_table_cells_containing_numeric_values_and_calculate_sum_programmatically.cs) | Use_Xpath_Select_Table_Cells_Containing_Numeric_Values_And_Calculate_Sum_Programmatically | Console.WriteLine, XPathResultType.Any, Aspose.Html | Creates or manipulates an HTML document. |

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