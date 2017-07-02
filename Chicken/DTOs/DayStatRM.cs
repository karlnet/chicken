using Chicken.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.DTOs
{
    public class DayStatRM
    {
        public DayStatRM(YFChickenDailyReport dayReport)
        {
            if (dayReport != null)
            {
                DieAmount = dayReport.DieAmount_int ?? 0;
                //Weight = dayReport.Weight_float ?? 0;
                //Evenness = dayReport.Evenness_float ?? 0;
                //FodderCumulant = dayReport.FodderCumulant_float ?? 0;
                Medicine = dayReport.Medicine_float ?? 0;
                OtherItem = dayReport.OtherItem_float ?? 0;
                CoalCumulant = dayReport.CoalCumulant_float ?? 0;
                TotalCoalCumulant = CoalCumulant + dayReport.TotalCoalCumulant_float ?? 0;
                TotalMedicine = Medicine + dayReport.TotalMedicine_float ?? 0;
                TotalOtherItem = OtherItem + dayReport.TotalOtherItem_float ?? 0;
                TotalDieAmount = DieAmount + dayReport.TotalDieAmount_int ?? 0;
            }
        }
        public string LairageDate { get; set; }
        public int LairageAmount { get; set; }
        public int ChickenTypeID { get; set; }
        public int Age { get; set; }
        public int AddChickenAmount { get; set; }
        public int TotalAddChickenAmount { get; set; }
        public int TotalChickenAmount { get; set; }
        public int DieAmount { get; set; }
        public int TotalDieAmount { get; set; }
        public double Weight { get; set; }
        public double Evenness { get; set; }
        public double FodderCumulant { get; set; }
        public double TotalFodderCumulant { get; set; }
        public double CoalCumulant { get; set; }
        public double TotalCoalCumulant { get; set; }
        public double Medicine { get; set; }
        public double TotalMedicine { get; set; }
        public double OtherItem { get; set; }
        public double TotalOtherItem { get; set; }
        public double ElectricCumulant { get; set; }
        public double TotalElectricCumulant { get; set; }
        public double WaterCumulant { get; set; }
        public double TotalWaterCumulant { get; set; }


    }
}