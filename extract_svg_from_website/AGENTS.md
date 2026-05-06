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
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

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
| [Allow Custom User Agent Header Httpclient Requests](./allow_custom_user_agent_header_httpclient_requests.cs) | Allow Custom User Agent Header Httpclient Requests | Console.WriteLine, PdfSaveOptions, Converter.ConvertHTML, HttpClient | Converts HTML content to another format using Aspose.HTML. |
| [Batch Process Multiple Page Urls Looping List Applying Extraction Workflow](./batch_process_multiple_page_urls_looping_list_applying_extraction_workflow.cs) | Batch Process Multiple Page Urls Looping List Applying Extraction Workflow | TextContent.Trim, System.Collections, Children.Add, File.WriteAllText, HTMLDocument | Creates or manipulates an HTML document. |
| [Cache Downloaded External Svg Files Locally To Avoid Redundant Network Requests](./cache_downloaded_external_svg_files_locally_to_avoid_redundant_network_requests.cs) | Cache Downloaded External Svg Files Locally To Avoid Redundant Network Requests | Console.WriteLine, System.IO, FileSystemResourceHandler, SVGDocument, Saving.ResourceHandlers | Demonstrates a specific Aspose.HTML operation. |
| [Configure Html Document Ignore Script Errors Page Loading](./configure_html_document_ignore_script_errors_page_loading.cs) | Configure Html Document Ignore Script Errors Page Loading | Configuration, Console.WriteLine, Sandbox.Scripts, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Create Reusable Method Accepts Page Url Returns List Of Extracted Inline Svg Strings](./create_reusable_method_accepts_page_url_returns_list_of_extracted_inline_svg_strings.cs) | Create Reusable Method Accepts Page Url Returns List Of Extracted Inline Svg Strings | HTMLDocument, System.Collections, Console.WriteLine, Element.OuterHTML, Aspose.Html | Creates or manipulates an HTML document. |
| [Detect Skip Duplicate Svg Markup Outerhtml Before Writing Files](./detect_skip_duplicate_svg_markup_outerhtml_before_writing_files.cs) | Detect Skip Duplicate Svg Markup Outerhtml Before Writing Files | System.Collections, Console.WriteLine, Element.OuterHTML, Markups.Add, SVGDocument | Creates or manipulates an HTML document. |
| [Download External Svg Files Httpclient Async Getasync](./download_external_svg_files_httpclient_async_getasync.cs) | Download External Svg Files Httpclient Async Getasync | File.WriteAllBytesAsync, Uri, Guid.NewGuid, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Expose Public Api Method Returns Collection Of File Paths For All Extracted Svgs From Given Url](./expose_public_api_method_returns_collection_of_file_paths_for_all_extracted_svgs_from_given_url.cs) | Expose Public Api Method Returns Collection Of File Paths For All Extracted Svgs From Given Url | System.Collections, Console.WriteLine, System.IO, Directory.GetCurrentDirectory, Path.Combine | Creates or manipulates an HTML document. |
| [Extract Each Inline Svg Markup Outerhtml Property](./extract_each_inline_svg_markup_outerhtml_property.cs) | Extract Each Inline Svg Markup Outerhtml Property | Console.WriteLine, Element.OuterHTML, SVGDocument, Doc.Save, Aspose.Html | Creates or manipulates an HTML document. |
| [Filter Img Collection Keep Only Elements With Src Ending Svg](./filter_img_collection_keep_only_elements_with_src_ending_svg.cs) | Filter Img Collection Keep Only Elements With Src Ending Svg | System.Collections, Generic.List, Console.WriteLine, StringComparison.OrdinalIgnoreCase, ParentNode.RemoveChild | Creates or manipulates an HTML document. |
| [Generate Summary Csv File Listing Source Page Url Svg Type Inline External Saved File Name](./generate_summary_csv_file_listing_source_page_url_svg_type_inline_external_saved_file_name.cs) | Generate Summary Csv File Listing Source Page Url Svg Type Inline External Saved File Name | StreamWriter, Console.WriteLine, Element.OuterHTML, System.IO, SVGDocument | Creates or manipulates an HTML document. |
| [Identify All Img Elements In Dom Via Document Images](./identify_all_img_elements_in_dom_via_document_images.cs) | Identify All Img Elements In Dom Via Document Images | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Implement Asynchronous Version Extraction Routine Improve Scalability](./implement_asynchronous_version_extraction_routine_improve_scalability.cs) | Implement Asynchronous Version Extraction Routine Improve Scalability | System.IO, System.Threading, File.AppendAllTextAsync, Console.Error, Environment.NewLine | Creates or manipulates an HTML document. |
| [Implement Error Handling Skip Extraction When Html Page Cannot Be Loaded](./implement_error_handling_skip_extraction_when_html_page_cannot_be_loaded.cs) | Implement Error Handling Skip Extraction When Html Page Cannot Be Loaded | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Implement Retry Logic For External Svg Downloads Transient Network Errors](./implement_retry_logic_for_external_svg_downloads_transient_network_errors.cs) | Implement Retry Logic For External Svg Downloads Transient Network Errors | Net.ResponseMessage, Console.WriteLine, System.IO, Exception, Content.ReadAsByteArray | Creates or manipulates an HTML document. |
| [Iterate Over Returned Svg Collection](./iterate_over_returned_svg_collection.cs) | Iterate Over Returned Svg Collection | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Load Html Page From Url Using Aspose Html Htmldocument Class](./load_html_page_from_url_using_aspose_html_htmldocument_class.cs) | Load Html Page From Url Using Aspose Html Htmldocument Class | Console.WriteLine, Aspose.HTML, Aspose.Html, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |
| [Log Count Of External Svgs Each Processed Page](./log_count_of_external_svgs_each_processed_page.cs) | Log Count Of External Svgs Each Processed Page | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Log Inline Svgs Count Per Processed Page](./log_inline_svgs_count_per_processed_page.cs) | Log Inline Svgs Count Per Processed Page | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Parse Base Tag Html Document Resolve Relative Svg Urls](./parse_base_tag_html_document_resolve_relative_svg_urls.cs) | Parse Base Tag Html Document Resolve Relative Svg Urls | Doc.GetElementsByTagName, Console.WriteLine, Elements.Length, Doc.DocumentElement, SVGDocument | Creates or manipulates an HTML document. |
| [Provide Option Rename Saved Svg Files Pattern Including Source Page Domain Index](./provide_option_rename_saved_svg_files_pattern_including_source_page_domain_index.cs) | Provide Option Rename Saved Svg Files Pattern Including Source Page Domain Index | Uri, Console.WriteLine, System.IO, System.Threading, SVGDocument | Demonstrates a specific Aspose.HTML operation. |
| [Resolve Relative Svg Urls Against Page Base Url Before Downloading](./resolve_relative_svg_urls_against_page_base_url_before_downloading.cs) | Resolve Relative Svg Urls Against Page Base Url Before Downloading | Console.WriteLine, SVGDocument, Doc.Save, Aspose.Html, Dom.Svg | Demonstrates a specific Aspose.HTML operation. |
| [Retrieve All Inline Svg Elements Using Getelementsbytagname Svg](./retrieve_all_inline_svg_elements_using_getelementsbytagname_svg.cs) | Retrieve All Inline Svg Elements Using Getelementsbytagname Svg | Console.WriteLine, Aspose.Html, Collections.HTMLCollection | Creates or manipulates an HTML document. |
| [Save Each Downloaded External Svg To Local File Preserving Original File Name](./save_each_downloaded_external_svg_to_local_file_preserving_original_file_name.cs) | Save Each Downloaded External Svg To Local File Preserving Original File Name | Uri, Console.WriteLine, Client.GetStringAsync, System.IO, Path.GetFileName | Demonstrates a specific Aspose.HTML operation. |
| [Save Each Extracted Inline Svg Markup To Separate Svg File Using System Io](./save_each_extracted_inline_svg_markup_to_separate_svg_file_using_system_io.cs) | Save Each Extracted Inline Svg Markup To Separate Svg File Using System Io | HTMLDocument, Console.WriteLine, Element.OuterHTML, System.IO, SVGDocument | Creates or manipulates an HTML document. |
| [Set Timeout On Httpclient To Prevent Hanging During External Svg Download](./set_timeout_on_httpclient_to_prevent_hanging_during_external_svg_download.cs) | Set Timeout On Httpclient To Prevent Hanging During External Svg Download | Console.WriteLine, TimeSpan.FromSeconds, Aspose.Html, RequestMessage, HTMLDocument | Creates or manipulates an HTML document. |
| [Store File Paths Of Saved Svgs In Dictionary Keyed By Source Page Url](./store_file_paths_of_saved_svgs_in_dictionary_keyed_by_source_page_url.cs) | Store File Paths Of Saved Svgs In Dictionary Keyed By Source Page Url | System.Collections, Guid.NewGuid, Console.WriteLine, SVGDocument, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Use Htmlloadoptions Specify Correct Encoding When Loading Non Utf8 Html Pages](./use_htmlloadoptions_specify_correct_encoding_when_loading_non_utf8_html_pages.cs) | Use Htmlloadoptions Specify Correct Encoding When Loading Non Utf8 Html Pages | Console.WriteLine, System.IO, Encoding.GetEncoding, Path.GetDirectoryName, File.ReadAllText | Creates or manipulates an HTML document. |
| [Use Webclient Fallback When Httpclient Download Fails](./use_webclient_fallback_when_httpclient_download_fails.cs) | Use Webclient Fallback When Httpclient Download Fails | Ex.Message, Console.WriteLine, Client.GetByteArrayAsync, System.Threading, WebClient | Demonstrates a specific Aspose.HTML operation. |
| [Verify Copyright And Usage Terms Before Reusing Extracted Svg Files](./verify_copyright_and_usage_terms_before_reusing_extracted_svg_files.cs) | Verify Copyright And Usage Terms Before Reusing Extracted Svg Files | Console.WriteLine, FileSystemResourceHandler, SVGDocument, Saving.ResourceHandlers, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |

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
