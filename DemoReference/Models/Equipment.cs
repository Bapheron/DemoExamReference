using DemoReference.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; } 
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateOnly PublicationDate { get; set; }
        public EquipmentState State {  get; set; }
        public int? UserId { get; set; } //Reader

        public User User { get; set; }
    }
}
