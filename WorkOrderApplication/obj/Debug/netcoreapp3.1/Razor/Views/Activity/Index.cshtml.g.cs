#pragma checksum "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f38d2810f14bb2e1b72d3846b131d5442b79e1ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_Index), @"mvc.1.0.view", @"/Views/Activity/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Activity/Index.cshtml", typeof(AspNetCore.Views_Activity_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38d2810f14bb2e1b72d3846b131d5442b79e1ef", @"/Views/Activity/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13efe7e9ea089ce44c248558b165d23b7f0e3b4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WorkOrderCore.Infrastructure.Persistence.DataContext.JobActivities>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(131, 38, true);
            WriteLiteral("\r\n<h2>Job Activities</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(169, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f38d2810f14bb2e1b72d3846b131d5442b79e1ef4726", async() => {
                BeginContext(216, 15, true);
                WriteLiteral("Create Activity");
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
            BeginContext(235, 477, true);
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
               Business Unit
            </th>
            <th>
                Activity Discription
            </th>
            <th>
                Activity Status
            </th>
            <th>
                Minimum Duration
            </th>
            <th>
                Maximum Duration
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 34 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(761, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(822, 59, false);
#line 38 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.BuninessUnit.Description));

#line default
#line hidden
            EndContext();
            BeginContext(881, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(949, 58, false);
#line 41 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.JobActivityDescriptioin));

#line default
#line hidden
            EndContext();
            BeginContext(1007, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1075, 54, false);
#line 44 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.JobActivitiesStatus));

#line default
#line hidden
            EndContext();
            BeginContext(1129, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1197, 46, false);
#line 47 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MinDuration));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 72, true);
            WriteLiteral(" Days\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1316, 46, false);
#line 50 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MaxDuration));

#line default
#line hidden
            EndContext();
            BeginContext(1362, 72, true);
            WriteLiteral(" Days\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1434, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f38d2810f14bb2e1b72d3846b131d5442b79e1ef9274", async() => {
                BeginContext(1479, 4, true);
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
            BeginContext(1487, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1677, 42, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            EndContext();
#line 58 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Activity\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1730, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WorkOrderCore.Infrastructure.Persistence.DataContext.JobActivities>> Html { get; private set; }
    }
}
#pragma warning restore 1591
