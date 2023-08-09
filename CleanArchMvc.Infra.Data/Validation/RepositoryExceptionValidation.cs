using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Validation;

public class RepositoryExceptionValidation : Exception
{
    public RepositoryExceptionValidation(string message) : base(message) { }

    public static void When(bool hasError, string message)
    {
        if(hasError)
        {
            throw new RepositoryExceptionValidation(message);
        }
    }
} 

