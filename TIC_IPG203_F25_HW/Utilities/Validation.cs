using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F25_HW.Models;

namespace TIC_IPG203_F25_HW.Utilities
{
    public static class Validation
    {
        public static bool IsValidSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                return false;
            }

            return serialNumber.Length >= 3;
        }

        public static bool IsValidDate(DateTime date)
        {
            return date != DateTime.MinValue
                   && date <= DateTime.Now;
        }

        public static bool IsValidStatus(RepairStatus status)
        {
            return Enum.IsDefined(typeof(RepairStatus), status);
        }

    }
}