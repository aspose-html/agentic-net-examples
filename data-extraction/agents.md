---
name: data-extraction
description: C# examples for Data Extraction using Aspose.HTML for .NET
language: csharp
framework: net10.0
parent: ../AGENTS.md
---

# AGENTS - Data Extraction

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET,
working within the **Data Extraction** category.
This folder contains standalone C# examples for Data Extraction operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;`
- `using System.IO;`
- `using Aspose.Html;`
- `using Aspose.Html.Dom;`
- `using Aspose.Html.Dom.XPath;`
- `using Aspose.Html.Dom.Traversal;`
- `using Aspose.Html.Dom.Svg;`
- `using Aspose.Html.Net;`
- `using Aspose.Html.Converters;`
- `using Aspose.Html.Saving;`

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [access-document-images-collection-iterate-all-img-elements.cs](./access-document-images-collection-iterate-all-img-elements.cs) |  | Access the document's Images collection to iterate over all <img> elements. |
| [access-document-links-collection-iterate-all-link-rel-icon-elements.cs](./access-document-links-collection-iterate-all-link-rel-icon-elements.cs) |  | Access the document's Links collection to iterate over all <link rel="icon"> elements. |
| [access-document-svg-elements-collection-iterate-all-inline-svg-elements.cs](./access-document-svg-elements-collection-iterate-all-inline-svg-elements.cs) | `SVGDocument` | Access the document's SVG elements collection to iterate over all inline <svg> elements. |
| [add-cli-flag-skip-downloading-files-already-exist-output-directory.cs](./add-cli-flag-skip-downloading-files-already-exist-output-directory.cs) | `HttpClient` | Add a CLI flag to skip downloading files that already exist in the output directory. |
| [apply-custom-nodefilter-exclude-nodes-with-display-none-style-during-dom-traversal.cs](./apply-custom-nodefilter-exclude-nodes-with-display-none-style-during-dom-traversal.cs) |  | Apply a custom NodeFilter that excludes nodes with display:none style during DOM traversal... |
| [apply-custom-nodefilter-extract-only-script-tags-ignore-other-elements.cs](./apply-custom-nodefilter-extract-only-script-tags-ignore-other-elements.cs) |  | Apply a custom NodeFilter to extract only script tags while ignoring other elements. |
| [apply-custom-nodefilter-include-only-nodes-inner-html-length-exceeds-200-characters.cs](./apply-custom-nodefilter-include-only-nodes-inner-html-length-exceeds-200-characters.cs) |  | Apply a custom NodeFilter that includes only nodes whose inner HTML length exceeds 200 cha... |
| [apply-retry-logic-exponential-backoff-failed-download-attempts.cs](./apply-retry-logic-exponential-backoff-failed-download-attempts.cs) | `HttpClient` | Apply retry logic with exponential backoff for failed download attempts. |
| [batch-download-files-from-list-of-urls-naming-each-file-based-on-original-filename.cs](./batch-download-files-from-list-of-urls-naming-each-file-based-on-original-filename.cs) | `HttpClient` | Batch download files from a list of URLs, naming each file based on its original filename. |
| [build-command-line-interface-accepts-target-urls-extracts-all-supported-resources.cs](./build-command-line-interface-accepts-target-urls-extracts-all-supported-resources.cs) |  | Build a command‑line interface that accepts target URLs and extracts all supported resourc... |
| [cli-option-limit-maximum-number-resources-extracted-per-page.cs](./cli-option-limit-maximum-number-resources-extracted-per-page.cs) |  | Provide a CLI option to limit the maximum number of resources extracted per page. |
| [configure-custom-httpclient-headers-user-agent-string-before-downloading-resources.cs](./configure-custom-httpclient-headers-user-agent-string-before-downloading-resources.cs) | `HttpClient` | Configure custom HttpClient headers, such as a User‑Agent string, before downloading resou... |
| [configure-htmlsaveoptions-exclude-javascript-files-when-saving-website-for-static-analysis.cs](./configure-htmlsaveoptions-exclude-javascript-files-when-saving-website-for-static-analysis.cs) | `HTMLSaveOptions` | Configure HTMLSaveOptions to exclude JavaScript files when saving a website for static ana... |
| [configure-restrict-saved-resources-same-domain-source-page.cs](./configure-restrict-saved-resources-same-domain-source-page.cs) |  | Configure ResourceHandlingOptions to restrict saved resources to the same domain as the so... |
| [create-requestmessage-with-custom-headers-download-image-file-from-url.cs](./create-requestmessage-with-custom-headers-download-image-file-from-url.cs) | `ImageSaveOptions`, `HttpClient`, `Url` | Create a RequestMessage with custom headers and use it to download an image file from a UR... |
| [detect-duplicate-external-svg-files-comparing-content-hashes-before-saving.cs](./detect-duplicate-external-svg-files-comparing-content-hashes-before-saving.cs) | `SVGDocument` | Detect duplicate external SVG files by comparing content hashes before saving. |
| [download-pdf-file-from-given-url-using-requestmessage-save-with-responsemessage.cs](./download-pdf-file-from-given-url-using-requestmessage-save-with-responsemessage.cs) | `PdfSaveOptions`, `HttpClient`, `Url` | Download a PDF file from a given URL using RequestMessage and save it with ResponseMessage... |
| [extract-all-email-addresses-from-webpage-selecting-anchor-tags-with-href-containing-mailto.cs](./extract-all-email-addresses-from-webpage-selecting-anchor-tags-with-href-containing-mailto.cs) |  | Extract all email addresses from a webpage by selecting anchor tags with href containing "... |
| [extract-content-attribute-all-meta-tags-specify-viewport-settings-css-selector.cs](./extract-content-attribute-all-meta-tags-specify-viewport-settings-css-selector.cs) |  | Extract the content attribute of all meta tags that specify viewport settings via CSS sele... |
| [extract-open-graph-title-property-from-page-using-xpath-and-store-it-csv-file.cs](./extract-open-graph-title-property-from-page-using-xpath-and-store-it-csv-file.cs) | `XPathResult` | Extract the Open Graph title property from a page using XPath and store it in a CSV file. |
| [extract-text-content-of-all-list-items-within-navigation-menu-using-css-selector.cs](./extract-text-content-of-all-list-items-within-navigation-menu-using-css-selector.cs) |  | Extract the text content of all list items within a navigation menu using a CSS selector. |
| [extract-website-icons-defined-with-link-rel-icon-and-save-as-ico-files.cs](./extract-website-icons-defined-with-link-rel-icon-and-save-as-ico-files.cs) |  | Extract website icons defined with <link rel="icon"> and save them as .ico files. |
| [filter-dom-nodes-include-only-elements-with-data-id-attribute-using-custom-nodefilter.cs](./filter-dom-nodes-include-only-elements-with-data-id-attribute-using-custom-nodefilter.cs) |  | Filter DOM nodes to include only elements with a data-id attribute using a custom NodeFilt... |
| [filter-extracted-images-by-file-extension-png-jpg-before-download.cs](./filter-extracted-images-by-file-extension-png-jpg-before-download.cs) | `ImageSaveOptions`, `HttpClient` | Filter extracted images by file extension, such as .png or .jpg, before download. |
| [filter-extracted-images-by-minimum-width-and-height-before-saving.cs](./filter-extracted-images-by-minimum-width-and-height-before-saving.cs) |  | Filter extracted images by minimum width and height before saving. |
| [flatten-extracted-files-into-single-output-folder-ignoring-original-website-paths.cs](./flatten-extracted-files-into-single-output-folder-ignoring-original-website-paths.cs) |  | Flatten all extracted files into a single output folder, ignoring original website paths. |
| [generate-csv-report-extracted-resource-type-url-local-path.cs](./generate-csv-report-extracted-resource-type-url-local-path.cs) | `Url` | Generate a CSV report listing each extracted resource with its type, URL, and local path. |
| [generate-list-of-external-resource-urls-referenced-in-page-using-xpath-save-to-csv.cs](./generate-list-of-external-resource-urls-referenced-in-page-using-xpath-save-to-csv.cs) | `XPathResult` | Generate a list of all external resource URLs referenced in a page using XPath and save to... |
| [generate-seo-report-extracting-title-meta-description-heading-hierarchy-webpage.cs](./generate-seo-report-extracting-title-meta-description-heading-hierarchy-webpage.cs) |  | Generate an SEO report by extracting title, meta description, and heading hierarchy from a... |
| [honor-base-tag-constructing-absolute-urls-resource-download.cs](./honor-base-tag-constructing-absolute-urls-resource-download.cs) | `HttpClient` | Honor the <base> tag when constructing absolute URLs for resource download. |
| [identify-external-svg-files-referenced-img-tags-download-local-storage.cs](./identify-external-svg-files-referenced-img-tags-download-local-storage.cs) | `SVGDocument`, `HttpClient` | Identify external SVG files referenced by <img> tags and download them to local storage. |
| [implement-asynchronous-download-resources-using-asyncawait-each-page.cs](./implement-asynchronous-download-resources-using-asyncawait-each-page.cs) | `HttpClient` | Implement asynchronous download of resources using async/await for each page. |
| [implement-custom-nodefilter-includes-only-anchor-elements-use-to-collect-link-nodes.cs](./implement-custom-nodefilter-includes-only-anchor-elements-use-to-collect-link-nodes.cs) |  | Implement a custom NodeFilter that includes only anchor elements and use it to collect lin... |
| [implement-error-handling-for-requestmessage-failures-when-downloading-files-from-invalid-urls.cs](./implement-error-handling-for-requestmessage-failures-when-downloading-files-from-invalid-urls.cs) | `HttpClient` | Implement error handling for RequestMessage failures when downloading files from invalid U... |
| [iterate-through-sibling-nodes-of-selected-element-log-outer-html.cs](./iterate-through-sibling-nodes-of-selected-element-log-outer-html.cs) |  | Iterate through sibling nodes of a selected element and log each node's outer HTML. |
| [load-html-document-count-heading-elements-h1-to-h3-using-xpath.cs](./load-html-document-count-heading-elements-h1-to-h3-using-xpath.cs) | `XPathResult`, `HTMLDocument` | Load an HTML document and count the number of heading elements from h1 to h3 using XPath. |
| [load-html-document-from-remote-url-extract-all-hyperlink-urls-with-css-selector.cs](./load-html-document-from-remote-url-extract-all-hyperlink-urls-with-css-selector.cs) | `HTMLDocument`, `HttpClient`, `Url` | Load an HTML document from a remote URL and extract all hyperlink URLs with a CSS selector... |
| [load-html-document-normalize-whitespace-text-nodes-save-cleaned-markup.cs](./load-html-document-normalize-whitespace-text-nodes-save-cleaned-markup.cs) | `HTMLDocument` | Load an HTML document, normalize whitespace in text nodes, and save the cleaned markup. |
| [load-html-document-remove-comment-nodes-save-cleaned-page-locally.cs](./load-html-document-remove-comment-nodes-save-cleaned-page-locally.cs) | `HTMLDocument` | Load an HTML document, remove all comment nodes, and save the cleaned page locally. |
| [load-html-document-replace-relative-image-urls-with-absolute-urls-save-updated-file.cs](./load-html-document-replace-relative-image-urls-with-absolute-urls-save-updated-file.cs) | `ImageSaveOptions`, `HTMLDocument` | Load an HTML document, replace all relative image URLs with absolute URLs, and save the up... |
| [load-html-file-extract-image-source-attributes-selecting-img-tags-css-selector.cs](./load-html-file-extract-image-source-attributes-selecting-img-tags-css-selector.cs) | `ImageSaveOptions`, `HTMLDocument` | Load an HTML file and extract image source attributes by selecting img tags with a CSS sel... |
| [load-local-html-file-retrieve-page-title-using-xpath-expression.cs](./load-local-html-file-retrieve-page-title-using-xpath-expression.cs) | `XPathResult`, `HTMLDocument` | Load a local HTML file and retrieve the page title using an XPath expression. |
| [log-errors-encountered-during-resource-download-to-dedicated-error-log-file.cs](./log-errors-encountered-during-resource-download-to-dedicated-error-log-file.cs) | `HttpClient` | Log errors encountered during resource download to a dedicated error log file. |
| [log-summary-all-extracted-resources-including-type-file-path-after-extraction.cs](./log-summary-all-extracted-resources-including-type-file-path-after-extraction.cs) |  | Log a summary of all extracted resources, including type and file path, after extraction. |
| [navigate-from-document-element-to-head-section-and-list-all-linked-stylesheet-urls.cs](./navigate-from-document-element-to-head-section-and-list-all-linked-stylesheet-urls.cs) |  | Navigate from the document element to the head section and list all linked stylesheet URLs... |
| [open-web-page-with-aspose-html-document-extract-raster-images-from-img-tags.cs](./open-web-page-with-aspose-html-document-extract-raster-images-from-img-tags.cs) | `HTMLDocument` | Open a web page using Aspose.HTML Document and extract raster images from <img> tags. |
| [page-url-restriction-allow-only-https-urls-saving-multi-page-website.cs](./page-url-restriction-allow-only-https-urls-saving-multi-page-website.cs) |  | Use PageUrlRestriction to allow only HTTPS URLs when saving a multi‑page website. |
| [parse-html-string-collect-text-of-all-paragraph-elements-using-xpath.cs](./parse-html-string-collect-text-of-all-paragraph-elements-using-xpath.cs) | `XPathResult`, `HTMLDocument` | Parse an HTML string and collect the text of all paragraph elements using XPath. |
| [perform-http-get-request-retrieve-json-data-api-endpoint-store-response.cs](./perform-http-get-request-retrieve-json-data-api-endpoint-store-response.cs) |  | Perform an HTTP GET request to retrieve JSON data from an API endpoint and store the respo... |
| [preserve-original-website-directory-hierarchy-saving-extracted-resources-locally.cs](./preserve-original-website-directory-hierarchy-saving-extracted-resources-locally.cs) |  | Preserve the original website directory hierarchy when saving extracted resources locally. |
| [process-list-of-web-page-urls-from-text-file-and-extract-resources-from-each-page.cs](./process-list-of-web-page-urls-from-text-file-and-extract-resources-from-each-page.cs) |  | Process a list of web page URLs from a text file and extract resources from each page. |
| [programmatically-download-extracted-resource-efficiently-asphtml-network-utilities.cs](./programmatically-download-extracted-resource-efficiently-asphtml-network-utilities.cs) | `HTMLDocument`, `HttpClient` | Programmatically download each extracted resource efficiently using Aspose.HTML network ut... |
| [raise-progress-events-after-each-resource-downloaded-report-extraction-status.cs](./raise-progress-events-after-each-resource-downloaded-report-extraction-status.cs) | `HttpClient` | Raise progress events after each resource is downloaded to report extraction status. |
| [resolve-protocol-relative-urls-to-absolute-using-url-class.cs](./resolve-protocol-relative-urls-to-absolute-using-url-class.cs) | `Url` | Resolve protocol‑relative URLs (starting with //) to absolute URLs using the Url class. |
| [resolve-relative-urls-to-absolute-urls-using-url-class-and-document-baseuri.cs](./resolve-relative-urls-to-absolute-urls-using-url-class-and-document-baseuri.cs) | `Url` | Resolve relative URLs to absolute URLs using the Url class and the document BaseURI. |
| [restrict-saved-resources-whitelist-domains-configure-restrictedresourceurls-before-saving.cs](./restrict-saved-resources-whitelist-domains-configure-restrictedresourceurls-before-saving.cs) |  | Restrict saved resources to a whitelist of domains by configuring RestrictedResourceUrls b... |
| [retrieve-inline-svg-markup-via-outerhtml-write-each-to-separate-svg-file.cs](./retrieve-inline-svg-markup-via-outerhtml-write-each-to-separate-svg-file.cs) | `SVGDocument` | Retrieve inline SVG markup via OuterHTML and write each to a separate .svg file. |
| [retrieve-inner-text-first-paragraph-inside-div-specific-class-using-xpath.cs](./retrieve-inner-text-first-paragraph-inside-div-specific-class-using-xpath.cs) | `XPathResult` | Retrieve the inner text of the first paragraph inside a div with a specific class using XP... |
| [save-each-downloaded-external-svg-file-to-output-folder-with-svg-extension.cs](./save-each-downloaded-external-svg-file-to-output-folder-with-svg-extension.cs) | `SVGDocument`, `HttpClient` | Save each downloaded external SVG file to the output folder with .svg extension. |
| [save-each-downloaded-image-to-specified-output-folder-preserving-original-filenames.cs](./save-each-downloaded-image-to-specified-output-folder-preserving-original-filenames.cs) | `ImageSaveOptions`, `HttpClient` | Save each downloaded image to a specified output folder preserving original filenames. |
| [save-each-extracted-icon-to-output-folder-with-appropriate-ico-extension.cs](./save-each-extracted-icon-to-output-folder-with-appropriate-ico-extension.cs) |  | Save each extracted icon to the output folder with appropriate .ico extension. |
| [save-each-extracted-inline-svg-markup-to-svg-file-preserving-original-markup.cs](./save-each-extracted-inline-svg-markup-to-svg-file-preserving-original-markup.cs) | `SVGDocument` | Save each extracted inline SVG markup to a .svg file preserving original markup. |
| [save-entire-website-to-directory-limit-resource-depth-two-levels-htmlsaveoptions.cs](./save-entire-website-to-directory-limit-resource-depth-two-levels-htmlsaveoptions.cs) | `HTMLSaveOptions` | Save an entire website to a directory while limiting resource depth to two levels using HT... |
| [save-remote-html-page-to-disk-after-modifying-title-element-using-dom-manipulation.cs](./save-remote-html-page-to-disk-after-modifying-title-element-using-dom-manipulation.cs) |  | Save a remote HTML page to disk after modifying its title element using DOM manipulation. |
| [save-single-page-embed-css-inline-offline-viewing.cs](./save-single-page-embed-css-inline-offline-viewing.cs) | `HTMLSaveOptions` | Save a single page with HTMLSaveOptions that embed all CSS resources inline for offline vi... |
| [save-single-webpage-to-local-folder-using-default-htmlsaveoptions-and-verify-file-creation.cs](./save-single-webpage-to-local-folder-using-default-htmlsaveoptions-and-verify-file-creation.cs) | `HTMLSaveOptions` | Save a single webpage to a local folder with default HTMLSaveOptions and verify file creat... |
| [save-website-preserving-original-folder-structure-setting-appropriate-htmlsaveoptions.cs](./save-website-preserving-original-folder-structure-setting-appropriate-htmlsaveoptions.cs) | `HTMLSaveOptions` | Save a website while preserving the original folder structure by setting appropriate HTMLS... |
| [save-website-with-max-handling-depth-zero-to-capture-only-entry-page.cs](./save-website-with-max-handling-depth-zero-to-capture-only-entry-page.cs) |  | Save a website with ResourceHandlingOptions.MaxHandlingDepth set to zero to capture only t... |
| [set-resourcehandlingoptions-restrictedresourceurls-block-external-javascript-files-website-saving.cs](./set-resourcehandlingoptions-restrictedresourceurls-block-external-javascript-files-website-saving.cs) |  | Set ResourceHandlingOptions.RestrictedResourceUrls to block external JavaScript files duri... |
| [skip-duplicate-images-comparing-sha256-hashes-saving-files.cs](./skip-duplicate-images-comparing-sha256-hashes-saving-files.cs) |  | Skip duplicate images by comparing SHA256 hashes before saving new files. |
| [store-extracted-resource-metadata-url-size-json-file-later-analysis.cs](./store-extracted-resource-metadata-url-size-json-file-later-analysis.cs) | `Url` | Store extracted resource metadata such as URL and size in a JSON file for later analysis. |
| [traverse-dom-find-first-child-element-of-body-output-tag-name.cs](./traverse-dom-find-first-child-element-of-body-output-tag-name.cs) |  | Traverse the DOM to find the first child element of the body and output its tag name. |
| [use-css-selectors-find-all-bold-text-elements-replace-inner-html-uppercase-text.cs](./use-css-selectors-find-all-bold-text-elements-replace-inner-html-uppercase-text.cs) |  | Use CSS selectors to find all bold text elements and replace their inner HTML with upperca... |
| [use-css-selectors-find-elements-class-highlight-change-background-color.cs](./use-css-selectors-find-elements-class-highlight-change-background-color.cs) |  | Use CSS selectors to find all elements with class "highlight" and change their background ... |
| [use-css-selectors-locate-video-tags-retrieve-source-urls-further-processing.cs](./use-css-selectors-locate-video-tags-retrieve-source-urls-further-processing.cs) |  | Use CSS selectors to locate all video tags and retrieve their source URLs for further proc... |
| [use-document-queryselectorall-css-selector-obtain-all-list-items-inside-ordered-lists.cs](./use-document-queryselectorall-css-selector-obtain-all-list-items-inside-ordered-lists.cs) |  | Use Document.QuerySelectorAll with a CSS selector to obtain all list items inside ordered ... |
| [use-document-queryselectorall-locate-elements-with-style-attribute-containing-color-red-change-to-blue.cs](./use-document-queryselectorall-locate-elements-with-style-attribute-containing-color-red-change-to-blue.cs) |  | Use Document.QuerySelectorAll to locate all elements with style attribute containing "colo... |
| [use-document-selectnodes-xpath-query-retrieve-all-table-rows-html-table.cs](./use-document-selectnodes-xpath-query-retrieve-all-table-rows-html-table.cs) | `XPathResult` | Use Document.SelectNodes with an XPath query to retrieve all table rows in an HTML table. |
| [use-parallel-foreach-process-multiple-pages-concurrently-respecting-thread-safety.cs](./use-parallel-foreach-process-multiple-pages-concurrently-respecting-thread-safety.cs) |  | Use Parallel.ForEach to process multiple pages concurrently while respecting thread safety... |
| [use-xpath-select-table-cells-containing-numeric-values-calculate-sum-programmatically.cs](./use-xpath-select-table-cells-containing-numeric-values-calculate-sum-programmatically.cs) | `XPathResult` | Use XPath to select all table cells containing numeric values and calculate their sum prog... |
| [user-cancel-batch-extraction-with-token.cs](./user-cancel-batch-extraction-with-token.cs) |  | Allow user to cancel batch extraction via a CancellationToken source. |

## Category Statistics
- Total examples: 81
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `HTMLDocument`
- `XPathResult`
- `NodeIterator`
- `Url`
- `HttpClient`
- `HTMLSaveOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-10-02 | Examples: 81
<!-- AUTOGENERATED:END -->
