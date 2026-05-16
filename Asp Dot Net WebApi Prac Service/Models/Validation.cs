using System;
using System.Collections.Generic;
using System.Text;

namespace Asp_Dot_Net_WebApi_Prac_Service.Models
{
    public class Validation<T>
    {
        public T? Value { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
