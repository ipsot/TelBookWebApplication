using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TelBookWebApplication.Models;
using TelBookWebApplication.Models.Entities;

namespace TelBookWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbonentsController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                TelBookContext db = new TelBookContext();
                return StatusCode(StatusCodes.Status200OK, db.Abonents);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            try
            {
                TelBookContext db = new TelBookContext();
                Abonent findAbonent = db.Abonents.First(item => item.Id == id);
                db.Abonents.Remove(findAbonent);
                db.SaveChanges();
                return Ok(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Abonent abonent)
        {
            try
            {
                TelBookContext db = new TelBookContext();
                db.Add(abonent);
                db.SaveChanges();
                return Ok(abonent);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPut("id")]
        public ActionResult Put(int id, [FromBody] Abonent abonent)
        {
            try
            {
                TelBookContext db = new TelBookContext();
                Abonent findAbonent = db.Abonents.First(item => item.Id == id);
                findAbonent.Name = abonent.Name;
                findAbonent.Phone = abonent.Phone;
                findAbonent.Description = abonent.Description;
                db.SaveChanges();
                return Ok(findAbonent);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
