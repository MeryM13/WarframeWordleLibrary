using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class WeaponSlot
{
    public int Id { get; set; }

    public string SlotName { get; set; } = null!;

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
