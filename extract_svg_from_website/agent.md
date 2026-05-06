---
name: extract_svg_from_website
description: C# examples for extract_svg_from_website using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – extract_svg_from_website

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **extract_svg_from_website** category.
This folder contains standalone C# examples for extract_svg_from_website operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: `extract_svg_from_website`
- **Total examples**: 30  
- **Typical workflow**:  
  1. **Load** an HTML page (remote URL or local file) into an `HTMLDocument`.  
  2. **Bind** – traverse the DOM, locate `<svg>` elements (inline) or `<img src="*.svg">` tags (external).  
  3. **Convert** – for inline SVGs create an `SVGDocument` from the markup; for external SVGs download the resource and load it into an `SVGDocument`.  
  4. **Render / Save** – optionally render the SVG, otherwise persist each `SVGDocument` to a file, log the operation, and update any bookkeeping structures.

---

## Required Namespaces

| Namespace                              | Usage |
|----------------------------------------|-------|
| System                                 | General purpose utilities, console I/O, collections |
| Aspose.Html                            | Core HTML processing (HTMLDocument, loading options) |
| Aspose.Html.Dom.Svg                    | SVG‑specific DOM types (`SVGDocument`, `SVGElement`) |
| Aspose.Html.Collections                | HTML collections (`HTMLCollection`) |
| System.IO                              | File system access (read/write, path handling) |
| Aspose.Html.Dom                        | General DOM manipulation (`Element`, `Document`) |
| System.Net.Http                        | HTTP client for downloading external SVGs |
| System.Collections.Generic             | Generic collections (`List<T>`, `Dictionary<TKey,TValue>`) |
| System.Threading.Tasks                | Asynchronous programming (`Task`, `async/await`) |
| Aspose.Html.Saving                     | Saving options for HTML/SVG output |
| Aspose.Html.Saving.ResourceHandlers    | Custom resource handlers (e.g., `FileSystemResourceHandler`) |
| Aspose.Html.Net                        | Network‑related helpers |
| Aspose.Html.Converters                 | Converters (e.g., HTML → PDF) |
| System.Text.Json                       | JSON handling for optional metadata |
| Aspose.Html.Dom.XPath                  | XPath queries on the DOM |
| System.Net                             | Low‑level networking utilities |

### How to import them

```csharp
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Collections;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;
using Aspose.Html.Net;
using Aspose.Html.Converters;
using Aspose.Html.Dom.XPath;
```

---

## Common Code Pattern

Below is a representative pattern that appears across most examples in this category.  
It demonstrates loading a page, extracting both **inline** and **external** SVGs, and persisting each SVG to a separate file.

```csharp
using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;

class ExtractSvgFromWebsite
{
    // Entry point
    static async Task Main(string[] args)
    {
        // 1️⃣ Load the HTML page
        string pageUrl = args.Length > 0 ? args[0] : "https://example.com";
        var htmlDoc = new HTMLDocument(pageUrl);

        // 2️⃣ Prepare a folder for the extracted SVGs
        string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "extracted_svgs");
        Directory.CreateDirectory(outputFolder);

        // 3️⃣ Extract **inline** SVG markup
        var inlineSvgs = htmlDoc.GetElementsByTagName("svg");
        int inlineIndex = 0;
        foreach (Element svgElem in inlineSvgs)
        {
            string svgMarkup = svgElem.OuterHTML;
            string filePath = Path.Combine(outputFolder, $"inline_{inlineIndex++}.svg");
            File.WriteAllText(filePath, svgMarkup);
            Console.WriteLine($"Saved inline SVG → {filePath}");
        }

        // 4️⃣ Extract **external** SVG references (<img src="*.svg"> or <object data="*.svg">)
        var imgElements = htmlDoc.Images; // HTMLCollection of <img> elements
        HttpClient http = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
        int externalIndex = 0;

        foreach (Element img in imgElements)
        {
            string src = img.GetAttribute("src");
            if (src == null || !src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                continue;

            // Resolve relative URLs against the page base URL
            Uri svgUri = new Uri(new Uri(pageUrl), src);
            try
            {
                byte[] svgBytes = await http.GetByteArrayAsync(svgUri);
                string filePath = Path.Combine(outputFolder, $"external_{externalIndex++}{Path.GetExtension(svgUri.AbsolutePath)}");
                await File.WriteAllBytesAsync(filePath, svgBytes);
                Console.WriteLine($"Downloaded external SVG → {filePath}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to download {svgUri}: {ex.Message}");
            }
        }

        // 5️⃣ Optional: load each saved file into an SVGDocument for further processing
        // foreach (var file in Directory.GetFiles(outputFolder, "*.svg"))
        // {
        //     var svgDoc = new SVGDocument(file);
        //     // …process svgDoc (e.g., render, convert, analyze)…
        // }
    }
}
```

