using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class Polarity
{
    public int Id { get; set; }

    public string PolarityName { get; set; } = null!;

    public string PolarityLetter { get; set; } = null!;

    public string? PolarityPictureLink { get; set; }

    public virtual ICollection<Warframe> Warframes { get; set; } = new List<Warframe>();
}
