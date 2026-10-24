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
        private readonly string serialNumber;
        private string brand;
        private string model;
        private RepairStatus status;
        private readonly DateTime dateReceived;
        public string SerialNumber => serialNumber;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public RepairStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        public DateTime DateReceived => dateReceived;
        protected Appliance(string serialNumber, string brand, string model)
        {
            this.serialNumber = serialNumber;
            this.brand = brand;
            this.model = model;
            this.status = RepairStatus.Received;
            this.dateReceived = DateTime.Now;
        }

        public abstract decimal RepairCost();
    }
}