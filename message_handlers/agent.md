---
name: message_handlers
description: C# examples for message_handlers using Aspose.HTML for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS – message_handlers

## Persona

You are a C# developer specializing in HTML processing using Aspose.HTML for .NET,
working within the **message_handlers** category.
This folder contains standalone C# examples for message_handlers operations.
See the root [agent.md](../agent.md) for repository-wide conventions and boundaries.

## Scope

- **Category name**: `message_handlers`
- **Total examples**: 98  
- **Typical workflow**:  
  1. **Load** an `HTMLDocument` (or raw HTML string).  
  2. **Bind** any required data or configuration (e.g., `Configuration`, custom handlers).  
  3. **Convert** the document to the target format using `Converters.Converter`.  
  4. **Render / Save** the result (PDF, JPEG, etc.) with the appropriate `Saving` options.  
  Message handlers are inserted into the `Configuration.MessageHandlers` collection to intercept, modify, or short‑circuit network requests and responses during steps 2‑4.

## Required Namespaces

| Namespace                              | Usage (example count) |
|----------------------------------------|-----------------------|
| System                                 | 98 |
| Aspose.Html                            | 97 |
| Aspose.Html.Net                        | 87 |
| Aspose.Html.Services                   | 86 |
| System.IO                              | 22 |
| System.IO.Compression                  | 15 |
| Aspose.Html.Rendering.Pdf              | 15 |
| Aspose.Html.Saving                     | 14 |
| Aspose.Html.Converters                 | 13 |
| System.Net                             | 11 |
| System.Diagnostics                     | 5 |
| Aspose.Html.Net.MessageFilters         | 5 |
| Aspose.Html.Net.MessageHandlers        | 4 |
| System.Collections.Concurrent          | 3 |
| Aspose.Html.Rendering.Image            | 3 |
| System.Collections.Generic             | 3 |
| System.Text                            | 2 |
| System.Text.Json.Nodes                 | 2 |
| System.Security.Cryptography           | 1 |
| System.Linq                            | 1 |
| System.Threading.Tasks                 | 1 |
| System.Text.RegularExpressions          | 1 |
| Aspose.Html.Rendering                  | 1 |
| System.Xml                             | 1 |
| System.Xml.Xsl                         | 1 |

### How to import them

```csharp
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Xsl;

using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Net.MessageHandlers;
```

## Common Code Pattern

```csharp
using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        // 1️⃣ Create a configuration and register required message handlers
        var config = new Configuration();
        config.MessageHandlers.Add(new Http500AbortHandler());          // example handler
        config.MessageHandlers.Add(new LoggingHandler());               // custom logging

        // 2️⃣ Load the HTML document (network or local)
        var document = new HTMLDocument("https://example.com/page.html", config);

        // 3️⃣ Convert the document to PDF (could be JPEG, PNG, etc.)
        var converter = new Converter(document);
        var pdfOptions = new PdfSaveOptions();
        converter.Convert(pdfOptions, "output.pdf");

        // 4️⃣ Optional: write a confirmation to console
        Console.WriteLine("Conversion completed successfully.");
    }
}
```

The pattern above is the backbone of every example in this folder: configure handlers, load a document, perform a conversion, and optionally log or render additional information.

## Frequently Used APIs

| API                                   | Appearances |
|---------------------------------------|-------------|
| Aspose.Html                           | 98 |
| Console.WriteLine                     | 97 |
| HTMLDocument                          | 77 |
| Configuration                         | 71 |
| MessageHandlers.Add                   | 53 |
| System.Net                            | 35 |
| Service.MessageHandlers               | 32 |
| Request.RequestUri                    | 29 |
| StringComparison.OrdinalIgnoreCase    | 28 |
| System.IO                             | 27 |
| Response.StatusCode                   | 25 |
| Net.MessageHandler                    | 22 |
| Net.INetworkOperationContext          | 21 |
| Services.INetworkService              | 20 |
| Request.Credentials                   | 19 |
| Path.Combine                          | 19 |
| Request.Headers                       | 16 |
| Directory.GetFiles                    | 16 |
| Directory.CreateDirectory             | 16 |
| Request.Timeout                       | 15 |

## Files in this folder

