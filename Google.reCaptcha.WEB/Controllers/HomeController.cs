using System.Web.Mvc;
using Google.reCaptcha.WEB.Models;
using GoogleRecaptcha;

namespace Google.reCaptcha.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 使用GoogleRecaptcha
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            IRecaptcha<RecaptchaV2Result> recaptcha = new RecaptchaV2(new RecaptchaV2Data(){
                Secret = "6LdQaxATAAAAACWOZDLB5C06RfW_0qhXJYagQ9iF"
            });

            // Verify the captcha
            var result = recaptcha.Verify();
            if (result.Success) // Success!!!
            {
                //TODO: write code here
            }
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        /// <summary>
        /// 自己寫
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Customer(FormCollection form)
        {
            var isVerify = new GoogleReCaptcha()
                 .GetCaptchaResponse(form["g-recaptcha-response"]);
            if (isVerify)
            {
                //TODO: Do something
            }

            return View();
        }
    }
}