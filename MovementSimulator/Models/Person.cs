using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovementSimulator.Models;

[Table("persons")]
[Index("PersonTypeId", Name = "idx_persons_person_type_id")]
public partial class Person
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("person_type_id")]
    public int PersonTypeId { get; set; }

    [Column("display_name")]
    [StringLength(200)]
    public string DisplayName { get; set; } = null!;

    [InverseProperty("Person")]
    public virtual ICollection<DepositAccount> DepositAccounts { get; set; } = new List<DepositAccount>();

    [InverseProperty("Person")]
    public virtual LegalPerson? LegalPerson { get; set; }

    [InverseProperty("Person")]
    public virtual NaturalPerson? NaturalPerson { get; set; }

    [ForeignKey("PersonTypeId")]
    [InverseProperty("People")]
    public virtual PersonType PersonType { get; set; } = null!;
}
