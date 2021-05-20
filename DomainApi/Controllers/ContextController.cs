using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DomainApi.Controllers
{
    public class ContextController : Controller
    {
        DomainContext _context;
        public IActionResult Init()
        {

            //DbContextOptions<DbContext> opt = new DbContextOptions(;
            //opt.
            //var _context = (DomainContext)ValidationContext.GetService(typeof(DomainContext));
            //var db = ServiceProvider.GetService((typeof (DomainContext)));

            var x = _context;

            return new JsonResult("init done");
        }

        public ContextController(DomainContext serv)
        {
            _context = serv;
        }
    }
}
