using System;

namespace WebAutopark.BusinessLogic.DataTransferObject
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
    }
}
