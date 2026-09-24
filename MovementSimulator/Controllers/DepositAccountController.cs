using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovementSimulator.Data;
using MovementSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovementSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositAccountController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;

        public DepositAccountController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("{clientId}")]
        public async Task<List<VDepositAccountsSummary>> GetAccountByClient(Guid clientId) {
            return await _dbcontext.VDepositAccountsSummaries.Where(v => v.PersonId == clientId).ToListAsync();
        }
    }
}
