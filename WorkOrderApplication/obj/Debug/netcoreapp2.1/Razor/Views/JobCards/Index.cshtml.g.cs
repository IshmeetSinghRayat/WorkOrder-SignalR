#pragma checksum "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52738e1bdf2f6f5e998c2a82bdd1ea21187cdc10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_JobCards_Index), @"mvc.1.0.view", @"/Views/JobCards/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/JobCards/Index.cshtml", typeof(AspNetCore.Views_JobCards_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\_ViewImports.cshtml"
using WorkOrderApplication;

#line default
#line hidden
#line 2 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\_ViewImports.cshtml"
using WorkOrderApplication.Models;

#line default
#line hidden
#line 3 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52738e1bdf2f6f5e998c2a82bdd1ea21187cdc10", @"/Views/JobCards/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13efe7e9ea089ce44c248558b165d23b7f0e3b4b", @"/Views/_ViewImports.cshtml")]
    public class Views_JobCards_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WorkOrderCore.Infrastructure.Persistence.DataContext.JobCards>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(83, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(126, 33, true);
            WriteLiteral("\r\n<h2>Job Cards</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(159, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3628db11ef748f78b3dad859de7d953", async() => {
                BeginContext(206, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(220, 466, true);
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Business Unit Name
            </th>
            <th>
                Job Description
            </th>
            <th>
                Job Duration
            </th>
            <th>
                Job Status
            </th>
            <th>
                Creation Date
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 34 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(735, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(796, 37, false);
#line 38 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(833, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(901, 49, false);
#line 41 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.JobDescription));

#line default
#line hidden
            EndContext();
            BeginContext(950, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1018, 46, false);
#line 44 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.JobDuration));

#line default
#line hidden
            EndContext();
            BeginContext(1064, 72, true);
            WriteLiteral(" Days\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1137, 44, false);
#line 47 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.JobStatus));

#line default
#line hidden
            EndContext();
            BeginContext(1181, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1249, 47, false);
#line 50 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CreationDate));

#line default
#line hidden
            EndContext();
            BeginContext(1296, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1363, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30bd8d8bbd924ec599773440bdc920dc", async() => {
                BeginContext(1408, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1416, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1438, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0968ea49be4f49fa871a411c83377925", async() => {
                BeginContext(1509, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1520, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1542, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6d0b76c8fe34594a55104b780fa56b2", async() => {
                BeginContext(1588, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1598, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 58 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\JobCards\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1653, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WorkOrderCore.Infrastructure.Persistence.DataContext.JobCards>> Html { get; private set; }
    }
}
#pragma warning restore 1591
