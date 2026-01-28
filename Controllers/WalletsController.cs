using DigitalWallet.Api.Data;
using DigitalWallet.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WalletsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWallets()
        {
            return await _context.Wallets.ToListAsync();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Wallet>> GetWalletByUserId(int userId)
        {
            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);

            if (wallet == null) return NotFound("No wallet found for this user.");

            return wallet;
        }
    }
}