*Key points illustrated*:

* `HTMLDocument` for page loading.  
* `GetElementsByTagName("svg")` to fetch inline SVG elements.  
* `Element.OuterHTML` to obtain raw SVG markup.  
* `HttpClient` (with timeout) for external SVG download.  
* `Path.Combine` / `Directory.CreateDirectory` for safe file handling.  
* Console logging (`Console.WriteLine`, `Console.Error.WriteLine`) for traceability.  

---

## Frequently Used APIs

| API                              | Appearances |
|----------------------------------|-------------|
| Console.WriteLine                | 29 |
| Aspose.Html                      | 28 |
| HTMLDocument                     | 17 |
| SVGDocument                      | 12 |
| Dom.Svg                          | 12 |
| System.IO                        | 11 |
| System.Collections               | 6 |
| Doc.Save                         | 6 |
| System.Threading                 | 6 |
| HttpClient                       | 5 |
| System.Net                       | 5 |
| Path.Combine                     | 5 |
| Element.OuterHTML                | 5 |
| Uri                              | 4 |
| Directory.CreateDirectory        | 4 |
| Aspose.HTML                      | 2 |
| Directory.GetCurrentDirectory    | 2 |
| System.Text                      | 2 |
| FileSystemResourceHandler        | 2 |
| Saving.ResourceHandlers          | 2 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [allow_custom_user_agent_header_httpclient_requests.cs](./allow_custom_user_agent_header_httpclient_requests.cs) | Allow_Custom_User_Agent_Header_Httpclient_Requests | Console.WriteLine, PdfSaveOptions, Converter.ConvertHTML, HttpClient | Converts HTML content to another format using Aspose.HTML. |
| [batch_process_multiple_page_urls_looping_list_applying_extraction_workflow.cs](./batch_process_multiple_page_urls_looping_list_applying_extraction_workflow.cs) | Batch_Process_Multiple_Page_Urls_Looping_List_Applying_Extraction_Workflow | TextContent.Trim, System.Collections, Children.Add, File.WriteAllText, HTMLDocument | Creates or manipulates an HTML document. |
| [cache_downloaded_external_svg_files_locally_to_avoid_redundant_network_requests.cs](./cache_downloaded_external_svg_files_locally_to_avoid_redundant_network_requests.cs) | Cache_Downloaded_External_Svg_Files_Locally_To_Avoid_Redundant_Network_Requests | Console.WriteLine, System.IO, FileSystemResourceHandler, SVGDocument, Saving.ResourceHandlers | Demonstrates a specific Aspose.HTML operation. |
| [configure_html_document_ignore_script_errors_page_loading.cs](./configure_html_document_ignore_script_errors_page_loading.cs) | Configure_Html_Document_Ignore_Script_Errors_Page_Loading | Configuration, Console.WriteLine, Sandbox.Scripts, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [create_reusable_method_accepts_page_url_returns_list_of_extracted_inline_svg_strings.cs](./create_reusable_method_accepts_page_url_returns_list_of_extracted_inline_svg_strings.cs) | Create_Reusable_Method_Accepts_Page_Url_Returns_List_Of_Extracted_Inline_Svg_Strings | HTMLDocument, System.Collections, Console.WriteLine, Element.OuterHTML, Aspose.Html | Creates or manipulates an HTML document. |
| [detect_skip_duplicate_svg_markup_outerhtml_before_writing_files.cs](./detect_skip_duplicate_svg_markup_outerhtml_before_writing_files.cs) | Detect_Skip_Duplicate_Svg_Markup_Outerhtml_Before_Writing_Files | System.Collections, Console.WriteLine, Element.OuterHTML, Markups.Add, SVGDocument | Creates or manipulates an HTML document. |
| [download_external_svg_files_httpclient_async_getasync.cs](./download_external_svg_files_httpclient_async_getasync.cs) | Download_External_Svg_Files_Httpclient_Async_Getasync | File.WriteAllBytesAsync, Uri, Guid.NewGuid, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [expose_public_api_method_returns_collection_of_file_paths_for_all_extracted_svgs_from_given_url.cs](./expose_public_api_method_returns_collection_of_file_paths_for_all_extracted_svgs_from_given_url.cs) | Expose_Public_Api_Method_Returns_Collection_Of_File_Paths_For_All_Extracted_Svgs_From_Given_Url | System.Collections, Console.WriteLine, System.IO, Directory.GetCurrentDirectory, Path.Combine | Creates or manipulates an HTML document. |
| [extract_each_inline_svg_markup_outerhtml_property.cs](./extract_each_inline_svg_markup_outerhtml_property.cs) | Extract_Each_Inline_Svg_Markup_Outerhtml_Property | Console.WriteLine, Element.OuterHTML, SVGDocument, Doc.Save, Aspose.Html | Creates or manipulates an HTML document. |
| [filter_img_collection_keep_only_elements_with_src_ending_svg.cs](./filter_img_collection_keep_only_elements_with_src_ending_svg.cs) | Filter_Img_Collection_Keep_Only_Elements_With_Src_Ending_Svg | System.Collections, Generic.List, Console.WriteLine, StringComparison.OrdinalIgnoreCase, ParentNode.RemoveChild | Creates or manipulates an HTML document. |
| [generate_summary_csv_file_listing_source_page_url_svg_type_inline_external_saved_file_name.cs](./generate_summary_csv_file_listing_source_page_url_svg_type_inline_external_saved_file_name.cs) | Generate_Summary_Csv_File_Listing_Source_Page_Url_Svg_Type_Inline_External_Saved_File_Name | StreamWriter, Console.WriteLine, Element.OuterHTML, System.IO, SVGDocument | Creates or manipulates an HTML document. |
| [identify_all_img_elements_in_dom_via_document_images.cs](./identify_all_img_elements_in_dom_via_document_images.cs) | Identify_All_Img_Elements_In_Dom_Via_Document_Images | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [implement_asynchronous_version_extraction_routine_improve_scalability.cs](./implement_asynchronous_version_extraction_routine_improve_scalability.cs) | Implement_Asynchronous_Version_Extraction_Routine_Improve_Scalability | System.IO, System.Threading, File.AppendAllTextAsync, Console.Error, Environment.NewLine | Creates or manipulates an HTML document. |
| [implement_error_handling_skip_extraction_when_html_page_cannot_be_loaded.cs](./implement_error_handling_skip_extraction_when_html_page_cannot_be_loaded.cs) | Implement_Error_Handling_Skip_Extraction_When_Html_Page_Cannot_Be_Loaded | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [implement_retry_logic_for_external_svg_downloads_transient_network_errors.cs](./implement_retry_logic_for_external_svg_downloads_transient_network_errors.cs) | Implement_Retry_Logic_For_External_Svg_Downloads_Transient_Network_Errors | Net.ResponseMessage, Console.WriteLine, System.IO, Exception, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [iterate_over_returned_svg_collection.cs](./iterate_over_returned_svg_collection.cs) | Iterate_Over_Returned_Svg_Collection | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [load_html_page_from_url_using_aspose_html_htmldocument_class.cs](./load_html_page_from_url_using_aspose_html_htmldocument_class.cs) | Load_Html_Page_From_Url_Using_Aspose_Html_Htmldocument_Class | Console.WriteLine, Aspose.HTML, Aspose.Html, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |
| [log_count_of_external_svgs_each_processed_page.cs](./log_count_of_external_svgs_each_processed_page.cs) | Log_Count_Of_External_Svgs_Each_Processed_Page | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [log_inline_svgs_count_per_processed_page.cs](./log_inline_svgs_count_per_processed_page.cs) | Log_Inline_Svgs_Count_Per_Processed_Page | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [parse_base_tag_html_document_resolve_relative_svg_urls.cs](./parse_base_tag_html_document_resolve_relative_svg_urls.cs) | Parse_Base_Tag_Html_Document_Resolve_Relative_Svg_Urls | Doc.GetElementsByTagName, Console.WriteLine, Elements.Length, Doc.DocumentElement, SVGDocument | Creates or manipulates an HTML document. |
| [provide_option_rename_saved_svg_files_pattern_including_source_page_domain_index.cs](./provide_option_rename_saved_svg_files_pattern_including_source_page_domain_index.cs) | Provide_Option_Rename_Saved_Svg_Files_Pattern_Including_Source_Page_Domain_Index | Uri, Console.WriteLine, System.IO, System.Threading, SVGDocument | Demonstrates a specific Aspose.HTML operation. |
| [resolve_relative_svg_urls_against_page_base_url_before_downloading.cs](./resolve_relative_svg_urls_against_page_base_url_before_downloading.cs) | Resolve_Relative_Svg_Urls_Against_Page_Base_Url_Before_Downloading | Console.WriteLine, SVGDocument, Doc.Save, Aspose.Html, Dom.Svg | Demonstrates a specific Aspose.HTML operation. |
| [retrieve_all_inline_svg_elements_using_getelementsbytagname_svg.cs](./retrieve_all_inline_svg_elements_using_getelementsbytagname_svg.cs) | Retrieve_All_Inline_Svg_Elements_Using_Getelementsbytagname_Svg | Console.WriteLine, Aspose.Html, Collections.HTMLCollection | Creates or manipulates an HTML document. |
| [save_each_downloaded_external_svg_to_local_file_preserving_original_file_name.cs](./save_each_downloaded_external_svg_to_local_file_preserving_original_file_name.cs) | Save_Each_Downloaded_External_Svg_To_Local_File_Preserving_Original_File_Name | Uri, Console.WriteLine, Client.GetStringAsync, System.IO, Path.GetFileName | Demonstrates a specific Aspose.HTML operation. |
| [save_each_extracted_inline_svg_markup_to_separate_svg_file_using_system_io.cs](./save_each_extracted_inline_svg_markup_to_separate_svg_file_using_system_io.cs) | Save_Each_Extracted_Inline_Svg_Markup_To_Separate_Svg_File_Using_System_Io | HTMLDocument, Console.WriteLine, Element.OuterHTML, System.IO, SVGDocument | Creates or manipulates an HTML document. |
| [set_timeout_on_httpclient_to_prevent_hanging_during_external_svg_download.cs](./set_timeout_on_httpclient_to_prevent_hanging_during_external_svg_download.cs) | Set_Timeout_On_Httpclient_To_Prevent_Hanging_During_External_Svg_Download | Console.WriteLine, TimeSpan.FromSeconds, Aspose.Html, RequestMessage, HTMLDocument | Creates or manipulates an HTML document. |
| [store_file_paths_of_saved_svgs_in_dictionary_keyed_by_source_page_url.cs](./store_file_paths_of_saved_svgs_in_dictionary_keyed_by_source_page_url.cs) | Store_File_Paths_Of_Saved_Svgs_In_Dictionary_Keyed_By_Source_Page_Url | System.Collections, Guid.NewGuid, Console.WriteLine, SVGDocument, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [use_htmlloadoptions_specify_correct_encoding_when_loading_non_utf8_html_pages.cs](./use_htmlloadoptions_specify_correct_encoding_when_loading_non_utf8_html_pages.cs) | Use_Htmlloadoptions_Specify_Correct_Encoding_When_Loading_Non_Utf8_Html_Pages | Console.WriteLine, System.IO, Encoding.GetEncoding, Path.GetDirectoryName, File.ReadAllText | Creates or manipulates an HTML document. |
| [use_webclient_fallback_when_httpclient_download_fails.cs](./use_webclient_fallback_when_httpclient_download_fails.cs) | Use_Webclient_Fallback_When_Httpclient_Download_Fails | Ex.Message, Console.WriteLine, Client.GetByteArrayAsync, System.Threading, WebClient | Demonstrates a specific Aspose.HTML operation. |
| [verify_copyright_and_usage_terms_before_reusing_extracted_svg_files.cs](./verify_copyright_and_usage_terms_before_reusing_extracted_svg_files.cs) | Verify_Copyright_And_Usage_Terms_Before_Reusing_Extracted_Svg_Files | Console.WriteLine, FileSystemResourceHandler, SVGDocument, Saving.ResourceHandlers, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |

