using System;
using System.Collections.Generic;
using System.Text;
using Carrefour.Core.Domain;

namespace Carrefour.Core
{
    public interface IWorkContext
    {
        Customer CurrentCustomer { get; }
    }
}
