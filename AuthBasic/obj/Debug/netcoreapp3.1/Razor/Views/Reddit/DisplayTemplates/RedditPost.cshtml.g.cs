#pragma checksum "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78454c9153cf4ce4d2fc152172787a7f4563f85a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reddit_DisplayTemplates_RedditPost), @"mvc.1.0.view", @"/Views/Reddit/DisplayTemplates/RedditPost.cshtml")]
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
#line 1 "E:\Drive\Programming\RedditClone\AuthBasic\Views\_ViewImports.cshtml"
using AuthBasic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Drive\Programming\RedditClone\AuthBasic\Views\_ViewImports.cshtml"
using AuthBasic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78454c9153cf4ce4d2fc152172787a7f4563f85a", @"/Views/Reddit/DisplayTemplates/RedditPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac9157c88f4568e60824f919d2261b0c1e1ea6ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Reddit_DisplayTemplates_RedditPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RedditPost>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"post\">\r\n\r\n    <div");
            BeginWriteAttribute("id", " id=\"", 51, "\"", 67, 1);
#nullable restore
#line 5 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
WriteAttributeValue("", 56, Model.name, 56, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 81, "\"", 98, 1);
#nullable restore
#line 6 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
WriteAttributeValue("", 88, Model.url, 88, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 6 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
                        Write(Model.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        <div>\r\n            submitted by <a");
            BeginWriteAttribute("href", " href=\"", 160, "\"", 193, 2);
            WriteAttributeValue("", 167, "/reddit/user/", 167, 13, true);
#nullable restore
#line 8 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
WriteAttributeValue("", 180, Model.author, 180, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 8 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
                                                         Write(Model.author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> ");
#nullable restore
#line 8 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
                                                                           Write(Model.created_string);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        </div>\r\n        <div>\r\n            <span>");
#nullable restore
#line 11 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
             Write(Model.score);

#line default
#line hidden
#nullable disable
            WriteLiteral(" points</span>\r\n            <span><a");
            BeginWriteAttribute("href", " href=\"", 334, "\"", 367, 2);
            WriteAttributeValue("", 341, "/reddit/comments/", 341, 17, true);
#nullable restore
#line 12 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
WriteAttributeValue("", 358, Model.id, 358, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 12 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditPost.cshtml"
                                                  Write(Model.num_comments);

#line default
#line hidden
#nullable disable
            WriteLiteral(" comments</a></span>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RedditPost> Html { get; private set; }
    }
}
#pragma warning restore 1591
