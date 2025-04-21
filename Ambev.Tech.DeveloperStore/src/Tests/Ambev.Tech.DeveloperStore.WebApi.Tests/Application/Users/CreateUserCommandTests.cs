using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Users.Commands;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using Ambev.Tech.DeveloperStore.Application.Users.Handlers;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using Ambev.Tech.DeveloperStore.Application.MappingProfiles;
using AutoMapper;
using FluentAssertions;
using Moq;


namespace Ambev.Tech.DeveloperStore.Application.Tests.Users.Commands
{
    public class CreateUserCommandTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly CreateUserHandler _handler;
        private readonly IMapper _mapper;

        public CreateUserCommandTests()
        {
            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                // Configure your mappings here (e.g., from User to UserDto)
                cfg.AddProfile(new MappingProfile()); // Add your AutoMapper profile
            });

            _mapper = mockMapperConfig.CreateMapper();
            _userRepositoryMock = new Mock<IUserRepository>();

            // Instantiate the handler with both IUserRepository and IMapper
            _handler = new CreateUserHandler(_userRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Handle_DeveCriarUsuario_QuandoCommandValido()
        {
            // Arrange
            UserDto userdto = new UserDto()
            {
                Username = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };
            var command = new CreateUserCommand(userdto);

            var user = new User()
            {
                Username = command.UserDto.Username,
                Email = command.UserDto.Email,
                Password = command.UserDto.Password
            };

            _userRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<User>()))
                .ReturnsAsync(user);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Username.Should().Be(command.UserDto.Username);
            result.Email.Should().Be(command.UserDto.Email);

            // Verificando se o repositório foi chamado
            _userRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<User>()));
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenEmailIsAlreadyTaken()
        {
            // Arrange
            var command = new CreateUserCommand(new UserDto()
            {
                Username = "Jane Doe",
                Email = "john.doe@example.com", // Email já utilizado
                Password = "password123"
            });

            var user = new User()
            {
                Username = command.UserDto.Username,
                Email = command.UserDto.Email,
                Password = command.UserDto.Password
            };

            _userRepositoryMock
                .Setup(repo => repo.GetByEmailAsync(command.UserDto.Email))
                .ReturnsAsync(new User { Email = command.UserDto.Email });

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
