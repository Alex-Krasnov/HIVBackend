using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblListPlaceCheck
{
    public int? PlaceCheckId { get; set; }

    public string? PlaceCheckName { get; set; }

    public string? User { get; set; }

    public DateOnly? Datetime { get; set; }
}
