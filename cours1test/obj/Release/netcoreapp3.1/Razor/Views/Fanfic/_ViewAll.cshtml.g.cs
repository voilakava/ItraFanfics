#pragma checksum "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c77182356bee2be91cb5554f95ab4f5df0117610"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fanfic__ViewAll), @"mvc.1.0.view", @"/Views/Fanfic/_ViewAll.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c77182356bee2be91cb5554f95ab4f5df0117610", @"/Views/Fanfic/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4c753a3bcd8bc8b8c4fc2eeabfc8cc7f5740f5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Fanfic__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<cours1test.Models.Fanfic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteChapter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"col-md-8 offset-md-2\">\n\n    <h1 class=\"text-center\"><i class=\"fas fa-comments-dollar text-success\"></i> Добавление Главы</h1>\n\n\n    <table class=\"table\">\n        <thead class=\"thead-light\">\n            <tr>\n                <th>\n");
            WriteLiteral("                    <a>Номер главы</a>\n                </th>\n                <th>\n");
            WriteLiteral("                    <a>Название</a>\n                </th>\n                <th>\n");
            WriteLiteral("                    <a>Текст главы</a>\n                </th>\n                <th>\n                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 795, "\"", 928, 4);
            WriteAttributeValue("", 805, "showInPopup(\'", 805, 13, true);
#nullable restore
#line 25 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
WriteAttributeValue("", 818, Url.Action("AddOrEditChapter","Fanfic", new  { @fanficId = Model.ID} ,Context.Request.Scheme), 818, 94, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 912, "\',\'New", 912, 6, true);
            WriteAttributeValue(" ", 918, "Chapter\')", 919, 10, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success text-white\"><i class=\"fas fa-random\"></i> New Chapter</a>\n                </th>\n            </tr>\n        </thead>\n");
#nullable restore
#line 29 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
         if (Model.Chapters != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tbody>\n\n");
#nullable restore
#line 33 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
                 foreach (var item in Model.Chapters)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>\n                            ");
#nullable restore
#line 37 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
                       Write(Html.DisplayFor(modelItem => item.RangeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 40 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 43 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CText));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                        <td>\n                            <div>\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1719, "\"", 1848, 4);
            WriteAttributeValue("", 1729, "showInPopup(\'", 1729, 13, true);
#nullable restore
#line 47 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
WriteAttributeValue("", 1742, Url.Action("AddOrEditChapter", "Fanfic", new { id = item.ID }, Context.Request.Scheme), 1742, 87, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1829, "\',\'Update", 1829, 9, true);
            WriteAttributeValue(" ", 1838, "Chapter\')", 1839, 10, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info text-white\"><i class=\"fas fa-pencil-alt\"></i> Edit</a>\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c77182356bee2be91cb5554f95ab4f5df01176108197", async() => {
                WriteLiteral("\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c77182356bee2be91cb5554f95ab4f5df01176108487", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 49 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item.ID);

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
                WriteLiteral("\n                                    <input type=\"submit\" value=\"Удалить\" class=\"btn btn-danger\" />\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
                                                                   WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            </div>\n                        </td>\n                    </tr>\n");
#nullable restore
#line 55 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \n\n            </tbody>\n");
#nullable restore
#line 59 "/Users/natavoylokova/Desktop/itra/ItraFanfics/cours1test/Views/Fanfic/_ViewAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<cours1test.Models.Fanfic> Html { get; private set; }
    }
}
#pragma warning restore 1591
