namespace testingdocker.webmvc
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.Collections.Generic.List<string> Resource { get; set; } 
            = new System.Collections.Generic.List<string>();
    }
}
