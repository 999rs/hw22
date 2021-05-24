using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFRepository;

namespace DomainApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //public DbContext context = new EFRepository.DataContext();


        [HttpGet]
        public string Get()
        {
            
            return "Ololo GET";
        }
    }
}
