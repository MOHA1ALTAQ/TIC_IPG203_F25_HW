using System;
using TIC_IPG203_F25_HW.Models;
using TIC_IPG203_F25_HW.Utilities;

namespace TIC_IPG203_F25_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> appliances = CreateAppliances();

            if (!ValidateAppliances(appliances))
            {
                return;
            }

            SubscribeToEvents(appliances);
            RegisterAppliances(appliances);

            UpdateApplianceStatuses(appliances);

            decimal totalRepairCost = DisplayAppliances(appliances);

            DisplayStatistics(totalRepairCost);
        }

        static List<Appliance> CreateAppliances()
        {
            return new List<Appliance>
            {
                new Refrigerator("REF001", "Samsung", "RF-500"),
                new WashingMachine("WM001", "LG", "TurboWash"),
                new AirConditioner("AC001", "Gree", "Pular")
            };
        }

        static bool ValidateAppliances(List<Appliance> appliances)
        {
            foreach (Appliance appliance in appliances)
            {
                if (!Validation.IsValidSerialNumber(appliance.SerialNumber))
                {
                    Console.WriteLine(
                        "Invalid serial number: " + appliance.SerialNumber
                    );

                    return false;
                }

                if (!Validation.IsValidDate(appliance.DateReceived))
                {
                    Console.WriteLine(
                        "Invalid received date for appliance: "
                        + appliance.SerialNumber
                    );

                    return false;
                }
            }

            return true;
        }

        static void SubscribeToEvents(List<Appliance> appliances)
        {
            foreach (Appliance appliance in appliances)
            {
                appliance.OnStatusChanged += message =>
                {
                    Console.WriteLine("EVENT: " + message);
                };
            }
        }

        static void RegisterAppliances(List<Appliance> appliances)
        {
            foreach (Appliance appliance in appliances)
            {
                RepairCenterStatistics.AddAppliance();
            }
        }

        static void UpdateApplianceStatuses(List<Appliance> appliances)
        {
            RepairStatus maintenanceStatus = RepairStatus.UnderMaintenance;

            if (Validation.IsValidStatus(maintenanceStatus))
            {
                appliances[0].Status = maintenanceStatus;
                RepairCenterStatistics.AddUnderMaintenanceAppliance();
            }

            RepairStatus repairedStatus = RepairStatus.Repaired;

            if (Validation.IsValidStatus(repairedStatus))
            {
                appliances[1].Status = repairedStatus;
                RepairCenterStatistics.AddRepairedAppliance();
            }
        }

        static decimal DisplayAppliances(List<Appliance> appliances)
        {
            decimal totalRepairCost = 0;

            foreach (Appliance appliance in appliances)
            {
                decimal repairCost = appliance.RepairCost();

                Console.WriteLine(
                    "Serial Number: " + appliance.SerialNumber
                );
                Console.WriteLine("Brand: " + appliance.Brand);
                Console.WriteLine("Model: " + appliance.Model);
                Console.WriteLine("Status: " + appliance.Status);
                Console.WriteLine("Repair Cost: " + repairCost);
                Console.WriteLine("***************************");

                totalRepairCost += repairCost;
            }

            return totalRepairCost;
        }

        static void DisplayStatistics(decimal totalRepairCost)
        {
            Console.WriteLine(
                "Total Estimated Repair Cost: " + totalRepairCost
            );

            Console.WriteLine();
            Console.WriteLine("===== Repair Center Statistics =====");

            Console.WriteLine(
                "Total Appliances: "
                + RepairCenterStatistics.TotalAppliances
            );

            Console.WriteLine(
                "Under Maintenance: "
                + RepairCenterStatistics.UnderMaintenanceAppliances
            );

            Console.WriteLine(
                "Repaired: "
                + RepairCenterStatistics.RepairedAppliances
            );
        }
    }
}