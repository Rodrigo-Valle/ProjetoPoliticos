namespace AdminAPI.HATEOAS
{
    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Metodo { get; set; }

        public Link(string href, string rel, string metodo)
        {
            Href = href;
            Rel = rel;
            Metodo = metodo;
        }
    }
}