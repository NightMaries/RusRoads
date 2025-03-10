using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RusRoads.API.DTO;
using RusRoads.API.Entity;
using RusRoads.API.Mappers;

namespace RusRoads.API.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class SubdivisionController(RusRoadsContext db, IMapper mapper) : ControllerBase
    {

        [HttpGet("Subdivisions")]
        public ActionResult<IEnumerable<Subdivision>> GetSubdivisionsAll()
        {
            var list = db.Subdivision.OrderBy(r => r.Id).ToList();
            var listDto = mapper.Map<IEnumerable<SubdivisionDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{subdivisionId}/employee")]
        public ActionResult<IEnumerable<Employee>> GetEmpSubdivision(int subdivisionId)
        {
            var list = db.Employee.Where(e => e.SubdivisionId == subdivisionId).ToList();
            var listDto = mapper.Map<IEnumerable<EmployeeDto>>(list);
            return Ok(listDto);
        }

        private IEnumerable<Employee> GetEmployees(int subdivisionId)
        {
            return db.Employee.Where(e => e.SubdivisionId == subdivisionId).ToList();
        }

        [HttpGet("{subdivisionId}/employeeAll")]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmpSubdivisions(int subdivisionId)
        {

            var listEmp = new List<Employee>();

            var listSub = new List<Subdivision>();

            var currentEmp = GetEmployees(subdivisionId);
            listEmp.AddRange(currentEmp);

            var subdivisions = db.Subdivision.ToList();

            GetChildren(subdivisionId);

            void GetChildren(int parentId)
            {

                var children = db.Subdivision.Where(s => s.LeaderSubdivisionId == parentId).ToList();

                listSub.AddRange(children);

                foreach (var child in children)
                {
                    GetChildren(child.Id);
                }
            }
            foreach (var sub in listSub)
            {
                listEmp.AddRange(GetEmployees(sub.Id));
            }
            var empDto = mapper.Map<IEnumerable<EmployeeDto>>(listEmp);

            return Ok(empDto);
        }

    }

}