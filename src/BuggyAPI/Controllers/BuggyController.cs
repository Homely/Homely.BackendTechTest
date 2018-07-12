using BuggyAPI.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BuggyAPI.Controllers
{
    // Context: There is a problem with the "Problem" route.
    // Expected output: a JSON result with the data "{ message: 'you've fixed me!' }"
    // Tasks:
    //      - Identify the problem
    //      - Explain to us why the problem occurs
    //      - Fix the problem
    //      - Prove you're fixed the problem
    //      - Do it in the best way you know how
    public class BuggyController : Controller
    {
        private TestService _testService;

        public BuggyController()
        {
            _testService = new TestService();
        }

        public ActionResult Problem()
        {
            var data = GetDataAsync().Result;
            return Json(new { message = data }, JsonRequestBehavior.AllowGet);
        }

        private async Task<string> GetDataAsync()
        {
            var result = await _testService.GetDataAsync();
            return result;
        }
    }
}