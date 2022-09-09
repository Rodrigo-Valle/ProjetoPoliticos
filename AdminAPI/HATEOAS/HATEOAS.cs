using System.Collections.Generic;

namespace AdminAPI.HATEOAS
{
    public class HATEOAS
    {
        private string Url;
        private string Protocol = "https://";
        public List<Link> Actions = new List<Link>();

        public HATEOAS(string url)
        {
            Url = url;
        }

        public HATEOAS(string url, string protocol)
        {
            Url = url;
            Protocol = protocol;
        }

        public void AddAction(string rel, string metodo)
        {
            Actions.Add(new Link(Protocol + Url, rel, metodo));
        }

        public Link[] GetActions(string sufix)
        {
            Link[] tempLinks = new Link[Actions.Count];

            for (int i = 0; i < tempLinks.Length; i++)
            {
                tempLinks[i] = new Link(Actions[i].Href, Actions[i].Rel, Actions[i].Metodo);
            }

            foreach (var link in tempLinks)
            {
                link.Href = link.Href + "/" + sufix;
            }
            return tempLinks;
        }
    }
}