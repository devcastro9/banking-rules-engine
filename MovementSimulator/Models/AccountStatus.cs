using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Table("account_status")]
[Index("Code", Name = "account_status_code_key", IsUnique = true)]
public partial class AccountStatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(20)]
    public string Code { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<DepositAccount> DepositAccounts { get; set; } = new List<DepositAccount>();
}
