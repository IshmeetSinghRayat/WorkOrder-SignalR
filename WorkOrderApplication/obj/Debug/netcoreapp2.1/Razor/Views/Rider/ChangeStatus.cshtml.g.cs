#pragma checksum "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99f574613bdfeb13fdfaa008ae0f74f6bec1eef5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rider_ChangeStatus), @"mvc.1.0.view", @"/Views/Rider/ChangeStatus.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Rider/ChangeStatus.cshtml", typeof(AspNetCore.Views_Rider_ChangeStatus))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99f574613bdfeb13fdfaa008ae0f74f6bec1eef5", @"/Views/Rider/ChangeStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13efe7e9ea089ce44c248558b165d23b7f0e3b4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Rider_ChangeStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WorkOrderCore.Infrastructure.Persistence.DataContext.Lookups>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(75, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
  
    ViewData["Title"] = "ChangeStatus"; 
    Layout = "/Views/Shared/_ClientLayout.csHtml";


#line default
#line hidden
            BeginContext(180, 99, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <h2>Change Transaction Status</h2>\r\n\r\n    <div class=\"col-md-4\">\r\n        ");
            EndContext();
            BeginContext(279, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fcf158ad0ab46399ff67f3355f3812a", async() => {
                BeginContext(345, 4, true);
                WriteLiteral("Back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(353, 125, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<hr />\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4\">\r\n            <div class=\"list-group\">\r\n");
            EndContext();
#line 21 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(543, 69, true);
            WriteLiteral("                    <a class=\"list-group-item list-group-item-action\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 612, "\"", 672, 5);
            WriteAttributeValue("", 622, "TakeAction(\'", 622, 12, true);
#line 23 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
WriteAttributeValue("", 634, item.Alias, 634, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 645, "\',\'", 645, 3, true);
#line 23 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
WriteAttributeValue("", 648, ViewBag.TransactionId, 648, 22, false);

#line default
#line hidden
            WriteAttributeValue("", 670, "\')", 670, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 673, "\"", 689, 1);
#line 23 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
WriteAttributeValue("", 678, item.Alias, 678, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(690, 50, true);
            WriteLiteral(" style=\"cursor:pointer\">\r\n                        ");
            EndContext();
            BeginContext(741, 9, false);
#line 24 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
                   Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(750, 28, true);
            WriteLiteral("\r\n                    </a>\r\n");
            EndContext();
#line 26 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
                }

#line default
#line hidden
            BeginContext(797, 52, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(871, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 33 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
          await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(945, 50, true);
                WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        $(\"#\" + \'");
                EndContext();
                BeginContext(996, 21, false);
#line 37 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
            Write(ViewBag.currentStatus);

#line default
#line hidden
                EndContext();
                BeginContext(1017, 316, true);
                WriteLiteral(@"').addClass(""active"");
    })
    function TakeAction(value, transactionId) {
        $("".list-group a.active"").removeClass('active');
        $(""#"" + value).addClass(""active"");
        var model = {
            Id: transactionId,
            JobCardsTranasctionsStatus: value
        };
        var URL = '");
                EndContext();
                BeginContext(1334, 46, false);
#line 46 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
              Write(Url.Action("ChangeTransactionStatus", "Rider"));

#line default
#line hidden
                EndContext();
                BeginContext(1380, 267, true);
                WriteLiteral(@"';
        $.ajax({
            type: ""POST"",
            url: URL,
            data: JSON.stringify(model),
            dataType: 'JSON',
            contentType: ""application/json"",
            success: function () {
                window.location.href = '");
                EndContext();
                BeginContext(1648, 28, false);
#line 54 "C:\Users\dell\Documents\WorkOrder2.2\WorkOrderApplication\Views\Rider\ChangeStatus.cshtml"
                                   Write(Url.Action("Index", "Rider"));

#line default
#line hidden
                EndContext();
                BeginContext(1676, 156, true);
                WriteLiteral("\';\r\n            },\r\n            error: function (passParams) {\r\n                console.log(passParams);\r\n            }\r\n        });\r\n    }\r\n</script>\r\n    ");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WorkOrderCore.Infrastructure.Persistence.DataContext.Lookups>> Html { get; private set; }
    }
}
#pragma warning restore 1591
