﻿using Microsoft.EntityFrameworkCore;
using Vertical_Slice_Architecture.Data;

namespace Vertical_Slice_Architecture.Shared.Repositories.MainRepository;

public class GenericRepository<TModel> :
    IGenericRepository<TModel> where TModel : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TModel> AddAsync(TModel entity, CancellationToken cancellationToken)
    {
        await _context
            .Set<TModel>()
            .AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context
            .Set<TModel>()
            .ToListAsync(cancellationToken);

        return entities;
    }

    public async Task<TModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context
            .Set<TModel>()
            .FindAsync(id, cancellationToken);

        return entity;
    }

    public Task<TModel> UpdateAsync(TModel entity)
    {
        _context
            .Set<TModel>()
            .Update(entity);

        return Task.FromResult(entity);
    }
}