using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Studio.Extant.Core.Interfaces;

namespace Studio.Extant.IdentityProvider.Database;

/// <summary>
/// Interface for the Asp Identity Database.
/// </summary>
public interface IIdentityDatabase : IDbContext
{
  /// <summary>
  /// User collection.
  /// </summary>
  DbSet<IdentityUser> Users { get; set; }
}