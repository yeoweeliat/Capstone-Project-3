#pragma checksum "C:\Users\might\source\repos\CustomerApp\CustomerApp\Views\Customer\CustomerEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85b6684e2f997c3aa76b13a9b7df2e5d018b1ea4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerEdit), @"mvc.1.0.view", @"/Views/Customer/CustomerEdit.cshtml")]
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
#line 1 "C:\Users\might\source\repos\CustomerApp\CustomerApp\Views\_ViewImports.cshtml"
using CustomerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\might\source\repos\CustomerApp\CustomerApp\Views\_ViewImports.cshtml"
using CustomerApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85b6684e2f997c3aa76b13a9b7df2e5d018b1ea4", @"/Views/Customer/CustomerEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1035fcd16cd1925d44002e818f0d84c97d3a947", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\might\source\repos\CustomerApp\CustomerApp\Views\Customer\CustomerEdit.cshtml"
  
    ViewData["Title"] = "View";

    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>This is the CustomerEdit View</h1>\r\n\r\n\r\nName :- <input type=\"text\" /> <br />\r\nAddress :- <input type=\"text\" /> <br />\r\n<input type=\"button\" value=\"Click\" />\r\n");
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