| File | Title | Key APIs | Description |
|------|-------|----------|-------------|
| [abort_pipeline_if_response_status_code_500_using_error_short_circuit_handler.cs](./abort_pipeline_if_response_status_code_500_using_error_short_circuit_handler.cs) | Abort_Pipeline_If_Response_Status_Code_500_Using_Error_Short_Circuit_Handler | Configuration, Http500AbortHandler, HttpStatusCode.InternalServerError | Creates or manipulates an HTML document. |
| [add_correlation_id_header_to_request_custom_message_handler.cs](./add_correlation_id_header_to_request_custom_message_handler.cs) | Add_Correlation_Id_Header_To_Request_Custom_Message_Handler | Configuration, CorrelationIdHandler, Guid.NewGuid | Creates or manipulates an HTML document. |
| [add_custom_error_handling_for_network_timeouts_via_timeout_error_handler.cs](./add_custom_error_handling_for_network_timeouts_via_timeout_error_handler.cs) | Add_Custom_Error_Handling_For_Network_Timeouts_Via_Timeout_Error_Handler | Request.Timeout, TimeoutHandler, Converters.Converter | Converts HTML content to another format using Aspose.HTML. |
| [add_custom_handler_retries_failed_network_requests_up_to_three_times_before_aborting.cs](./add_custom_handler_retries_failed_network_requests_up_to_three_times_before_aborting.cs) | Add_Custom_Handler_Retries_Failed_Network_Requests_Up_To_Three_Times_Before_Aborting | Configuration, RetryHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [add_custom_header_conversion_version_response_using_handler.cs](./add_custom_header_conversion_version_response_using_handler.cs) | Add_Custom_Header_Conversion_Version_Response_Using_Handler | Converters.Converter, Saving.PdfSaveOptions, Net.MessageHandler | Converts HTML content to another format using Aspose.HTML. |
| [add_custom_header_to_outgoing_requests_using_custom_message_handler.cs](./add_custom_header_to_outgoing_requests_using_custom_message_handler.cs) | Add_Custom_Header_To_Outgoing_Requests_Using_Custom_Message_Handler | Converters.Converter, Request.Headers, Saving.PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [add_custom_user_agent_string_to_outgoing_requests_via_header_injection_handler.cs](./add_custom_user_agent_string_to_outgoing_requests_via_header_injection_handler.cs) | Add_Custom_User_Agent_String_To_Outgoing_Requests_Via_Header_Injection_Handler | Configuration, PdfSaveOptions, Request.Headers | Converts HTML content to another format using Aspose.HTML. |
| [add_digest_authentication_support_in_credentialhandler_by_generating_ha1_hash_from_user_credentials.cs](./add_digest_authentication_support_in_credentialhandler_by_generating_ha1_hash_from_user_credentials.cs) | Add_Digest_Authentication_Support_In_Credentialhandler_By_Generating_Ha1_Hash_From_User_Credentials | Encoding.UTF8, DigestHandler, Net.MessageHandler | Creates or manipulates an HTML document. |
| [add_handler_strips_query_strings_from_urls_before_network_service.cs](./add_handler_strips_query_strings_from_urls_before_network_service.cs) | Add_Handler_Strips_Query_Strings_From_Urls_Before_Network_Service | Configuration, HTMLDocument, Request.RequestUri | Creates or manipulates an HTML document. |
| [add_startrequestdurationloggingmessagehandler_and_stoprequestdurationloggingmessagehandler_capture_http_request_executio.cs](./add_startrequestdurationloggingmessagehandler_and_stoprequestdurationloggingmessagehandler_capture_http_request_executio.cs) | Add_Startrequestdurationloggingmessagehandler_And_Stoprequestdurationloggingmessagehandler_Capture_Http_Request_Executio | Configuration, System.Collections, TimeSpan.Zero | Creates or manipulates an HTML document. |
| [add_start_stop_logging_handlers_around_each_network_request_produce_detailed_performance_reports_per_document.cs](./add_start_stop_logging_handlers_around_each_network_request_produce_detailed_performance_reports_per_document.cs) | Add_Start_Stop_Logging_Handlers_Around_Each_Network_Request_Produce_Detailed_Performance_Reports_Per_Document | Configuration, System.Collections, RequestStopHandler | Creates or manipulates an HTML document. |
| [add_timeout_message_handler_after_logging_handlers_ensure_timeout_enforcement_last.cs](./add_timeout_message_handler_after_logging_handlers_ensure_timeout_enforcement_last.cs) | Add_Timeout_Message_Handler_After_Logging_Handlers_Ensure_Timeout_Enforcement_Last | Configuration, Request.Timeout, TimeoutMessageHandler | Creates or manipulates an HTML document. |
| [add_timeout_message_handler_five_second_limit_ensure_large_image_downloads_do_not_stall_conversion.cs](./add_timeout_message_handler_five_second_limit_ensure_large_image_downloads_do_not_stall_conversion.cs) | Add_Timeout_Message_Handler_Five_Second_Limit_Ensure_Large_Image_Downloads_Do_Not_Stall_Conversion | Configuration, Request.Timeout, TimeoutMessageHandler | Converts HTML content to another format using Aspose.HTML. |
| [batch_process_apply_timeout_message_handler_to_html_documents_in_directory.cs](./batch_process_apply_timeout_message_handler_to_html_documents_in_directory.cs) | Batch_Process_Apply_Timeout_Message_Handler_To_Html_Documents_In_Directory | Configuration, Request.Timeout, Directory.GetFiles | Converts HTML content to another format using Aspose.HTML. |
| [batch_process_convert_twenty_zip_archives_to_jpg_parallel_execution.cs](./batch_process_convert_twenty_zip_archives_to_jpg_parallel_execution.cs) | Batch_Process_Convert_Twenty_Zip_Archives_To_Jpg_Parallel_Execution | System.Threading, Converter.ConvertHTML, Path.GetTempPath | Converts HTML content to another format using Aspose.HTML. |
| [block_external_http_resources_adding_networkdisabledmessagehandler_permits_file_about_base64_protocols.cs](./block_external_http_resources_adding_networkdisabledmessagehandler_permits_file_about_base64_protocols.cs) | Block_External_Http_Resources_Adding_Networkdisabledmessagehandler_Permits_File_About_Base64_Protocols | Configuration, Filters.Add, NetworkDisabledMessageHandler | Creates or manipulates an HTML document. |
| [build_timing_handler_records_start_end_timestamps_logs_total_request_duration.cs](./build_timing_handler_records_start_end_timestamps_logs_total_request_duration.cs) | Build_Timing_Handler_Records_Start_End_Timestamps_Logs_Total_Request_Duration | Configuration, Time.ToString, System.Diagnostics | Creates or manipulates an HTML document. |
| [clean_up_temporary_files_after_conversion_completes_using_cleanup_handler.cs](./clean_up_temporary_files_after_conversion_completes_using_cleanup_handler.cs) | Clean_Up_Temporary_Files_After_Conversion_Completes_Using_Cleanup_Handler | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [combine_authentication_logging_handlers_pipeline_secure_auditing_requests.cs](./combine_authentication_logging_handlers_pipeline_secure_auditing_requests.cs) | Combine_Authentication_Logging_Handlers_Pipeline_Secure_Auditing_Requests | Configuration, LogHandler, Request.RequestUri | Creates or manipulates an HTML document. |
| [combine_zipfileschemamessagehandler_networkdisabledmessagehandler_safely_load_html_from_zip_restricting_protocols.cs](./combine_zipfileschemamessagehandler_networkdisabledmessagehandler_safely_load_html_from_zip_restricting_protocols.cs) | Combine_Zipfileschemamessagehandler_Networkdisabledmessagehandler_Safely_Load_Html_From_Zip_Restricting_Protocols | TimeoutHandler, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [configure_message_handler_order_zipfileschemamessagehandler_before_logging_handlers_accurate_timing.cs](./configure_message_handler_order_zipfileschemamessagehandler_before_logging_handlers_accurate_timing.cs) | Configure_Message_Handler_Order_Zipfileschemamessagehandler_Before_Logging_Handlers_Accurate_Timing | StringComparison.OrdinalIgnoreCase, Path.GetTempPath, Rendering.Pdf | Creates or manipulates an HTML document. |
| [configure_networkdisabledmessagehandler_allow_about_and_base64_protocols_secure_offline_rendering.cs](./configure_networkdisabledmessagehandler_allow_about_and_base64_protocols_secure_offline_rendering.cs) | Configure_Networkdisabledmessagehandler_Allow_About_And_Base64_Protocols_Secure_Offline_Rendering | Configuration, HTMLDocument, Rendering.Pdf | Creates or manipulates an HTML document. |
| [configure_network_timeout_values_in_configuration_object_and_apply_to_all_message_handlers.cs](./configure_network_timeout_values_in_configuration_object_and_apply_to_all_message_handlers.cs) | Configure_Network_Timeout_Values_In_Configuration_Object_And_Apply_To_All_Message_Handlers | Configuration, Request.Timeout, TimeoutHandler | Creates or manipulates an HTML document. |
| [configure_timeout_message_handler_dynamic_timeout_value_based_on_requested_resource_size.cs](./configure_timeout_message_handler_dynamic_timeout_value_based_on_requested_resource_size.cs) | Configure_Timeout_Message_Handler_Dynamic_Timeout_Value_Based_On_Requested_Resource_Size | Configuration, Request.Timeout, DynamicTimeoutMessageHandler | Creates or manipulates an HTML document. |
| [configure_ziparchive_message_handler_handle_only_html_files_inside_archive.cs](./configure_ziparchive_message_handler_handle_only_html_files_inside_archive.cs) | Configure_Ziparchive_Message_Handler_Handle_Only_Html_Files_Inside_Archive | StringComparison.OrdinalIgnoreCase, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [configure_zipfileschemamessagehandler_before_other_handlers_to_resolve_resources_inside_zip_archive.cs](./configure_zipfileschemamessagehandler_before_other_handlers_to_resolve_resources_inside_zip_archive.cs) | Configure_Zipfileschemamessagehandler_Before_Other_Handlers_To_Resolve_Resources_Inside_Zip_Archive | StringComparison.OrdinalIgnoreCase, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [confirm_credentialhandler_automatically_retries_request_after_receiving_authentication_challenge.cs](./confirm_credentialhandler_automatically_retries_request_after_receiving_authentication_challenge.cs) | Confirm_Credentialhandler_Automatically_Retries_Request_After_Receiving_Authentication_Challenge | Configuration, CredentialHandler, NetworkCredential | Creates or manipulates an HTML document. |
| [confirm_inserting_credentialhandler_does_not_affect_loading_of_non_protected_html_pages.cs](./confirm_inserting_credentialhandler_does_not_affect_loading_of_non_protected_html_pages.cs) | Confirm_Inserting_Credentialhandler_Does_Not_Affect_Loading_Of_Non_Protected_Html_Pages | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [convert_html_from_zip_to_jpg_using_ziparchivemessagehandler_custom_dpi.cs](./convert_html_from_zip_to_jpg_using_ziparchivemessagehandler_custom_dpi.cs) | Convert_Html_From_Zip_To_Jpg_Using_Ziparchivemessagehandler_Custom_Dpi | Path.GetTempPath, ZipArchiveMode.Read, ImageRenderingOptions | Creates or manipulates an HTML document. |
| [convert_html_from_zip_to_pdf_ziparchivemessagehandler_default_settings.cs](./convert_html_from_zip_to_pdf_ziparchivemessagehandler_default_settings.cs) | Convert_Html_From_Zip_To_Pdf_Ziparchivemessagehandler_Default_Settings | Path.GetTempPath, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [create_batch_process_convert_ten_zip_archives_to_pdf_same_pipeline_configuration.cs](./create_batch_process_convert_ten_zip_archives_to_pdf_same_pipeline_configuration.cs) | Create_Batch_Process_Convert_Ten_Zip_Archives_To_Pdf_Same_Pipeline_Configuration | TimeoutHandler, Path.GetTempPath, Path.GetFileNameWithoutExtension | Creates or manipulates an HTML document. |
| [create_configuration_add_one_second_timeout_message_handler_load_html_file.cs](./create_configuration_add_one_second_timeout_message_handler_load_html_file.cs) | Create_Configuration_Add_One_Second_Timeout_Message_Handler_Load_Html_File | Configuration, Request.Timeout, OneSecondTimeoutMessageHandler | Creates or manipulates an HTML document. |
| [create_configuration_disables_all_network_requests_except_loading_local_resources.cs](./create_configuration_disables_all_network_requests_except_loading_local_resources.cs) | Create_Configuration_Disables_All_Network_Requests_Except_Loading_Local_Resources | Request.RequestUri, LocalOnlyHandler, Services.INetworkService | Creates or manipulates an HTML document. |
| [create_configuration_enables_timeout_handling_protocol_filtering_zip_schema_resolution_detailed_request_logging.cs](./create_configuration_enables_timeout_handling_protocol_filtering_zip_schema_resolution_detailed_request_logging.cs) | Create_Configuration_Enables_Timeout_Handling_Protocol_Filtering_Zip_Schema_Resolution_Detailed_Request_Logging | TimeoutHandler, LoggingHandler, Path.GetTempPath | Creates or manipulates an HTML document. |
| [create_configuration_instance_30_second_network_timeout_all_handlers.cs](./create_configuration_instance_30_second_network_timeout_all_handlers.cs) | Create_Configuration_Instance_30_Second_Network_Timeout_All_Handlers | Configuration, Request.Timeout, TimeoutHandler | Creates or manipulates an HTML document. |
| [create_configuration_object_retrieve_inetworkservice_attach_custom_authentication_handlers.cs](./create_configuration_object_retrieve_inetworkservice_attach_custom_authentication_handlers.cs) | Create_Configuration_Object_Retrieve_Inetworkservice_Attach_Custom_Authentication_Handlers | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [create_configuration_start_stop_duration_logging_handlers_detailed_performance_metrics.cs](./create_configuration_start_stop_duration_logging_handlers_detailed_performance_metrics.cs) | Create_Configuration_Start_Stop_Duration_Logging_Handlers_Detailed_Performance_Metrics | Configuration, System.Collections, StopHandler | Creates or manipulates an HTML document. |
| [create_credentialhandler_class_inheriting_messagehandler_to_manage_http_authentication.cs](./create_credentialhandler_class_inheriting_messagehandler_to_manage_http_authentication.cs) | Create_Credentialhandler_Class_Inheriting_Messagehandler_To_Manage_Http_Authentication | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [create_custom_message_handler_logs_request_urls_and_execution_times_for_each_http_call.cs](./create_custom_message_handler_logs_request_urls_and_execution_times_for_each_http_call.cs) | Create_Custom_Message_Handler_Logs_Request_Urls_And_Execution_Times_For_Each_Http_Call | Time.ToString, Request.RequestUri, Services.INetworkService | Creates or manipulates an HTML document. |
| [create_html_document_instance_with_target_url_and_custom_configuration_containing_credential_handler.cs](./create_html_document_instance_with_target_url_and_custom_configuration_containing_credential_handler.cs) | Create_Html_Document_Instance_With_Target_Url_And_Custom_Configuration_Containing_Credential_Handler | Configuration, MyCredentialHandler, Service.MessageHandlers | Creates or manipulates an HTML document. |
| [create_script_processes_list_of_zip_files_extracts_html_converts_each_to_pdf.cs](./create_script_processes_list_of_zip_files_extracts_html_converts_each_to_pdf.cs) | Create_Script_Processes_List_Of_Zip_Files_Extracts_Html_Converts_Each_To_Pdf | Path.GetTempPath, Path.GetFileNameWithoutExtension, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [demonstrate_loading_protected_html_page_ntlm_authentication_validate_response_content.cs](./demonstrate_loading_protected_html_page_ntlm_authentication_validate_response_content.cs) | Demonstrate_Loading_Protected_Html_Page_Ntlm_Authentication_Validate_Response_Content | Configuration, HTMLDocument, Header.StartsWith | Creates or manipulates an HTML document. |
| [demonstrate_loading_protected_html_page_using_basic_authentication_and_validate_response_content.cs](./demonstrate_loading_protected_html_page_using_basic_authentication_and_validate_response_content.cs) | Demonstrate_Loading_Protected_Html_Page_Using_Basic_Authentication_And_Validate_Response_Content | Configuration, BasicAuthHandler, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |
| [demonstrate_loading_protected_html_page_using_digest_authentication_and_validate_response_content.cs](./demonstrate_loading_protected_html_page_using_digest_authentication_and_validate_response_content.cs) | Demonstrate_Loading_Protected_Html_Page_Using_Digest_Authentication_And_Validate_Response_Content | Auth.Split, DigestAuthHandler, Net.RequestMessage | Creates or manipulates an HTML document. |
| [demonstrate_loading_protected_html_page_using_kerberos_authentication_and_validate_response_content.cs](./demonstrate_loading_protected_html_page_using_kerberos_authentication_and_validate_response_content.cs) | Demonstrate_Loading_Protected_Html_Page_Using_Kerberos_Authentication_And_Validate_Response_Content | Configuration, KerberosHandler, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |
| [design_short_circuit_handler_returns_immediate_response_when_specific_query_parameter_present.cs](./design_short_circuit_handler_returns_immediate_response_when_specific_query_parameter_present.cs) | Design_Short_Circuit_Handler_Returns_Immediate_Response_When_Specific_Query_Parameter_Present | Configuration, Request.RequestUri, SkipHandler | Creates or manipulates an HTML document. |
| [develop_conversion_reads_html_files_applies_logging_handlers_saves_pdfs.cs](./develop_conversion_reads_html_files_applies_logging_handlers_saves_pdfs.cs) | Develop_Conversion_Reads_Html_Files_Applies_Logging_Handlers_Saves_Pdfs | Converters.Converter, Request.RequestUri, Saving.PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [develop_custom_schema_handler_for_myproto_protocol_and_register_in_message_handlers_collection.cs](./develop_custom_schema_handler_for_myproto_protocol_and_register_in_message_handlers_collection.cs) | Develop_Custom_Schema_Handler_For_Myproto_Protocol_And_Register_In_Message_Handlers_Collection | Configuration, MyProtoMessageHandler, Filters.Add | Creates or manipulates an HTML document. |
| [develop_unit_test_verifying_networkdisabledmessagehandler_blocks_disallowed_protocols_during_html_loading.cs](./develop_unit_test_verifying_networkdisabledmessagehandler_blocks_disallowed_protocols_during_html_loading.cs) | Develop_Unit_Test_Verifying_Networkdisabledmessagehandler_Blocks_Disallowed_Protocols_During_Html_Loading | HTMLDocument, File.WriteAllText, Guid.NewGuid | Creates or manipulates an HTML document. |
| [enable_kerberos_authentication_in_credentialhandler_using_windowsidentity_and_ticket_acquisition_mechanisms.cs](./enable_kerberos_authentication_in_credentialhandler_using_windowsidentity_and_ticket_acquisition_mechanisms.cs) | Enable_Kerberos_Authentication_In_Credentialhandler_Using_Windowsidentity_And_Ticket_Acquisition_Mechanisms | CredentialCache.DefaultNetworkCredentials, Net.MessageHandler, Net.INetworkOperationContext | Creates or manipulates an HTML document. |
| [ensure_credentialhandler_inserted_at_index_zero_of_messagehandlers_before_creating_htmldocument.cs](./ensure_credentialhandler_inserted_at_index_zero_of_messagehandlers_before_creating_htmldocument.cs) | Ensure_Credentialhandler_Inserted_At_Index_Zero_Of_Messagehandlers_Before_Creating_Htmldocument | Configuration, MessageHandlers.Insert, CredentialHandler | Creates or manipulates an HTML document. |
| [ensure_credentialhandler_processes_authentication_challenges_without_additional_htmldocument_loading_code.cs](./ensure_credentialhandler_processes_authentication_challenges_without_additional_htmldocument_loading_code.cs) | Ensure_Credentialhandler_Processes_Authentication_Challenges_Without_Additional_Htmldocument_Loading_Code | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [implement_authentication_handler_validates_required_headers_returns_error_response_when_missing.cs](./implement_authentication_handler_validates_required_headers_returns_error_response_when_missing.cs) | Implement_Authentication_Handler_Validates_Required_Headers_Returns_Error_Response_When_Missing | Request.Headers, Response.StatusCode, Net.MessageHandler | Creates or manipulates an HTML document. |
| [implement_basic_authentication_in_credentialhandler_using_networkcredential_username_password.cs](./implement_basic_authentication_in_credentialhandler_using_networkcredential_username_password.cs) | Implement_Basic_Authentication_In_Credentialhandler_Using_Networkcredential_Username_Password | Services.INetworkService, DocumentElement.OuterHTML, Net.MessageHandler | Creates or manipulates an HTML document. |
| [implement_custom_handler_logs_request_urls_and_response_status_codes_for_debugging.cs](./implement_custom_handler_logs_request_urls_and_response_status_codes_for_debugging.cs) | Implement_Custom_Handler_Logs_Request_Urls_And_Response_Status_Codes_For_Debugging | Configuration, Request.RequestUri, Response.StatusCode | Creates or manipulates an HTML document. |
| [implement_custom_protocol_handler_for_datauri_scheme_decode_base64_content_directly_within_html.cs](./implement_custom_protocol_handler_for_datauri_scheme_decode_base64_content_directly_within_html.cs) | Implement_Custom_Protocol_Handler_For_Datauri_Scheme_Decode_Base64_Content_Directly_Within_Html | Encoding.UTF8, Convert.FromBase64String, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [implement_diagnostic_handler_writes_request_and_response_headers_to_log_file_per_network_call.cs](./implement_diagnostic_handler_writes_request_and_response_headers_to_log_file_per_network_call.cs) | Implement_Diagnostic_Handler_Writes_Request_And_Response_Headers_To_Log_File_Per_Network_Call | Configuration, Service.MessageHandlers, Request.RequestUri | Creates or manipulates an HTML document. |
| [implement_idisposable_pattern_custom_handler_release_resources_after_processing.cs](./implement_idisposable_pattern_custom_handler_release_resources_after_processing.cs) | Implement_Idisposable_Pattern_Custom_Handler_Release_Resources_After_Processing | Configuration, GC.SuppressFinalize, Rendering.Pdf | Creates or manipulates an HTML document. |
| [implement_retry_logic_in_credentialhandler_to_resend_requests_after_authentication_challenge_responses.cs](./implement_retry_logic_in_credentialhandler_to_resend_requests_after_authentication_challenge_responses.cs) | Implement_Retry_Logic_In_Credentialhandler_To_Resend_Requests_After_Authentication_Challenge_Responses | Configuration, CredentialHandler, Response.StatusCode | Creates or manipulates an HTML document. |
| [insert_authentication_handler_after_logging_enforce_security_checks.cs](./insert_authentication_handler_after_logging_enforce_security_checks.cs) | Insert_Authentication_Handler_After_Logging_Enforce_Security_Checks | Configuration, LogHandler, Request.RequestUri | Creates or manipulates an HTML document. |
| [insert_custom_credentialhandler_at_start_of_pipeline_using_configuration.cs](./insert_custom_credentialhandler_at_start_of_pipeline_using_configuration.cs) | Insert_Custom_Credentialhandler_At_Start_Of_Pipeline_Using_Configuration | Configuration, MessageHandlers.Insert, CredentialHandler | Creates or manipulates an HTML document. |
| [insert_logging_handlers_at_pipeline_start_capture_request_start_times_before_filtering.cs](./insert_logging_handlers_at_pipeline_start_capture_request_start_times_before_filtering.cs) | Insert_Logging_Handlers_At_Pipeline_Start_Capture_Request_Start_Times_Before_Filtering | Request.RequestUri, Console.WriteLine, Services.INetworkService | Creates or manipulates an HTML document. |
| [insert_logging_handler_beginning_of_pipeline_capture_request_details.cs](./insert_logging_handler_beginning_of_pipeline_capture_request_details.cs) | Insert_Logging_Handler_Beginning_Of_Pipeline_Capture_Request_Details | Configuration, StreamWriter, HTMLDocument | Creates or manipulates an HTML document. |
| [insert_networkdisabledmessagehandler_at_pipeline_start_allow_only_file_protocol.cs](./insert_networkdisabledmessagehandler_at_pipeline_start_allow_only_file_protocol.cs) | Insert_Networkdisabledmessagehandler_At_Pipeline_Start_Allow_Only_File_Protocol | Configuration, FileProtocolMessageHandler, Service.MessageHandlers | Creates or manipulates an HTML document. |
| [insert_ziparchive_message_handler_before_rendering_ensure_resources_resolved_correctly.cs](./insert_ziparchive_message_handler_before_rendering_ensure_resources_resolved_correctly.cs) | Insert_Ziparchive_Message_Handler_Before_Rendering_Ensure_Resources_Resolved_Correctly | TimeoutHandler, Path.GetTempPath, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [integrate_ntlm_authentication_handling_credentialhandler_configuring_domain_username_password_parameters.cs](./integrate_ntlm_authentication_handling_credentialhandler_configuring_domain_username_password_parameters.cs) | Integrate_Ntlm_Authentication_Handling_Credentialhandler_Configuring_Domain_Username_Password_Parameters | Configuration, Header.StartsWith, CredentialHandler | Creates or manipulates an HTML document. |
| [load_protected_html_page_require_digest_authentication_verify_automatic_challenge_handling.cs](./load_protected_html_page_require_digest_authentication_verify_automatic_challenge_handling.cs) | Load_Protected_Html_Page_Require_Digest_Authentication_Verify_Automatic_Challenge_Handling | Auth.Split, DigestAuthHandler, Response.Headers | Creates or manipulates an HTML document. |
| [load_protected_html_page_requiring_kerberos_authentication_test_ticket_renewal_functionality.cs](./load_protected_html_page_requiring_kerberos_authentication_test_ticket_renewal_functionality.cs) | Load_Protected_Html_Page_Requiring_Kerberos_Authentication_Test_Ticket_Renewal_Functionality | KerberosHandler, Services.INetworkService, Net.MessageHandler | Creates or manipulates an HTML document. |
| [load_protected_html_page_requiring_ntlm_authentication_credentials_applied.cs](./load_protected_html_page_requiring_ntlm_authentication_credentials_applied.cs) | Load_Protected_Html_Page_Requiring_Ntlm_Authentication_Credentials_Applied | NtlmHandler, Header.StartsWith, Net.RequestMessage | Creates or manipulates an HTML document. |
| [load_protected_html_page_with_basic_auth_using_networkcredential_credentialhandler.cs](./load_protected_html_page_with_basic_auth_using_networkcredential_credentialhandler.cs) | Load_Protected_Html_Page_With_Basic_Auth_Using_Networkcredential_Credentialhandler | Configuration, NetworkCredential, BasicAuthHandler | Creates or manipulates an HTML document. |
| [log_conversion_duration_each_zip_to_pdf_operation_conversion_timer_handler.cs](./log_conversion_duration_each_zip_to_pdf_operation_conversion_timer_handler.cs) | Log_Conversion_Duration_Each_Zip_To_Pdf_Operation_Conversion_Timer_Handler | Timer.Stop, Stopwatch.StartNew, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [log_request_and_response_headers_to_file_via_dedicated_logging_handler.cs](./log_request_and_response_headers_to_file_via_dedicated_logging_handler.cs) | Log_Request_And_Response_Headers_To_File_Via_Dedicated_Logging_Handler | Configuration, Service.MessageHandlers, Request.RequestUri | Creates or manipulates an HTML document. |
| [log_request_processing_start_end_timestamps_with_timestamping_handler.cs](./log_request_processing_start_end_timestamps_with_timestamping_handler.cs) | Log_Request_Processing_Start_End_Timestamps_With_Timestamping_Handler | Configuration, TimestampLoggingHandler, Time.ToString | Creates or manipulates an HTML document. |
| [measure_pipeline_processing_time_output_console_handler.cs](./measure_pipeline_processing_time_output_console_handler.cs) | Measure_Pipeline_Processing_Time_Output_Console_Handler | Converters.Converter, Request.RequestUri, Rendering.Pdf | Converts HTML content to another format using Aspose.HTML. |
| [modify_response_content_include_additional_json_metadata_custom_handler.cs](./modify_response_content_include_additional_json_metadata_custom_handler.cs) | Modify_Response_Content_Include_Additional_Json_Metadata_Custom_Handler | JsonMetadataHandler, Response.Content, JsonNode.Parse | Creates or manipulates an HTML document. |
| [override_invoke_method_forward_request_to_next_handler_unless_condition_triggers_short_circuit.cs](./override_invoke_method_forward_request_to_next_handler_unless_condition_triggers_short_circuit.cs) | Override_Invoke_Method_Forward_Request_To_Next_Handler_Unless_Condition_Triggers_Short_Circuit | Configuration, Net.MessageHandlers, SkipHandler | Creates or manipulates an HTML document. |
| [place_zipfileschemamessagehandler_after_timeout_handler_prioritize_timeout_checks_before_zip_resolution.cs](./place_zipfileschemamessagehandler_after_timeout_handler_prioritize_timeout_checks_before_zip_resolution.cs) | Place_Zipfileschemamessagehandler_After_Timeout_Handler_Prioritize_Timeout_Checks_Before_Zip_Resolution | TimeoutHandler, Path.GetTempPath, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [retrieve_inetworkservice_from_configuration_to_enable_network_operations.cs](./retrieve_inetworkservice_from_configuration_to_enable_network_operations.cs) | Retrieve_Inetworkservice_From_Configuration_To_Enable_Network_Operations | Console.WriteLine, Aspose.Html, Configuration | Demonstrates a specific Aspose.HTML operation. |
| [return_403_forbidden_from_authentication_handler_when_api_key_validation_fails.cs](./return_403_forbidden_from_authentication_handler_when_api_key_validation_fails.cs) | Return_403_Forbidden_From_Authentication_Handler_When_Api_Key_Validation_Fails | Configuration, HttpStatusCode.Forbidden, Request.Headers | Creates or manipulates an HTML document. |
| [set_global_three_second_timeout_network_requests_pdf_conversion.cs](./set_global_three_second_timeout_network_requests_pdf_conversion.cs) | Set_Global_Three_Second_Timeout_Network_Requests_Pdf_Conversion | Configuration, Request.Timeout, ThreeSecondTimeoutHandler | Converts HTML content to another format using Aspose.HTML. |
| [set_jpeg_device_options_quality_85_rendering_html_from_zip_to_jpg.cs](./set_jpeg_device_options_quality_85_rendering_html_from_zip_to_jpg.cs) | Set_Jpeg_Device_Options_Quality_85_Rendering_Html_From_Zip_To_Jpg | HTMLDocument, ImageRenderingOptions, ImageFormat.Jpeg | Creates or manipulates an HTML document. |
| [set_pdf_device_options_embed_fonts_render_html_from_zip_to_pdf.cs](./set_pdf_device_options_embed_fonts_render_html_from_zip_to_pdf.cs) | Set_Pdf_Device_Options_Embed_Fonts_Render_Html_From_Zip_To_Pdf | FontEmbedding.Always, Path.GetTempPath, FileNotFoundException | Creates or manipulates an HTML document. |
| [set_timeout_property_of_timeout_message_handler_to_zero_disable_timeout_enforcement_testing.cs](./set_timeout_property_of_timeout_message_handler_to_zero_disable_timeout_enforcement_testing.cs) | Set_Timeout_Property_Of_Timeout_Message_Handler_To_Zero_Disable_Timeout_Enforcement_Testing | Configuration, Request.Timeout, ZeroTimeoutHandler | Creates or manipulates an HTML document. |
| [test_digest_authentication_handling_by_verifying_server_provided_nonce_and_response_hash_calculations.cs](./test_digest_authentication_handling_by_verifying_server_provided_nonce_and_response_hash_calculations.cs) | Test_Digest_Authentication_Handling_By_Verifying_Server_Provided_Nonce_And_Response_Hash_Calculations | Auth.Split, DigestAuthHandler, Net.RequestMessage | Creates or manipulates an HTML document. |
| [transform_xml_response_using_xslt_custom_handler.cs](./transform_xml_response_using_xslt_custom_handler.cs) | Transform_Xml_Response_Using_Xslt_Custom_Handler | Configuration, StringWriter, XmlReader.Create | Converts HTML content to another format using Aspose.HTML. |
| [use_configuration_object_apply_custom_schema_handler_data_protocol_multiple_conversions.cs](./use_configuration_object_apply_custom_schema_handler_data_protocol_multiple_conversions.cs) | Use_Configuration_Object_Apply_Custom_Schema_Handler_Data_Protocol_Multiple_Conversions | Configuration, DataProtocolMessageHandler, Request.RequestUri | Converts HTML content to another format using Aspose.HTML. |
| [use_protocolmessagefilter_process_http_and_https_protocols_in_pipeline.cs](./use_protocolmessagefilter_process_http_and_https_protocols_in_pipeline.cs) | Use_Protocolmessagefilter_Process_Http_And_Https_Protocols_In_Pipeline | Configuration, Net.MessageHandlers, Filters.Add | Creates or manipulates an HTML document. |
| [use_protocol_message_filter_handle_http_and_https_schemes.cs](./use_protocol_message_filter_handle_http_and_https_schemes.cs) | Use_Protocol_Message_Filter_Handle_Http_And_Https_Schemes | Configuration, Filters.Add, ProtocolMessageFilter | Creates or manipulates an HTML document. |
| [use_protocol_message_filter_handle_only_http_resources_in_conversion_workflow.cs](./use_protocol_message_filter_handle_only_http_resources_in_conversion_workflow.cs) | Use_Protocol_Message_Filter_Handle_Only_Http_Resources_In_Conversion_Workflow | Configuration, Net.MessageHandlers, Filters.Add | Creates or manipulates an HTML document. |
| [use_protocol_message_filter_to_exclude_file_protocol_resources_from_processing_in_pipeline.cs](./use_protocol_message_filter_to_exclude_file_protocol_resources_from_processing_in_pipeline.cs) | Use_Protocol_Message_Filter_To_Exclude_File_Protocol_Resources_From_Processing_In_Pipeline | Console.WriteLine, Filters.Add, ProtocolMessageFilter | Creates or manipulates an HTML document. |
| [validate_credentialhandler_encodes_credentials_basic_authentication_base64.cs](./validate_credentialhandler_encodes_credentials_basic_authentication_base64.cs) | Validate_Credentialhandler_Encodes_Credentials_Basic_Authentication_Base64 | Console.WriteLine, BasicAuthValidator, Request.Headers | Creates or manipulates an HTML document. |
| [validate_credentialhandler_reuse_multiple_sequential_htmldocument_loads_different_urls.cs](./validate_credentialhandler_reuse_multiple_sequential_htmldocument_loads_different_urls.cs) | Validate_Credentialhandler_Reuse_Multiple_Sequential_Htmldocument_Loads_Different_Urls | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [validate_json_payload_in_request_body_using_custom_validation_handler.cs](./validate_json_payload_in_request_body_using_custom_validation_handler.cs) | Validate_Json_Payload_In_Request_Body_Using_Custom_Validation_Handler | Configuration, HTMLDocument, Request.Content | Creates or manipulates an HTML document. |
| [verify_credentialhandler_correctly_adds_authorization_header_basic_authentication_using_base64.cs](./verify_credentialhandler_correctly_adds_authorization_header_basic_authentication_using_base64.cs) | Verify_Credentialhandler_Correctly_Adds_Authorization_Header_Basic_Authentication_Using_Base64 | System.Console, BasicAuthValidator, Request.Headers | Creates or manipulates an HTML document. |
| [verify_credentialhandler_correctly_computes_digest_response_using_server_provided_nonce.cs](./verify_credentialhandler_correctly_computes_digest_response_using_server_provided_nonce.cs) | Verify_Credentialhandler_Correctly_Computes_Digest_Response_Using_Server_Provided_Nonce | Configuration, Auth.Split, DigestHandler | Creates or manipulates an HTML document. |
| [verify_credentialhandler_correctly_formats_ntlm_authentication_messages_protocol_specifications.cs](./verify_credentialhandler_correctly_formats_ntlm_authentication_messages_protocol_specifications.cs) | Verify_Credentialhandler_Correctly_Formats_Ntlm_Authentication_Messages_Protocol_Specifications | Configuration, Header.StartsWith, Response.StatusCode | Creates or manipulates an HTML document. |
| [verify_credentialhandler_correctly_obtains_and_uses_kerberos_tickets_for_authentication.cs](./verify_credentialhandler_correctly_obtains_and_uses_kerberos_tickets_for_authentication.cs) | Verify_Credentialhandler_Correctly_Obtains_And_Uses_Kerberos_Tickets_For_Authentication | Configuration, MessageHandlers.Add, Request.Credentials | Creates or manipulates an HTML document. |
| [verify_html_document_loads_protected_page_successfully_after_credential_handler_processes_authentication.cs](./verify_html_document_loads_protected_page_successfully_after_credential_handler_processes_authentication.cs) | Verify_Html_Document_Loads_Protected_Page_Successfully_After_Credential_Handler_Processes_Authentication | Configuration, CredentialHandler, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |

