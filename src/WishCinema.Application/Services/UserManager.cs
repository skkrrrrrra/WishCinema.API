using DamnSmallMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WishCinema.Application.Requests;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Domain.Entities;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class UserManager : IUserManager
    {
        private readonly MainDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserManager(MainDbContext dbContext, IConfiguration configuration) 
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var user = new User();
            user.UserProfile = new();


            var result = await _dbContext.Users.Where(item => item.Phone == request.Phone || item.Username == request.Username).FirstOrDefaultAsync();

            if(result != null)
            {
                return false;
            }

            user = Mapper.Map<User>(request);
            user.UserProfile = Mapper.Map<UserProfile>(request);

            var passwordHashAndSalt = (await GetPasswordHashAndSalt(request.Password));
            user.PasswordHash = passwordHashAndSalt.Item1;
            user.PasswordSalt = passwordHashAndSalt.Item2;

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        //public async Task<bool> LoginWithPhoneCode(LoginByPhoneRequest request)
        //{

        //}

        public async Task<string> LoginWithPassword(LoginRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(item => item.Username == request.Username);

            if(user == null)
            {
                return string.Empty;
            }

            var result = await CheckPasswordHash(user.PasswordHash, user.PasswordSalt, request.Password);

            if(result == false)
            {
                return string.Empty;
            }

            var jwt = await CreateToken(user);
            return jwt;
        }





        private async Task<(byte[], byte[])> GetPasswordHashAndSalt(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var paswordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return (passwordHash, paswordSalt);
            }
        }
        private async Task<bool> CheckPasswordHash(byte[] hash, byte[] salt, string password)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if(!hash.SequenceEqual(passwordHash))
                {
                    return false;
                }
                return true;
            }
        }

        private async Task<string> CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateHelper.GetCurrentDateTime().AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
