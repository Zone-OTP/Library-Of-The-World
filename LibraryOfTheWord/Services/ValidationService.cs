using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes_ModelLibrary.VeiwModes;
using LibraryOfTheWorld.Services;
using Microsoft.VisualBasic.ApplicationServices;

namespace LibraryOfTheWorld.Services
{
    internal class ValidationService
    {
        public async static Task<UserVeiwModel> SignInValidation(string name, string password)
        {
            UserVeiwModel user = new();
            if (await AdminService.SignInCheck(name, password))
            {
                user.IsAdmin = true;
                user.Name = name;
                return user;
            }
            else if (await CustomerService.ValidateLoginAsync(name, password))
            {
                var customer = await CustomerService.GetCustomerByNameAsync(name);
                user.Email = customer.Email;
                user.CustomerId = customer.CustomerId;
                user.Name = customer.Name;
                user.LibraryCardNumber = customer.LibraryCardNumber;
                user.PersonalGovernmentId = customer.PersonalGovernmentID;

                return user;
            }

            return null;

        }


    }
}
