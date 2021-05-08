using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RomanToNumericMicroservice.Helper;
using System.Net;

namespace RomanToNumericMicroservice.Controllers
{
    [ApiController]
    public class NumberConverterController : ControllerBase
    {

        private readonly IConverter _converter;

        public NumberConverterController(IConverter converter)
        {
            this._converter = converter;
        }

        [HttpGet]
        [Route("api/v1/romantonumeric/{romannumber}")]
        public ActionResult Get(string romannumber)
        {
            try
            {
                var response = _converter.RomanToNumeric(romannumber);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }

        }
    }
}
