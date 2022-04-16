using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Model
{
    public class registermodel
    {
       
        public int Driver_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Village { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        [Key]
        public string Mobile_number { get; set; }
        public Int64 Aadhaar_no { get; set; }
        public string License_no { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm_password { get; set; }
        public string Authkey { get; set; }

    }
}
