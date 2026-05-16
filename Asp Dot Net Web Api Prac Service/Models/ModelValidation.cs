using System;
using System.Collections.Generic;
using System.Text;

namespace Asp_Dot_Net_Web_Api_Prac_Service.Models
{
    public class ModelValidation<T>
    {
        public T? Value { get; set; }
        public bool IsValid { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
