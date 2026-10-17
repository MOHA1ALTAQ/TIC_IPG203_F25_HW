using System;
using TIC_IPG203_F25_HW.Models;
namespace TIC_IPG203_F25_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> appliances = new List<Appliance>();

            appliances.Add(new Refrigerator("REF001", "Samsung", "RF-500"));
            appliances.Add(new WashingMachine("WM001", "LG", "TurboWash"));
            appliances.Add(new AirConditioner("AC001", "Gree", "Pular"));

            decimal totalRepairCost = 0;

            foreach (Appliance appliance in appliances)
            {
                Console.WriteLine("Serial Number: " + appliance.SerialNumber);
                Console.WriteLine("Brand: " + appliance.Brand);
                Console.WriteLine("Model: " + appliance.Model);
                Console.WriteLine("Status: " + appliance.Status);
                Console.WriteLine("Repair Cost: " + appliance.RepairCost());
                totalRepairCost += appliance.RepairCost();
                Console.WriteLine("***************************");
            }
            Console.WriteLine("Total Repair Cost: " + totalRepairCost);
        }
    }
}