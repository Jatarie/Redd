#pragma checksum "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed82fab451eb71e9f5a36e2e7cd78a9697141f4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reddit_DisplayTemplates_RedditComment), @"mvc.1.0.view", @"/Views/Reddit/DisplayTemplates/RedditComment.cshtml")]
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
#nullable restore
#line 2 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed82fab451eb71e9f5a36e2e7cd78a9697141f4d", @"/Views/Reddit/DisplayTemplates/RedditComment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac9157c88f4568e60824f919d2261b0c1e1ea6ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Reddit_DisplayTemplates_RedditComment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RedditComment>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div>\r\n    <a href=\"/reddit/user/\">");
#nullable restore
#line 6 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
                       Write(Model.author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> 62 points ");
#nullable restore
#line 6 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
                                                   Write(Model.createdString);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div>\r\n    ");
#nullable restore
#line 8 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
Write(Model.body);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <span class=\"link-like\"");
            BeginWriteAttribute("id", " id=\"", 219, "\"", 245, 2);
            WriteAttributeValue("", 224, "replybutton-", 224, 12, true);
#nullable restore
#line 11 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
WriteAttributeValue("", 236, Model.id, 236, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Reply</span>\r\n    <div");
            BeginWriteAttribute("id", " id=\"", 269, "\"", 289, 2);
            WriteAttributeValue("", 274, "reply-", 274, 6, true);
#nullable restore
#line 12 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
WriteAttributeValue("", 280, Model.id, 280, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display:none\">\r\n    ");
#nullable restore
#line 13 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
Write(await Html.PartialAsync("_createComment", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <script>\r\n        \r\n    $(\'#replybutton-");
#nullable restore
#line 16 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
               Write(Model.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').click(function() {\r\n        if(\'");
#nullable restore
#line 17 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
       Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' == \"\"){\r\n        $(\'#login-overlay\').css({\r\n            \'display\': \'block\'\r\n        });\r\n\r\n        }\r\n        else{\r\n        $(\'#reply-");
#nullable restore
#line 24 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
             Write(Model.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').css({\r\n            \'display\': \'block\'\r\n        });\r\n        $(\'#textarea-");
#nullable restore
#line 27 "E:\Drive\Programming\RedditClone\AuthBasic\Views\Reddit\DisplayTemplates\RedditComment.cshtml"
                Write(Model.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').focus().val(\"\")\r\n        }\r\n    })\r\n\r\n    </script>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RedditComment> Html { get; private set; }
    }
}
#pragma warning restore 1591