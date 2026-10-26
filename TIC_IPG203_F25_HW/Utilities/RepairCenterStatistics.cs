using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25_HW.Utilities
{
    public static class RepairCenterStatistics
    {
        public static int TotalAppliances { get; private set; }

        public static int RepairedAppliances { get; private set; }

        public static int UnderMaintenanceAppliances { get; private set; }

        public static void AddAppliance()
        {
            TotalAppliances++;
        }

        public static void AddRepairedAppliance()
        {
            RepairedAppliances++;
        }

        public static void AddUnderMaintenanceAppliance()
        {
            UnderMaintenanceAppliances++;
        }
    }
}