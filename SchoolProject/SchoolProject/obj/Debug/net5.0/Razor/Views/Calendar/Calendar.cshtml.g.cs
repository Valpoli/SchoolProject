#pragma checksum "C:\Users\valpo\OOPgitfinal\SchoolProject\SchoolProject\SchoolProject\Views\Calendar\Calendar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d3a1be0ac9352ef82ffb9dac550376e11a502e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Calendar_Calendar), @"mvc.1.0.view", @"/Views/Calendar/Calendar.cshtml")]
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
#nullable restore
#line 1 "C:\Users\valpo\OOPgitfinal\SchoolProject\SchoolProject\SchoolProject\Views\_ViewImports.cshtml"
using SchoolProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\valpo\OOPgitfinal\SchoolProject\SchoolProject\SchoolProject\Views\_ViewImports.cshtml"
using SchoolProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\valpo\OOPgitfinal\SchoolProject\SchoolProject\SchoolProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\valpo\OOPgitfinal\SchoolProject\SchoolProject\SchoolProject\Views\_ViewImports.cshtml"
using SchoolProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d3a1be0ac9352ef82ffb9dac550376e11a502e0", @"/Views/Calendar/Calendar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dcfa14e3597ce5a338876651fa5f45e7c0428b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Calendar_Calendar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/daypilot/daypilot-all.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\valpo\OOPgitfinal\SchoolProject\SchoolProject\SchoolProject\Views\Calendar\Calendar.cshtml"
   ViewData["Title"] = "Home Page"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d3a1be0ac9352ef82ffb9dac550376e11a502e04265", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 3 "C:\Users\valpo\OOPgitfinal\SchoolProject\SchoolProject\SchoolProject\Views\Calendar\Calendar.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<link href=""icons/style.css"" rel=""stylesheet"" type=""text/css"">

<div class=""wrap"">
    <div class=""left"">
        <div id=""nav""></div>
    </div>
    <div class=""right"">
        <div id=""dp""></div>
    </div>
</div>

<script>var nav = new DayPilot.Navigator(""nav"");
    nav.showMonths = 2;
    nav.skipMonths = 2;
    nav.selectMode = ""week"";
    nav.onTimeRangeSelected = function (args) {
        dp.startDate = args.day;
        dp.update();
        dp.events.load(""/api/events"");
    };
    nav.init();


    var dp = new DayPilot.Calendar(""dp"");
    dp.viewType = ""Week"";
    dp.onTimeRangeSelected = function (args) {
        DayPilot.Modal.prompt(""Create a new event:"", ""Event"").then(function (modal) {
            var dp = args.control;
            dp.clearSelection();
            if (!modal.result) {
                return;
            }
            var params = {
                start: args.start.toString(),
                end: args.end.toString(),
                text: m");
            WriteLiteral(@"odal.result,
                resource: args.resource
            };
            $.ajax({
                type: 'POST',
                url: '/api/events',
                data: JSON.stringify(params),
                success: function (data) {
                    dp.events.add(new DayPilot.Event(data));
                    dp.message(""Event created"");
                },
                contentType: ""application/json"",
                dataType: 'json'
            });
        });
    };
    dp.onEventMove = function (args) {
        var params = {
            id: args.e.id(),
            start: args.newStart.toString(),
            end: args.newEnd.toString()
        };
        $.ajax({
            type: 'PUT',
            url: '/api/events/' + args.e.id() + ""/move"",
            data: JSON.stringify(params),
            success: function (data) {
                dp.message(""Event moved"");
            },
            contentType: ""application/json"",
            dataType: 'json'
    ");
            WriteLiteral(@"    });
    };
    dp.onEventResize = function (args) {
        var params = {
            id: args.e.id(),
            start: args.newStart.toString(),
            end: args.newEnd.toString()
        };
        $.ajax({
            type: 'PUT',
            url: '/api/events/' + args.e.id() + ""/move"",
            data: JSON.stringify(params),
            success: function (data) {
                dp.message(""Event resized"");
            },
            contentType: ""application/json"",
            dataType: 'json'
        });
    };
    dp.onBeforeEventRender = function (args) {
        args.data.barColor = args.data.color;
        args.data.areas = [
            { top: 2, right: 2, icon: ""icon-triangle-down"", visibility: ""Hover"", action: ""ContextMenu"", style: ""font-size: 12px; background-color: #f9f9f9; border: 1px solid #ccc; padding: 2px 2px 0px 2px; cursor:pointer;"" }
        ];
    };
    dp.contextMenu = new DayPilot.Menu({
        items: [
            {
                text: """);
            WriteLiteral(@"Delete"",
                onClick: function (args) {
                    var e = args.source;
                    $.ajax({
                        type: 'DELETE',
                        url: '/api/events/' + e.id(),
                        success: function (data) {
                            dp.events.remove(e);
                            dp.message(""Event deleted"");
                        },
                        contentType: ""application/json"",
                        dataType: 'json'
                    });
                }
            },
            {
                text: ""-""
            },
            {
                text: ""Blue"",
                icon: ""icon icon-blue"",
                color: ""#1066a8"",
                onClick: function (args) { updateColor(args.source, args.item.color); }
            },
            {
                text: ""Green"",
                icon: ""icon icon-green"",
                color: ""#6aa84f"",
                onClick: function (args) { up");
            WriteLiteral(@"dateColor(args.source, args.item.color); }
            },
            {
                text: ""Yellow"",
                icon: ""icon icon-yellow"",
                color: ""#f1c232"",
                onClick: function (args) { updateColor(args.source, args.item.color); }
            },
            {
                text: ""Red"",
                icon: ""icon icon-red"",
                color: ""#cc0000"",
                onClick: function (args) { updateColor(args.source, args.item.color); }
            },

        ]
    });
    dp.init();

    dp.events.load(""/api/events"");</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
