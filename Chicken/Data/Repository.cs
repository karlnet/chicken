using Chicken.Data.Entities;
using Chicken.DTOs;
using Chicken.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.Data
{
    public class Repository : IRepository
    {
        private AppDbContext db;  
        public Repository(AppDbContext ctx)
        {
            db = ctx;    
        }
        public YFBatchRecord GetLastBatchInfo(int projectid) {
            return db.YFBatchRecords.Where(m => m.ProjectID_int == projectid).OrderByDescending(m => m.BatchID_int).FirstOrDefault();
        }
        public bool HasProject(int projectid)
        {
            return db.IsExists<YFProject>(m => m.ProjectID_int == projectid);
        }

        public YFBatchRecordAddChicken GetLastAddChickenInfo(int projectid,int batchid)
        {
            return db.Where<YFBatchRecordAddChicken>(m => m.BatchID_int == batchid && m.ProjectID_int == projectid).OrderByDescending(m => m.DTCreate_datetime).FirstOrDefault();
        }

        public YFChickenDailyReport GetLastDayReport(int projectid, int batchid)
        {
            return db.Where<YFChickenDailyReport>(m => m.ProjectID_int == projectid && m.BatchID_int == batchid).OrderByDescending(m => m.DTCreate_datetime).FirstOrDefault();
        }

        public IQueryable<YFChickenDailyReport> GetAllDayReport(int projectid, int batchid)
        {
            return db.Where<YFChickenDailyReport>(m => m.ProjectID_int == projectid && m.BatchID_int == batchid).OrderBy(m => m.DTCreate_datetime);
        }

        public int GetDayAddChickenAmount(int projectid,int batchid)
        {
            int num = 0;
            var lastInfo = db.Where<YFBatchRecordAddChicken>(m => m.BatchID_int == batchid && m.ProjectID_int == projectid).OrderByDescending(m => m.DTCreate_datetime).FirstOrDefault();
            if (lastInfo.DTCreate_datetime.ToShortDateString() != DateTime.Now.ToShortDateString())       // no day report             
                return lastInfo.ChickenAmount_int ?? 0 + lastInfo.TotalChickenAmount_int ?? 0;

            return num;
        }
        public IQueryable<YFProject> GetUserProjects(List<int> projectids)
        {
            var projects = db.Where<YFProject>( m=> projectids.Contains(m.ProjectID_int));
            return projects;
        }
        public IQueryable<YFChickenHouseInfo> GetUserHouses(List<int> projectids)
        {
            var houses = db.Where<YFChickenHouseInfo>(m => projectids.Contains(m.ID));
            return houses;
        }
    }
}