using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Table("movement_type")]
[Index("Code", Name = "movement_type_code_key", IsUnique = true)]
public partial class MovementType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(30)]
    public string Code { get; set; } = null!;

    [Column("description")]
    [StringLength(150)]
    public string? Description { get; set; }

    [Column("sign")]
    public short? Sign { get; set; }

    [InverseProperty("MovementType")]
    public virtual ICollection<AccountMovement> AccountMovements { get; set; } = new List<AccountMovement>();
}
