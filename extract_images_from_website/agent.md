---
name: extract_images_from_website
description: C# examples for extract_images_from_website using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – extract_images_from_website

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **extract_images_from_website** category.
This folder contains standalone C# examples for extract_images_from_website operations.
See the root [agent.md](../agent.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: `extract_images_from_website`
- **Total examples**: 37  
- **Typical workflow**:  
  1. **Load** an HTML document (remote URL or local file).  
  2. **Bind** – locate `<img>` and `<link rel="icon">` elements, resolve their `src`/`href` attributes to absolute URLs using `Url` and the document’s `BaseUri`.  
  3. **Convert** – download the binary data with `HttpClient` (or `WebClient`) and optionally transform it (e.g., base‑64 encoding).  
  4. **Render / Save** – write the image bytes to disk, archive them, or embed them in other payloads.

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | Core language features, console I/O |
| Aspose.Html | HTML document model, URL handling |
| Aspose.Html.Dom | DOM traversal, element access |
| Aspose.Html.Net | Network‑related helpers |
| System.IO | File and stream operations |
| System.Net.Http | `HttpClient` for downloading resources |
| Aspose.Html.Collections | Collections used by Aspose HTML |
| System.Threading.Tasks | Asynchronous programming (`Task`, `WhenAll`) |
| System.Collections.Generic | Generic collections (`List<T>`, `Dictionary<K,V>`) |
| System.Threading | Cancellation tokens, thread‑level control |
| Aspose.Html.Converters | Converting HTML to other formats |
| Aspose.Html.Saving | Saving converted content |
| System.Net | Low‑level networking utilities |
| Aspose.Html.Dom.XPath | XPath queries on the DOM |
| Aspose.Html.Rendering.Image | Rendering HTML to images (optional) |
| Aspose.Html.IO | I/O abstractions used by the library |
| Aspose.Html.Services | Service‑oriented helpers |
| System.IO.Compression | Creating ZIP archives |
| System.Text.Json | Serialising metadata to JSON |
| Aspose.Html.Accessibility | Accessibility analysis (rarely needed) |
| Aspose.Html.Accessibility.Results | Result objects for accessibility checks |
| Aspose.Html.Accessibility.Saving | Saving accessibility reports |
| System.Diagnostics | Debugging and performance timing |

### How to import them

```csharp
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;
using Aspose.Html.Collections;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;
using Aspose.Html.Services;
using System.IO.Compression;
using System.Diagnostics;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;
```

---

## Common Code Pattern

The examples share a common skeleton that demonstrates the full extraction pipeline:

```csharp
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class ImageExtractor
{
    static async Task Main(string[] args)
    {
        // 1️⃣ Load the remote page
        var url = new Uri("https://example.com");
        var document = new HTMLDocument(url);

        // 2️⃣ Resolve image URLs (both <img> and <link rel="icon">)
        var imageElements = document.QuerySelectorAll("img, link[rel~='icon']");
        var imageUrls = new List<Uri>();

        foreach (var element in imageElements)
        {
            var attr = element.TagName.Equals("IMG", StringComparison.OrdinalIgnoreCase)
                ? "src"
                : "href";

            var raw = element.GetAttribute(attr);
            if (string.IsNullOrWhiteSpace(raw))
            {
                Console.WriteLine($"[WARN] Element missing '{attr}' attribute – skipping.");
                continue;
            }

            var absolute = new Url(raw, document.BaseUri).ToString();
            imageUrls.Add(new Uri(absolute));
        }

        // 3️⃣ Download each image (parallel, with cancellation support)
        using var http = new HttpClient();
        var cts = new CancellationTokenSource();
        var downloadTasks = imageUrls.Select(async imgUri =>
        {
            try
            {
                var bytes = await http.GetByteArrayAsync(imgUri, cts.Token);
                var fileName = Path.GetFileName(imgUri.LocalPath);
                var outPath = Path.Combine("downloaded_images", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outPath)!);
                await File.WriteAllBytesAsync(outPath, bytes, cts.Token);
                Console.WriteLine($"[OK] Saved {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {imgUri} – {ex.Message}");
            }
        });

        await Task.WhenAll(downloadTasks);
        Console.WriteLine("Extraction completed.");
    }
}
```

*Key points*  

* `HTMLDocument` loads the page and provides `BaseUri`.  
* `QuerySelectorAll` (or XPath) fetches the relevant nodes.  
* `Url` resolves relative references against `BaseUri`.  
* `HttpClient` performs async downloads; `Task.WhenAll` maximises throughput.  
* `CancellationTokenSource` enables graceful termination.  

---

## Frequently Used APIs

| API | Appearances |
|-----|--------------|
| Console.WriteLine | 36 |
| Aspose.Html | 35 |
| HTMLDocument | 28 |
| System.IO | 19 |
| System.Net | 15 |
| Path.Combine | 15 |
| Url | 14 |
| Directory.CreateDirectory | 14 |
| HttpClient | 14 |
| Element.GetAttribute | 12 |
| Url.ToString | 12 |
| System.Threading | 10 |
| Client.GetByteArrayAsync | 10 |
| Path.GetFileName | 9 |
| StringComparison.OrdinalIgnoreCase | 8 |
| Path.GetExtension | 8 |
| File.WriteAllBytes | 8 |
| System.Collections | 6 |
| XPathResultType.Any | 3 |
| Dom.XPath | 3 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [add_error_handling_for_missing_src_attributes_and_log_warnings_without_interrupting_workflow.cs](./add_error_handling_for_missing_src_attributes_and_log_warnings_without_interrupting_workflow.cs) | Add Error Handling For Missing Src Attributes And Log Warnings Without Interrupting Workflow | File.AppendAllText, Console.WriteLine, Environment.NewLine, XPathResultType.Any | Demonstrates how to continue processing when an `<img>` element lacks a `src` attribute, logging the issue to a file. |
| [add_retry_logic_transient_network_failures_downloading_images_icons.cs](./add_retry_logic_transient_network_failures_downloading_images_icons.cs) | Add Retry Logic Transient Network Failures Downloading Images Icons | Net.ResponseMessage, Console.WriteLine, Exception, Content.ReadAsByteArray, System.Threading | Shows a retry mechanism for transient HTTP errors while fetching images or icons. |
| [apply_naming_pattern_prefixes_saved_files_source_domain_name.cs](./apply_naming_pattern_prefixes_saved_files_source_domain_name.cs) | Apply Naming Pattern Prefixes Saved Files Source Domain Name | Console.WriteLine, Aspose.Html, Uri | Saves images with a filename prefix derived from the source domain to avoid collisions. |
| [archive_all_extracted_images_and_icons_zip_file_easy_distribution.cs](./archive_all_extracted_images_and_icons_zip_file_easy_distribution.cs) | Archive All Extracted Images And Icons Zip File Easy Distribution | StringComparison.OrdinalIgnoreCase, Path.GetFileName, Client.GetByteArrayAsync, File.Exists, HTMLDocument | Packs all downloaded assets into a ZIP archive for convenient distribution. |
| [async_streams_write_image_files_directly_to_disk_while_downloading_reduce_memory_usage.cs](./async_streams_write_image_files_directly_to_disk_while_downloading_reduce_memory_usage.cs) | Async Streams Write Image Files Directly To Disk While Downloading Reduce Memory Usage | FileStreamProvider, FileMode.Create, ImageFormat.Png, System.Threading, FileShare.None | Streams image bytes straight to disk, keeping memory footprint low. |
| [collect_all_link_elements_with_rel_icon_from_loaded_html_document.cs](./collect_all_link_elements_with_rel_icon_from_loaded_html_document.cs) | Collect All Link Elements With Rel Icon From Loaded Html Document | Console.WriteLine, StringComparison.OrdinalIgnoreCase, Elements.Length, Aspose.Html, HTMLDocument | Retrieves `<link rel="icon">` elements for favicon extraction. |
| [configure_httpclient_proxy_settings_support_extraction_behind_corporate_firewalls.cs](./configure_httpclient_proxy_settings_support_extraction_behind_corporate_firewalls.cs) | Configure Httpclient Proxy Settings Support Extraction Behind Corporate Firewalls | WebProxy, NetworkCredential, Console.WriteLine, Content.ReadAsStringAsync, System.Threading | Shows how to configure `HttpClient` to work through a corporate proxy. |
| [convert_downloaded_image_bytes_base64_strings_embedding_json_payloads.cs](./convert_downloaded_image_bytes_base64_strings_embedding_json_payloads.cs) | Convert Downloaded Image Bytes Base64 Strings Embedding Json Payloads | Convert.ToBase64String, Console.WriteLine, Client.GetByteArrayAsync, System.Threading, JsonSerializer.Serialize | Converts image bytes to Base64 and embeds them in a JSON document. |
| [create_reusable_method_accepts_url_returns_list_of_absolute_image_urls.cs](./create_reusable_method_accepts_url_returns_list_of_absolute_image_urls.cs) | Create Reusable Method Accepts Url Returns List Of Absolute Image Urls | System.Collections, Element.GetAttribute, Url.ToString, Console.WriteLine, Url | Provides a helper that returns all absolute image URLs from a page. |
| [document_extraction_workflow_code_comments_xml_documentation_public_methods.cs](./document_extraction_workflow_code_comments_xml_documentation_public_methods.cs) | Document Extraction Workflow Code Comments Xml Documentation Public Methods | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Adds XML documentation and accessibility‑related logging to the extraction pipeline. |
| [download_icon_data_synchronously_using_webclient_each_resolved_icon_url_resource.cs](./download_icon_data_synchronously_using_webclient_each_resolved_icon_url_resource.cs) | Download Icon Data Synchronously Using Webclient Each Resolved Icon Url Resource | HTMLDocument, Element.GetAttribute, Url.ToString, Console.WriteLine, System.IO | Synchronous download of favicons using `WebClient`. |
| [download_image_data_asynchronously_httpclient_each_resolved_url_resource.cs](./download_image_data_asynchronously_httpclient_each_resolved_url_resource.cs) | Download Image Data Asynchronously Httpclient Each Resolved Url Resource | HTMLDocument, Element.GetAttribute, Url.ToString, Console.WriteLine, System.IO | Asynchronous image download with `HttpClient`. |
| [extract_image_dimensions_from_html_attributes_and_store_alongside_file_metadata.cs](./extract_image_dimensions_from_html_attributes_and_store_alongside_file_metadata.cs) | Extract Image Dimensions From Html Attributes And Store Alongside File Metadata | Console.WriteLine, System.Collections, Aspose.Html, HTMLDocument | Reads `width`/`height` attributes and records them with the saved file. |
| [filter_extracted_images_by_file_extension_download_only_png_and_jpeg.cs](./filter_extracted_images_by_file_extension_download_only_png_and_jpeg.cs) | Filter Extracted Images By File Extension Download Only Png And Jpeg | HTMLDocument, Element.GetAttribute, Url.ToString, Console.WriteLine, System.IO | Limits downloads to PNG and JPEG assets. |
| [implement_batch_extraction_process_multiple_web_pages_sequentially_single_run.cs](./implement_batch_extraction_process_multiple_web_pages_sequentially_single_run.cs) | Implement Batch Extraction Process Multiple Web Pages Sequentially Single Run | Json.JsonSerializer, TextContent.Trim, System.Collections, Children.Add, File.WriteAllText | Processes a list of URLs one after another, persisting results to a JSON file. |
| [implement_configurable_timeout_for_httpclient_requests_to_avoid_hanging_on_slow_resources.cs](./implement_configurable_timeout_for_httpclient_requests_to_avoid_hanging_on_slow_resources.cs) | Implement Configurable Timeout For Httpclient Requests To Avoid Hanging On Slow Resources | Console.WriteLine, DocumentElement.OuterHTML, TimeSpan.FromSeconds, Aspose.Html, RequestMessage | Sets a per‑request timeout to prevent stalls on slow servers. |
| [implement_parallel_image_download_using_task_whenall_improve_overall_extraction_performance.cs](./implement_parallel_image_download_using_task_whenall_improve_overall_extraction_performance.cs) | Implement Parallel Image Download Using Task Whenall Improve Overall Extraction Performance | File.WriteAllBytesAsync, System.Threading, StringComparison.OrdinalIgnoreCase, Path.GetFileName, Client.GetByteArrayAsync | Fires off parallel download tasks and awaits them with `Task.WhenAll`. |
| [implement_progress_reporting_callback_reports_number_of_images_downloaded_versus_total.cs](./implement_progress_reporting_callback_reports_number_of_images_downloaded_versus_total.cs) | Implement Progress Reporting Callback Reports Number Of Images Downloaded Versus Total | HTMLDocument, Element.GetAttribute, Url.ToString, Console.WriteLine, System.IO | Shows a simple progress indicator while images are being saved. |
| [integrate_extraction_routine_into_aspnet_core_controller_endpoint_for_on_demand_usage.cs](./integrate_extraction_routine_into_aspnet_core_controller_endpoint_for_on_demand_usage.cs) | Integrate Extraction Routine Into Aspnet Core Controller Endpoint For On Demand Usage | Request.RequestUri, Console.WriteLine, System.IO, Services.INetworkService, Stopwatch.StartNew | Exposes the extraction logic as an ASP.NET Core API endpoint. |
| [log_detailed_extraction_steps_to_file_using_serilog_for_troubleshooting.cs](./log_detailed_extraction_steps_to_file_using_serilog_for_troubleshooting.cs) | Log Detailed Extraction Steps To File Using Serilog For Troubleshooting | File.AppendAllText, System.IO, Environment.NewLine, XPathResultType.Any, Aspose.Html | Writes step‑by‑step logs with Serilog‑style formatting. |
| [parse_remote_web_page_url_and_retrieve_all_img_elements_using_htmldocument.cs](./parse_remote_web_page_url_and_retrieve_all_img_elements_using_htmldocument.cs) | Parse Remote Web Page Url And Retrieve All Img Elements Using Htmldocument | Element.GetAttribute, Url.ToString, Console.WriteLine, Url, Aspose.Html | Basic example that lists every `<img>` on a remote page. |
| [provide_option_overwrite_existing_files_skip_them_user_defined_flag.cs](./provide_option_overwrite_existing_files_skip_them_user_defined_flag.cs) | Provide Option Overwrite Existing Files Skip Them User Defined Flag | Console.WriteLine, System.IO, PdfSaveOptions, Directory.GetFiles, Converter.ConvertHTML | Demonstrates a flag that controls whether existing files are overwritten. |
| [register_html_document_and_http_client_services_via_dependency_injection_for_testability.cs](./register_html_document_and_http_client_services_via_dependency_injection_for_testability.cs) | Register Html Document And Http Client Services Via Dependency Injection For Testability | Console.WriteLine, HttpClient, Aspose.Html, System.Net, HTMLDocument | Shows DI registration to make the extraction code unit‑testable. |
| [resolve_each_icon_href_to_absolute_url_using_url_class_and_document_baseuri.cs](./resolve_each_icon_href_to_absolute_url_using_url_class_and_document_baseuri.cs) | Resolve Each Icon Href To Absolute Url Using Url Class And Document Baseuri | Element.GetAttribute, Url.ToString, Console.WriteLine, Url, Aspose.Html | Resolves favicon URLs against the page’s base URI. |
| [resolve_each_image_src_attribute_absolute_url_using_url_class_and_document_baseuri.cs](./resolve_each_image_src_attribute_absolute_url_using_url_class_and_document_baseuri.cs) | Resolve Each Image Src Attribute Absolute Url Using Url Class And Document Baseuri | Element.GetAttribute, Url.ToString, Console.WriteLine, Url, Aspose.Html | Same as above but for `<img>` elements. |
| [save_downloaded_icons_to_dedicated_icons_directory_using_custom_naming_convention.cs](./save_downloaded_icons_to_dedicated_icons_directory_using_custom_naming_convention.cs) | Save Downloaded Icons To Dedicated Icons Directory Using Custom Naming Convention | HTMLDocument, File.WriteAllBytesAsync, Uri, Uri.IsWellFormedUriString, Console.WriteLine | Stores favicons in a separate folder with a deterministic naming scheme. |
| [save_downloaded_images_local_folder_original_names.cs](./save_downloaded_images_local_folder_original_names.cs) | Save Downloaded Images Local Folder Original Names | HTMLDocument, Element.GetAttribute, Url.ToString, Console.WriteLine, System.IO | Persists images using the filename that appears in the source URL. |
| [skip_downloading_icons_larger_than_specified_byte_size_threshold_conserve_bandwidth.cs](./skip_downloading_icons_larger_than_specified_byte_size_threshold_conserve_bandwidth.cs) | Skip Downloading Icons Larger Than Specified Byte Size Threshold Conserve Bandwidth | Bytes.Length, Console.WriteLine, System.IO, Path.GetFileName, Content.ReadAsByteArray | Checks the content length before downloading and skips oversized icons. |
| [store_extracted_images_in_memory_streams_for_further_processing_before_writing_to_disk.cs](./store_extracted_images_in_memory_streams_for_further_processing_before_writing_to_disk.cs) | Store Extracted Images In Memory Streams For Further Processing Before Writing To Disk | System.Collections, FileAccess.Write, Console.WriteLine, System.IO, File.OpenRead | Keeps images in `MemoryStream` objects for additional manipulation (e.g., resizing) before persisting. |
| [support_extraction_of_favicon_ico_files_by_handling_link_elements_with_rel_shortcut_icon.cs](./support_extraction_of_favicon_ico_files_by_handling_link_elements_with_rel_shortcut_icon.cs) | Support Extraction Of Favicon Ico Files By Handling Link Elements With Rel Shortcut Icon | Console.WriteLine, XPathResultType.Any, Aspose.Html, Dom.XPath, HTMLDocument | Uses XPath to locate `<link rel="shortcut icon">` elements and download the `.ico` files. |
| [use_cancellationtoken_allow_graceful_termination_image_extraction_process.cs](./use_cancellationtoken_allow_graceful_termination_image_extraction_process.cs) | Use Cancellationtoken Allow Graceful Termination Image Extraction Process | System.Threading, StringComparison.OrdinalIgnoreCase, CancellationTokenSource, Console.CancelKeyPress, Path.GetFileName | Demonstrates how to stop the extraction cleanly on user interrupt. |
| [use_custom_http_message_handler_simulate_network_latency_performance_testing.cs](./use_custom_http_message_handler_simulate_network_latency_performance_testing.cs) | Use Custom Http Message Handler Simulate Network Latency Performance Testing | Configuration, Console.WriteLine, Aspose.HTML, System.Threading, Thread.Sleep | Wraps `HttpClient` with a handler that injects artificial latency for testing. |
| [use_html_document_queryselectorall_with_css_selector_img_data_important_true_to_target_specific_images.cs](./use_html_document_queryselectorall_with_css_selector_img_data_important_true_to_target_specific_images.cs) | Use Html Document Queryselectorall With Css Selector Img Data Important True To Target Specific Images | Console.WriteLine, Aspose.Html, HtmlDocument.QuerySelectorAll, HTMLDocument | Shows a CSS selector that picks only images marked with `data-important="true"`. |
| [use_retry_after_header_http_response_schedule_delayed_retries_rate_limited_resources.cs](./use_retry_after_header_http_response_schedule_delayed_retries_rate_limited_resources.cs) | Use Retry After Header Http Response Schedule Delayed Retries Rate Limited Resources | Task.Delay, Delta.HasValue, TimeSpan.Zero, Date.HasValue, Console.WriteLine | Implements retry‑after handling for HTTP 429 responses. |
| [validate_each_resolved_url_successful_http_status_before_download.cs](./validate_each_resolved_url_successful_http_status_before_download.cs) | Validate Each Resolved Url Successful Http Status Before Download | System.Collections, Console.WriteLine, Content.ReadAsByteArray, Url, Context.Network | Sends a HEAD request to ensure the URL returns 2xx before fetching the image. |
| [validate_saved_image_files_not_corrupted_by_checking_file_signatures_after_write_operation.cs](./validate_saved_image_files_not_corrupted_by_checking_file_signatures_after_write_operation.cs) | Validate Saved Image Files Not Corrupted By Checking File Signatures After Write Operation | File.ReadAllBytes, Console.WriteLine, System.IO, File.OpenRead, ImageFormat.Jpeg | Reads the first bytes of each saved file to confirm a valid image signature. |
| [write_unit_tests_mock_httpclient_responses_verify_url_resolution_download_logic.cs](./write_unit_tests_mock_httpclient_responses_verify_url_resolution_download_logic.cs) | Write Unit Tests Mock Httpclient Responses Verify Url Resolution Download Logic | HTMLDocument, MockHttpMessageHandler, Console.WriteLine, ByteArrayContent, Exception | Provides a unit‑test skeleton that mocks HTTP responses for the extraction code. |

---

## Category‑Specific Tips

### Key API Surface
* **HTMLDocument** – entry point for loading and parsing HTML.  
* **Element.GetAttribute** – retrieve `src`, `href`, `width`, `height`, etc.  
* **Url** – resolve relative URLs against `document.BaseUri`.  
* **HttpClient / Client.GetByteArrayAsync** – async binary download.  
* **File / Path** – create directories, compose file names, write bytes.  
* **Task / Parallel** – maximise throughput with `WhenAll` or `Parallel.ForEach`.  
* **CancellationToken** – allow graceful shutdown.  

### Rules
1. **Always resolve URLs** with `new Url(raw, document.BaseUri)` before downloading.  
2. **Validate** the resolved URL (`Uri.IsWellFormedUriString`) and HTTP status before fetching.  
3. **Wrap network calls** in retry logic (exponential back‑off, respect `Retry‑After`).  
4. **Limit concurrency** (`SemaphoreSlim`) when downloading many assets to avoid socket exhaustion.  
5. **Write files atomically** – download to a temp file then move/rename to the final location.  
6. **Log** every major step (`Console.WriteLine` or a logger) – missing attributes, download failures, file‑system errors.  
7. **Respect existing files** – provide an overwrite/skip flag.  
8. **Clean up** temporary streams and `HttpClient` instances (`using` or `Dispose`).  

---

## Warnings

* **Template‑binding mismatches** – if you change the HTML structure, selectors (`QuerySelectorAll`, XPath) may return no nodes; always verify selector correctness.  
* **Missing `src`/`href` attributes** – attempting to download a null URL throws; guard with `string.IsNullOrWhiteSpace`.  
* **File‑path issues** – illegal characters in URLs can produce invalid file names; sanitize with `Path.GetInvalidFileNameChars`.  
* **Large images / memory pressure** – loading many images into memory before writing can cause OOM; stream directly to disk or use bounded buffers.  
* **Rendering to images** – `Aspose.Html.Rendering.Image` may require additional system resources; ensure sufficient GDI+ availability on the host.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – the file must compile and run without external project references.  
2. **Console logging** – use `Console.WriteLine` for progress and error messages.  
3. **Follow the common pattern** – load → resolve URLs → download → save (or archive).  
4. **Naming** – file name should be PascalCase, prefixed with the action (e.g., `Download_...`).  
5. **Update statistics** – increment `total_examples` and add the new file entry to the **Files** table, including its key APIs and a concise description.  

---