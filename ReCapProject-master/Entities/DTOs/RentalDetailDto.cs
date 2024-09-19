using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string? CarBrand { get; set; }
        public string? CarDescription { get; set; }
        public string? CustomerName { get; set; }
        
    }
}
