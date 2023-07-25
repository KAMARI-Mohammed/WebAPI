public class Messages{

    public int id {get; set;}
    public required string userName {get;set;}
    public required string text {get;set;}
    public DateTime textDate {get;set;}

    public string UserId {get;set;}
    public virtual AppUser Sender  {get;set;}


}