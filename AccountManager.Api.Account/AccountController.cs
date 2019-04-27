using AccountManager.Data.DataServices;
using AccountManager.Data.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AccountManager.Api.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController
    {
        private AccountDataService service;
        public AccountController(AccountDataService service)
        {
            this.service = service;   
        }
        //[HttpGet]
        //public IEnumerable<AccountDTO>()






























    }
}
