---
name: working_with_html_templates
description: C# examples for working_with_html_templates using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – working_with_html_templates

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **working_with_html_templates** category.
This folder contains standalone C# examples for working_with_html_templates operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: `working_with_html_templates`  
- **Total examples**: 45  
- **Typical workflow**:  
  1. **Load** an HTML template (file, string, or stream) using `TemplateLoadOptions` if needed.  
  2. **Bind** data to the template through a `TemplateData` object (JSON, XML, CSV, etc.).  
  3. **Convert** the populated template to a final HTML document with `Converter.ConvertTemplate`.  
  4. **Render** the result to an image or PDF (optional) using the rendering APIs.

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | 45 |
| Aspose.Html | 36 |
| Aspose.Html.Converters | 27 |
| Aspose.Html.Loading | 26 |
| Aspose.Html.Dom | 13 |
| System.IO | 10 |
| System.Collections.Generic | 8 |
| System.Text.Json | 5 |
| Aspose.Html.Rendering.Image | 5 |
| System.Xml.Linq | 4 |
| Aspose.Html.Collections | 4 |
| Aspose.Html.Saving | 3 |
| System.Linq | 3 |
| Aspose.Html.Dom.XPath | 2 |
| Aspose.Html.Net | 1 |
| Aspose.Html.Services | 1 |
| System.Text | 1 |
| Aspose.Html.Drawing | 1 |
| System.Drawing | 1 |
| Aspose.Html.Forms | 1 |
| System.Globalization | 1 |

### How to import them

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using System.Drawing;
using System.Globalization;

using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Collections;
using Aspose.Html.Saving;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Drawing;
using Aspose.Html.Forms;
```

---

## Common Code Pattern

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        // 1️⃣ Load the HTML template (can be a file, string or stream)
        var loadOptions = new TemplateLoadOptions
        {
            // Example: enable external CSS, set base URL, etc.
            EnableExternalResources = true,
            BaseUrl = new Uri("file:///C:/Templates/")
        };
        var templatePath = @"C:\Templates\InvoiceTemplate.html";

        // 2️⃣ Prepare data to bind (JSON, XML, CSV …)
        var json = File.ReadAllText(@"C:\Data\invoice.json");
        var data = new TemplateData(json);   // JSON string → TemplateData

        // 3️⃣ Convert the populated template to a final HTML document
        var result = Converter.ConvertTemplate(templatePath, data, loadOptions);

        // 4️⃣ (Optional) Render the HTML to PNG for preview
        var renderOptions = new ImageRenderingOptions
        {
            Width = 1024,
            Height = 768,
            BackgroundColor = System.Drawing.Color.White
        };
        result.RenderTo("InvoicePreview.png", renderOptions);

        // 5️⃣ Save the final HTML if needed
        result.Save("InvoiceFinal.html");

        Console.WriteLine("Template processing completed successfully.");
    }
}
```

---

## Frequently Used APIs

