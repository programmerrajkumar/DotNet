#pragma checksum "C:\Users\rajkumar.s\source\repos\DotNetCoreFundamentals\ExceptionHandlingFeature\Pages\ErrorStatusCodeRedirect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61cf71b0e1bd02d8e7d78cd863af809f3c82b88a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ExceptionHandlingFeature.Pages.Pages_ErrorStatusCodeRedirect), @"mvc.1.0.razor-page", @"/Pages/ErrorStatusCodeRedirect.cshtml")]
namespace ExceptionHandlingFeature.Pages
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
#line 1 "C:\Users\rajkumar.s\source\repos\DotNetCoreFundamentals\ExceptionHandlingFeature\Pages\_ViewImports.cshtml"
using ExceptionHandlingFeature;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61cf71b0e1bd02d8e7d78cd863af809f3c82b88a", @"/Pages/ErrorStatusCodeRedirect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e1cbc45b9ff4f687a9c35eaa2dd9cff305d96db", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ErrorStatusCodeRedirect : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\nError ");
#nullable restore
#line 6 "C:\Users\rajkumar.s\source\repos\DotNetCoreFundamentals\ExceptionHandlingFeature\Pages\ErrorStatusCodeRedirect.cshtml"
 Write(Model.ErrorStatusCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" . \r\n");
#nullable restore
#line 7 "C:\Users\rajkumar.s\source\repos\DotNetCoreFundamentals\ExceptionHandlingFeature\Pages\ErrorStatusCodeRedirect.cshtml"
Write(Model.ErrorMessage);

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExceptionHandlingFeature.Pages.ErrorStatusCodeRedirectModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ExceptionHandlingFeature.Pages.ErrorStatusCodeRedirectModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ExceptionHandlingFeature.Pages.ErrorStatusCodeRedirectModel>)PageContext?.ViewData;
        public ExceptionHandlingFeature.Pages.ErrorStatusCodeRedirectModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
