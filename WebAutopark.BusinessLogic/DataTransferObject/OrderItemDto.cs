﻿namespace WebAutopark.BusinessLogic.DataTransferObject
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ComponentId { get; set; }
        public int Quantity { get; set; }
        public ComponentDto Component { get; set; }
    }
}
