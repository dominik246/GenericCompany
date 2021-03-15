using AutoMapper;

using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;
using GenericCompany.Service.Common.Services;
using GenericCompany.WebApi.RESTModels.UserTransactionModel;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTransactionController : ControllerBase
    {
        private readonly IUserTransactionService _userTransactionService;
        private readonly IMapper Mapper;

        public UserTransactionController(IUserTransactionService userService, IMapper mapper)
        {
            _userTransactionService = userService;
            Mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<OkObjectResult> Find([FromQuery] BaseFilterModel filter, [FromBody] UrlFields fields)
        {
            var result = await _userTransactionService.FindAsync(filter, fields);
            return Ok(Mapper.Map<IEnumerable<UserTransactionModel>>(result));
        }

        // GET api/<UserController>/id
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(Guid id, [FromQuery] UrlFields fields)
        {
            if (id == default)
            {
                return BadRequest("Id cannot be null!");
            }
            var result = await _userTransactionService.GetAsync(new BaseFilterModel() { Id = id }, fields);
            return Ok(Mapper.Map<UserTransactionModel>(result));
        }

        // GET api/<UserController>/count
        [HttpGet("count")]
        public async Task<ObjectResult> Get([FromQuery] BaseFilterModel filter)
        {
            var result = await _userTransactionService.GetDbCountAsync(filter);
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<NoContentResult> Post([FromBody] IEnumerable<UserTransactionModel> modelList)
        {
            var _pocos = Mapper.Map<IEnumerable<IUserTransactionPoco>>(modelList);
            await _userTransactionService.CreateAsync(_pocos);
            return NoContent();
        }

        // PUT api/<UserController>
        [HttpPut]
        public async Task<NoContentResult> Put([FromBody] IList<UserTransactionModel> modelList)
        {
            var _pocos = Mapper.Map<IList<IUserTransactionPoco>>(modelList);
            await _userTransactionService.UpdateRangeAsync(_pocos);
            return NoContent();
        }

        // DELETE api/<UserController>
        [HttpDelete]
        public async Task<OkObjectResult> Delete([FromBody] IEnumerable<UserTransactionModel> modelList)
        {
            var _pocos = Mapper.Map<IEnumerable<IUserTransactionPoco>>(modelList);
            var result = await _userTransactionService.DeleteRangeAsync(_pocos);
            return Ok(result);
        }
    }
}
