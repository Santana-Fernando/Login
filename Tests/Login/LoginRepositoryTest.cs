using Xunit.Abstractions;
using Xunit;
using Infra.Data.Repository.Login;
using Microsoft.Extensions.Configuration;
using Domain.Login.Entities;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Moq;
using Infra.Data.Context.Helpers;
using Tests.Helper;

namespace Tests.Login
{
    public class LoginRepositoryTest
    {
        private readonly ITestOutputHelper _output;
        public LoginRepositoryTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Should call Authenticatio Login and return any answer")]
        public async Task LoginRepository_ShouldCallAuthenticationLogin()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);

                var loginEntry = new LoginEntry
                {
                    email = "test@example.com",
                    password = "password123"
                };

                var result = await loginRepository.Login(loginEntry);

                Assert.NotNull(result);
            }
        }

        [Fact(DisplayName = "Should return access denied if login data not exists")]
        public async Task LoginRepository_ShouldReturnAccessDeniedIfLoginEntryDataNotExists()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);

                var loginEntry = new LoginEntry
                {
                    email = "test@example.com",
                    password = "password123"
                };

                var result = await loginRepository.Login(loginEntry);

                Assert.NotNull(result);
                Assert.Equal("Access denied", result.message);
                Assert.Equal(System.Net.HttpStatusCode.Forbidden, result.statusCode);
            }
        }

        [Fact(DisplayName = "Should return internal server error if login catches")]
        public async Task LoginRepository_ShouldReturnInternalServerErrorIfLoginCatches()
        {
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(x => x["ConnectionStrings:DefaultConnection"]).Returns("Data Source=DESKTOP-F9M2LAN\\SQLEXPRESS;User ID=sa;Password=Fern@nd01331;Database=PeopleBasePraticl;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(configurationMock.Object["ConnectionStrings:DefaultConnection"])
            .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);

                var loginEntry = new LoginEntry
                {
                    email = "test@example.com",
                    password = "123456"
                };

                var result = await loginRepository.Login(loginEntry);

                Assert.NotNull(result);
                Assert.Equal(System.Net.HttpStatusCode.InternalServerError, result.statusCode);
            }
        }

        [Fact(DisplayName = "Should return OK if login is correct")]
        public async Task LoginRepository_ShouldReturnOkIfLoginIsCorrect()
        {
            AppSettingsMock appSettingsMock = new AppSettingsMock();
            var configurationMock = appSettingsMock.configurationMockStub();
            var options = appSettingsMock.OptionsDatabaseStub();

            using (var dbContext = new ApplicationDbContext(options))
            {
                var loginRepository = new LoginRepository(dbContext, configurationMock.Object);

                var loginEntry = new LoginEntry
                {
                    email = "system@gmail.com",
                    password = "123456"
                };

                var result = await loginRepository.Login(loginEntry);

                Assert.NotNull(result);
                Assert.True(new TokenAuthentication(configurationMock.Object).ValidateToken(result.token));
                Assert.Equal(System.Net.HttpStatusCode.OK, result.statusCode);
                Assert.Equal("OK", result.message);
            }
        }

    }
}
