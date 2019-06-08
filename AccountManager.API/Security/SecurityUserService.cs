using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.API.Security
{
    public class SecurityUserService
    {
        private IMapper mapper;
        private IConfiguration configuration;
        private UserManager<IdentityUser> userManager;

        public SecurityUserService(IMapper mapper,
            IConfiguration configuration,
            UserManager<IdentityUser> userManager)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.userManager = userManager;
        }

        public async Task Register(CreateUser model)
        {
            IdentityUser user = mapper.Map<IdentityUser>(model);
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors
                    .Select(e => e.Description)));
        }

        public async Task<string> Login(string userName, 
            string password)
        {
            IdentityUser user = userManager.Users
                .SingleOrDefault(u =>
                    u.UserName.ToLower() == userName.ToLower());

            if (user == null)
                throw new Exception("Usuario o Password invalido");

            if(!(await userManager.CheckPasswordAsync(user, password)))
                throw new Exception("Usuario o Password invalido");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), 
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
