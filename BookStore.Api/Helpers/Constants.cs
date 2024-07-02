namespace BookStore.Api.Helpers;

public static class Constants
{
    // images
    //private const string ImageBasePath = @".\wwwroot\images\";
    
    private const string ImageBasePath = @"images\";
    
    public const string UserImageBasePath = ImageBasePath + @"users\";
    
    public const string BookImageBasePath = ImageBasePath + @"books\";
    
    public const string BookImageType = "book";
    
    public const string UserImageType = "user";
    
    public const string DefaultUserImagePath = UserImageBasePath + "NoImageAvailable.jpg";
    
    public const string DefaultBookImagePath = BookImageBasePath + "NoImageAvailable.jpg";
    
    // claims
    
    public const string Admin = "admin";

    public const string Moderator = "moderator";

    public const string Customer = "customer";

    public const string ClaimTypeName = "level";
    
    // cors

    public const string CorsPolicy = "AllowAll";
    
    // logs

    public const string CorrelationLogIdProperty = "CorrelationId";
}