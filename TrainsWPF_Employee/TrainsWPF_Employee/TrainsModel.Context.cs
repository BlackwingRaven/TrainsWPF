//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainsWPF_Employee
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrainsDBEntities : DbContext
    {
        public TrainsDBEntities()
            : base("name=TrainsDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Train> Train { get; set; }
    }
}
