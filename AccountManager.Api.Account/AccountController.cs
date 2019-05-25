using AccountManager.Data.DataServices;
using AccountManager.Data.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AccountManager.API.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController
        : ControllerBase
    {

        private AccountDataService service;
        public AccountController(AccountDataService service)
        {

            this.service = service;
        }

        [HttpGet]
        public IEnumerable<AccountDTO> Get()
        {
            var result = service.GetAll<AccountDTO>();
            return result;
        }

        [HttpPost]
        public IActionResult AddOrupdate([FromBody] AccountDTO model)
        {
            service.AddOrUpdate<AccountDTO>(model);
            return Ok();
        }


        [HttpGet("AccountPagging")]
        public IActionResult Pagging(int accountTypeId, int page, int rowPage)
        {
            return Ok(service.GetAll<AccountDTO>(a => a.AccountTypeId == accountTypeId)
                .Pagging(page, rowPage)); 
        }
    }
}
