using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer.Profile.Adaptors.Ef.Entities;

public abstract class EntityBase<TKey>
{
    [Key] public TKey? Id { get; set; }
}