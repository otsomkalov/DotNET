using System.Linq;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Include<T>(this IQueryable<T> query, params string[] includes)
            where T : BaseEntity
        {
            return includes == null ? query : includes.Aggregate(query, EntityFrameworkQueryableExtensions.Include);
        }
    }
}