using System;
using System.ComponentModel.DataAnnotations;

namespace SyndicDocumentsData.Entities;

public class BaseEntitie
{
    public DateTime audit_created { get; set; } = DateTime.Now;
    public DateTime? audit_updated { get; set; }
    [Key]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();
}