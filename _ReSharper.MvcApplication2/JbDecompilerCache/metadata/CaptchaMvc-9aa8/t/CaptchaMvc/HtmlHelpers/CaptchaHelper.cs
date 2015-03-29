// Type: CaptchaMvc.HtmlHelpers.CaptchaHelper
// Assembly: CaptchaMvc, Version=2.5.0.0, Culture=neutral, PublicKeyToken=fe46ad421dd3b0e6
// Assembly location: C:\Users\user\Desktop\MvcApplication2-2014-12-03\MvcApplication2\packages\CaptchaMvc.Mvc4.1.5.0\lib\net40-full\CaptchaMvc.dll

using CaptchaMvc.Interface;
using CaptchaMvc.Models;
using JetBrains.Annotations;
using System.Web.Mvc;

namespace CaptchaMvc.HtmlHelpers
{
    /// <summary>
    /// Provides extension methods to work with a captcha.
    /// 
    /// </summary>
    public static class CaptchaHelper
    {
        /// <summary>
        /// Creates a new captcha with the specified arguments.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="length">The specified length of characters.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha Captcha(this HtmlHelper htmlHelper, int length, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new captcha with the specified arguments.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="refreshText">The specified refresh button text.</param><param name="inputText">The specified input text.</param><param name="length">The specified length of characters.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha Captcha(this HtmlHelper htmlHelper, string refreshText, string inputText, int length, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new captcha with the specified arguments.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="refreshText">The specified refresh button text.</param><param name="inputText">The specified input text.</param><param name="length">The specified length of characters.</param><param name="requiredMessageText">The specified required message text.</param><param name="addValidationSpan">If <c>true</c> add a span for validation; otherwise <c>false</c>.
        ///             </param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha Captcha(this HtmlHelper htmlHelper, string refreshText, string inputText, int length, string requiredMessageText, bool addValidationSpan = false, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new captcha with the specified partial view.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="length">The specified length of characters.</param><param name="partialViewName">The name of the partial view to render.</param><param name="viewData">The view data dictionary for the partial view.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha Captcha(this HtmlHelper htmlHelper, int length, [AspMvcPartialView] string partialViewName, ViewDataDictionary viewData = null, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new captcha with the specified partial view.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="length">The specified length of characters.</param><param name="partialViewName">The name of the partial view to render.</param><param name="scriptPartialViewName">The name of the partial view to render script.</param><param name="viewData">The view data dictionary for the partial view.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha Captcha(this HtmlHelper htmlHelper, int length, [AspMvcPartialView] string partialViewName, [AspMvcPartialView] string scriptPartialViewName, ViewDataDictionary viewData = null, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new math captcha with the specified arguments.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha MathCaptcha(this HtmlHelper htmlHelper, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new math captcha with the specified arguments.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="refreshText">The specified refresh button text.</param><param name="inputText">The specified input text.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha MathCaptcha(this HtmlHelper htmlHelper, string refreshText, string inputText, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new math captcha with the specified arguments.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="refreshText">The specified refresh button text.</param><param name="inputText">The specified input text.</param><param name="requiredMessageText">The specified required message text.</param><param name="addValidationSpan">If <c>true</c> add a span for validation; otherwise <c>false</c>.
        ///             </param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha MathCaptcha(this HtmlHelper htmlHelper, string refreshText, string inputText, string requiredMessageText, bool addValidationSpan = false, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new math captcha with the specified partial view.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="partialViewName">The name of the partial view to render.</param><param name="viewData">The view data dictionary for the partial view.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha MathCaptcha(this HtmlHelper htmlHelper, [AspMvcPartialView] string partialViewName, ViewDataDictionary viewData = null, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new math captcha with the specified partial view.
        /// 
        /// </summary>
        /// <param name="htmlHelper">The specified <see cref="T:System.Web.Mvc.HtmlHelper"/>.
        ///             </param><param name="partialViewName">The name of the partial view to render.</param><param name="scriptPartialViewName">The name of the partial view to render script.</param><param name="viewData">The view data dictionary for the partial view.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha MathCaptcha(this HtmlHelper htmlHelper, [AspMvcPartialView] string partialViewName, [AspMvcPartialView] string scriptPartialViewName, ViewDataDictionary viewData = null, params ParameterModel[] parameters);

        /// <summary>
        /// Determines whether the captcha is valid, and write error message if need.
        /// 
        /// </summary>
        /// <param name="controllerBase">The specified <see cref="T:System.Web.Mvc.ControllerBase"/>.
        ///             </param><param name="errorText">The specified error message.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// <c>True</c> if the captcha is valid; otherwise, <c>false</c>.
        /// 
        /// </returns>
        public static bool IsCaptchaValid(this ControllerBase controllerBase, string errorText, params ParameterModel[] parameters);

        /// <summary>
        /// Gets the <see cref="T:CaptchaMvc.Interface.ICaptchaManager"/> using the specified <see cref="T:System.Web.Mvc.ControllerBase"/>.
        /// 
        /// </summary>
        /// <param name="controllerBase">The specified <see cref="T:System.Web.Mvc.ControllerBase"/>.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptchaManager"/>.
        /// </returns>
        public static ICaptchaManager GetCaptchaManager(this ControllerBase controllerBase);

        /// <summary>
        /// Gets the <see cref="T:CaptchaMvc.Interface.ICaptchaBuilderProvider"/> using the specified <see cref="T:System.Web.Mvc.ControllerBase"/>.
        /// 
        /// </summary>
        /// <param name="controllerBase">The specified <see cref="T:System.Web.Mvc.ControllerBase"/>.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptchaBuilderProvider"/>.
        /// </returns>
        public static ICaptchaBuilderProvider GetCaptchaBuilderProvider(this ControllerBase controllerBase);

        /// <summary>
        /// Creates a new captcha values with the specified arguments.
        /// 
        /// </summary>
        /// <param name="controller">The specified <see cref="T:System.Web.Mvc.ControllerBase"/>.
        ///             </param><param name="length">The specified length of characters.</param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.IUpdateInfoModel"/>.
        /// 
        /// </returns>
        public static IUpdateInfoModel GenerateCaptchaValue(this ControllerBase controller, int length, params ParameterModel[] parameters);

        /// <summary>
        /// Creates a new math captcha values with the specified arguments.
        /// 
        /// </summary>
        /// <param name="controller">The specified <see cref="T:System.Web.Mvc.ControllerBase"/>.
        ///             </param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.IUpdateInfoModel"/>.
        /// 
        /// </returns>
        public static IUpdateInfoModel GenerateMathCaptchaValue(this ControllerBase controller, params ParameterModel[] parameters);

        /// <summary>
        /// Makes the captcha "intelligent".
        /// 
        /// </summary>
        /// <param name="captcha">The specified <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        ///             </param><param name="parameters">The specified parameters, if any.</param>
        /// <returns>
        /// An instance of <see cref="T:CaptchaMvc.Interface.ICaptcha"/>.
        /// 
        /// </returns>
        public static ICaptcha AsIntelligent(this ICaptcha captcha, params ParameterModel[] parameters);
    }
}
