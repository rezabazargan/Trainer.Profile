using System.ComponentModel.DataAnnotations;

namespace Trainer.Profile.Adaptors.Ef.Entities;

public abstract class EntityBase<TKey>
{
    [Key] public TKey? Id { get; set; }
}