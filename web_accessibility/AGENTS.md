---
name: web_accessibility
description: C# examples for web_accessibility using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – web_accessibility

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **web_accessibility** category.
This folder contains standalone C# examples for web_accessibility operations.
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

---

## Scope

- **Category name**: web_accessibility  
- **Total examples**: 96  
- **Typical workflow**:  
  1. **Load** an HTML document (from file, string, or stream).  
  2. **Bind** data or configure the `AccessibilityValidator`.  
  3. **Convert** the document by running the accessibility validation (`Validate`, `ValidateAsync`).  
  4. **Render** results – write to console, save as JSON/XML, or embed in reports.

---

## Required Namespaces

| Namespace | Usage |
|-----------|-------|
| System | Used in 96 examples |
| Aspose.Html | Used in 83 examples |
| Aspose.Html.Accessibility | Used in 77 examples |
| Aspose.Html.Accessibility.Results | Used in 70 examples |
| System.IO | Used in 29 examples |
| Aspose.Html.Dom | Used in 13 examples |
| Aspose.Html.Accessibility.Saving | Used in 13 examples |
| System.Collections.Generic | Used in 11 examples |
| Aspose.Html.Collections | Used in 5 examples |
| System.Text.Json | Used in 5 examples |
| System.Threading.Tasks | Used in 3 examples |
| System.Text | Used in 3 examples |
| Aspose.Html.Saving | Used in 2 examples |
| System.Linq | Used in 2 examples |
| Aspose.Html.Converters | Used in 2 examples |
| System.Threading | Used in 1 example |
| System.Net | Used in 1 example |
| System.Net.Mail | Used in 1 example |
| Aspose.Html.Net | Used in 1 example |
| Aspose.Html.Services | Used in 1 example |
| Aspose.Html.Rendering.Image | Used in 1 example |
| System.Drawing | Used in 1 example |
| System.Diagnostics | Used in 1 example |
| System.Net.Sockets | Used in 1 example |
| Aspose.Html.Loading | Used in 1 example |
| System.Net.Http | Used in 1 example |

### How to import them

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.Http;
using System.Diagnostics;
using System.Drawing;

