using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerPortal.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using CustomerPortal.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace CustomerPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public async Task<IActionResult> InterventionAsync()

        {
            var queryObject = new
            {
                query = @"
                        query getEverything($email: String!) {
                                getEverything(email: $email){
                                        customer{
                                                id
                                                email
                                            }
                                            buildings{
                                                id
                                                customer_id
                                            }
                                            batteries{
                                                id
                                                building_id
                                            }
                                            columns{
                                                id
                                                battery_id
                                            }
                                            elevators{
                                                id
                                                column_id
                                            }
                                    }  
                            }
                        ",

                variables = new { email = User.Identity.Name }

            };

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(queryObject), Encoding.UTF8, "application/json")
            };

            dynamic responseObj;

            using (var response = await Program.httpClient.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                responseObj = JsonConvert.DeserializeObject<dynamic>(responseString);
            }
            Console.WriteLine(responseObj);
            for(int i = 0; i < responseObj["data"]["getEverything"]["buildings"].Count;i++){
                ViewBag.Buildings += $"<option name='customer_id'  value='{responseObj["data"]["getEverything"]["buildings"][i]["id"]}'>Building ID: {responseObj["data"]["getEverything"]["buildings"][i]["id"]}</option>";
            }

            for (int i = 0; i < responseObj["data"]["getEverything"]["batteries"].Count; i++)
            {
                ViewBag.Batteries += $"<option name='buildingID-{responseObj["data"]["getEverything"]["batteries"][i]["building_id"]}'  value='{responseObj["data"]["getEverything"]["batteries"][i]["id"]}'>Battery ID: {responseObj["data"]["getEverything"]["batteries"][i]["id"]}</option>";
            }

            for (int i = 0; i < responseObj["data"]["getEverything"]["columns"].Count; i++)
            {
                ViewBag.Columns += $"<option name='BatteryId-{responseObj["data"]["getEverything"]["columns"][i]["battery_id"]}'  value='{responseObj["data"]["getEverything"]["columns"][i]["id"]}'>Column ID: {responseObj["data"]["getEverything"]["columns"][i]["id"]}</option>";
            }

            for (int i = 0; i < responseObj["data"]["getEverything"]["elevators"].Count; i++)
            {
                ViewBag.Elevators += $"<option name='columnId-{responseObj["data"]["getEverything"]["elevators"][i]["column_id"]}'  value='{responseObj["data"]["getEverything"]["elevators"][i]["id"]}'>Elevator ID: {responseObj["data"]["getEverything"]["elevators"][i]["id"]}</option>";
            }

            return View();
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
