#pragma checksum "F:\.net Project\New folder\Views\Seekers\dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9df67a48f8b1d0e5df9723d8fe3aae7816a938d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seekers_dashboard), @"mvc.1.0.view", @"/Views/Seekers/dashboard.cshtml")]
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
#line 1 "F:\.net Project\New folder\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\.net Project\New folder\Views\_ViewImports.cshtml"
using JobFair;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\.net Project\New folder\Views\_ViewImports.cshtml"
using JobFair.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9df67a48f8b1d0e5df9723d8fe3aae7816a938d", @"/Views/Seekers/dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88829cc0febe61ef1702c2167ea93b1222c3f5fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Seekers_dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JobFair.Models.Seeker>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\.net Project\New folder\Views\Seekers\dashboard.cshtml"
  
    ViewData["Title"] = "Seeker";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome ");
#nullable restore
#line 8 "F:\.net Project\New folder\Views\Seekers\dashboard.cshtml"
                             Write(ViewContext.HttpContext.Request.Cookies["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JobFair.Models.Seeker> Html { get; private set; }
    }
}
#pragma warning restore 1591
