using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PWABlog.Models.AcessControl
{
    public class RegisterUserExeception:Exception
    {
        public IEnumerable<IdentityError> Error { get; set; }

        public RegisterUserExeception(IEnumerable<IdentityError> error)
        {
            Error = error;
        }
    }
}