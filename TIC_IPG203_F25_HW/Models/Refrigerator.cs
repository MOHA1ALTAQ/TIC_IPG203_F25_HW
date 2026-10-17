using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25_HW.Models
{
    public class Refrigerator : Appliance
    {
        public Refrigerator(string serialNumber, string brand, string model)
                    : base(serialNumber, brand, model)
        {
        }

        public override decimal RepairCost()
        {
            return 156m;
        }
    }
}
