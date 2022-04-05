using Microsoft.EntityFrameworkCore;
using KursModels.Models;

namespace KursModels
{
    public class KursDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=Aln-Pc\SQLEXPRESS;Initial Catalog=CannedFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;");  //DESKTOP-H7FNSK3   ||  Aln-Pc
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Teacher> Teachers { set; get; }
        public virtual DbSet<Task> Tasks { set; get; }
        public virtual DbSet<StudentD> CannedComponents { set; get; }
        public virtual DbSet<ProductD> Products { set; get; }
        public virtual DbSet<MMMaterialTask> MaterialTasks { set; get; }
        public virtual DbSet<MMMaterialClass> MaterialClasses { set; get; }
        public virtual DbSet<MMInteresStudent> InteresStudents { set; get; }
        public virtual DbSet<MMInteresProduct> InteresProducts { set; get; }
        public virtual DbSet<MMInteresCraft> InteresCrafts { set; get; }
        public virtual DbSet<MMClassProduct> ClassProducts { set; get; }
        public virtual DbSet<Material> Materials { set; get; }
        public virtual DbSet<InterestD> Interests { set; get; }
        public virtual DbSet<CraftD> Crafts { set; get; }
        public virtual DbSet<Class> Classes { set; get; }
    }
}
