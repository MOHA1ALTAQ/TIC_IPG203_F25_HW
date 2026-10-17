using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F25_HW.Interfaces;

namespace TIC_IPG203_F25_HW.Models
{
    public abstract class Appliance : IRepairable
    {
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public RepairStatus Status { get; set; }
        public DateTime DateReceived { get; set; }

        protected Appliance(string serialNumber, string brand, string model)
        {
            SerialNumber = serialNumber;
            Brand = brand;
            Model = model;
            Status = RepairStatus.Received;
            DateReceived = DateTime.Now;
        }

        public abstract decimal RepairCost();
    }
}
