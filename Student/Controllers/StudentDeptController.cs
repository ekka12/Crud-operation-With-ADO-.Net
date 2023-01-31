using BOL;
using SAL;
using System.Collections.Generic;
// using System.Data;
// using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
// using Student.Models;

namespace StudentDept.Controllers;

public class StudentDeptController : Controller {
    private readonly ILogger<StudentDeptController>_Logger;

    public StudentDeptController(ILogger<StudentDeptController>logger){
        _Logger=logger;
    }
     [HttpGet]
     public IActionResult Index(){
        StudentService ss = new StudentService();
        List <Student1> slist= ss.GetAll();
        Console.WriteLine("In Index");
        if(slist!=null){
             Console.WriteLine("In Index1");
            this.ViewData["Student1"]=slist;
            
        }
        return View();
     }
     public IActionResult IndexDep(){
         StudentService ss = new StudentService();
        List <Department> slist= ss.GetAlldep();
        if(slist!=null){
            this.ViewData["Department1"]=slist;
            
        }
        return View();
     } 
    // [HttpPost]
        public IActionResult Delete(int studid){
            Console.WriteLine(studid);
            StudentService ss = new StudentService();
            bool status = ss.delete(studid);
            if(status){
               return RedirectToAction("Index","StudentDept");
            }
            return View();
        }

  

  [HttpGet]
       public IActionResult insert(){
         StudentService ss = new StudentService();
        List <Department> slist= ss.GetAlldep();
        if(slist!=null){
            this.ViewData["Department"]=slist;
            
        }
        return View();
     } 
[HttpPost]
        public IActionResult insert(int sid,string sname,string dname){
            StudentService ss = new StudentService();
            bool status = ss.Addstud(sid,sname,dname);
            if(status){
              return  RedirectToAction("Index","StudentDept");
            }
            return View();
        }
  [HttpGet]
        public IActionResult Edit (int studid){
            StudentService ss = new StudentService();
            List<Department> dlist = ss.GetAlldep();
             Console.WriteLine(studid);

            List <Student1> slist= ss.GetAll();
            foreach(Student1 s in slist){
                if(s.StudId==studid){
                         this.ViewData["Student1"]=s;
                }
            }
         
            if(dlist!=null){
                this.ViewData["Department"]=dlist;
            }
          
            return View();
        }
  [HttpPost]
        public IActionResult Edit (int studid,string sname,string dname){
            StudentService ss = new StudentService();
           
            bool status = ss.edit(studid,sname,dname);
            if(status){
                return RedirectToAction("Index","StudentDept");
            }
            return View();
        }

    
}
