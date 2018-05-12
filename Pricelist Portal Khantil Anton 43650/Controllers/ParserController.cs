using System.Threading;
using System.Web.Mvc;
using System.Web.UI;
using Pricelist_Portal_Khantil_Anton_43650.Parser;
using Pricelist_Portal_Khantil_Anton_43650.Parser.Morele;

namespace Pricelist_Portal_Khantil_Anton_43650.Controllers
{
    public class ParserController : Controller
    {
        // GET: Parser
        public ActionResult Parser()
        {
            MoreleStartParsing.RefreshDB();

            ViewBag.Message = "All works done! Database was refreshed!";
            return View();
        }

    }
}