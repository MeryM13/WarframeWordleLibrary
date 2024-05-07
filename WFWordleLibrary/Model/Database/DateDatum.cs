using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class DateDatum
{
    public DateOnly Date { get; set; }

    public int TodayWarframe { get; set; }

    public int TodayWeapon { get; set; }

    public virtual ICollection<PlayerDateDatum> PlayerDateData { get; set; } = new List<PlayerDateDatum>();

    public virtual Warframe TodayWarframeNavigation { get; set; } = null!;

    public virtual Weapon TodayWeaponNavigation { get; set; } = null!;
}
