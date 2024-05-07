using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class WeaponGame
{
    public int Id { get; set; }

    public int PlayerData { get; set; }

    public bool Completed { get; set; }

    public virtual PlayerDateDatum PlayerDataNavigation { get; set; } = null!;

    public virtual ICollection<WeaponGuess> WeaponGuesses { get; set; } = new List<WeaponGuess>();
}
