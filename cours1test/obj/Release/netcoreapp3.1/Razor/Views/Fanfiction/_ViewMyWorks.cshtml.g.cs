#pragma checksum "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3074efaa2708feae0a19289b0d008f1474eb4817"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fanfiction__ViewMyWorks), @"mvc.1.0.view", @"/Views/Fanfiction/_ViewMyWorks.cshtml")]
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
#line 1 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/_ViewImports.cshtml"
using cours1test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/_ViewImports.cshtml"
using cours1test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3074efaa2708feae0a19289b0d008f1474eb4817", @"/Views/Fanfiction/_ViewMyWorks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4c753a3bcd8bc8b8c4fc2eeabfc8cc7f5740f5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Fanfiction__ViewMyWorks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<cours1test.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Fanfic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteFanfic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""col-md-8 offset-md-2"">

    <h1 class=""text-center""><i class=""fas fa-comments-dollar text-success""></i> ???????????????????? ??????????</h1>


    <table class=""table"">
        <thead class=""thead-light"">
            <tr>
                <th> 
                    <a>???????????????? ??????????</a>
                </th>
                <th> 
                    <a>?????????? ????????????????</a>
                </th>
                <th>
                    <a>???????????????????? ????????????</a>
                </th>
                <th>
                    <a>???????????????????? ????????????????????????</a>
                </th>

                <th>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3074efaa2708feae0a19289b0d008f1474eb48176041", async() => {
                WriteLiteral("<i class=\"fas fa-random\"></i>?????????????? ?????????? ??????????");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
            WriteLiteral("\n                </th>\n            </tr>\n        </thead>\n");
#nullable restore
#line 30 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
         if (Model.Fanfics != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tbody>\n\n");
#nullable restore
#line 34 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
                 foreach (var fanfic in Model.Fanfics)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>\n                        ");
#nullable restore
#line 38 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
                   Write(Html.DisplayFor(modelItem => fanfic.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 41 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
                   Write(Html.DisplayFor(modelItem => fanfic.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 44 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
                   Write(Html.DisplayFor(modelItem => fanfic.Likes.Count()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 47 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
                   Write(Html.DisplayFor(modelItem => fanfic.Comments.Count()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td> \n                    <td>\n                        <div>\n                            <a class=\"btn btn-info text-white\"><i class=\"fas fa-pencil-alt\"></i> ???????????????????????????? </a>\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3074efaa2708feae0a19289b0d008f1474eb48179755", async() => {
                WriteLiteral("\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3074efaa2708feae0a19289b0d008f1474eb481710041", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 53 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => fanfic.ID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                                <input type=\"submit\" value=\"??????????????\" class=\"btn btn-danger\" />\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
                                                                                      WriteLiteral(fanfic.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        </div>\n                    </td>\n                </tr>\n");
#nullable restore
#line 59 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n            </tbody>\n");
#nullable restore
#line 63 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfiction/_ViewMyWorks.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<cours1test.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
