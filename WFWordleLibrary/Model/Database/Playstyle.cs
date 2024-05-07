using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class Playstyle
{
    public int Id { get; set; }

    public string PlaystyleName { get; set; } = null!;

    public virtual ICollection<Warframe> Warframes { get; set; } = new List<Warframe>();
}
