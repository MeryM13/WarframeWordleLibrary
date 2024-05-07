using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class Element
{
    public int Id { get; set; }

    public string ElementName { get; set; } = null!;

    public string? ElementPictureLink { get; set; }

    public virtual ICollection<Warframe> Warframes { get; set; } = new List<Warframe>();

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
