using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Table("account_type")]
[Index("Code", Name = "account_type_code_key", IsUnique = true)]
public partial class AccountType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(30)]
    public string Code { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

    [InverseProperty("AccountType")]
    public virtual ICollection<DepositAccount> DepositAccounts { get; set; } = new List<DepositAccount>();
}
