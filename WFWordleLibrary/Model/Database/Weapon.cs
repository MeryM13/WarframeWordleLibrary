using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class Weapon
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsExalted { get; set; }

    public bool HasIncarnon { get; set; }

    public bool IsSignature { get; set; }

    public int ReleasedInUpdate { get; set; }

    public int Association { get; set; }

    public decimal FireRate { get; set; }

    public decimal Multishot { get; set; }

    public decimal ReloadSpeed { get; set; }

    public int MagazineSize { get; set; }

    public int AmmoMax { get; set; }

    public decimal CritChanceValue { get; set; }

    public decimal CritDamageValue { get; set; }

    public decimal StatusChance { get; set; }

    public decimal Impact { get; set; }

    public decimal Puncture { get; set; }

    public decimal Slash { get; set; }

    public int? AddedElement { get; set; }

    public decimal? AddedElementDamage { get; set; }

    public decimal Damage { get; set; }

    public string? WeaponPictureLink { get; set; }

    public virtual Element? AddedElementNavigation { get; set; }

    public virtual Fraction AssociationNavigation { get; set; } = null!;

    public virtual ICollection<DateDatum> DateData { get; set; } = new List<DateDatum>();

    public virtual GameUpdate ReleasedInUpdateNavigation { get; set; } = null!;

    public virtual ICollection<WeaponGuess> WeaponGuesses { get; set; } = new List<WeaponGuess>();

    public virtual ICollection<AcquisitionMethod> AcquisitionMethods { get; set; } = new List<AcquisitionMethod>();

    public virtual ICollection<WeaponSlot> WeaponSlots { get; set; } = new List<WeaponSlot>();

    public virtual ICollection<WeaponTriggerType> WeaponTriggerTypes { get; set; } = new List<WeaponTriggerType>();

    public virtual ICollection<WeaponType> WeaponTypes { get; set; } = new List<WeaponType>();

    public virtual ICollection<WeaponVariant> WeaponVariants { get; set; } = new List<WeaponVariant>();
}
