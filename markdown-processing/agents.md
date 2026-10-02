---
name: markdown-processing
description: C# examples for Markdown Processing using Aspose.HTML for .NET
language: csharp
framework: net10.0
parent: ../AGENTS.md
---

# AGENTS - Markdown Processing

## Persona

You are a C# developer specializing in HTML document conversion and DOM manipulation using Aspose.HTML for .NET,
working within the **Markdown Processing** category.
This folder contains standalone C# examples for Markdown Processing operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

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
| [add-author-metadata-comment-beginning-markdown-file-documentation.cs](./add-author-metadata-comment-beginning-markdown-file-documentation.cs) | `MarkdownSaveOptions` | Add an author metadata comment at the beginning of the Markdown file for documentation pur... |
| [add-bullet-list-generated-from-array-of-strings-at-designated-location-in-document.cs](./add-bullet-list-generated-from-array-of-strings-at-designated-location-in-document.cs) |  | Add a bullet list generated from an array of strings at a designated location in the docum... |
| [add-custom-attribute-heading-nodes-seo-purposes-altering-visible-text.cs](./add-custom-attribute-heading-nodes-seo-purposes-altering-visible-text.cs) |  | Add a custom attribute to heading nodes for SEO purposes without altering visible text. |
| [add-custom-data-attribute-to-list-nodes-indicating-ordered-or-unordered.cs](./add-custom-data-attribute-to-list-nodes-indicating-ordered-or-unordered.cs) |  | Add a custom data attribute to list nodes indicating whether they are ordered or unordered... |
| [add-html-comment-with-line-numbers-before-each-paragraph-node-debugging.cs](./add-html-comment-with-line-numbers-before-each-paragraph-node-debugging.cs) |  | Add an HTML comment containing line numbers before each paragraph node for debugging purpo... |
| [add-language-identifiers-fenced-code-blocks-enable-proper-syntax-highlighting-rendered-output.cs](./add-language-identifiers-fenced-code-blocks-enable-proper-syntax-highlighting-rendered-output.cs) |  | Add language identifiers to fenced code blocks to enable proper syntax highlighting in ren... |
| [add-missing-alt-text-to-images-lacking-descriptions-by-inserting-default-placeholder.cs](./add-missing-alt-text-to-images-lacking-descriptions-by-inserting-default-placeholder.cs) |  | Add missing alt text to images lacking descriptions by inserting a default placeholder. |
| [add-timestamp-comment-indicating-processing-time-top-markdown-file.cs](./add-timestamp-comment-indicating-processing-time-top-markdown-file.cs) | `MarkdownSaveOptions` | Add a timestamp comment indicating processing time at the top of the Markdown file. |
| [add-title-attribute-image-markdown-nodes-tooltip-information.cs](./add-title-attribute-image-markdown-nodes-tooltip-information.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Add a title attribute to image markdown nodes to provide additional tooltip information. |
| [add-yaml-front-matter-block-at-top-with-custom-metadata-fields.cs](./add-yaml-front-matter-block-at-top-with-custom-metadata-fields.cs) |  | Add a YAML front‑matter block at the top with custom metadata fields for the document. |
| [append-disclaimer-paragraph-at-end-of-file-to-inform-readers-of-usage-terms.cs](./append-disclaimer-paragraph-at-end-of-file-to-inform-readers-of-usage-terms.cs) |  | Append a disclaimer paragraph at the end of the file to inform readers of usage terms. |
| [append-list-of-tags-to-yaml-front-matter-based-on-extracted-heading-keywords.cs](./append-list-of-tags-to-yaml-front-matter-based-on-extracted-heading-keywords.cs) |  | Append a list of tags to the YAML front‑matter based on extracted heading keywords. |
| [append-new-level-two-heading-with-custom-text-at-end-of-markdown-document.cs](./append-new-level-two-heading-with-custom-text-at-end-of-markdown-document.cs) | `MarkdownSaveOptions` | Append a new level‑two heading with custom text at the end of the Markdown document. |
| [apply-custom-css-class-code-block-nodes-modifying-syntax-properties.cs](./apply-custom-css-class-code-block-nodes-modifying-syntax-properties.cs) |  | Apply a custom CSS class to all code block nodes by modifying their syntax properties. |
| [apply-regular-expression-mask-email-addresses-all-text-nodes-privacy-compliance.cs](./apply-regular-expression-mask-email-addresses-all-text-nodes-privacy-compliance.cs) |  | Apply a regular expression to mask email addresses within all text nodes for privacy compl... |
| [batch-heading-updates-multiple-markdown-files-folder-shared-configuration.cs](./batch-heading-updates-multiple-markdown-files-folder-shared-configuration.cs) | `MarkdownSaveOptions`, `Configuration` | Perform batch heading updates across multiple Markdown files in a folder using a shared co... |
| [batch-processing-update-heading-prefixes-across-all-markdown-files-in-specified-directory.cs](./batch-processing-update-heading-prefixes-across-all-markdown-files-in-specified-directory.cs) | `MarkdownSaveOptions` | Perform batch processing to update heading prefixes across all Markdown files in a specifi... |
| [collapse-multiple-consecutive-blank-lines-into-single-blank-line-throughout-document.cs](./collapse-multiple-consecutive-blank-lines-into-single-blank-line-throughout-document.cs) |  | Collapse multiple consecutive blank lines into a single blank line throughout the document... |
| [compare-two-markdownsyntax-tree-objects-structural-equality-detect-unintended-modifications-version-control.cs](./compare-two-markdownsyntax-tree-objects-structural-equality-detect-unintended-modifications-version-control.cs) | `MarkdownSaveOptions` | Compare two MarkdownSyntaxTree objects for structural equality to detect unintended modifi... |
| [convert-blockquote-sections-into-italic-paragraphs-simplify-formatting-retaining-emphasis.cs](./convert-blockquote-sections-into-italic-paragraphs-simplify-formatting-retaining-emphasis.cs) | `Converter` | Convert blockquote sections into italic paragraphs to simplify formatting while retaining ... |
| [convert-existing-markdown-tables-to-plain-text-with-column-alignment.cs](./convert-existing-markdown-tables-to-plain-text-with-column-alignment.cs) | `MarkdownSaveOptions`, `Converter` | Convert existing Markdown tables into plain text representations while preserving column a... |
| [convert-heading-texts-to-title-case-while-keeping-existing-hash-level-markers.cs](./convert-heading-texts-to-title-case-while-keeping-existing-hash-level-markers.cs) | `Converter` | Convert all heading texts to title case while keeping their existing hash level markers. |
| [convert-inline-markdown-links-to-reference-style-links-and-generate-reference-list-bottom.cs](./convert-inline-markdown-links-to-reference-style-links-and-generate-reference-list-bottom.cs) | `MarkdownSaveOptions`, `Converter` | Convert inline Markdown links to reference‑style links and generate a reference list at th... |
| [convert-markdown-emphasis-markers-from-single-asterisks-to-double-asterisks-stronger-emphasis.cs](./convert-markdown-emphasis-markers-from-single-asterisks-to-double-asterisks-stronger-emphasis.cs) | `MarkdownSaveOptions`, `Converter` | Convert Markdown emphasis markers from single asterisks to double asterisks for stronger e... |
| [convert-markdown-footnotes-to-endnotes-adjust-references-accordingly-throughout-document.cs](./convert-markdown-footnotes-to-endnotes-adjust-references-accordingly-throughout-document.cs) | `MarkdownSaveOptions`, `Converter` | Convert Markdown footnotes to endnotes and adjust references accordingly throughout the do... |
| [convert-tabs-to-spaces-code-blocks-consistent-formatting-editors.cs](./convert-tabs-to-spaces-code-blocks-consistent-formatting-editors.cs) | `Converter` | Convert tabs to spaces within code blocks to maintain consistent formatting across editors... |
| [convert-task-list-items-regular-bullet-points-simplify-document-formatting.cs](./convert-task-list-items-regular-bullet-points-simplify-document-formatting.cs) | `Converter` | Convert task list items to regular bullet points to simplify document formatting. |
| [convert-unordered-list-to-ordered-list-preserving-hierarchy.cs](./convert-unordered-list-to-ordered-list-preserving-hierarchy.cs) | `Converter` | Convert an unordered list of items into an ordered list while preserving list hierarchy. |
| [convert-uppercase-heading-texts-to-title-case-preserving-hash-level-markers.cs](./convert-uppercase-heading-texts-to-title-case-preserving-hash-level-markers.cs) | `Converter` | Convert all uppercase heading texts to title case while preserving their hash level marker... |
| [count-number-of-headings-at-each-level-output-statistics-as-comment.cs](./count-number-of-headings-at-each-level-output-statistics-as-comment.cs) |  | Count the number of headings at each level and output the statistics as a comment. |
| [create-new-markdown-table-from-two-dimensional-data-array-and-insert-after-heading.cs](./create-new-markdown-table-from-two-dimensional-data-array-and-insert-after-heading.cs) | `MarkdownSaveOptions` | Create a new Markdown table from a two‑dimensional data array and insert it after a headin... |
| [custom-transformation-wrap-paragraph-text-span-specific-css-class.cs](./custom-transformation-wrap-paragraph-text-span-specific-css-class.cs) |  | Create a custom transformation that wraps all paragraph text in a span with a specific CSS... |
| [decrypt-encrypted-markdown-nodes-restore-original-content-editing.cs](./decrypt-encrypted-markdown-nodes-restore-original-content-editing.cs) | `MarkdownSaveOptions` | Decrypt previously encrypted Markdown nodes to restore original content for further editin... |
| [delete-specific-list-item-identified-by-text-content-from-markdown-list.cs](./delete-specific-list-item-identified-by-text-content-from-markdown-list.cs) | `MarkdownSaveOptions` | Delete a specific list item identified by its text content from a Markdown list. |
| [depth-first-traversal-collect-all-text-nodes-into-list-for-bulk-processing.cs](./depth-first-traversal-collect-all-text-nodes-into-list-for-bulk-processing.cs) |  | Perform a depth‑first traversal to collect all text nodes into a list for bulk processing. |
| [detect-and-fix-inconsistent-indentation-in-nested-lists-to-ensure-proper-hierarchical-rendering.cs](./detect-and-fix-inconsistent-indentation-in-nested-lists-to-ensure-proper-hierarchical-rendering.cs) |  | Detect and fix inconsistent indentation in nested lists to ensure proper hierarchical rend... |
| [detect-broken-image-links-checking-each-image-url-http-response-status.cs](./detect-broken-image-links-checking-each-image-url-http-response-status.cs) | `ImageSaveOptions`, `Url` | Detect broken image links by checking each image URL's HTTP response status. |
| [detect-duplicate-heading-texts-rename-with-unique-identifiers-avoid-ambiguity.cs](./detect-duplicate-heading-texts-rename-with-unique-identifiers-avoid-ambiguity.cs) |  | Detect duplicate heading texts and rename them with unique identifiers to avoid ambiguity. |
| [detect-github-flavored-markdown-features-within-document-and-log-identified-elements.cs](./detect-github-flavored-markdown-features-within-document-and-log-identified-elements.cs) | `MarkdownSaveOptions` | Detect GitHub Flavored Markdown features within a document and log identified elements. |
| [detect-mismatched-markdown-delimiters-automatically-correct-them-maintain-valid-syntax.cs](./detect-mismatched-markdown-delimiters-automatically-correct-them-maintain-valid-syntax.cs) | `MarkdownSaveOptions` | Detect mismatched Markdown delimiters and automatically correct them to maintain valid syn... |
| [detect-remove-stray-backticks-not-valid-code-spans-clean-markup.cs](./detect-remove-stray-backticks-not-valid-code-spans-clean-markup.cs) |  | Detect and remove stray backticks that do not form valid code spans to clean markup. |
| [detect-unescaped-special-characters-in-urls-and-escape-to-prevent-parsing-errors.cs](./detect-unescaped-special-characters-in-urls-and-escape-to-prevent-parsing-errors.cs) |  | Detect unescaped special characters in URLs and escape them to prevent parsing errors. |
| [encrypt-specific-markdown-nodes-with-custom-wrapper-protect-sensitive-content-before-saving.cs](./encrypt-specific-markdown-nodes-with-custom-wrapper-protect-sensitive-content-before-saving.cs) | `MarkdownSaveOptions` | Encrypt specific Markdown nodes using a custom wrapper to protect sensitive content before... |
| [ensure-each-list-preceded-by-blank-line-for-markdown-spacing-conventions.cs](./ensure-each-list-preceded-by-blank-line-for-markdown-spacing-conventions.cs) | `MarkdownSaveOptions` | Ensure each list is preceded by a blank line to conform with Markdown spacing conventions. |
| [ensure-every-heading-node-ends-with-newline-character-to-maintain-valid-markdown-syntax.cs](./ensure-every-heading-node-ends-with-newline-character-to-maintain-valid-markdown-syntax.cs) | `MarkdownSaveOptions` | Ensure every heading node ends with a newline character to maintain valid Markdown syntax. |
| [ensure-markdown-file-ends-single-newline-parser-requirements.cs](./ensure-markdown-file-ends-single-newline-parser-requirements.cs) | `MarkdownSaveOptions` | Ensure the Markdown file ends with a single newline character to satisfy parser requiremen... |
| [escape-special-markdown-characters-all-text-nodes-prevent-unintended-formatting.cs](./escape-special-markdown-characters-all-text-nodes-prevent-unintended-formatting.cs) | `MarkdownSaveOptions` | Escape special Markdown characters in all text nodes to prevent unintended formatting. |
| [export-entire-markdownsyntax-tree-xml-file-archival-version-control.cs](./export-entire-markdownsyntax-tree-xml-file-archival-version-control.cs) | `MarkdownSaveOptions` | Export the entire MarkdownSyntaxTree to an XML file for archival and version control purpo... |
| [extract-all-hyperlink-urls-from-markdown-document-and-store-them-in-list.cs](./extract-all-hyperlink-urls-from-markdown-document-and-store-them-in-list.cs) | `MarkdownSaveOptions` | Extract all hyperlink URLs from the Markdown document and store them in a list. |
| [extract-all-list-items-from-document-and-write-them-to-separate-markdown-file.cs](./extract-all-list-items-from-document-and-write-them-to-separate-markdown-file.cs) | `MarkdownSaveOptions` | Extract all list items from the document and write them to a separate Markdown file. |
| [extract-all-task-list-items-into-json-array-external-processing-reporting.cs](./extract-all-task-list-items-into-json-array-external-processing-reporting.cs) |  | Extract all task list items into a JSON array for external processing or reporting. |
| [generate-consolidated-reference-list-for-all-urls-used-in-document-and-insert.cs](./generate-consolidated-reference-list-for-all-urls-used-in-document-and-insert.cs) |  | Generate a consolidated reference list for all URLs used in the document and insert it. |
| [generate-html-preview-of-markdown-content-using-built-in-renderer-for-visual-verification.cs](./generate-html-preview-of-markdown-content-using-built-in-renderer-for-visual-verification.cs) | `MarkdownSaveOptions` | Generate an HTML preview of the Markdown content using the built‑in renderer for visual ve... |
| [generate-index-markdown-file-linking-each-split-chapter-file-quick-access.cs](./generate-index-markdown-file-linking-each-split-chapter-file-quick-access.cs) | `MarkdownSaveOptions` | Generate an index Markdown file linking to each split chapter file for quick access. |
| [generate-json-representation-heading-hierarchy-external-analysis-integration.cs](./generate-json-representation-heading-hierarchy-external-analysis-integration.cs) |  | Generate a JSON representation of the heading hierarchy for external analysis or integrati... |
| [generate-report-summarizing-modifications-markdown-file-including-change-type-counts.cs](./generate-report-summarizing-modifications-markdown-file-including-change-type-counts.cs) | `MarkdownSaveOptions` | Generate a report summarizing all modifications made to a Markdown file, including counts ... |
| [generate-summary-paragraph-describing-document-length-and-main-topics.cs](./generate-summary-paragraph-describing-document-length-and-main-topics.cs) |  | Generate a summary paragraph that describes the document length and main topics. |
| [generate-table-of-contents-based-on-heading-hierarchy-insert-at-top.cs](./generate-table-of-contents-based-on-heading-hierarchy-insert-at-top.cs) |  | Generate a table of contents based on heading hierarchy and insert it at the top. |
| [generate-word-count-statistic-embed-comment-top-document.cs](./generate-word-count-statistic-embed-comment-top-document.cs) |  | Generate a word count statistic and embed it as a comment at the top of the document. |
| [highlight-code-block-syntax-assign-custom-css-class-node-property-modification.cs](./highlight-code-block-syntax-assign-custom-css-class-node-property-modification.cs) |  | Highlight code block syntax by assigning a custom CSS class through node property modifica... |
| [implement-lazy-loading-for-large-images-by-inserting-placeholder-syntax-before-actual-image-references.cs](./implement-lazy-loading-for-large-images-by-inserting-placeholder-syntax-before-actual-image-references.cs) | `ImageSaveOptions` | Implement lazy loading for large images by inserting placeholder syntax before actual imag... |
| [insert-checklist-items-task-list-syntax-set-initial-checked-state.cs](./insert-checklist-items-task-list-syntax-set-initial-checked-state.cs) |  | Insert checklist items using task list syntax and set their initial checked state. |
| [insert-copyright-notice-immediately-after-first-heading-assert-ownership.cs](./insert-copyright-notice-immediately-after-first-heading-assert-ownership.cs) |  | Insert a copyright notice immediately after the first heading to assert ownership. |
| [insert-footnote-definitions-at-end-of-document-for-each-referenced-footnote-marker.cs](./insert-footnote-definitions-at-end-of-document-for-each-referenced-footnote-marker.cs) |  | Insert footnote definitions at the end of the document for each referenced footnote marker... |
| [insert-generated-table-of-contents-after-front-matter-block-improve-navigation.cs](./insert-generated-table-of-contents-after-front-matter-block-improve-navigation.cs) |  | Insert a generated table of contents after the front‑matter block to improve navigation. |
| [insert-horizontal-rule-after-top-level-heading-separate-sections.cs](./insert-horizontal-rule-after-top-level-heading-separate-sections.cs) |  | Insert a horizontal rule after every top‑level heading to visually separate sections. |
| [insert-horizontal-rule-before-each-code-block-visually-separate-code-surrounding-text.cs](./insert-horizontal-rule-before-each-code-block-visually-separate-code-surrounding-text.cs) |  | Insert a horizontal rule before each code block to visually separate code from surrounding... |
| [insert-line-break-heading-text-improve-readability-narrow-screens.cs](./insert-line-break-heading-text-improve-readability-narrow-screens.cs) |  | Insert a line break within a long heading text to improve readability on narrow screens. |
| [insert-markdown-comment-before-each-heading-indicating-hierarchical-level-easier-navigation.cs](./insert-markdown-comment-before-each-heading-indicating-hierarchical-level-easier-navigation.cs) | `MarkdownSaveOptions` | Insert a Markdown comment before each heading indicating its hierarchical level for easier... |
| [insert-subheading-under-specified-parent-heading-using-markdownsyntaxfactory-create-nodes.cs](./insert-subheading-under-specified-parent-heading-using-markdownsyntaxfactory-create-nodes.cs) | `MarkdownSaveOptions` | Insert a subheading under a specified parent heading using the MarkdownSyntaxFactory to cr... |
| [insert-table-of-figures-generated-from-image-captions-after-table-of-contents.cs](./insert-table-of-figures-generated-from-image-captions-after-table-of-contents.cs) | `ImageSaveOptions` | Insert a table of figures generated from image captions and place it after the table of co... |
| [load-all-md-files-from-directory-parse-each-into-separate-syntax-trees.cs](./load-all-md-files-from-directory-parse-each-into-separate-syntax-trees.cs) |  | Load all .md files from a directory and parse each into separate syntax trees. |
| [load-previously-saved-xml-representation-syntax-tree-reconstruct-markdown-document.cs](./load-previously-saved-xml-representation-syntax-tree-reconstruct-markdown-document.cs) | `MarkdownSaveOptions` | Load a previously saved XML representation of a syntax tree and reconstruct the Markdown d... |
| [merge-consecutive-list-items-single-paragraph-simplify-list-presentation.cs](./merge-consecutive-list-items-single-paragraph-simplify-list-presentation.cs) |  | Merge consecutive list items into a single paragraph to simplify list presentation. |
| [merge-consecutive-paragraph-nodes-into-single-paragraph-to-reduce-unnecessary-breaks.cs](./merge-consecutive-paragraph-nodes-into-single-paragraph-to-reduce-unnecessary-breaks.cs) |  | Merge consecutive paragraph nodes into a single paragraph to reduce unnecessary breaks. |
| [merge-two-markdown-documents-preserving-heading-hierarchy-inserting-separator-comment.cs](./merge-two-markdown-documents-preserving-heading-hierarchy-inserting-separator-comment.cs) | `MarkdownSaveOptions` | Merge two Markdown documents while preserving heading hierarchy and inserting a separator ... |
| [normalize-all-line-endings-in-document-to-lf-characters-for-consistent-cross-platform-behavior.cs](./normalize-all-line-endings-in-document-to-lf-characters-for-consistent-cross-platform-behavior.cs) |  | Normalize all line endings in the document to LF characters for consistent cross‑platform ... |
| [optimize-image-markdown-width-attributes-rendering-performance-web-pages.cs](./optimize-image-markdown-width-attributes-rendering-performance-web-pages.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Optimize image markdown by adding width attributes to improve rendering performance on web... |
| [parse-single-markdown-file-into-markdown-syntax-tree.cs](./parse-single-markdown-file-into-markdown-syntax-tree.cs) | `MarkdownSaveOptions` | Parse a single Markdown file into a MarkdownSyntaxTree using the MarkdownParser class. |
| [prefix-each-heading-with-sequential-numeric-index-to-create-ordered-document-outline.cs](./prefix-each-heading-with-sequential-numeric-index-to-create-ordered-document-outline.cs) |  | Prefix each heading with a sequential numeric index to create an ordered document outline. |
| [prepend-note-to-all-blockquote-contents-to-highlight-important-information.cs](./prepend-note-to-all-blockquote-contents-to-highlight-important-information.cs) |  | Prepend the word “NOTE:” to all blockquote contents to highlight important information. |
| [remove-all-empty-paragraph-nodes-from-syntax-tree-to-clean-up-document-structure.cs](./remove-all-empty-paragraph-nodes-from-syntax-tree-to-clean-up-document-structure.cs) |  | Remove all empty paragraph nodes from the syntax tree to clean up the document structure. |
| [remove-blockquote-formatting-preserving-inner-text-flatten-document-structure.cs](./remove-blockquote-formatting-preserving-inner-text-flatten-document-structure.cs) |  | Remove blockquote formatting while preserving the inner text to flatten document structure... |
| [remove-duplicate-paragraph-nodes-eliminate-redundant-content-streamline-document.cs](./remove-duplicate-paragraph-nodes-eliminate-redundant-content-streamline-document.cs) |  | Remove duplicate paragraph nodes to eliminate redundant content and streamline the documen... |
| [remove-embedded-html-tags-markdown-content-ensure-pure-markdown-output.cs](./remove-embedded-html-tags-markdown-content-ensure-pure-markdown-output.cs) | `MarkdownSaveOptions` | Remove any embedded HTML tags from the Markdown content to ensure pure Markdown output. |
| [remove-empty-list-items-clean-up-list-structures-avoid-rendering-issues.cs](./remove-empty-list-items-clean-up-list-structures-avoid-rendering-issues.cs) |  | Remove all empty list items to clean up list structures and avoid rendering issues. |
| [remove-existing-yaml-front-matter-block-revert-document-plain-markdown.cs](./remove-existing-yaml-front-matter-block-revert-document-plain-markdown.cs) | `MarkdownSaveOptions` | Remove an existing YAML front‑matter block to revert the document to plain Markdown. |
| [remove-markdown-comments-from-document-produce-clean-version-without-annotations.cs](./remove-markdown-comments-from-document-produce-clean-version-without-annotations.cs) | `MarkdownSaveOptions` | Remove all Markdown comments from the document to produce a clean version without annotati... |
| [renumber-ordered-list-after-deleting-items-maintain-proper-numeric-ordering.cs](./renumber-ordered-list-after-deleting-items-maintain-proper-numeric-ordering.cs) |  | Renumber an ordered list after deleting items to maintain proper numeric ordering. |
| [reorder-list-items-alphabetically-based-on-text-values-and-update-syntax-tree.cs](./reorder-list-items-alphabetically-based-on-text-values-and-update-syntax-tree.cs) |  | Reorder list items alphabetically based on their text values and update the syntax tree. |
| [replace-all-em-dashes-with-double-hyphens-ensure-compatibility-plain-text-viewers.cs](./replace-all-em-dashes-with-double-hyphens-ensure-compatibility-plain-text-viewers.cs) |  | Replace all em dashes with double hyphens to ensure compatibility with plain‑text viewers. |
| [replace-content-first-paragraph-node-new-text-retaining-formatting.cs](./replace-content-first-paragraph-node-new-text-retaining-formatting.cs) |  | Replace the content of the first paragraph node with new text while retaining its formatti... |
| [replace-double-spaces-with-single-spaces-in-all-text-nodes-to-improve-readability.cs](./replace-double-spaces-with-single-spaces-in-all-text-nodes-to-improve-readability.cs) |  | Replace double spaces with single spaces in all text nodes to improve readability. |
| [replace-footnote-reference-markers-with-inline-explanatory-text-to-simplify-reading-for-users.cs](./replace-footnote-reference-markers-with-inline-explanatory-text-to-simplify-reading-for-users.cs) |  | Replace footnote reference markers with inline explanatory text to simplify reading for us... |
| [replace-image-urls-with-cdn-hosted-equivalents-to-improve-loading-performance-for-users.cs](./replace-image-urls-with-cdn-hosted-equivalents-to-improve-loading-performance-for-users.cs) | `ImageSaveOptions` | Replace existing image URLs with CDN-hosted equivalents to improve loading performance for... |
| [replace-inline-code-spans-emphasized-text-demonstrate-alternative-formatting-options.cs](./replace-inline-code-spans-emphasized-text-demonstrate-alternative-formatting-options.cs) |  | Replace inline code spans with emphasized text to demonstrate alternative formatting optio... |
| [replace-inline-html-tags-with-equivalent-markdown-syntax-maintain-pure-markdown-formatting.cs](./replace-inline-html-tags-with-equivalent-markdown-syntax-maintain-pure-markdown-formatting.cs) | `MarkdownSaveOptions` | Replace all inline HTML tags with equivalent Markdown syntax to maintain pure Markdown for... |
| [replace-markdown-image-syntax-html-img-tags-preserving-alt-text-source-attributes.cs](./replace-markdown-image-syntax-html-img-tags-preserving-alt-text-source-attributes.cs) | `ImageSaveOptions`, `MarkdownSaveOptions` | Replace Markdown image syntax with HTML img tags while preserving alt text and source attr... |
| [replace-markdown-tables-with-csv-code-fences-raw-data-format.cs](./replace-markdown-tables-with-csv-code-fences-raw-data-format.cs) | `MarkdownSaveOptions` | Replace all Markdown tables with CSV code fences to provide raw data format. |
| [save-generated-html-preview-to-temporary-file-for-automated-testing-workflows.cs](./save-generated-html-preview-to-temporary-file-for-automated-testing-workflows.cs) |  | Save the generated HTML preview to a temporary file for automated testing workflows. |
| [save-updated-markdown-document-original-encoding-line-ending-style.cs](./save-updated-markdown-document-original-encoding-line-ending-style.cs) | `MarkdownSaveOptions` | Save the updated Markdown document preserving the original file encoding and line ending s... |
| [serialize-modified-markdownsyntax-tree-to-string-with-custom-indentation.cs](./serialize-modified-markdownsyntax-tree-to-string-with-custom-indentation.cs) | `MarkdownSaveOptions` | Serialize the modified MarkdownSyntaxTree to a string with custom indentation for readabil... |
| [split-document-into-chapters-based-on-level-2-headings-save-each-as-separate-file.cs](./split-document-into-chapters-based-on-level-2-headings-save-each-as-separate-file.cs) |  | Split the document into chapters based on level‑2 headings and save each as a separate fil... |
| [split-long-paragraph-into-two-separate-nodes-at-nearest-sentence-boundary.cs](./split-long-paragraph-into-two-separate-nodes-at-nearest-sentence-boundary.cs) |  | Split a long paragraph into two separate nodes at the nearest sentence boundary. |
| [split-markdown-document-into-separate-files-per-top-level-heading-modular-sections.cs](./split-markdown-document-into-separate-files-per-top-level-heading-modular-sections.cs) | `MarkdownSaveOptions` | Split a Markdown document into separate files for each top‑level heading to create modular... |
| [toggle-checked-state-task-list-items-programmatically-reflect-completion-status.cs](./toggle-checked-state-task-list-items-programmatically-reflect-completion-status.cs) |  | Toggle the checked state of task list items programmatically to reflect completion status. |
| [trim-leading-trailing-whitespace-from-every-text-node-to-ensure-consistent-spacing.cs](./trim-leading-trailing-whitespace-from-every-text-node-to-ensure-consistent-spacing.cs) |  | Trim leading and trailing whitespace from every text node to ensure consistent spacing. |
| [trim-trailing-spaces-each-line-avoid-unnecessary-whitespace-final-output.cs](./trim-trailing-spaces-each-line-avoid-unnecessary-whitespace-final-output.cs) |  | Trim trailing spaces from each line to avoid unnecessary whitespace in the final output. |
| [update-atx-heading-text-preserving-original-hash-symbol-count.cs](./update-atx-heading-text-preserving-original-hash-symbol-count.cs) |  | Update the text of an ATX heading while preserving its original number of hash symbols. |
| [update-specific-yaml-front-matter-fields-title-date-programmatically.cs](./update-specific-yaml-front-matter-fields-title-date-programmatically.cs) |  | Update specific fields within the YAML front‑matter, such as title or date, programmatical... |
| [validate-document-contains-one-heading-structural-requirements.cs](./validate-document-contains-one-heading-structural-requirements.cs) |  | Validate that the document contains at least one heading to meet structural requirements. |
| [validate-document-no-raw-html-tags-strict-markdown-compliance.cs](./validate-document-no-raw-html-tags-strict-markdown-compliance.cs) | `MarkdownSaveOptions` | Validate that the document does not contain any raw HTML tags to ensure strict Markdown co... |
| [validate-every-footnote-definition-referenced-somewhere-in-document-avoid-orphaned-notes.cs](./validate-every-footnote-definition-referenced-somewhere-in-document-avoid-orphaned-notes.cs) |  | Validate that every footnote definition is referenced somewhere in the document to avoid o... |
| [validate-every-url-document-uses-https-scheme-secure-connections.cs](./validate-every-url-document-uses-https-scheme-secure-connections.cs) | `Url` | Validate that every URL in the document uses the HTTPS scheme for secure connections. |
| [validate-heading-levels-follow-logical-hierarchy-without-skipping-intermediate-levels.cs](./validate-heading-levels-follow-logical-hierarchy-without-skipping-intermediate-levels.cs) |  | Validate that heading levels follow a logical hierarchy without skipping intermediate leve... |
| [validate-no-heading-exceeds-six-hash-characters-ensuring-markdown-specification-compliance.cs](./validate-no-heading-exceeds-six-hash-characters-ensuring-markdown-specification-compliance.cs) | `MarkdownSaveOptions` | Validate that no heading exceeds six hash characters, ensuring compliance with Markdown sp... |
| [validate-no-paragraph-exceeds-two-hundred-words-maintain-concise-content-standards.cs](./validate-no-paragraph-exceeds-two-hundred-words-maintain-concise-content-standards.cs) |  | Validate that no paragraph exceeds two hundred words to maintain concise content standards... |
| [validate-ordered-list-numbers-sequential-correct-gaps-after-item-removal.cs](./validate-ordered-list-numbers-sequential-correct-gaps-after-item-removal.cs) |  | Validate that ordered list numbers are sequential and correct any gaps after item removal. |
| [validate-required-fields-title-author-exist-yaml-front-matter-block.cs](./validate-required-fields-title-author-exist-yaml-front-matter-block.cs) |  | Validate that required fields like title and author exist in the YAML front‑matter block. |
| [verify-all-code-blocks-fenced-with-backticks-and-correct-any-using-indentation.cs](./verify-all-code-blocks-fenced-with-backticks-and-correct-any-using-indentation.cs) |  | Verify that all code blocks are fenced with backticks and correct any that use indentation... |

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
Updated: 2026-10-02 | Examples: 120
<!-- AUTOGENERATED:END -->
