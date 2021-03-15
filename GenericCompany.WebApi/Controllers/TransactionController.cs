using AutoMapper;

using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;
using GenericCompany.Service.Common.Services;
using GenericCompany.WebApi.RESTModels.TransactionModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper Mapper;

        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            Mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<OkObjectResult> Find([FromQuery] BaseFilterModel filter, [FromBody] UrlFields fields)
        {
            var result = await _transactionService.FindAsync(filter, fields);
            return Ok(Mapper.Map<IEnumerable<TransactionModel>>(result));
        }

        // GET api/<UserController>/id
        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(Guid id, [FromQuery] UrlFields fields)
        {
            if (id == default)
            {
                return BadRequest("Id cannot be null!");
            }
            var result = await _transactionService.GetAsync(new BaseFilterModel() { Id = id }, fields);
            return Ok(Mapper.Map<TransactionModel>(result));
        }

        // GET api/<UserController>/count
        [HttpGet("count")]
        public async Task<ObjectResult> Get([FromQuery] BaseFilterModel filter)
        {
            var result = await _transactionService.GetDbCountAsync(filter);
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<NoContentResult> Post([FromBody] IEnumerable<TransactionModel> modelList)
        {
            var _pocos = Mapper.Map<IEnumerable<ITransactionPoco>>(modelList);
            await _transactionService.CreateAsync(_pocos);
            return NoContent();
        }

        // PUT api/<UserController>
        [HttpPut]
        public async Task<NoContentResult> Put([FromBody] IList<TransactionModel> modelList)
        {
            var _pocos = Mapper.Map<IList<ITransactionPoco>>(modelList);
            await _transactionService.UpdateRangeAsync(_pocos);
            return NoContent();
        }

        // DELETE api/<UserController>
        [HttpDelete]
        public async Task<OkObjectResult> Delete([FromBody] IEnumerable<TransactionModel> modelList)
        {
            var _pocos = Mapper.Map<IEnumerable<ITransactionPoco>>(modelList);
            var result = await _transactionService.DeleteRangeAsync(_pocos);
            return Ok(result);
        }
    }
}
