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
| [Access Validationresult Errors Collection Count Total Accessibility Errors Document](./access_validationresult_errors_collection_count_total_accessibility_errors_document.cs) | Access Validationresult Errors Collection Count Total Accessibility Errors Document | Errors.Count, HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Access Validationresult Warnings Collection Count Total Accessibility Warnings Html Page](./access_validationresult_warnings_collection_count_total_accessibility_warnings_html_page.cs) | Access Validationresult Warnings Collection Count Total Accessibility Warnings Html Page | Console.WriteLine, ValidationResult.Warnings, Result.Details, Accessibility.WebAccessibility, Accessibility.ValidationBuilder | Creates or manipulates an HTML document. |
| [Add Missing Track Element With Kind Captions And Src To Video Programmatically](./add_missing_track_element_with_kind_captions_and_src_to_video_programmatically.cs) | Add Missing Track Element With Kind Captions And Src To Video Programmatically | HTMLSaveOptions, Console.WriteLine, StringComparison.OrdinalIgnoreCase, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Apply Cancellation Token To Validation Process For Graceful Termination During Long Batch Runs](./apply_cancellation_token_to_validation_process_for_graceful_termination_during_long_batch_runs.cs) | Apply Cancellation Token To Validation Process For Graceful Termination During Long Batch Runs | WebAccessibility, Console.WriteLine, System.Threading, Accessibility.Results, TimeSpan.FromSeconds | Creates or manipulates an HTML document. |
| [Call Validationresult Savetostring Obtain Formatted String Errors Warnings](./call_validationresult_savetostring_obtain_formatted_string_errors_warnings.cs) | Call Validationresult Savetostring Obtain Formatted String Errors Warnings | Result.SaveToString, ValidationResult.SaveToString, WebAccessibility, Console.WriteLine, Accessibility.Results | Creates or manipulates an HTML document. |
| [Check Missing Track Elements Kind Captions In Video Tags Using Validation Report](./check_missing_track_elements_kind_captions_in_video_tags_using_validation_report.cs) | Check Missing Track Elements Kind Captions In Video Tags Using Validation Report | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Combine Validation Findings With Seo Metrics Identify Pages With Accessibility And Ranking Issues](./combine_validation_findings_with_seo_metrics_identify_pages_with_accessibility_and_ranking_issues.cs) | Combine Validation Findings With Seo Metrics Identify Pages With Accessibility And Ranking Issues | HTMLDocument, System.Collections, File.WriteAllText, Result.ToString, Result.Success | Creates or manipulates an HTML document. |
| [Compare Two Validationresult Objects Detect Regressions Modifying Html Content Same Project](./compare_two_validationresult_objects_detect_regressions_modifying_html_content_same_project.cs) | Compare Two Validationresult Objects Detect Regressions Modifying Html Content Same Project | Accessibility.Results, Failures.Contains, Failures.Add, Result.Details, Result.Error | Creates or manipulates an HTML document. |
| [Configure Accessibilityvalidator With Custom Settings Before Validating Html Document In Application](./configure_accessibilityvalidator_with_custom_settings_before_validating_html_document_in_application.cs) | Configure Accessibilityvalidator With Custom Settings Before Validating Html Document In Application | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.Results | Creates or manipulates an HTML document. |
| [Configure Validator Ignore Selected Rule Codes Allowing Custom Compliance Thresholds During Checks](./configure_validator_ignore_selected_rule_codes_allowing_custom_compliance_thresholds_during_checks.cs) | Configure Validator Ignore Selected Rule Codes Allowing Custom Compliance Thresholds During Checks | HTMLDocument, System.Collections, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Configure Validator Static Rule Repository Consistent Rule Application Across Runs](./configure_validator_static_rule_repository_consistent_rule_application_across_runs.cs) | Configure Validator Static Rule Repository Consistent Rule Application Across Runs | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Configure Validator Treat Caption Missing Warnings Errors Adjust Severity Settings](./configure_validator_treat_caption_missing_warnings_errors_adjust_severity_settings.cs) | Configure Validator Treat Caption Missing Warnings Errors Adjust Severity Settings | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Create Custom Rule Subset Selecting Specific Wcag Criteria From Accessibilityrules Before Validation](./create_custom_rule_subset_selecting_specific_wcag_criteria_from_accessibilityrules_before_validation.cs) | Create Custom Rule Subset Selecting Specific Wcag Criteria From Accessibilityrules Before Validation | System.Collections, Accessibility.Rules, Result.Success, Console.WriteLine, Accessibility.Guideline | Creates or manipulates an HTML document. |
| [Create Powershell Script Loads Dotnet Library Validates Html File Prints Json Results](./create_powershell_script_loads_dotnet_library_validates_html_file_prints_json_results.cs) | Create Powershell Script Loads Dotnet Library Validates Html File Prints Json Results | HTMLDocument, System.Collections, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Create Static Accessibilityvalidator Instance Reuse To Validate Multiple Html Files Efficiently](./create_static_accessibilityvalidator_instance_reuse_to_validate_multiple_html_files_efficiently.cs) | Create Static Accessibilityvalidator Instance Reuse To Validate Multiple Html Files Efficiently | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Create Validator Instance Before Loading Html Document For Accessibility](./create_validator_instance_before_loading_html_document_for_accessibility.cs) | Create Validator Instance Before Loading Html Document For Accessibility | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.Results | Creates or manipulates an HTML document. |
| [Detect Absent Caption Files Referenced In Track Elements And Log File Paths](./detect_absent_caption_files_referenced_in_track_elements_and_log_file_paths.cs) | Detect Absent Caption Files Referenced In Track Elements And Log File Paths | File.AppendAllText, Console.WriteLine, System.IO, File.Exists, Environment.NewLine | Creates or manipulates an HTML document. |
| [Develop Command Line Tool Accepting Input Path And Output Format Arguments To Perform Validation On Demand](./develop_command_line_tool_accepting_input_path_and_output_format_arguments_to_perform_validation_on_demand.cs) | Develop Command Line Tool Accepting Input Path And Output Format Arguments To Perform Validation On Demand | Result.SaveToString, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Embed Validation Results String Into Email Body Notify Stakeholders Accessibility Status](./embed_validation_results_string_into_email_body_notify_stakeholders_accessibility_status.cs) | Embed Validation Results String Into Email Body Notify Stakeholders Accessibility Status | MailMessage, HTMLDocument, Result.SaveToString, NetworkCredential, WebAccessibility | Creates or manipulates an HTML document. |
| [Embed Vtt Caption File Into Html Document And Reference With New Track Element](./embed_vtt_caption_file_into_html_document_and_reference_with_new_track_element.cs) | Embed Vtt Caption File Into Html Document And Reference With New Track Element | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Ensure Caption Tracks Contain Synchronized Timestamps Matching Associated Media Timeline](./ensure_caption_tracks_contain_synchronized_timestamps_matching_associated_media_timeline.cs) | Ensure Caption Tracks Contain Synchronized Timestamps Matching Associated Media Timeline | TagName.Equals, Console.WriteLine, System.IO, StringComparison.OrdinalIgnoreCase, Path.GetFileNameWithoutExtension | Creates or manipulates an HTML document. |
| [Exclude Keyboard Navigation Warnings From Final Report Using Result Filtering Option](./exclude_keyboard_navigation_warnings_from_final_report_using_result_filtering_option.cs) | Exclude Keyboard Navigation Warnings From Final Report Using Result Filtering Option | ErrorMessage.IndexOf, Result.Rule, Result.Success, Result.Error, HTMLDocument | Creates or manipulates an HTML document. |
| [Execute Validate Method Assess Multimedia Accessibility Loaded Html Document](./execute_validate_method_assess_multimedia_accessibility_loaded_html_document.cs) | Execute Validate Method Assess Multimedia Accessibility Loaded Html Document | Result.Rule, Result.Success, Accessibility.Rules, Result.Error, HTMLDocument | Creates or manipulates an HTML document. |
| [Execute Validator Validate With File Path To Run Accessibility Checks On Page](./execute_validator_validate_with_file_path_to_run_accessibility_checks_on_page.cs) | Execute Validator Validate With File Path To Run Accessibility Checks On Page | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Export Validation Results Formatted String Save To String Developer Review](./export_validation_results_formatted_string_save_to_string_developer_review.cs) | Export Validation Results Formatted String Save To String Developer Review | WebAccessibility, Console.WriteLine, Accessibility.Results, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Fail Build If Critical Accessibility Errors Detected Enforce Quality Gates](./fail_build_if_critical_accessibility_errors_detected_enforce_quality_gates.cs) | Fail Build If Critical Accessibility Errors Detected Enforce Quality Gates | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Fail Ci Build If Validationresult Contains Error Level Findings Enforce Accessibility Standards](./fail_ci_build_if_validationresult_contains_error_level_findings_enforce_accessibility_standards.cs) | Fail Ci Build If Validationresult Contains Error Level Findings Enforce Accessibility Standards | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Fetch Html Content From Url List Validate Pages Save Results Xml Files](./fetch_html_content_from_url_list_validate_pages_save_results_xml_files.cs) | Fetch Html Content From Url List Validate Pages Save Results Xml Files | HTMLDocument, System.Collections, File.WriteAllText, Result.ToString, WebAccessibility | Creates or manipulates an HTML document. |
| [Filter Errors By Target Types To Separate Html Element Issues From Css Related Problems](./filter_errors_by_target_types_to_separate_html_element_issues_from_css_related_problems.cs) | Filter Errors By Target Types To Separate Html Element Issues From Css Related Problems | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Filter Rule Set To Include Error Level Criteria Before Validation Focus On Critical Problems](./filter_rule_set_to_include_error_level_criteria_before_validation_focus_on_critical_problems.cs) | Filter Rule Set To Include Error Level Criteria Before Validation Focus On Critical Problems | HTMLDocument, WebAccessibility, Console.WriteLine, Rule.Code, Accessibility.Results | Creates or manipulates an HTML document. |
| [Filter Validation Results Audio Description Warnings Targeted Video Improvements](./filter_validation_results_audio_description_warnings_targeted_video_improvements.cs) | Filter Validation Results Audio Description Warnings Targeted Video Improvements | Result.Success, Result.Error, ErrorMessage.Contains, Accessibility.TargetTypes, Console.WriteLine | Creates or manipulates an HTML document. |
| [Filter Validation Results Display Caption Related Warnings Focused Remediation](./filter_validation_results_display_caption_related_warnings_focused_remediation.cs) | Filter Validation Results Display Caption Related Warnings Focused Remediation | Result.Success, Result.Error, Console.WriteLine, Result.Details, Target.TargetType | Creates or manipulates an HTML document. |
| [Filter Warnings Specific Ruleid Values Focus Particular Accessibility Techniques](./filter_warnings_specific_ruleid_values_focus_particular_accessibility_techniques.cs) | Filter Warnings Specific Ruleid Values Focus Particular Accessibility Techniques | Result.Rule, Result.Success, System.Console, Result.Error, Result.Details | Creates or manipulates an HTML document. |
| [Generate Detailed Validation Report Json Save To Specified Output Directory](./generate_detailed_validation_report_json_save_to_specified_output_directory.cs) | Generate Detailed Validation Report Json Save To Specified Output Directory | Result.SaveToString, File.WriteAllText, Console.WriteLine, System.IO, Accessibility.AccessibilityValidator | Creates or manipulates an HTML document. |
| [Generate Markdown Report From Validationresult To Post Directly In Pull Request Comments](./generate_markdown_report_from_validationresult_to_post_directly_in_pull_request_comments.cs) | Generate Markdown Report From Validationresult To Post Directly In Pull Request Comments | HTMLDocument, Result.Success, File.WriteAllText, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Generate Summary Report Aggregates Total Errors Processed Html Documents Batch](./generate_summary_report_aggregates_total_errors_processed_html_documents_batch.cs) | Generate Summary Report Aggregates Total Errors Processed Html Documents Batch | System.Linq, HTMLDocument, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Identify Video Elements Lacking Audio Description Tracks Filtering Validation Messages Description Warnings](./identify_video_elements_lacking_audio_description_tracks_filtering_validation_messages_description_warnings.cs) | Identify Video Elements Lacking Audio Description Tracks Filtering Validation Messages Description Warnings | HTMLDocument, Result.Success, Result.Error, WebAccessibility, ErrorMessage.Contains | Creates or manipulates an HTML document. |
| [Implement Retry Mechanism Validating Remote Html Content Transient Network Failures](./implement_retry_mechanism_validating_remote_html_content_transient_network_failures.cs) | Implement Retry Mechanism Validating Remote Html Content Transient Network Failures | Configuration, HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Incorporate Color Contrast Verification Results Into Overall Validation Summary Comprehensive Reporting](./incorporate_color_contrast_verification_results_into_overall_validation_summary_comprehensive_reporting.cs) | Incorporate Color Contrast Verification Results Into Overall Validation Summary Comprehensive Reporting | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Initialize Html Document From File Path And Validate Using Default Validator](./initialize_html_document_from_file_path_and_validate_using_default_validator.cs) | Initialize Html Document From File Path And Validate Using Default Validator | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Inject Accessibilityvalidator Via Dependency Injection Enable Flexible Configuration Aspnet Core Applications](./inject_accessibilityvalidator_via_dependency_injection_enable_flexible_configuration_aspnet_core_applications.cs) | Inject Accessibilityvalidator Via Dependency Injection Enable Flexible Configuration Aspnet Core Applications | Result.Success, Result.Error, Console.WriteLine, Result.Details, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Instantiate Accessibilityvalidator Using Createvalidator Before Loading Html Document](./instantiate_accessibilityvalidator_using_createvalidator_before_loading_html_document.cs) | Instantiate Accessibilityvalidator Using Createvalidator Before Loading Html Document | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Integrate Accessibility Validation Into Aspose Html Workflows Multimedia Processing Pipeline](./integrate_accessibility_validation_into_aspose_html_workflows_multimedia_processing_pipeline.cs) | Integrate Accessibility Validation Into Aspose Html Workflows Multimedia Processing Pipeline | Result.Success, Result.Error, Console.WriteLine, Aspose.HTML, Accessibility.TargetTypes | Creates or manipulates an HTML document. |
| [Integrate Validation Step Into Cicd Pipeline Using Command Line Invocation Of Validator](./integrate_validation_step_into_cicd_pipeline_using_command_line_invocation_of_validator.cs) | Integrate Validation Step Into Cicd Pipeline Using Command Line Invocation Of Validator | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Integrate Validation Step Into Github Actions Workflow Automatically Test Pull Requests](./integrate_validation_step_into_github_actions_workflow_automatically_test_pull_requests.cs) | Integrate Validation Step Into Github Actions Workflow Automatically Test Pull Requests | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Iterate Accessibilityrules Advisorytechniques List Improvement Suggestions Identified Issues](./iterate_accessibilityrules_advisorytechniques_list_improvement_suggestions_identified_issues.cs) | Iterate Accessibilityrules Advisorytechniques List Improvement Suggestions Identified Issues | Result.Rule, Result.Success, Result.Error, Console.WriteLine, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Iterate Validationresult Details Log Each Rule Identifier And Its Pass Fail Status](./iterate_validationresult_details_log_each_rule_identifier_and_its_pass_fail_status.cs) | Iterate Validationresult Details Log Each Rule Identifier And Its Pass Fail Status | ValidationResult.Details, HTMLDocument, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Load Html Content From String Into Validator For In Memory Validation](./load_html_content_from_string_into_validator_for_in_memory_validation.cs) | Load Html Content From String Into Validator For In Memory Validation | HTMLDocument, WebAccessibility, Console.WriteLine, Accessibility.Results, ValidationBuilder.All | Creates or manipulates an HTML document. |
| [Load Html Content String Create Document Object Run Accessibility Validation](./load_html_content_string_create_document_object_run_accessibility_validation.cs) | Load Html Content String Create Document Object Run Accessibility Validation | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Load Html File From Disk Into Validator Using Load Method File Path Argument](./load_html_file_from_disk_into_validator_using_load_method_file_path_argument.cs) | Load Html File From Disk Into Validator Using Load Method File Path Argument | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Load Html File From Local Path Into Validator For Wcag Analysis](./load_html_file_from_local_path_into_validator_for_wcag_analysis.cs) | Load Html File From Local Path Into Validator For Wcag Analysis | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Load Html From Stream Object Into Validator Support Network Memory Sources](./load_html_from_stream_object_into_validator_support_network_memory_sources.cs) | Load Html From Stream Object Into Validator Support Network Memory Sources | Encoding.UTF8, Console.WriteLine, System.IO, MemoryStream, Aspose.Html | Creates or manipulates an HTML document. |
| [Log All Validation Messages To File For Further Analysis And Troubleshooting By Developers](./log_all_validation_messages_to_file_for_further_analysis_and_troubleshooting_by_developers.cs) | Log All Validation Messages To File For Further Analysis And Troubleshooting By Developers | HTMLDocument, StreamWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Modify Video Elements Include Keyboard Focusable Controls Add Tabindex Attributes Where Needed](./modify_video_elements_include_keyboard_focusable_controls_add_tabindex_attributes_where_needed.cs) | Modify Video Elements Include Keyboard Focusable Controls Add Tabindex Attributes Where Needed | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Plain Text Summary Validation Findings Quick Developer Review](./plain_text_summary_validation_findings_quick_developer_review.cs) | Plain Text Summary Validation Findings Quick Developer Review | Result.SaveToString, WebAccessibility, Console.WriteLine, Accessibility.Results, Aspose.Html | Creates or manipulates an HTML document. |
| [Prioritize Remediation Tasks Severity Levels Advisory Impact Scores](./prioritize_remediation_tasks_severity_levels_advisory_impact_scores.cs) | Prioritize Remediation Tasks Severity Levels Advisory Impact Scores | Console.WriteLine, System.Linq, System.Collections | Demonstrates a specific Aspose.HTML operation. |
| [Process Batch Html Files Folder Validating Each Sequentially Aggregating Results](./process_batch_html_files_folder_validating_each_sequentially_aggregating_results.cs) | Process Batch Html Files Folder Validating Each Sequentially Aggregating Results | HTMLDocument, Console.WriteLine, System.IO, ImageFormat.Jpeg, Directory.GetFiles | Converts HTML content to another format using Aspose.HTML. |
| [Process Folder Of Html Files Validate Each Output Individual Json Reports To Target Directory](./process_folder_of_html_files_validate_each_output_individual_json_reports_to_target_directory.cs) | Process Folder Of Html Files Validate Each Output Individual Json Reports To Target Directory | HTMLDocument, System.Collections, File.WriteAllText, System.IO, Directory.GetFiles | Creates or manipulates an HTML document. |
| [Process Html Files In Parallel Using Task Parallel Library To Improve Validation Throughput For Large Projects](./process_html_files_in_parallel_using_task_parallel_library_to_improve_validation_throughput_for_large_projects.cs) | Process Html Files In Parallel Using Task Parallel Library To Improve Validation Throughput For Large Projects | HTMLDocument, Result.Success, Parallel.ForEach, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Publish Validation Summaries To Dashboard Continuous Monitoring Website Accessibility Status](./publish_validation_summaries_to_dashboard_continuous_monitoring_website_accessibility_status.cs) | Publish Validation Summaries To Dashboard Continuous Monitoring Website Accessibility Status | HTMLDocument, Result.SaveToString, Result.Success, Result.Error, WebAccessibility | Creates or manipulates an HTML document. |
| [Query Specific Rule By Code Show Detailed Guidance](./query_specific_rule_by_code_show_detailed_guidance.cs) | Query Specific Rule By Code Show Detailed Guidance | Accessibility.Rules, WebAccessibility, Console.WriteLine, AccessibilityRules.GetRule, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Read Validationresult Description High Level Summary Accessibility Check Outcome](./read_validationresult_description_high_level_summary_accessibility_check_outcome.cs) | Read Validationresult Description High Level Summary Accessibility Check Outcome | Result.Success, Result.SaveToString, Console.WriteLine, ValidationResult.Description, Accessibility.WebAccessibility | Creates or manipulates an HTML document. |
| [Redirect Console Output Validation Issues Persistent Log File](./redirect_console_output_validation_issues_persistent_log_file.cs) | Redirect Console Output Validation Issues Persistent Log File | Result.SaveToString, File.WriteAllText, WebAccessibility, System.IO, Accessibility.Results | Creates or manipulates an HTML document. |
| [Retrieve Contrast Ratio Values For Specific Foreground And Background Colors And Log Failures](./retrieve_contrast_ratio_values_for_specific_foreground_and_background_colors_and_log_failures.cs) | Retrieve Contrast Ratio Values For Specific Foreground And Background Colors And Log Failures | Math.Min, System.Collections, System.Drawing, Console.WriteLine, Math.Max | Demonstrates a specific Aspose.HTML operation. |
| [Retrieve Validationresult Returned By Validate And Store For Further Processing](./retrieve_validationresult_returned_by_validate_and_store_for_further_processing.cs) | Retrieve Validationresult Returned By Validate And Store For Further Processing | HTMLDocument, WebAccessibility, Console.WriteLine, Accessibility.Results, ValidationBuilder.All | Creates or manipulates an HTML document. |
| [Re Run Validation After Html Modifications Confirm Issues Resolved](./re_run_validation_after_html_modifications_confirm_issues_resolved.cs) | Re Run Validation After Html Modifications Confirm Issues Resolved | Result.Success, Result.Error, Console.WriteLine, Accessibility.TargetTypes, Rule.Code | Creates or manipulates an HTML document. |
| [Run Batch Validation All Html Files Project Folder Produce Consolidated Json Report](./run_batch_validation_all_html_files_project_folder_produce_consolidated_json_report.cs) | Run Batch Validation All Html Files Project Folder Produce Consolidated Json Report | HTMLDocument, System.Collections, Result.Success, Result.SaveToString, File.WriteAllText | Creates or manipulates an HTML document. |
| [Run Default Accessibility Validation And Direct Console Output To Debug Logger For Development Monitoring](./run_default_accessibility_validation_and_direct_console_output_to_debug_logger_for_development_monitoring.cs) | Run Default Accessibility Validation And Direct Console Output To Debug Logger For Development Monitoring | HTMLDocument, Result.Success, Result.Error, WebAccessibility, System.Diagnostics | Creates or manipulates an HTML document. |
| [Run Validation Nightly Build Process Ensure Continuous Accessibility Compliance](./run_validation_nightly_build_process_ensure_continuous_accessibility_compliance.cs) | Run Validation Nightly Build Process Ensure Continuous Accessibility Compliance | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Save Complete Validation Report String Using Validationresult Savetostring Later Processing](./save_complete_validation_report_string_using_validationresult_savetostring_later_processing.cs) | Save Complete Validation Report String Using Validationresult Savetostring Later Processing | Result.SaveToString, ValidationResult.SaveToString, WebAccessibility, Console.WriteLine, Accessibility.Results | Creates or manipulates an HTML document. |
| [Save Validation Results To Json File For Later Analysis And Integration With Reporting Tools](./save_validation_results_to_json_file_for_later_analysis_and_integration_with_reporting_tools.cs) | Save Validation Results To Json File For Later Analysis And Integration With Reporting Tools | File.WriteAllText, WebAccessibility, Console.WriteLine, System.IO, Accessibility.Results | Creates or manipulates an HTML document. |
| [Save Validation Results Xml File Compatibility Legacy Systems Workflows](./save_validation_results_xml_file_compatibility_legacy_systems_workflows.cs) | Save Validation Results Xml File Compatibility Legacy Systems Workflows | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Schedule Windows Task Scheduler Job Batch Validation All Html Files Nightly](./schedule_windows_task_scheduler_job_batch_validation_all_html_files_nightly.cs) | Schedule Windows Task Scheduler Job Batch Validation All Html Files Nightly | Console.WriteLine, Path.GetFileName, System.IO, Directory.GetFiles, Aspose.Html | Creates or manipulates an HTML document. |
| [Select Desired Output Format Enumeration Before Saving Results](./select_desired_output_format_enumeration_before_saving_results.cs) | Select Desired Output Format Enumeration Before Saving Results | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Serialize Validationresult To Json Using Custom Serialization For External Tool Integration](./serialize_validationresult_to_json_using_custom_serialization_for_external_tool_integration.cs) | Serialize Validationresult To Json Using Custom Serialization For External Tool Integration | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Serialize Validationresult To Xml Using Custom Serialization For Legacy System Compatibility](./serialize_validationresult_to_xml_using_custom_serialization_for_legacy_system_compatibility.cs) | Serialize Validationresult To Xml Using Custom Serialization For Legacy System Compatibility | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Set Custom Issue Severity Threshold Only High Priority Accessibility Problems Reported](./set_custom_issue_severity_threshold_only_high_priority_accessibility_problems_reported.cs) | Set Custom Issue Severity Threshold Only High Priority Accessibility Problems Reported | Result.Rule, Result.Success, Result.Error, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Stream Validation Results To Network Socket Using Custom Textwriter For Remote Monitoring](./stream_validation_results_to_network_socket_using_custom_textwriter_for_remote_monitoring.cs) | Stream Validation Results To Network Socket Using Custom Textwriter For Remote Monitoring | HTMLDocument, Encoding.UTF8, Accessibility.Saving, WebAccessibility, System.IO | Creates or manipulates an HTML document. |
| [Transform Validation Json Output Xslt Generate Human Readable Html Report](./transform_validation_json_output_xslt_generate_human_readable_html_report.cs) | Transform Validation Json Output Xslt Generate Human Readable Html Report | TemplateData, Converter.ConvertTemplate, Console.WriteLine, TemplateLoadOptions, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Update Audio Element Include Track For Captions Set Kind Captions Correctly](./update_audio_element_include_track_for_captions_set_kind_captions_correctly.cs) | Update Audio Element Include Track For Captions Set Kind Captions Correctly | Console.WriteLine, Aspose.Html, HTMLDocument | Creates or manipulates an HTML document. |
| [Use Accessibilityrules Getall Fetch All Wcag Rule Codes And Descriptions For Ui Display](./use_accessibilityrules_getall_fetch_all_wcag_rule_codes_and_descriptions_for_ui_display.cs) | Use Accessibilityrules Getall Fetch All Wcag Rule Codes And Descriptions For Ui Display | Accessibility.Rules, WebAccessibility, Console.WriteLine, AccessibilityRules.GetAll, Aspose.Html | Demonstrates a specific Aspose.HTML operation. |
| [Use Online Color Contrast Checker Api Programmatically Verify Contrast Ratios Identified Elements](./use_online_color_contrast_checker_api_programmatically_verify_contrast_ratios_identified_elements.cs) | Use Online Color Contrast Checker Api Programmatically Verify Contrast Ratios Identified Elements | HTMLDocument, Encoding.UTF8, Console.WriteLine, Content.ReadAsStringAsync, System.Threading | Creates or manipulates an HTML document. |
| [Use Stringbuilder Textwriter Capture Xml Validation Output Memory](./use_stringbuilder_textwriter_capture_xml_validation_output_memory.cs) | Use Stringbuilder Textwriter Capture Xml Validation Output Memory | Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine, System.IO | Creates or manipulates an HTML document. |
| [Use Validator Azure Devops Pipeline Task Publish Validation Report Build Artifact](./use_validator_azure_devops_pipeline_task_publish_validation_report_build_artifact.cs) | Use Validator Azure Devops Pipeline Task Publish Validation Report Build Artifact | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Use Validator In Aspnet Core Controller To Check Uploaded Html Files For Multimedia Accessibility Before Storage](./use_validator_in_aspnet_core_controller_to_check_uploaded_html_files_for_multimedia_accessibility_before_storage.cs) | Use Validator In Aspnet Core Controller To Check Uploaded Html Files For Multimedia Accessibility Before Storage | Result.Rule, Result.Success, Accessibility.Rules, HTMLDocument, WebAccessibility | Creates or manipulates an HTML document. |
| [Use Validator In Console Application To Process Html File Paths Via Command Line Arguments](./use_validator_in_console_application_to_process_html_file_paths_via_command_line_arguments.cs) | Use Validator In Console Application To Process Html File Paths Via Command Line Arguments | HTMLDocument, WebAccessibility, Console.WriteLine, System.IO, Accessibility.Results | Creates or manipulates an HTML document. |
| [Use Validator In Github Actions Workflow To Automatically Fail Builds When Caption Issues Detected](./use_validator_in_github_actions_workflow_to_automatically_fail_builds_when_caption_issues_detected.cs) | Use Validator In Github Actions Workflow To Automatically Fail Builds When Caption Issues Detected | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Use Validator Unit Test Assert No Multimedia Accessibility Issues Sample Html](./use_validator_unit_test_assert_no_multimedia_accessibility_issues_sample_html.cs) | Use Validator Unit Test Assert No Multimedia Accessibility Issues Sample Html | HTMLDocument, Result.Success, Accessibility.Rules, Result.Error, WebAccessibility | Creates or manipulates an HTML document. |
| [Validate Html Documents Retrieved From Remote Url Loading Content Into Validator](./validate_html_documents_retrieved_from_remote_url_loading_content_into_validator.cs) | Validate Html Documents Retrieved From Remote Url Loading Content Into Validator | HTMLDocument, Result.Success, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Validate Html Generated Razor View Runtime Log Accessibility Issues](./validate_html_generated_razor_view_runtime_log_accessibility_issues.cs) | Validate Html Generated Razor View Runtime Log Accessibility Issues | HTMLDocument, Result.Success, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Verify Each Track Element Includes Valid Srclang Attribute Meets Accessibility Standards](./verify_each_track_element_includes_valid_srclang_attribute_meets_accessibility_standards.cs) | Verify Each Track Element Includes Valid Srclang Attribute Meets Accessibility Standards | Result.Success, Result.Error, Console.WriteLine, Accessibility.TargetTypes, Result.Details | Creates or manipulates an HTML document. |
| [Write Formatted Validation String Text File Archival Reporting](./write_formatted_validation_string_text_file_archival_reporting.cs) | Write Formatted Validation String Text File Archival Reporting | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Write Method Returns List Of Error Messages For Specified Rule Identifier](./write_method_returns_list_of_error_messages_for_specified_rule_identifier.cs) | Write Method Returns List Of Error Messages For Specified Rule Identifier | HTMLDocument, System.Collections, WebAccessibility, Console.WriteLine, Rule.Code | Creates or manipulates an HTML document. |
| [Write Method Returns Warning Counts Grouped By Target Element Type For Analysis](./write_method_returns_warning_counts_grouped_by_target_element_type_for_analysis.cs) | Write Method Returns Warning Counts Grouped By Target Element Type For Analysis | HTMLDocument, System.Collections, Result.Error, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Write Validation Results To Json File Using Validationresult Savetofile Json Format](./write_validation_results_to_json_file_using_validationresult_savetofile_json_format.cs) | Write Validation Results To Json File Using Validationresult Savetofile Json Format | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |
| [Write Validation Results To Xml File Using Validationresult Savetoxml](./write_validation_results_to_xml_file_using_validationresult_savetoxml.cs) | Write Validation Results To Xml File Using Validationresult Savetoxml | File.WriteAllText, Accessibility.Saving, StringWriter, WebAccessibility, Console.WriteLine | Creates or manipulates an HTML document. |

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
