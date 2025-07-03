namespace Portfolio.Models;

public class BlogArticle : BaseModel
{
    public string Title { get; set; } // Title of the blog article
    public string Content { get; set; } // Content will be stored as Markdown
    public string Category { get; set; } // Category of the blog article
    public string Tags { get; set; } // Comma-separated tags for the article
    public string Slug { get; set; } // URL-friendly version of the title
    
    public bool IsPublished { get; set; } // Indicates if the article is published
    public DateTime PublishedDate { get; set; } // Date when the article was published
    
    public string Summary { get; set; } // Short summary of the article
    
    public string ImageUrl { get; set; } // URL of the article's featured image
    public string SeoTitle { get; set; } // SEO title for the article
    public string SeoDescription { get; set; } // SEO description for the article
    public string SeoKeywords { get; set; } // SEO keywords for the article
    public DateTime LastModified { get; set; } // Date when the article was last modified
    
}