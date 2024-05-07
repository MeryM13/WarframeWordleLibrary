using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class Gender
{
    public int Id { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Warframe> Warframes { get; set; } = new List<Warframe>();
}
