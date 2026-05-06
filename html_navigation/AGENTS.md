---
name: html_navigation
description: C# examples for html_navigation using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – html_navigation

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **html_navigation** category.
This folder contains standalone C# examples for html_navigation operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: `html_navigation`  
- **Total examples**: **120**  
- **Typical workflow**:  
  1. **Load** – read an HTML file or stream into an `HTMLDocument`.  
  2. **Bind / Manipulate** – locate navigation‑related nodes (e.g., `<nav>`, `<a>`, `<ul>`), read or modify attributes, add ARIA labels, rewrite URLs, etc.  
  3. **Convert** – optionally transform the document (e.g., to plain text, Markdown, JSON, or a different HTML version) using Aspose converters.  
  4. **Render / Save** – write the resulting markup back to disk, a stream, or another format (PDF, PNG, etc.) using `HTMLSaveOptions` or other save‑options classes.

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | 120 |
| Aspose.Html | 118 |
| Aspose.Html.Dom | 90 |
| Aspose.Html.Collections | 44 |
| System.Collections.Generic | 25 |
| System.IO | 15 |
| Aspose.Html.Net | 11 |
| System.Linq | 10 |
| System.Text.Json | 7 |
| Aspose.Html.Saving | 7 |
| System.Text | 7 |
| Aspose.Html.Converters | 4 |
| Aspose.Html.Dom.XPath | 4 |
| System.Text.RegularExpressions | 3 |
| Aspose.Html.Dom.Svg | 3 |
| Aspose.Html.Forms | 2 |
| Aspose.Html.Dom.Css | 2 |
| Aspose.Html.Accessibility | 2 |
| Aspose.Html.Services | 1 |
| System.Threading | 1 |
| System.Threading.Tasks | 1 |
| Aspose.Html.Accessibility.Results | 1 |

### How to import them

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Dom.Css;
using Aspose.Html.Forms;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Services;
```

---

## Common Code Pattern

Below is a representative pattern that appears in many navigation‑related samples (loading a document, fixing navigation links, and saving the result).

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        // 1️⃣ Load the HTML document from disk.
        string inputPath = @"C:\Docs\sample.html";
        using var document = new HTMLDocument(inputPath);

        // 2️⃣ Locate all navigation anchor elements.
        var navLinks = document.GetElementsByTagName("a");
        Console.WriteLine($"Found {navLinks.Length} anchor elements.");

        // 3️⃣ Example manipulation – add an ARIA label when missing.
        foreach (Element link in navLinks)
        {
            string aria = link.GetAttribute("aria-label");
            if (string.IsNullOrWhiteSpace(aria))
            {
                string text = link.TextContent?.Trim() ?? "navigation link";
                link.SetAttribute("aria-label", text);
                Console.WriteLine($"Added aria-label=\"{text}\" to <a href=\"{link.GetAttribute("href")}\">");
            }
        }

        // 4️⃣ Convert / render – optional step (e.g., to plain text).
        // var plain = Converter.ConvertHTML(document, new TextSaveOptions());

        // 5️⃣ Save the updated document.
        var saveOptions = new HTMLSaveOptions
        {
            // Example: embed external resources to make the file self‑contained.
            ResourceHandlingOptions = ResourceHandlingOptions.Embed
        };
        string outputPath = @"C:\Docs\sample_fixed.html";
        document.Save(outputPath, saveOptions);
        Console.WriteLine($"Document saved to {outputPath}");
    }
}
```

*Key points demonstrated*:

* Use `HTMLDocument` for loading and saving.  
* Access node collections via `GetElementsByTagName` and iterate with `Elements.Length`.  
* Read/write attributes with `Element.GetAttribute` / `Element.SetAttribute`.  
* Log progress with `Console.WriteLine`.  
* Apply `StringComparison.OrdinalIgnoreCase` when comparing attribute values (not shown but common).  

