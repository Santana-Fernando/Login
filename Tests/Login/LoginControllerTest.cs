using Application.Login.Interfaces;
using Application.Login.Services;
using Application.Login.ViewModel;
using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using Infra.Data.Context;
using Infra.Data.Repository.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation;
using System.Linq;
using System.Threading.Tasks;
using Tests.Helper;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Login
{
    public class LoginControllerTest
    {
        private readonly ITestOutputHelper _output;
        public LoginControllerTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Should call LoginController")]
        public async Task LoginRepository_ShouldCallLoginController()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>()));
                var loginService = new LoginServices(loginRepository, mapper);

                var loginController = new Presentation.Controllers.Login(loginService);

                var loginEntry = new LoginEntryViewModel()
                {
                    email = "fer@gmail.com",
                    password = "123456"
                };

                var result = await loginController.LoginEntry(loginEntry);

                Assert.NotNull(result);
            }
        }

        [Fact(DisplayName = "Should return the status StatusCodes.Status403Forbidden")]
        public async Task LoginRepository_ShouldReturnStatus403Forbidden()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>()));
                var loginService = new LoginServices(loginRepository, mapper);

                var loginController = new Presentation.Controllers.Login(loginService);

                var loginEntry = new LoginEntryViewModel()
                {
                    email = "fer@gmail.com",
                    password = "123456"
                };

                var result = await loginController.LoginEntry(loginEntry);
                
                Assert.NotNull(result);
                if (result is ObjectResult objectResult)
                {
                    Assert.Equal(StatusCodes.Status403Forbidden, objectResult.StatusCode);
                }
            }
        }

        [Fact(DisplayName = "Should return the status Status400BadRequest if e-mail is missing.")]
        public async Task LoginRepository_ShouldReturnStatus400BadRequestEmailMissing()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>()));
                var loginService = new LoginServices(loginRepository, mapper);

                var loginController = new Presentation.Controllers.Login(loginService);

                var loginEntry = new LoginEntryViewModel()
                {
                    email = "",
                    password = "123456"
                };

                var result = await loginController.LoginEntry(loginEntry);

                Assert.NotNull(result);
                if (result is ObjectResult objectResult)
                {
                    Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
                }
            }
        }

        [Fact(DisplayName = "Should return the status Status400BadRequest if password is missing.")]
        public async Task LoginRepository_ShouldReturnStatus400BadRequestPasswordMissing()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>()));
                var loginService = new LoginServices(loginRepository, mapper);

                var loginController = new Presentation.Controllers.Login(loginService);

                var loginEntry = new LoginEntryViewModel()
                {
                    email = "fer@gmail.com",
                    password = ""
                };

                var result = await loginController.LoginEntry(loginEntry);

                Assert.NotNull(result);
                if (result is ObjectResult objectResult)
                {
                    Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
                }
            }
        }

        [Fact(DisplayName = "Should return the status 200OK if ok.")]
        public async Task LoginRepository_ShouldReturnStatus200IfOK()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);
                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ViewModelToDomainMappingProfile>()));
                var loginService = new LoginServices(loginRepository, mapper);

                var loginController = new Presentation.Controllers.Login(loginService);

                var loginEntry = new LoginEntryViewModel()
                {
                    email = "system@gmail.com",
                    password = "123456"
                };

                var result = await loginController.LoginEntry(loginEntry);

                Assert.NotNull(result);
                if (result is ObjectResult objectResult)
                {
                    Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
                }
            }
        }
    }
}
