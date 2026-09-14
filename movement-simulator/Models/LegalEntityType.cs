using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace movement_simulator.Models;

[Table("legal_entity_type")]
[Index("Code", Name = "legal_entity_type_code_key", IsUnique = true)]
public partial class LegalEntityType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(30)]
    public string Code { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("LegalEntityType")]
    public virtual ICollection<LegalPerson> LegalPeople { get; set; } = new List<LegalPerson>();
}
