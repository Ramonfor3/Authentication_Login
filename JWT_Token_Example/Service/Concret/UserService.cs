using Authentication_Login.Dtos.Users;
using Authentication_Login.Exceptions;
using Authentication_Login.Models;
using Authentication_Login.Repository.Abstract;
using Authentication_Login.Response;
using Authentication_Login.Service.Abstract;
using Authentication_Login.Validation;
using AutoMapper;
using FluentValidation.Results;

namespace Authentication_Login.Service.Concret
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> AddUser(CreateUserDto users)
        {
            Validation(users);
            if (users == null) throw new ArgumentNullException(nameof(users));
            var userMapped = await _repository.AddUser(_mapper.Map<Users>(users));
            return _mapper.Map<UserDto>(userMapped);
        }

        private void Validation(CreateUserDto dto)
        {
            AuthenticationUserValidator validationRules = new AuthenticationUserValidator(_repository);
            ValidationResult result = validationRules.Validate(dto);
            if (!result.IsValid)
            {
                var errors = string.Join(" | ", result.Errors);
                throw new NotFoundException(errors);
            }
        }

        public async Task<ApiResponse<GetUserDto>> GetAll()
        {
            var apiResponse = new ApiResponse<GetUserDto>();
            var user = _mapper.Map<IEnumerable<GetUserDto>>(await _repository.GetAll());
            apiResponse.result = new ResultBody<GetUserDto>
            {
                items = user.ToList(),
                totalAcount = user.Count()
            };
            return apiResponse;
        }

        public async Task<ApiResponse<GetUserDto>> GetById(int Id)
        {
            var apiResponse = new ApiResponse<GetUserDto>();
            var user = _mapper.Map<IEnumerable<GetUserDto>>(await _repository.GetById(Id));
            if (user == null) throw new NotFoundException($"User with {Id} is not found");

            apiResponse.result = new ResultBody<GetUserDto>
            {
                items = user.ToList(),
                totalAcount = user.Count()
            };
            return apiResponse;
        }

        public async Task<ApiResponse<GetUserDto>> GetByUserName(string name)
        {
            var apiResponse = new ApiResponse<GetUserDto>();
            var user = _mapper.Map<IEnumerable<GetUserDto>>(await _repository.GetByUserName(name));
            if (user == null) throw new NotFoundException($"User with {name} is not found");
            apiResponse.result = new ResultBody<GetUserDto>
            {
                items = user.ToList(),
                totalAcount = user.Count()
            };
            return apiResponse;
        }
    }
}
