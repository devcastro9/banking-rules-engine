using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace movement_simulator.Models;

[Table("person_type")]
[Index("Code", Name = "person_type_code_key", IsUnique = true)]
public partial class PersonType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("description")]
    [StringLength(50)]
    public string Description { get; set; } = null!;

    [InverseProperty("PersonType")]
    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
