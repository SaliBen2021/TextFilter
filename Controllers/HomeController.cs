using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TextFilter.Models;
using Xceed.Wpf.Toolkit;

namespace TextFilter.Controllers
{
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

        //Extract the stop words form the text
        [HttpPost]
        public ActionResult Textprocessing(TextModel model)
        {
            string s2;
            int counter = 0;
            
            if (ModelState.IsValid)
            {
                //trim the input text
                string s = model.userIn.Trim();
                //seperate the text to words
                string[] s1 = s.Split(' ');
                
                foreach(var word in s1)
                {
                    
                    // compare the input text with the stop words in the txt file
                    using (StreamReader reader = new StreamReader("stop_words_english.txt"))
                    {
                        string line;
                    //read the txt file line by line, each line has one stop word
                        while ((line = reader.ReadLine()) != null)
                        {
                            if(word.Equals(line))
                            {
                                s2=s.Replace(word,"");// if the stop word exsits in the text, it will be removed
                               
                                s = s2;
                                counter++;// count the stop words in the txt
                            }

                        }
                    }
                }
                TempData["counter"] = counter;// to send the stop word to the html page
                System.Console.WriteLine($"<{s}>");//display the output in the console
                var sortedArray = s.OrderBy(x => x);// order the string
                return View("Textprocessing", sortedArray);// send the string to the view model
               
            }

            return View();
        }
    

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
