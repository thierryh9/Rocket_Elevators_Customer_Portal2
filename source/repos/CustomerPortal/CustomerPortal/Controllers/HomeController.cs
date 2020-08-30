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

        public async Task<IActionResult> PrivacyAsync()
        {
            var queryObject = new
            {
                query = @"
                        query getEverything($email: String!) {
                              getEverything(email: $email) {
                                customer {
                                  id
                                  entrepriseName
                                  authorityName
                                  email
                                  address_id
                                }
                                address {
                                  id
                                  street
                                  suite
                                  city
                                  postalCode
                                  country
                                }
                                buildings {
                                  id
                                  fullName
                                  customer_id
                                }
                                batteries {
                                  id
                                  building_id
                                  status
                                  employee_id
                                  installdate
                                  inspectionDate
                                  information
                                  notes
                                }
                                columns {
                                  id
                                  battery_id
                                  numberFloor
                                  status
                                  information
                                  notes
                                }
                                elevators {
                                  id
                                  serialNumber
                                  elevator_model
                                  building_type
                                  status
                                  installDate
                                  inspectionDate
                                  certificat
                                  information
                                  notes
                                  created_at
                                  updated_at
                                  column_id
                                }
                              }
                            }",
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
            for (int i = 0; i < responseObj["data"]["getEverything"]["buildings"].Count; i++)
            {
                ViewBag.Customer += $"<div>Full name: {responseObj["data"]["getEverything"]["buildings"][i]["fullName"]}</div>";
            }

            ViewBag.Customer += $"<div>Customer ID: {responseObj["data"]["getEverything"]["customer"]["id"]}</div>";
            ViewBag.Customer += $"<div>Entreprise: {responseObj["data"]["getEverything"]["customer"]["entrepriseName"]}</div>";
            ViewBag.Customer += $"<div>Authority: {responseObj["data"]["getEverything"]["customer"]["authorityName"]}</div>";
            ViewBag.Customer += $"<div>Email: {responseObj["data"]["getEverything"]["customer"]["email"]}</div>";
            ViewBag.Customer += $"<div>Address ID: {responseObj["data"]["getEverything"]["address"]["id"]}</div>";
            ViewBag.Customer += $"<div>Street: {responseObj["data"]["getEverything"]["address"]["street"]}</div>";
            ViewBag.Customer += $"<div>Suite or apt: {responseObj["data"]["getEverything"]["address"]["suite"]}</div>";
            ViewBag.Customer += $"<div>City: {responseObj["data"]["getEverything"]["address"]["city"]}</div>";
            ViewBag.Customer += $"<div>Postal code: {responseObj["data"]["getEverything"]["address"]["postalCode"]}</div>";
            ViewBag.Customer += $"<div>Country: {responseObj["data"]["getEverything"]["address"]["country"]}</div>";


            for (int i = 0; i < responseObj["data"]["getEverything"]["batteries"].Count; i++)
            {
                ViewBag.Batteries += $"<div>Battery ID: {responseObj["data"]["getEverything"]["batteries"][i]["id"]}</div>";
                ViewBag.Batteries += $"<div>Status: {responseObj["data"]["getEverything"]["batteries"][i]["status"]}</div>";
                ViewBag.Batteries += $"<div>Employee ID: {responseObj["data"]["getEverything"]["batteries"][i]["employee_id"]}</div>";
                ViewBag.Batteries += $"<div>Information: {responseObj["data"]["getEverything"]["batteries"][i]["information"]}</div>";
                ViewBag.Batteries += $"<div>Notes: {responseObj["data"]["getEverything"]["batteries"][i]["notes"]}</div>";
            }

            
            for (int i = 0; i < responseObj["data"]["getEverything"]["columns"].Count; i++)
            {
                ViewBag.Columns += $"<div>Column ID: {responseObj["data"]["getEverything"]["columns"][i]["id"]}</div>";
                ViewBag.Columns += $"<div>Battery ID: {responseObj["data"]["getEverything"]["columns"][i]["battery_id"]}</div>";
                ViewBag.Columns += $"<div>number of floors served: {responseObj["data"]["getEverything"]["columns"][i]["numberFloor"]}</div>";
                ViewBag.Columns += $"<div>Status: {responseObj["data"]["getEverything"]["columns"][i]["status"]}</div>";
                ViewBag.Columns += $"<div>Information: {responseObj["data"]["getEverything"]["columns"][i]["information"]}</div>";
                ViewBag.Columns += $"<div>Notes: {responseObj["data"]["getEverything"]["columns"][i]["notes"]}</div>";
            }
            
            for (int i = 0; i < responseObj["data"]["getEverything"]["elevators"].Count; i++)
            {
                ViewBag.Elevators += $"<div>--------------Elevator ID----------------: {responseObj["data"]["getEverything"]["elevators"][i]["id"]}</div>";
                ViewBag.Elevators += $"<div>Serial number: {responseObj["data"]["getEverything"]["elevators"][i]["serialNumber"]}</div>";
                ViewBag.Elevators += $"<div>Elevator model: {responseObj["data"]["getEverything"]["elevators"][i]["elevator_model"]}</div>";
                ViewBag.Elevators += $"<div>Type of building: {responseObj["data"]["getEverything"]["elevators"][i]["building_type"]}</div>";
                ViewBag.Elevators += $"<div>Status: {responseObj["data"]["getEverything"]["elevators"][i]["status"]}</div>";               
                ViewBag.Elevators += $"<div>Information: {responseObj["data"]["getEverything"]["elevators"][i]["information"]}</div>";
                ViewBag.Elevators += $"<div>Notes: {responseObj["data"]["getEverything"]["elevators"][i]["notes"]}</div>";
                ViewBag.Elevators += $"<div>Created at: {responseObj["data"]["getEverything"]["elevators"][i]["created_at"]}</div>";
                ViewBag.Elevators += $"<div>Updated at: {responseObj["data"]["getEverything"]["elevators"][i]["updated_at"]}</div>";
                ViewBag.Elevators += $"<div>Column ID: {responseObj["data"]["getEverything"]["elevators"][i]["column_id"]}</div>";

            }

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