---

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Console.WriteLine | 120 |
| Aspose.Html | 119 |
| HTMLDocument | 96 |
| System.Collections | 27 |
| System.Text | 21 |
| System.IO | 20 |
| Elements.Length | 20 |
| StringComparison.OrdinalIgnoreCase | 20 |
| Element.GetAttribute | 15 |
| Dom.Element | 12 |
| System.Linq | 10 |
| Url.ToString | 8 |
| File.ReadAllText | 7 |
| Element.SetAttribute | 7 |
| File.WriteAllText | 7 |
| Path.Combine | 7 |
| Url | 7 |
| StringBuilder | 7 |
| TextContent.Trim | 6 |
| TagName.ToLower | 6 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [add_aria_label_attributes_to_navigation_links_lacking_descriptive_text_for_screen_readers.cs](./add_aria_label_attributes_to_navigation_links_lacking_descriptive_text_for_screen_readers.cs) | Add Aria Label Attributes To Navigation Links Lacking Descriptive Text For Screen Readers | Console.WriteLine, TextContent.Trim, Aspose.Html, HTMLDocument | Enhances accessibility by adding missing `aria-label` attributes to navigation links. |
| [add_crossorigin_attribute_to_external_script_tags_to_enable_cors_handling.cs](./add_crossorigin_attribute_to_external_script_tags_to_enable_cors_handling.cs) | Add Crossorigin Attribute To External Script Tags To Enable CORS Handling | Encoding.UTF8, Element.GetAttribute, Console.WriteLine, System.IO, Elements.Length | Inserts `crossorigin` on external `<script>` tags to allow CORS requests. |
| [add_custom_data_attribute_to_all_heading_elements_for_javascript_interaction.cs](./add_custom_data_attribute_to_all_heading_elements_for_javascript_interaction.cs) | Add Custom Data Attribute To All Heading Elements For Javascript Interaction | Console.WriteLine, Aspose.Html, Nodes.Length, HTMLDocument | Adds a `data-id` attribute to every heading for client‑side scripts. |
| [add_custom_data_tracking_attribute_to_all_outbound_links_for_analytics.cs](./add_custom_data_tracking_attribute_to_all_outbound_links_for_analytics.cs) | Add Custom Data Tracking Attribute To All Outbound Links For Analytics | Console.WriteLine, Aspose.Html, StringComparison.OrdinalIgnoreCase, HTMLDocument | Tags external links with a tracking attribute for analytics platforms. |
| [add_language_attribute_html_tag_detected_content_language.cs](./add_language_attribute_html_tag_detected_content_language.cs) | Add Language Attribute Html Tag Detected Content Language | Element.Lang, Console.WriteLine, Elements.Length, Aspose.Html, HTMLDocument | Detects page language and sets the `<html lang="">` attribute accordingly. |
| [add_missing_alt_attributes_to_img_tags_using_placeholder_description_for_accessibility.cs](./add_missing_alt_attributes_to_img_tags_using_placeholder_description_for_accessibility.cs) | Add Missing Alt Attributes To Img Tags Using Placeholder Description For Accessibility | Console.WriteLine, Aspose.Html, HTMLDocument | Supplies default `alt` text for images lacking it. |
| [add_missing_charset_meta_tag_based_on_detected_file_encoding_improve_compatibility.cs](./add_missing_charset_meta_tag_based_on_detected_file_encoding_improve_compatibility.cs) | Add Missing Charset Meta Tag Based On Detected File Encoding Improve Compatibility | Encoding.UTF8, Content.IndexOf, Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase | Inserts a `<meta charset>` tag matching the file’s actual encoding. |
| [add_missing_doctype_declaration_beginning_html_file_standards_mode.cs](./add_missing_doctype_declaration_beginning_html_file_standards_mode.cs) | Add Missing Doctype Declaration Beginning Html File Standards Mode | File.WriteAllText, Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase, File.ReadAllText | Prepends a `<!DOCTYPE html>` declaration to enforce standards mode. |
| [add_nofollow_attribute_to_external_links_control_search_engine_crawling.cs](./add_nofollow_attribute_to_external_links_control_search_engine_crawling.cs) | Add Nofollow Attribute To External Links Control Search Engine Crawling | Console.WriteLine, Aspose.Html, StringComparison.OrdinalIgnoreCase, HTMLDocument | Marks outbound links with `rel="nofollow"` to guide crawlers. |
| [append_new_stylesheet_link_element_to_head_reference_external_css_file.cs](./append_new_stylesheet_link_element_to_head_reference_external_css_file.cs) | Append New Stylesheet Link Element To Head Reference External Css File | Console.WriteLine, System.Linq, Aspose.Html, HTMLDocument | Adds a `<link rel="stylesheet">` element pointing to an external CSS file. |
| [batch_process_folder_html_files_extract_headings_hierarchy_save_each_json_outline.cs](./batch_process_folder_html_files_extract_headings_hierarchy_save_each_json_outline.cs) | Batch Process Folder Html Files Extract Headings Hierarchy Save Each Json Outline | TextContent.Trim, System.Collections, Children.Add, File.WriteAllText, HTMLDocument | Walks a folder, builds a hierarchical outline of headings, and writes each as JSON. |
| [clone_navigation_menu_element_and_insert_clone_at_end_of_body.cs](./clone_navigation_menu_element_and_insert_clone_at_end_of_body.cs) | Clone Navigation Menu Element And Insert Clone At End Of Body | HTMLSaveOptions, System.Linq, Console.WriteLine, Aspose.Html, HTMLDocument | Duplicates a navigation menu and appends the clone to the document body. |
| [compare_two_html_documents_generate_diff_report_highlighting_added_and_removed_nodes.cs](./compare_two_html_documents_generate_diff_report_highlighting_added_and_removed_nodes.cs) | Compare Two Html Documents Generate Diff Report Highlighting Added And Removed Nodes | WebUtility.HtmlEncode, System.Linq, System.Collections, Doc.GetElementsByTagName, Console.WriteLine | Produces a diff report that shows added/removed nodes between two HTML files. |
| [configure_parser_ignore_xml_namespaces_navigating_html_documents_mixed_content.cs](./configure_parser_ignore_xml_namespaces_navigating_html_documents_mixed_content.cs) | Configure Parser Ignore Xml Namespaces Navigating Html Documents Mixed Content | Console.WriteLine, Aspose.Html, Dom.Element, HTMLDocument | Sets parser options to ignore XML namespaces for smoother navigation. |
| [configure_parser_treat_unknown_tags_as_generic_elements_instead_of_throwing_errors.cs](./configure_parser_treat_unknown_tags_as_generic_elements_instead_of_throwing_errors.cs) | Configure Parser Treat Unknown Tags As Generic Elements Instead Of Throwing Errors | Console.WriteLine, Aspose.Html, HTMLDocument | Adjusts parser to treat unknown tags as generic elements, preventing exceptions. |
| [convert_html_document_to_plain_text_preserving_line_breaks_for_readability.cs](./convert_html_document_to_plain_text_preserving_line_breaks_for_readability.cs) | Convert Html Document To Plain Text Preserving Line Breaks For Readability | Converter.ConvertHTML, Aspose.Html, TextSaveOptions, Console.WriteLine | Converts HTML to plain‑text while keeping line breaks for easier reading. |
| [convert_html_email_templates_to_plain_text_preserving_line_breaks_and_links.cs](./convert_html_email_templates_to_plain_text_preserving_line_breaks_and_links.cs) | Convert Html Email Templates To Plain Text Preserving Line Breaks And Links | Converter.ConvertHTML, Aspose.Html, TextSaveOptions, Console.WriteLine | Same as above but focused on email template conversion. |
| [convert_html_table_to_json_array_preserving_column_headers_as_object_keys.cs](./convert_html_table_to_json_array_preserving_column_headers_as_object_keys.cs) | Convert Html Table To Json Array Preserving Column Headers As Object Keys | System.Collections, File.WriteAllText, TablesData.Count, TablesData.Add, Console.WriteLine | Transforms an HTML `<table>` into a JSON array where each object key is a column header. |
| [convert_inline_svg_elements_to_external_files_and_replace_with_img_references.cs](./convert_inline_svg_elements_to_external_files_and_replace_with_img_references.cs) | Convert Inline Svg Elements To External Files And Replace With Img References | Element.ParentNode, Console.WriteLine, Element.OuterHTML, Elements.Length, Element.SetAttribute | Extracts inline `<svg>` to separate files and swaps them with `<img>` tags. |
| [convert_i_tags_to_em_tags_accessibility_compliance_document.cs](./convert_i_tags_to_em_tags_accessibility_compliance_document.cs) | Convert I Tags To Em Tags Accessibility Compliance Document | Element.ParentNode, Console.WriteLine, Elements.Length, Dom.Element, Aspose.Html | Replaces deprecated `<i>` tags with semantic `<em>` for better accessibility. |
| [convert_relative_image_source_urls_to_absolute_urls_based_on_document_base_tag.cs](./convert_relative_image_source_urls_to_absolute_urls_based_on_document_base_tag.cs) | Convert Relative Image Source Urls To Absolute Urls Based On Document Base Tag | Url.ToString, Uri.IsWellFormedUriString, Console.WriteLine, UriKind.Absolute, Url | Resolves relative `src` attributes to absolute URLs using the `<base>` element. |
| [convert_relative_urls_in_anchor_tags_to_absolute_using_document_base_url.cs](./convert_relative_urls_in_anchor_tags_to_absolute_using_document_base_url.cs) | Convert Relative Urls In Anchor Tags To Absolute Using Document Base Url | Element.GetAttribute, Url.ToString, Console.WriteLine, DocumentElement.OuterHTML, Url | Same as above but for `<a href>` attributes. |
| [convert_uppercase_tag_names_to_lowercase_for_html5_compliance_throughout_document.cs](./convert_uppercase_tag_names_to_lowercase_for_html5_compliance_throughout_document.cs) | Convert Uppercase Tag Names To Lowercase For Html5 Compliance Throughout Document | RegexOptions.Compiled, Console.WriteLine, System.IO, Value.ToLower, File.ReadAllText | Normalises tag names to lower‑case to meet HTML5 standards. |
| [detect_and_correct_malformed_tags_missing_closing_brackets_during_parsing.cs](./detect_and_correct_malformed_tags_missing_closing_brackets_during_parsing.cs) | Detect And Correct Malformed Tags Missing Closing Brackets During Parsing | Console.WriteLine, Aspose.Html, HTMLSaveOptions, HTMLDocument | Detects tags missing `>` or `</>` and repairs them before saving. |
| [detect_and_extract_comment_nodes_with_todo_markers_for_development_tracking.cs](./detect_and_extract_comment_nodes_with_todo_markers_for_development_tracking.cs) | Detect And Extract Comment Nodes With Todo Markers For Development Tracking | Console.WriteLine, XPathResultType.Any, Aspose.Html, Dom.XPath, HTMLDocument | Pulls out `<!-- TODO … -->` comments for a dev‑task list. |
| [detect_and_extract_inline_svg_elements_save_as_separate_svg_files.cs](./detect_and_extract_inline_svg_elements_save_as_separate_svg_files.cs) | Detect And Extract Inline Svg Elements Save As Separate Svg Files | Console.WriteLine, Element.OuterHTML, System.IO, Environment.CurrentDirectory, SVGDocument | Saves each inline `<svg>` to its own `.svg` file. |
| [detect_and_list_elements_with_tabindex_to_evaluate_keyboard_navigation_order.cs](./detect_and_list_elements_with_tabindex_to_evaluate_keyboard_navigation_order.cs) | Detect And List Elements With Tabindex To Evaluate Keyboard Navigation Order | Console.WriteLine, Aspose.Html, Elements.Length, HTMLDocument | Lists elements that define a `tabindex` for accessibility audits. |
| [detect_and_log_parsing_warnings_unknown_tags_attributes_during_load.cs](./detect_and_log_parsing_warnings_unknown_tags_attributes_during_load.cs) | Detect And Log Parsing Warnings Unknown Tags Attributes During Load | Console.WriteLine, Aspose.Html, HTMLDocument | Captures parser warnings about unknown tags/attributes. |
| [detect_and_remove_empty_elements_without_child_nodes_or_text_content.cs](./detect_and_remove_empty_elements_without_child_nodes_or_text_content.cs) | Detect And Remove Empty Elements Without Child Nodes Or Text Content | System.Collections, Generic.List, Console.WriteLine, Remove.Add, Aspose.Html | Prunes empty elements to clean up the DOM. |
| [detect_and_remove_empty_style_tags_without_css_rules_in_document.cs](./detect_and_remove_empty_style_tags_without_css_rules_in_document.cs) | Detect And Remove Empty Style Tags Without Css Rules In Document | Element.ParentNode, Element.TextContent, Console.WriteLine, Elements.Length, Aspose.Html | Deletes `<style>` blocks that contain no CSS. |
| [detect_broken_links_by_sending_http_head_requests_to_each_extracted_url_and_logging_failures.cs](./detect_broken_links_by_sending_http_head_requests_to_each_extracted_url_and_logging_failures.cs) | Detect Broken Links By Sending Http Head Requests To Each Extracted Url And Logging Failures | System.Collections, Element.GetAttribute, Url.ToString, Console.WriteLine, Links.Add | Performs HEAD requests to verify link health. |
| [detect_duplicate_meta_tags_retain_only_first_occurrence_avoid_conflicts.cs](./detect_duplicate_meta_tags_retain_only_first_occurrence_avoid_conflicts.cs) | Detect Duplicate Meta Tags Retain Only First Occurrence Avoid Conflicts | StringComparer.OrdinalIgnoreCase, System.Collections, Element.GetAttribute, Element.ParentNode, Console.WriteLine | Removes duplicate `<meta>` elements, keeping the first. |
| [detect_language_attribute_of_html_tag_and_set_to_en_us_if_missing.cs](./detect_language_attribute_of_html_tag_and_set_to_en_us_if_missing.cs) | Detect Language Attribute Of Html Tag And Set To En Us If Missing | Element.GetAttribute, Console.WriteLine, Elements.Length, Element.SetAttribute, Aspose.Html | Ensures the `<html>` element has a `lang` attribute. |
| [detect_pagination_controls_searching_links_containing_next_previous_text.cs](./detect_pagination_controls_searching_links_containing_next_previous_text.cs) | Detect Pagination Controls Searching Links Containing Next Previous Text | System.Collections, Element.GetAttribute, Element.TextContent, Console.WriteLine, Links.Add | Finds “Next” / “Previous” navigation links for pagination analysis. |
| [enable_case_sensitive_element_name_matching_xml_like_html_parsing_specific_documents.cs](./enable_case_sensitive_element_name_matching_xml_like_html_parsing_specific_documents.cs) | Enable Case Sensitive Element Name Matching Xml Like Html Parsing Specific Documents | Console.WriteLine, Collections.HTMLCollection, Aspose.Html, Dom.Element, HTMLDocument | Turns on case‑sensitive parsing for XML‑heavy HTML. |
| [ensure_every_element_unique_id_generate_missing_ids_based_on_tag_names.cs](./ensure_every_element_unique_id_generate_missing_ids_based_on_tag_names.cs) | Ensure Every Element Unique Id Generate Missing Ids Based On Tag Names | Ids.Add, System.Collections, Console.WriteLine, TagName.ToLower, Elements.Length | Generates missing `id` attributes to guarantee uniqueness. |
| [extract_all_data_table_elements_generate_json_arrays_representing_each_table_rows.cs](./extract_all_data_table_elements_generate_json_arrays_representing_each_table_rows.cs) | Extract All Data Table Elements Generate Json Arrays Representing Each Table Rows | System.Collections, TablesJson.Count, Console.WriteLine, Array.Add, JsonSerializer.Serialize | Serialises each `<table>` row into a JSON array. |
| [extract_all_data_table_rows_and_calculate_sum_of_numeric_columns_for_reporting.cs](./extract_all_data_table_rows_and_calculate_sum_of_numeric_columns_for_reporting.cs) | Extract All Data Table Rows And Calculate Sum Of Numeric Columns For Reporting | System.Collections, Console.WriteLine, Sums.Count, Aspose.Html, Sums.Add | Computes column totals for numeric data tables. |
| [extract_all_heading_elements_assign_incremental_ids_for_anchor_linking_document.cs](./extract_all_heading_elements_assign_incremental_ids_for_anchor_linking_document.cs) | Extract All Heading Elements Assign Incremental Ids For Anchor Linking Document | Console.WriteLine, Aspose.Html, HTMLDocument | Adds sequential `id` attributes to headings for intra‑page linking. |
| [extract_all_style_attribute_values_create_stylesheet_file_with_equivalent_css_rules.cs](./extract_all_style_attribute_values_create_stylesheet_file_with_equivalent_css_rules.cs) | Extract All Style Attribute Values Create Stylesheet File With Equivalent Css Rules | HTMLDocument, Element.TextContent, Console.WriteLine, TagName.ToLower, Builder.ToString | Moves inline `style` attributes into an external stylesheet. |
| [extract_anchor_elements_open_new_window_target_blank_security_review.cs](./extract_anchor_elements_open_new_window_target_blank_security_review.cs) | Extract Anchor Elements Open New Window Target Blank Security Review | Console.WriteLine, TextContent.Trim, Aspose.Html, HTMLDocument | Lists `<a target="_blank">` links for security assessment. |
| [extract_author_meta_tag_value_and_store_for_content_attribution.cs](./extract_author_meta_tag_value_and_store_for_content_attribution.cs) | Extract Author Meta Tag Value And Store For Content Attribution | Console.WriteLine, StringComparison.OrdinalIgnoreCase, Elements.Length, Aspose.Html, HTMLDocument | Retrieves the `author` meta tag content. |
| [extract_breadcrumb_navigation_links_by_locating_ordered_list_elements_with_specific_class_names.cs](./extract_breadcrumb_navigation_links_by_locating_ordered_list_elements_with_specific_class_names.cs) | Extract Breadcrumb Navigation Links By Locating Ordered List Elements With Specific Class Names | Console.WriteLine, TextContent.Trim, Aspose.Html, HTMLDocument | Pulls breadcrumb links from `<ol class="breadcrumb">`. |
| [extract_canonical_link_element_href_value_for_seo_analysis_from_document.cs](./extract_canonical_link_element_href_value_for_seo_analysis_from_document.cs) | Extract Canonical Link Element Href Value For Seo Analysis From Document | Console.WriteLine, StringComparison.OrdinalIgnoreCase, Elements.Length, Aspose.Html, HTMLDocument | Gets the `rel="canonical"` URL for SEO checks. |
| [extract_charset_meta_tag_value_ensure_matches_file_encoding.cs](./extract_charset_meta_tag_value_ensure_matches_file_encoding.cs) | Extract Charset Meta Tag Value Ensure Matches File Encoding | Console.WriteLine, System.IO, Encoding.GetEncoding, StringComparison.OrdinalIgnoreCase, Path.GetDirectoryName | Verifies that the declared charset matches the file’s actual encoding. |
| [extract_csrf_token_hidden_input_values_from_forms_for_security_testing.cs](./extract_csrf_token_hidden_input_values_from_forms_for_security_testing.cs) | Extract Csrf Token Hidden Input Values From Forms For Security Testing | Console.WriteLine, Aspose.Html, HTMLDocument | Finds hidden inputs named `csrf` or similar. |
| [extract_css_class_names_document_output_frequency_histogram.cs](./extract_css_class_names_document_output_frequency_histogram.cs) | Extract Css Class Names Document Output Frequency Histogram | HTMLDocument, System.Collections, StringComparer.Ordinal, Console.WriteLine, StringSplitOptions.RemoveEmptyEntries | Counts occurrences of each CSS class in the document. |
| [extract_email_addresses_from_mailto_links_and_compile_into_plain_text_list.cs](./extract_email_addresses_from_mailto_links_and_compile_into_plain_text_list.cs) | Extract Email Addresses From Mailto Links And Compile Into Plain Text List | List.Add, System.Collections, Element.GetAttribute, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Gathers all `mailto:` addresses into a text file. |
| [extract_embedded_video_source_urls_from_iframe_elements_for_media_cataloging.cs](./extract_embedded_video_source_urls_from_iframe_elements_for_media_cataloging.cs) | Extract Embedded Video Source Urls From Iframe Elements For Media Cataloging | Url.ToString, Console.WriteLine, Url, Aspose.Html, HTMLDocument | Retrieves video URLs embedded via `<iframe>`. |
| [extract_heading_tags_h1_h6_build_nested_table_of_contents_json_structure.cs](./extract_heading_tags_h1_h6_build_nested_table_of_contents_json_structure.cs) | Extract Heading Tags H1 H6 Build Nested Table Of Contents Json Structure | TextContent.Trim, System.Collections, Children.Add, File.WriteAllText, HTMLDocument | Generates a JSON TOC based on heading hierarchy. |
| [extract_hyperlink_href_attributes_from_anchor_tags_write_to_csv_file.cs](./extract_hyperlink_href_attributes_from_anchor_tags_write_to_csv_file.cs) | Extract Hyperlink Href Attributes From Anchor Tags Write To Csv File | StreamWriter, System.Collections, Console.WriteLine, System.IO, Aspose.Html | Exports all link URLs to a CSV for link audits. |
| [extract_link_elements_rel_icon_verify_file_formats_favicon_compliance.cs](./extract_link_elements_rel_icon_verify_file_formats_favicon_compliance.cs) | Extract Link Elements Rel Icon Verify File Formats Favicon Compliance | System.Collections, Url.ToString, Console.WriteLine, System.IO, Path.GetExtension | Checks that the favicon referenced by `<link rel="icon">` is a supported format. |
| [extract_link_elements_with_rel_preload_and_list_resource_urls_for_performance_audit.cs](./extract_link_elements_with_rel_preload_and_list_resource_urls_for_performance_audit.cs) | Extract Link Elements With Rel Preload And List Resource Urls For Performance Audit | System.Linq, Console.WriteLine, Elements.Length, Collections.HTMLCollection, Aspose.Html | Lists resources preloaded via `<link rel="preload">`. |
| [extract_meta_description_content_and_summarize_length_content_quality_checks.cs](./extract_meta_description_content_and_summarize_length_content_quality_checks.cs) | Extract Meta Description Content And Summarize Length Content Quality Checks | Console.WriteLine, StringComparison.OrdinalIgnoreCase, Elements.Length, Attr.Equals, Aspose.Html | Retrieves the meta description and reports its length. |
| [extract_meta_viewport_values_and_verify_contain_width_device_width_responsive_design.cs](./extract_meta_viewport_values_and_verify_contain_width_device_width_responsive_design.cs) | Extract Meta Viewport Values And Verify Contain Width Device Width Responsive Design | Console.WriteLine, StringComparison.OrdinalIgnoreCase, Name.Equals, Aspose.Html, HTMLDocument | Validates that the viewport meta tag contains `width=device-width`. |
| [extract_open_graph_meta_tags_output_dictionary_social_media_integration.cs](./extract_open_graph_meta_tags_output_dictionary_social_media_integration.cs) | Extract Open Graph Meta Tags Output Dictionary Social Media Integration | System.Collections, Console.WriteLine, Elements.Length, Aspose.Html, HTMLDocument | Pulls Open Graph tags into a dictionary for social sharing. |
| [extract_table_data_html_tables_export_each_table_separate_csv_file.cs](./extract_table_data_html_tables_export_each_table_separate_csv_file.cs) | Extract Table Data Html Tables Export Each Table Separate Csv File | File.WriteAllText, Encoding.UTF8, Console.WriteLine, System.IO, Builder.ToString | Writes each HTML table to its own CSV file. |
| [extract_theme_color_meta_tag_value_for_progressive_web_app_configuration.cs](./extract_theme_color_meta_tag_value_for_progressive_web_app_configuration.cs) | Extract Theme Color Meta Tag Value For Progressive Web App Configuration | Console.WriteLine, Aspose.Html, Element.GetAttribute, HTMLDocument | Retrieves the `theme-color` meta tag for PWA theming. |
| [extract_value_robots_meta_tag_determine_indexing_directives.cs](./extract_value_robots_meta_tag_determine_indexing_directives.cs) | Extract Value Robots Meta Tag Determine Indexing Directives | Console.WriteLine, XPathResultType.Any, Aspose.Html, Dom.XPath, HTMLDocument | Reads the `robots` meta tag to understand crawl directives. |
| [find_all_form_elements_list_input_field_names_and_default_values_for_analysis.cs](./find_all_form_elements_list_input_field_names_and_default_values_for_analysis.cs) | Find All Form Elements List Input Field Names And Default Values For Analysis | Forms.Length, Console.WriteLine, TagName.ToLower, Elements.Length, Aspose.Html | Enumerates all form controls with their default values. |
| [find_element_by_unique_id_attribute_modify_inner_text_new_value.cs](./find_element_by_unique_id_attribute_modify_inner_text_new_value.cs) | Find Element By Unique Id Attribute Modify Inner Text New Value | Console.WriteLine, Aspose.Html | Locates an element by `id` and updates its inner text. |
| [find_phone_number_patterns_within_text_nodes_output_for_contact_information_extraction.cs](./find_phone_number_patterns_within_text_nodes_output_for_contact_information_extraction.cs) | Find Phone Number Patterns Within Text Nodes Output For Contact Information Extraction | Console.WriteLine, Regex.Matches, Regex, XPathResultType.Any, Aspose.Html | Uses regex to extract phone numbers from text nodes. |
| [generate_json_sitemap_traversing_all_anchor_elements_recording_absolute_urls.cs](./generate_json_sitemap_traversing_all_anchor_elements_recording_absolute_urls.cs) | Generate Json Sitemap Traversing All Anchor Elements Recording Absolute Urls | System.Collections, Url.ToString, Console.WriteLine, Url, JsonSerializer.Serialize | Builds a JSON sitemap of all internal/external links. |
| [generate_navigation_sidebar_html_snippet_extracted_heading_hierarchy_site.cs](./generate_navigation_sidebar_html_snippet_extracted_heading_hierarchy_site.cs) | Generate Navigation Sidebar Html Snippet Extracted Heading Hierarchy Site | Children.Add, TagName.ToLower, JsonSerializer.Serialize, Path.GetFileNameWithoutExtension, File.WriteAllText | Creates a sidebar navigation HTML fragment from heading hierarchy. |
| [generate_report_summarizing_number_of_each_html_element_type_in_document.cs](./generate_report_summarizing_number_of_each_html_element_type_in_document.cs) | Generate Report Summarizing Number Of Each Html Element Type In Document | StringComparer.OrdinalIgnoreCase, System.Collections, Console.WriteLine, Elements.Length, Counts.ContainsKey | Produces a count of each element type present. |
| [generate_site_map_xml_file_traversing_all_internal_links_discovered_in_html_document.cs](./generate_site_map_xml_file_traversing_all_internal_links_discovered_in_html_document.cs) | Generate Site Map Xml File Traversing All Internal Links Discovered In Html Document | SecurityElement.Escape, File.WriteAllText, Encoding.UTF8, Uri, Console.WriteLine | Writes an XML sitemap of internal links. |
| [identify_and_list_all_elements_with_role_attributes_for_accessibility_compliance_review.cs](./identify_and_list_all_elements_with_role_attributes_for_accessibility_compliance_review.cs) | Identify And List All Elements With Role Attributes For Accessibility Compliance Review | Console.WriteLine, Aspose.Html, HTMLDocument | Lists elements that define ARIA `role` attributes. |
| [identify_and_list_all_external_stylesheet_urls_for_dependency_management_in_project.cs](./identify_and_list_all_external_stylesheet_urls_for_dependency_management_in_project.cs) | Identify And List All External Stylesheet Urls For Dependency Management In Project | Sheets.Length, Console.WriteLine, Aspose.Html, Dom.Css, HTMLDocument | Extracts URLs from `<link rel="stylesheet">` tags. |
| [identify_and_list_all_form_action_urls_backend_endpoint_mapping_in_application.cs](./identify_and_list_all_form_action_urls_backend_endpoint_mapping_in_application.cs) | Identify And List All Form Action Urls Backend Endpoint Mapping In Application | Console.WriteLine, Aspose.Html, HTMLDocument | Lists the `action` attribute of every `<form>`. |
| [identify_and_list_external_script_source_urls_for_dependency_analysis_in_document.cs](./identify_and_list_external_script_source_urls_for_dependency_analysis_in_document.cs) | Identify And List External Script Source Urls For Dependency Analysis In Document | Element.GetAttribute, Console.WriteLine, Elements.Length, Console.Error, Aspose.Html | Retrieves all external JavaScript source URLs. |
| [identify_extract_all_data_attribute_values_custom_javascript_data_binding_document.cs](./identify_extract_all_data_attribute_values_custom_javascript_data_binding_document.cs) | Identify Extract All Data Attribute Values Custom Javascript Data Binding Document | Console.WriteLine, Aspose.Html, Name.StartsWith, HTMLDocument | Collects all `data-*` attributes for custom bindings. |
| [identify_extract_microdata_items_using_itemtype_attributes_convert_to_structured_list.cs](./identify_extract_microdata_items_using_itemtype_attributes_convert_to_structured_list.cs) | Identify Extract Microdata Items Using Itemtype Attributes Convert To Structured List | System.Collections, Element.GetAttribute, Element.TextContent, Console.WriteLine, Item.Properties | Parses microdata (`itemscope`, `itemtype`) into a .NET list. |
| [identify_inline_style_definitions_move_to_external_stylesheet_for_cleaner_markup.cs](./identify_inline_style_definitions_move_to_external_stylesheet_for_cleaner_markup.cs) | Identify Inline Style Definitions Move To External Stylesheet For Cleaner Markup | System.Linq, Console.WriteLine, Builder.ToString, Builder.AppendLine, StringBuilder | Gathers inline `style` attributes and writes them to an external CSS file. |
| [inline_external_css_files_into_style_tags_in_html_head_self_contained_document.cs](./inline_external_css_files_into_style_tags_in_html_head_self_contained_document.cs) | Inline External Css Files Into Style Tags In Html Head Self Contained Document | Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase, Path.GetDirectoryName, Path.Combine | Embeds external CSS files directly into `<style>` tags. |
| [inline_external_javascript_files_into_script_tags_create_single_file_html_page.cs](./inline_external_javascript_files_into_script_tags_create_single_file_html_page.cs) | Inline External Javascript Files Into Script Tags Create Single File Html Page | HTMLSaveOptions, Console.WriteLine, ResourceHandlingOptions.JavaScript, Aspose.Html, ResourceHandling.Embed | Embeds external JS files into the HTML document. |
| [insert_base_tag_with_specified_url_resolve_relative_links_correctly.cs](./insert_base_tag_with_specified_url_resolve_relative_links_correctly.cs) | Insert Base Tag With Specified Url Resolve Relative Links Correctly | Console.WriteLine, Aspose.Html, Element.SetAttribute, HTMLDocument | Adds a `<base href="...">` element to control relative URL resolution. |
| [insert_custom_script_tag_logs_page_load_time_performance_monitoring.cs](./insert_custom_script_tag_logs_page_load_time_performance_monitoring.cs) | Insert Custom Script Tag Logs Page Load Time Performance Monitoring | Configuration, Body.AppendChild, Console.WriteLine, System.IO, AppDomain.CurrentDomain | Injects a script that measures and logs page load time. |
| [insert_new_meta_tag_for_character_encoding_into_head_section_of_html_document.cs](./insert_new_meta_tag_for_character_encoding_into_head_section_of_html_document.cs) | Insert New Meta Tag For Character Encoding Into Head Section Of Html Document | Encoding.UTF8, Console.WriteLine, System.IO, File.ReadAllText, DocumentElement.AppendChild | Adds a `<meta charset="utf-8">` tag to the `<head>`. |
| [list_all_downloadable_file_links_filtering_anchor_hrefs_common_file_extensions.cs](./list_all_downloadable_file_links_filtering_anchor_hrefs_common_file_extensions.cs) | List All Downloadable File Links Filtering Anchor Hrefs Common File Extensions | System.Collections, Element.GetAttribute, Url.ToString, Console.WriteLine, Links.Add | Finds links that point to downloadable files (pdf, zip, etc.). |
| [load_html_content_from_url_stream_with_custom_user_agent_header.cs](./load_html_content_from_url_stream_with_custom_user_agent_header.cs) | Load Html Content From Url Stream With Custom User Agent Header | Console.WriteLine, Aspose.Html, RequestMessage, HTMLDocument | Loads a remote page using a custom `User-Agent`. |
| [load_html_file_from_disk_into_dom_object_default_parsing_options.cs](./load_html_file_from_disk_into_dom_object_default_parsing_options.cs) | Load Html File From Disk Into Dom Object Default Parsing Options | Console.WriteLine, Aspose.Html, DocumentElement.OuterHTML | Simple load of a local HTML file into a DOM. |
| [load_multiple_html_documents_concurrently_asynchronous_methods_combine_body_contents_into_one_file.cs](./load_multiple_html_documents_concurrently_asynchronous_methods_combine_body_contents_into_one_file.cs) | Load Multiple Html Documents Concurrently Asynchronous Methods Combine Body Contents Into One File | System.Linq, System.Collections, CancellationToken.None, Task.WhenAll, HTMLDocument | Demonstrates parallel loading and merging of bodies. |
| [locate_elements_xpath_replace_outer_html_custom_snippet.cs](./locate_elements_xpath_replace_outer_html_custom_snippet.cs) | Locate Elements Xpath Replace Outer Html Custom Snippet | Console.WriteLine, XPathResultType.Any, Aspose.Html, Dom.XPath, HTMLDocument | Uses XPath to replace matched nodes with a custom HTML snippet. |
| [locate_social_media_icon_links_matching_known_domain_patterns_and_list_urls.cs](./locate_social_media_icon_links_matching_known_domain_patterns_and_list_urls.cs) | Locate Social Media Icon Links Matching Known Domain Patterns And List Urls | System.Collections, Element.GetAttribute, Url.ToString, Url.IndexOf, Console.WriteLine | Finds icons linking to known social networks. |
| [merge_html_files_appending_body_sections_document.cs](./merge_html_files_appending_body_sections_document.cs) | Merge Html Files Appending Body Sections Document | System.Linq, Doc.GetElementsByTagName, Body.ChildNodes, Body.AppendChild, Doc.Body | Concatenates the `<body>` of multiple HTML files. |
| [minify_html_document_by_collapsing_whitespace_and_removing_optional_closing_tags.cs](./minify_html_document_by_collapsing_whitespace_and_removing_optional_closing_tags.cs) | Minify Html Document By Collapsing Whitespace And Removing Optional Closing Tags | Console.WriteLine, DocumentElement.OuterHTML, Regex.Replace, Aspose.Html, System.Text | Produces a compact HTML output. |
| [move_script_element_from_head_to_end_of_body_to_improve_page_loading.cs](./move_script_element_from_head_to_end_of_body_to_improve_page_loading.cs) | Move Script Element From Head To End Of Body To Improve Page Loading | Console.WriteLine, Collections.HTMLCollection, InvalidOperationException, Aspose.Html, Dom.Element | Relocates `<script>` tags for better load performance. |
| [parse_html_string_case_insensitive_tag_handling_preserve_whitespace_formatting.cs](./parse_html_string_case_insensitive_tag_handling_preserve_whitespace_formatting.cs) | Parse Html String Case Insensitive Tag Handling Preserve Whitespace Formatting | Console.WriteLine, HTMLDocument, Aspose.Html, DocumentElement.OuterHTML | Parses a raw HTML string with case‑insensitive handling. |
| [pretty_print_html_indentation_two_spaces_nesting_level_readability.cs](./pretty_print_html_indentation_two_spaces_nesting_level_readability.cs) | Pretty Print Html Indentation Two Spaces Nesting Level Readability | Console.WriteLine, Math.Max, DocumentElement.OuterHTML, StringBuilder, Aspose.Html | Formats HTML with consistent two‑space indentation. |
| [remove_all_comment_nodes_from_dom_clean_html_output.cs](./remove_all_comment_nodes_from_dom_clean_html_output.cs) | Remove All Comment Nodes From Dom Clean Html Output | Console.WriteLine, Aspose.Html, Children.Length, HTMLDocument | Strips all `<!-- comment -->` nodes. |
| [remove_all_empty_paragraph_tags_containing_only_whitespace_characters_in_document.cs](./remove_all_empty_paragraph_tags_containing_only_whitespace_characters_in_document.cs) | Remove All Empty Paragraph Tags Containing Only Whitespace Characters In Document | Console.WriteLine, Aspose.Html, HTMLDocument | Deletes `<p>` elements that are empty or whitespace only. |
| [remove_all_script_tags_from_dom_to_eliminate_executable_javascript_before_saving.cs](./remove_all_script_tags_from_dom_to_eliminate_executable_javascript_before_saving.cs) | Remove All Script Tags From Dom To Eliminate Executable Javascript Before Saving | System.Linq, Console.WriteLine, ParentNode.RemoveChild, Elements.ToList, Aspose.Html | Strips all `<script>` elements. |
| [remove_deprecated_center_tags_replace_with_css_text_align_styling.cs](./remove_deprecated_center_tags_replace_with_css_text_align_styling.cs) | Remove Deprecated Center Tags Replace With Css Text Align Styling | Console.WriteLine, Aspose.Html, HTMLDocument | Replaces `<center>` with CSS `text-align:center`. |
| [remove_deprecated_marquee_tags_replace_with_css_animations_modern_effect.cs](./remove_deprecated_marquee_tags_replace_with_css_animations_modern_effect.cs) | Remove Deprecated Marquee Tags Replace With Css Animations Modern Effect | System.Linq, Console.WriteLine, ParentNode.ReplaceChild, Aspose.Html, HTMLDocument | Replaces `<marquee>` with CSS keyframe animation. |
| [remove_duplicate_id_attributes_by_appending_numeric_suffixes_ensure_uniqueness_throughout_document.cs](./remove_duplicate_id_attributes_by_appending_numeric_suffixes_ensure_uniqueness_throughout_document.cs) | Remove Duplicate Id Attributes By Appending Numeric Suffixes Ensure Uniqueness Throughout Document | StringComparer.OrdinalIgnoreCase, Generic.Dictionary, System.Collections, Console.WriteLine, Elements.Length | Renames duplicate `id`s to make them unique. |
| [remove_inline_style_attributes_from_elements_enforce_external_stylesheet_usage.cs](./remove_inline_style_attributes_from_elements_enforce_external_stylesheet_usage.cs) | Remove Inline Style Attributes From Elements Enforce External Stylesheet Usage | Console.WriteLine, Aspose.Html, HTMLDocument | Strips `style=` attributes to force external CSS. |
| [remove_noscript_elements_simplify_dom_environments_without_javascript.cs](./remove_noscript_elements_simplify_dom_environments_without_javascript.cs) | Remove Noscript Elements Simplify Dom Environments Without Javascript | Console.WriteLine, Aspose.Html, ParentNode.RemoveChild, HTMLDocument | Deletes `<noscript>` blocks. |
| [replace_all_b_tags_with_strong_tags_improve_semantic_markup_throughout_document.cs](./replace_all_b_tags_with_strong_tags_improve_semantic_markup_throughout_document.cs) | Replace All B Tags With Strong Tags Improve Semantic Markup Throughout Document | List.Add, System.Collections, Console.WriteLine, Aspose.Html, HTMLDocument | Swaps `<b>` for `<strong>` for better semantics. |
| [replace_all_inline_event_handler_attributes_with_external_javascript_listeners.cs](./replace_all_inline_event_handler_attributes_with_external_javascript_listeners.cs) | Replace All Inline Event Handler Attributes With External Javascript Listeners | Console.WriteLine, Aspose.Html, HTMLDocument | Moves inline `onclick`, `onload`, etc., to external script listeners. |
| [replace_all_occurrences_non_breaking_space_characters_with_regular_spaces_text_normalization.cs](./replace_all_occurrences_non_breaking_space_characters_with_regular_spaces_text_normalization.cs) | Replace All Occurrences Non Breaking Space Characters With Regular Spaces Text Normalization | HTMLDocument, Html.Replace, Console.WriteLine, Aspose.HTML, Aspose.Html | Normalises NBSP (`\u00A0`) to regular spaces. |
| [replace_all_occurrences_of_deprecated_align_attribute_with_equivalent_css_styling.cs](./replace_all_occurrences_of_deprecated_align_attribute_with_equivalent_css_styling.cs) | Replace All Occurrences Of Deprecated Align Attribute With Equivalent Css Styling | Console.WriteLine, Aspose.Html, HTMLDocument | Converts `align="center"` to `style="text-align:center;"`. |
| [replace_deprecated_font_tags_with_equivalent_css_style_attributes_throughout_document.cs](./replace_deprecated_font_tags_with_equivalent_css_style_attributes_throughout_document.cs) | Replace Deprecated Font Tags With Equivalent Css Style Attributes Throughout Document | System.Linq, System.Collections, Console.WriteLine, Parts.Add, Aspose.Html | Replaces `<font>` tags with CSS `font-family`, `font-size`, etc. |
| [replace_empty_alt_attributes_with_descriptive_text_derived_from_surrounding_caption_elements.cs](./replace_empty_alt_attributes_with_descriptive_text_derived_from_surrounding_caption_elements.cs) | Replace Empty Alt Attributes With Descriptive Text Derived From Surrounding Caption Elements | Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase, Elem.TextContent, Collections.HTMLCollection | Generates `alt` text from nearby `<figcaption>` content. |
| [replace_target_blank_attributes_with_rel_noopener_noreferrer_to_mitigate_security_risks_in_document.cs](./replace_target_blank_attributes_with_rel_noopener_noreferrer_to_mitigate_security_risks_in_document.cs) | Replace Target Blank Attributes With Rel Noopener Noreferrer To Mitigate Security Risks In Document | Console.WriteLine, Aspose.Html, HTMLDocument | Adds `rel="noopener noreferrer"` to all `target="_blank"` links. |
| [retrieve_audio_source_urls_audio_tags_save_manifest_file.cs](./retrieve_audio_source_urls_audio_tags_save_manifest_file.cs) | Retrieve Audio Source Urls Audio Tags Save Manifest File | System.Collections, Element.GetAttribute, Console.WriteLine, System.IO, Urls.Add | Collects `<audio src="">` URLs into a manifest. |
| [retrieve_json_ld_script_blocks_from_html_and_deserialize_into_dotnet_objects.cs](./retrieve_json_ld_script_blocks_from_html_and_deserialize_into_dotnet_objects.cs) | Retrieve Json Ld Script Blocks From Html And Deserialize Into Dotnet Objects | Element.GetAttribute, Element.TextContent, Console.WriteLine, StringComparison.OrdinalIgnoreCase, Elements.Length | Parses `<script type="application/ld+json">` blocks into C# objects. |
| [retrieve_title_element_text_from_loaded_html_document_and_store_in_variable.cs](./retrieve_title_element_text_from_loaded_html_document_and_store_in_variable.cs) | Retrieve Title Element Text From Loaded Html Document And Store In Variable | Console.WriteLine, Aspose.Html, HTMLDocument | Reads the `<title>` element. |
| [retrieve_viewport_meta_tag_value_for_mobile_rendering_settings.cs](./retrieve_viewport_meta_tag_value_for_mobile_rendering_settings.cs) | Retrieve Viewport Meta Tag Value For Mobile Rendering Settings | Console.WriteLine, Aspose.Html | Gets the viewport meta tag content. |
| [rewrite_all_hyperlink_urls_https_scheme_security_compliance.cs](./rewrite_all_hyperlink_urls_https_scheme_security_compliance.cs) | Rewrite All Hyperlink Urls Https Scheme Security Compliance | Element.GetAttribute, Console.WriteLine, StringComparison.OrdinalIgnoreCase, Element.SetAttribute, Aspose.Html | Forces all links to use `https://`. |
| [search_elements_containing_specific_keyword_highlight_add_css_class.cs](./search_elements_containing_specific_keyword_highlight_add_css_class.cs) | Search Elements Containing Specific Keyword Highlight Add Css Class | Console.WriteLine, Aspose.Html, InnerHTML.Contains, HTMLDocument | Highlights elements that contain a given keyword. |
| [select_all_paragraph_elements_css_selector_iterate_extract_plain_text.cs](./select_all_paragraph_elements_css_selector_iterate_extract_plain_text.cs) | Select All Paragraph Elements Css Selector Iterate Extract Plain Text | Console.WriteLine, Aspose.Html | Uses CSS selector to pull plain text from `<p>` tags. |
| [serialize_dom_tree_to_json_representation_for_efficient_client_side_processing.cs](./serialize_dom_tree_to_json_representation_for_efficient_client_side_processing.cs) | Serialize Dom Tree To Json Representation For Efficient Client Side Processing | TextContent.Replace, Console.WriteLine, StringBuilder, Aspose.Html, System.Text | Serialises the DOM into a compact JSON structure. |
| [set_custom_timeout_value_when_loading_html_from_remote_urls_to_avoid_long_waits.cs](./set_custom_timeout_value_when_loading_html_from_remote_urls_to_avoid_long_waits.cs) | Set Custom Timeout Value When Loading Html From Remote Urls To Avoid Long Waits | Console.WriteLine, TimeSpan.FromSeconds, Aspose.Html, RequestMessage, HTMLDocument | Configures a request timeout for remote HTML loads. |
| [split_html_document_into_separate_files_at_each_top_level_heading_for_modular_publishing.cs](./split_html_document_into_separate_files_at_each_top_level_heading_for_modular_publishing.cs) | Split Html Document Into Separate Files At Each Top Level Heading For Modular Publishing | HTMLDocument, Elem.OuterHTML, Content.AppendLine, TagName.Equals, Doc.Body | Breaks a large document into multiple files based on top‑level headings. |
| [transform_html_into_markdown_using_builtin_efficient_conversion_routine.cs](./transform_html_into_markdown_using_builtin_efficient_conversion_routine.cs) | Transform Html Into Markdown Using Builtin Efficient Conversion Routine | Converter.ConvertHTML, Aspose.Html, MarkdownSaveOptions, Console.WriteLine | Converts HTML to Markdown format. |
| [unwrap_images_from_figure_tags_preserving_src_attributes_intact.cs](./unwrap_images_from_figure_tags_preserving_src_attributes_intact.cs) | Unwrap Images From Figure Tags Preserving Src Attributes Intact | Console.WriteLine, ParentNode.RemoveChild, ParentNode.InsertBefore, Aspose.Html, HTMLDocument | Moves `<img>` out of `<figure>` while keeping the `src`. |
| [update_existing_base_tag_href_attribute_to_new_domain_for_site_migration.cs](./update_existing_base_tag_href_attribute_to_new_domain_for_site_migration.cs) | Update Existing Base Tag Href Attribute To New Domain For Site Migration | Console.WriteLine, Aspose.Html, Element.SetAttribute, Elements.Length | Changes the `<base href>` to a new domain. |
| [use_css_selector_find_all_list_items_within_unordered_lists_extract_text.cs](./use_css_selector_find_all_list_items_within_unordered_lists_extract_text.cs) | Use Css Selector Find All List Items Within Unordered Lists Extract Text | Console.WriteLine, Aspose.Html | Retrieves text from `<li>` items inside `<ul>`. |
| [validate_html_structure_against_w3c_standards_and_collect_validation_error_messages.cs](./validate_html_structure_against_w3c_standards_and_collect_validation_error_messages.cs) | Validate Html Structure Against W3C Standards And Collect Validation Error Messages | Result.Success, System.Console, Result.Error, Console.WriteLine, Accessibility.TargetTypes | Runs W3C validation and reports errors. |
| [wrap_each_paragraph_element_inside_div_specific_css_class_layout_control.cs](./wrap_each_paragraph_element_inside_div_specific_css_class_layout_control.cs) | Wrap Each Paragraph Element Inside Div Specific Css Class Layout Control | Console.WriteLine, Div.SetAttribute, Div.AppendChild, Aspose.Html, HTMLDocument | Wraps `<p>` elements in a `<div class="wrapper">`. |

