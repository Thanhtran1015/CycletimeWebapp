using IoT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IoT.helpers;
namespace IoT.Controllers
{
    public class FactoryController : Controller
    {
        // GET: Factory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Devices()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Chart()
        {
        //    string url = "http://localhost:3484/api/displaydata";
        //    var data = new object();
        //    var task = Task.Run(async () => {
        //        for (; ; )
        //        {
        //            await Task.Delay(100);
        //                     data = await GetCurrentData(url);
        //        }
        //    });
        //    ViewBag.Data = data;
            return View();
        }
       public async Task<object> GetCurrentData(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<object>(jsonResponse);
                   return data;
                }
            }
            return "";
        }
        
        [HttpGet]
        public JsonResult LoadData()
        {
            //IoTDbContext db = new IoTDbContext();

            //var startTime = DateTime.Now.Date + new TimeSpan(07, 30, 00);
            //var endTime = DateTime.Now.Date + new TimeSpan(18, 00, 00);

            //var CurrentDay = DateTime.Now.Date;
            //var query = db.DisplayDatas.Where(x => x.CreateTime == CurrentDay).FirstOrDefault();

            //var model = db.CycleTimes
            //   .Where(x => x.TimeRevCycleTime >= startTime && x.TimeRevCycleTime <= endTime).ToList();
            //TimeSpan totalCurrent = DateTime.Now - startTime;

            //decimal TotalHours = Convert.ToDecimal(totalCurrent.TotalHours);

            //CycleTimeViewModel cycleTimeVM = new CycleTimeViewModel();
            //cycleTimeVM.AverageTimeCycleTime = Math.Round((query.TotalTime / query.Count)/1000, 3);
            //cycleTimeVM.Availability = Math.Round((Convert.ToDecimal((query.TotalTime/3600000))/ TotalHours) *100, 3);
            //cycleTimeVM.MinRealTime = Math.Round(query.MinRealTime/ 1000,3);
            //cycleTimeVM.RealTimeCycleTime = Math.Round(query.RealTime / 1000, 3);

            //string json = JsonConvert.SerializeObject(cycleTimeVM);

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}