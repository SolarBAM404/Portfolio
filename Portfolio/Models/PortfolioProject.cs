namespace Portfolio.Models;

public class PortfolioProject : BaseModel
{
    public string? Title { get; set; } // Title of the project
    public string? Category { get; set; } // Category of the project (e.g., Web Development, Mobile App)
    public string? Summary { get; set; } // Short summary of the project for listing
    public string? Slug { get; set; } // URL-friendly version of the title
    public string? ImageUrl { get; set; } // URL of the project's image
    public string[]? Tags { get; set; } // Tags associated with the project
    public string? ProjectUrl { get; set; } // URL to the project or its repository
    public string? MarkdownContent { get; set; } // Detailed description in Markdown format
    public string[]? MediaUrls { get; set; } // URLs of additional media (e.g., videos, images)
    
}