using AutoMapper;
using Azure.Core;
using Business.Abstractions.Constants;
using Business.Abstractions.Interfaces.DapperRepository;
using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.User;
using Entities.Entities;

namespace Business.Services
{
    public class UserService : IUserService
    {

        private readonly IUserEFRepository _userRepository;
        private readonly IUserDapperRepository _userDapperRepository;
        private readonly IMapper _mapper;
        private readonly IResultOutput<UserOutput> _resultOutput;
        public UserService(IMapper mapper,
                           IUserEFRepository userRepository,
                           IUserDapperRepository userDapperRepository,
                           IResultOutput<UserOutput> resultOutput)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _resultOutput = resultOutput;
            _userDapperRepository = userDapperRepository;
        }

        public async Task<UserAuthOutput> AuthenticateAsync(string username, string password)
        {
            return await _userRepository.AuthenticateAsync(username, password);
        }
        public async Task<IResultOutput<UserOutput>> SaveAsync(UserInsertInput userInput)
        {
            var userEntity = _mapper.Map<UserInsertInput, UserEntity>(userInput);
            userEntity.SetStatusTrue();
            userEntity.SetNewDateRegister();
            var savedUserEntity = await _userRepository.SaveAsync(userEntity);
            var savedUserOutput = _mapper.Map<UserEntity, UserOutput>(savedUserEntity);
            return _resultOutput.OperationOutputSuccess(savedUserOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<UserOutput>> UpdateAsync(UserUpdateInput userInput)
        {
            var userEntity = await _userRepository.GetByIdAsync(userInput.IdUser);
            var userEntityMapping = _mapper.Map<UserUpdateInput, UserEntity>(userInput);
            userEntity.SetEntityUpdate(userEntityMapping);
            await _userRepository.UnitOfWork.Commit();
            return _resultOutput.OperationOutputSuccess(new(), Messages.SuccessMessage);
        }
        public async Task<IResultOutput<UserOutput>> DeleteAsync(int id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            if (userEntity == null)
            {
                return _resultOutput.OperationOutputError(Messages.ErrorMessage);
            }
            await _userRepository.DeleteAsync(userEntity);
            await _userRepository.UnitOfWork.Commit();
            var deletedUserOutput = _mapper.Map<UserEntity, UserOutput>(userEntity);
            return _resultOutput.OperationOutputSuccess(deletedUserOutput, Messages.SuccessMessage);
        }
        public async Task<IResultOutput<UserOutput>> GetByIdAsync(int id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            var UserOutput = _mapper.Map<UserEntity, UserOutput>(userEntity);
            return _resultOutput.OperationOutputSuccess(UserOutput, Messages.SuccessMessage);
        }
    }
}
