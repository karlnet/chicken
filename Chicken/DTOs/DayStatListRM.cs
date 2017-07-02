﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chicken.Data.Entities;
namespace Chicken.DTOs
{
    public class DayStatListRM
    {
        public DayStatListRM(IEnumerable<YFChickenDailyReport> dayReportList)
        {
            WorkReportList = new List<WorkReport>();
            foreach(YFChickenDailyReport m in dayReportList)
            {
                var workReport = new WorkReport();
                workReport.Age = m.Day_int??0;
                workReport.DieAmount = m.DieAmount_int ?? 0;
                workReport.DieAmountIndex = ((workReport.DieAmount + m.TotalDieAmount_int.Value) * 1.0000d / m.TotalChickenAmount_int * 1.0000d).Value.ToString("0.0000");
                workReport.Weight =( m.Weight_float??0).ToString();
                workReport.Evenness = (m.Evenness_float ?? 0).ToString();
                workReport.FodderCumulant = (m.FodderCumulant_float ?? 0d).ToString();
                workReport.Medicine = (m.Medicine_float ?? 0).ToString();
                workReport.OtherItem = (m.OtherItem_float ?? 0).ToString();
                workReport.WaterCumulant = (m.WaterCumulant_float ?? 0d).ToString();
                workReport.CoalCumulant = (m.CoalCumulant_float ?? 0d).ToString();
                workReport.ElectricCumulant =( m.ElectricCumulant_float??0d).ToString();
                //workReport.AddChickenAmount = addList.Where(a => a.DTCreate_datetime.ToShortDateString() == m.DTCreate_datetime.ToShortDateString()).Sum(n => n.ChickenAmount_int).ToString();
                workReport.FodderWeightIndex = (m.Weight_float ?? 0) == 0 ? "0.0000" : (((m.FodderCumulant_float??0) + m.TotalFodderCumulant_float) / (m.TotalChickenAmount_int * m.Weight_float??0)).Value.ToString("0.0000");
                workReport.FodderChickenIndex = ((m.FodderCumulant_float ?? 0 + m.TotalFodderCumulant_float) / m.TotalChickenAmount_int).Value.ToString("0.0000");
                workReport.WaterFodderIndex = ((m.WaterCumulant_float ?? 0 + m.TotalWaterCumulant_float)/ ((m.FodderCumulant_float ?? 0 + m.TotalFodderCumulant_float))).Value.ToString("0.0000");

                WorkReportList.Add(workReport);
            }
        }
        public string LairageDate { get; set; }
        public int LairageAmount { get; set; }
        public int TotalChickenAmount { get; set; }
        public int ChickenTypeID { get; set; }
        public List<WorkReport> WorkReportList { get; set; }

    }

    public class WorkReport
    {
        public int Age { get; set; }
        public int DieAmount { get; set; }
        public string DieAmountIndex { get; set; }
        public string Weight { get; set; }
        public string Evenness { get; set; }
        public string FodderCumulant { get; set; }
        public string CoalCumulant { get; set; }
        public string Medicine { get; set; }
        public string OtherItem { get; set; }
        public string WaterCumulant { get; set; }
        public string ElectricCumulant { get; set; }
        //public string AddChickenAmount { get; set; }
        public string WaterFodderIndex { get; set; }
        public string FodderWeightIndex { get; set; }
        public string FodderChickenIndex { get; set; }
    }



}