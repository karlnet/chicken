namespace HtIOT.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HtIOT.Infrastructure;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class AppDbContext :  IdentityDbContext<ApplicationUser>

    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }
        
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
