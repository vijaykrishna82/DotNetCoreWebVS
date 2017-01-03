using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreVSWeb.Controllers
{
    public class MariaController
    {
      //  [HttpGet("/")]
        public string Index() => "Hello from MVC!";

        //[HttpGet("/Maria")]
        public string Maria() => "Hello from Maria!";
    }
}
