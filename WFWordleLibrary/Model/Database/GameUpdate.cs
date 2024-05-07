using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class GameUpdate
{
    public int Id { get; set; }

    public string UpdateTitle { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    public virtual ICollection<Warframe> Warframes { get; set; } = new List<Warframe>();

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
