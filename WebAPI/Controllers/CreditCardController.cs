using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;
        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _creditCardService.GetAllCard();
            if (result.Success)
            {
               return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetCardById(string id)
        {
            var result = _creditCardService.GetCardById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.AddCard(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _creditCardService.DeleteCard(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
