

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Model
{
    public class Response
    {
        [Key]
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }
}
