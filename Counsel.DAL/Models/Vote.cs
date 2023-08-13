using System;
using System.Collections.Generic;

namespace Counsel.DAL.Models;

public partial class Vote
{
    public int VoteId { get; set; }

    public string? VoterName { get; set; }

    public int? MeasureId { get; set; }

    public string? Vote1 { get; set; }

    public virtual Measure? Measure { get; set; }
}
