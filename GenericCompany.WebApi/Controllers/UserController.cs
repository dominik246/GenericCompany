using AutoMapper;

using GenericCompany.Common.Filters.UserFilter;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;
using GenericCompany.Service.Common.Services;
using GenericCompany.WebApi.RESTModels.UserModel;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper Mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            Mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<OkObjectResult> Find([FromQuery] UserFilter filter, [FromBody] UrlFields fields)
        {
            var result = await _userService.FindAsync(filter, fields);
            return Ok(Mapper.Map<IEnumerable<UserModel>>(result));
        }

        // GET api/<UserController>/id
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(Guid id, [FromQuery] UrlFields fields)
        {
            if (id == default)
            {
                return BadRequest("Id cannot be null!");
            }
            var result = await _userService.GetAsync(new UserFilter() { Id = id }, fields);
            return Ok(Mapper.Map<UserModel>(result));
        }

        // GET api/<UserController>/count
        [HttpGet("count")]
        public async Task<ObjectResult> Get([FromQuery] UserFilter filter)
        {
            var result = await _userService.GetDbCountAsync(filter);
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<NoContentResult> Post([FromBody] IEnumerable<UserModel> modelList)
        {
            var _pocos = Mapper.Map<IEnumerable<IUserPoco>>(modelList);
            await _userService.CreateAsync(_pocos);
            return NoContent();
        }

        // PUT api/<UserController>
        [HttpPut]
        public async Task<NoContentResult> Put([FromBody] IList<UserModel> modelList)
        {
            var _pocos = Mapper.Map<IList<IUserPoco>>(modelList);
            await _userService.UpdateRangeAsync(_pocos);
            return NoContent();
        }

        // DELETE api/<UserController>
        [HttpDelete]
        public async Task<OkObjectResult> Delete([FromBody] IEnumerable<UserModel> modelList)
        {
            var _pocos = Mapper.Map<IEnumerable<IUserPoco>>(modelList);
            var result = await _userService.DeleteRangeAsync(_pocos);
            return Ok(result);
        }
    }
}
