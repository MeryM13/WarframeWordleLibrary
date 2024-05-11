using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class AcquisitionMethod
{
    public int Id { get; set; }

    public string MethodName { get; set; } = null!;

    public virtual ICollection<WarframeAcquisition> WarframeAcquisitions { get; set; } = new List<WarframeAcquisition>();

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
