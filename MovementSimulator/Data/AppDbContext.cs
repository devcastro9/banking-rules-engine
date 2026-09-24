using Microsoft.EntityFrameworkCore;
using MovementSimulator.Models;

namespace MovementSimulator.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountMovement> AccountMovements { get; set; }

    public virtual DbSet<AccountStatus> AccountStatuses { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<DepositAccount> DepositAccounts { get; set; }

    public virtual DbSet<LegalEntityType> LegalEntityTypes { get; set; }

    public virtual DbSet<LegalPerson> LegalPersons { get; set; }

    public virtual DbSet<MovementStatus> MovementStatuses { get; set; }

    public virtual DbSet<MovementType> MovementTypes { get; set; }

    public virtual DbSet<NaturalPerson> NaturalPersons { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonType> PersonTypes { get; set; }

    public virtual DbSet<VDepositAccountsSummary> VDepositAccountsSummaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<AccountMovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_movements_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountMovements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_movements_account_fk");

            entity.HasOne(d => d.MovementType).WithMany(p => p.AccountMovements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_movements_type_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.AccountMovements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_movements_status_fk");
        });

        modelBuilder.Entity<AccountStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_status_pkey");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_type_pkey");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("currency_pkey");

            entity.Property(e => e.Code).IsFixedLength();
        });

        modelBuilder.Entity<DepositAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deposit_account_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.AccountType).WithMany(p => p.DepositAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("deposit_account_account_type_fk");

            entity.HasOne(d => d.Currency).WithMany(p => p.DepositAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("deposit_account_currency_fk");

            entity.HasOne(d => d.Person).WithMany(p => p.DepositAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("deposit_account_person_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.DepositAccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("deposit_account_status_fk");
        });

        modelBuilder.Entity<LegalEntityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("legal_entity_type_pkey");
        });

        modelBuilder.Entity<LegalPerson>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("legal_persons_pkey");

            entity.Property(e => e.PersonId).ValueGeneratedNever();

            entity.HasOne(d => d.LegalEntityType).WithMany(p => p.LegalPeople)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("legal_persons_type_fk");

            entity.HasOne(d => d.Person).WithOne(p => p.LegalPerson).HasConstraintName("legal_persons_person_fk");
        });

        modelBuilder.Entity<MovementStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movement_status_pkey");
        });

        modelBuilder.Entity<MovementType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movement_type_pkey");

            entity.Property(e => e.Sign).HasDefaultValue((short)0);
        });

        modelBuilder.Entity<NaturalPerson>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("natural_persons_pkey");

            entity.Property(e => e.PersonId).ValueGeneratedNever();

            entity.HasOne(d => d.Person).WithOne(p => p.NaturalPerson).HasConstraintName("natural_persons_person_fk");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("persons_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.PersonType).WithMany(p => p.People)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("persons_person_type_fk");
        });

        modelBuilder.Entity<PersonType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_type_pkey");
        });

        modelBuilder.Entity<VDepositAccountsSummary>(entity =>
        {
            entity.ToView("v_deposit_accounts_summary");

            entity.Property(e => e.Currency).IsFixedLength();
        });
        modelBuilder.HasSequence("deposit_account_number_seq")
            .HasMin(1000000000L)
            .HasMax(9999999999L);
        modelBuilder.HasSequence("transaction_number_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
