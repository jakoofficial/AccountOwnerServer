﻿using Contracts;
using Entities;
using Entities.Models;

namespace Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Owner> GetAllOwners()
    {
        return FindAll()
            .OrderBy(ow => ow.Name)
            .ToList();
    }

    public Owner GetOwnerById(int ownerId)
    {
        return FindByCondition(owner => owner.Id.Equals(ownerId)).FirstOrDefault();
    }
}