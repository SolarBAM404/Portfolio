using MongoDB.Driver;
using MongoDbEntityFramework;
using MongoDbEntityFramework.Repository;
using MongoDbEntityFramework.Settings;
using Portfolio.Models;

namespace Portfolio.Data;

public class PortfolioContext : DbContext
{
    public IEntityRepository<BlogArticle> BlogArticles { get; private set; }
    public IEntityRepository<PortfolioProject> PortfolioProjects { get; private set; }
    
    public PortfolioContext(MongoClient client, DbSettings settings)
        : base(client, settings)
    {
        BlogArticles = new EntityRepository<BlogArticle>(this);
        PortfolioProjects = new EntityRepository<PortfolioProject>(this);
    }

}