#pragma checksum "C:\Users\towea\source\repos\Thyme1\Thyme1\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13b63829c7961d6a337283e3e64b0692884b38c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 2 "C:\Users\towea\source\repos\Thyme1\Thyme1\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#line 3 "C:\Users\towea\source\repos\Thyme1\Thyme1\Views\_ViewImports.cshtml"
using Thyme1;

#line default
#line hidden
#line 4 "C:\Users\towea\source\repos\Thyme1\Thyme1\Views\_ViewImports.cshtml"
using Thyme1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13b63829c7961d6a337283e3e64b0692884b38c1", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5de6f8dd666c00339935c24a99de697c0a3e2944", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\towea\source\repos\Thyme1\Thyme1\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 2943, true);
            WriteLiteral(@"<style>
        .home-text {
            padding: 70px 0;
            text-align: center;
            font-family: 'Antic';
            font-weight: lighter;
            color: white;
        }
        p {
            margin: 35px 275px 50px 275px;
        }
    .carousel {
        width: 640px;
        height: 360px;
    }

    .carousel-inner {
        width: 100%;
        height: 100%
    }
        </style>

<div class=""home-text"">
    <h2>Take Some Thyme For Your Plants</h2>
    <p>Thyme is here to make sure you take the time to give your plants what they need! Keep track of all the plants in your collection and create custom reminders so that you never miss a watering! Make sure they're well fed too with custom fertilizing reminders. You'll also never forget the last time you watered or fertilized when you log your plant chores each time you do them!</p>
</div>

<div id=""demo"" class=""carousel slide carousel-fade carousel-dark"" data-ride=""carousel""
     style=""max-width: 900px;");
            WriteLiteral(@" margin: 0 auto"">

    <!-- Indicators -->
    <ul class=""carousel-indicators"">
        <li data-bs-target=""#carouselExampleDark"" data-slide-to=""0"" class=""active""></li>
        <li data-bs-target=""#carouselExampleDark"" data-slide-to=""1""></li>
        <li data-bs-target=""#carouselExampleDark"" data-slide-to=""2""></li>
    </ul>

    <!-- The slideshow -->
    <div class=""carousel-inner"">
        <div class=""carousel-item active"">
            <div class=""d-flex justify-content-center w-100 h-100"">
                <img @*class=""center-block""*@ src=""https://cdn.shopify.com/s/files/1/0059/8835/2052/products/Monstera_delisiosa_4_FGT_450x.jpg?v=1612444295"" alt=""Los Angeles"">
            </div>
        </div>
        <div class=""carousel-item"">
            <div class=""d-flex justify-content-center w-100 h-100"">
                <img @*class=""img-fluid""*@ src=""https://images.squarespace-cdn.com/content/v1/5609487be4b035506396fb9c/1596460327915-QBCRZCZEK400VK8C6IWM/ke17ZwdGBToddI8pDm48kKVr1gWRtRuDvfnPPMh");
            WriteLiteral(@"-VDpZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PI8FNs0v8qdtDzqXerqGSo3mUnqdoMzGpoE7ko1tkllA4KMshLAGzx4R3EDFOm1kBS/s181787783377916527_p132_i3_w765.jpeg?format=1000w"" alt=""Chicago"">
            </div>
        </div>
        <div class=""carousel-item"">
            <div class=""d-flex justify-content-center w-100 h-100"">
                <img @*class=""img-fluid""*@ src=""https://www.bostonmagazine.com/wp-content/uploads/sites/2/2019/11/house-plants-feature.jpg"" alt=""New York"">
            </div>
        </div>
    </div>

    <!-- Left and right controls -->
    <a class=""carousel-control-prev"" href=""#demo"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon""></span>
    </a>
    <a class=""carousel-control-next"" href=""#demo"" data-slide=""next"">
        <span class=""carousel-control-next-icon""></span>
    </a>

</div>
");
            EndContext();
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
