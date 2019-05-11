using AccountManager.Data.DataServices;
using AccountManager.Data.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AccountManager.API.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController
        : ControllerBase
    {

        private AccountTypeDataService service;
        public AccountTypeController(AccountTypeDataService service)
        {

            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var result = service.GetAll<AccountTypeDTO>();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrupdate([FromBody] AccountTypeDTO model)
        {
            service.AddOrUpdate<AccountTypeDTO>(model);
            return Ok();
        }
    }
}
