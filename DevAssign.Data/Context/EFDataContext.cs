using DevAssign.Data.Contracts;
using DevAssign.Data.Model;
using System.Data.Entity;

namespace DevAssign.Data.Context
{
    public class EFDataContext : DbContext
    {
        public EFDataContext()
            : base("SqlDataContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDataContext, DevAssign.Data.Migrations.Configuration>("SqlDataContext"));
        }

        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<ToDo> ToDo { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Reminder> Reminder { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Relations
            modelBuilder.Entity<Reminder>()
                .HasRequired<Task>(x => x.Task)
                .WithMany(x => x.Reminders)
                .HasForeignKey(x => x.TaskId);

            modelBuilder.Entity<ToDo>()
                .HasRequired<User>(x => x.User)
                .WithMany(x => x.ToDos)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Task>()
                .HasRequired<ToDo>(x => x.ToDo)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ToDoId);
             

            base.OnModelCreating(modelBuilder);
        }
    }
}
