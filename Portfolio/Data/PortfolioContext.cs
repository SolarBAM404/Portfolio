using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Portfolio.Models;

namespace Portfolio.Data;

public class PortfolioContext : DbContext
{
    public DbSet<BlogArticle> BlogArticles { get; private set; }
    public DbSet<PortfolioProject> PortfolioProjects { get; private set; }
    
    public PortfolioContext(DbContextOptions options) : base(options)
    {
    }

}