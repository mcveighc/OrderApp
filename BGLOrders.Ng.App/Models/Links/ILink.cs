namespace BGLOrderApp.Models.Links
{
    public interface ILink
    {
        string Href { get; }
        string Rel { get; }
    }
}