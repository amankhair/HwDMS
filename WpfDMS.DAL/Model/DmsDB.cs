namespace WpfDMS.DAL
{
    using System.Data.Entity;

    public partial class DmsDB : DbContext
    {
        public DmsDB()
            : base("name=DmsDB")
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Laboratory> Laboratory { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.b_test_charge)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.b_delivery_charges)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.d_name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.d_gender)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.d_adress)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.d_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.d_login)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.d_password)
                .IsUnicode(false);

            modelBuilder.Entity<Laboratory>()
                .Property(e => e.lab_name)
                .IsUnicode(false);

            modelBuilder.Entity<Laboratory>()
                .Property(e => e.lab_adress)
                .IsUnicode(false);

            modelBuilder.Entity<Laboratory>()
                .Property(e => e.lab_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Laboratory>()
                .Property(e => e.lab_timings)
                .IsUnicode(false);

            modelBuilder.Entity<Laboratory>()
                .Property(e => e.lab_tests)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.p_name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.p_gender)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.p_adress)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.p_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.p_login)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.p_password)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.t_name)
                .IsUnicode(false);
        }
    }
}
