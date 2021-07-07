using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShop.Utility
{
    public static class DeleteFile
    {
        public static bool DeleteImageFile(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
