using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Spartanprogramming.Web.MVC
{
    public interface IMappingStrategy<TInput, TOutput>
    {
        TOutput Map(TInput resource);
    }
}
