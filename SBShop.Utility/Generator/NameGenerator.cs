using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShop.Utility.Generator
{
    public class NameGenerator
    {
        public string ImageNameGenerator()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
