using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblSetup
{
    public int Id { get; set; }

    public int? TimeOutValue { get; set; }

    public int? TimeOutStep { get; set; }
}
