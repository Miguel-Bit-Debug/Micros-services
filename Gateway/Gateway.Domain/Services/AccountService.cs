using Gateway.Domain.DTOs.Request;
using Gateway.Domain.Interfaces.Repositories;
using Gateway.Domain.Interfaces.Services;
using Gateway.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Gateway.Domain.Services
{
    public class AccountService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IAccountRepository accountRepository,
                              ILogger<AccountService> logger,
                              ITokenService tokenService)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _tokenService = tokenService;
        }

        public async Task<string> CreateAccount(AccountRequestDTO request)
        {
            try
            {
                _logger.LogInformation($"Iniciando criação de conta - {request.Username}");

                if (request.Password != request.ConfirmPassword)
                {
                    return null;
                }

                var accountExists = await _accountRepository.CheckAccountExists(request.Email);

                if (accountExists)
                {
                    return "Account already exists";
                }

                request.HashPassword(BCrypt.Net.BCrypt.HashPassword(request.Password, 10));

                var account = new Account(request.Username,
                                          request.Age,
                                          request.Email,
                                          request.Password);

                await _accountRepository.CreateAccount(account);
                _logger.LogInformation($"Conta criada com sucesso. {request.Username}");

                var token = _tokenService.GenerateToken(request.Username, request.Email);
                return token;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"erro ao criar a conta. {request.Username} - Erro {ex.Message}");
                throw ex;
            }
        }

        public async Task<string> Login(LoginRequestDTO request)
        {
            var account = await _accountRepository.GetAccountByEmail(request.Email);

            if (account == null)
            {
                return null;
            }

            var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, account.Password);

            if (!passwordValid)
            {
                return null;
            }

            var token = _tokenService.GenerateToken(account.Username, account.Email);
            return token;
        }
    }
}
