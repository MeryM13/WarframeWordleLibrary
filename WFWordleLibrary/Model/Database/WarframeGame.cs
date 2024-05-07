using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class WarframeGame
{
    public int Id { get; set; }

    public int PlayerData { get; set; }

    public bool Completed { get; set; }

    public virtual PlayerDateDatum PlayerDataNavigation { get; set; } = null!;

    public virtual ICollection<WarframeGuess> WarframeGuesses { get; set; } = new List<WarframeGuess>();
}
