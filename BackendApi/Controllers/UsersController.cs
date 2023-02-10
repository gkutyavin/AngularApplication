using BackendApi.Data;
using BackendApi.Dto;
using BackendApi.Dto.Validators;
using BackendApi.Models;
using BackendApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly IUserDtoValidator userDtoValidator;

        public UsersController(IUserRepository repository, IUserDtoValidator userDtoValidator)
        {
            this.repository = repository;
            this.userDtoValidator = userDtoValidator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto userDto)
        {
            if (! await userDtoValidator.ValidateAsync(userDto))
                return BadRequest();

            var user = new User
            {
                Login = userDto.Login!,
                Password = userDto.Password!, // TODO: don't store plain password text
                Agree = userDto.Agree!.Value,
                CountryID = userDto.Country!.Value.ID!.Value,
                ProvinceID = userDto.Province!.Value.ID!.Value,
            };

            await repository.Add(user);

            return Ok();
        }
    }
}