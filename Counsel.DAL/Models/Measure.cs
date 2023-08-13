using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Counsel.DAL.Models;

public partial class Measure
{
    [FromBody]
    public int MeasureId { get; set; }
    
    [FromBody]
    public string? MeasureName { get; set; }

    [FromBody]
    public string? MeasureSubject { get; set; }

    [FromBody]
    public string? MeasureDescription { get; set; }

    [FromBody]
    public string? MeasureStatus { get; set; }

    [FromBody]
    public string? MeasureResults { get; set; }

    [FromBody]
    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
