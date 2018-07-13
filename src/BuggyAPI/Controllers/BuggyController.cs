using System.Threading.Tasks;
using System.Web.Mvc;
using ThirdPartyLib;

namespace BuggyAPI.Controllers
{
    // Context: There is a problem with the "Problem" route.
    // Expected output: a JSON result with the data "{ message: 'you've fixed me!' }"
    // Tasks:
    //      - Identify the problem
    //      - Explain to us why the problem occurs
    //      - Fix the problem
    //      - Prove you're fixed the problem (just in the browser, don't worry about tests)
    public class BuggyController : Controller
    {
        private SomeServiceYouCantChange _thirdPartyLib;

        public BuggyController()
        {
            _thirdPartyLib = new SomeServiceYouCantChange();
        }

        public ActionResult Problem()
        {
            var data = GetDataAsync().Result;
            return Json(new { message = data }, JsonRequestBehavior.AllowGet);
        }

        private async Task<string> GetDataAsync()
        {
            var result = await _thirdPartyLib.ReturnsTheStringYouWantAsync();
            return result;
        }
    }
}