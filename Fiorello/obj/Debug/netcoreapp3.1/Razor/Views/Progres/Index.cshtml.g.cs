#pragma checksum "D:\ASP.Net core\Fiorello\Fiorello\Views\Progres\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38b8a08513cbf62b3cebc3d8c5a08452a97591d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Progres_Index), @"mvc.1.0.view", @"/Views/Progres/Index.cshtml")]
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
#line 1 "D:\ASP.Net core\Fiorello\Fiorello\Views\_ViewImports.cshtml"
using Fiorello;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP.Net core\Fiorello\Fiorello\Views\_ViewImports.cshtml"
using Fiorello.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ASP.Net core\Fiorello\Fiorello\Views\_ViewImports.cshtml"
using Fiorello.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38b8a08513cbf62b3cebc3d8c5a08452a97591d6", @"/Views/Progres/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"decffa2262467382fc21b92705d27a4977a41275", @"/Views/_ViewImports.cshtml")]
    public class Views_Progres_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\ASP.Net core\Fiorello\Fiorello\Views\Progres\Index.cshtml"
  
    ViewData["Title"] = "Progres";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <section id=""progress-title"">
        <div class=""container py-4"">
            <div class=""row py-5"">
                <div class=""col-12"">
                    <h1>Progress Bar</h1>
                </div>
            </div>
        </div>
    </section>
    <section id=""progress"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-6 mt-5"">
                    <div class=""d-flex justify-content-between mb-2"">
                        <span class=""progress-title"">Growing</span>
                        <span>95%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 95%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                    <div class=""d-flex justify-content-between mb-2 mt-3"">
           ");
            WriteLiteral(@"             <span class=""progress-title"">Watering</span>
                        <span>80%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 80%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                    <div class=""d-flex justify-content-between mb-2 mt-3"">
                        <span class=""progress-title"">Furtilizing</span>
                        <span>55%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 55%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                </div>
                <div class");
            WriteLiteral(@"=""col-md-6 mt-5"">
                    <div class=""d-flex justify-content-between mb-2"">
                        <span class=""progress-title"">Growing</span>
                        <span>95%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 95%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                    <div class=""d-flex justify-content-between mb-2 mt-3"">
                        <span class=""progress-title"">Watering</span>
                        <span>80%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 80%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valu");
            WriteLiteral(@"emax=""100""></div>
                    </div>
                    <div class=""d-flex justify-content-between mb-2 mt-3"">
                        <span class=""progress-title"">Furtilizing</span>
                        <span>55%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 55%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                </div>
                <div class=""col-12 mt-5"">
                    <div class=""d-flex justify-content-between mb-2"">
                        <span class=""progress-title"">Growing</span>
                        <span>95%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px; background: black;"">
                        <div class=""progress-bar custom-progress-bar");
            WriteLiteral(@""" role=""progressbar"" style=""width: 95%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                    <div class=""d-flex justify-content-between mb-2 mt-3"">
                        <span class=""progress-title"">Watering</span>
                        <span>80%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px; background: black;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 80%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                    <div class=""d-flex justify-content-between mb-2 mt-3"">
                        <span class=""progress-title"">Furtilizing</span>
                        <span>55%</span>
                    </div>
                    <div class=""progress custom-progress"" style=""height: 4px; background: bla");
            WriteLiteral(@"ck;"">
                        <div class=""progress-bar custom-progress-bar"" role=""progressbar"" style=""width: 55%;""
                             aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</main>

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
