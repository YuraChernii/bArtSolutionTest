using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Domain.Dto;
using bArtSolutionTest.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bArtSolutionTest.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Add new Account
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddNewAccount([FromBody] AddNewAccountDto addNewAccountDto)
        {
            var addedAccount = await accountService.AddNewAccountAsync(addNewAccountDto);

            return addedAccount == null ? StatusCode(409, $"Account already exists.") : Ok(addedAccount);
        }

    }
}
