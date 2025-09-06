namespace Portfolio.Models;

public class HomeCarouselContent : BaseModel
{
    
    public required string Url { get; set; }
    public string? AltText { get; set; }
    public required MediaMode Mode { get; set; }
    
}

public enum MediaMode
{
    Image,
    Video
}