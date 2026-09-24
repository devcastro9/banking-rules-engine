using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Keyless]
public partial class VDepositAccountsSummary
{
    [Column("account_number")]
    [StringLength(50)]
    public string? AccountNumber { get; set; }

    [Column("product")]
    [StringLength(30)]
    public string? Product { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string? Status { get; set; }

    [Column("currency")]
    [StringLength(3)]
    public string? Currency { get; set; }

    [Column("person_id")]
    public Guid? PersonId { get; set; }

    [Column("client")]
    [StringLength(200)]
    public string? Client { get; set; }

    [Column("total_balance")]
    [Precision(18, 2)]
    public decimal? TotalBalance { get; set; }

    [Column("total_available")]
    [Precision(18, 2)]
    public decimal? TotalAvailable { get; set; }

    [Column("total_blocked")]
    [Precision(18, 2)]
    public decimal? TotalBlocked { get; set; }

    [Column("total_garnished")]
    [Precision(18, 2)]
    public decimal? TotalGarnished { get; set; }
}
