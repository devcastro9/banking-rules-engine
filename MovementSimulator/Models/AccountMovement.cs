using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Table("account_movements")]
[Index("AccountId", "CreatedAt", Name = "idx_account_movements_account_created_at", IsDescending = new[] { false, true })]
[Index("AccountId", "StatusId", Name = "idx_account_movements_account_status_covering")]
[Index("MovementTypeId", Name = "idx_account_movements_movement_type_id")]
[Index("StatusId", Name = "idx_account_movements_status_id")]
[Index("TransactionNumber", Name = "idx_account_movements_transaction_number")]
public partial class AccountMovement
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("transaction_number")]
    [StringLength(50)]
    public string TransactionNumber { get; set; } = null!;

    [Column("account_id")]
    public Guid AccountId { get; set; }

    [Column("movement_type_id")]
    public int MovementTypeId { get; set; }

    [Column("amount")]
    [Precision(18, 2)]
    public decimal Amount { get; set; }

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_by")]
    [StringLength(100)]
    public string CreatedBy { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_by")]
    [StringLength(100)]
    public string? UpdatedBy { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("AccountMovements")]
    public virtual DepositAccount Account { get; set; } = null!;

    [ForeignKey("MovementTypeId")]
    [InverseProperty("AccountMovements")]
    public virtual MovementType MovementType { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("AccountMovements")]
    public virtual MovementStatus Status { get; set; } = null!;
}
