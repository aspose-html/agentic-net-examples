---
name: markdown-processing
description: C# examples for Markdown Processing using Aspose.HTML for .NET
language: csharp
framework: net10.0
parent: ../agents.md
---

# AGENTS - Markdown Processing

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET,
working within the **Markdown Processing** category.
This folder contains standalone C# examples for Markdown Processing operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;`
- `using System.IO;`
- `using Aspose.Html;`
- `using Aspose.Html.Dom;`
- `using Aspose.Html.Dom.Svg;`
- `using Aspose.Html.Dom.XPath;`
- `using Aspose.Html.Accessibility;`
- `using Aspose.Html.Collections;`
- `using Aspose.Html.Converters;`
- `using Aspose.Html.Loading;`
- `using Aspose.Html.Net;`
- `using Aspose.Html.Rendering.Image;`
- `using Aspose.Html.Saving;`

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [add_author_metadata_comment_at_beginning_of_markdown_file.cs](./add_author_metadata_comment_at_beginning_of_markdown_file.cs) | `MarkdownSaveOptions` | Add an author metadata comment at the beginning of the Markdown file for documentation pur... |
| [add_bullet_list_generated_from_array_of_strings_at_designated_location_in_document.cs](./add_bullet_list_generated_from_array_of_strings_at_designated_location_in_document.cs) |  | Add a bullet list generated from an array of strings at a designated location in the docum... |
| [add_custom_attribute_to_heading_nodes_for_seo_without_altering_visible_text.cs](./add_custom_attribute_to_heading_nodes_for_seo_without_altering_visible_text.cs) |  | Add a custom attribute to heading nodes for SEO purposes without altering visible text. |
| [add_custom_data_attribute_to_list_nodes_indicating_ordered_or_unordered.cs](./add_custom_data_attribute_to_list_nodes_indicating_ordered_or_unordered.cs) |  | Add a custom data attribute to list nodes indicating whether they are ordered or unordered... |
| [add_html_comment_with_line_numbers_before_each_paragraph_node_debugging.cs](./add_html_comment_with_line_numbers_before_each_paragraph_node_debugging.cs) |  | Add an HTML comment containing line numbers before each paragraph node for debugging purpo... |
| [add_language_identifiers_fenced_code_blocks_enable_proper_syntax_highlighting_rendered_output.cs](./add_language_identifiers_fenced_code_blocks_enable_proper_syntax_highlighting_rendered_output.cs) |  | Add language identifiers to fenced code blocks to enable proper syntax highlighting in ren... |
| [add_missing_alt_text_to_images_lacking_descriptions_with_default_placeholder.cs](./add_missing_alt_text_to_images_lacking_descriptions_with_default_placeholder.cs) |  | Add missing alt text to images lacking descriptions by inserting a default placeholder. |
| [add_timestamp_comment_indicating_processing_time_at_top_of_markdown_file.cs](./add_timestamp_comment_indicating_processing_time_at_top_of_markdown_file.cs) | `MarkdownSaveOptions` | Add a timestamp comment indicating processing time at the top of the Markdown file. |
| [add_title_attribute_image_markdown_nodes_tooltip_information.cs](./add_title_attribute_image_markdown_nodes_tooltip_information.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Add a title attribute to image markdown nodes to provide additional tooltip information. |
| [add_yaml_front_matter_block_top_with_custom_metadata_fields_for_document.cs](./add_yaml_front_matter_block_top_with_custom_metadata_fields_for_document.cs) |  | Add a YAML front‑matter block at the top with custom metadata fields for the document. |
| [append_disclaimer_paragraph_end_of_file_inform_readers_usage_terms.cs](./append_disclaimer_paragraph_end_of_file_inform_readers_usage_terms.cs) |  | Append a disclaimer paragraph at the end of the file to inform readers of usage terms. |
| [append_new_level_two_heading_with_custom_text_at_end_of_markdown_document.cs](./append_new_level_two_heading_with_custom_text_at_end_of_markdown_document.cs) | `MarkdownSaveOptions` | Append a new level‑two heading with custom text at the end of the Markdown document. |
| [append_tags_to_yaml_front_matter_based_on_extracted_heading_keywords.cs](./append_tags_to_yaml_front_matter_based_on_extracted_heading_keywords.cs) |  | Append a list of tags to the YAML front‑matter based on extracted heading keywords. |
| [apply_custom_css_class_to_all_code_block_nodes_by_modifying_syntax_properties.cs](./apply_custom_css_class_to_all_code_block_nodes_by_modifying_syntax_properties.cs) |  | Apply a custom CSS class to all code block nodes by modifying their syntax properties. |
| [apply_regex_mask_email_addresses_text_nodes_privacy_compliance.cs](./apply_regex_mask_email_addresses_text_nodes_privacy_compliance.cs) |  | Apply a regular expression to mask email addresses within all text nodes for privacy compl... |
| [batch_heading_updates_multiple_markdown_files_folder_shared_configuration.cs](./batch_heading_updates_multiple_markdown_files_folder_shared_configuration.cs) | `MarkdownSaveOptions`, `Configuration` | Perform batch heading updates across multiple Markdown files in a folder using a shared co... |
| [batch_processing_update_heading_prefixes_markdown_files_specified_directory.cs](./batch_processing_update_heading_prefixes_markdown_files_specified_directory.cs) | `MarkdownSaveOptions` | Perform batch processing to update heading prefixes across all Markdown files in a specifi... |
| [collapse_multiple_consecutive_blank_lines_to_single_blank_line_throughout_document.cs](./collapse_multiple_consecutive_blank_lines_to_single_blank_line_throughout_document.cs) |  | Collapse multiple consecutive blank lines into a single blank line throughout the document... |
| [compare_two_markdownsyntax_tree_objects_structural_equality_detect_unintended_modifications_version_control.cs](./compare_two_markdownsyntax_tree_objects_structural_equality_detect_unintended_modifications_version_control.cs) | `MarkdownSaveOptions` | Compare two MarkdownSyntaxTree objects for structural equality to detect unintended modifi... |
| [convert_blockquote_sections_into_italic_paragraphs_simplify_formatting_retaining_emphasis.cs](./convert_blockquote_sections_into_italic_paragraphs_simplify_formatting_retaining_emphasis.cs) | `Converter` | Convert blockquote sections into italic paragraphs to simplify formatting while retaining ... |
| [convert_existing_markdown_tables_to_plain_text_preserving_column_alignment.cs](./convert_existing_markdown_tables_to_plain_text_preserving_column_alignment.cs) | `MarkdownSaveOptions`, `Converter` | Convert existing Markdown tables into plain text representations while preserving column a... |
| [convert_heading_texts_to_title_case_keeping_hash_level_markers.cs](./convert_heading_texts_to_title_case_keeping_hash_level_markers.cs) | `Converter` | Convert all heading texts to title case while keeping their existing hash level markers. |
| [convert_inline_markdown_links_to_reference_style_and_generate_reference_list_bottom.cs](./convert_inline_markdown_links_to_reference_style_and_generate_reference_list_bottom.cs) | `MarkdownSaveOptions`, `Converter` | Convert inline Markdown links to reference‑style links and generate a reference list at th... |
| [convert_markdown_emphasis_markers_from_single_asterisks_to_double_asterisks_stronger_emphasis.cs](./convert_markdown_emphasis_markers_from_single_asterisks_to_double_asterisks_stronger_emphasis.cs) | `MarkdownSaveOptions`, `Converter` | Convert Markdown emphasis markers from single asterisks to double asterisks for stronger e... |
| [convert_markdown_footnotes_to_endnotes_and_adjust_references_throughout_document.cs](./convert_markdown_footnotes_to_endnotes_and_adjust_references_throughout_document.cs) | `MarkdownSaveOptions`, `Converter` | Convert Markdown footnotes to endnotes and adjust references accordingly throughout the do... |
| [convert_tabs_to_spaces_within_code_blocks_maintain_consistent_formatting_across_editors.cs](./convert_tabs_to_spaces_within_code_blocks_maintain_consistent_formatting_across_editors.cs) | `Converter` | Convert tabs to spaces within code blocks to maintain consistent formatting across editors... |
| [convert_task_list_items_to_regular_bullet_points_simplify_document_formatting.cs](./convert_task_list_items_to_regular_bullet_points_simplify_document_formatting.cs) | `Converter` | Convert task list items to regular bullet points to simplify document formatting. |
| [convert_unordered_list_items_to_ordered_list_preserving_hierarchy.cs](./convert_unordered_list_items_to_ordered_list_preserving_hierarchy.cs) | `Converter` | Convert an unordered list of items into an ordered list while preserving list hierarchy. |
| [convert_uppercase_heading_texts_to_title_case_preserving_hash_level_markers.cs](./convert_uppercase_heading_texts_to_title_case_preserving_hash_level_markers.cs) | `Converter` | Convert all uppercase heading texts to title case while preserving their hash level marker... |
| [count_headings_each_level_output_comment.cs](./count_headings_each_level_output_comment.cs) |  | Count the number of headings at each level and output the statistics as a comment. |
| [create_custom_transformation_wraps_all_paragraph_text_in_span_with_specific_css_class.cs](./create_custom_transformation_wraps_all_paragraph_text_in_span_with_specific_css_class.cs) |  | Create a custom transformation that wraps all paragraph text in a span with a specific CSS... |
| [create_new_markdown_table_from_two_dimensional_data_array_and_insert_after_heading.cs](./create_new_markdown_table_from_two_dimensional_data_array_and_insert_after_heading.cs) | `MarkdownSaveOptions` | Create a new Markdown table from a two‑dimensional data array and insert it after a headin... |
| [decrypt_previously_encrypted_markdown_nodes_restore_original_content_for_further_editing.cs](./decrypt_previously_encrypted_markdown_nodes_restore_original_content_for_further_editing.cs) | `MarkdownSaveOptions` | Decrypt previously encrypted Markdown nodes to restore original content for further editin... |
| [delete_specific_list_item_identified_by_text_content_from_markdown_list.cs](./delete_specific_list_item_identified_by_text_content_from_markdown_list.cs) | `MarkdownSaveOptions` | Delete a specific list item identified by its text content from a Markdown list. |
| [depth_first_traversal_collect_text_nodes_into_list_bulk_processing.cs](./depth_first_traversal_collect_text_nodes_into_list_bulk_processing.cs) |  | Perform a depth‑first traversal to collect all text nodes into a list for bulk processing. |
| [detect_and_fix_inconsistent_indentation_in_nested_lists_to_ensure_proper_hierarchical_rendering.cs](./detect_and_fix_inconsistent_indentation_in_nested_lists_to_ensure_proper_hierarchical_rendering.cs) |  | Detect and fix inconsistent indentation in nested lists to ensure proper hierarchical rend... |
| [detect_and_remove_stray_backticks_not_forming_valid_code_spans_clean_markup.cs](./detect_and_remove_stray_backticks_not_forming_valid_code_spans_clean_markup.cs) |  | Detect and remove stray backticks that do not form valid code spans to clean markup. |
| [detect_broken_image_links_by_checking_each_image_url_http_response_status.cs](./detect_broken_image_links_by_checking_each_image_url_http_response_status.cs) | `ImageSaveOptions`, `Url` | Detect broken image links by checking each image URL's HTTP response status. |
| [detect_duplicate_heading_texts_rename_unique_identifiers_avoid_ambiguity.cs](./detect_duplicate_heading_texts_rename_unique_identifiers_avoid_ambiguity.cs) |  | Detect duplicate heading texts and rename them with unique identifiers to avoid ambiguity. |
| [detect_github_flavored_markdown_features_within_document_and_log_identified_elements.cs](./detect_github_flavored_markdown_features_within_document_and_log_identified_elements.cs) | `MarkdownSaveOptions` | Detect GitHub Flavored Markdown features within a document and log identified elements. |
| [detect_mismatched_markdown_delimiters_correct_maintain_valid_syntax.cs](./detect_mismatched_markdown_delimiters_correct_maintain_valid_syntax.cs) | `MarkdownSaveOptions` | Detect mismatched Markdown delimiters and automatically correct them to maintain valid syn... |
| [detect_unescaped_special_characters_in_urls_and_escape_to_prevent_parsing_errors.cs](./detect_unescaped_special_characters_in_urls_and_escape_to_prevent_parsing_errors.cs) |  | Detect unescaped special characters in URLs and escape them to prevent parsing errors. |
| [encrypt_specific_markdown_nodes_using_custom_wrapper_to_protect_sensitive_content_before_saving.cs](./encrypt_specific_markdown_nodes_using_custom_wrapper_to_protect_sensitive_content_before_saving.cs) | `MarkdownSaveOptions` | Encrypt specific Markdown nodes using a custom wrapper to protect sensitive content before... |
| [ensure_each_list_preceded_by_blank_line_markdown_spacing_conventions.cs](./ensure_each_list_preceded_by_blank_line_markdown_spacing_conventions.cs) | `MarkdownSaveOptions` | Ensure each list is preceded by a blank line to conform with Markdown spacing conventions. |
| [ensure_every_heading_node_ends_with_newline_character_maintain_valid_markdown_syntax.cs](./ensure_every_heading_node_ends_with_newline_character_maintain_valid_markdown_syntax.cs) | `MarkdownSaveOptions` | Ensure every heading node ends with a newline character to maintain valid Markdown syntax. |
| [ensure_markdown_file_ends_with_single_newline_character_to_satisfy_parser_requirements.cs](./ensure_markdown_file_ends_with_single_newline_character_to_satisfy_parser_requirements.cs) | `MarkdownSaveOptions` | Ensure the Markdown file ends with a single newline character to satisfy parser requiremen... |
| [escape_special_markdown_characters_in_all_text_nodes_to_prevent_unintended_formatting.cs](./escape_special_markdown_characters_in_all_text_nodes_to_prevent_unintended_formatting.cs) | `MarkdownSaveOptions` | Escape special Markdown characters in all text nodes to prevent unintended formatting. |
| [export_entire_markdownsyntax_tree_to_xml_for_archival_and_version_control.cs](./export_entire_markdownsyntax_tree_to_xml_for_archival_and_version_control.cs) | `MarkdownSaveOptions` | Export the entire MarkdownSyntaxTree to an XML file for archival and version control purpo... |
| [extract_all_hyperlink_urls_from_markdown_document_and_store_in_list.cs](./extract_all_hyperlink_urls_from_markdown_document_and_store_in_list.cs) | `MarkdownSaveOptions` | Extract all hyperlink URLs from the Markdown document and store them in a list. |
| [extract_all_list_items_from_document_and_write_them_to_separate_markdown_file.cs](./extract_all_list_items_from_document_and_write_them_to_separate_markdown_file.cs) | `MarkdownSaveOptions` | Extract all list items from the document and write them to a separate Markdown file. |
| [extract_all_task_list_items_into_json_array_for_external_processing_or_reporting.cs](./extract_all_task_list_items_into_json_array_for_external_processing_or_reporting.cs) |  | Extract all task list items into a JSON array for external processing or reporting. |
| [generate_consolidated_reference_list_for_all_urls_used_in_document_and_insert.cs](./generate_consolidated_reference_list_for_all_urls_used_in_document_and_insert.cs) |  | Generate a consolidated reference list for all URLs used in the document and insert it. |
| [generate_html_preview_of_markdown_content_using_builtin_renderer_visual_verification.cs](./generate_html_preview_of_markdown_content_using_builtin_renderer_visual_verification.cs) | `MarkdownSaveOptions` | Generate an HTML preview of the Markdown content using the built‑in renderer for visual ve... |
| [generate_index_markdown_file_linking_each_split_chapter_file_quick_access.cs](./generate_index_markdown_file_linking_each_split_chapter_file_quick_access.cs) | `MarkdownSaveOptions` | Generate an index Markdown file linking to each split chapter file for quick access. |
| [generate_json_representation_heading_hierarchy_external_analysis_integration.cs](./generate_json_representation_heading_hierarchy_external_analysis_integration.cs) |  | Generate a JSON representation of the heading hierarchy for external analysis or integrati... |
| [generate_report_summarizing_all_modifications_to_markdown_file_including_counts_of_each_change_type.cs](./generate_report_summarizing_all_modifications_to_markdown_file_including_counts_of_each_change_type.cs) | `MarkdownSaveOptions` | Generate a report summarizing all modifications made to a Markdown file, including counts ... |
| [generate_summary_paragraph_document_length_main_topics.cs](./generate_summary_paragraph_document_length_main_topics.cs) |  | Generate a summary paragraph that describes the document length and main topics. |
| [generate_table_of_contents_based_on_heading_hierarchy_and_insert_at_top.cs](./generate_table_of_contents_based_on_heading_hierarchy_and_insert_at_top.cs) |  | Generate a table of contents based on heading hierarchy and insert it at the top. |
| [generate_word_count_statistic_embed_comment_top_document.cs](./generate_word_count_statistic_embed_comment_top_document.cs) |  | Generate a word count statistic and embed it as a comment at the top of the document. |
| [highlight_code_block_syntax_by_assigning_custom_css_class_via_node_property_modification.cs](./highlight_code_block_syntax_by_assigning_custom_css_class_via_node_property_modification.cs) |  | Highlight code block syntax by assigning a custom CSS class through node property modifica... |
| [implement_lazy_loading_for_large_images_by_inserting_placeholder_syntax_before_actual_image_references.cs](./implement_lazy_loading_for_large_images_by_inserting_placeholder_syntax_before_actual_image_references.cs) | `ImageSaveOptions` | Implement lazy loading for large images by inserting placeholder syntax before actual imag... |
| [insert_checklist_items_using_task_list_syntax_and_set_initial_checked_state.cs](./insert_checklist_items_using_task_list_syntax_and_set_initial_checked_state.cs) |  | Insert checklist items using task list syntax and set their initial checked state. |
| [insert_copyright_notice_after_first_heading_ownership.cs](./insert_copyright_notice_after_first_heading_ownership.cs) |  | Insert a copyright notice immediately after the first heading to assert ownership. |
| [insert_footnote_definitions_end_of_document_each_referenced_footnote_marker.cs](./insert_footnote_definitions_end_of_document_each_referenced_footnote_marker.cs) |  | Insert footnote definitions at the end of the document for each referenced footnote marker... |
| [insert_generated_table_of_contents_after_front_matter_block_improve_navigation.cs](./insert_generated_table_of_contents_after_front_matter_block_improve_navigation.cs) |  | Insert a generated table of contents after the front‑matter block to improve navigation. |
| [insert_horizontal_rule_after_top_level_heading_sections.cs](./insert_horizontal_rule_after_top_level_heading_sections.cs) |  | Insert a horizontal rule after every top‑level heading to visually separate sections. |
| [insert_horizontal_rule_before_each_code_block_visually_separate_code_from_surrounding_text.cs](./insert_horizontal_rule_before_each_code_block_visually_separate_code_from_surrounding_text.cs) |  | Insert a horizontal rule before each code block to visually separate code from surrounding... |
| [insert_line_break_long_heading_text_readability_narrow_screens.cs](./insert_line_break_long_heading_text_readability_narrow_screens.cs) |  | Insert a line break within a long heading text to improve readability on narrow screens. |
| [insert_markdown_comment_before_heading_indicating_hierarchical_level_easier_navigation.cs](./insert_markdown_comment_before_heading_indicating_hierarchical_level_easier_navigation.cs) | `MarkdownSaveOptions` | Insert a Markdown comment before each heading indicating its hierarchical level for easier... |
| [insert_subheading_under_specified_parent_heading_using_markdownsyntaxfactory_create_nodes.cs](./insert_subheading_under_specified_parent_heading_using_markdownsyntaxfactory_create_nodes.cs) | `MarkdownSaveOptions` | Insert a subheading under a specified parent heading using the MarkdownSyntaxFactory to cr... |
| [insert_table_of_figures_generated_from_image_captions_place_after_table_of_contents.cs](./insert_table_of_figures_generated_from_image_captions_place_after_table_of_contents.cs) | `ImageSaveOptions` | Insert a table of figures generated from image captions and place it after the table of co... |
| [load_all_md_files_from_directory_and_parse_each_into_separate_syntax_trees.cs](./load_all_md_files_from_directory_and_parse_each_into_separate_syntax_trees.cs) |  | Load all .md files from a directory and parse each into separate syntax trees. |
| [load_previously_saved_xml_representation_syntax_tree_and_reconstruct_markdown_document.cs](./load_previously_saved_xml_representation_syntax_tree_and_reconstruct_markdown_document.cs) | `MarkdownSaveOptions` | Load a previously saved XML representation of a syntax tree and reconstruct the Markdown d... |
| [merge_consecutive_list_items_into_single_paragraph_to_simplify_list_presentation.cs](./merge_consecutive_list_items_into_single_paragraph_to_simplify_list_presentation.cs) |  | Merge consecutive list items into a single paragraph to simplify list presentation. |
| [merge_consecutive_paragraph_nodes_into_single_paragraph_reduce_unnecessary_breaks.cs](./merge_consecutive_paragraph_nodes_into_single_paragraph_reduce_unnecessary_breaks.cs) |  | Merge consecutive paragraph nodes into a single paragraph to reduce unnecessary breaks. |
| [merge_two_markdown_documents_preserving_heading_hierarchy_insert_separator_comment.cs](./merge_two_markdown_documents_preserving_heading_hierarchy_insert_separator_comment.cs) | `MarkdownSaveOptions` | Merge two Markdown documents while preserving heading hierarchy and inserting a separator ... |
| [normalize_all_line_endings_in_document_to_lf_characters_for_consistent_cross_platform_behavior.cs](./normalize_all_line_endings_in_document_to_lf_characters_for_consistent_cross_platform_behavior.cs) |  | Normalize all line endings in the document to LF characters for consistent cross‑platform ... |
| [optimize_image_markdown_adding_width_attributes_improve_rendering_performance_web_pages.cs](./optimize_image_markdown_adding_width_attributes_improve_rendering_performance_web_pages.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Optimize image markdown by adding width attributes to improve rendering performance on web... |
| [parse_single_markdown_file_into_markdown_syntax_tree_using_markdown_parser.cs](./parse_single_markdown_file_into_markdown_syntax_tree_using_markdown_parser.cs) | `MarkdownSaveOptions` | Parse a single Markdown file into a MarkdownSyntaxTree using the MarkdownParser class. |
| [prefix_each_heading_sequential_numeric_index_create_ordered_document_outline.cs](./prefix_each_heading_sequential_numeric_index_create_ordered_document_outline.cs) |  | Prefix each heading with a sequential numeric index to create an ordered document outline. |
| [prepend_note_to_blockquote_contents_highlight_important_information.cs](./prepend_note_to_blockquote_contents_highlight_important_information.cs) |  | Prepend the word “NOTE:” to all blockquote contents to highlight important information. |
| [remove_all_empty_list_items_clean_up_list_structures_avoid_rendering_issues.cs](./remove_all_empty_list_items_clean_up_list_structures_avoid_rendering_issues.cs) |  | Remove all empty list items to clean up list structures and avoid rendering issues. |
| [remove_all_markdown_comments_from_document_produce_clean_version_without_annotations.cs](./remove_all_markdown_comments_from_document_produce_clean_version_without_annotations.cs) | `MarkdownSaveOptions` | Remove all Markdown comments from the document to produce a clean version without annotati... |
| [remove_blockquote_formatting_preserving_inner_text_flatten_document_structure.cs](./remove_blockquote_formatting_preserving_inner_text_flatten_document_structure.cs) |  | Remove blockquote formatting while preserving the inner text to flatten document structure... |
| [remove_duplicate_paragraph_nodes_eliminate_redundant_content_streamline_document.cs](./remove_duplicate_paragraph_nodes_eliminate_redundant_content_streamline_document.cs) |  | Remove duplicate paragraph nodes to eliminate redundant content and streamline the documen... |
| [remove_embedded_html_tags_from_markdown_content_ensure_pure_markdown_output.cs](./remove_embedded_html_tags_from_markdown_content_ensure_pure_markdown_output.cs) | `MarkdownSaveOptions` | Remove any embedded HTML tags from the Markdown content to ensure pure Markdown output. |
| [remove_empty_paragraph_nodes_from_syntax_tree_clean_document_structure.cs](./remove_empty_paragraph_nodes_from_syntax_tree_clean_document_structure.cs) |  | Remove all empty paragraph nodes from the syntax tree to clean up the document structure. |
| [remove_existing_yaml_front_matter_block_revert_document_to_plain_markdown.cs](./remove_existing_yaml_front_matter_block_revert_document_to_plain_markdown.cs) | `MarkdownSaveOptions` | Remove an existing YAML front‑matter block to revert the document to plain Markdown. |
| [renumber_ordered_list_after_deleting_items_maintain_proper_numeric_ordering.cs](./renumber_ordered_list_after_deleting_items_maintain_proper_numeric_ordering.cs) |  | Renumber an ordered list after deleting items to maintain proper numeric ordering. |
| [reorder_list_items_alphabetically_based_on_text_values_and_update_syntax_tree.cs](./reorder_list_items_alphabetically_based_on_text_values_and_update_syntax_tree.cs) |  | Reorder list items alphabetically based on their text values and update the syntax tree. |
| [replace_all_em_dashes_with_double_hyphens_for_plain_text_viewer_compatibility.cs](./replace_all_em_dashes_with_double_hyphens_for_plain_text_viewer_compatibility.cs) |  | Replace all em dashes with double hyphens to ensure compatibility with plain‑text viewers. |
| [replace_all_inline_html_tags_with_equivalent_markdown_syntax_to_maintain_pure_markdown_formatting.cs](./replace_all_inline_html_tags_with_equivalent_markdown_syntax_to_maintain_pure_markdown_formatting.cs) | `MarkdownSaveOptions` | Replace all inline HTML tags with equivalent Markdown syntax to maintain pure Markdown for... |
| [replace_content_first_paragraph_node_new_text_retaining_formatting.cs](./replace_content_first_paragraph_node_new_text_retaining_formatting.cs) |  | Replace the content of the first paragraph node with new text while retaining its formatti... |
| [replace_double_spaces_with_single_spaces_in_all_text_nodes_to_improve_readability.cs](./replace_double_spaces_with_single_spaces_in_all_text_nodes_to_improve_readability.cs) |  | Replace double spaces with single spaces in all text nodes to improve readability. |
| [replace_existing_image_urls_with_cdn_hosted_equivalents_improve_loading_performance_for_users.cs](./replace_existing_image_urls_with_cdn_hosted_equivalents_improve_loading_performance_for_users.cs) | `ImageSaveOptions` | Replace existing image URLs with CDN-hosted equivalents to improve loading performance for... |
| [replace_footnote_reference_markers_with_inline_explanatory_text_simplify_reading_users.cs](./replace_footnote_reference_markers_with_inline_explanatory_text_simplify_reading_users.cs) |  | Replace footnote reference markers with inline explanatory text to simplify reading for us... |
| [replace_inline_code_spans_with_emphasized_text_demonstrate_formatting_options.cs](./replace_inline_code_spans_with_emphasized_text_demonstrate_formatting_options.cs) |  | Replace inline code spans with emphasized text to demonstrate alternative formatting optio... |
| [replace_markdown_image_syntax_html_img_tags_preserving_alt_text_source_attributes.cs](./replace_markdown_image_syntax_html_img_tags_preserving_alt_text_source_attributes.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Replace Markdown image syntax with HTML img tags while preserving alt text and source attr... |
| [replace_markdown_tables_with_csv_code_fences_provide_raw_data_format.cs](./replace_markdown_tables_with_csv_code_fences_provide_raw_data_format.cs) | `MarkdownSaveOptions` | Replace all Markdown tables with CSV code fences to provide raw data format. |
| [save_generated_html_preview_to_temporary_file_for_automated_testing_workflows.cs](./save_generated_html_preview_to_temporary_file_for_automated_testing_workflows.cs) |  | Save the generated HTML preview to a temporary file for automated testing workflows. |
| [save_updated_markdown_document_preserving_original_encoding_line_ending_style.cs](./save_updated_markdown_document_preserving_original_encoding_line_ending_style.cs) | `MarkdownSaveOptions` | Save the updated Markdown document preserving the original file encoding and line ending s... |
| [serialize_modified_markdown_syntax_tree_to_string_with_custom_indentation_for_readability.cs](./serialize_modified_markdown_syntax_tree_to_string_with_custom_indentation_for_readability.cs) | `MarkdownSaveOptions` | Serialize the modified MarkdownSyntaxTree to a string with custom indentation for readabil... |
| [split_document_into_chapters_based_on_level_2_headings_and_save_each_as_separate_file.cs](./split_document_into_chapters_based_on_level_2_headings_and_save_each_as_separate_file.cs) |  | Split the document into chapters based on level‑2 headings and save each as a separate fil... |
| [split_long_paragraph_into_two_separate_nodes_at_nearest_sentence_boundary.cs](./split_long_paragraph_into_two_separate_nodes_at_nearest_sentence_boundary.cs) |  | Split a long paragraph into two separate nodes at the nearest sentence boundary. |
| [split_markdown_document_into_separate_files_per_top_level_heading_modular_sections.cs](./split_markdown_document_into_separate_files_per_top_level_heading_modular_sections.cs) | `MarkdownSaveOptions` | Split a Markdown document into separate files for each top‑level heading to create modular... |
| [toggle_checked_state_of_task_list_items_programmatically_to_reflect_completion_status.cs](./toggle_checked_state_of_task_list_items_programmatically_to_reflect_completion_status.cs) |  | Toggle the checked state of task list items programmatically to reflect completion status. |
| [trim_leading_trailing_whitespace_from_every_text_node_ensure_consistent_spacing.cs](./trim_leading_trailing_whitespace_from_every_text_node_ensure_consistent_spacing.cs) |  | Trim leading and trailing whitespace from every text node to ensure consistent spacing. |
| [trim_trailing_spaces_each_line_avoid_unnecessary_whitespace_final_output.cs](./trim_trailing_spaces_each_line_avoid_unnecessary_whitespace_final_output.cs) |  | Trim trailing spaces from each line to avoid unnecessary whitespace in the final output. |
| [update_specific_fields_within_yaml_front_matter_title_date_programmatically.cs](./update_specific_fields_within_yaml_front_matter_title_date_programmatically.cs) |  | Update specific fields within the YAML front‑matter, such as title or date, programmatical... |
| [update_text_of_atx_heading_preserving_original_hash_symbol_count.cs](./update_text_of_atx_heading_preserving_original_hash_symbol_count.cs) |  | Update the text of an ATX heading while preserving its original number of hash symbols. |
| [validate_document_contains_at_least_one_heading_meet_structural_requirements.cs](./validate_document_contains_at_least_one_heading_meet_structural_requirements.cs) |  | Validate that the document contains at least one heading to meet structural requirements. |
| [validate_document_does_not_contain_raw_html_tags_ensure_strict_markdown_compliance.cs](./validate_document_does_not_contain_raw_html_tags_ensure_strict_markdown_compliance.cs) | `MarkdownSaveOptions` | Validate that the document does not contain any raw HTML tags to ensure strict Markdown co... |
| [validate_every_footnote_definition_is_referenced_in_document_to_avoid_orphaned_notes.cs](./validate_every_footnote_definition_is_referenced_in_document_to_avoid_orphaned_notes.cs) |  | Validate that every footnote definition is referenced somewhere in the document to avoid o... |
| [validate_every_url_in_document_uses_https_scheme_for_secure_connections.cs](./validate_every_url_in_document_uses_https_scheme_for_secure_connections.cs) | `Url` | Validate that every URL in the document uses the HTTPS scheme for secure connections. |
| [validate_heading_levels_follow_logical_hierarchy_without_skipping_intermediate_levels.cs](./validate_heading_levels_follow_logical_hierarchy_without_skipping_intermediate_levels.cs) |  | Validate that heading levels follow a logical hierarchy without skipping intermediate leve... |
| [validate_no_heading_exceeds_six_hash_characters_ensuring_markdown_specifications_compliance.cs](./validate_no_heading_exceeds_six_hash_characters_ensuring_markdown_specifications_compliance.cs) | `MarkdownSaveOptions` | Validate that no heading exceeds six hash characters, ensuring compliance with Markdown sp... |
| [validate_no_paragraph_exceeds_two_hundred_words_maintain_concise_content_standards.cs](./validate_no_paragraph_exceeds_two_hundred_words_maintain_concise_content_standards.cs) |  | Validate that no paragraph exceeds two hundred words to maintain concise content standards... |
| [validate_ordered_list_numbers_sequential_and_correct_gaps_after_item_removal.cs](./validate_ordered_list_numbers_sequential_and_correct_gaps_after_item_removal.cs) |  | Validate that ordered list numbers are sequential and correct any gaps after item removal. |
| [validate_required_fields_title_and_author_exist_in_yaml_front_matter_block.cs](./validate_required_fields_title_and_author_exist_in_yaml_front_matter_block.cs) |  | Validate that required fields like title and author exist in the YAML front‑matter block. |
| [verify_all_code_blocks_fenced_with_backticks_and_correct_indentation.cs](./verify_all_code_blocks_fenced_with_backticks_and_correct_indentation.cs) |  | Verify that all code blocks are fenced with backticks and correct any that use indentation... |

## Category Statistics
- Total examples: 120
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `HTMLDocument`
- `MarkdownSaveOptions`
- `OutlineNode`
- `HttpClient`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-10-01 | Examples: 120
<!-- AUTOGENERATED:END -->
