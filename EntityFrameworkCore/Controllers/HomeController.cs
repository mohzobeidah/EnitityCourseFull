using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.Models;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            using (var db = new Testcontext())
            {

                List<Teachers> teacherslist = new List<Teachers>
                {
                     new Teachers{Name="dddd"},
                      new Teachers{Name="ddddfdd"}

                };
                db.Teachers.AddRange(teacherslist);
                db.SaveChanges();
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
                var IsExist = db.Teachers.Any(k=>k.TeacherID==1); // max , avarge, sum ,, count

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
            using (var db = new Testcontext())
            {
                var ss = db.Teachers.Where(x => x.TeacherID == db.Teachers.Max(xx => xx.TeacherID)).Select(x => new { x.TeacherID, x.Name }).FirstOrDefault().ToJson();
                Teachers t = ss.FromJson<Teachers>();
                return View(t);
            }

            
        }
        public string Privacy2()
        {
            using (var db = new Testcontext())
            {

                // eager loading
                var sssw = db.Teachers;
                //  explicity loading 
                var ss = db.Teachers.Include(x => x.Course_Relation);

                var sss = db.Teachers.ToList();
                var t = db.Teachers.Find(1);
                db.Entry(t).Collection(x => x.Course_Relation).Load(); // load for t only only as collection
                db.Entry(t).Reference(x => x.Course_Relation).Load(); // load for t only only as only object one to one
                return ("ddddd");
            }


        }
        public string Privacy42()
        {
            using (var db = new Testcontext())
            {

                db.twoPrimaryKeys.OrderBy(x => EF.Property<string>(x, "ShadowProperty")).ToList(); //use it where and so no
                var dd = new TwoPrimaryKey
                {
                    id1 = 1,
                    id2 = 1

                };
                db.Entry(dd).Property<string>("ShadowProperty").CurrentValue = "ddddddfff"; //add value 
                foreach (var item in db.twoPrimaryKeys)
                {
                   var ssss= db.Entry(item).Property<string>("ShadowProperty").CurrentValue;//add read  

                }
              
                

            } 

            return "dddd";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
