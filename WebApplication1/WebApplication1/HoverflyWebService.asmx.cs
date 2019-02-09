using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for HoverflyWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class HoverflyWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public Student GetStudent()
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            return new Student()
            {
                Name = "andy eddy edwards editing name and hoverfly over ",
                Age = 25,
                DateOfBirth = new DateTime(1993, 5, 12),
                time = DateTime.Now.ToLongTimeString(),
                city = "Hebron"
            };
        }


    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string time { get; set; }
        public string city { get; set; }
    }
}
