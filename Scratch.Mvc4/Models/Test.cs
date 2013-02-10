using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scratch.Mvc4.Models
{
    public class Test
    {
        public Test()
        {
            Id = Guid.NewGuid();
            Name = Id.ToString();
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
    }
}