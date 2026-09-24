using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Table("legal_persons")]
[Index("LegalEntityTypeId", Name = "idx_legal_persons_legal_entity_type_id")]
public partial class LegalPerson
{
    [Key]
    [Column("person_id")]
    public Guid PersonId { get; set; }

    [Column("legal_name")]
    [StringLength(200)]
    public string LegalName { get; set; } = null!;

    [Column("incorporation_date")]
    public DateOnly IncorporationDate { get; set; }

    [Column("legal_entity_type_id")]
    public int LegalEntityTypeId { get; set; }

    [ForeignKey("LegalEntityTypeId")]
    [InverseProperty("LegalPeople")]
    public virtual LegalEntityType LegalEntityType { get; set; } = null!;

    [ForeignKey("PersonId")]
    [InverseProperty("LegalPerson")]
    public virtual Person Person { get; set; } = null!;
}
