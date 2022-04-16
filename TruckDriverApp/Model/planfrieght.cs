using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckDriverApp.Model
{
    public class planfrieght
    {
        [Key]
        public int plan_FrieghtId { get;set; }
        public string Start_Route { get; set; }
        public string End_Route { get; set; }
        public DateTime Transport_Time { get; set; }
        public decimal Frieght_Quotation { get; set; }
        public string Status { get; set; }
    }
}