---

## Category‑Specific Tips

### Key API Surface
- **HTMLDocument** – entry point for loading any HTML source (URL, file, stream).  
- **SVGDocument** – use when you need a full SVG DOM (e.g., to render or convert).  
- **Element.OuterHTML** – quickest way to obtain raw SVG markup from an inline `<svg>` element.  
- **HttpClient** (or **WebClient** fallback) – download external SVG resources; always set a timeout and consider retry logic.  
- **FileSystemResourceHandler** – useful when you want Aspose.HTML to resolve relative resources from a local folder.  

### Rules
1. **Always resolve relative URLs** against the page’s base URL (`new Uri(baseUri, relative)`).  
2. **Cache external SVGs** locally to avoid duplicate network calls (see the cache example).  
3. **Deduplicate** inline SVG markup before writing files – identical `OuterHTML` strings should be written once.  
4. **Wrap network calls in `try/catch`** and log failures; optionally retry on transient errors.  
5. **Use async I/O** (`await File.WriteAllBytesAsync`, `await http.GetByteArrayAsync`) for scalability when processing many pages.  
6. **Sanitize file names** (`Path.GetInvalidFileNameChars`) when persisting SVGs derived from URLs.  
7. **Dispose** `HTMLDocument`, `SVGDocument`, and `HttpClient` (or wrap them in `using` statements) to free native resources promptly.  