using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;
using Aspose.Html.Collections;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Services;
using Aspose.Html.Net;
using Aspose.Html.Loading;
```

---

## Common Code Pattern

```csharp
using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class WebAccessibilityExample
{
    static void Main()
    {
        // 1️⃣ Load the HTML document
        var htmlPath = @"C:\Samples\sample.html";
        using var document = new HTMLDocument(htmlPath);

        // 2️⃣ Create and configure the validator
        var validator = AccessibilityValidator.CreateValidator();
        // (optional) customize rule set, severity thresholds, etc.

        // 3️⃣ Run validation
        ValidationResult result = validator.Validate(document);

        // 4️⃣ Render the outcome
        Console.WriteLine($"Success: {result.Success}");
        Console.WriteLine($"Errors  : {result.Errors.Count}");
        Console.WriteLine($"Warnings: {result.Warnings.Count}");

        // Save a formatted report (JSON)
        string jsonReport = result.SaveToString(AccessibilitySavingFormat.Json);
        File.WriteAllText("validation-report.json", jsonReport);
    }
}
```

*The pattern above is the backbone of every example in this folder – load a document, invoke the validator, and output the findings.*

---

## Frequently Used APIs

| API | Appearances |
|-----|--------------|
| Aspose.Html | 94 |
| Console.WriteLine | 91 |
| Accessibility.Results | 78 |
| HTMLDocument | 72 |
| WebAccessibility | 63 |
| Accessibility.CreateValidator | 58 |
| Result.Details | 48 |
| Result.Success | 46 |
| ValidationBuilder.All | 33 |
| Result.Error | 32 |
| System.IO | 31 |
| Result.Errors | 29 |
| Accessibility.ValidationBuilder | 21 |
| Accessibility.WebAccessibility | 18 |
| Accessibility.AccessibilityValidator | 16 |
| Target.TargetType | 13 |
| File.WriteAllText | 13 |
| Rule.Code | 13 |
| Accessibility.Saving | 13 |
| Result.SaveTo | 13 |

---

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [Access_Validationresult_Errors_Collection_Count_Total_Accessibility_Errors_Document](./access_validationresult_errors_collection_count_total_accessibility_errors_document.cs) | Access_Validationresult_Errors_Collection_Count_Total_Accessibility_Errors_Document | Errors.Count, HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Access_Validationresult_Warnings_Collection_Count_Total_Accessibility_Warnings_Html_Page](./access_validationresult_warnings_collection_count_total_accessibility_warnings_html_page.cs) | Access_Validationresult_Warnings_Collection_Count_Total_Accessibility_Warnings_Html_Page | Console.WriteLine, ValidationResult.Warnings, Result.Details, Accessibility.WebAccessibility, Accessibility.ValidationBuilder | Creates or manipulates an HTML document. |
| [Add_Missing_Track_Element_With_Kind_Captions_And_Src_To_Video_Programmatically](./add_missing_track_element_with_kind_captions_and_src_to_video_programmatically.cs) | Add_Missing_Track_Element_With_Kind_Captions_And_Src_To_Video_Programmatically | HTMLSaveOptions, Console.WriteLine, StringComparison.OrdinalIgnoreCase, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Apply_Cancellation_Token_To_Validation_Process_For_Graceful_Termination_During_Long_Batch_Runs](./apply_cancellation_token_to_validation_process_for_graceful_termination_during_long_batch_runs.cs) | Apply_Cancellation_Token_To_Validation_Process_For_Graceful_Termination_During_Long_Batch_Runs | WebAccessibility, Console.WriteLine, System.Threading, Accessibility.Results, TimeSpan.FromSeconds | Creates or manipulates an HTML document. |
| [Call_Validationresult_Savetostring_Obtain_Formatted_String_Errors_Warnings](./call_validationresult_savetostring_obtain_formatted_string_errors_warnings.cs) | Call_Validationresult_Savetostring_Obtain_Formatted_String_Errors_Warnings | Result.SaveToString, ValidationResult.SaveToString, WebAccessibility, Console.WriteLine, Accessibility.Results | Creates or manipulates an HTML document. |
| [Check_Missing_Track_Elements_Kind_Captions_In_Video_Tags_Using_Validation_Report](./check_missing_track_elements_kind_captions_in_video_tags_using_validation_report.cs) | Check_Missing_Track_Elements_Kind_Captions_In_Video_Tags_Using_Validation_Report | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Combine_Validation_Findings_With_Seo_Metrics_Identify_Pages_With_Accessibility_And_Ranking_Issues](./combine_validation_findings_with_seo_metrics_identify_pages_with_accessibility_and_ranking_issues.cs) | Combine_Validation_Findings_With_Seo_Metrics_Identify_Pages_With_Accessibility_And_Ranking_Issues | HTMLDocument, System.Collections, File.WriteAllText, Result.ToString, Result.Success | Creates or manipulates an HTML document. |
| [Compare_Two_Validationresult_Objects_Detect_Regressions_Modifying_Html_Content_Same_Project](./compare_two_validationresult_objects_detect_regressions_modifying_html_content_same_project.cs) | Compare_Two_Validationresult_Objects_Detect_Regressions_Modifying_Html_Content_Same_Project | Accessibility.Results, Failures.Contains, Failures.Add, Result.Details, Result.Error | Creates or manipulates an HTML document. |
| [Configure_Accessibilityvalidator_With_Custom_Settings_Before_Validating_Html_Document_In_Application](./configure_accessibilityvalidator_with_custom_settings_before_validating_html_document_in_application.cs) | Configure_Accessibilityvalidator_With_Custom_Settings_Before_Validating_Html_Document_In_Application | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.Results | Creates or manipulates an HTML document. |
| [Configure_Validator_Ignore_Selected_Rule_Codes_Allowing_Custom_Compliance_Thresholds_During_Checks](./configure_validator_ignore_selected_rule_codes_allowing_custom_compliance_thresholds_during_checks.cs) | Configure_Validator_Ignore_Selected_Rule_Codes_Allowing_Custom_Compliance_Thresholds_During_Checks | HTMLDocument, System.Collections, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Configure_Validator_Static_Rule_Repository_Consistent_Rule_Application_Across_Runs](./configure_validator_static_rule_repository_consistent_rule_application_across_runs.cs) | Configure_Validator_Static_Rule_Repository_Consistent_Rule_Application_Across_Runs | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Configure_Validator_Treat_Caption_Missing_Warnings_Errors_Adjust_Severity_Settings](./configure_validator_treat_caption_missing_warnings_errors_adjust_severity_settings.cs) | Configure_Validator_Treat_Caption_Missing_Warnings_Errors_Adjust_Severity_Settings | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Create_Custom_Rule_Subset_Selecting_Specific_Wcag_Criteria_From_Accessibilityrules_Before_Validation](./create_custom_rule_subset_selecting_specific_wcag_criteria_from_accessibilityrules_before_validation.cs) | Create_Custom_Rule_Subset_Selecting_Specific_Wcag_Criteria_From_Accessibilityrules_Before_Validation | System.Collections, Accessibility.Rules, Result.Success, Console.WriteLine, Accessibility.Guideline | Creates or manipulates an HTML document. |
| [Create_Powershell_Script_Loads_Dotnet_Library_Validates_Html_File_Prints_Json_Results](./create_powershell_script_loads_dotnet_library_validates_html_file_prints_json_results.cs) | Create_Powershell_Script_Loads_Dotnet_Library_Validates_Html_File_Prints_Json_Results | HTMLDocument, System.Collections, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Create_Static_Accessibilityvalidator_Instance_Reuse_To_Validate_Multiple_Html_Files_Efficiently](./create_static_accessibilityvalidator_instance_reuse_to_validate_multiple_html_files_efficiently.cs) | Create_Static_Accessibilityvalidator_Instance_Reuse_To_Validate_Multiple_Html_Files_Efficiently | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Create_Validator_Instance_Before_Loading_Html_Document_For_Accessibility](./create_validator_instance_before_loading_html_document_for_accessibility.cs) | Create_Validator_Instance_Before_Loading_Html_Document_For_Accessibility | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.Results | Creates or manipulates an HTML document. |
| [Detect_Absent_Caption_Files_Referenced_In_Track_Elements_And_Log_File_Paths](./detect_absent_caption_files_referenced_in_track_elements_and_log_file_paths.cs) | Detect_Absent_Caption_Files_Referenced_In_Track_Elements_And_Log_File_Paths | File.AppendAllText, Console.WriteLine, System.IO, File.Exists, Environment.NewLine | Creates or manipulates an HTML document. |
| [Develop_Command_Line_Tool_Accepting_Input_Path_And_Output_Format_Arguments_To_Perform_Validation_On_Demand](./develop_command_line_tool_accepting_input_path_and_output_format_arguments_to_perform_validation_on_demand.cs) | Develop_Command_Line_Tool_Accepting_Input_Path_And_Output_Format_Arguments_To_Perform_Validation_On_Demand | Result.SaveToString, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Embed_Validation_Results_String_Into_Email_Body_Notify_Stakeholders_Accessibility_Status](./embed_validation_results_string_into_email_body_notify_stakeholders_accessibility_status.cs) | Embed_Validation_Results_String_Into_Email_Body_Notify_Stakeholders_Accessibility_Status | MailMessage, HTMLDocument, Result.SaveToString, NetworkCredential, WebAccessibility | Creates or manipulates an HTML document. |
| [Embed_Vtt_Caption_File_Into_Html_Document_And_Reference_With_New_Track_Element](./embed_vtt_caption_file_into_html_document_and_reference_with_new_track_element.cs) | Embed_Vtt_Caption_File_Into_Html_Document_And_Reference_With_New_Track_Element | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Ensure_Caption_Tracks_Contain_Synchronized_Timestamps_Matching_Associated_Media_Timeline](./ensure_caption_tracks_contain_synchronized_timestamps_matching_associated_media_timeline.cs) | Ensure_Caption_Tracks_Contain_Synchronized_Timestamps_Matching_Associated_Media_Timeline | TagName.Equals, Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase, Path.GetFileNameWithoutExtension | Creates or manipulates an HTML document. |
| [Exclude_Keyboard_Navigation_Warnings_From_Final_Report_Using_Result_Filtering_Option](./exclude_keyboard_navigation_warnings_from_final_report_using_result_filtering_option.cs) | Exclude_Keyboard_Navigation_Warnings_From_Final_Report_Using_Result_Filtering_Option | ErrorMessage.IndexOf, Result.Rule, Result.Success, Result.Error, HTMLDocument | Creates or manipulates an HTML document. |
| [Execute_Validate_Method_Assess_Multimedia_Accessibility_Loaded_Html_Document](./execute_validate_method_assess_multimedia_accessibility_loaded_html_document.cs) | Execute_Validate_Method_Assess_Multimedia_Accessibility_Loaded_Html_Document | Result.Rule, Result.Success, Accessibility.Rules, Result.Error, HTMLDocument | Creates or manipulates an HTML document. |
| [Execute_Validator_Validate_With_File_Path_To_Run_Accessibility_Checks_On_Page](./execute_validator_validate_with_file_path_to_run_accessibility_checks_on_page.cs) | Execute_Validator_Validate_With_File_Path_To_Run_Accessibility_Checks_On_Page | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Export_Validation_Results_Formatted_String_Save_To_String_Developer_Review](./export_validation_results_formatted_string_save_to_string_developer_review.cs) | Export_Validation_Results_Formatted_String_Save_To_String_Developer_Review | WebAccessibility, Console.WriteLine, Accessibility.Results, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Fail_Build_If_Critical_Accessibility_Errors_Detected_Enforce_Quality_Gates](./fail_build_if_critical_accessibility_errors_detected_enforce_quality_gates.cs) | Fail_Build_If_Critical_Accessibility_Errors_Detected_Enforce_Quality_Gates | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Fail_Ci_Build_If_Validationresult_Contains_Error_Level_Findings_Enforce_Accessibility_Standards](./fail_ci_build_if_validationresult_contains_error_level_findings_enforce_accessibility_standards.cs) | Fail_Ci_Build_If_Validationresult_Contains_Error_Level_Findings_Enforce_Accessibility_Standards | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Fetch_Html_Content_From_Url_List_Validate_Pages_Save_Results_Xml_Files](./fetch_html_content_from_url_list_validate_pages_save_results_xml_files.cs) | Fetch_Html_Content_From_Url_List_Validate_Pages_Save_Results_Xml_Files | HTMLDocument, System.Collections, File.WriteAllText, Result.ToString, WebAccessibility | Creates or manipulates an HTML document. |
| [Filter_Errors_By_Target_Types_To_Separate_Html_Element_Issues_From_Css_Related_Problems](./filter_errors_by_target_types_to_separate_html_element_issues_from_css_related_problems.cs) | Filter_Errors_By_Target_Types_To_Separate_Html_Element_Issues_From_Css_Related_Problems | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Filter_Rule_Set_To_Include_Error_Level_Criteria_Before_Validation_Focus_On_Critical_Problems](./filter_rule_set_to_include_error_level_criteria_before_validation_focus_on_critical_problems.cs) | Filter_Rule_Set_To_Include_Error_Level_Criteria_Before_Validation_Focus_On_Critical_Problems | HTMLDocument, WebAccessibility, Console.WriteLine, Rule.Code, Accessibility.Results | Creates or manipulates an HTML document. |
| [Filter_Validation_Results_Audio_Description_Warnings_Targeted_Video_Improvements](./filter_validation_results_audio_description_warnings_targeted_video_improvements.cs) | Filter_Validation_Results_Audio_Description_Warnings_Targeted_Video_Improvements | Result.Success, Result.Error, ErrorMessage.Contains, Accessibility.TargetTypes, Console.WriteLine | Creates or manipulates an HTML document. |
| [Filter_Validation_Results_Display_Caption_Related_Warnings_Focused_Remediation](./filter_validation_results_display_caption_related_warnings_focused_remediation.cs) | Filter_Validation_Results_Display_Caption_Related_Warnings_Focused_Remediation | Result.Success, Result.Error, Console.WriteLine, Result.Details, Target.TargetType | Creates or manipulates an HTML document. |
| [Filter_Warnings_Specific_Ruleid_Values_Focus_Particular_Accessibility_Techniques](./filter_warnings_specific_ruleid_values_focus_particular_accessibility_techniques.cs) | Filter_Warnings_Specific_Ruleid_Values_Focus_Particular_Accessibility_Techniques | Result.Rule, Result.Success, System.Console, Result.Error, Result.Details | Creates or manipulates an HTML document. |
| [Generate_Detailed_Validation_Report_Json_Save_To_Specified_Output_Directory](./generate_detailed_validation_report_json_save_to_specified_output_directory.cs) | Generate_Detailed_Validation_Report_Json_Save_To_Specified_Output_Directory | Result.SaveToString, File.WriteAllText, Console.WriteLine, System.IO, Accessibility.AccessibilityValidator | Creates or manipulates an HTML document. |
| [Generate_Markdown_Report_From_Validationresult_To_Post_Directly_In_Pull_Request_Comments](./generate_markdown_report_from_validationresult_to_post_directly_in_pull_request_comments.cs) | Generate_Markdown_Report_From_Validationresult_To_Post_Directly_In_Pull_Request_Comments | HTMLDocument, Result.Success, File.WriteAllText, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Generate_Summary_Report_Aggregates_Total_Errors_Processed_Html_Documents_Batch](./generate_summary_report_aggregates_total_errors_processed_html_documents_batch.cs) | Generate_Summary_Report_Aggregates_Total_Errors_Processed_Html_Documents_Batch | System.Linq, HTMLDocument, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Identify_Video_Elements_Lacking_Audio_Description_Tracks_Filtering_Validation_Messages_Description_Warnings](./identify_video_elements_lacking_audio_description_tracks_filtering_validation_messages_description_warnings.cs) | Identify_Video_Elements_Lacking_Audio_Description_Tracks_Filtering_Validation_Messages_Description_Warnings | HTMLDocument, Result.Success, Result.Error, WebAccessibility, ErrorMessage.Contains | Creates or manipulates an HTML document. |
| [Implement_Retry_Mechanism_Validating_Remote_Html_Content_Transient_Network_Failures](./implement_retry_mechanism_validating_remote_html_content_transient_network_failures.cs) | Implement_Retry_Mechanism_Validating_Remote_Html_Content_Transient_Network_Failures | Configuration, HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Incorporate_Color_Contrast_Verification_Results_Into_Overall_Validation_Summary_Comprehensive_Reporting](./incorporate_color_contrast_verification_results_into_overall_validation_summary_comprehensive_reporting.cs) | Incorporate_Color_Contrast_Verification_Results_Into_Overall_Validation_Summary_Comprehensive_Reporting | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Initialize_Html_Document_From_File_Path_And_Validate_Using_Default_Validator](./initialize_html_document_from_file_path_and_validate_using_default_validator.cs) | Initialize_Html_Document_From_File_Path_And_Validate_Using_Default_Validator | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Inject_Accessibilityvalidator_Via_Dependency_Injection_Enable_Flexible_Configuration_Aspnet_Core_Applications](./inject_accessibilityvalidator_via_dependency_injection_enable_flexible_configuration_aspnet_core_applications.cs) | Inject_Accessibilityvalidator_Via_Dependency_Injection_Enable_Flexible_Configuration_Aspnet_Core_Applications | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Instantiate_Accessibilityvalidator_Using_Createvalidator_Before_Loading_Html_Document](./instantiate_accessibilityvalidator_using_createvalidator_before_loading_html_document.cs) | Instantiate_Accessibilityvalidator_Using_Createvalidator_Before_Loading_Html_Document | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Integrate_Accessibility_Validation_Into_Aspose_Html_Workflows_Multimedia_Processing_Pipeline](./integrate_accessibility_validation_into_aspose_html_workflows_multimedia_processing_pipeline.cs) | Integrate_Accessibility_Validation_Into_Aspose_Html_Workflows_Multimedia_Processing_Pipeline | Result.Success, Result.Error, Console.WriteLine, Aspose.HTML, Accessibility.TargetTypes | Creates or manipulates an HTML document. |
| [Integrate_Validation_Step_Into_Cicd_Pipeline_Using_Command_Line_Invocation_Of_Validator](./integrate_validation_step_into_cicd_pipeline_using_command_line_invocation_of_validator.cs) | Integrate_Validation_Step_Into_Cicd_Pipeline_Using_Command_Line_Invocation_Of_Validator | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Integrate_Validation_Step_Into_Github_Actions_Workflow_Automatically_Test_Pull_Requests](./integrate_validation_step_into_github_actions_workflow_automatically_test_pull_requests.cs) | Integrate_Validation_Step_Into_Github_Actions_Workflow_Automatically_Test_Pull_Requests | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Iterate_Accessibilityrules_Advisorytechniques_List_Improvement_Suggestions_Identified_Issues](./iterate_accessibilityrules_advisorytechniques_list_improvement_suggestions_identified_issues.cs) | Iterate_Accessibilityrules_Advisorytechniques_List_Improvement_Suggestions_Identified_Issues | Result.Rule, Result.Success, Result.Error, Console.WriteLine, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Iterate_Validationresult_Details_Log_Each_Rule_Identifier_And_Its_Pass_Fail_Status](./iterate_validationresult_details_log_each_rule_identifier_and_its_pass_fail_status.cs) | Iterate_Validationresult_Details_Log_Each_Rule_Identifier_And_Its_Pass_Fail_Status | ValidationResult.Details, HTMLDocument, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Load_Html_Content_From_String_Into_Validator_For_In_Memory_Validation](./load_html_content_from_string_into_validator_for_in_memory_validation.cs) | Load_Html_Content_From_String_Into_Validator_For_In_Memory_Validation | HTMLDocument, WebAccessibility, Console.WriteLine, Accessibility.Results, ValidationBuilder.All | Creates or manipulates an HTML document. |
| [Load_Html_Content_String_Create_Document_Object_Run_Accessibility_Validation](./load_html_content_string_create_document_object_run_accessibility_validation.cs) | Load_Html_Content_String_Create_Document_Object_Run_Accessibility_Validation | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Load_Html_File_From_Disk_Into_Validator_Using_Load_Method_File_Path_Argument](./load_html_file_from_disk_into_validator_using_load_method_file_path_argument.cs) | Load_Html_File_From_Disk_Into_Validator_Using_Load_Method_File_Path_Argument | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Load_Html_File_From_Local_Path_Into_Validator_For_Wcag_Analysis](./load_html_file_from_local_path_into_validator_for_wcag_analysis.cs) | Load_Html_File_From_Local_Path_Into_Validator_For_Wcag_Analysis | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Load_Html_From_Stream_Object_Into_Validator_Support_Network_Memory_Sources](./load_html_from_stream_object_into_validator_support_network_memory_sources.cs) | Load_Html_From_Stream_Object_Into_Validator_Support_Network_Memory_Sources | Encoding.UTF8, Console.WriteLine, System.IO, MemoryStream, Aspose.Html | Creates or manipulates an HTML document. |
| [Log_All_Validation_Messages_To_File_For_Further_Analysis_And_Troubleshooting_By_Developers](./log_all_validation_messages_to_file_for_further_analysis_and_troubleshooting_by_developers.cs) | Log_All_Validation_Messages_To_File_For_Further_Analysis_And_Troubleshooting_By_Developers | HTMLDocument, StreamWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Modify_Video_Elements_Include_Keyboard_Focusable_Controls_Add_Tabindex_Attributes_Where_Needed](./modify_video_elements_include_keyboard_focusable_controls_add_tabindex_attributes_where_needed.cs) | Modify_Video_Elements_Include_Keyboard_Focusable_Controls_Add_Tabindex_Attributes_Where_Needed | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Plain_Text_Summary_Validation_Findings_Quick_Developer_Review](./plain_text_summary_validation_findings_quick_developer_review.cs) | Plain_Text_Summary_Validation_Findings_Quick_Developer_Review | Result.SaveToString, WebAccessibility, Console.WriteLine, Accessibility.Results, Aspose.Html | Creates or manipulates an HTML document. |
| [Prioritize_Remediation_Tasks_Severity_Levels_Advisory_Impact_Scores](./prioritize_remediation_tasks_severity_levels_advisory_impact_scores.cs) | Prioritize_Remediation_Tasks_Severity_Levels_Advisory_Impact_Scores | Console.WriteLine, System.Linq, System.Collections | Demonstrates a specific Aspose.HTML operation. |
| [Process_Batch_Html_Files_Folder_Validating_Each_Sequentially_Aggregating_Results](./process_batch_html_files_folder_validating_each_sequentially_aggregating_results.cs) | Process_Batch_Html_Files_Folder_Validating_Each_Sequentially_Aggregating_Results | HTMLDocument, Console.WriteLine, System.IO, ImageFormat.Jpeg, Directory.GetFiles | Converts HTML content to another format using Aspose.HTML. |
| [Process_Folder_Of_Html_Files_Validate_Each_Output_Individual_Json_Reports_To_Target_Directory](./process_folder_of_html_files_validate_each_output_individual_json_reports_to_target_directory.cs) | Process_Folder_Of_Html_Files_Validate_Each_Output_Individual_Json_Reports_To_Target_Directory | HTMLDocument, System.Collections, File.WriteAllText, System.IO, Directory.GetFiles | Creates or manipulates an HTML document. |
| [Process_Html_Files_In_Parallel_Using_Task_Parallel_Library_To_Improve_Validation_Throughput_For_Large_Projects](./process_html_files_in_parallel_using_task_parallel_library_to_improve_validation_throughput_for_large_projects.cs) | Process_Html_Files_In_Parallel_Using_Task_Parallel_Library_To_Improve_Validation_Throughput_For_Large_Projects | HTMLDocument, Result.Success, Parallel.ForEach, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Publish_Validation_Summaries_To_Dashboard_Continuous_Monitoring_Website_Accessibility_Status](./publish_validation_summaries_to_dashboard_continuous_monitoring_website_accessibility_status.cs) | Publish_Validation_Summaries_To_Dashboard_Continuous_Monitoring_Website_Accessibility_Status | HTMLDocument, Result.SaveToString, Result.Success, Result.Error, WebAccessibility | Creates or manipulates an HTML document. |
| [Query_Specific_Rule_By_Code_Show_Detailed_Guidance](./query_specific_rule_by_code_show_detailed_guidance.cs) | Query_Specific_Rule_By_Code_Show_Detailed_Guidance | Accessibility.Rules, WebAccessibility, Console.WriteLine, AccessibilityRules.GetRule, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Read_Validationresult_Description_High_Level_Summary_Accessibility_Check_Outcome](./read_validationresult_description_high_level_summary_accessibility_check_outcome.cs) | Read_Validationresult_Description_High_Level_Summary_Accessibility_Check_Outcome | Result.Success, Result.SaveToString, Console.WriteLine, ValidationResult.Description, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Redirect_Console_Output_Validation_Issues_Persistent_Log_File](./redirect_console_output_validation_issues_persistent_log_file.cs) | Redirect_Console_Output_Validation_Issues_Persistent_Log_File | Result.SaveToString, File.WriteAllText, WebAccessibility, System.IO, Accessibility.Results | Creates or manipulates an HTML document. |
| [Retrieve_Contrast_Ratio_Values_For_Specific_Foreground_And_Background_Colors_And_Log_Failures](./retrieve_contrast_ratio_values_for_specific_foreground_and_background_colors_and_log_failures.cs) | Retrieve_Contrast_Ratio_Values_For_Specific_Foreground_And_Background_Colors_And_Log_Failures | Math.Min, System.Collections, System.Drawing, Console.WriteLine, Math.Max | Demonstrates a specific Aspose.HTML operation. |
| [Retrieve_Validationresult_Returned_By_Validate_And_Store_For_Further_Processing](./retrieve_validationresult_returned_by_validate_and_store_for_further_processing.cs) | Retrieve_Validationresult_Returned_By_Validate_And_Store_For_Further_Processing | HTMLDocument, WebAccessibility, Console.WriteLine, Accessibility.Results, ValidationBuilder.All | Creates or manipulates an HTML document. |
| [Re_Run_Validation_After_Html_Modifications_Confirm_Issues_Resolved](./re_run_validation_after_html_modifications_confirm_issues_resolved.cs) | Re_Run_Validation_After_Html_Modifications_Confirm_Issues_Resolved | Result.Success, Result.Error, Console.WriteLine, Accessibility.TargetTypes, Rule.Code | Creates or manipulates an HTML document. |
| [Run_Batch_Validation_All_Html_Files_Project_Folder_Produce_Consolidated_Json_Report](./run_batch_validation_all_html_files_project_folder_produce_consolidated_json_report.cs) | Run_Batch_Validation_All_Html_Files_Project_Folder_Produce_Consolidated_Json_Report | HTMLDocument, System.Collections, Result.Success, Result.SaveToString, File.WriteAllText | Creates or manipulates an HTML document. |
| [Run_Default_Accessibility_Validation_And_Direct_Console_Output_To_Debug_Logger_For_Development_Monitoring](./run_default_accessibility_validation_and_direct_console_output_to_debug_logger_for_development_monitoring.cs) | Run_Default_Accessibility_Validation_And_Direct_Console_Output_To_Debug_Logger_For_Development_Monitoring | HTMLDocument, Result.Success, Result.Error, WebAccessibility, System.Diagnostics | Creates or manipulates an HTML document. |
| [Run_Validation_Nightly_Build_Process_Ensure_Continuous_Accessibility_Compliance](./run_validation_nightly_build_process_ensure_continuous_accessibility_compliance.cs) | Run_Validation_Nightly_Build_Process_Ensure_Continuous_Accessibility_Compliance | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Save_Complete_Validation_Report_String_Using_Validationresult_Savetostring_Later_Processing](./save_complete_validation_report_string_using_validationresult_savetostring_later_processing.cs) | Save_Complete_Validation_Report_String_Using_Validationresult_Savetostring_Later_Processing | Result.SaveToString, ValidationResult.SaveToString, WebAccessibility, Console.WriteLine, Accessibility.Results | Creates or manipulates an HTML document. |
| [Save_Validation_Results_To_Json_File_For_Later_Analysis_And_Integration_With_Reporting_Tools](./save_validation_results_to_json_file_for_later_analysis_and_integration_with_reporting_tools.cs) | Save_Validation_Results_To_Json_File_For_Later_Analysis_And_Integration_With_Reporting_Tools | File.WriteAllText, WebAccessibility, Console.WriteLine, System.IO, Accessibility.Results | Creates or manipulates an HTML document. |
| [Save_Validation_Results_Xml_File_Compatibility_Legacy_Systems_Workflows](./save_validation_results_xml_file_compatibility_legacy_systems_workflows.cs) | Save_Validation_Results_Xml_File_Compatibility_Legacy_Systems_Workflows | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Schedule_Windows_Task_Scheduler_Job_Batch_Validation_All_Html_Files_Nightly](./schedule_windows_task_scheduler_job_batch_validation_all_html_files_nightly.cs) | Schedule_Windows_Task_Scheduler_Job_Batch_Validation_All_Html_Files_Nightly | Console.WriteLine, Path.GetFileName, System.IO, Directory.GetFiles, Aspose.Html | Creates or manipulates an HTML document. |
| [Select_Desired_Output_Format_Enumeration_Before_Saving_Results](./select_desired_output_format_enumeration_before_saving_results.cs) | Select_Desired_Output_Format_Enumeration_Before_Saving_Results | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Serialize_Validationresult_To_Json_Using_Custom_Serialization_For_External_Tool_Integration](./serialize_validationresult_to_json_using_custom_serialization_for_external_tool_integration.cs) | Serialize_Validationresult_To_Json_Using_Custom_Serialization_For_External_Tool_Integration | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Serialize_Validationresult_To_Xml_Using_Custom_Serialization_For_Legacy_System_Compatibility](./serialize_validationresult_to_xml_using_custom_serialization_for_legacy_system_compatibility.cs) | Serialize_Validationresult_To_Xml_Using_Custom_Serialization_For_Legacy_System_Compatibility | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Set_Custom_Issue_Severity_Threshold_Only_High_Priority_Accessibility_Problems_Reported](./set_custom_issue_severity_threshold_only_high_priority_accessibility_problems_reported.cs) | Set_Custom_Issue_Severity_Threshold_Only_High_Priority_Accessibility_Problems_Reported | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Stream_Validation_Results_To_Network_Socket_Using_Custom_Textwriter_For_Remote_Monitoring](./stream_validation_results_to_network_socket_using_custom_textwriter_for_remote_monitoring.cs) | Stream_Validation_Results_To_Network_Socket_Using_Custom_Textwriter_For_Remote_Monitoring | HTMLDocument, Encoding.UTF8, Accessibility.Saving, WebAccessibility, System.IO | Creates or manipulates an HTML document. |
| [Transform_Validation_Json_Output_Xslt_Generate_Human_Readable_Html_Report](./transform_validation_json_output_xslt_generate_human_readable_html_report.cs) | Transform_Validation_Json_Output_Xslt_Generate_Human_Readable_Html_Report | TemplateData, Converter.ConvertTemplate, Console.WriteLine, TemplateLoadOptions, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Update_Audio_Element_Include_Track_For_Captions_Set_Kind_Captions_Correctly](./update_audio_element_include_track_for_captions_set_kind_captions_correctly.cs) | Update_Audio_Element_Include_Track_For_Captions_Set_Kind_Captions_Correctly | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Use_Accessibilityrules_Getall_Fetch_All_Wcag_Rule_Codes_And_Descriptions_For_Ui_Display](./use_accessibilityrules_getall_fetch_all_wcag_rule_codes_and_descriptions_for_ui_display.cs) | Use_Accessibilityrules_Getall_Fetch_All_Wcag_Rule_Codes_And_Descriptions_For_Ui_Display | Accessibility.Rules, WebAccessibility, Console.WriteLine, AccessibilityRules.GetAll, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Use_Online_Color_Contrast_Checker_Api_Programmatically_Verify_Contrast_Ratios_Identified_Elements](./use_online_color_contrast_checker_api_programmatically_verify_contrast_ratios_identified_elements.cs) | Use_Online_Color_Contrast_Checker_Api_Programmatically_Verify_Contrast_Ratios_Identified_Elements | HTMLDocument, Encoding.UTF8, Console.WriteLine, Content.ReadAsStringAsync, System.Threading | Creates or manipulates an HTML document. |
| [Use_Stringbuilder_Textwriter_Capture_Xml_Validation_Output_Memory](./use_stringbuilder_textwriter_capture_xml_validation_output_memory.cs) | Use_Stringbuilder_Textwriter_Capture_Xml_Validation_Output_Memory | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Use_Validator_Azure_Devops_Pipeline_Task_Publish_Validation_Report_Build_Artifact](./use_validator_azure_devops_pipeline_task_publish_validation_report_build_artifact.cs) | Use_Validator_Azure_Devops_Pipeline_Task_Publish_Validation_Report_Build_Artifact | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Use_Validator_In_Aspnet_Core_Controller_To_Check_Uploaded_Html_Files_For_Multimedia_Accessibility_Before_Storage](./use_validator_in_aspnet_core_controller_to_check_uploaded_html_files_for_multimedia_accessibility_before_storage.cs) | Use_Validator_In_Aspnet_Core_Controller_To_Check_Uploaded_Html_Files_For_Multimedia_Accessibility_Before_Storage | Result.Rule, Result.Success, Accessibility.Rules, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Use_Validator_In_Console_Application_To_Process_Html_File_Paths_Via_Command_Line_Arguments](./use_validator_in_console_application_to_process_html_file_paths_via_command_line_arguments.cs) | Use_Validator_In_Console_Application_To_Process_Html_File_Paths_Via_Command_Line_Arguments | HTMLDocument, WebAccessibility, Console.WriteLine, System.IO, Accessibility.Results | Creates or manipulates an HTML document. |
| [Use_Validator_In_Github_Actions_Workflow_To_Automatically_Fail_Builds_When_Caption_Issues_Detected](./use_validator_in_github_actions_workflow_to_automatically_fail_builds_when_caption_issues_detected.cs) | Use_Validator_In_Github_Actions_Workflow_To_Automatically_Fail_Builds_When_Caption_Issues_Detected | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Use_Validator_Unit_Test_Assert_No_Multimedia_Accessibility_Issues_Sample_Html](./use_validator_unit_test_assert_no_multimedia_accessibility_issues_sample_html.cs) | Use_Validator_Unit_Test_Assert_No_Multimedia_Accessibility_Issues_Sample_Html | HTMLDocument, Result.Success, Accessibility.Rules, Result.Error, WebAccessibility | Creates or manipulates an HTML document. |
| [Validate_Html_Documents_Retrieved_From_Remote_Url_Loading_Content_Into_Validator](./validate_html_documents_retrieved_from_remote_url_loading_content_into_validator.cs) | Validate_Html_Documents_Retrieved_From_Remote_Url_Loading_Content_Into_Validator | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Validate_Html_Generated_Razor_View_Runtime_Log_Accessibility_Issues](./validate_html_generated_razor_view_runtime_log_accessibility_issues.cs) | Validate_Html_Generated_Razor_View_Runtime_Log_Accessibility_Issues | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Verify_Each_Track_Element_Includes_Valid_Srclang_Attribute_Meets_Accessibility_Standards](./verify_each_track_element_includes_valid_srclang_attribute_meets_accessibility_standards.cs) | Verify_Each_Track_Element_Includes_Valid_Srclang_Attribute_Meets_Accessibility_Standards | Result.Success, Result.Error, Console.WriteLine, Accessibility.TargetTypes, Result.Details | Creates or manipulates an HTML document. |
| [Write_Formatted_Validation_String_Text_File_Archival_Reporting](./write_formatted_validation_string_text_file_archival_reporting.cs) | Write_Formatted_Validation_String_Text_File_Archival_Reporting | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Write_Method_Returns_List_Of_Error_Messages_For_Specified_Rule_Identifier](./write_method_returns_list_of_error_messages_for_specified_rule_identifier.cs) | Write_Method_Returns_List_Of_Error_Messages_For_Specified_Rule_Identifier | HTMLDocument, System.Collections, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Write_Method_Returns_Warning_Counts_Grouped_By_Target_Element_Type_For_Analysis](./write_method_returns_warning_counts_grouped_by_target_element_type_for_analysis.cs) | Write_Method_Returns_Warning_Counts_Grouped_By_Target_Element_Type_For_Analysis | HTMLDocument, System.Collections, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Write_Validation_Results_To_Json_File_Using_Validationresult_Savetofile_Json_Format](./write_validation_results_to_json_file_using_validationresult_savetofile_json_format.cs) | Write_Validation_Results_To_Json_File_Using_Validationresult_Savetofile_Json_Format | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Write_Validation_Results_To_Xml_File_Using_Validationresult_Savetoxml](./write_validation_results_to_xml_file_using_validationresult_savetoxml.cs) | Write_Validation_Results_To_Xml_File_Using_Validationresult_Savetoxml | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |

---

## Category-Specific Tips

### Key API Surface
- `HTMLDocument` – core representation of the HTML to be validated.  
- `AccessibilityValidator.CreateValidator()` – entry point for all accessibility checks.  
- `Validate` / `ValidateAsync` – runs the rule engine and returns a `ValidationResult`.  
- `Result.Success`, `Result.Error`, `Result.Warnings` – quick status checks.  
- `Result.Details` – iterate for per‑rule outcomes.  
- `Result.SaveToString` / `Result.SaveTo` – export JSON, XML, or plain‑text reports.  
- `Rule.Code` – identify or filter specific WCAG rules.  
- `File.WriteAllText`, `Console.WriteLine` – common logging / persistence helpers.

### Rules
1. **Always dispose `HTMLDocument`** (use `using` or explicit `Dispose`) to free native resources.  
2. **Filter before you log** – use `Result.Rule` or `ErrorMessage.Contains` to isolate relevant findings.  
3. **Prefer JSON for CI pipelines** – it is easy to parse and integrates with dashboards.  
4. **Reuse a static validator** when processing many files; it reduces overhead.  
5. **Set severity thresholds** (`Result.Rule.Severity`) to focus on critical issues only.  

---

## Warnings

- **Template binding mismatch** – if you reference IDs or placeholders that do not exist in the loaded HTML, validation may report false‑positive “missing element” errors.  
- **Missing external resources** – track files, caption VTT files, or referenced images must be present on disk or reachable via URL; otherwise the validator will flag “resource not found”.  
- **Incorrect file paths** – relative paths are resolved against the current working directory; use absolute paths or set `document.BaseUrl`.  
- **Large documents & memory pressure** – loading many megabytes of HTML simultaneously can exhaust memory; process files sequentially or use streaming where possible.  

---

## Guidelines for Adding New Examples

1. **Self‑contained** – the example must compile and run without external configuration files.  
2. **Console logging** – use `Console.WriteLine` to surface key results (status, counts, sample rule).  
3. **Follow the common pattern** (load → validator → validate → output).  
4. **Naming** – file name should be snake_case, title in PascalCase, and reflect the operation.  
5. **Update statistics** – increment `total_examples` and the relevant namespace/API counts in the source JSON.  

---
