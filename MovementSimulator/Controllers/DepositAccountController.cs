using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class DepositAccountController(AppDbContext dbcontext, ILogger<DepositAccountController> logger) : ControllerBase
    {
        [HttpGet("{clientId}")]
        public async Task<List<VDepositAccountsSummary>> GetAccountByClient(Guid clientId) {
            logger.LogInformation("Fetching deposit accounts for client: {clientId}", clientId);
            return await dbcontext.VDepositAccountsSummaries.Where(v => v.PersonId == clientId).ToListAsync();
        }
    }
}
