---
name: markdown_processing
description: C# examples for markdown_processing using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – markdown_processing

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **markdown_processing** category.
This folder contains standalone C# examples for markdown_processing operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

## Scope

- **Category name:** markdown_processing  
- **Total examples:** 119  
- **Typical workflow:**  
  1. **Load** a Markdown or HTML source (file, string, or stream).  
  2. **Bind** any required data or configuration (e.g., paths, options).  
  3. **Convert** using `Converter.ConvertMarkdown` or `Converter.ConvertHTML`.  
  4. **Render / Save** the result with `HTMLDocument`, `DocSaveOptions`, `MarkdownSaveOptions`, or write directly to disk.

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | 119 |
| Aspose.Html | 91 |
| Aspose.Html.Dom | 69 |
| System.IO | 43 |
| Aspose.Html.Converters | 24 |
| Aspose.Html.Saving | 19 |
| Aspose.Html.Collections | 18 |
| System.Collections.Generic | 14 |
| System.Text | 10 |
| System.Text.RegularExpressions | 10 |
| System.Linq | 9 |
| System.Text.Json | 3 |
| Aspose.Html.Toolkit.Markdown.Syntax | 3 |
| Aspose.Html.Toolkit.Markdown.Syntax.Parser | 3 |
| Aspose.Html.Net | 3 |
| System.Globalization | 2 |
| Aspose.Html.Dom.XPath | 1 |
| Aspose.Html.Dom.Traversal | 1 |
| System.Xml.Linq | 1 |
| Aspose.Html.Rendering | 1 |
| Aspose.Html.Accessibility | 1 |
| Aspose.Html.Accessibility.Results | 1 |

### How to import them

```csharp
using System;
using Aspose.Html;
using Aspose.Html.Dom;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text.Json;
using Aspose.Html.Toolkit.Markdown.Syntax;
using Aspose.Html.Toolkit.Markdown.Syntax.Parser;
using Aspose.Html.Net;
using System.Globalization;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Dom.Traversal;
using System.Xml.Linq;
using Aspose.Html.Rendering;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
```

