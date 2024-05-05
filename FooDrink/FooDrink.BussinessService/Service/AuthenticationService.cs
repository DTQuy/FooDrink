using FooDrink.BussinessService.Interface;
using FooDrink.Database.Models;
using FooDrink.DTO.Request.Authentication;
using FooDrink.DTO.Response.Authentication;
using FooDrink.Repository;
using FooDrink.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooDrink.BussinessService.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IUnitOfWork unit, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unit;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public IRepository<Product>? ProductRepository => throw new NotImplementedException();

        public IRepository<User>? UserRepository => throw new NotImplementedException();

        public IRepository<User>? AuthenticationRepository => throw new NotImplementedException();

        public async Task<AuthenticationResponse> Login(LoginRequest request)
        {
            var response = new AuthenticationResponse();

            var user = await _unitOfWork.AuthenticationRepository.GetByUsernameAndPassword(request.Username, request.Password);

            if (user != null)
            {
                response.Token = _jwtTokenGenerator.GenerateToken(user.Id, user.FullName);
            } else
            {
                response.Message = "Wrong username or password";
            }

            return response;

        }

        public async Task<AuthenticationResponse> Register(RegisterRequest request)
        {
            var response = new AuthenticationResponse();

            var user = await _unitOfWork.AuthenticationRepository.GetByUsername(request.Username);

            if (user == null)
            {
                User newUser = new() {
                    Username = request.Username,
                    Password = request.Password,
                    FullName = request.Fullname,
                    Email = request.Email,
                    Address = request.Address,
                    Role = "Customer",
                    Status = true
                };
                _ = await _unitOfWork.AuthenticationRepository.AddAsync(newUser);
                response.Token = _jwtTokenGenerator.GenerateToken(newUser.Id, newUser.Role);
            }
            else
            {
                response.Message = "Username has already existed";
            }

            return response;
        }
    }
}
