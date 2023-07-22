using System;
using System.Collections.Generic;

namespace prueba.Models;

public partial class VwErrorsLog
{
    public int Id { get; set; }

    public string? MethodName { get; set; }

    public string? ExceptionMessage { get; set; }

    public string? ExceptionStackTrace { get; set; }

    public string? Clue { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUser { get; set; } = null!;

    public string? ExceptionType { get; set; }
}
