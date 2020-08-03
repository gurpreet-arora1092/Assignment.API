using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Assignment.API.Data;
using Assignment.API.Helpers;
using Assignment.API.Models;
using Assignment.API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] EmployeeParams employeeParams)
        {
            var employee = await _repo.GetEmployee(employeeParams);
            var employeeToReturn = _mapper.Map<IEnumerable<EmployeeForListDto>>(employee);

            Response.AddPagination(employee.CurrentPage, employee.PageSize, employee.TotalCount, employee.TotalPages);

            return Ok(employeeToReturn);
        }


        [HttpGet("{id}", Name = "getEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {


            var employee = await _repo.GetEmployee(id);
            var employeeToReturn = _mapper.Map<EmployeeForListDto>(employee);
            return Ok(employeeToReturn);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateEmployee(int id, EmployeeForUpdateDto employeeForUpdateDto)
        {
            if (id != int.Parse(Employee.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var employeeFromRepo = await _repo.GetEmployee(id);


            _mapper.Map(employeeForUpdateDto, employeeFromRepo);

            if (await _repo.SaveAll())
                return NoContent();


            throw new Exception($"Updating user {id} failed on save");
        }


    }