## Common Code Pattern

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        // 1️⃣ Load – read a markdown file
        string markdownPath = Path.Combine(Environment.CurrentDirectory, "sample.md");
        string markdown = File.ReadAllText(markdownPath);

        // 2️⃣ Convert – markdown → HTML document
        HTMLDocument doc = Converter.ConvertMarkdown(markdown);

        // 3️⃣ Optional manipulation – e.g., add a comment at the top
        var comment = doc.CreateComment("Processed by Aspose.HTML on " + DateTime.Now);
        doc.Body.InsertBefore(comment, doc.Body.FirstChild);

        // 4️⃣ Render / Save – HTML → file
        var saveOptions = new HtmlSaveOptions();
        string htmlPath = Path.ChangeExtension(markdownPath, ".html");
        doc.Save(htmlPath, saveOptions);

        Console.WriteLine($"Conversion complete: {htmlPath}");
    }
}
```

## Frequently Used APIs

| API | Appearances |
|-----|-------------|
| Console.WriteLine | 119 |
| Aspose.Html | 103 |
| HTMLDocument | 61 |
| System.IO | 46 |
| System.Text | 25 |
| File.ReadAllText | 18 |
| File.WriteAllText | 17 |
| System.Collections | 17 |
| Converter.ConvertHTML | 16 |
| Path.Combine | 14 |
| TextContent.Trim | 14 |
| Converter.ConvertMarkdown | 13 |
| MarkdownSaveOptions | 12 |
| System.Linq | 9 |
| Regex.Replace | 9 |
| Body.AppendChild | 8 |
| Directory.Exists | 8 |
| StringComparison.OrdinalIgnoreCase | 7 |
| TagName.ToLower | 7 |
| Directory.GetFiles | 7 |

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [Add Author Metadata Comment Beginning Markdown File Documentation](./add_author_metadata_comment_beginning_markdown_file_documentation.cs) | Add Author Metadata Comment Beginning Markdown File Documentation | DocSaveOptions, File.WriteAllText, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Add Bullet List Generated From Array Of Strings At Designated Location In Document](./add_bullet_list_generated_from_array_of_strings_at_designated_location_in_document.cs) | Add Bullet List Generated From Array Of Strings At Designated Location In Document | Console.WriteLine, System.IO, Environment.CurrentDirectory | Creates or manipulates an HTML document. |
| [Add Custom Attribute Heading Nodes Seo Without Altering Visible Text](./add_custom_attribute_heading_nodes_seo_without_altering_visible_text.cs) | Add Custom Attribute Heading Nodes Seo Without Altering Visible Text | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Add Custom Data Attribute To List Nodes Indicating Ordered Or Unordered](./add_custom_data_attribute_to_list_nodes_indicating_ordered_or_unordered.cs) | Add Custom Data Attribute To List Nodes Indicating Ordered Or Unordered | TagName.Equals, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [Add Html Comment With Line Numbers Before Each Paragraph Node For Debugging](./add_html_comment_with_line_numbers_before_each_paragraph_node_for_debugging.cs) | Add Html Comment With Line Numbers Before Each Paragraph Node For Debugging | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Add Language Identifiers To Fenced Code Blocks Proper Syntax Highlighting In Rendered Output](./add_language_identifiers_to_fenced_code_blocks_proper_syntax_highlighting_in_rendered_output.cs) | Add Language Identifiers To Fenced Code Blocks Proper Syntax Highlighting In Rendered Output | Console.WriteLine, HTMLDocument, Aspose.Html | Creates or manipulates an HTML document. |
| [Add Missing Alt Text To Images Lacking Descriptions With Default Placeholder](./add_missing_alt_text_to_images_lacking_descriptions_with_default_placeholder.cs) | Add Missing Alt Text To Images Lacking Descriptions With Default Placeholder | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Add Timestamp Comment Indicating Processing Time At Top Of Markdown File](./add_timestamp_comment_indicating_processing_time_at_top_of_markdown_file.cs) | Add Timestamp Comment Indicating Processing Time At Top Of Markdown File | File.WriteAllText, DateTime.Now, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Add Title Attribute To Image Markdown Nodes For Additional Tooltip Information](./add_title_attribute_to_image_markdown_nodes_for_additional_tooltip_information.cs) | Add Title Attribute To Image Markdown Nodes For Additional Tooltip Information | Console.WriteLine, Path.GetFileName, System.IO | Creates or manipulates an HTML document. |
| [Add Yaml Front Matter Block At Top With Custom Metadata Fields For Document](./add_yaml_front_matter_block_at_top_with_custom_metadata_fields_for_document.cs) | Add Yaml Front Matter Block At Top With Custom Metadata Fields For Document | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Append Disclaimer Paragraph At End Of File For Usage Terms](./append_disclaimer_paragraph_at_end_of_file_for_usage_terms.cs) | Append Disclaimer Paragraph At End Of File For Usage Terms | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Append List Of Tags To Yaml Front Matter Based On Extracted Heading Keywords](./append_list_of_tags_to_yaml_front_matter_based_on_extracted_heading_keywords.cs) | Append List Of Tags To Yaml Front Matter Based On Extracted Heading Keywords | Children.Add, TagName.ToLower, Path.GetFileNameWithoutExtension | Creates or manipulates an HTML document. |
| [Append New Level Two Heading With Custom Text At End Of Markdown Document](./append_new_level_two_heading_with_custom_text_at_end_of_markdown_document.cs) | Append New Level Two Heading With Custom Text At End Of Markdown Document | Encoding.UTF8, Converter.ConvertMarkdown, Body.AppendChild | Creates or manipulates an HTML document. |
| [Apply Custom Css Class All Code Block Nodes Modifying Syntax Properties](./apply_custom_css_class_all_code_block_nodes_modifying_syntax_properties.cs) | Apply Custom Css Class All Code Block Nodes Modifying Syntax Properties | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Apply Regular Expression To Mask Email Addresses In All Text Nodes For Privacy Compliance](./apply_regular_expression_to_mask_email_addresses_in_all_text_nodes_for_privacy_compliance.cs) | Apply Regular Expression To Mask Email Addresses In All Text Nodes For Privacy Compliance | Regex.Replace, Console.WriteLine, XPathResultType.Any | Creates or manipulates an HTML document. |
| [Batch Heading Updates Across Multiple Markdown Files In Folder Using Shared Configuration](./batch_heading_updates_across_multiple_markdown_files_in_folder_using_shared_configuration.cs) | Batch Heading Updates Across Multiple Markdown Files In Folder Using Shared Configuration | TextContent.Trim, MarkdownFeatures.AutomaticParagraph, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Batch Processing Update Heading Prefixes Markdown Files Specified Directory](./batch_processing_update_heading_prefixes_markdown_files_specified_directory.cs) | Batch Processing Update Heading Prefixes Markdown Files Specified Directory | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Collapse Multiple Consecutive Blank Lines Into Single Blank Line Throughout Document](./collapse_multiple_consecutive_blank_lines_into_single_blank_line_throughout_document.cs) | Collapse Multiple Consecutive Blank Lines Into Single Blank Line Throughout Document | Console.WriteLine, System.IO, File.ReadAllText | Creates or manipulates an HTML document. |
| [Compare Two Markdownsyntax Tree Objects Structural Equality Detect Unintended Modifications Version Control](./compare_two_markdownsyntax_tree_objects_structural_equality_detect_unintended_modifications_version_control.cs) | Compare Two Markdownsyntax Tree Objects Structural Equality Detect Unintended Modifications Version Control | Tree.ToString, Toolkit.Markdown, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Convert All Uppercase Heading Texts To Title Case Preserving Hash Level Markers](./convert_all_uppercase_heading_texts_to_title_case_preserving_hash_level_markers.cs) | Convert All Uppercase Heading Texts To Title Case Preserving Hash Level Markers | Text.ToUpperInvariant, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Convert Blockquote Sections To Italic Paragraphs Simplify Formatting Retaining Emphasis](./convert_blockquote_sections_to_italic_paragraphs_simplify_formatting_retaining_emphasis.cs) | Convert Blockquote Sections To Italic Paragraphs Simplify Formatting Retaining Emphasis | System.Linq, Console.WriteLine, ParentNode.ReplaceChild | Creates or manipulates an HTML document. |
| [Convert Existing Markdown Tables To Plain Text Preserving Column Alignment](./convert_existing_markdown_tables_to_plain_text_preserving_column_alignment.cs) | Convert Existing Markdown Tables To Plain Text Preserving Column Alignment | Converter.ConvertMarkdown, Console.WriteLine, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Convert Heading Texts To Title Case Keeping Existing Hash Level Markers](./convert_heading_texts_to_title_case_keeping_existing_hash_level_markers.cs) | Convert Heading Texts To Title Case Keeping Existing Hash Level Markers | System.Linq, Encoding.UTF8, CultureInfo.CurrentCulture | Creates or manipulates an HTML document. |
| [Convert Inline Markdown Links To Reference Style Links Generate Reference List Bottom](./convert_inline_markdown_links_to_reference_style_links_generate_reference_list_bottom.cs) | Convert Inline Markdown Links To Reference Style Links Generate Reference List Bottom | System.Linq, System.Collections, File.WriteAllText | Demonstrates a specific Aspose.HTML operation. |
| [Convert Markdown Emphasis Markers From Single To Double Asterisks Stronger Emphasis](./convert_markdown_emphasis_markers_from_single_to_double_asterisks_stronger_emphasis.cs) | Convert Markdown Emphasis Markers From Single To Double Asterisks Stronger Emphasis | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Convert Markdown Footnotes Endnotes Adjust References Throughout Document](./convert_markdown_footnotes_endnotes_adjust_references_throughout_document.cs) | Convert Markdown Footnotes Endnotes Adjust References Throughout Document | DocSaveOptions, File.WriteAllText, Div.AppendChild | Converts HTML content to another format using Aspose.HTML. |
| [Convert Tabs To Spaces Code Blocks Maintain Consistent Formatting Editors](./convert_tabs_to_spaces_code_blocks_maintain_consistent_formatting_editors.cs) | Convert Tabs To Spaces Code Blocks Maintain Consistent Formatting Editors | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Convert Task List Items Regular Bullet Points Simplify Document Formatting](./convert_task_list_items_regular_bullet_points_simplify_document_formatting.cs) | Convert Task List Items Regular Bullet Points Simplify Document Formatting | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Convert Unordered List Items Into Ordered List Preserving Hierarchy](./convert_unordered_list_items_into_ordered_list_preserving_hierarchy.cs) | Convert Unordered List Items Into Ordered List Preserving Hierarchy | Console.WriteLine, Elements.Length, ParentNode.ReplaceChild | Creates or manipulates an HTML document. |
| [Count Number Headings Each Level Output Statistics Comment](./count_number_headings_each_level_output_statistics_comment.cs) | Count Number Headings Each Level Output Statistics Comment | Console.WriteLine, TagName.ToLower, Builder.ToString | Creates or manipulates an HTML document. |
| [Create Custom Transformation Wrap Paragraph Text In Span With Specific Css Class](./create_custom_transformation_wrap_paragraph_text_in_span_with_specific_css_class.cs) | Create Custom Transformation Wrap Paragraph Text In Span With Specific Css Class | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Create Markdown Table From Two Dimensional Data Array And Insert After Heading](./create_markdown_table_from_two_dimensional_data_array_and_insert_after_heading.cs) | Create Markdown Table From Two Dimensional Data Array And Insert After Heading | Cells.Length, Rows.Length, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Decrypt Previously Encrypted Markdown Nodes Restore Original Content Further Editing](./decrypt_previously_encrypted_markdown_nodes_restore_original_content_further_editing.cs) | Decrypt Previously Encrypted Markdown Nodes Restore Original Content Further Editing | Encoding.UTF8, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Delete Specific List Item Identified By Text Content From Markdown List](./delete_specific_list_item_identified_by_text_content_from_markdown_list.cs) | Delete Specific List Item Identified By Text Content From Markdown List | TextContent.Trim, Converters.Converter, Console.WriteLine | Creates or manipulates an HTML document. |
| [Depth First Traversal Collect Text Nodes Into List For Bulk Processing](./depth_first_traversal_collect_text_nodes_into_list_for_bulk_processing.cs) | Depth First Traversal Collect Text Nodes Into List For Bulk Processing | System.Collections, Node.TEXT_NODE, Console.WriteLine | Creates or manipulates an HTML document. |
| [Detect And Fix Inconsistent Indentation In Nested Lists To Ensure Proper Hierarchical Rendering](./detect_and_fix_inconsistent_indentation_in_nested_lists_to_ensure_proper_hierarchical_rendering.cs) | Detect And Fix Inconsistent Indentation In Nested Lists To Ensure Proper Hierarchical Rendering | Console.WriteLine, TextContent.Trim, Aspose.Html | Creates or manipulates an HTML document. |
| [Detect Broken Image Links By Checking Each Image Url Http Response Status](./detect_broken_image_links_by_checking_each_image_url_http_response_status.cs) | Detect Broken Image Links By Checking Each Image Url Http Response Status | System.Collections, Element.GetAttribute, Url.ToString | Creates or manipulates an HTML document. |
| [Detect Duplicate Heading Texts Rename With Unique Identifiers Avoid Ambiguity](./detect_duplicate_heading_texts_rename_with_unique_identifiers_avoid_ambiguity.cs) | Detect Duplicate Heading Texts Rename With Unique Identifiers Avoid Ambiguity | TextContent.Trim, StringComparer.OrdinalIgnoreCase, System.Collections | Creates or manipulates an HTML document. |
| [Detect Github Flavored Markdown Features In Document Log Identified Elements](./detect_github_flavored_markdown_features_in_document_log_identified_elements.cs) | Detect Github Flavored Markdown Features In Document Log Identified Elements | Converter.ConvertMarkdown, Console.WriteLine, ListItems.Length | Creates or manipulates an HTML document. |
| [Detect Mismatched Markdown Delimiters Automatically Correct Maintain Valid Syntax](./detect_mismatched_markdown_delimiters_automatically_correct_maintain_valid_syntax.cs) | Detect Mismatched Markdown Delimiters Automatically Correct Maintain Valid Syntax | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Detect Remove Stray Backticks Not Form Valid Code Spans Clean Markup](./detect_remove_stray_backticks_not_form_valid_code_spans_clean_markup.cs) | Detect Remove Stray Backticks Not Form Valid Code Spans Clean Markup | Console.WriteLine, Aspose.Html, InnerHTML.Replace | Creates or manipulates an HTML document. |
| [Detect Unescaped Special Characters In Urls And Escape To Prevent Parsing Errors](./detect_unescaped_special_characters_in_urls_and_escape_to_prevent_parsing_errors.cs) | Detect Unescaped Special Characters In Urls And Escape To Prevent Parsing Errors | Element.GetAttribute, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Encrypt Specific Markdown Nodes Using Custom Wrapper To Protect Sensitive Content Before Saving](./encrypt_specific_markdown_nodes_using_custom_wrapper_to_protect_sensitive_content_before_saving.cs) | Encrypt Specific Markdown Nodes Using Custom Wrapper To Protect Sensitive Content Before Saving | File.WriteAllText, Converters.Converter, Doc.CreateElement | Creates or manipulates an HTML document. |
| [Ensure Each List Preceded By Blank Line Markdown Spacing Conventions](./ensure_each_list_preceded_by_blank_line_markdown_spacing_conventions.cs) | Ensure Each List Preceded By Blank Line Markdown Spacing Conventions | StreamWriter, File.ReadAllLines, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Ensure Every Heading Node Ends Newline Character Maintain Valid Markdown Syntax](./ensure_every_heading_node_ends_newline_character_maintain_valid_markdown_syntax.cs) | Ensure Every Heading Node Ends Newline Character Maintain Valid Markdown Syntax | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Ensure Markdown File Ends Single Newline Parser Requirements](./ensure_markdown_file_ends_single_newline_parser_requirements.cs) | Ensure Markdown File Ends Single Newline Parser Requirements | File.WriteAllText, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Escape Special Markdown Characters In All Text Nodes To Prevent Unintended Formatting](./escape_special_markdown_characters_in_all_text_nodes_to_prevent_unintended_formatting.cs) | Escape Special Markdown Characters In All Text Nodes To Prevent Unintended Formatting | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Export Entire Markdownsyntax Tree To Xml For Archival And Version Control](./export_entire_markdownsyntax_tree_to_xml_for_archival_and_version_control.cs) | Export Entire Markdownsyntax Tree To Xml For Archival And Version Control | XDocument, Converter.ConvertMarkdown, Console.WriteLine | Creates or manipulates an HTML document. |
| [Extract All Hyperlink Urls From Markdown Document And Store In List](./extract_all_hyperlink_urls_from_markdown_document_and_store_in_list.cs) | Extract All Hyperlink Urls From Markdown Document And Store In List | System.Collections, Element.GetAttribute, Converter.ConvertMarkdown | Creates or manipulates an HTML document. |
| [Extract List Items From Document Write Separate Markdown File](./extract_list_items_from_document_write_separate_markdown_file.cs) | Extract List Items From Document Write Separate Markdown File | TextContent.Trim, System.Collections, Console.WriteLine | Creates or manipulates an HTML document. |
| [Extract Task List Items Into Json Array For External Processing Reporting](./extract_task_list_items_into_json_array_for_external_processing_reporting.cs) | Extract Task List Items Into Json Array For External Processing Reporting | System.Collections, File.ReadAllLines, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Generate Consolidated Reference List For All Urls Used In Document And Insert](./generate_consolidated_reference_list_for_all_urls_used_in_document_and_insert.cs) | Generate Consolidated Reference List For All Urls Used In Document And Insert | List.Add, System.Collections, Element.GetAttribute | Creates or manipulates an HTML document. |
| [Generate Html Preview Of Markdown Content Using Built In Renderer For Visual Verification](./generate_html_preview_of_markdown_content_using_built_in_renderer_for_visual_verification.cs) | Generate Html Preview Of Markdown Content Using Built In Renderer For Visual Verification | Encoding.UTF8, Element.TextContent, Converter.ConvertMarkdown | Creates or manipulates an HTML document. |
| [Generate Index Markdown File Linking Each Split Chapter File Quick Access](./generate_index_markdown_file_linking_each_split_chapter_file_quick_access.cs) | Generate Index Markdown File Linking Each Split Chapter File Quick Access | System.Linq, Files.Select, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Generate Json Representation Heading Hierarchy External Analysis Integration](./generate_json_representation_heading_hierarchy_external_analysis_integration.cs) | Generate Json Representation Heading Hierarchy External Analysis Integration | TextContent.Trim, System.Collections, Children.Add | Creates or manipulates an HTML document. |
| [Generate Report Summarizing Modifications Made To Markdown File Including Counts Of Each Change Type](./generate_report_summarizing_modifications_made_to_markdown_file_including_counts_of_each_change_type.cs) | Generate Report Summarizing Modifications Made To Markdown File Including Counts Of Each Change Type | StreamWriter, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Generate Summary Paragraph Document Length Main Topics](./generate_summary_paragraph_document_length_main_topics.cs) | Generate Summary Paragraph Document Length Main Topics | Body.TextContent, Console.WriteLine, Text.Length | Creates or manipulates an HTML document. |
| [Generate Table Of Contents Based On Heading Hierarchy And Insert At Top](./generate_table_of_contents_based_on_heading_hierarchy_and_insert_at_top.cs) | Generate Table Of Contents Based On Heading Hierarchy And Insert At Top | TextContent.Trim, Root.AppendChild, Guid.NewGuid | Creates or manipulates an HTML document. |
| [Generate Word Count Statistic And Embed As Comment At Top Of Document](./generate_word_count_statistic_and_embed_as_comment_at_top_of_document.cs) | Generate Word Count Statistic And Embed As Comment At Top Of Document | Body.TextContent, Dom.Comment, Body.AppendChild | Creates or manipulates an HTML document. |
| [Highlight Code Block Syntax By Assigning Custom Css Class Through Node Property Modification](./highlight_code_block_syntax_by_assigning_custom_css_class_through_node_property_modification.cs) | Highlight Code Block Syntax By Assigning Custom Css Class Through Node Property Modification | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Implement Lazy Loading For Large Images By Inserting Placeholder Syntax Before Actual Image References](./implement_lazy_loading_for_large_images_by_inserting_placeholder_syntax_before_actual_image_references.cs) | Implement Lazy Loading For Large Images By Inserting Placeholder Syntax Before Actual Image References | File.WriteAllText, Element.GetAttribute, Console.WriteLine | Creates or manipulates an HTML document. |
| [Insert Checklist Items Using Task List Syntax Set Initial Checked State](./insert_checklist_items_using_task_list_syntax_set_initial_checked_state.cs) | Insert Checklist Items Using Task List Syntax Set Initial Checked State | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Insert Copyright Notice Immediately After First Heading Assert Ownership](./insert_copyright_notice_immediately_after_first_heading_assert_ownership.cs) | Insert Copyright Notice Immediately After First Heading Assert Ownership | Console.WriteLine, Aspose.Html, Para.AppendChild | Creates or manipulates an HTML document. |
| [Insert Footnote Definitions At End Of Document For Each Referenced Footnote Marker](./insert_footnote_definitions_at_end_of_document_for_each_referenced_footnote_marker.cs) | Insert Footnote Definitions At End Of Document For Each Referenced Footnote Marker | Ids.Add, Ids.Count, System.Collections | Creates or manipulates an HTML document. |
| [Insert Generated Table Of Contents After Front Matter Block To Improve Navigation](./insert_generated_table_of_contents_after_front_matter_block_to_improve_navigation.cs) | Insert Generated Table Of Contents After Front Matter Block To Improve Navigation | Body.AppendChild, Guid.NewGuid, Console.WriteLine | Creates or manipulates an HTML document. |
| [Insert Horizontal Rule After Top Level Heading To Visually Separate Sections](./insert_horizontal_rule_after_top_level_heading_to_visually_separate_sections.cs) | Insert Horizontal Rule After Top Level Heading To Visually Separate Sections | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Insert Horizontal Rule Before Each Code Block Visually Separate Code Surrounding Text](./insert_horizontal_rule_before_each_code_block_visually_separate_code_surrounding_text.cs) | Insert Horizontal Rule Before Each Code Block Visually Separate Code Surrounding Text | Console.WriteLine, Aspose.Html, ParentNode.InsertBefore | Creates or manipulates an HTML document. |
| [Insert Line Break Within Long Heading Text Improve Readability Narrow Screens](./insert_line_break_within_long_heading_text_improve_readability_narrow_screens.cs) | Insert Line Break Within Long Heading Text Improve Readability Narrow Screens | Console.WriteLine, Aspose.Html, Dom.Text | Creates or manipulates an HTML document. |
| [Insert Markdown Comment Before Each Heading Indicating Hierarchical Level For Easier Navigation](./insert_markdown_comment_before_each_heading_indicating_hierarchical_level_for_easier_navigation.cs) | Insert Markdown Comment Before Each Heading Indicating Hierarchical Level For Easier Navigation | Console.WriteLine, TagName.ToLower, ParentNode.InsertBefore | Creates or manipulates an HTML document. |
| [Insert Subheading Under Specified Parent Heading Using Markdownsyntaxfactory Create Nodes](./insert_subheading_under_specified_parent_heading_using_markdownsyntaxfactory_create_nodes.cs) | Insert Subheading Under Specified Parent Heading Using Markdownsyntaxfactory Create Nodes | Heading.AppendChild, Toolkit.Markdown, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Insert Table Of Figures Generated From Image Captions After Table Of Contents](./insert_table_of_figures_generated_from_image_captions_after_table_of_contents.cs) | Insert Table Of Figures Generated From Image Captions After Table Of Contents | HTMLSaveOptions, Div.AppendChild, Console.WriteLine | Creates or manipulates an HTML document. |
| [Load All Md Files From Directory And Parse Each Into Separate Syntax Trees](./load_all_md_files_from_directory_and_parse_each_into_separate_syntax_trees.cs) | Load All Md Files From Directory And Parse Each Into Separate Syntax Trees | Toolkit.Markdown, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Load Previously Saved Xml Representation Of Syntax Tree And Reconstruct Markdown Document](./load_previously_saved_xml_representation_of_syntax_tree_and_reconstruct_markdown_document.cs) | Load Previously Saved Xml Representation Of Syntax Tree And Reconstruct Markdown Document | Console.WriteLine, Converter.ConvertHTML, MarkdownSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Merge Consecutive List Items Single Paragraph Simplify Presentation](./merge_consecutive_list_items_single_paragraph_simplify_presentation.cs) | Merge Consecutive List Items Single Paragraph Simplify Presentation | TextContent.Trim, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [Merge Consecutive Paragraph Nodes Into Single Paragraph Reduce Unnecessary Breaks](./merge_consecutive_paragraph_nodes_into_single_paragraph_reduce_unnecessary_breaks.cs) | Merge Consecutive Paragraph Nodes Into Single Paragraph Reduce Unnecessary Breaks | Console.WriteLine, Aspose.Html, TagName.ToLower | Creates or manipulates an HTML document. |
| [Merge Two Markdown Documents Preserving Heading Hierarchy Inserting Separator Comment](./merge_two_markdown_documents_preserving_heading_hierarchy_inserting_separator_comment.cs) | Merge Two Markdown Documents Preserving Heading Hierarchy Inserting Separator Comment | Body.ChildNodes, MarkdownFeatures.AutomaticParagraph, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Normalize All Line Endings Document To Lf Characters Consistent Cross Platform Behavior](./normalize_all_line_endings_document_to_lf_characters_consistent_cross_platform_behavior.cs) | Normalize All Line Endings Document To Lf Characters Consistent Cross Platform Behavior | File.WriteAllText, System.IO, File.ReadAllText | Demonstrates a specific Aspose.HTML operation. |
| [Optimize Image Markdown Adding Width Attributes Improve Rendering Performance Web Pages](./optimize_image_markdown_adding_width_attributes_improve_rendering_performance_web_pages.cs) | Optimize Image Markdown Adding Width Attributes Improve Rendering Performance Web Pages | Console.WriteLine, Aspose.Html, Element.SetAttribute | Creates or manipulates an HTML document. |
| [Parse Single Markdown File Into Markdown Syntax Tree Using Markdown Parser](./parse_single_markdown_file_into_markdown_syntax_tree_using_markdown_parser.cs) | Parse Single Markdown File Into Markdown Syntax Tree Using Markdown Parser | Toolkit.Markdown, Console.WriteLine, Syntax.Parser | Demonstrates a specific Aspose.HTML operation. |
| [Prefix Each Heading With Sequential Numeric Index To Create Ordered Document Outline](./prefix_each_heading_with_sequential_numeric_index_to_create_ordered_document_outline.cs) | Prefix Each Heading With Sequential Numeric Index To Create Ordered Document Outline | Console.WriteLine, TextContent.Trim, Aspose.Html | Creates or manipulates an HTML document. |
| [Prepend Note All Blockquote Contents Highlight Important Information](./prepend_note_all_blockquote_contents_highlight_important_information.cs) | Prepend Note All Blockquote Contents Highlight Important Information | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Remove All Empty List Items Clean Up List Structures Avoid Rendering Issues](./remove_all_empty_list_items_clean_up_list_structures_avoid_rendering_issues.cs) | Remove All Empty List Items Clean Up List Structures Avoid Rendering Issues | System.Linq, Items.ToList, Console.WriteLine | Creates or manipulates an HTML document. |
| [Remove Blockquote Formatting Preserving Text Flatten Document Structure](./remove_blockquote_formatting_preserving_text_flatten_document_structure.cs) | Remove Blockquote Formatting Preserving Text Flatten Document Structure | Console.WriteLine, ParentNode.RemoveChild, ParentNode.InsertBefore | Creates or manipulates an HTML document. |
| [Remove Duplicate Paragraph Nodes Eliminate Redundant Content Streamline Document](./remove_duplicate_paragraph_nodes_eliminate_redundant_content_streamline_document.cs) | Remove Duplicate Paragraph Nodes Eliminate Redundant Content Streamline Document | Console.WriteLine, System.Collections, Aspose.Html | Creates or manipulates an HTML document. |
| [Remove Embedded Html Tags Markdown Content Ensure Pure Markdown Output](./remove_embedded_html_tags_markdown_content_ensure_pure_markdown_output.cs) | Remove Embedded Html Tags Markdown Content Ensure Pure Markdown Output | File.WriteAllText, DocumentElement.TextContent, Console.WriteLine | Creates or manipulates an HTML document. |
| [Remove Empty Paragraph Nodes From Syntax Tree Clean Up Document Structure](./remove_empty_paragraph_nodes_from_syntax_tree_clean_up_document_structure.cs) | Remove Empty Paragraph Nodes From Syntax Tree Clean Up Document Structure | Console.WriteLine, Aspose.Html, ParentNode.RemoveChild | Creates or manipulates an HTML document. |
| [Remove Existing Yaml Front Matter Block Revert Document To Plain Markdown](./remove_existing_yaml_front_matter_block_revert_document_to_plain_markdown.cs) | Remove Existing Yaml Front Matter Block Revert Document To Plain Markdown | System.Collections, File.ReadAllLines, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Remove Markdown Comments From Document Produce Clean Version Without Annotations](./remove_markdown_comments_from_document_produce_clean_version_without_annotations.cs) | Remove Markdown Comments From Document Produce Clean Version Without Annotations | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Renumber Ordered List After Deleting Items Maintain Proper Numeric Ordering](./renumber_ordered_list_after_deleting_items_maintain_proper_numeric_ordering.cs) | Renumber Ordered List After Deleting Items Maintain Proper Numeric Ordering | System.Linq, Console.WriteLine, Collection.ToList | Creates or manipulates an HTML document. |
| [Reorder List Items Alphabetically Based On Text Values And Update Syntax Tree](./reorder_list_items_alphabetically_based_on_text_values_and_update_syntax_tree.cs) | Reorder List Items Alphabetically Based On Text Values And Update Syntax Tree | TextContent.Trim, System.Collections, Generic.List | Creates or manipulates an HTML document. |
| [Replace All Em Dashes Double Hyphens Ensure Compatibility Plain Text Viewers](./replace_all_em_dashes_double_hyphens_ensure_compatibility_plain_text_viewers.cs) | Replace All Em Dashes Double Hyphens Ensure Compatibility Plain Text Viewers | File.WriteAllText, System.IO, File.ReadAllText | Demonstrates a specific Aspose.HTML operation. |
| [Replace All Inline Html Tags With Equivalent Markdown Syntax To Maintain Pure Markdown Formatting](./replace_all_inline_html_tags_with_equivalent_markdown_syntax_to_maintain_pure_markdown_formatting.cs) | Replace All Inline Html Tags With Equivalent Markdown Syntax To Maintain Pure Markdown Formatting | Converter.ConvertHTML, Aspose.Html, MarkdownSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Replace Content First Paragraph Node New Text Retaining Formatting](./replace_content_first_paragraph_node_new_text_retaining_formatting.cs) | Replace Content First Paragraph Node New Text Retaining Formatting | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Replace Double Spaces With Single Spaces In All Text Nodes To Improve Readability](./replace_double_spaces_with_single_spaces_in_all_text_nodes_to_improve_readability.cs) | Replace Double Spaces With Single Spaces In All Text Nodes To Improve Readability | Console.WriteLine, Node.Data, Regex.Replace | Creates or manipulates an HTML document. |
| [Replace Existing Image Urls With Cdn Hosted Equivalents To Improve Loading Performance For Users](./replace_existing_image_urls_with_cdn_hosted_equivalents_to_improve_loading_performance_for_users.cs) | Replace Existing Image Urls With Cdn Hosted Equivalents To Improve Loading Performance For Users | Element.GetAttribute, Url.ToString, Uri | Creates or manipulates an HTML document. |
| [Replace Inline Code Spans Emphasized Text Alternative Formatting Options](./replace_inline_code_spans_emphasized_text_alternative_formatting_options.cs) | Replace Inline Code Spans Emphasized Text Alternative Formatting Options | Console.WriteLine, Aspose.Html, Elements.Length | Creates or manipulates an HTML document. |
| [Replace Markdown Image Syntax With Html Img Tags Preserving Alt Text And Source Attributes](./replace_markdown_image_syntax_with_html_img_tags_preserving_alt_text_and_source_attributes.cs) | Replace Markdown Image Syntax With Html Img Tags Preserving Alt Text And Source Attributes | File.WriteAllText, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Replace Markdown Tables Csv Code Fences Provide Raw Data Format](./replace_markdown_tables_csv_code_fences_provide_raw_data_format.cs) | Replace Markdown Tables Csv Code Fences Provide Raw Data Format | TextContent.Trim, Console.WriteLine, Builder.ToString | Creates or manipulates an HTML document. |
| [Save Generated Html Preview To Temporary File For Automated Testing Workflows](./save_generated_html_preview_to_temporary_file_for_automated_testing_workflows.cs) | Save Generated Html Preview To Temporary File For Automated Testing Workflows | Console.WriteLine, System.IO, Path.GetTempPath | Creates or manipulates an HTML document. |
| [Save Updated Markdown Document Preserving Original File Encoding And Line Ending Style](./save_updated_markdown_document_preserving_original_file_encoding_and_line_ending_style.cs) | Save Updated Markdown Document Preserving Original File Encoding And Line Ending Style | Converter.ConvertHTML, Aspose.Html, MarkdownSaveOptions.Git | Converts HTML content to another format using Aspose.HTML. |
| [Serialize Modified Markdown Syntax Tree To String With Custom Indentation For Readability](./serialize_modified_markdown_syntax_tree_to_string_with_custom_indentation_for_readability.cs) | Serialize Modified Markdown Syntax Tree To String With Custom Indentation For Readability | Children.Add, System.Collections, Generic.List | Demonstrates a specific Aspose.HTML operation. |
| [Split Document Into Chapters Based On Level 2 Headings And Save Each Separate File](./split_document_into_chapters_based_on_level_2_headings_and_save_each_separate_file.cs) | Split Document Into Chapters Based On Level 2 Headings And Save Each Separate File | TagName.Equals, Doc.Body, Console.WriteLine | Creates or manipulates an HTML document. |
| [Split Long Paragraph Into Two Nodes Sentence Boundary](./split_long_paragraph_into_two_nodes_sentence_boundary.cs) | Split Long Paragraph Into Two Nodes Sentence Boundary | Text.IndexOf, Console.WriteLine, Text.Length | Creates or manipulates an HTML document. |
| [Split Markdown Document Into Separate Files Per Top Level Heading Modular Sections](./split_markdown_document_into_separate_files_per_top_level_heading_modular_sections.cs) | Split Markdown Document Into Separate Files Per Top Level Heading Modular Sections | TagName.Equals, StringComparison.OrdinalIgnoreCase, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Toggle Checked State Of Task List Items Programmatically To Reflect Completion Status](./toggle_checked_state_of_task_list_items_programmatically_to_reflect_completion_status.cs) | Toggle Checked State Of Task List Items Programmatically To Reflect Completion Status | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Trim Leading And Trailing Whitespace From Every Text Node Consistent Spacing](./trim_leading_and_trailing_whitespace_from_every_text_node_consistent_spacing.cs) | Trim Leading And Trailing Whitespace From Every Text Node Consistent Spacing | Console.WriteLine, Node.Data, Aspose.Html | Creates or manipulates an HTML document. |
| [Trim Trailing Spaces Each Line Avoid Unnecessary Whitespace Final Output](./trim_trailing_spaces_each_line_avoid_unnecessary_whitespace_final_output.cs) | Trim Trailing Spaces Each Line Avoid Unnecessary Whitespace Final Output | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Update Atx Heading Text Preserving Original Hash Symbol Count](./update_atx_heading_text_preserving_original_hash_symbol_count.cs) | Update Atx Heading Text Preserving Original Hash Symbol Count | File.ReadAllLines, System.IO, File.WriteAllLines | Demonstrates a specific Aspose.HTML operation. |
| [Update Specific Yaml Frontmatter Fields Title Date Programmatically](./update_specific_yaml_frontmatter_fields_title_date_programmatically.cs) | Update Specific Yaml Frontmatter Fields Title Date Programmatically | System.Linq, System.Collections, File.ReadAllLines | Demonstrates a specific Aspose.HTML operation. |
| [Validate Document Contains At Least One Heading Meet Structural Requirements](./validate_document_contains_at_least_one_heading_meet_structural_requirements.cs) | Validate Document Contains At Least One Heading Meet Structural Requirements | HTMLDocument, Result.Success, Result.Error | Creates or manipulates an HTML document. |
| [Validate Document Does Not Contain Any Raw Html Tags To Ensure Strict Markdown Compliance](./validate_document_does_not_contain_any_raw_html_tags_to_ensure_strict_markdown_compliance.cs) | Validate Document Does Not Contain Any Raw Html Tags To Ensure Strict Markdown Compliance | Console.WriteLine, Aspose.HTML, Aspose.Html | Creates or manipulates an HTML document. |
| [Validate Every Footnote Definition Is Referenced Somewhere In Document To Avoid Orphaned Notes](./validate_every_footnote_definition_is_referenced_somewhere_in_document_to_avoid_orphaned_notes.cs) | Validate Every Footnote Definition Is Referenced Somewhere In Document To Avoid Orphaned Notes | System.Linq, Ids.Add, System.Collections | Creates or manipulates an HTML document. |
| [Validate Every Url In Document Uses Https Scheme For Secure Connections](./validate_every_url_in_document_uses_https_scheme_for_secure_connections.cs) | Validate Every Url In Document Uses Https Scheme For Secure Connections | Element.GetAttribute, Url.ToString, Console.WriteLine | Creates or manipulates an HTML document. |
| [Validate Heading Levels Follow Logical Hierarchy Without Skipping Intermediate Levels](./validate_heading_levels_follow_logical_hierarchy_without_skipping_intermediate_levels.cs) | Validate Heading Levels Follow Logical Hierarchy Without Skipping Intermediate Levels | TextContent.Trim, Console.WriteLine, TagName.ToLower | Creates or manipulates an HTML document. |
| [Validate No Heading Exceeds Six Hash Characters Ensuring Markdown Specification Compliance](./validate_no_heading_exceeds_six_hash_characters_ensuring_markdown_specification_compliance.cs) | Validate No Heading Exceeds Six Hash Characters Ensuring Markdown Specification Compliance | Encoding.UTF8, Converters.Converter, Console.WriteLine | Creates or manipulates an HTML document. |
| [Validate No Paragraph Exceeds Two Hundred Words Content Standards](./validate_no_paragraph_exceeds_two_hundred_words_content_standards.cs) | Validate No Paragraph Exceeds Two Hundred Words Content Standards | Console.WriteLine, Aspose.Html, StringSplitOptions.RemoveEmptyEntries | Creates or manipulates an HTML document. |
| [Validate Ordered List Numbers Sequential Correct Gaps After Item Removal](./validate_ordered_list_numbers_sequential_correct_gaps_after_item_removal.cs) | Validate Ordered List Numbers Sequential Correct Gaps After Item Removal | Lists.Length, Console.WriteLine, Items.Length | Creates or manipulates an HTML document. |
| [Validate Required Fields Title Author Exist Yaml Front Matter Block](./validate_required_fields_title_author_exist_yaml_front_matter_block.cs) | Validate Required Fields Title Author Exist Yaml Front Matter Block | Console.WriteLine, System.IO, File.ReadAllText | Demonstrates a specific Aspose.HTML operation. |
| [Verify All Code Blocks Fenced With Backticks And Correct Indentation](./verify_all_code_blocks_fenced_with_backticks_and_correct_indentation.cs) | Verify All Code Blocks Fenced With Backticks And Correct Indentation | Console.WriteLine, File.ReadAllLines, System.IO | Demonstrates a specific Aspose.HTML operation. |

## Category-Specific Tips

### Key API Surface
- **Conversion:** `Converter.ConvertMarkdown`, `Converter.ConvertHTML`
- **Document Model:** `HTMLDocument`, `Dom.Element`, `Dom.Comment`
- **Saving/Loading:** `DocSaveOptions`, `HtmlSaveOptions`, `MarkdownSaveOptions`
- **File I/O:** `File.ReadAllText`, `File.WriteAllText`, `Path.Combine`
- **Text Manipulation:** `Regex.Replace`, `TextContent.Trim`, `StringComparison.OrdinalIgnoreCase`

### Rules
1. **Always load content with explicit encoding** (`File.ReadAllText` + `Encoding.UTF8`) to avoid hidden BOM issues.  
2. **Validate before conversion** – check for raw HTML, heading hierarchy, and URL schemes.  
3. **Use `Console.WriteLine` for every major step**; it is the canonical logging mechanism in this repo.  
4. **When inserting nodes, prefer `ParentNode.InsertBefore` or `AppendChild`** to keep the DOM order deterministic.  
5. **After any structural change, call `doc.Save` with the appropriate `*SaveOptions`** to persist changes.  

## Warnings

- **Template Binding Mismatch:** If a placeholder in a Markdown template does not exist in the data model, `Converter.ConvertMarkdown` will leave raw tokens in the output.  
- **Missing Resources:** Relative image paths must resolve against the working directory; otherwise `Element.GetAttribute("src")` will point to a non‑existent file and break lazy‑loading logic.  
- **File Path Issues:** Hard‑coded paths (`"C:\\..."`) break cross‑platform builds; always use `Path.Combine` and `Environment.CurrentDirectory`.  
- **Rendering Memory Issues:** Converting very large Markdown files to HTML can exceed the default heap; consider streaming the input or increasing the process memory limit.  

## Guidelines for Adding New Examples

1. **Self‑contained code** – include all `using` statements, no external project references.  
2. **Console logging** – start each logical block with `Console.WriteLine("Step description")`.  
3. **Follow the common pattern** (load → convert → manipulate → save/render).  
4. **Naming convention:** `Action_Entity_OptionalDetail.cs` (e.g., `Add_Custom_Attribute_To_Images.cs`).  
5. **Update statistics:** increment `total_examples` and add the new file entry to the **Files** table with up to five key APIs.  
