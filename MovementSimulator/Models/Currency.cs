using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Table("currency")]
[Index("Code", Name = "currency_code_key", IsUnique = true)]
public partial class Currency
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(3)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(50)]
    public string? Name { get; set; }

    [Column("symbol")]
    [StringLength(5)]
    public string? Symbol { get; set; }

    [InverseProperty("Currency")]
    public virtual ICollection<DepositAccount> DepositAccounts { get; set; } = new List<DepositAccount>();
}
