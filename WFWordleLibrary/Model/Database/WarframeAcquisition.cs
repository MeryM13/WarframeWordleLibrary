using System;
using System.Collections.Generic;

namespace WFWordleLibrary.Model.Database;

public partial class WarframeAcquisition
{
    public int Warframe { get; set; }

    public int AcquisitionMethod { get; set; }

    public string? AdditionalInfo { get; set; }

    public virtual AcquisitionMethod AcquisitionMethodNavigation { get; set; } = null!;

    public virtual Warframe WarframeNavigation { get; set; } = null!;
}
