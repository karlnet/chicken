namespace Chicken.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Chicken.Infrastructure;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Entities;

    public partial class AppDbContext :  IdentityDbContext<ApplicationUser>

    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }
        public virtual DbSet<YFIOIntValue> YFIOIntValues { get; set; }
        public virtual DbSet<YFProjectIO> YFProjectIOs { get; set; }
        public virtual DbSet<YFProjectWeightInfo> YFProjectWeightInfos { get; set; }
        public virtual DbSet<YFBabyChickenSupplier> YFBabyChickenSuppliers { get; set; }
        public virtual DbSet<YFChickenHouseInfo> YFChickenHouseInfos { get; set; }
        public virtual DbSet<YFFodderSupplier> YFFodderSuppliers { get; set; }

        public virtual DbSet<InitChickenIndex> InitChickenIndexs { get; set; }
        public virtual DbSet<YFIOFloatValue> YFIOFloatValues { get; set; }
        public virtual DbSet<YFBatchRecord> YFBatchRecords { get; set; }
        public virtual DbSet<YFBatchRecordAddChicken> YFBatchRecordAddChickens { get; set; }
        public virtual DbSet<YFChickenDailyReport> YFChickenDailyReports { get; set; }
        public virtual DbSet<YFProject> YFProjects { get; set; }
        public virtual DbSet<YFUserInfo> YFUserInfoes { get; set; }
        public virtual DbSet<YFUserProject> YFUserProjects { get; set; }
        public virtual DbSet<Device> devices { get; set; }
        public virtual DbSet<Platform> platforms { get; set; }
        public virtual DbSet<Point> points { get; set; }
        public virtual DbSet<Project> projects { get; set; }
        public virtual DbSet<Project_Role> project_roles { get; set; }
        public virtual DbSet<Role_Device> role_devices { get; set; }
        public virtual DbSet<Role_Point> role_points { get; set; }
        public virtual DbSet<User_Project> user_projects { get; set; }
       
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