---

## Warnings

- **Template‑binding mismatches** – if you attempt to bind data to a non‑existent placeholder in the HTML, Aspose.HTML will throw a runtime exception. Verify placeholder names before binding.  
- **Missing resources** – external SVG URLs that return 404/403 will cause `HttpClient` exceptions; always handle `HttpRequestException`.  
- **File‑path issues** – using relative paths without a proper working directory can lead to `DirectoryNotFoundException`. Prefer `Path.Combine(Directory.GetCurrentDirectory(), …)`.  
- **Memory pressure** – loading very large HTML pages or many SVGs simultaneously can exhaust memory. Process pages sequentially or limit concurrent tasks (`SemaphoreSlim`).  
- **Encoding pitfalls** – loading non‑UTF‑8 pages without specifying `HtmlLoadOptions.Encoding` may corrupt SVG markup. Use `Encoding.GetEncoding` when needed.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – the example must compile and run without external project references beyond the namespaces listed above.  
2. **Console logging** – use `Console.WriteLine` (or `Console.Error.WriteLine` for errors) to report progress and outcomes.  
3. **Follow the common pattern** – load → locate SVGs → download/convert → save → log.  
4. **Naming conventions** – file name in *PascalCase* with underscores separating logical words, matching the title case shown in the table.  
5. **Update statistics** – after adding a new file, increment `total_examples` and adjust namespace/API counts accordingly.  

---