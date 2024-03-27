using Iranpl.ApplicationCore.Services.Intefaces.Test;
using Iranpl.Domain.ViewModel;
using Iranpl.Infrastructure.Data.IranplContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iranpl.ApplicationCore.Services.Intefaces.Test;
using Microsoft.IdentityModel.Tokens;

namespace Iranpl.Infrastructure.Repositories
{
    public class TestLoginRepository : ITestLogin
    {
        private readonly SearchListsApiContext _apiContext;

        public TestLoginRepository(SearchListsApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public TestLoginDto TestLogin(TestLogin testLogin)
        {
            var result = new TestLoginDto();

            //ToDo: call api
            //result

            if (!testLogin.UserName.IsNullOrEmpty()) {
                // login  success
                //need claim

            }
            else
            {
            // login  failed
            }

            return result;
            //throw new NotImplementedException();


        }
    }
}
