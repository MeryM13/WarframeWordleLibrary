using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class WarframeGuess
{
    public int Id { get; set; }

    public int Game { get; set; }

    public int SelectedWarframe { get; set; }

    public decimal TotalScore { get; set; }

    public virtual WarframeGame GameNavigation { get; set; } = null!;

    public virtual Warframe SelectedWarframeNavigation { get; set; } = null!;
}
