using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Exceptions;
public class ServiceException : Exception
{
    public ServiceException(Exception innerException)
        : base(message: "A service error ocurred, contact support.", innerException)
    { }
}
