using Microsoft.AspNetCore.Http;
using System;

namespace SBShop.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        
     
    }
}
