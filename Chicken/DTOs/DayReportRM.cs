﻿using Chicken.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.DTOs
{
    public class DayReportRM
    {
        public DayReportRM(YFChickenDailyReport dayReport)
        {
            HasWorkReport = 1;
            DieAmount = dayReport.DieAmount_int ?? 0;
            //Weight = dayReport.Weight_float ?? 0;
            //FodderCumulant = dayReport.FodderCumulant_float ?? 0;
            Medicine = dayReport.Medicine_float ?? 0;
            OtherItem = dayReport.OtherItem_float ?? 0;
            CoalCumulant = dayReport.CoalCumulant_float ?? 0;

            Eggs = dayReport.Eggs ?? 0;
            EggsBad = dayReport.EggsBad ?? 0;
            EggsBox = dayReport.EggsBox ?? 0;
            EggsWeight = dayReport.EggsWeight ?? 0;



        }
        public DayReportRM()
        {

        }
        public string LairageDate { get; set; }
        public int ChickenTypeID { get; set; }
        public int Age { get; set; }
        public int TotalChickenAmount { get; set; }
        public int HasWorkReport { get; set; }
        public int DieAmount { get; set; }
        public double Weight { get; set; }
        public double FodderCumulant { get; set; }
        public double Medicine { get; set; }
        public double OtherItem { get; set; }
        public double CoalCumulant { get; set; }

        public int Eggs { get; set; }
        public int EggsBad { get; set; }
        public int EggsBox { get; set; }
        public double EggsWeight { get; set; }


    }
}