| API | Appearances |
|-----|--------------|
| Console.WriteLine | 45 |
| Aspose.Html | 45 |
| HTMLDocument | 28 |
| TemplateData | 26 |
| Converter.ConvertTemplate | 26 |
| TemplateLoadOptions | 26 |
| System.IO | 11 |
| System.Collections | 8 |
| File.ReadAllText | 8 |
| Configuration | 7 |
| System.Text | 6 |
| Rendering.Image | 5 |
| System.Xml | 4 |
| XDocument.Load | 4 |
| JsonSerializer.Deserialize | 4 |
| Document.Save | 4 |
| ImageRenderingOptions | 4 |
| ImageDevice | 4 |
| TemplateContent.XML | 3 |
| TemplateContentOptions | 3 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [apply_attribute_binding_set_href_attribute_anchor_tags_from_xml_link_data.cs](./apply_attribute_binding_set_href_attribute_anchor_tags_from_xml_link_data.cs) | Apply Attribute Binding – Set Href on Anchor Tags from XML | System.Collections, Console.WriteLine, System.Xml | Binds XML link data to `<a>` elements and updates their `href` attributes. |
| [apply_attribute_binding_set_src_attribute_img_tag_from_json_image_urls.cs](./apply_attribute_binding_set_src_attribute_img_tag_from_json_image_urls.cs) | Apply Attribute Binding – Set Src on Img Tags from JSON | System.Collections, Console.WriteLine, System.IO | Reads a JSON array of image URLs and assigns them to `<img>` `src` attributes. |
| [apply_templateloadoptions_enable_loading_html_templates_with_external_css_references_for_styling.cs](./apply_templateloadoptions_enable_loading_html_templates_with_external_css_references_for_styling.cs) | Enable Loading HTML Templates with External CSS | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Demonstrates how `TemplateLoadOptions` can load external CSS while converting a template. |
| [apply_templateloadoptions_enable_loading_templates_from_network_share_with_authentication.cs](./apply_templateloadoptions_enable_loading_templates_from_network_share_with_authentication.cs) | Load Templates from Network Share with Authentication | Configuration, TemplateData, Document.Save | Shows how to configure credentials to access a template stored on a secured network share. |
| [combine_xml_data_inline_expressions_product_catalog_html_page.cs](./combine_xml_data_inline_expressions_product_catalog_html_page.cs) | Combine XML Data & Inline Expressions – Product Catalog | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Merges hierarchical XML product data with inline expressions to generate a catalog page. |
| [configure_templateloadoptions_ignore_script_tags_template_loading_security.cs](./configure_templateloadoptions_ignore_script_tags_template_loading_security.cs) | Ignore Script Tags During Template Loading (Security) | Configuration, Console.WriteLine, DocumentElement.OuterHTML | Uses sandbox settings to strip `<script>` tags for safer template processing. |
| [control_css_class_attribute_binding_value_json_data_source.cs](./control_css_class_attribute_binding_value_json_data_source.cs) | Control CSS Class Binding from JSON Data Source | System.Collections, Console.WriteLine, System.IO | Dynamically assigns CSS classes to elements based on JSON‑driven conditions. |
| [control_visibility_div_element_binding_style_attribute_data_value.cs](./control_visibility_div_element_binding_style_attribute_data_value.cs) | Control Visibility of DIV via Style Binding | Console.WriteLine, Aspose.Html, HTMLDocument | Toggles `display:none` on a `<div>` according to a data flag. |
| [convert_populated_html_template_to_final_html_document_using_convert_template_method.cs](./convert_populated_html_template_to_final_html_document_using_convert_template_method.cs) | Convert Populated HTML Template to Final Document | Configuration, TemplateData, Converter.ConvertTemplate | Full end‑to‑end conversion of a data‑filled template to a ready‑to‑use HTML file. |
| [convert_template_conditional_attribute_binding_readonly_fields_data_flags.cs](./convert_template_conditional_attribute_binding_readonly_fields_data_flags.cs) | Conditional Attribute Binding – Read‑Only Fields | TemplateData, Doc.GetElementsByTagName, Converter.ConvertTemplate | Sets `readonly` on form inputs when a corresponding data flag is true. |
| [convert_template_with_embedded_svg_graphics_to_html_and_render_to_png_preserving_vector_quality.cs](./convert_template_with_embedded_svg_graphics_to_html_and_render_to_png_preserving_vector_quality.cs) | Convert Template with Embedded SVG → PNG (Vector Quality) | Console.WriteLine, AppDomain.CurrentDomain, Converter.ConvertHTML, ImageSaveOptions | Renders an HTML template containing SVG graphics to a high‑quality PNG. |
| [convert_template_with_foreach_loop_to_html_table_dynamic_rows.cs](./convert_template_with_foreach_loop_to_html_table_dynamic_rows.cs) | Foreach Loop – Generate Dynamic Table Rows | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Uses a `foreach` directive in the template to repeat table rows for each data item. |
| [create_html_template_dynamically_string_variable_markup_data_binding_expressions.cs](./create_html_template_dynamically_string_variable_markup_data_binding_expressions.cs) | Create HTML Template Dynamically with Data‑Binding Expressions | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Builds a template string at runtime and binds data using double‑curly‑brace expressions. |
| [create_reusable_html_email_template_populate_user_data_from_xml.cs](./create_reusable_html_email_template_populate_user_data_from_xml.cs) | Reusable HTML Email Template – Populate from XML | Configuration, TemplateData, Converter.ConvertTemplate | Generates personalized email bodies by binding XML user records to a single template. |
| [create_templatedata_object_from_json_file_and_bind_to_html_template.cs](./create_templatedata_object_from_json_file_and_bind_to_html_template.cs) | Create TemplateData from JSON File and Bind | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Reads a JSON file, creates a `TemplateData` instance, and applies it to an HTML template. |
| [create_template_binds_data_driven_title_attribute_display_tooltips_hover.cs](./create_template_binds_data_driven_title_attribute_display_tooltips_hover.cs) | Data‑Driven `title` Attribute for Tooltips | File.WriteAllText, TemplateData, Converter.ConvertTemplate | Generates `title` attributes on elements to show context‑sensitive tooltips. |
| [create_template_from_string_including_meta_tag_with_dynamic_description_content.cs](./create_template_from_string_including_meta_tag_with_dynamic_description_content.cs) | Template from String – Dynamic Meta Description | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Shows how to embed a meta description that changes per data set. |
| [create_template_string_with_conditional_class_attribute_based_on_user_role.cs](./create_template_string_with_conditional_class_attribute_based_on_user_role.cs) | Conditional Class Attribute Based on User Role | TemplateData, TemplateContent.XML, Document.Save | Applies different CSS classes to elements depending on the logged‑in user’s role. |
| [define_inline_double_curly_brace_expressions_in_template_to_insert_first_name_values.cs](./define_inline_double_curly_brace_expressions_in_template_to_insert_first_name_values.cs) | Inline Double‑Curly‑Brace Expressions – First Name | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Inserts a user’s first name into the template using `{{FirstName}}`. |
| [foreach_expression_generate_list_items_from_json_array_navigation_links.cs](./foreach_expression_generate_list_items_from_json_array_navigation_links.cs) | Foreach Expression – Generate Navigation List from JSON | System.Collections, Body.AppendChild, Console.WriteLine | Loops through a JSON array to create `<li>` navigation items. |
| [generate_localized_html_page_binding_language_specific_strings_from_xml_resource_file.cs](./generate_localized_html_page_binding_language_specific_strings_from_xml_resource_file.cs) | Localized HTML Page – Bind Language Strings from XML | System.Linq, Encoding.UTF8, HTMLDocument, Element.TextContent | Loads language‑specific strings from an XML resource and injects them into the page. |
| [generate_png_preview_converting_template_html_rendering_result_image.cs](./generate_png_preview_converting_template_html_rendering_result_image.cs) | Generate PNG Preview from Template Rendering | System.Linq, TemplateData, ImageRenderingOptions, Document.RenderTo | Converts a populated template to a PNG preview image for quick visual checks. |
| [include_conditional_attribute_expression_hide_element_when_data_flag_false.cs](./include_conditional_attribute_expression_hide_element_when_data_flag_false.cs) | Conditional Attribute – Hide Element When Flag Is False | Console.WriteLine, Aspose.Html, HTMLDocument | Uses a conditional expression to add `style="display:none"` when a data flag is false. |
| [instantiate_templateloadoptions_specify_custom_encoding_before_loading_html_template_file.cs](./instantiate_templateloadoptions_specify_custom_encoding_before_loading_html_template_file.cs) | Specify Custom Encoding via TemplateLoadOptions | TemplateData, Converter.ConvertTemplate, Console.WriteLine | Demonstrates loading a UTF‑8 encoded template file with explicit encoding settings. |
| [load_html_template_file_from_disk_and_populate_using_xml_data_source.cs](./load_html_template_file_from_disk_and_populate_using_xml_data_source.cs) | Load Template from Disk & Populate with XML | Configuration, TemplateData, Converter.ConvertTemplate | Reads an HTML file from disk, binds XML data, and produces the final document. |
| [load_template_custom_base_url_templateloadoptions_resolve_relative_links.cs](./load_template_custom_base_url_templateloadoptions_resolve_relative_links.cs) | Custom Base URL – Resolve Relative Links | TemplateData, Uri, Converter.ConvertTemplate, Console.WriteLine | Sets a custom base URL so that relative image/script links resolve correctly. |
| [perform_one_line_template_conversion_with_source_path_data_and_output_path.cs](./perform_one_line_template_conversion_with_source_path_data_and_output_path.cs) | One‑Line Template Conversion (Path‑Based) | Configuration, TemplateData, Converter.ConvertTemplate, Console.WriteLine | Shows the most compact form of converting a template using file paths only. |
| [populate_template_hierarchical_xml_data_produce_nested_unordered_lists_html.cs](./populate_template_hierarchical_xml_data_produce_nested_unordered_lists_html.cs) | Hierarchical XML → Nested `<ul>` Lists | Configuration, TemplateData, Converter.ConvertTemplate, Console.WriteLine | Transforms a multi‑level XML structure into nested unordered lists. |
| [populate_template_nested_json_objects_display_property_values_using_dot_notation.cs](./populate_template_nested_json_objects_display_property_values_using_dot_notation.cs) | Dot‑Notation Binding for Nested JSON Objects | TemplateData, Converter.ConvertTemplate, Console.WriteLine, System.IO | Accesses deep JSON properties using `Parent.Child.Property` syntax inside the template. |
| [populate_template_with_csv_data_converted_to_json_and_display_in_html_table.cs](./populate_template_with_csv_data_converted_to_json_and_display_in_html_table.cs) | CSV → JSON → HTML Table | File.WriteAllText, System.Collections, Encoding.UTF8, TemplateData, Converter.ConvertTemplate | Converts CSV rows to JSON, then binds them to a table in the template. |
| [populate_template_with_user_profile_json_and_generate_personalized_dashboard_html_page.cs](./populate_template_with_user_profile_json_and_generate_personalized_dashboard_html_page.cs) | Personalized Dashboard from User Profile JSON | TemplateData, Converter.ConvertTemplate, Console.WriteLine, TemplateLoadOptions | Generates a dashboard page where widgets are shown/hidden based on user profile data. |
| [render_converted_html_document_to_png_with_specified_image_width_and_height.cs](./render_converted_html_document_to_png_with_specified_image_width_and_height.cs) | Render HTML → PNG with Fixed Dimensions | ImageRenderingOptions, HTMLDocument, Console.WriteLine, ImageFormat.Png, Page | Renders the final HTML to a PNG image of exact width/height. |
| [render_converted_html_to_png_with_specific_dpi_setting_for_high_resolution_output.cs](./render_converted_html_to_png_with_specific_dpi_setting_for_high_resolution_output.cs) | High‑Resolution PNG Rendering (DPI) | Uri, Converters.Converter, Console.WriteLine, System.IO, ImageFormat.Png | Sets DPI on the rendering options to produce a high‑resolution PNG. |
| [render_final_html_to_png_transparent_background_options.cs](./render_final_html_to_png_transparent_background_options.cs) | PNG Rendering with Transparent Background | HTMLDocument, ImageRenderingOptions, System.Drawing, Console.WriteLine, Color.Transparent | Demonstrates how to output a PNG with an alpha channel (transparent background). |
| [render_resulting_html_document_to_png_image_using_renderto_method.cs](./render_resulting_html_document_to_png_image_using_renderto_method.cs) | Render HTML → PNG Using `RenderTo` | ImageRenderingOptions, Rendering.Image, Console.WriteLine, ImageDevice, Aspose.Html | Uses the `RenderTo` method to write the rendered image directly to a file. |
| [set_checked_attribute_checkbox_conditionally_based_boolean_value_data_source.cs](./set_checked_attribute_checkbox_conditionally_based_boolean_value_data_source.cs) | Conditional `checked` Attribute on Checkboxes | TemplateData, TemplateContent.XML, Document.Save, Converter.ConvertTemplate, Console.WriteLine | Checks a box when the bound boolean value is true. |
| [set_disabled_attribute_on_form_inputs_conditionally_based_on_xml_data.cs](./set_disabled_attribute_on_form_inputs_conditionally_based_on_xml_data.cs) | Conditional `disabled` on Form Inputs from XML | System.Linq, HTMLDocument, Console.WriteLine, System.IO, System.Xml | Disables input fields according to flags defined in an XML configuration. |
| [set_maxlength_attribute_input_field_dynamically_from_xml_configuration_values.cs](./set_maxlength_attribute_input_field_dynamically_from_xml_configuration_values.cs) | Dynamic `maxlength` from XML Config | HTMLDocument, Console.WriteLine, System.Xml, Element.SetAttribute, XDocument.Load | Reads max length values from XML and applies them to `<input>` elements. |
| [set_selected_attribute_on_option_elements_based_on_matching_values_xml_data_source.cs](./set_selected_attribute_on_option_elements_based_on_matching_values_xml_data_source.cs) | Set `selected` on `<option>` Based on XML Data | HTMLDocument, System.Collections, Doc.GetElementsByTagName, Console.WriteLine, Set.Contains | Marks the correct `<option>` as selected by matching XML values. |
| [single_line_code_convert_template_string_to_html_file.cs](./single_line_code_convert_template_string_to_html_file.cs) | One‑Liner: Convert Template String → HTML File | TemplateData, Converter.ConvertTemplate, Console.WriteLine, TemplateLoadOptions, Aspose.Html | Shows the minimal code required to turn a template string into a saved HTML file. |
| [use_foreach_directive_repeat_table_row_each_item.cs](./use_foreach_directive_repeat_table_row_each_item.cs) | `foreach` Directive – Repeat Table Row per Item | Cells.Length, System.Collections, Rows.Length, Console.WriteLine, Aspose.Html | Demonstrates the built‑in `foreach` directive for table row repetition. |
| [use_foreach_loop_generate_table_rows_each_json_record.cs](./use_foreach_loop_generate_table_rows_each_json_record.cs) | Generate Table Rows from JSON Records | System.Collections, Body.AppendChild, Console.WriteLine, System.IO, JsonSerializer.Deserialize | Reads a JSON array and creates a table row for each record. |
| [use_inline_expressions_calculate_display_total_price_json_line_item_values.cs](./use_inline_expressions_calculate_display_total_price_json_line_item_values.cs) | Inline Expression – Calculate Total Price | CultureInfo.InvariantCulture, Console.WriteLine, System.IO, NumberStyles.Any, File.ReadAllText | Calculates and displays a total price using inline arithmetic on JSON line‑item values. |
| [use_inline_expressions_format_dates_json_data_html_template.cs](./use_inline_expressions_format_dates_json_data_html_template.cs) | Inline Date Formatting from JSON | TemplateData, Converter.ConvertTemplate, Console.WriteLine, TemplateLoadOptions, Aspose.Html | Formats dates inside the template using a custom format string. |
| [use_templatedata_bind_product_list_from_json_generate_repeating_product_card_layout.cs](./use_templatedata_bind_product_list_from_json_generate_repeating_product_card_layout.cs) | Bind Product List from JSON → Repeating Card Layout | TemplateData, Converter.ConvertTemplate, Console.WriteLine, TemplateLoadOptions, Aspose.Html | Generates a grid of product cards by binding a JSON product array. |

