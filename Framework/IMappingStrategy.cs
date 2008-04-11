using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Spartanprogramming.MVC
{
    public interface IMappingStrategy<TInput, TOutput>
    {
        TOutput Map(TInput resource);
    }
}
