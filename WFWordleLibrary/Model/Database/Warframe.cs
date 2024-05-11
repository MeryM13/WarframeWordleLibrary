using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class Warframe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Gender { get; set; }

    public int HasExalteds { get; set; }

    public bool HasPrime { get; set; }

    public int ReleasedInUpdate { get; set; }

    public int AuraPolarity { get; set; }

    public int ProgenitorElement { get; set; }

    public int SubsumedAbility { get; set; }

    public int TacticalAbility { get; set; }

    public int Health { get; set; }

    public int Shields { get; set; }

    public int Armor { get; set; }

    public int Energy { get; set; }

    public decimal SprintSpeed { get; set; }

    public string? WarframePictureLink { get; set; }

    public virtual Polarity AuraPolarityNavigation { get; set; } = null!;

    public virtual ICollection<DateDatum> DateData { get; set; } = new List<DateDatum>();

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual Element ProgenitorElementNavigation { get; set; } = null!;

    public virtual GameUpdate ReleasedInUpdateNavigation { get; set; } = null!;

    public virtual ICollection<WarframeAcquisition> WarframeAcquisitions { get; set; } = new List<WarframeAcquisition>();

    public virtual ICollection<WarframeGuess> WarframeGuesses { get; set; } = new List<WarframeGuess>();

    public virtual ICollection<Playstyle> CommonPlaystyles { get; set; } = new List<Playstyle>();
}