---

## Category‑Specific Tips

### Key API Surface
- **TemplateData** – central object for JSON, XML, CSV, or custom data sources.  
- **Converter.ConvertTemplate** – one‑stop conversion from template + data → final HTML.  
- **TemplateLoadOptions** – control external resources, base URL, encoding, security sandbox.  
- **HTMLDocument** – DOM manipulation after conversion (e.g., further tweaks, scripting).  
- **ImageRenderingOptions / Rendering.Image** – for PNG/PDF previews.

### Rules
1. **Always pair a `TemplateData` instance with a matching template** – mismatched placeholders cause silent omissions.  
2. **Prefer `TemplateLoadOptions` for external CSS/JS**; otherwise resources are ignored.  
3. **Use absolute or base‑URL‑resolved paths** when templates reference images or stylesheets.  
4. **Validate JSON/XML before creating `TemplateData`** to avoid runtime binding errors.  
5. **Dispose rendered `HTMLDocument` objects** (or wrap in `using`) to free native resources, especially when rendering large pages.  

---

## Warnings

- **Binding Mismatch** – If a placeholder in the template has no corresponding key in `TemplateData`, the expression is left untouched, leading to broken UI.  
- **Missing External Resources** – Templates that reference CSS/JS files not reachable (network share, wrong base URL) will render without styling or scripts.  
- **File‑Path Issues** – Relative paths are resolved against `TemplateLoadOptions.BaseUrl`; an incorrect base URL results in 404‑like missing images.  
- **Memory Consumption During Rendering** – Rendering high‑resolution PNGs or large HTML documents can exhaust memory; monitor and limit image dimensions/DPI.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – The example must compile and run without external project references.  
2. **Console Logging** – Use `Console.WriteLine` to output key steps and results.  
3. **Follow the Standard Flow** – Load → Bind → Convert → (optional) Render → Save.  
4. **Naming Convention** – File name in *PascalCase* describing the operation, prefixed with the category action (e.g., `convert_template_...`).  
5. **Update Statistics** – After adding a file, increment `total_examples` and adjust namespace/API counts accordingly.  

---