*All 98 examples are listed above.*

## Category-Specific Tips

### Key API Surface
- **Configuration** – central object for pipeline setup.  
- **MessageHandlers.Add / Insert** – order matters; earlier handlers see raw requests.  
- **Request.Timeout** – global timeout; can be overridden per‑handler.  
- **Response.StatusCode** – useful for short‑circuit or retry logic.  
- **Request.Headers / Response.Headers** – manipulate authentication, correlation IDs, etc.  
- **Services.INetworkService** – underlying network engine; required for custom handlers.  

### Rules
1. **Insert credential‑related handlers at index 0** to guarantee authentication before any network call.  
2. **Place logging handlers early** (usually right after credential handlers) to capture raw request/response data.  
3. **Add timeout handlers after logging** so that timeout enforcement does not hide logged information.  
4. **Protocol‑filter or network‑disable handlers should be the first in the chain** when you need to restrict allowed schemes.  
5. **Always add `ZipFileSchemaMessageHandler` before any rendering handler**; otherwise resources inside archives cannot be resolved.  
6. **Never modify the `Configuration` after an `HTMLDocument` instance has been created** – the document captures the handler collection at construction time.  
7. **Dispose of any `IDisposable` handlers (e.g., file‑based loggers) after conversion** to release file handles.  

## Warnings

