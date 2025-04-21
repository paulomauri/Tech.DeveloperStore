using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Users.Commands;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id);
            if (existingUser == null)
            {
                return null; // ou lançar uma exceção, dependendo da sua política
            }

            var userToUpdate = _mapper.Map<User>(request.UserDto);
            userToUpdate.Id = request.Id;

            var updatedUser = await _userRepository.UpdateAsync(request.Id, userToUpdate);
            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
