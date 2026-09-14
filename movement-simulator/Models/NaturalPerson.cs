using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace movement_simulator.Models;

[Table("natural_persons")]
public partial class NaturalPerson
{
    [Key]
    [Column("person_id")]
    public Guid PersonId { get; set; }

    [Column("first_name")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("NaturalPerson")]
    public virtual Person Person { get; set; } = null!;
}