- **Template‑binding mismatches** – if a custom handler expects a specific request shape (e.g., query string) and the source HTML does not provide it, the handler may throw or silently skip processing.  
- **Missing resources** – handlers that rewrite URLs (e.g., stripping query strings) can lead to 404s if the server requires those parameters.  
- **File‑path issues** – using relative paths inside ZIP archives or when writing temporary files can cause `FileNotFoundException` on different OSes; prefer `Path.Combine` and `Path.GetTempPath`.  
- **Memory pressure during large conversions** – rendering many high‑resolution images or PDFs in a single process may exceed the .NET GC heap; consider batch processing or explicit `GC.Collect()` after each document.  
- **Handler ordering side‑effects** – placing a `NetworkDisabledMessageHandler` after a handler that needs network access will cause unexpected failures.  

## Guidelines for Adding New Examples

1. **Self‑contained** – the file must compile on its own; include `using` statements, a `Main` method, and any required NuGet references.  
2. **Console logging** – use `Console.WriteLine` to surface configuration, request URLs, status codes, and timing information.  
3. **Follow the common pattern** – create a `Configuration`, add handlers, instantiate `HTMLDocument`, then convert/render.  
4. **Naming convention** – file name in *snake_case*, title in *PascalCase* with words separated by underscores, matching the pattern used in existing examples.  
5. **Update statistics** – after adding a file, increment `total_examples` and, if a new API or namespace appears, add it to the respective tables.  

---