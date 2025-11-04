using BusinessLayer.DTOs;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public class AuthService
    {
        private readonly LionAccountRepo _repo;

        public AuthService(LionAccountRepo repo)
        {
            _repo= repo;
        }

        //Login 
        public async Task<LoginResponse> LoginAsync (LoginRequest req)
        {
            var account = await _repo.GetLionAccountAsync(req.Email, req.Password);
            return new LoginResponse
            {
                AccountId = account.AccountId,
                UserName = account.UserName,
                FullName = account.FullName,
                Email = account.Email,
                Phone = account.Phone,
                RoleId = account.RoleId
            };
        }
    }
}
