using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class AcquisitionMethod
{
    public int Id { get; set; }

    public string MethodName { get; set; } = null!;

    public virtual ICollection<Warframe> Warframes { get; set; } = new List<Warframe>();

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
