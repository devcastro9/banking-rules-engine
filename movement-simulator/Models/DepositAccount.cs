using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace movement_simulator.Models;

[Table("deposit_account")]
[Index("AccountNumber", Name = "deposit_account_account_number_key", IsUnique = true)]
[Index("AccountTypeId", Name = "idx_deposit_account_account_type_id")]
[Index("PersonId", Name = "idx_deposit_account_person_id")]
[Index("StatusId", Name = "idx_deposit_account_status_id")]
public partial class DepositAccount
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("account_number")]
    [StringLength(50)]
    public string AccountNumber { get; set; } = null!;

    [Column("person_id")]
    public Guid PersonId { get; set; }

    [Column("account_type_id")]
    public int AccountTypeId { get; set; }

    [Column("currency_id")]
    public int CurrencyId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("total_balance")]
    [Precision(18, 2)]
    public decimal TotalBalance { get; set; }

    [Column("total_blocked")]
    [Precision(18, 2)]
    public decimal TotalBlocked { get; set; }

    [Column("total_garnished")]
    [Precision(18, 2)]
    public decimal TotalGarnished { get; set; }

    [Column("total_available")]
    [Precision(18, 2)]
    public decimal TotalAvailable { get; set; }

    [InverseProperty("Account")]
    public virtual ICollection<AccountMovement> AccountMovements { get; set; } = new List<AccountMovement>();

    [ForeignKey("AccountTypeId")]
    [InverseProperty("DepositAccounts")]
    public virtual AccountType AccountType { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("DepositAccounts")]
    public virtual Currency Currency { get; set; } = null!;

    [ForeignKey("PersonId")]
    [InverseProperty("DepositAccounts")]
    public virtual Person Person { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("DepositAccounts")]
    public virtual AccountStatus Status { get; set; } = null!;
}
