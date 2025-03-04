using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RusRoads.API.DTO;
using RusRoads.API.Entity;

namespace RusRoads.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController(RusRoadsContext db, IMapper mapper): ControllerBase
    {
        [HttpPost]
        public ActionResult<EmployeeDto> CreateEmp(EmployeeDto empDto)
        {
            var emp = mapper.Map<Employee>(empDto);
            try
            {
                db.Employee.Add(emp);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.InnerException?.Message}");
            }
            return Created("",empDto);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var emp = db.Employee.Include(r => r.Subdivision).ToList();
            var empDto = mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return Ok(empDto);
        }

        [HttpPut ("update")]
        public ActionResult<Employee> Update(EmployeeDto empDto)
        {
            var emp = mapper.Map<Employee>(empDto);
            try
            {
                db.Employee.Update(emp);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.InnerException?.Message}");
            }
            return Ok(emp);
        }

        [HttpPut ("dismiss")]
        public ActionResult<Employee> Dismiss(EmployeeDto empDto)
        {
            var emp = mapper.Map<Employee>(empDto);
            emp.DismissDate = DateTime.Now;
            try
            {
                db.Update(emp);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.InnerException?.Message}");
            }
            return Ok(emp);
        }

    }
}