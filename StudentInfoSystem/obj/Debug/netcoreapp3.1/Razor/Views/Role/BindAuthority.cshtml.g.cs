#pragma checksum "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\Role\BindAuthority.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3d3653dd3e8dd8a81d60e356d8b82bbba0658ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_BindAuthority), @"mvc.1.0.view", @"/Views/Role/BindAuthority.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3d3653dd3e8dd8a81d60e356d8b82bbba0658ea", @"/Views/Role/BindAuthority.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5d7c3c9362d3042be4a5416a1caf5f33f7d4dec", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_BindAuthority : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\Role\BindAuthority.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3d3653dd3e8dd8a81d60e356d8b82bbba0658ea3546", async() => {
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <title>BindAuthority</title>
    <link href=""/css/hbes.grid.css"" rel=""stylesheet"" />
    <link href=""/css/hbes.reset.css"" rel=""stylesheet"" />
    <link href=""/css/zTree/zTreeStyle/zTreeStyle.css"" rel=""stylesheet"" />
    <link rel=""stylesheet"" href=""/js/layui/css/layui.css"">
    <script src=""/js/jquery.min.js""></script>
    <script src=""/js/hbes-ui.js""></script>
    <script src=""/js/layui/lay/dest/layui.all.js""></script>
    <script src=""/js/zTree/jquery.ztree.core.min.js""></script>
    <style type=""text/css"">

        /*ztree表格*/
        .ztree {
            padding: 0;
            border: 2px solid #CDD6D5;
        }

            .ztree li a {
                vertical-align: middle;
                height: 30px;
            }

            .ztree li > a {
                width: 100%;
            }

            .ztree li > a,
            .ztree li a.curSelectedNode {
                padding-top: 0px;
                b");
                WriteLiteral(@"ackground: none;
                height: auto;
                border: none;
                cursor: default;
                opacity: 1;
            }

            .ztree li ul {
                padding-left: 0px;
            }

            .ztree div.diy span {
                line-height: 30px;
                vertical-align: middle;
            }

            .ztree div.diy {
                height: 100%;
                line-height: 30px;
                border-top: 1px dotted #ccc;
                border-left: 1px solid #eeeeee;
                text-align: center;
                display: inline-block;
                box-sizing: border-box;
                color: #6c6c6c;
                font-family: ""SimSun"";
                font-size: 12px;
            }

                .ztree div.diy:first-child {
                    text-align: left;
                    text-indent: 10px;
                    border-left: none;
                }

            .ztree .head {
      ");
                WriteLiteral(@"      }

                .ztree .head div.diy {
                    border-top: none;
                    font-family: ""Microsoft YaHei"";
                    font-size: 14px;
                }

        .treetableck {
        }

        .treetablespan {
        }
        /*end--ztree表格*/
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3d3653dd3e8dd8a81d60e356d8b82bbba0658ea6979", async() => {
                WriteLiteral("\r\n    <div id=\"page-content\" class=\"page-content\">\r\n        <input type=\"hidden\" id=\"hid_RoleId\" runat=\"server\"");
                BeginWriteAttribute("value", " value=\"", 2552, "\"", 2575, 1);
#nullable restore
#line 93 "E:\project\2022\直播\StudentSystem\StudentInfoSystem\StudentInfoSystem\Views\Role\BindAuthority.cshtml"
WriteAttributeValue("", 2560, ViewData["id"], 2560, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
        <div style=""max-height:430px;  overflow-y:auto;"">
            <ul id=""dataTree"" class=""ztree"" style=""width:99%;""></ul>
        </div>
        <div class=""bottomBtnDiv"">
            <button class=""layui-btn layui-btn-small layui-btn-normal"" onclick=""save()"" type=""button"">确定</button>
            <button class=""layui-btn layui-btn-small layui-btn-primary"" onclick=""closeWin()"" type=""button"">关闭</button>
        </div>
        <div style=""clear:left;""></div>
    </div>

    <script type=""text/javascript"">
         var authArrayed = new Object();
         $(function () {
             submitData(""/Role/GetRoleAuthority"", { roleId: hid_RoleId.value }, function (data) {

                 if (data != null && data.length > 0) {
                     for (var i = 0 ; i < data.length; i++)
                     {
                         var row = data[i];
                         row.type = ""old"";
                         authArrayed[row.AuthorityId] = row;

                     }
       ");
                WriteLiteral(@"          }

                treeTableBind();
             });
         });
         var zTreeNodes;
         var setting = {
             view: {
                 showLine: false,
                 showIcon: false,
                 addDiyDom: addDiyDom
             },
             data: {
                 key: {
                     name: ""text""
                 },
                 simpleData: {
                     enable: true,
                     idKey: ""id"",//节点绑定的字段(数据库表字段groupid)
                     pIdKey: ""pid""//节点的上级字段(数据库表字段parentid)
                 }
             }
         };
         /**
      * 自定义DOM节点
      */
         function addDiyDom(treeId, treeNode) {
             var spaceWidth = 15;
             var liObj = $(""#"" + treeNode.tId);
             var aObj = $(""#"" + treeNode.tId + ""_a"");
             var switchObj = $(""#"" + treeNode.tId + ""_switch"");
             var icoObj = $(""#"" + treeNode.tId + ""_ico"");
             var spanObj = $(""#"" + treeNode.tId +");
                WriteLiteral(@" ""_span"");


             aObj.attr('title', treeNode.text);
             aObj.append('<div class=""diy swich"" style=""width:35%;""></div>');

             var div = $(liObj).find('div').eq(0);
             switchObj.remove();
             spanObj.remove();
             icoObj.remove();
             div.append(switchObj);
             div.append(spanObj);

             var spaceStr = ""<span style='height:1px;display: inline-block;width:"" + (spaceWidth * treeNode.level) + ""px'></span>"";
             switchObj.before(spaceStr);


             var editStr = '';
             editStr += '<div class=""diy"" style=""width:65%;text-align: left; padding-left:5px; ""> &nbsp;';

             var authArray = treeNode.auth;
             if (authArray.length > 0) {
                 for (var i = 0 ; i < authArray.length; i++) {
                     var auth = authArray[i];
                     var checked = """";

                     if (authArrayed[auth.Id] != null && authArrayed[auth.Id] != undefined)
 ");
                WriteLiteral(@"                    {
                         checked = 'checked=""checked""';
                     };
                     editStr += '<input onclick=""click_cb(this)"" value=""' + auth.Id + '""  class=""authck"" type=""checkbox"" ' + checked + ' style="" float:left;margin-top:10px;margin-right:2px;""  />';
                     editStr += '<span class=""treetablespan"" style="" float:left; margin-top:2px;margin-right:10px;"">' + auth.AuthorityName + '</span>';
                 }
             }
             editStr += '</div>';

             aObj.append(editStr);
         }
         function click_cb(ck) {
             if (ck.checked) {
                 if (authArrayed[ck.value] != undefined && authArrayed[ck.value] != null) {
                     if (authArrayed[ck.value].type == ""old"") {

                     }
                     else if (authArrayed[ck.value].type == ""remove"") {

                         authArrayed[ck.value].type = ""add"";
                     }
                 }
                ");
                WriteLiteral(@" else {
                     authArrayed[ck.value] = { type: ""add"", AuthorityId: ck.value };
                 }
             }
             else {
                 if (authArrayed[ck.value] != undefined && authArrayed[ck.value] != null) {
                     if (authArrayed[ck.value].type == ""old"") {
                         authArrayed[ck.value].type = ""remove"";
                     }
                     else if (authArrayed[ck.value].type == ""remove"") {
                     }
                     else if (authArrayed[ck.value].type == ""add"") {
                         delete authArrayed[ck.value];
                     }
                 }
             }
         }

         function treeTableBind() {
             submitData(""/Menu/GetMenuBindAuthority"", {}, function (data) {
                 //初始化列表
                 zTreeNodes = data;
                 //初始化树
                 $.fn.zTree.init($(""#dataTree""), setting, zTreeNodes);
                 //添加表头
                 var li_head ");
                WriteLiteral(@"= ' <li class=""head""><a><div class=""diy"" style=""width:35%;"">菜单</div><div class=""diy"" style=""width:65%;"">权限</div></li>';
                 var rows = $(""#dataTree"").find('li');

                 if (rows.length > 0) {
                     rows.eq(0).before(li_head)
                 }
                 else {
                     $(""#dataTree"").append(li_head);
                     $(""#dataTree"").append('<li ><div style=""text-align: center;line-height: 30px;"" >无符合条件数据</div></li>')
                 }
             });
         }
         function save() {
             submitData(""/Role/RoleBindAuthority"", { roleId: hid_RoleId.value, data: JSON.stringify(authArrayed) });

         }
    </script>
");
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
