#pragma checksum "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ac65f23c8db6fbba6d293c65bbf13402fd0b595"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Item_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/Item/Delete.cshtml")]
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
#line 1 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\_ViewImports.cshtml"
using Aunt_Irma_Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\_ViewImports.cshtml"
using Aunt_Irma_Shop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ac65f23c8db6fbba6d293c65bbf13402fd0b595", @"/Areas/Admin/Views/Item/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc50e451908843a148a9c2b792825dc9b8cef0db", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Item_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Aunt_Irma_Shop.Models.Item>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div>\r\n    <div>\r\n        <h3>Are you sure you want to delete this Item?</h3>\r\n        <hr />\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4\">\r\n                <dl>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 17 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 20 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 23 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 26 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.TextAreaFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 30 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.SubCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 33 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayFor(model => model.SubCategory.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 36 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 39 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayFor(model => model.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 42 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 45 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                   Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n            <div class=\"col-3 offset-1\">\r\n");
#nullable restore
#line 50 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                 if (Model.Picture != null)
                {
                    var base64 = Convert.ToBase64String(Model.Picture);
                    var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img");
            BeginWriteAttribute("src", " src=\"", 2003, "\"", 2016, 1);
#nullable restore
#line 54 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
WriteAttributeValue("", 2009, imgsrc, 2009, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\" width:100%;\" />\r\n");
#nullable restore
#line 55 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ac65f23c8db6fbba6d293c65bbf13402fd0b59510525", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0ac65f23c8db6fbba6d293c65bbf13402fd0b59510792", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 64 "C:\Users\erind\source\repos\CrazyuncleFunk\auntirmashop\Aunt Irma Shop\Aunt Irma Shop\Areas\Admin\Views\Item\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

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
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ac65f23c8db6fbba6d293c65bbf13402fd0b59513810", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        tinymce.init({
            selector: 'textarea',
            plugins: ""lists"",
            toolbar: ""undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist"",
            menubar: 'file edit format',
            readonly: 1
        });</script>
    <script>tinymce.init({ selector: 'textarea' });</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Aunt_Irma_Shop.Models.Item> Html { get; private set; }
    }
}
#pragma warning restore 1591
