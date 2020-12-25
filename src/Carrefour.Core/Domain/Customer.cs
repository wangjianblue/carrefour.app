using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Core.Domain
{
  public  class Customer
    {
        public  int id { get; set; }
        public  string Username { get; set; }
        public  string Email { get; set; }

        public Guid CustomerGuid { get; set; }
    }
}
