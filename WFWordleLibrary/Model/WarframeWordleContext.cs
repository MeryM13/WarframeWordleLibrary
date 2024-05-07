using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WFWordleLibrary.Model.Database;

namespace WFWordleLibrary.Model;

public partial class WarframeWordleContext : DbContext
{
    public WarframeWordleContext()
    {
    }

    public WarframeWordleContext(DbContextOptions<WarframeWordleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcquisitionMethod> AcquisitionMethods { get; set; }

    public virtual DbSet<DateDatum> DateData { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<Fraction> Fractions { get; set; }

    public virtual DbSet<GameUpdate> GameUpdates { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<PlayerDateDatum> PlayerDateData { get; set; }

    public virtual DbSet<Playstyle> Playstyles { get; set; }

    public virtual DbSet<Polarity> Polarities { get; set; }

    public virtual DbSet<Warframe> Warframes { get; set; }

    public virtual DbSet<WarframeGame> WarframeGames { get; set; }

    public virtual DbSet<WarframeGuess> WarframeGuesses { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    public virtual DbSet<WeaponGame> WeaponGames { get; set; }

    public virtual DbSet<WeaponGuess> WeaponGuesses { get; set; }

    public virtual DbSet<WeaponSlot> WeaponSlots { get; set; }

    public virtual DbSet<WeaponTriggerType> WeaponTriggerTypes { get; set; }

    public virtual DbSet<WeaponType> WeaponTypes { get; set; }

    public virtual DbSet<WeaponVariant> WeaponVariants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=WarframeWordle;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcquisitionMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Acquisit__3214EC27CEE9D9F2");

            entity.ToTable("AcquisitionMethod");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MethodName).HasMaxLength(20);
        });

        modelBuilder.Entity<DateDatum>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("PK__DateData__77387D06ECF40503");

            entity.HasOne(d => d.TodayWarframeNavigation).WithMany(p => p.DateData)
                .HasForeignKey(d => d.TodayWarframe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DateData__TodayW__5EBF139D");

            entity.HasOne(d => d.TodayWeaponNavigation).WithMany(p => p.DateData)
                .HasForeignKey(d => d.TodayWeapon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DateData__TodayW__5FB337D6");
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Element__3214EC272452D3C2");

            entity.ToTable("Element");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ElementName).HasMaxLength(15);
            entity.Property(e => e.ElementPictureLink).HasColumnType("text");
        });

        modelBuilder.Entity<Fraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fraction__3214EC279BA8D9D9");

