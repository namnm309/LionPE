using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class LionAccountRepo
    {
        private readonly Su25lionDbContext _context;

        public LionAccountRepo(Su25lionDbContext context)
        {
            _context = context;
        }

        //Login 

        public async Task<LionAccount> GetLionAccountAsync(string email,string password)
        {
            var account= await _context.LionAccounts.FirstOrDefaultAsync(acc=>acc.Email == email && acc.Password==password);
            return account;
        }
    }
}
