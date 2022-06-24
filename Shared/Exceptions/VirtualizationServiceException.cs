using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Exceptions;
public class VirtualizationServiceException : Exception
{
    public VirtualizationServiceException(Exception innerException)
        : base(message: "Virtualization service error ocurred, contact support.", innerException)
    { }
}
