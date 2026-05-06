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
See the root [AGENTS.md](../AGENTS.md) for repository-wide conventions and boundaries.

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
| [Abort Pipeline If Response Status Code 500 Using Error Short Circuit Handler](./abort_pipeline_if_response_status_code_500_using_error_short_circuit_handler.cs) | Abort Pipeline If Response Status Code 500 Using Error Short Circuit Handler | Configuration, Http500AbortHandler, HttpStatusCode.InternalServerError | Creates or manipulates an HTML document. |
| [Add Correlation Id Header To Request Custom Message Handler](./add_correlation_id_header_to_request_custom_message_handler.cs) | Add Correlation Id Header To Request Custom Message Handler | Configuration, CorrelationIdHandler, Guid.NewGuid | Creates or manipulates an HTML document. |
| [Add Custom Error Handling For Network Timeouts Via Timeout Error Handler](./add_custom_error_handling_for_network_timeouts_via_timeout_error_handler.cs) | Add Custom Error Handling For Network Timeouts Via Timeout Error Handler | Request.Timeout, TimeoutHandler, Converters.Converter | Converts HTML content to another format using Aspose.HTML. |
| [Add Custom Handler Retries Failed Network Requests Up To Three Times Before Aborting](./add_custom_handler_retries_failed_network_requests_up_to_three_times_before_aborting.cs) | Add Custom Handler Retries Failed Network Requests Up To Three Times Before Aborting | Configuration, RetryHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [Add Custom Header Conversion Version Response Using Handler](./add_custom_header_conversion_version_response_using_handler.cs) | Add Custom Header Conversion Version Response Using Handler | Converters.Converter, Saving.PdfSaveOptions, Net.MessageHandler | Converts HTML content to another format using Aspose.HTML. |
| [Add Custom Header To Outgoing Requests Using Custom Message Handler](./add_custom_header_to_outgoing_requests_using_custom_message_handler.cs) | Add Custom Header To Outgoing Requests Using Custom Message Handler | Converters.Converter, Request.Headers, Saving.PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Add Custom User Agent String To Outgoing Requests Via Header Injection Handler](./add_custom_user_agent_string_to_outgoing_requests_via_header_injection_handler.cs) | Add Custom User Agent String To Outgoing Requests Via Header Injection Handler | Configuration, PdfSaveOptions, Request.Headers | Converts HTML content to another format using Aspose.HTML. |
| [Add Digest Authentication Support In Credentialhandler By Generating Ha1 Hash From User Credentials](./add_digest_authentication_support_in_credentialhandler_by_generating_ha1_hash_from_user_credentials.cs) | Add Digest Authentication Support In Credentialhandler By Generating Ha1 Hash From User Credentials | Encoding.UTF8, DigestHandler, Net.MessageHandler | Creates or manipulates an HTML document. |
| [Add Handler Strips Query Strings From Urls Before Network Service](./add_handler_strips_query_strings_from_urls_before_network_service.cs) | Add Handler Strips Query Strings From Urls Before Network Service | Configuration, HTMLDocument, Request.RequestUri | Creates or manipulates an HTML document. |
| [Add Startrequestdurationloggingmessagehandler And Stoprequestdurationloggingmessagehandler Capture Http Request Executio](./add_startrequestdurationloggingmessagehandler_and_stoprequestdurationloggingmessagehandler_capture_http_request_executio.cs) | Add Startrequestdurationloggingmessagehandler And Stoprequestdurationloggingmessagehandler Capture Http Request Executio | Configuration, System.Collections, TimeSpan.Zero | Creates or manipulates an HTML document. |
| [Add Start Stop Logging Handlers Around Each Network Request Produce Detailed Performance Reports Per Document](./add_start_stop_logging_handlers_around_each_network_request_produce_detailed_performance_reports_per_document.cs) | Add Start Stop Logging Handlers Around Each Network Request Produce Detailed Performance Reports Per Document | Configuration, System.Collections, RequestStopHandler | Creates or manipulates an HTML document. |
| [Add Timeout Message Handler After Logging Handlers Ensure Timeout Enforcement Last](./add_timeout_message_handler_after_logging_handlers_ensure_timeout_enforcement_last.cs) | Add Timeout Message Handler After Logging Handlers Ensure Timeout Enforcement Last | Configuration, Request.Timeout, TimeoutMessageHandler | Creates or manipulates an HTML document. |
| [Add Timeout Message Handler Five Second Limit Ensure Large Image Downloads Do Not Stall Conversion](./add_timeout_message_handler_five_second_limit_ensure_large_image_downloads_do_not_stall_conversion.cs) | Add Timeout Message Handler Five Second Limit Ensure Large Image Downloads Do Not Stall Conversion | Configuration, Request.Timeout, TimeoutMessageHandler | Converts HTML content to another format using Aspose.HTML. |
| [Batch Process Apply Timeout Message Handler To Html Documents In Directory](./batch_process_apply_timeout_message_handler_to_html_documents_in_directory.cs) | Batch Process Apply Timeout Message Handler To Html Documents In Directory | Configuration, Request.Timeout, Directory.GetFiles | Converts HTML content to another format using Aspose.HTML. |
| [Batch Process Convert Twenty Zip Archives To Jpg Parallel Execution](./batch_process_convert_twenty_zip_archives_to_jpg_parallel_execution.cs) | Batch Process Convert Twenty Zip Archives To Jpg Parallel Execution | System.Threading, Converter.ConvertHTML, Path.GetTempPath | Converts HTML content to another format using Aspose.HTML. |
| [Block External Http Resources Adding Networkdisabledmessagehandler Permits File About Base64 Protocols](./block_external_http_resources_adding_networkdisabledmessagehandler_permits_file_about_base64_protocols.cs) | Block External Http Resources Adding Networkdisabledmessagehandler Permits File About Base64 Protocols | Configuration, Filters.Add, NetworkDisabledMessageHandler | Creates or manipulates an HTML document. |
| [Build Timing Handler Records Start End Timestamps Logs Total Request Duration](./build_timing_handler_records_start_end_timestamps_logs_total_request_duration.cs) | Build Timing Handler Records Start End Timestamps Logs Total Request Duration | Configuration, Time.ToString, System.Diagnostics | Creates or manipulates an HTML document. |
| [Clean Up Temporary Files After Conversion Completes Using Cleanup Handler](./clean_up_temporary_files_after_conversion_completes_using_cleanup_handler.cs) | Clean Up Temporary Files After Conversion Completes Using Cleanup Handler | Console.WriteLine, System.IO, Path.GetTempFileName | Converts HTML content to another format using Aspose.HTML. |
| [Combine Authentication Logging Handlers Pipeline Secure Auditing Requests](./combine_authentication_logging_handlers_pipeline_secure_auditing_requests.cs) | Combine Authentication Logging Handlers Pipeline Secure Auditing Requests | Configuration, LogHandler, Request.RequestUri | Creates or manipulates an HTML document. |
| [Combine Zipfileschemamessagehandler Networkdisabledmessagehandler Safely Load Html From Zip Restricting Protocols](./combine_zipfileschemamessagehandler_networkdisabledmessagehandler_safely_load_html_from_zip_restricting_protocols.cs) | Combine Zipfileschemamessagehandler Networkdisabledmessagehandler Safely Load Html From Zip Restricting Protocols | TimeoutHandler, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [Configure Message Handler Order Zipfileschemamessagehandler Before Logging Handlers Accurate Timing](./configure_message_handler_order_zipfileschemamessagehandler_before_logging_handlers_accurate_timing.cs) | Configure Message Handler Order Zipfileschemamessagehandler Before Logging Handlers Accurate Timing | StringComparison.OrdinalIgnoreCase, Path.GetTempPath, Rendering.Pdf | Creates or manipulates an HTML document. |
| [Configure Networkdisabledmessagehandler Allow About And Base64 Protocols Secure Offline Rendering](./configure_networkdisabledmessagehandler_allow_about_and_base64_protocols_secure_offline_rendering.cs) | Configure Networkdisabledmessagehandler Allow About And Base64 Protocols Secure Offline Rendering | Configuration, HTMLDocument, Rendering.Pdf | Creates or manipulates an HTML document. |
| [Configure Network Timeout Values In Configuration Object And Apply To All Message Handlers](./configure_network_timeout_values_in_configuration_object_and_apply_to_all_message_handlers.cs) | Configure Network Timeout Values In Configuration Object And Apply To All Message Handlers | Configuration, Request.Timeout, TimeoutHandler | Creates or manipulates an HTML document. |
| [Configure Timeout Message Handler Dynamic Timeout Value Based On Requested Resource Size](./configure_timeout_message_handler_dynamic_timeout_value_based_on_requested_resource_size.cs) | Configure Timeout Message Handler Dynamic Timeout Value Based On Requested Resource Size | Configuration, Request.Timeout, DynamicTimeoutMessageHandler | Creates or manipulates an HTML document. |
| [Configure Ziparchive Message Handler Handle Only Html Files Inside Archive](./configure_ziparchive_message_handler_handle_only_html_files_inside_archive.cs) | Configure Ziparchive Message Handler Handle Only Html Files Inside Archive | StringComparison.OrdinalIgnoreCase, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [Configure Zipfileschemamessagehandler Before Other Handlers To Resolve Resources Inside Zip Archive](./configure_zipfileschemamessagehandler_before_other_handlers_to_resolve_resources_inside_zip_archive.cs) | Configure Zipfileschemamessagehandler Before Other Handlers To Resolve Resources Inside Zip Archive | StringComparison.OrdinalIgnoreCase, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [Confirm Credentialhandler Automatically Retries Request After Receiving Authentication Challenge](./confirm_credentialhandler_automatically_retries_request_after_receiving_authentication_challenge.cs) | Confirm Credentialhandler Automatically Retries Request After Receiving Authentication Challenge | Configuration, CredentialHandler, NetworkCredential | Creates or manipulates an HTML document. |
| [Confirm Inserting Credentialhandler Does Not Affect Loading Of Non Protected Html Pages](./confirm_inserting_credentialhandler_does_not_affect_loading_of_non_protected_html_pages.cs) | Confirm Inserting Credentialhandler Does Not Affect Loading Of Non Protected Html Pages | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [Convert Html From Zip To Jpg Using Ziparchivemessagehandler Custom Dpi](./convert_html_from_zip_to_jpg_using_ziparchivemessagehandler_custom_dpi.cs) | Convert Html From Zip To Jpg Using Ziparchivemessagehandler Custom Dpi | Path.GetTempPath, ZipArchiveMode.Read, ImageRenderingOptions | Creates or manipulates an HTML document. |
| [Convert Html From Zip To Pdf Ziparchivemessagehandler Default Settings](./convert_html_from_zip_to_pdf_ziparchivemessagehandler_default_settings.cs) | Convert Html From Zip To Pdf Ziparchivemessagehandler Default Settings | Path.GetTempPath, ZipArchiveMode.Read, FileNotFoundException | Creates or manipulates an HTML document. |
| [Create Batch Process Convert Ten Zip Archives To Pdf Same Pipeline Configuration](./create_batch_process_convert_ten_zip_archives_to_pdf_same_pipeline_configuration.cs) | Create Batch Process Convert Ten Zip Archives To Pdf Same Pipeline Configuration | TimeoutHandler, Path.GetTempPath, Path.GetFileNameWithoutExtension | Creates or manipulates an HTML document. |
| [Create Configuration Add One Second Timeout Message Handler Load Html File](./create_configuration_add_one_second_timeout_message_handler_load_html_file.cs) | Create Configuration Add One Second Timeout Message Handler Load Html File | Configuration, Request.Timeout, OneSecondTimeoutMessageHandler | Creates or manipulates an HTML document. |
| [Create Configuration Disables All Network Requests Except Loading Local Resources](./create_configuration_disables_all_network_requests_except_loading_local_resources.cs) | Create Configuration Disables All Network Requests Except Loading Local Resources | Request.RequestUri, LocalOnlyHandler, Services.INetworkService | Creates or manipulates an HTML document. |
| [Create Configuration Enables Timeout Handling Protocol Filtering Zip Schema Resolution Detailed Request Logging](./create_configuration_enables_timeout_handling_protocol_filtering_zip_schema_resolution_detailed_request_logging.cs) | Create Configuration Enables Timeout Handling Protocol Filtering Zip Schema Resolution Detailed Request Logging | TimeoutHandler, LoggingHandler, Path.GetTempPath | Creates or manipulates an HTML document. |
| [Create Configuration Instance 30 Second Network Timeout All Handlers](./create_configuration_instance_30_second_network_timeout_all_handlers.cs) | Create Configuration Instance 30 Second Network Timeout All Handlers | Configuration, Request.Timeout, TimeoutHandler | Creates or manipulates an HTML document. |
| [Create Configuration Object Retrieve Inetworkservice Attach Custom Authentication Handlers](./create_configuration_object_retrieve_inetworkservice_attach_custom_authentication_handlers.cs) | Create Configuration Object Retrieve Inetworkservice Attach Custom Authentication Handlers | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [Create Configuration Start Stop Duration Logging Handlers Detailed Performance Metrics](./create_configuration_start_stop_duration_logging_handlers_detailed_performance_metrics.cs) | Create Configuration Start Stop Duration Logging Handlers Detailed Performance Metrics | Configuration, System.Collections, StopHandler | Creates or manipulates an HTML document. |
| [Create Credentialhandler Class Inheriting Messagehandler To Manage Http Authentication](./create_credentialhandler_class_inheriting_messagehandler_to_manage_http_authentication.cs) | Create Credentialhandler Class Inheriting Messagehandler To Manage Http Authentication | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [Create Custom Message Handler Logs Request Urls And Execution Times For Each Http Call](./create_custom_message_handler_logs_request_urls_and_execution_times_for_each_http_call.cs) | Create Custom Message Handler Logs Request Urls And Execution Times For Each Http Call | Time.ToString, Request.RequestUri, Services.INetworkService | Creates or manipulates an HTML document. |
| [Create Html Document Instance With Target Url And Custom Configuration Containing Credential Handler](./create_html_document_instance_with_target_url_and_custom_configuration_containing_credential_handler.cs) | Create Html Document Instance With Target Url And Custom Configuration Containing Credential Handler | Configuration, MyCredentialHandler, Service.MessageHandlers | Creates or manipulates an HTML document. |
| [Create Script Processes List Of Zip Files Extracts Html Converts Each To Pdf](./create_script_processes_list_of_zip_files_extracts_html_converts_each_to_pdf.cs) | Create Script Processes List Of Zip Files Extracts Html Converts Each To Pdf | Path.GetTempPath, Path.GetFileNameWithoutExtension, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [Demonstrate Loading Protected Html Page Ntlm Authentication Validate Response Content](./demonstrate_loading_protected_html_page_ntlm_authentication_validate_response_content.cs) | Demonstrate Loading Protected Html Page Ntlm Authentication Validate Response Content | Configuration, HTMLDocument, Header.StartsWith | Creates or manipulates an HTML document. |
| [Demonstrate Loading Protected Html Page Using Basic Authentication And Validate Response Content](./demonstrate_loading_protected_html_page_using_basic_authentication_and_validate_response_content.cs) | Demonstrate Loading Protected Html Page Using Basic Authentication And Validate Response Content | Configuration, BasicAuthHandler, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |
| [Demonstrate Loading Protected Html Page Using Digest Authentication And Validate Response Content](./demonstrate_loading_protected_html_page_using_digest_authentication_and_validate_response_content.cs) | Demonstrate Loading Protected Html Page Using Digest Authentication And Validate Response Content | Auth.Split, DigestAuthHandler, Net.RequestMessage | Creates or manipulates an HTML document. |
| [Demonstrate Loading Protected Html Page Using Kerberos Authentication And Validate Response Content](./demonstrate_loading_protected_html_page_using_kerberos_authentication_and_validate_response_content.cs) | Demonstrate Loading Protected Html Page Using Kerberos Authentication And Validate Response Content | Configuration, KerberosHandler, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |
| [Design Short Circuit Handler Returns Immediate Response When Specific Query Parameter Present](./design_short_circuit_handler_returns_immediate_response_when_specific_query_parameter_present.cs) | Design Short Circuit Handler Returns Immediate Response When Specific Query Parameter Present | Configuration, Request.RequestUri, SkipHandler | Creates or manipulates an HTML document. |
| [Develop Conversion Reads Html Files Applies Logging Handlers Saves Pdfs](./develop_conversion_reads_html_files_applies_logging_handlers_saves_pdfs.cs) | Develop Conversion Reads Html Files Applies Logging Handlers Saves Pdfs | Converters.Converter, Request.RequestUri, Saving.PdfSaveOptions | Converts HTML content to another format using Aspose.HTML. |
| [Develop Custom Schema Handler For Myproto Protocol And Register In Message Handlers Collection](./develop_custom_schema_handler_for_myproto_protocol_and_register_in_message_handlers_collection.cs) | Develop Custom Schema Handler For Myproto Protocol And Register In Message Handlers Collection | Configuration, MyProtoMessageHandler, Filters.Add | Creates or manipulates an HTML document. |
| [Develop Unit Test Verifying Networkdisabledmessagehandler Blocks Disallowed Protocols During Html Loading](./develop_unit_test_verifying_networkdisabledmessagehandler_blocks_disallowed_protocols_during_html_loading.cs) | Develop Unit Test Verifying Networkdisabledmessagehandler Blocks Disallowed Protocols During Html Loading | HTMLDocument, File.WriteAllText, Guid.NewGuid | Creates or manipulates an HTML document. |
| [Enable Kerberos Authentication In Credentialhandler Using Windowsidentity And Ticket Acquisition Mechanisms](./enable_kerberos_authentication_in_credentialhandler_using_windowsidentity_and_ticket_acquisition_mechanisms.cs) | Enable Kerberos Authentication In Credentialhandler Using Windowsidentity And Ticket Acquisition Mechanisms | CredentialCache.DefaultNetworkCredentials, Net.MessageHandler, Net.INetworkOperationContext | Creates or manipulates an HTML document. |
| [Ensure Credentialhandler Inserted At Index Zero Of Messagehandlers Before Creating Htmldocument](./ensure_credentialhandler_inserted_at_index_zero_of_messagehandlers_before_creating_htmldocument.cs) | Ensure Credentialhandler Inserted At Index Zero Of Messagehandlers Before Creating Htmldocument | Configuration, MessageHandlers.Insert, CredentialHandler | Creates or manipulates an HTML document. |
| [Ensure Credentialhandler Processes Authentication Challenges Without Additional Htmldocument Loading Code](./ensure_credentialhandler_processes_authentication_challenges_without_additional_htmldocument_loading_code.cs) | Ensure Credentialhandler Processes Authentication Challenges Without Additional Htmldocument Loading Code | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [Implement Authentication Handler Validates Required Headers Returns Error Response When Missing](./implement_authentication_handler_validates_required_headers_returns_error_response_when_missing.cs) | Implement Authentication Handler Validates Required Headers Returns Error Response When Missing | Request.Headers, Response.StatusCode, Net.MessageHandler | Creates or manipulates an HTML document. |
| [Implement Basic Authentication In Credentialhandler Using Networkcredential Username Password](./implement_basic_authentication_in_credentialhandler_using_networkcredential_username_password.cs) | Implement Basic Authentication In Credentialhandler Using Networkcredential Username Password | Services.INetworkService, DocumentElement.OuterHTML, Net.MessageHandler | Creates or manipulates an HTML document. |
| [Implement Custom Handler Logs Request Urls And Response Status Codes For Debugging](./implement_custom_handler_logs_request_urls_and_response_status_codes_for_debugging.cs) | Implement Custom Handler Logs Request Urls And Response Status Codes For Debugging | Configuration, Request.RequestUri, Response.StatusCode | Creates or manipulates an HTML document. |
| [Implement Custom Protocol Handler For Datauri Scheme Decode Base64 Content Directly Within Html](./implement_custom_protocol_handler_for_datauri_scheme_decode_base64_content_directly_within_html.cs) | Implement Custom Protocol Handler For Datauri Scheme Decode Base64 Content Directly Within Html | Encoding.UTF8, Convert.FromBase64String, Converter.ConvertHTML | Converts HTML content to another format using Aspose.HTML. |
| [Implement Diagnostic Handler Writes Request And Response Headers To Log File Per Network Call](./implement_diagnostic_handler_writes_request_and_response_headers_to_log_file_per_network_call.cs) | Implement Diagnostic Handler Writes Request And Response Headers To Log File Per Network Call | Configuration, Service.MessageHandlers, Request.RequestUri | Creates or manipulates an HTML document. |
| [Implement Idisposable Pattern Custom Handler Release Resources After Processing](./implement_idisposable_pattern_custom_handler_release_resources_after_processing.cs) | Implement Idisposable Pattern Custom Handler Release Resources After Processing | Configuration, GC.SuppressFinalize, Rendering.Pdf | Creates or manipulates an HTML document. |
| [Implement Retry Logic In Credentialhandler To Resend Requests After Authentication Challenge Responses](./implement_retry_logic_in_credentialhandler_to_resend_requests_after_authentication_challenge_responses.cs) | Implement Retry Logic In Credentialhandler To Resend Requests After Authentication Challenge Responses | Configuration, CredentialHandler, Response.StatusCode | Creates or manipulates an HTML document. |
| [Insert Authentication Handler After Logging Enforce Security Checks](./insert_authentication_handler_after_logging_enforce_security_checks.cs) | Insert Authentication Handler After Logging Enforce Security Checks | Configuration, LogHandler, Request.RequestUri | Creates or manipulates an HTML document. |
| [Insert Custom Credentialhandler At Start Of Pipeline Using Configuration](./insert_custom_credentialhandler_at_start_of_pipeline_using_configuration.cs) | Insert Custom Credentialhandler At Start Of Pipeline Using Configuration | Configuration, MessageHandlers.Insert, CredentialHandler | Creates or manipulates an HTML document. |
| [Insert Logging Handlers At Pipeline Start Capture Request Start Times Before Filtering](./insert_logging_handlers_at_pipeline_start_capture_request_start_times_before_filtering.cs) | Insert Logging Handlers At Pipeline Start Capture Request Start Times Before Filtering | Request.RequestUri, Console.WriteLine, Services.INetworkService | Creates or manipulates an HTML document. |
| [Insert Logging Handler Beginning Of Pipeline Capture Request Details](./insert_logging_handler_beginning_of_pipeline_capture_request_details.cs) | Insert Logging Handler Beginning Of Pipeline Capture Request Details | Configuration, StreamWriter, HTMLDocument | Creates or manipulates an HTML document. |
| [Insert Networkdisabledmessagehandler At Pipeline Start Allow Only File Protocol](./insert_networkdisabledmessagehandler_at_pipeline_start_allow_only_file_protocol.cs) | Insert Networkdisabledmessagehandler At Pipeline Start Allow Only File Protocol | Configuration, FileProtocolMessageHandler, Service.MessageHandlers | Creates or manipulates an HTML document. |
| [Insert Ziparchive Message Handler Before Rendering Ensure Resources Resolved Correctly](./insert_ziparchive_message_handler_before_rendering_ensure_resources_resolved_correctly.cs) | Insert Ziparchive Message Handler Before Rendering Ensure Resources Resolved Correctly | TimeoutHandler, Path.GetTempPath, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [Integrate Ntlm Authentication Handling Credentialhandler Configuring Domain Username Password Parameters](./integrate_ntlm_authentication_handling_credentialhandler_configuring_domain_username_password_parameters.cs) | Integrate Ntlm Authentication Handling Credentialhandler Configuring Domain Username Password Parameters | Configuration, Header.StartsWith, CredentialHandler | Creates or manipulates an HTML document. |
| [Load Protected Html Page Require Digest Authentication Verify Automatic Challenge Handling](./load_protected_html_page_require_digest_authentication_verify_automatic_challenge_handling.cs) | Load Protected Html Page Require Digest Authentication Verify Automatic Challenge Handling | Auth.Split, DigestAuthHandler, Response.Headers | Creates or manipulates an HTML document. |
| [Load Protected Html Page Requiring Kerberos Authentication Test Ticket Renewal Functionality](./load_protected_html_page_requiring_kerberos_authentication_test_ticket_renewal_functionality.cs) | Load Protected Html Page Requiring Kerberos Authentication Test Ticket Renewal Functionality | KerberosHandler, Services.INetworkService, Net.MessageHandler | Creates or manipulates an HTML document. |
| [Load Protected Html Page Requiring Ntlm Authentication Credentials Applied](./load_protected_html_page_requiring_ntlm_authentication_credentials_applied.cs) | Load Protected Html Page Requiring Ntlm Authentication Credentials Applied | NtlmHandler, Header.StartsWith, Net.RequestMessage | Creates or manipulates an HTML document. |
| [Load Protected Html Page With Basic Auth Using Networkcredential Credentialhandler](./load_protected_html_page_with_basic_auth_using_networkcredential_credentialhandler.cs) | Load Protected Html Page With Basic Auth Using Networkcredential Credentialhandler | Configuration, NetworkCredential, BasicAuthHandler | Creates or manipulates an HTML document. |
| [Log Conversion Duration Each Zip To Pdf Operation Conversion Timer Handler](./log_conversion_duration_each_zip_to_pdf_operation_conversion_timer_handler.cs) | Log Conversion Duration Each Zip To Pdf Operation Conversion Timer Handler | Timer.Stop, Stopwatch.StartNew, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [Log Request And Response Headers To File Via Dedicated Logging Handler](./log_request_and_response_headers_to_file_via_dedicated_logging_handler.cs) | Log Request And Response Headers To File Via Dedicated Logging Handler | Configuration, Service.MessageHandlers, Request.RequestUri | Creates or manipulates an HTML document. |
| [Log Request Processing Start End Timestamps With Timestamping Handler](./log_request_processing_start_end_timestamps_with_timestamping_handler.cs) | Log Request Processing Start End Timestamps With Timestamping Handler | Configuration, TimestampLoggingHandler, Time.ToString | Creates or manipulates an HTML document. |
| [Measure Pipeline Processing Time Output Console Handler](./measure_pipeline_processing_time_output_console_handler.cs) | Measure Pipeline Processing Time Output Console Handler | Converters.Converter, Request.RequestUri, Rendering.Pdf | Converts HTML content to another format using Aspose.HTML. |
| [Modify Response Content Include Additional Json Metadata Custom Handler](./modify_response_content_include_additional_json_metadata_custom_handler.cs) | Modify Response Content Include Additional Json Metadata Custom Handler | JsonMetadataHandler, Response.Content, JsonNode.Parse | Creates or manipulates an HTML document. |
| [Override Invoke Method Forward Request To Next Handler Unless Condition Triggers Short Circuit](./override_invoke_method_forward_request_to_next_handler_unless_condition_triggers_short_circuit.cs) | Override Invoke Method Forward Request To Next Handler Unless Condition Triggers Short Circuit | Configuration, Net.MessageHandlers, SkipHandler | Creates or manipulates an HTML document. |
| [Place Zipfileschemamessagehandler After Timeout Handler Prioritize Timeout Checks Before Zip Resolution](./place_zipfileschemamessagehandler_after_timeout_handler_prioritize_timeout_checks_before_zip_resolution.cs) | Place Zipfileschemamessagehandler After Timeout Handler Prioritize Timeout Checks Before Zip Resolution | TimeoutHandler, Path.GetTempPath, ZipArchiveMode.Read | Creates or manipulates an HTML document. |
| [Retrieve Inetworkservice From Configuration To Enable Network Operations](./retrieve_inetworkservice_from_configuration_to_enable_network_operations.cs) | Retrieve Inetworkservice From Configuration To Enable Network Operations | Console.WriteLine, Aspose.Html, Configuration | Demonstrates a specific Aspose.HTML operation. |
| [Return 403 Forbidden From Authentication Handler When Api Key Validation Fails](./return_403_forbidden_from_authentication_handler_when_api_key_validation_fails.cs) | Return 403 Forbidden From Authentication Handler When Api Key Validation Fails | Configuration, HttpStatusCode.Forbidden, Request.Headers | Creates or manipulates an HTML document. |
| [Set Global Three Second Timeout Network Requests Pdf Conversion](./set_global_three_second_timeout_network_requests_pdf_conversion.cs) | Set Global Three Second Timeout Network Requests Pdf Conversion | Configuration, Request.Timeout, ThreeSecondTimeoutHandler | Converts HTML content to another format using Aspose.HTML. |
| [Set Jpeg Device Options Quality 85 Rendering Html From Zip To Jpg](./set_jpeg_device_options_quality_85_rendering_html_from_zip_to_jpg.cs) | Set Jpeg Device Options Quality 85 Rendering Html From Zip To Jpg | HTMLDocument, ImageRenderingOptions, ImageFormat.Jpeg | Creates or manipulates an HTML document. |
| [Set Pdf Device Options Embed Fonts Render Html From Zip To Pdf](./set_pdf_device_options_embed_fonts_render_html_from_zip_to_pdf.cs) | Set Pdf Device Options Embed Fonts Render Html From Zip To Pdf | FontEmbedding.Always, Path.GetTempPath, FileNotFoundException | Creates or manipulates an HTML document. |
| [Set Timeout Property Of Timeout Message Handler To Zero Disable Timeout Enforcement Testing](./set_timeout_property_of_timeout_message_handler_to_zero_disable_timeout_enforcement_testing.cs) | Set Timeout Property Of Timeout Message Handler To Zero Disable Timeout Enforcement Testing | Configuration, Request.Timeout, ZeroTimeoutHandler | Creates or manipulates an HTML document. |
| [Test Digest Authentication Handling By Verifying Server Provided Nonce And Response Hash Calculations](./test_digest_authentication_handling_by_verifying_server_provided_nonce_and_response_hash_calculations.cs) | Test Digest Authentication Handling By Verifying Server Provided Nonce And Response Hash Calculations | Auth.Split, DigestAuthHandler, Net.RequestMessage | Creates or manipulates an HTML document. |
| [Transform Xml Response Using Xslt Custom Handler](./transform_xml_response_using_xslt_custom_handler.cs) | Transform Xml Response Using Xslt Custom Handler | Configuration, StringWriter, XmlReader.Create | Converts HTML content to another format using Aspose.HTML. |
| [Use Configuration Object Apply Custom Schema Handler Data Protocol Multiple Conversions](./use_configuration_object_apply_custom_schema_handler_data_protocol_multiple_conversions.cs) | Use Configuration Object Apply Custom Schema Handler Data Protocol Multiple Conversions | Configuration, DataProtocolMessageHandler, Request.RequestUri | Converts HTML content to another format using Aspose.HTML. |
| [Use Protocolmessagefilter Process Http And Https Protocols In Pipeline](./use_protocolmessagefilter_process_http_and_https_protocols_in_pipeline.cs) | Use Protocolmessagefilter Process Http And Https Protocols In Pipeline | Configuration, Net.MessageHandlers, Filters.Add | Creates or manipulates an HTML document. |
| [Use Protocol Message Filter Handle Http And Https Schemes](./use_protocol_message_filter_handle_http_and_https_schemes.cs) | Use Protocol Message Filter Handle Http And Https Schemes | Configuration, Filters.Add, ProtocolMessageFilter | Creates or manipulates an HTML document. |
| [Use Protocol Message Filter Handle Only Http Resources In Conversion Workflow](./use_protocol_message_filter_handle_only_http_resources_in_conversion_workflow.cs) | Use Protocol Message Filter Handle Only Http Resources In Conversion Workflow | Configuration, Net.MessageHandlers, Filters.Add | Creates or manipulates an HTML document. |
| [Use Protocol Message Filter To Exclude File Protocol Resources From Processing In Pipeline](./use_protocol_message_filter_to_exclude_file_protocol_resources_from_processing_in_pipeline.cs) | Use Protocol Message Filter To Exclude File Protocol Resources From Processing In Pipeline | Console.WriteLine, Filters.Add, ProtocolMessageFilter | Creates or manipulates an HTML document. |
| [Validate Credentialhandler Encodes Credentials Basic Authentication Base64](./validate_credentialhandler_encodes_credentials_basic_authentication_base64.cs) | Validate Credentialhandler Encodes Credentials Basic Authentication Base64 | Console.WriteLine, BasicAuthValidator, Request.Headers | Creates or manipulates an HTML document. |
| [Validate Credentialhandler Reuse Multiple Sequential Htmldocument Loads Different Urls](./validate_credentialhandler_reuse_multiple_sequential_htmldocument_loads_different_urls.cs) | Validate Credentialhandler Reuse Multiple Sequential Htmldocument Loads Different Urls | Configuration, CredentialHandler, MessageHandlers.Add | Creates or manipulates an HTML document. |
| [Validate Json Payload In Request Body Using Custom Validation Handler](./validate_json_payload_in_request_body_using_custom_validation_handler.cs) | Validate Json Payload In Request Body Using Custom Validation Handler | Configuration, HTMLDocument, Request.Content | Creates or manipulates an HTML document. |
| [Verify Credentialhandler Correctly Adds Authorization Header Basic Authentication Using Base64](./verify_credentialhandler_correctly_adds_authorization_header_basic_authentication_using_base64.cs) | Verify Credentialhandler Correctly Adds Authorization Header Basic Authentication Using Base64 | System.Console, BasicAuthValidator, Request.Headers | Creates or manipulates an HTML document. |
| [Verify Credentialhandler Correctly Computes Digest Response Using Server Provided Nonce](./verify_credentialhandler_correctly_computes_digest_response_using_server_provided_nonce.cs) | Verify Credentialhandler Correctly Computes Digest Response Using Server Provided Nonce | Configuration, Auth.Split, DigestHandler | Creates or manipulates an HTML document. |
| [Verify Credentialhandler Correctly Formats Ntlm Authentication Messages Protocol Specifications](./verify_credentialhandler_correctly_formats_ntlm_authentication_messages_protocol_specifications.cs) | Verify Credentialhandler Correctly Formats Ntlm Authentication Messages Protocol Specifications | Configuration, Header.StartsWith, Response.StatusCode | Creates or manipulates an HTML document. |
| [Verify Credentialhandler Correctly Obtains And Uses Kerberos Tickets For Authentication](./verify_credentialhandler_correctly_obtains_and_uses_kerberos_tickets_for_authentication.cs) | Verify Credentialhandler Correctly Obtains And Uses Kerberos Tickets For Authentication | Configuration, MessageHandlers.Add, Request.Credentials | Creates or manipulates an HTML document. |
| [Verify Html Document Loads Protected Page Successfully After Credential Handler Processes Authentication](./verify_html_document_loads_protected_page_successfully_after_credential_handler_processes_authentication.cs) | Verify Html Document Loads Protected Page Successfully After Credential Handler Processes Authentication | Configuration, CredentialHandler, DocumentElement.OuterHTML | Creates or manipulates an HTML document. |

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
