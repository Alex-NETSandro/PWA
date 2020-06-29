using Microsoft.AspNetCore.Identity;

namespace PWABlog.Models.AcessControl
{
    public class DescriptorError:IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            var error = base.DuplicateUserName(userName);
            error.Description = "the specified username already exists";
            return error;
        }
    }
}