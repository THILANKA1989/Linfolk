#pragma checksum "L:\Projects\NetCoreLinfolk\NetCoreLinfolk\Views\Categories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c107631893b200ba239601960a2b8b2be995932"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Index), @"mvc.1.0.view", @"/Views/Categories/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/Index.cshtml", typeof(AspNetCore.Views_Categories_Index))]
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
#line 2 "L:\Projects\NetCoreLinfolk\NetCoreLinfolk\Views\_ViewImports.cshtml"
using NetCoreLinfolk.ModelViews;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c107631893b200ba239601960a2b8b2be995932", @"/Views/Categories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fecd969b43cfefca6b11b3453389705c3d68c1da", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NetCoreLinfolk.Data.Entities.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 95, true);
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h2>Categories</h2>\r\n    </div>\r\n\r\n");
            EndContext();
#line 9 "L:\Projects\NetCoreLinfolk\NetCoreLinfolk\Views\Categories\Index.cshtml"
     foreach (var c in Model)
    {

#line default
#line hidden
            BeginContext(192, 329, true);
            WriteLiteral(@"        <div class=""col-md-4"">
            <div class=""padset-xss"">
                <div class=""border-grey background-lightgrey"">
                    <div class=""centered-block radius-box-xs padset-bottom-xs padset-top-xs"">
                        <h2 class=""text-center cancel-margin""><a href=""#"" class=""cancel-decoration"">");
            EndContext();
            BeginContext(522, 14, false);
#line 15 "L:\Projects\NetCoreLinfolk\NetCoreLinfolk\Views\Categories\Index.cshtml"
                                                                                               Write(c.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(536, 99, true);
            WriteLiteral("</a></h2>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 20 "L:\Projects\NetCoreLinfolk\NetCoreLinfolk\Views\Categories\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(642, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NetCoreLinfolk.Data.Entities.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
