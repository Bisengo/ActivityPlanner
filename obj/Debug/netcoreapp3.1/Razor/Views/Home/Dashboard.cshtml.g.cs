#pragma checksum "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f23580dc9fae31adbf766a68fbe36933054592a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\_ViewImports.cshtml"
using ActivityPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\_ViewImports.cshtml"
using ActivityPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f23580dc9fae31adbf766a68fbe36933054592a6", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c37d158e468d24f980094b39283707157d9ba8be", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Activy>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 class=\"card bg-light text-center\">Welcome To The Activity Center, ");
#nullable restore
#line 3 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                                                                 Write(ViewBag.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\r\n\r\n<table class=\"table-warning table\">\r\n    <thead class=\"bg-dark text-warning\">\r\n        <tr>\r\n            <th>Activity</th>\r\n            <th>Date ");
            WriteLiteral("@ Time</th>\r\n            <th>Duration</th>\r\n            <th>Event Coordinator</th>\r\n            <th>Particpants</th>\r\n            <th>Actions</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 17 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
         foreach(var m in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 547, "\"", 571, 2);
            WriteAttributeValue("", 554, "/show/", 554, 6, true);
#nullable restore
#line 20 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 560, m.ActivyId, 560, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                                           Write(m.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
               Write(m.ActDateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
               Write(m.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 22 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                           Write(m.DurationUnit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
               Write(m.Organizer.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 23 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                                      Write(m.Organizer.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
               Write(m.Attendees.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 26 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                     if(ViewBag.User.UserId == m.Organizer.UserId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 965, "\"", 991, 2);
            WriteAttributeValue("", 972, "/cancel/", 972, 8, true);
#nullable restore
#line 28 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 980, m.ActivyId, 980, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Cancel Activity</a>\r\n");
#nullable restore
#line 29 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                    }
                    else
                    {
                        if(m.Attendees.Any(asc => asc.UserId == ViewBag.User.UserId))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1230, "\"", 1255, 2);
            WriteAttributeValue("", 1237, "/leave/", 1237, 7, true);
#nullable restore
#line 34 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1244, m.ActivyId, 1244, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Leave Activity</a>\r\n");
#nullable restore
#line 35 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1415, "\"", 1439, 2);
            WriteAttributeValue("", 1422, "/join/", 1422, 6, true);
#nullable restore
#line 38 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1428, m.ActivyId, 1428, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Join Activity</a>                           \r\n");
#nullable restore
#line 39 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 43 "C:\Users\kbise\Documents\codingDojo\Csharp_stack\ORM\ActivityPlanner\Views\Home\Dashboard.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n<a href=\"/new\" class=\"btn btn-success\"><b><u>Add New Activity</u></b></a>\r\n\r\n<a href=\"/logout\" class=\"btn btn-danger\"><b><u>Logout</u></b></a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Activy>> Html { get; private set; }
    }
}
#pragma warning restore 1591
