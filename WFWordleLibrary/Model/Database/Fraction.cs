using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class Fraction
{
    public int Id { get; set; }

    public string FractionName { get; set; } = null!;

    public string? FractionPictureLink { get; set; }

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
