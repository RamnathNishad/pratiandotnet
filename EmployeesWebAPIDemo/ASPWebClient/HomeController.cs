using ASPWebClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ASPWebClient
{
    public class HomeController : Controller
    {
        string baseUrl = "http://localhost:5208/api/Employees/";
        // GET: HomeController
        public ActionResult Index()
        {
            //call web api using HttpClient
            using (var client=new HttpClient())
            {
                var lstEmps = new List<Employee>();
                var response= client.GetAsync(baseUrl).Result;
                if(response.IsSuccessStatusCode)
                {
                    //get the data from the response
                    var data=response.Content.ReadAsStringAsync().Result;
                    lstEmps=JsonSerializer.Deserialize<List<Employee>>(data);
                }
                return View(lstEmps);
            }                
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            //call web api using HttpClient
            using (var client = new HttpClient())
            {
                var emp=new Employee();
                var response = client.GetAsync(baseUrl+ "GetEmpById/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    //get the data from the response
                    var data = response.Content.ReadAsStringAsync().Result;
                    emp = JsonSerializer.Deserialize<Employee>(data);
                }
                return View(emp);
            }
        }

        // GET: HomeController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {               
                //post to web api using model                
                 using (var client = new HttpClient())
                 {
                    var response = client.PostAsJsonAsync<Employee>(baseUrl + "AddEmp", emp).Result ;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View();
                    }
                 }
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
