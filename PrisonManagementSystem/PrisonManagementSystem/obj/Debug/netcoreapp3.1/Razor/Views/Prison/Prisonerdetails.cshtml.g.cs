#pragma checksum "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02101183fa68907e66a39dfa89849dadb765bbe8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prison_Prisonerdetails), @"mvc.1.0.view", @"/Views/Prison/Prisonerdetails.cshtml")]
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
#line 1 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\_ViewImports.cshtml"
using PrisonManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\_ViewImports.cshtml"
using PrisonManagementSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02101183fa68907e66a39dfa89849dadb765bbe8", @"/Views/Prison/Prisonerdetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c1a48e7e8e974c984b00ac9bf172e31b5033ab0", @"/Views/_ViewImports.cshtml")]
    public class Views_Prison_Prisonerdetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreatePrisonerDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_MainNav", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/addPrisoner.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/toastr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
  
    ViewData["Title"] = "Prisoner Info";
    Layout = "~/Views/Shared/_FormsLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"main-container\" id=\"container\">\r\n\r\n    <div class=\"overlay\"></div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "02101183fa68907e66a39dfa89849dadb765bbe84785", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <div class=\"container\">\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 287, "\"", 295, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"Passport-profile\">\r\n                <div class=\"Passport-image\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 413, "\"", 444, 1);
#nullable restore
#line 17 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
WriteAttributeValue("", 419, Model.inMate.PassportURL, 419, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </div>\r\n                <div class=\"Passport-description\">\r\n                    <h4>");
#nullable restore
#line 20 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                   Write(Model.inMate.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 20 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                            Write(Model.inMate.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                </div>
            </div>
            <div class=""row"" style=""padding-top:3rem;"">
                <div class=""col-sm-6"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h5 class=""card-title"">Inmate Name</h5>
                            <p class=""card-text"" style=""text-transform: uppercase;""><b>");
#nullable restore
#line 28 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                  Write(Model.inMate.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> ");
#nullable restore
#line 28 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                                             Write(Model.inMate.OtherName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 28 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                                                                     Write(Model.inMate.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h5 class=""card-title"">Inmate's Gender</h5>
                            <p class=""card-text"">");
#nullable restore
#line 36 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                            Write(Model.inMate.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                        </div>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-6"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h5 class=""card-title"">Date of Birth</h5>
                            <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 47 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                               Write(Model.inMate.DateOfBirth);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h5 class=""card-title"">Date Convicted</h5>
                            <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 55 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                               Write(Model.inMate.DateConvicted);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-6"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h5 class=""card-title"">Date To Complete Jail Time</h5>
                            <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 65 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                               Write(Model.inMate.ExpectedJailTerm);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h5 class=""card-title"">Offence</h5>
                            <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 73 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                               Write(Model.inMate.Offence);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
            </div>
            <div id=""flHorizontalForm"" class=""col-lg-12 layout-spacing"">
                <div class=""statbox widget box box-shadow"">
                    <div class=""widget-header"">
                        <div class=""row"">
                            <div class=""col-xl-12 col-md-12 col-sm-12 col-12"">
                                <h4>Sentence Statement</h4>
                            </div>
                        </div>
                    </div>
                    <div class=""widget-content widget-content-area"">
                        ");
#nullable restore
#line 88 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                   Write(Model.inMate.Sentence);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
            </div>


            <div id=""flBiometricForm"" class=""col-lg-12 layout-spacing"">
                <div class=""statbox widget box box-shadow"">
                    <div class=""widget-header"" style=""padding-bottom:1rem;"">
                        <div class=""row"">
                            <div class=""col-xl-12 col-md-12 col-sm-12 col-12"">
                                <h4>Biometric Information</h4>
                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-sm-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Height</h5>
                                    <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 109 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                       Write(Model.inMate.Height);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" CM</p>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Weight</h5>
                                    <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 117 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                       Write(Model.inMate.Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" CM</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-sm-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Color Of Eye</h5>
                                    <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 127 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                       Write(Model.inMate.ColorOfEye);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id=""flRegistrationForm"" class=""col-lg-12 layout-spacing"">
                <div class=""statbox widget box box-shadow"">
                    <div class=""widget-header"" style=""padding-bottom:1rem;>
                        <div class=""row"">
                            <div class=""col-xl-12 col-md-12 col-sm-12 col-12"">
                                <h4>Other Information</h4>
                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-sm-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Health Conditions</h5>
                                    <p class=""card-text"" style=""te");
            WriteLiteral("xt-transform: uppercase;\">");
#nullable restore
#line 150 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                       Write(Model.inMate.HealthConditions);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-6"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h5 class=""card-title"">Emergency Contact</h5>
                                    <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 158 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                       Write(Model.inMate.EmergencyContact);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h5 class=""card-title"">Description</h5>
                                <p class=""card-text"" style=""text-transform: uppercase;"">");
#nullable restore
#line 167 "C:\Users\DELL\Source\Repos\pms\PrisonManagementSystem\PrisonManagementSystem\Views\Prison\Prisonerdetails.cshtml"
                                                                                   Write(Model.inMate.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("JsScript", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02101183fa68907e66a39dfa89849dadb765bbe819778", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02101183fa68907e66a39dfa89849dadb765bbe820878", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <style>

        .Passport-profile {
            display: grid;
            grid-template-columns: 100%;
            grid-template-areas: ""image"" ""text"";
            border-radius: 10px;
            background: #EFEFEF;
            overflow: hidden;
            padding-top: 2rem;
            background-color: firebrick;
            padding-left: 2rem;
            padding-right: 2rem;
            margin-top: 2rem;
        }

        .Passport-image {
            grid-area: image;
            background-size: cover;
        }

        .Passport-image img {
            width: 100%;
        }

        .Passport-description {
            grid-area: text;
            margin: 20px;
            overflow: hidden;
        }

        .Passport-profile h4 {
            font-size: 18px;
            padding-top: 15px;
        }

        .Passport-description h4 {
            color: white;
            font-family: AvenirLTProRoman;
            font-weight: 400;
            fon");
                WriteLiteral("t-size: 50px;\r\n        }\r\n    </style>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreatePrisonerDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
