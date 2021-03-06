#pragma checksum "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12e1c1d6587e25b5d248b2857afb4a362e11196d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Enrollments_GetCoursesByStudent), @"mvc.1.0.view", @"/Views/Enrollments/GetCoursesByStudent.cshtml")]
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
#line 1 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\_ViewImports.cshtml"
using UniversityStudentsApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\_ViewImports.cshtml"
using UniversityStudentsApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12e1c1d6587e25b5d248b2857afb4a362e11196d", @"/Views/Enrollments/GetCoursesByStudent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35c6972c1e856c4ea75fe3b28e481dabf2dfa4f5", @"/Views/_ViewImports.cshtml")]
    public class Views_Enrollments_GetCoursesByStudent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Enrollments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetStudentByEnrollmentId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
  
    ViewData["Title"] = "GetCoursesByStudent";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Courses from this student</h3>

<table class=""table"">
    <thead>
        <th> ID </th>
        <th> Title </th>
        <th> Points </th>
        <th> Grade </th>
        <th> ProjectUrl </th>
        <th> SeminarUrl</th>
    </thead>

    <tbody>
");
#nullable restore
#line 19 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
         if(Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
             foreach(var course in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 25 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                   Write(course.Course.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 28 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                   Write(course.Course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                         ");
#nullable restore
#line 31 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                    Write(course.ExamPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral(" +");
#nullable restore
#line 31 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                                        Write(course.ProjectPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral(" + ");
#nullable restore
#line 31 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                                                                Write(course.SeminarPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral(" + ");
#nullable restore
#line 31 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                                                                                        Write(course.AdditionalPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                   Write(course.Grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                   Write(course.ProjectUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                   Write(course.SemonarUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12e1c1d6587e25b5d248b2857afb4a362e11196d8084", async() => {
                WriteLiteral(" Change ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
                                                                                                WriteLiteral(course.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 46 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\bojan\Desktop\.netUniversityPhase2\UniversityStudentsApp\Views\Enrollments\GetCoursesByStudent.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
