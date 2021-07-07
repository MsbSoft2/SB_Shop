using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShop.Utility.Convertors
{
    public static class MonyConvertor
    {
        public static string ToRial(this decimal mony)
        {
            return mony.ToString("#,00");
        }
    }
}
