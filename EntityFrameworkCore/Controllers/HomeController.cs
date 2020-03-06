using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.Models;
using EntityFrameworkCore.Data;

namespace EntityFrameworkCore.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            using (var db = new Testcontext())
            {
               var teacher= db.Teachers.Select(x=>x.Name).ToList();// choose specific propeties with new datattype
                foreach (var item in teacher)
                {
                    Console.WriteLine(item);
                }
                // return View(teacher);
            }
            using (var db = new Testcontext())
            {
                var teacher = db.Teachers.Where(x => x.Name.ToLower()=="ali").ToList();// choose new Rocodes by where

                // return View(teacher);
                foreach (var item in teacher)
                {
                    Console.WriteLine(item.Name);
                }
               
            }
            using (var db = new Testcontext())
            {
                Func<Teachers, bool> func = (x) =>
                {

                    return x.Name.ToLower() == "ali";
                };
                var teacher = db.Teachers.Where(x => x.Name.ToLower() == "ali").ToList();// choose new Rocodes by where
                var teacher2 = db.Teachers.Where(func).ToList();// choose new Rocodes by where
                                                                // return View(teacher);
                foreach (var item in teacher2)
                {
                    Console.WriteLine(item.Name);
                }
            }
            using (var db = new Testcontext())
            {
                var teacher = db.Teachers.AsEnumerable().AsParallel().WithExecutionMode(ParallelExecutionMode.Default);// choose specific propeties with new datattype
                var teacher2 = db.Teachers.OrderBy(x=>x.Name).AsEnumerable().AsParallel().AsOrdered();
                var teacher3 = db.Teachers.AsEnumerable().AsParallel().WithMergeOptions(ParallelMergeOptions.Default);
                var searchwithcontain = db.Teachers.Where(x => x.Name.ToLower().Contains("M")).ToList();
                var searchwithStart = db.Teachers.Where(x => x.Name.ToLower().StartsWith("M")).ToList();
                var searchwithEnd= db.Teachers.Where(x => x.Name.ToLower().EndsWith("M")).ToList();
                 var searchwithDsitnct = db.Teachers.Where(x => x.Name.ToLower()=="Ali").Distinct().ToList();
                var searchMIn= db.Teachers.Min(x=>x.TeacherID); // max , avarge, sum ,, count 

                foreach (var item in teacher)
                {
                    Console.WriteLine(item);
                }
                // return View(teacher);
            }

            return ("ddddddddd");
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
