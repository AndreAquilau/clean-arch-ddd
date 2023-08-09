using System;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Domain.Entities;

public abstract class Entity : IEntity
{
    public int Id { get; protected set; }
}
