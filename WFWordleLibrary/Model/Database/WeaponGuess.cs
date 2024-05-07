using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class WeaponGuess
{
    public int Id { get; set; }

    public int Game { get; set; }

    public int SelectedWeapon { get; set; }

    public decimal TotalScore { get; set; }

    public virtual WeaponGame GameNavigation { get; set; } = null!;

    public virtual Weapon SelectedWeaponNavigation { get; set; } = null!;
}