            entity.ToTable("Fraction");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FractionName).HasMaxLength(20);
            entity.Property(e => e.FractionPictureLink).HasColumnType("text");
        });

        modelBuilder.Entity<GameUpdate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameUpda__3214EC27978663DE");

            entity.ToTable("GameUpdate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UpdateTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3214EC270440C780");

            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GenderName).HasMaxLength(15);
        });

        modelBuilder.Entity<PlayerDateDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerDa__3214EC27D03BE2A3");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PlayerIp)
                .HasColumnType("text")
                .HasColumnName("PlayerIP");

            entity.HasOne(d => d.DateDataNavigation).WithMany(p => p.PlayerDateData)
                .HasForeignKey(d => d.DateData)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerDat__DateD__628FA481");
        });

        modelBuilder.Entity<Playstyle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Playstyl__3214EC27345EE958");

            entity.ToTable("Playstyle");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PlaystyleName).HasMaxLength(20);
        });

        modelBuilder.Entity<Polarity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Polarity__3214EC27CCCC7C05");

            entity.ToTable("Polarity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PolarityLetter).HasMaxLength(10);
            entity.Property(e => e.PolarityName).HasMaxLength(15);
            entity.Property(e => e.PolarityPictureLink).HasColumnType("text");
        });

        modelBuilder.Entity<Warframe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warframe__3214EC27396337B6");

            entity.ToTable("Warframe");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SprintSpeed).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.WarframePictureLink).HasColumnType("text");

            entity.HasOne(d => d.AuraPolarityNavigation).WithMany(p => p.Warframes)
                .HasForeignKey(d => d.AuraPolarity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warframe__AuraPo__5165187F");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Warframes)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warframe__Gender__4F7CD00D");

            entity.HasOne(d => d.ProgenitorElementNavigation).WithMany(p => p.Warframes)
                .HasForeignKey(d => d.ProgenitorElement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warframe__Progen__52593CB8");

            entity.HasOne(d => d.ReleasedInUpdateNavigation).WithMany(p => p.Warframes)
                .HasForeignKey(d => d.ReleasedInUpdate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warframe__Releas__5070F446");

            entity.HasMany(d => d.AcquisitionMethods).WithMany(p => p.Warframes)
                .UsingEntity<Dictionary<string, object>>(
                    "WarframeAcquisition",
                    r => r.HasOne<AcquisitionMethod>().WithMany()
                        .HasForeignKey("AcquisitionMethod")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WarframeA__Acqui__5629CD9C"),
                    l => l.HasOne<Warframe>().WithMany()
                        .HasForeignKey("Warframe")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WarframeA__Warfr__5535A963"),
                    j =>
                    {
                        j.HasKey("Warframe", "AcquisitionMethod").HasName("PK__Warframe__641891C697D5DC11");
                        j.ToTable("WarframeAcquisition");
                    });

            entity.HasMany(d => d.CommonPlaystyles).WithMany(p => p.Warframes)
                .UsingEntity<Dictionary<string, object>>(
                    "WarframePlaystyle",
                    r => r.HasOne<Playstyle>().WithMany()
                        .HasForeignKey("CommonPlaystyle")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WarframeP__Commo__5BE2A6F2"),
                    l => l.HasOne<Warframe>().WithMany()
                        .HasForeignKey("Warframe")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WarframeP__Warfr__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("Warframe", "CommonPlaystyle").HasName("PK__Warframe__A3A71DF875F2499F");
                        j.ToTable("WarframePlaystyle");
                    });
        });

        modelBuilder.Entity<WarframeGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warframe__3214EC276CA799E6");

            entity.ToTable("WarframeGame");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.PlayerDataNavigation).WithMany(p => p.WarframeGames)
                .HasForeignKey(d => d.PlayerData)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WarframeG__Playe__656C112C");
        });

        modelBuilder.Entity<WarframeGuess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warframe__3214EC27FF6E180B");

            entity.ToTable("WarframeGuess");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TotalScore).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.GameNavigation).WithMany(p => p.WarframeGuesses)
                .HasForeignKey(d => d.Game)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WarframeGu__Game__6B24EA82");

            entity.HasOne(d => d.SelectedWarframeNavigation).WithMany(p => p.WarframeGuesses)
                .HasForeignKey(d => d.SelectedWarframe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WarframeG__Selec__6C190EBB");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Weapon__3214EC27704096F1");

            entity.ToTable("Weapon");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedElementDamage).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.CritChanceValue).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.CritDamageValue).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Damage).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FireRate).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Impact).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Multishot).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Puncture).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.ReloadSpeed).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Slash).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.StatusChance).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.WeaponPictureLink).HasColumnType("text");

            entity.HasOne(d => d.AddedElementNavigation).WithMany(p => p.Weapons)
                .HasForeignKey(d => d.AddedElement)
                .HasConstraintName("FK__Weapon__AddedEle__300424B4");

            entity.HasOne(d => d.AssociationNavigation).WithMany(p => p.Weapons)
                .HasForeignKey(d => d.Association)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Weapon__Associat__2F10007B");

            entity.HasOne(d => d.ReleasedInUpdateNavigation).WithMany(p => p.Weapons)
                .HasForeignKey(d => d.ReleasedInUpdate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Weapon__Released__2E1BDC42");

            entity.HasMany(d => d.AcquisitionMethods).WithMany(p => p.Weapons)
                .UsingEntity<Dictionary<string, object>>(
                    "WeaponAcquisition",
                    r => r.HasOne<AcquisitionMethod>().WithMany()
                        .HasForeignKey("AcquisitionMethod")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponAcq__Acqui__4AB81AF0"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("Weapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponAcq__Weapo__49C3F6B7"),
                    j =>
                    {
                        j.HasKey("Weapon", "AcquisitionMethod").HasName("PK__WeaponAc__D308FB8790575A7A");
                        j.ToTable("WeaponAcquisition");
                    });

            entity.HasMany(d => d.WeaponSlots).WithMany(p => p.Weapons)
                .UsingEntity<Dictionary<string, object>>(
                    "WeaponSlotPairing",
                    r => r.HasOne<WeaponSlot>().WithMany()
                        .HasForeignKey("WeaponSlot")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponSlo__Weapo__35BCFE0A"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("Weapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponSlo__Weapo__34C8D9D1"),
                    j =>
                    {
                        j.HasKey("Weapon", "WeaponSlot").HasName("PK__WeaponSl__EF2FEE297C25627D");
                        j.ToTable("WeaponSlotPairing");
                    });

            entity.HasMany(d => d.WeaponTriggerTypes).WithMany(p => p.Weapons)
                .UsingEntity<Dictionary<string, object>>(
                    "WeaponTriggerTypePairing",
                    r => r.HasOne<WeaponTriggerType>().WithMany()
                        .HasForeignKey("WeaponTriggerType")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponTri__Weapo__412EB0B6"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("Weapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponTri__Weapo__403A8C7D"),
                    j =>
                    {
                        j.HasKey("Weapon", "WeaponTriggerType").HasName("PK__WeaponTr__87FCAE8A29D94259");
                        j.ToTable("WeaponTriggerTypePairing");
                    });

            entity.HasMany(d => d.WeaponTypes).WithMany(p => p.Weapons)
                .UsingEntity<Dictionary<string, object>>(
                    "WeaponTypePairing",
                    r => r.HasOne<WeaponType>().WithMany()
                        .HasForeignKey("WeaponType")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponTyp__Weapo__3B75D760"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("Weapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponTyp__Weapo__3A81B327"),
                    j =>
                    {
                        j.HasKey("Weapon", "WeaponType").HasName("PK__WeaponTy__2F0BAE8D9B5988F7");
                        j.ToTable("WeaponTypePairing");
                    });

            entity.HasMany(d => d.WeaponVariants).WithMany(p => p.Weapons)
                .UsingEntity<Dictionary<string, object>>(
                    "WeaponVariantPairing",
                    r => r.HasOne<WeaponVariant>().WithMany()
                        .HasForeignKey("WeaponVariant")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponVar__Weapo__46E78A0C"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("Weapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__WeaponVar__Weapo__45F365D3"),
                    j =>
                    {
                        j.HasKey("Weapon", "WeaponVariant").HasName("PK__WeaponVa__3FC58C5A9861460B");
                        j.ToTable("WeaponVariantPairing");
                    });
        });

        modelBuilder.Entity<WeaponGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponGa__3214EC278F836772");

            entity.ToTable("WeaponGame");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.PlayerDataNavigation).WithMany(p => p.WeaponGames)
                .HasForeignKey(d => d.PlayerData)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WeaponGam__Playe__68487DD7");
        });

        modelBuilder.Entity<WeaponGuess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponGu__3214EC27A4173CD0");

            entity.ToTable("WeaponGuess");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TotalScore).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.GameNavigation).WithMany(p => p.WeaponGuesses)
                .HasForeignKey(d => d.Game)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WeaponGues__Game__6EF57B66");

            entity.HasOne(d => d.SelectedWeaponNavigation).WithMany(p => p.WeaponGuesses)
                .HasForeignKey(d => d.SelectedWeapon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WeaponGue__Selec__6FE99F9F");
        });

        modelBuilder.Entity<WeaponSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponSl__3214EC27B30EB7F9");

            entity.ToTable("WeaponSlot");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SlotName).HasMaxLength(20);
        });

        modelBuilder.Entity<WeaponTriggerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponTr__3214EC272C700A83");

            entity.ToTable("WeaponTriggerType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TriggerTypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<WeaponType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponTy__3214EC276198C6CF");

            entity.ToTable("WeaponType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<WeaponVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponVa__3214EC27E90D432D");

            entity.ToTable("WeaponVariant");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.VariantName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
