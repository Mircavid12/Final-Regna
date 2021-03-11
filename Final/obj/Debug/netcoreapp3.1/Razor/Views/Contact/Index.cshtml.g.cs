#pragma checksum "C:\Users\Power Electronics\source\repos\Final\Final\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8800cb35b9d87edff86290802df9881e6252954d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\Power Electronics\source\repos\Final\Final\Views\_ViewImports.cshtml"
using Final;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Power Electronics\source\repos\Final\Final\Views\_ViewImports.cshtml"
using Final.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Power Electronics\source\repos\Final\Final\Views\_ViewImports.cshtml"
using Final.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8800cb35b9d87edff86290802df9881e6252954d", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a842fa91ac914b314d21b429e3196d43ef2c1ec2", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Contact>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Power Electronics\source\repos\Final\Final\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Main area start -->
<main>
    <!-- Intro section start -->
    <section id=""particle-canvas-contact"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-lg-12 p-0"">
                    <div class=""header-content text-center"">
                        <canvas id=""canvas"" class=""canvas""></canvas>
                        <h3>Əlaqə</h3>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Intro section end -->
    <!-- Contact section start -->
    <section id=""contact"">
        <div class=""container-fluid"">
            <div class=""row contact-infos"">
                <div class=""col-lg-6"">
                    <div class=""contact-img"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 857, "\"", 882, 2);
            WriteAttributeValue("", 863, "images/", 863, 7, true);
#nullable restore
#line 28 "C:\Users\Power Electronics\source\repos\Final\Final\Views\Contact\Index.cshtml"
WriteAttributeValue("", 870, Model.Image, 870, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 883, "\"", 889, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
                <div class=""col-lg-3 offset-lg-1 mt-5"">
                    <div class=""contact-address"">
                        <i class=""fas fa-map-marker-alt""></i>
                        <p>
                           ");
#nullable restore
#line 35 "C:\Users\Power Electronics\source\repos\Final\Final\Views\Contact\Index.cshtml"
                      Write(Html.Raw(Model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                    <div class=\"contact-mail\">\r\n                        <i class=\"fas fa-envelope\"></i>\r\n                        <p>\r\n                            ");
#nullable restore
#line 41 "C:\Users\Power Electronics\source\repos\Final\Final\Views\Contact\Index.cshtml"
                       Write(Model.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                    <div class=\"contact-phone mt-4\">\r\n                        <i class=\"fas fa-phone-alt\"></i>\r\n                        <p>\r\n                           ");
#nullable restore
#line 47 "C:\Users\Power Electronics\source\repos\Final\Final\Views\Contact\Index.cshtml"
                      Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </p>
                    </div>
                    <div class=""social-links mt-4"">
                        <a href=""#"" class=""twitter""><i class=""fa fa-twitter""></i></a>
                        <a href=""#"" class=""facebook""><i class=""fa fa-facebook""></i></a>
                        <a href=""#"" class=""instagram""><i class=""fa fa-instagram""></i></a>
                        <a href=""#"" class=""google-plus""><i class=""fa fa-google-plus""></i></a>
                        <a href=""#"" class=""linkedin""><i class=""fa fa-linkedin""></i></a>
                    </div>
                </div>
            </div>
            <div class=""row "">
                <div class=""col-lg-12 p-0"">
                    <div class=""full map-section"">
                        <div id=""map"">
                            <div id=""googleMap"" style=""width:100%;height:440px;"">
                                <iframe src=""https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d6078.9310940031055!2d49.8410052!3d40.3");
            WriteLiteral("763735!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x92f42463a7364219!2sAlpha%20Gym!5e0!3m2!1sen!2s!4v1612347715562!5m2!1sen!2s\"\r\n                                        width=\"100%\" height=\"400\" frameborder=\"0\" style=\"border:0;\"");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 2924, "\"", 2942, 0);
            EndWriteAttribute();
            WriteLiteral(@"
                                        aria-hidden=""false"" tabindex=""0""></iframe>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Contact section end -->
    <!-- Google Map -->
    <!-- Google Map -->

</main>
<!-- Main area end -->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591
