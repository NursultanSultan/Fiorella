#pragma checksum "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06ae7afb32e23305b4dcd37a5ecf0ce203c6c71b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminFiorella_Views_Product_Index), @"mvc.1.0.view", @"/Areas/AdminFiorella/Views/Product/Index.cshtml")]
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
#line 1 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\_ViewImports.cshtml"
using Fiorello;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\_ViewImports.cshtml"
using Fiorello.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\_ViewImports.cshtml"
using Fiorello.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06ae7afb32e23305b4dcd37a5ecf0ce203c6c71b", @"/Areas/AdminFiorella/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f25cbc239e8f3e104488d7127235499274a391e7", @"/Areas/AdminFiorella/Views/_ViewImports.cshtml")]
    public class Areas_AdminFiorella_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int count = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-lg-12 grid-margin stretch-card"">
    <div class=""card"">
        <div class=""card-body"">
            <h4 class=""card-title"">Product</h4>
            
                
            <div class=""table-responsive"">
                <table class=""table table-bordered mt-3"">
                    <thead>
                        <tr>
                            <th> # </th>
                            <th> Product name </th>
                            <th> Image </th>
                            <th> Price </th>
                            <th> Count</th>

                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 26 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml"
                         foreach (var pr in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td> ");
#nullable restore
#line 29 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml"
                                Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td> ");
#nullable restore
#line 30 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml"
                                Write(pr.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td> </td>\r\n                                <td> ");
#nullable restore
#line 32 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml"
                                Write(pr.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td> ");
#nullable restore
#line 33 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml"
                                Write(pr.Conut);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                \r\n                            </tr>\r\n");
#nullable restore
#line 36 "D:\ASP.Net core\Fiorello\Fiorello\Areas\AdminFiorella\Views\Product\Index.cshtml"
                            count++;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591