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
| [Add_Author_Metadata_Comment_Beginning_Markdown_File_Documentation](./add_author_metadata_comment_beginning_markdown_file_documentation.cs) | Add_Author_Metadata_Comment_Beginning_Markdown_File_Documentation | DocSaveOptions, File.WriteAllText, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Add_Bullet_List_Generated_From_Array_Of_Strings_At_Designated_Location_In_Document](./add_bullet_list_generated_from_array_of_strings_at_designated_location_in_document.cs) | Add_Bullet_List_Generated_From_Array_Of_Strings_At_Designated_Location_In_Document | Console.WriteLine, System.IO, Environment.CurrentDirectory | Creates or manipulates an HTML document. |
| [Add_Custom_Attribute_Heading_Nodes_Seo_Without_Altering_Visible_Text](./add_custom_attribute_heading_nodes_seo_without_altering_visible_text.cs) | Add_Custom_Attribute_Heading_Nodes_Seo_Without_Altering_Visible_Text | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Add_Custom_Data_Attribute_To_List_Nodes_Indicating_Ordered_Or_Unordered](./add_custom_data_attribute_to_list_nodes_indicating_ordered_or_unordered.cs) | Add_Custom_Data_Attribute_To_List_Nodes_Indicating_Ordered_Or_Unordered | TagName.Equals, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [Add_Html_Comment_With_Line_Numbers_Before_Each_Paragraph_Node_For_Debugging](./add_html_comment_with_line_numbers_before_each_paragraph_node_for_debugging.cs) | Add_Html_Comment_With_Line_Numbers_Before_Each_Paragraph_Node_For_Debugging | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Add_Language_Identifiers_To_Fenced_Code_Blocks_Proper_Syntax_Highlighting_In_Rendered_Output](./add_language_identifiers_to_fenced_code_blocks_proper_syntax_highlighting_in_rendered_output.cs) | Add_Language_Identifiers_To_Fenced_Code_Blocks_Proper_Syntax_Highlighting_In_Rendered_Output | Console.WriteLine, HTMLDocument, Aspose.Html | Creates or manipulates an HTML document. |
| [Add_Missing_Alt_Text_To_Images_Lacking_Descriptions_With_Default_Placeholder](./add_missing_alt_text_to_images_lacking_descriptions_with_default_placeholder.cs) | Add_Missing_Alt_Text_To_Images_Lacking_Descriptions_With_Default_Placeholder | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Add_Timestamp_Comment_Indicating_Processing_Time_At_Top_Of_Markdown_File](./add_timestamp_comment_indicating_processing_time_at_top_of_markdown_file.cs) | Add_Timestamp_Comment_Indicating_Processing_Time_At_Top_Of_Markdown_File | File.WriteAllText, DateTime.Now, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Add_Title_Attribute_To_Image_Markdown_Nodes_For_Additional_Tooltip_Information](./add_title_attribute_to_image_markdown_nodes_for_additional_tooltip_information.cs) | Add_Title_Attribute_To_Image_Markdown_Nodes_For_Additional_Tooltip_Information | Console.WriteLine, Path.GetFileName, System.IO | Creates or manipulates an HTML document. |
| [Add_Yaml_Front_Matter_Block_At_Top_With_Custom_Metadata_Fields_For_Document](./add_yaml_front_matter_block_at_top_with_custom_metadata_fields_for_document.cs) | Add_Yaml_Front_Matter_Block_At_Top_With_Custom_Metadata_Fields_For_Document | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Append_Disclaimer_Paragraph_At_End_Of_File_For_Usage_Terms](./append_disclaimer_paragraph_at_end_of_file_for_usage_terms.cs) | Append_Disclaimer_Paragraph_At_End_Of_File_For_Usage_Terms | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Append_List_Of_Tags_To_Yaml_Front_Matter_Based_On_Extracted_Heading_Keywords](./append_list_of_tags_to_yaml_front_matter_based_on_extracted_heading_keywords.cs) | Append_List_Of_Tags_To_Yaml_Front_Matter_Based_On_Extracted_Heading_Keywords | Children.Add, TagName.ToLower, Path.GetFileNameWithoutExtension | Creates or manipulates an HTML document. |
| [Append_New_Level_Two_Heading_With_Custom_Text_At_End_Of_Markdown_Document](./append_new_level_two_heading_with_custom_text_at_end_of_markdown_document.cs) | Append_New_Level_Two_Heading_With_Custom_Text_At_End_Of_Markdown_Document | Encoding.UTF8, Converter.ConvertMarkdown, Body.AppendChild | Creates or manipulates an HTML document. |
| [Apply_Custom_Css_Class_All_Code_Block_Nodes_Modifying_Syntax_Properties](./apply_custom_css_class_all_code_block_nodes_modifying_syntax_properties.cs) | Apply_Custom_Css_Class_All_Code_Block_Nodes_Modifying_Syntax_Properties | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Apply_Regular_Expression_To_Mask_Email_Addresses_In_All_Text_Nodes_For_Privacy_Compliance](./apply_regular_expression_to_mask_email_addresses_in_all_text_nodes_for_privacy_compliance.cs) | Apply_Regular_Expression_To_Mask_Email_Addresses_In_All_Text_Nodes_For_Privacy_Compliance | Regex.Replace, Console.WriteLine, XPathResultType.Any | Creates or manipulates an HTML document. |
| [Batch_Heading_Updates_Across_Multiple_Markdown_Files_In_Folder_Using_Shared_Configuration](./batch_heading_updates_across_multiple_markdown_files_in_folder_using_shared_configuration.cs) | Batch_Heading_Updates_Across_Multiple_Markdown_Files_In_Folder_Using_Shared_Configuration | TextContent.Trim, MarkdownFeatures.AutomaticParagraph, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Batch_Processing_Update_Heading_Prefixes_Markdown_Files_Specified_Directory](./batch_processing_update_heading_prefixes_markdown_files_specified_directory.cs) | Batch_Processing_Update_Heading_Prefixes_Markdown_Files_Specified_Directory | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Collapse_Multiple_Consecutive_Blank_Lines_Into_Single_Blank_Line_Throughout_Document](./collapse_multiple_consecutive_blank_lines_into_single_blank_line_throughout_document.cs) | Collapse_Multiple_Consecutive_Blank_Lines_Into_Single_Blank_Line_Throughout_Document | Console.WriteLine, System.IO, File.ReadAllText | Creates or manipulates an HTML document. |
| [Compare_Two_Markdownsyntax_Tree_Objects_Structural_Equality_Detect_Unintended_Modifications_Version_Control](./compare_two_markdownsyntax_tree_objects_structural_equality_detect_unintended_modifications_version_control.cs) | Compare_Two_Markdownsyntax_Tree_Objects_Structural_Equality_Detect_Unintended_Modifications_Version_Control | Tree.ToString, Toolkit.Markdown, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Convert_All_Uppercase_Heading_Texts_To_Title_Case_Preserving_Hash_Level_Markers](./convert_all_uppercase_heading_texts_to_title_case_preserving_hash_level_markers.cs) | Convert_All_Uppercase_Heading_Texts_To_Title_Case_Preserving_Hash_Level_Markers | Text.ToUpperInvariant, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Convert_Blockquote_Sections_To_Italic_Paragraphs_Simplify_Formatting_Retaining_Emphasis](./convert_blockquote_sections_to_italic_paragraphs_simplify_formatting_retaining_emphasis.cs) | Convert_Blockquote_Sections_To_Italic_Paragraphs_Simplify_Formatting_Retaining_Emphasis | System.Linq, Console.WriteLine, ParentNode.ReplaceChild | Creates or manipulates an HTML document. |
| [Convert_Existing_Markdown_Tables_To_Plain_Text_Preserving_Column_Alignment](./convert_existing_markdown_tables_to_plain_text_preserving_column_alignment.cs) | Convert_Existing_Markdown_Tables_To_Plain_Text_Preserving_Column_Alignment | Converter.ConvertMarkdown, Console.WriteLine, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Convert_Heading_Texts_To_Title_Case_Keeping_Existing_Hash_Level_Markers](./convert_heading_texts_to_title_case_keeping_existing_hash_level_markers.cs) | Convert_Heading_Texts_To_Title_Case_Keeping_Existing_Hash_Level_Markers | System.Linq, Encoding.UTF8, CultureInfo.CurrentCulture | Creates or manipulates an HTML document. |
| [Convert_Inline_Markdown_Links_To_Reference_Style_Links_Generate_Reference_List_Bottom](./convert_inline_markdown_links_to_reference_style_links_generate_reference_list_bottom.cs) | Convert_Inline_Markdown_Links_To_Reference_Style_Links_Generate_Reference_List_Bottom | System.Linq, System.Collections, File.WriteAllText | Demonstrates a specific Aspose.HTML operation. |
| [Convert_Markdown_Emphasis_Markers_From_Single_To_Double_Asterisks_Stronger_Emphasis](./convert_markdown_emphasis_markers_from_single_to_double_asterisks_stronger_emphasis.cs) | Convert_Markdown_Emphasis_Markers_From_Single_To_Double_Asterisks_Stronger_Emphasis | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Convert_Markdown_Footnotes_Endnotes_Adjust_References_Throughout_Document](./convert_markdown_footnotes_endnotes_adjust_references_throughout_document.cs) | Convert_Markdown_Footnotes_Endnotes_Adjust_References_Throughout_Document | DocSaveOptions, File.WriteAllText, Div.AppendChild | Converts HTML content to another format using Aspose.HTML. |
| [Convert_Tabs_To_Spaces_Code_Blocks_Maintain_Consistent_Formatting_Editors](./convert_tabs_to_spaces_code_blocks_maintain_consistent_formatting_editors.cs) | Convert_Tabs_To_Spaces_Code_Blocks_Maintain_Consistent_Formatting_Editors | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Convert_Task_List_Items_Regular_Bullet_Points_Simplify_Document_Formatting](./convert_task_list_items_regular_bullet_points_simplify_document_formatting.cs) | Convert_Task_List_Items_Regular_Bullet_Points_Simplify_Document_Formatting | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Convert_Unordered_List_Items_Into_Ordered_List_Preserving_Hierarchy](./convert_unordered_list_items_into_ordered_list_preserving_hierarchy.cs) | Convert_Unordered_List_Items_Into_Ordered_List_Preserving_Hierarchy | Console.WriteLine, Elements.Length, ParentNode.ReplaceChild | Creates or manipulates an HTML document. |
| [Count_Number_Headings_Each_Level_Output_Statistics_Comment](./count_number_headings_each_level_output_statistics_comment.cs) | Count_Number_Headings_Each_Level_Output_Statistics_Comment | Console.WriteLine, TagName.ToLower, Builder.ToString | Creates or manipulates an HTML document. |
| [Create_Custom_Transformation_Wrap_Paragraph_Text_In_Span_With_Specific_Css_Class](./create_custom_transformation_wrap_paragraph_text_in_span_with_specific_css_class.cs) | Create_Custom_Transformation_Wrap_Paragraph_Text_In_Span_With_Specific_Css_Class | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Create_Markdown_Table_From_Two_Dimensional_Data_Array_And_Insert_After_Heading](./create_markdown_table_from_two_dimensional_data_array_and_insert_after_heading.cs) | Create_Markdown_Table_From_Two_Dimensional_Data_Array_And_Insert_After_Heading | Cells.Length, Rows.Length, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Decrypt_Previously_Encrypted_Markdown_Nodes_Restore_Original_Content_Further_Editing](./decrypt_previously_encrypted_markdown_nodes_restore_original_content_further_editing.cs) | Decrypt_Previously_Encrypted_Markdown_Nodes_Restore_Original_Content_Further_Editing | Encoding.UTF8, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Delete_Specific_List_Item_Identified_By_Text_Content_From_Markdown_List](./delete_specific_list_item_identified_by_text_content_from_markdown_list.cs) | Delete_Specific_List_Item_Identified_By_Text_Content_From_Markdown_List | TextContent.Trim, Converters.Converter, Console.WriteLine | Creates or manipulates an HTML document. |
| [Depth_First_Traversal_Collect_Text_Nodes_Into_List_For_Bulk_Processing](./depth_first_traversal_collect_text_nodes_into_list_for_bulk_processing.cs) | Depth_First_Traversal_Collect_Text_Nodes_Into_List_For_Bulk_Processing | System.Collections, Node.TEXT_NODE, Console.WriteLine | Creates or manipulates an HTML document. |
| [Detect_And_Fix_Inconsistent_Indentation_In_Nested_Lists_To_Ensure_Proper_Hierarchical_Rendering](./detect_and_fix_inconsistent_indentation_in_nested_lists_to_ensure_proper_hierarchical_rendering.cs) | Detect_And_Fix_Inconsistent_Indentation_In_Nested_Lists_To_Ensure_Proper_Hierarchical_Rendering | Console.WriteLine, TextContent.Trim, Aspose.Html | Creates or manipulates an HTML document. |
| [Detect_Broken_Image_Links_By_Checking_Each_Image_Url_Http_Response_Status](./detect_broken_image_links_by_checking_each_image_url_http_response_status.cs) | Detect_Broken_Image_Links_By_Checking_Each_Image_Url_Http_Response_Status | System.Collections, Element.GetAttribute, Url.ToString | Creates or manipulates an HTML document. |
| [Detect_Duplicate_Heading_Texts_Rename_With_Unique_Identifiers_Avoid_Ambiguity](./detect_duplicate_heading_texts_rename_with_unique_identifiers_avoid_ambiguity.cs) | Detect_Duplicate_Heading_Texts_Rename_With_Unique_Identifiers_Avoid_Ambiguity | TextContent.Trim, StringComparer.OrdinalIgnoreCase, System.Collections | Creates or manipulates an HTML document. |
| [Detect_Github_Flavored_Markdown_Features_In_Document_Log_Identified_Elements](./detect_github_flavored_markdown_features_in_document_log_identified_elements.cs) | Detect_Github_Flavored_Markdown_Features_In_Document_Log_Identified_Elements | Converter.ConvertMarkdown, Console.WriteLine, ListItems.Length | Creates or manipulates an HTML document. |
| [Detect_Mismatched_Markdown_Delimiters_Automatically_Correct_Maintain_Valid_Syntax](./detect_mismatched_markdown_delimiters_automatically_correct_maintain_valid_syntax.cs) | Detect_Mismatched_Markdown_Delimiters_Automatically_Correct_Maintain_Valid_Syntax | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Detect_Remove_Stray_Backticks_Not_Form_Valid_Code_Spans_Clean_Markup](./detect_remove_stray_backticks_not_form_valid_code_spans_clean_markup.cs) | Detect_Remove_Stray_Backticks_Not_Form_Valid_Code_Spans_Clean_Markup | Console.WriteLine, Aspose.Html, InnerHTML.Replace | Creates or manipulates an HTML document. |
| [Detect_Unescaped_Special_Characters_In_Urls_And_Escape_To_Prevent_Parsing_Errors](./detect_unescaped_special_characters_in_urls_and_escape_to_prevent_parsing_errors.cs) | Detect_Unescaped_Special_Characters_In_Urls_And_Escape_To_Prevent_Parsing_Errors | Element.GetAttribute, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Encrypt_Specific_Markdown_Nodes_Using_Custom_Wrapper_To_Protect_Sensitive_Content_Before_Saving](./encrypt_specific_markdown_nodes_using_custom_wrapper_to_protect_sensitive_content_before_saving.cs) | Encrypt_Specific_Markdown_Nodes_Using_Custom_Wrapper_To_Protect_Sensitive_Content_Before_Saving | File.WriteAllText, Converters.Converter, Doc.CreateElement | Creates or manipulates an HTML document. |
| [Ensure_Each_List_Preceded_By_Blank_Line_Markdown_Spacing_Conventions](./ensure_each_list_preceded_by_blank_line_markdown_spacing_conventions.cs) | Ensure_Each_List_Preceded_By_Blank_Line_Markdown_Spacing_Conventions | StreamWriter, File.ReadAllLines, Console.WriteLine | Converts HTML content to another format using Aspose.HTML. |
| [Ensure_Every_Heading_Node_Ends_Newline_Character_Maintain_Valid_Markdown_Syntax](./ensure_every_heading_node_ends_newline_character_maintain_valid_markdown_syntax.cs) | Ensure_Every_Heading_Node_Ends_Newline_Character_Maintain_Valid_Markdown_Syntax | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Ensure_Markdown_File_Ends_Single_Newline_Parser_Requirements](./ensure_markdown_file_ends_single_newline_parser_requirements.cs) | Ensure_Markdown_File_Ends_Single_Newline_Parser_Requirements | File.WriteAllText, Console.WriteLine, System.IO | Converts HTML content to another format using Aspose.HTML. |
| [Escape_Special_Markdown_Characters_In_All_Text_Nodes_To_Prevent_Unintended_Formatting](./escape_special_markdown_characters_in_all_text_nodes_to_prevent_unintended_formatting.cs) | Escape_Special_Markdown_Characters_In_All_Text_Nodes_To_Prevent_Unintended_Formatting | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Export_Entire_Markdownsyntax_Tree_To_Xml_For_Archival_And_Version_Control](./export_entire_markdownsyntax_tree_to_xml_for_archival_and_version_control.cs) | Export_Entire_Markdownsyntax_Tree_To_Xml_For_Archival_And_Version_Control | XDocument, Converter.ConvertMarkdown, Console.WriteLine | Creates or manipulates an HTML document. |
| [Extract_All_Hyperlink_Urls_From_Markdown_Document_And_Store_In_List](./extract_all_hyperlink_urls_from_markdown_document_and_store_in_list.cs) | Extract_All_Hyperlink_Urls_From_Markdown_Document_And_Store_In_List | System.Collections, Element.GetAttribute, Converter.ConvertMarkdown | Creates or manipulates an HTML document. |
| [Extract_List_Items_From_Document_Write_Separate_Markdown_File](./extract_list_items_from_document_write_separate_markdown_file.cs) | Extract_List_Items_From_Document_Write_Separate_Markdown_File | TextContent.Trim, System.Collections, Console.WriteLine | Creates or manipulates an HTML document. |
| [Extract_Task_List_Items_Into_Json_Array_For_External_Processing_Reporting](./extract_task_list_items_into_json_array_for_external_processing_reporting.cs) | Extract_Task_List_Items_Into_Json_Array_For_External_Processing_Reporting | System.Collections, File.ReadAllLines, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Generate_Consolidated_Reference_List_For_All_Urls_Used_In_Document_And_Insert](./generate_consolidated_reference_list_for_all_urls_used_in_document_and_insert.cs) | Generate_Consolidated_Reference_List_For_All_Urls_Used_In_Document_And_Insert | List.Add, System.Collections, Element.GetAttribute | Creates or manipulates an HTML document. |
| [Generate_Html_Preview_Of_Markdown_Content_Using_Built_In_Renderer_For_Visual_Verification](./generate_html_preview_of_markdown_content_using_built_in_renderer_for_visual_verification.cs) | Generate_Html_Preview_Of_Markdown_Content_Using_Built_In_Renderer_For_Visual_Verification | Encoding.UTF8, Element.TextContent, Converter.ConvertMarkdown | Creates or manipulates an HTML document. |
| [Generate_Index_Markdown_File_Linking_Each_Split_Chapter_File_Quick_Access](./generate_index_markdown_file_linking_each_split_chapter_file_quick_access.cs) | Generate_Index_Markdown_File_Linking_Each_Split_Chapter_File_Quick_Access | System.Linq, Files.Select, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Generate_Json_Representation_Heading_Hierarchy_External_Analysis_Integration](./generate_json_representation_heading_hierarchy_external_analysis_integration.cs) | Generate_Json_Representation_Heading_Hierarchy_External_Analysis_Integration | TextContent.Trim, System.Collections, Children.Add | Creates or manipulates an HTML document. |
| [Generate_Report_Summarizing_Modifications_Made_To_Markdown_File_Including_Counts_Of_Each_Change_Type](./generate_report_summarizing_modifications_made_to_markdown_file_including_counts_of_each_change_type.cs) | Generate_Report_Summarizing_Modifications_Made_To_Markdown_File_Including_Counts_Of_Each_Change_Type | StreamWriter, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Generate_Summary_Paragraph_Document_Length_Main_Topics](./generate_summary_paragraph_document_length_main_topics.cs) | Generate_Summary_Paragraph_Document_Length_Main_Topics | Body.TextContent, Console.WriteLine, Text.Length | Creates or manipulates an HTML document. |
| [Generate_Table_Of_Contents_Based_On_Heading_Hierarchy_And_Insert_At_Top](./generate_table_of_contents_based_on_heading_hierarchy_and_insert_at_top.cs) | Generate_Table_Of_Contents_Based_On_Heading_Hierarchy_And_Insert_At_Top | TextContent.Trim, Root.AppendChild, Guid.NewGuid | Creates or manipulates an HTML document. |
| [Generate_Word_Count_Statistic_And_Embed_As_Comment_At_Top_Of_Document](./generate_word_count_statistic_and_embed_as_comment_at_top_of_document.cs) | Generate_Word_Count_Statistic_And_Embed_As_Comment_At_Top_Of_Document | Body.TextContent, Dom.Comment, Body.AppendChild | Creates or manipulates an HTML document. |
| [Highlight_Code_Block_Syntax_By_Assigning_Custom_Css_Class_Through_Node_Property_Modification](./highlight_code_block_syntax_by_assigning_custom_css_class_through_node_property_modification.cs) | Highlight_Code_Block_Syntax_By_Assigning_Custom_Css_Class_Through_Node_Property_Modification | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Implement_Lazy_Loading_For_Large_Images_By_Inserting_Placeholder_Syntax_Before_Actual_Image_References](./implement_lazy_loading_for_large_images_by_inserting_placeholder_syntax_before_actual_image_references.cs) | Implement_Lazy_Loading_For_Large_Images_By_Inserting_Placeholder_Syntax_Before_Actual_Image_References | File.WriteAllText, Element.GetAttribute, Console.WriteLine | Creates or manipulates an HTML document. |
| [Insert_Checklist_Items_Using_Task_List_Syntax_Set_Initial_Checked_State](./insert_checklist_items_using_task_list_syntax_set_initial_checked_state.cs) | Insert_Checklist_Items_Using_Task_List_Syntax_Set_Initial_Checked_State | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Insert_Copyright_Notice_Immediately_After_First_Heading_Assert_Ownership](./insert_copyright_notice_immediately_after_first_heading_assert_ownership.cs) | Insert_Copyright_Notice_Immediately_After_First_Heading_Assert_Ownership | Console.WriteLine, Aspose.Html, Para.AppendChild | Creates or manipulates an HTML document. |
| [Insert_Footnote_Definitions_At_End_Of_Document_For_Each_Referenced_Footnote_Marker](./insert_footnote_definitions_at_end_of_document_for_each_referenced_footnote_marker.cs) | Insert_Footnote_Definitions_At_End_Of_Document_For_Each_Referenced_Footnote_Marker | Ids.Add, Ids.Count, System.Collections | Creates or manipulates an HTML document. |
| [Insert_Generated_Table_Of_Contents_After_Front_Matter_Block_To_Improve_Navigation](./insert_generated_table_of_contents_after_front_matter_block_to_improve_navigation.cs) | Insert_Generated_Table_Of_Contents_After_Front_Matter_Block_To_Improve_Navigation | Body.AppendChild, Guid.NewGuid, Console.WriteLine | Creates or manipulates an HTML document. |
| [Insert_Horizontal_Rule_After_Top_Level_Heading_To_Visually_Separate_Sections](./insert_horizontal_rule_after_top_level_heading_to_visually_separate_sections.cs) | Insert_Horizontal_Rule_After_Top_Level_Heading_To_Visually_Separate_Sections | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Insert_Horizontal_Rule_Before_Each_Code_Block_Visually_Separate_Code_Surrounding_Text](./insert_horizontal_rule_before_each_code_block_visually_separate_code_surrounding_text.cs) | Insert_Horizontal_Rule_Before_Each_Code_Block_Visually_Separate_Code_Surrounding_Text | Console.WriteLine, Aspose.Html, ParentNode.InsertBefore | Creates or manipulates an HTML document. |
| [Insert_Line_Break_Within_Long_Heading_Text_Improve_Readability_Narrow_Screens](./insert_line_break_within_long_heading_text_improve_readability_narrow_screens.cs) | Insert_Line_Break_Within_Long_Heading_Text_Improve_Readability_Narrow_Screens | Console.WriteLine, Aspose.Html, Dom.Text | Creates or manipulates an HTML document. |
| [Insert_Markdown_Comment_Before_Each_Heading_Indicating_Hierarchical_Level_For_Easier_Navigation](./insert_markdown_comment_before_each_heading_indicating_hierarchical_level_for_easier_navigation.cs) | Insert_Markdown_Comment_Before_Each_Heading_Indicating_Hierarchical_Level_For_Easier_Navigation | Console.WriteLine, TagName.ToLower, ParentNode.InsertBefore | Creates or manipulates an HTML document. |
| [Insert_Subheading_Under_Specified_Parent_Heading_Using_Markdownsyntaxfactory_Create_Nodes](./insert_subheading_under_specified_parent_heading_using_markdownsyntaxfactory_create_nodes.cs) | Insert_Subheading_Under_Specified_Parent_Heading_Using_Markdownsyntaxfactory_Create_Nodes | Heading.AppendChild, Toolkit.Markdown, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Insert_Table_Of_Figures_Generated_From_Image_Captions_After_Table_Of_Contents](./insert_table_of_figures_generated_from_image_captions_after_table_of_contents.cs) | Insert_Table_Of_Figures_Generated_From_Image_Captions_After_Table_Of_Contents | HTMLSaveOptions, Div.AppendChild, Console.WriteLine | Creates or manipulates an HTML document. |
| [Load_All_Md_Files_From_Directory_And_Parse_Each_Into_Separate_Syntax_Trees](./load_all_md_files_from_directory_and_parse_each_into_separate_syntax_trees.cs) | Load_All_Md_Files_From_Directory_And_Parse_Each_Into_Separate_Syntax_Trees | Toolkit.Markdown, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Load_Previously_Saved_Xml_Representation_Of_Syntax_Tree_And_Reconstruct_Markdown_Document](./load_previously_saved_xml_representation_of_syntax_tree_and_reconstruct_markdown_document.cs) | Load_Previously_Saved_Xml_Representation_Of_Syntax_Tree_And_Reconstruct_Markdown_Document | Console.WriteLine, Converter.ConvertHTML, MarkdownSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Merge_Consecutive_List_Items_Single_Paragraph_Simplify_Presentation](./merge_consecutive_list_items_single_paragraph_simplify_presentation.cs) | Merge_Consecutive_List_Items_Single_Paragraph_Simplify_Presentation | TextContent.Trim, Console.WriteLine, StringComparison.OrdinalIgnoreCase | Creates or manipulates an HTML document. |
| [Merge_Consecutive_Paragraph_Nodes_Into_Single_Paragraph_Reduce_Unnecessary_Breaks](./merge_consecutive_paragraph_nodes_into_single_paragraph_reduce_unnecessary_breaks.cs) | Merge_Consecutive_Paragraph_Nodes_Into_Single_Paragraph_Reduce_Unnecessary_Breaks | Console.WriteLine, Aspose.Html, TagName.ToLower | Creates or manipulates an HTML document. |
| [Merge_Two_Markdown_Documents_Preserving_Heading_Hierarchy_Inserting_Separator_Comment](./merge_two_markdown_documents_preserving_heading_hierarchy_inserting_separator_comment.cs) | Merge_Two_Markdown_Documents_Preserving_Heading_Hierarchy_Inserting_Separator_Comment | Body.ChildNodes, MarkdownFeatures.AutomaticParagraph, Converter.ConvertMarkdown | Converts HTML content to another format using Aspose.HTML. |
| [Normalize_All_Line_Endings_Document_To_Lf_Characters_Consistent_Cross_Platform_Behavior](./normalize_all_line_endings_document_to_lf_characters_consistent_cross_platform_behavior.cs) | Normalize_All_Line_Endings_Document_To_Lf_Characters_Consistent_Cross_Platform_Behavior | File.WriteAllText, System.IO, File.ReadAllText | Demonstrates a specific Aspose.HTML operation. |
| [Optimize_Image_Markdown_Adding_Width_Attributes_Improve_Rendering_Performance_Web_Pages](./optimize_image_markdown_adding_width_attributes_improve_rendering_performance_web_pages.cs) | Optimize_Image_Markdown_Adding_Width_Attributes_Improve_Rendering_Performance_Web_Pages | Console.WriteLine, Aspose.Html, Element.SetAttribute | Creates or manipulates an HTML document. |
| [Parse_Single_Markdown_File_Into_Markdown_Syntax_Tree_Using_Markdown_Parser](./parse_single_markdown_file_into_markdown_syntax_tree_using_markdown_parser.cs) | Parse_Single_Markdown_File_Into_Markdown_Syntax_Tree_Using_Markdown_Parser | Toolkit.Markdown, Console.WriteLine, Syntax.Parser | Demonstrates a specific Aspose.HTML operation. |
| [Prefix_Each_Heading_With_Sequential_Numeric_Index_To_Create_Ordered_Document_Outline](./prefix_each_heading_with_sequential_numeric_index_to_create_ordered_document_outline.cs) | Prefix_Each_Heading_With_Sequential_Numeric_Index_To_Create_Ordered_Document_Outline | Console.WriteLine, TextContent.Trim, Aspose.Html | Creates or manipulates an HTML document. |
| [Prepend_Note_All_Blockquote_Contents_Highlight_Important_Information](./prepend_note_all_blockquote_contents_highlight_important_information.cs) | Prepend_Note_All_Blockquote_Contents_Highlight_Important_Information | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Remove_All_Empty_List_Items_Clean_Up_List_Structures_Avoid_Rendering_Issues](./remove_all_empty_list_items_clean_up_list_structures_avoid_rendering_issues.cs) | Remove_All_Empty_List_Items_Clean_Up_List_Structures_Avoid_Rendering_Issues | System.Linq, Items.ToList, Console.WriteLine | Creates or manipulates an HTML document. |
| [Remove_Blockquote_Formatting_Preserving_Text_Flatten_Document_Structure](./remove_blockquote_formatting_preserving_text_flatten_document_structure.cs) | Remove_Blockquote_Formatting_Preserving_Text_Flatten_Document_Structure | Console.WriteLine, ParentNode.RemoveChild, ParentNode.InsertBefore | Creates or manipulates an HTML document. |
| [Remove_Duplicate_Paragraph_Nodes_Eliminate_Redundant_Content_Streamline_Document](./remove_duplicate_paragraph_nodes_eliminate_redundant_content_streamline_document.cs) | Remove_Duplicate_Paragraph_Nodes_Eliminate_Redundant_Content_Streamline_Document | Console.WriteLine, System.Collections, Aspose.Html | Creates or manipulates an HTML document. |
| [Remove_Embedded_Html_Tags_Markdown_Content_Ensure_Pure_Markdown_Output](./remove_embedded_html_tags_markdown_content_ensure_pure_markdown_output.cs) | Remove_Embedded_Html_Tags_Markdown_Content_Ensure_Pure_Markdown_Output | File.WriteAllText, DocumentElement.TextContent, Console.WriteLine | Creates or manipulates an HTML document. |
| [Remove_Empty_Paragraph_Nodes_From_Syntax_Tree_Clean_Up_Document_Structure](./remove_empty_paragraph_nodes_from_syntax_tree_clean_up_document_structure.cs) | Remove_Empty_Paragraph_Nodes_From_Syntax_Tree_Clean_Up_Document_Structure | Console.WriteLine, Aspose.Html, ParentNode.RemoveChild | Creates or manipulates an HTML document. |
| [Remove_Existing_Yaml_Front_Matter_Block_Revert_Document_To_Plain_Markdown](./remove_existing_yaml_front_matter_block_revert_document_to_plain_markdown.cs) | Remove_Existing_Yaml_Front_Matter_Block_Revert_Document_To_Plain_Markdown | System.Collections, File.ReadAllLines, Console.WriteLine | Demonstrates a specific Aspose.HTML operation. |
| [Remove_Markdown_Comments_From_Document_Produce_Clean_Version_Without_Annotations](./remove_markdown_comments_from_document_produce_clean_version_without_annotations.cs) | Remove_Markdown_Comments_From_Document_Produce_Clean_Version_Without_Annotations | File.WriteAllText, Console.WriteLine, System.IO | Demonstrates a specific Aspose.HTML operation. |
| [Renumber_Ordered_List_After_Deleting_Items_Maintain_Proper_Numeric_Ordering](./renumber_ordered_list_after_deleting_items_maintain_proper_numeric_ordering.cs) | Renumber_Ordered_List_After_Deleting_Items_Maintain_Proper_Numeric_Ordering | System.Linq, Console.WriteLine, Collection.ToList | Creates or manipulates an HTML document. |
| [Reorder_List_Items_Alphabetically_Based_On_Text_Values_And_Update_Syntax_Tree](./reorder_list_items_alphabetically_based_on_text_values_and_update_syntax_tree.cs) | Reorder_List_Items_Alphabetically_Based_On_Text_Values_And_Update_Syntax_Tree | TextContent.Trim, System.Collections, Generic.List | Creates or manipulates an HTML document. |
| [Replace_All_Em_Dashes_Double_Hyphens_Ensure_Compatibility_Plain_Text_Viewers](./replace_all_em_dashes_double_hyphens_ensure_compatibility_plain_text_viewers.cs) | Replace_All_Em_Dashes_Double_Hyphens_Ensure_Compatibility_Plain_Text_Viewers | File.WriteAllText, System.IO, File.ReadAllText | Demonstrates a specific Aspose.HTML operation. |
| [Replace_All_Inline_Html_Tags_With_Equivalent_Markdown_Syntax_To_Maintain_Pure_Markdown_Formatting](./replace_all_inline_html_tags_with_equivalent_markdown_syntax_to_maintain_pure_markdown_formatting.cs) | Replace_All_Inline_Html_Tags_With_Equivalent_Markdown_Syntax_To_Maintain_Pure_Markdown_Formatting | Converter.ConvertHTML, Aspose.Html, MarkdownSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Replace_Content_First_Paragraph_Node_New_Text_Retaining_Formatting](./replace_content_first_paragraph_node_new_text_retaining_formatting.cs) | Replace_Content_First_Paragraph_Node_New_Text_Retaining_Formatting | Console.WriteLine, Aspose.Html | Creates or manipulates an HTML document. |
| [Replace_Double_Spaces_With_Single_Spaces_In_All_Text_Nodes_To_Improve_Readability](./replace_double_spaces_with_single_spaces_in_all_text_nodes_to_improve_readability.cs) | Replace_Double_Spaces_With_Single_Spaces_In_All_Text_Nodes_To_Improve_Readability | Console.WriteLine, Node.Data, Regex.Replace | Creates or manipulates an HTML document. |
| [Replace_Existing_Image_Urls_With_Cdn_Hosted_Equivalents_To_Improve_Loading_Performance_For_Users](./replace_existing_image_urls_with_cdn_hosted_equivalents_to_improve_loading_performance_for_users.cs) | Replace_Existing_Image_Urls_With_Cdn_Hosted_Equivalents_To_Improve_Loading_Performance_For_Users | Element.GetAttribute, Url.ToString, Uri | Creates or manipulates an HTML document. |
| [Replace_Inline_Code_Spans_Emphasized_Text_Alternative_Formatting_Options](./replace_inline_code_spans_emphasized_text_alternative_formatting_options.cs) | Replace_Inline_Code_Spans_Emphasized_Text_Alternative_Formatting_Options | Console.WriteLine, Aspose.Html, Elements.Length | Creates or manipulates an HTML document. |
| [Replace_Markdown_Image_Syntax_With_Html_Img_Tags_Preserving_Alt_Text_And_Source_Attributes](./replace_markdown_image_syntax_with_html_img_tags_preserving_alt_text_and_source_attributes.cs) | Replace_Markdown_Image_Syntax_With_Html_Img_Tags_Preserving_Alt_Text_And_Source_Attributes | File.WriteAllText, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Replace_Markdown_Tables_Csv_Code_Fences_Provide_Raw_Data_Format](./replace_markdown_tables_csv_code_fences_provide_raw_data_format.cs) | Replace_Markdown_Tables_Csv_Code_Fences_Provide_Raw_Data_Format | TextContent.Trim, Console.WriteLine, Builder.ToString | Creates or manipulates an HTML document. |
| [Save_Generated_Html_Preview_To_Temporary_File_For_Automated_Testing_Workflows](./save_generated_html_preview_to_temporary_file_for_automated_testing_workflows.cs) | Save_Generated_Html_Preview_To_Temporary_File_For_Automated_Testing_Workflows | Console.WriteLine, System.IO, Path.GetTempPath | Creates or manipulates an HTML document. |
| [Save_Updated_Markdown_Document_Preserving_Original_File_Encoding_And_Line_Ending_Style](./save_updated_markdown_document_preserving_original_file_encoding_and_line_ending_style.cs) | Save_Updated_Markdown_Document_Preserving_Original_File_Encoding_And_Line_Ending_Style | Converter.ConvertHTML, Aspose.Html, MarkdownSaveOptions.Git | Converts HTML content to another format using Aspose.HTML. |
| [Serialize_Modified_Markdown_Syntax_Tree_To_String_With_Custom_Indentation_For_Readability](./serialize_modified_markdown_syntax_tree_to_string_with_custom_indentation_for_readability.cs) | Serialize_Modified_Markdown_Syntax_Tree_To_String_With_Custom_Indentation_For_Readability | Children.Add, System.Collections, Generic.List | Demonstrates a specific Aspose.HTML operation. |
| [Split_Document_Into_Chapters_Based_On_Level_2_Headings_And_Save_Each_Separate_File](./split_document_into_chapters_based_on_level_2_headings_and_save_each_separate_file.cs) | Split_Document_Into_Chapters_Based_On_Level_2_Headings_And_Save_Each_Separate_File | TagName.Equals, Doc.Body, Console.WriteLine | Creates or manipulates an HTML document. |
| [Split_Long_Paragraph_Into_Two_Nodes_Sentence_Boundary](./split_long_paragraph_into_two_nodes_sentence_boundary.cs) | Split_Long_Paragraph_Into_Two_Nodes_Sentence_Boundary | Text.IndexOf, Console.WriteLine, Text.Length | Creates or manipulates an HTML document. |
| [Split_Markdown_Document_Into_Separate_Files_Per_Top_Level_Heading_Modular_Sections](./split_markdown_document_into_separate_files_per_top_level_heading_modular_sections.cs) | Split_Markdown_Document_Into_Separate_Files_Per_Top_Level_Heading_Modular_Sections | TagName.Equals, StringComparison.OrdinalIgnoreCase, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Toggle_Checked_State_Of_Task_List_Items_Programmatically_To_Reflect_Completion_Status](./toggle_checked_state_of_task_list_items_programmatically_to_reflect_completion_status.cs) | Toggle_Checked_State_Of_Task_List_Items_Programmatically_To_Reflect_Completion_Status | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Trim_Leading_And_Trailing_Whitespace_From_Every_Text_Node_Consistent_Spacing](./trim_leading_and_trailing_whitespace_from_every_text_node_consistent_spacing.cs) | Trim_Leading_And_Trailing_Whitespace_From_Every_Text_Node_Consistent_Spacing | Console.WriteLine, Node.Data, Aspose.Html | Creates or manipulates an HTML document. |
| [Trim_Trailing_Spaces_Each_Line_Avoid_Unnecessary_Whitespace_Final_Output](./trim_trailing_spaces_each_line_avoid_unnecessary_whitespace_final_output.cs) | Trim_Trailing_Spaces_Each_Line_Avoid_Unnecessary_Whitespace_Final_Output | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Update_Atx_Heading_Text_Preserving_Original_Hash_Symbol_Count](./update_atx_heading_text_preserving_original_hash_symbol_count.cs) | Update_Atx_Heading_Text_Preserving_Original_Hash_Symbol_Count | File.ReadAllLines, System.IO, File.WriteAllLines | Demonstrates a specific Aspose.HTML operation. |
| [Update_Specific_Yaml_Frontmatter_Fields_Title_Date_Programmatically](./update_specific_yaml_frontmatter_fields_title_date_programmatically.cs) | Update_Specific_Yaml_Frontmatter_Fields_Title_Date_Programmatically | System.Linq, System.Collections, File.ReadAllLines | Demonstrates a specific Aspose.HTML operation. |
| [Validate_Document_Contains_At_Least_One_Heading_Meet_Structural_Requirements](./validate_document_contains_at_least_one_heading_meet_structural_requirements.cs) | Validate_Document_Contains_At_Least_One_Heading_Meet_Structural_Requirements | HTMLDocument, Result.Success, Result.Error | Creates or manipulates an HTML document. |
| [Validate_Document_Does_Not_Contain_Any_Raw_Html_Tags_To_Ensure_Strict_Markdown_Compliance](./validate_document_does_not_contain_any_raw_html_tags_to_ensure_strict_markdown_compliance.cs) | Validate_Document_Does_Not_Contain_Any_Raw_Html_Tags_To_Ensure_Strict_Markdown_Compliance | Console.WriteLine, Aspose.HTML, Aspose.Html | Creates or manipulates an HTML document. |
| [Validate_Every_Footnote_Definition_Is_Referenced_Somewhere_In_Document_To_Avoid_Orphaned_Notes](./validate_every_footnote_definition_is_referenced_somewhere_in_document_to_avoid_orphaned_notes.cs) | Validate_Every_Footnote_Definition_Is_Referenced_Somewhere_In_Document_To_Avoid_Orphaned_Notes | System.Linq, Ids.Add, System.Collections | Creates or manipulates an HTML document. |
| [Validate_Every_Url_In_Document_Uses_Https_Scheme_For_Secure_Connections](./validate_every_url_in_document_uses_https_scheme_for_secure_connections.cs) | Validate_Every_Url_In_Document_Uses_Https_Scheme_For_Secure_Connections | Element.GetAttribute, Url.ToString, Console.WriteLine | Creates or manipulates an HTML document. |
| [Validate_Heading_Levels_Follow_Logical_Hierarchy_Without_Skipping_Intermediate_Levels](./validate_heading_levels_follow_logical_hierarchy_without_skipping_intermediate_levels.cs) | Validate_Heading_Levels_Follow_Logical_Hierarchy_Without_Skipping_Intermediate_Levels | TextContent.Trim, Console.WriteLine, TagName.ToLower | Creates or manipulates an HTML document. |
| [Validate_No_Heading_Exceeds_Six_Hash_Characters_Ensuring_Markdown_Specification_Compliance](./validate_no_heading_exceeds_six_hash_characters_ensuring_markdown_specification_compliance.cs) | Validate_No_Heading_Exceeds_Six_Hash_Characters_Ensuring_Markdown_Specification_Compliance | Encoding.UTF8, Converters.Converter, Console.WriteLine | Creates or manipulates an HTML document. |
| [Validate_No_Paragraph_Exceeds_Two_Hundred_Words_Content_Standards](./validate_no_paragraph_exceeds_two_hundred_words_content_standards.cs) | Validate_No_Paragraph_Exceeds_Two_Hundred_Words_Content_Standards | Console.WriteLine, Aspose.Html, StringSplitOptions.RemoveEmptyEntries | Creates or manipulates an HTML document. |
| [Validate_Ordered_List_Numbers_Sequential_Correct_Gaps_After_Item_Removal](./validate_ordered_list_numbers_sequential_correct_gaps_after_item_removal.cs) | Validate_Ordered_List_Numbers_Sequential_Correct_Gaps_After_Item_Removal | Lists.Length, Console.WriteLine, Items.Length | Creates or manipulates an HTML document. |
| [Validate_Required_Fields_Title_Author_Exist_Yaml_Front_Matter_Block](./validate_required_fields_title_author_exist_yaml_front_matter_block.cs) | Validate_Required_Fields_Title_Author_Exist_Yaml_Front_Matter_Block | Console.WriteLine, System.IO, File.ReadAllText | Demonstrates a specific Aspose.HTML operation. |
| [Verify_All_Code_Blocks_Fenced_With_Backticks_And_Correct_Indentation](./verify_all_code_blocks_fenced_with_backticks_and_correct_indentation.cs) | Verify_All_Code_Blocks_Fenced_With_Backticks_And_Correct_Indentation | Console.WriteLine, File.ReadAllLines, System.IO | Demonstrates a specific Aspose.HTML operation. |

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
