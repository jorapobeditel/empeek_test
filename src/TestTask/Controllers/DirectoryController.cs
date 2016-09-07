using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.IO;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    public class DirectoryController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        public DirectoryController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        DirectoryModels directoryModel = new DirectoryModels();
        // GET api/directory
        [HttpGet]
        public DirectoryViewModels Get()
        {
            return directoryModel.FillDirViewModel(_appEnvironment.WebRootPath);
        }

        // GET api/directory/5
        [HttpGet("{*dir}")]
        public ActionResult Get(string dir)
        {

            DirectoryViewModels data = directoryModel.FillDirViewModel(dir);
            if (data != null)
                return Ok(data);
            return NotFound();

        }
        /*
        // POST api/directory
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/directory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/directory/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
