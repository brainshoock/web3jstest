using System;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3;
using System.Web.Mvc;

namespace TestMvcApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBalance(string url, string eth)
        {
            var client = new RpcClient(new Uri(url));

            var web3 = new Web3(client);

            var weiBalance = web3.Eth.GetBalance.SendRequestAsync(eth).Result;
            var balance = (decimal)weiBalance.Value / (decimal)Math.Pow(10, 18);

            return Json(new { balance  = balance }, JsonRequestBehavior.AllowGet);
        }
    }
}