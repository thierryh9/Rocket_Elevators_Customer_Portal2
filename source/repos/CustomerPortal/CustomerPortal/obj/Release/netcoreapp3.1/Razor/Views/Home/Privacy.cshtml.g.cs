#pragma checksum "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b19d5498e39df319e2da61adbb01aec55bec2ddd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
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
#line 1 "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\_ViewImports.cshtml"
using CustomerPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\_ViewImports.cshtml"
using CustomerPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b19d5498e39df319e2da61adbb01aec55bec2ddd", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13a5cdee0ef29e0f941e2cbb84bc7b66da6178e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Your products";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <!-- Navbar -->
    <div class=""row"">
        <div class=""col-4"">
            <div class=""list-group"" id=""list-tab"" role=""tablist"">
                <a class=""list-group-item list-group-item-action"" id=""list-settings-list"" data-toggle=""list"" href=""#list-settings"" role=""tab"" aria-controls=""settings"">Customer infos</a>
                <a class=""list-group-item list-group-item-action active"" id=""list-home-list"" data-toggle=""list"" href=""#list-home"" role=""tab"" aria-controls=""home"">Batteries</a>
                <a class=""list-group-item list-group-item-action"" id=""list-profile-list"" data-toggle=""list"" href=""#list-profile"" role=""tab"" aria-controls=""profile"">Columns</a>
                <a class=""list-group-item list-group-item-action"" id=""list-messages-list"" data-toggle=""list"" href=""#list-messages"" role=""tab"" aria-controls=""messages"">Elevators</a>
            </div>
        </div>
        <div class=""col-8"">
            <div class=""tab-content"" id=""nav-tabContent"">
                <div class=""tab-pan");
            WriteLiteral("e fade\" id=\"list-settings\" role=\"tabpanel\" aria-labelledby=\"list-home-list\">");
#nullable restore
#line 17 "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\Home\Privacy.cshtml"
                                                                                                          Write(Html.Raw(ViewBag.Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"tab-pane fade\" id=\"list-home\" role=\"tabpanel\" aria-labelledby=\"list-home-list\">");
#nullable restore
#line 18 "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\Home\Privacy.cshtml"
                                                                                                      Write(Html.Raw(ViewBag.Batteries));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"tab-pane fade\" id=\"list-profile\" role=\"tabpanel\" aria-labelledby=\"list-profile-list\">");
#nullable restore
#line 19 "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\Home\Privacy.cshtml"
                                                                                                            Write(Html.Raw(ViewBag.Columns));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div class=\"tab-pane fade\" id=\"list-messages\" role=\"tabpanel\" aria-labelledby=\"list-messages-list\">");
#nullable restore
#line 20 "C:\Users\Thierry Harvey\source\repos\CustomerPortal\CustomerPortal\Views\Home\Privacy.cshtml"
                                                                                                              Write(Html.Raw(ViewBag.Elevators));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            </div>
        </div>
    </div>
                    
    


    <div>
        <a href=""/Home/Intervention"" class=""btn btn-success"">
            <span class=""btn btn-success""></span> CREATE INTERVENTION
        </a>

    </div>
");
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
