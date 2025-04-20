using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Tech.DeveloperStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUser = await _userRepository.AddAsync(user);
            var createdUserDto = _mapper.Map<UserDto>(createdUser);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUserDto.Id }, createdUserDto);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var updatedUser = await _userRepository.UpdateAsync(user);
            if (updatedUser == null)
                return NotFound();

            var updatedUserDto = _mapper.Map<ProductDto>(updatedUser);
            return Ok(updatedUserDto);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
