using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AutoSound.Model.ModelDb;

public class AutoSoundDbContext: DbContext
{

    public virtual DbSet<Employee> Employees  { get; set; } = null!;
    public virtual DbSet<Security> Securities  { get; set; } = null!;
    public virtual DbSet<Post> Posts { get; set; } = null!;
    public virtual DbSet<Stock> Stocks  { get; set; } = null!;
    public virtual DbSet<Achive>  Achives { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IKCHMR8\\HOLLOWSPACE;Database=AutoSoundDB;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity("AutoSound.Model.ModelDb.Achive", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Comment")
                .HasColumnType("nvarchar(max)");

            b.Property<int?>("Count")
                .HasColumnType("int");

            b.Property<decimal?>("Price")
                .HasColumnType("money");

            b.Property<string>("Status")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Title")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Type")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Achives");
        });

        modelBuilder.Entity("AutoSound.Model.ModelDb.Employee", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Name")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<int>("PostId")
                .HasColumnType("int");

            b.Property<string>("SecondName")
                .HasColumnType("nvarchar(max)");

            b.Property<int>("SecurityId")
                .HasColumnType("int");

            b.Property<string>("SurName")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.HasIndex("PostId");

            b.HasIndex("SecurityId");

            b.ToTable("Employees");
        });

        modelBuilder.Entity("AutoSound.Model.ModelDb.Post", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Title")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Posts");
        });

        modelBuilder.Entity("AutoSound.Model.ModelDb.Security", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Login")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Password")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Securities");
        });

        modelBuilder.Entity("AutoSound.Model.ModelDb.Stock", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Comment")
                .HasColumnType("nvarchar(max)");

            b.Property<int?>("Count")
                .HasColumnType("int");

            b.Property<decimal?>("Price")
                .HasColumnType("money");

            b.Property<string>("Status")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Title")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Type")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Stocks");
        });

        modelBuilder.Entity("AutoSound.Model.ModelDb.Employee", b =>
        {
            b.HasOne("AutoSound.Model.ModelDb.Post", "Post")
                .WithMany("Employees")
                .HasForeignKey("PostId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("AutoSound.Model.ModelDb.Security", "Security")
                .WithMany()
                .HasForeignKey("SecurityId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Post");

            b.Navigation("Security");
        });

        modelBuilder.Entity("AutoSound.Model.ModelDb.Post", b =>
        {
            b.Navigation("Employees");
        });
    }

}