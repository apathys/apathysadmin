#pragma checksum "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a171dedd7d5753a5d13a4e6496ab193f4db52fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_BindRole), @"mvc.1.0.view", @"/Views/User/BindRole.cshtml")]
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
#line 1 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\_ViewImports.cshtml"
using StudentInfoSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\_ViewImports.cshtml"
using StudentInfoSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a171dedd7d5753a5d13a4e6496ab193f4db52fd", @"/Views/User/BindRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5d7c3c9362d3042be4a5416a1caf5f33f7d4dec", @"/Views/_ViewImports.cshtml")]
    public class Views_User_BindRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml"
   

    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a171dedd7d5753a5d13a4e6496ab193f4db52fd3515", async() => {
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <title></title>
    <link href=""/css/hbes.grid.css"" rel=""stylesheet"" />
    <link href=""/css/hbes.reset.css"" rel=""stylesheet"" />
    <link href=""/css/zTree/zTreeStyle/zTreeStyle.css"" rel=""stylesheet"" />
    <link rel=""stylesheet"" href=""/js/layui/css/layui.css"">
    <script src=""/js/jquery.min.js""></script>
    <script src=""/js/hbes-ui.js""></script>
    <script src=""/js/layui/lay/dest/layui.all.js""></script>
    <script src=""/js/zTree/jquery.ztree.core.min.js""></script>
    <style type=""text/css"">
        .role_p {
            float: left;
            height: 20px;
            margin-top: 4px;
            margin-right: 10px;
        }

            .role_p input {
                margin: 0px;
                padding: 0px;
                float: left;
                margin-top: 3px;
            }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a171dedd7d5753a5d13a4e6496ab193f4db52fd5416", async() => {
                WriteLiteral("\r\n    <div id=\"page-content\" class=\"page-content\">\r\n\r\n");
#nullable restore
#line 38 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml"
         foreach (XxsModel.SysBasic.Sys_Role role in (List<XxsModel.SysBasic.Sys_Role>)ViewData["roleList"])
        {
            string check = "";
            foreach (XxsModel.SysBasic.Sys_UserAndRole uar in (List<XxsModel.SysBasic.Sys_UserAndRole>)ViewData["meRoleList"])
            {
                if (uar.RoleId.Equals(role.Id))
                {
                    check = "checked='checked'";
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <p class=\"role_p\"><input type=\"checkbox\" ");
#nullable restore
#line 48 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml"
                                                Write(check);

#line default
#line hidden
#nullable disable
                WriteLiteral(" value=\"");
#nullable restore
#line 48 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml"
                                                              Write(role.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" class=\"role_cb\" /><span>");
#nullable restore
#line 48 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml"
                                                                                                Write(role.RoleName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> </p>\r\n");
#nullable restore
#line 49 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml"

        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    </div>

    <div class=""bottomBtnDiv"">
        <button class=""layui-btn layui-btn-small layui-btn-normal"" onclick=""save()"" type=""button"">确定</button>
        <button class=""layui-btn layui-btn-small layui-btn-primary"" onclick=""closeWin()"" type=""button"">关闭</button>
    </div>
    <script type=""text/javascript"">
       function save()
       {
           var roleIds = """";
           var role_cb = $("".role_cb"");
           if (role_cb != undefined && role_cb.length > 0)
           {
               for (var i = 0 ; i < role_cb.length; i++)
               {
                   if (role_cb[i].checked)
                   {
                       roleIds += role_cb[i].value+"","";
                   }
               }

           }
           if (roleIds.trim() != """")
           {
               roleIds = roleIds.substring(0, roleIds.length - 1);
           }

           var userId = """);
#nullable restore
#line 80 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\User\BindRole.cshtml"
                    Write(ViewData["userId"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n           var postData = { userId: userId, roleIds: roleIds };\r\n           submitData(\"/User/BindRoleHandler\", postData);\r\n       }\r\n\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
