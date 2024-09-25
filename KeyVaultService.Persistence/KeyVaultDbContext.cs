using KeyVaultService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeyVaultService.Persistence;

/// <summary>
/// Key vault db context
/// </summary>
public class KeyVaultDbContext : DbContext
{
    /// <summary>
    /// C-tor
    /// </summary>
    /// <param name="options">Db context options</param>
    public KeyVaultDbContext(DbContextOptions<KeyVaultDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Policies db set
    /// </summary>
    public DbSet<Policy> Policies { get; set; }

    /// <summary>
    /// Secrets db set
    /// </summary>
    public DbSet<Secret> Secrets { get; set; }

    /// <summary>
    /// Sercret value db set
    /// </summary>
    public DbSet<SecretValue> SecretValues { get; set; }

    /// <summary>
    /// Secret value logs db set
    /// </summary>
    public DbSet<SecretValueLog> SecretValueLogs { get; set; }

    /// <summary>
    /// Vault db set
    /// </summary>
    public DbSet<Vault> Vaults { get; set; }

    /// <summary>
    /// Vault policy db set
    /// </summary>
    public DbSet<VaultPolicy> VaultPolicies { get; set; }
    
    /// <inheritdoc cref="DbContext.OnModelCreating"/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Policy__3214EC07A8BDFE59");

            entity.ToTable("Policy");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Secret>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Secret__3214EC079D63AB5D");

            entity.ToTable("Secret");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.VaultId).HasColumnName("Vault_Id");

            entity.HasOne(d => d.Vault).WithMany(p => p.Secrets)
                .HasForeignKey(d => d.VaultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Secret__Vault_Id__3A81B327");
        });

        modelBuilder.Entity<SecretValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SecretVa__3214EC071CD5272A");

            entity.ToTable("SecretValue");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.SecretId).HasColumnName("Secret_Id");
            entity.Property(e => e.Value)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.Secret).WithMany(p => p.SecretValues)
                .HasForeignKey(d => d.SecretId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SecretVal__Secre__3D5E1FD2");
        });

        modelBuilder.Entity<SecretValueLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SecretVa__3214EC076E8526B6");

            entity.ToTable("SecretValueLog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LastOperationTimestamp).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecretId).HasColumnName("Secret_Id");
            entity.Property(e => e.SecretValueId).HasColumnName("SecretValue_Id");

            entity.HasOne(d => d.Secret).WithMany(p => p.SecretValueLogs)
                .HasForeignKey(d => d.SecretId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SecretVal__Secre__412EB0B6");

            entity.HasOne(d => d.SecretValue).WithMany(p => p.SecretValueLogs)
                .HasForeignKey(d => d.SecretValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SecretVal__Secre__4222D4EF");
        });

        modelBuilder.Entity<Vault>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vault__3214EC07C105CC91");

            entity.ToTable("Vault");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<VaultPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VaultPol__3214EC07BB671217");

            entity.ToTable("VaultPolicy");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ObjectId).HasColumnName("Object_Id");
            entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");
            entity.Property(e => e.VaultId).HasColumnName("Vault_Id");

            entity.HasOne(d => d.Policy).WithMany(p => p.VaultPolicies)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VaultPoli__Polic__46E78A0C");

            entity.HasOne(d => d.Vault).WithMany(p => p.VaultPolicies)
                .HasForeignKey(d => d.VaultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VaultPoli__Vault__47DBAE45");
        });

        base.OnModelCreating(modelBuilder);
    }
}
