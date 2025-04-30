using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public class UserNotException(string email) : NotFoundException($"User with Email {email} Is Not Found")
    {
    }
}
