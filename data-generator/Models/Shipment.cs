using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryDataGenerator.Models
{
    public class Shipment
    {
        public string id { get; set; }
        public string divisionId { get; set; }
        public string storeId { get; set; }
        public string distributorId { get; set; }
        public IEnumerable<ShipmentItem> items { get; set; }
        public DateTime arrivalTimestamp { get; set; }
    }

    public class ShipmentItem
    {
        public string upc { get; set; }
        public int shipmentAmount { get; set; }
    }
}