*Note: The table above lists **all 120** examples present in the `html_navigation` folder.*

---

## Category‑Specific Tips

### Key API Surface
* **Document handling** – `HTMLDocument`, `HTMLSaveOptions`, `HTMLLoadOptions`.  
* **Node traversal** – `GetElementsByTagName`, `Elements.Length`, `XPath`, CSS selectors (`QuerySelectorAll`).  
* **Attribute work** – `Element.GetAttribute`, `Element.SetAttribute`, `StringComparison.OrdinalIgnoreCase`.  
* **String utilities** – `TextContent.Trim`, `TagName.ToLower`, `StringBuilder`.  
* **File I/O** – `File.ReadAllText`, `File.WriteAllText`, `Path.Combine`.  
* **Logging** – `Console.WriteLine` (used in every sample).  

### Rules (derived from the 120 samples)

| Rule | Explanation |
|------|-------------|
| **Always log progress** | Every example starts with `Console.WriteLine` to make debugging deterministic. |
| **Check for null / empty before mutating** | Most samples guard `Element.GetAttribute` results with `string.IsNullOrWhiteSpace`. |
| **Use `StringComparison.OrdinalIgnoreCase` for attribute/value checks** | Guarantees case‑insensitive matching for HTML attributes (`rel`, `type`, `href`). |
| **Prefer `Elements.Length` over `Count`** | The Aspose collection exposes `Length`; it is the idiomatic way to iterate. |
| **When adding new attributes, preserve existing content** | E.g., when adding `aria-label`, reuse the element’s text content if possible. |
| **Save with `HTMLSaveOptions.ResourceHandlingOptions = ResourceHandlingOptions.Embed` for self‑contained files** | Frequently used when the output must be portable. |
| **Validate after manipulation** | Use the built‑in validator (`Result.Success`) when structural changes are made. |
| **Keep the DOM clean** – remove empty tags, duplicate IDs, deprecated elements before saving. |
| **When converting URLs, always resolve against `<base>` if present** | Guarantees correct absolute URLs. |
| **Batch operations should reuse a single `HTMLDocument` instance when possible** | Improves performance and reduces memory pressure. |

