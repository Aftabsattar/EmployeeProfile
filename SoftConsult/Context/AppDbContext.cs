using Microsoft.EntityFrameworkCore;
using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Grade> Grade { get; set; }
    public DbSet<EmployeeStatus> EmployeeStatus { get; set; }
    public DbSet<JobStatus> JobStatus { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<EmployeeListViewModel> EmployeeList { get; set; }
    public DbSet<DepartmentLevel> DepartmentLevels { get; set; }
    public DbSet<Religion> Religion { get; set; }
    public DbSet<LevelPolicy> LevelPolicie { get; set; }
    public DbSet<Gender> Gender { get; set; }
    public DbSet<MaritalStatus> MaritalStatuses { get; set; }
    public DbSet<BloodGroup> BloodGroup { get; set; }
    public DbSet<Designation> Designation { get; set; }
    public DbSet<Nationality> Nationality { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<SurName> SurName { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<EmployeeListViewModel>().HasNoKey();
    }
}