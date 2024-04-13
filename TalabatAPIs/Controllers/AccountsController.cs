using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Services;
using TalabatAPIs.Dtos;
using TalabatAPIs.Errors;
using TalabatAPIs.Extentions;

namespace TalabatAPIs.Controllers
{

    public class AccountsController : ApiBaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenServices _tokenServices;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenServices tokenServices,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
            _mapper = mapper;
        }

        // post : /api/accounts/login

        // إحنا هنرجع ل endpoint object من نوع UserDto
        // هنستقبل من user حاجة من نوع LoginDto
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenServices.CreateTokenAsync(user, _userManager)
            }) ;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {

            if(CheckEmailExsits(model.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] {"this email already in use"} });
           
            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
            };
            //  "password": "Pa$$w0rdfghh"

            var result = await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return Ok(new UserDto(){
                DisplayName = model.DisplayName,
                Email = model.Email,
                Token = await _tokenServices.CreateTokenAsync(user, _userManager)
            });
                
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenServices.CreateTokenAsync(user,_userManager)
            });
        }

        [Authorize]
        [HttpGet("address")] // get : api/account/address
        public async Task<ActionResult<AddressDto>> GetUserAdress()
        {
            var user = await _userManager.FindUserWithAdressAsync(User);

            var address = _mapper.Map<Address, AddressDto>(user.address);

            return Ok(address);
        }

        [Authorize]
        [HttpPut("address")] // put : api/account/address
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto updatedAddress)
        {
            var address = _mapper.Map<AddressDto, Address>(updatedAddress);

            var user = await _userManager.FindUserWithAdressAsync(User);

            address.Id = user.address.Id ;

            user.address = address;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return Ok(updatedAddress);
        }

        
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExsits(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}
