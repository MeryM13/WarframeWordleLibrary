using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class WeaponVariant
{
    public int Id { get; set; }

    public string VariantName { get; set; } = null!;

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