---

## Warnings

* **Template‑binding mismatches** – If you reference an element that does not exist (e.g., a missing `<nav>`), the code will throw a `NullReferenceException`. Always verify `Elements.Length > 0` before accessing `[0]`.  
* **Missing external resources** – Scripts, stylesheets, or images referenced by relative URLs will fail to load after conversion unless a `<base>` tag is inserted or URLs are made absolute.  
* **File‑path issues** – Hard‑coded absolute paths (`C:\Docs\…`) break on non‑Windows platforms. Prefer `Path.Combine` with `AppDomain.CurrentDomain.BaseDirectory`.  
* **Memory pressure on large documents** – Loading many megabytes of HTML into a single `HTMLDocument` can exhaust memory. Use streaming or process files in batches.  
* **Rendering limits** – Converting to PDF/PNG may require additional resources (fonts, images). Ensure `HTMLSaveOptions` is configured with appropriate `ResourceHandlingOptions`.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – The sample must compile and run without external project references other than the namespaces listed above.  
2. **Console‑first** – Begin with `Console.WriteLine` statements that describe each step (load, modify, save).  
3. **Follow the common pattern** – Load → locate → manipulate → (optional convert) → save.  
4. **Naming** – File name should be `verb_noun_description.cs` in PascalCase, matching the existing convention.  
5. **Update statistics** – After adding a file, increment `total_examples` and the relevant namespace/API counts in `agents.md`.  

---