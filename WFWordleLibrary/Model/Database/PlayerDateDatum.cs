using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class PlayerDateDatum
{
    public int Id { get; set; }

    public DateOnly DateData { get; set; }

    public string PlayerIp { get; set; } = null!;

    public virtual DateDatum DateDataNavigation { get; set; } = null!;

    public virtual ICollection<WarframeGame> WarframeGames { get; set; } = new List<WarframeGame>();

    public virtual ICollection<WeaponGame> WeaponGames { get; set; } = new List<WeaponGame>();
}
