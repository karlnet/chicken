namespace Chicken.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<InitChickenIndex> InitChickenIndexs { get; set; }
        public virtual DbSet<YFIOFloatValue> YFIOFloatValues { get; set; }
        public virtual DbSet<YFBatchRecord> YFBatchRecords { get; set; }
        public virtual DbSet<YFBatchRecordAddChicken> YFBatchRecordAddChickens { get; set; }
        public virtual DbSet<YFChickenDailyReport> YFChickenDailyReports { get; set; }
        public virtual DbSet<YFProject> YFProjects { get; set; }
        public virtual DbSet<YFUserInfo> YFUserInfoes { get; set; }
        public virtual DbSet<YFUserProject> YFUserProjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YFBatchRecord>()
                .HasMany(e => e.YFBatchRecordAddChickens)
                .WithRequired(e => e.YFBatchRecord)
                .HasForeignKey(e => new { e.BatchID_int, e.ProjectID_int })
                .WillCascadeOnDelete(false);
        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
