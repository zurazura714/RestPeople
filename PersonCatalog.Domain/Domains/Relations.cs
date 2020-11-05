namespace PersonCatalog.Domain.Domains
{
    public class Relations
    {
        public int FromID { get; set; }
        public int ToID { get; set; }
        public virtual Person PersonFrom { get; set; }
        public virtual Person PersonTo { get; set; }
        public RelationType RelationType { get; set; }
    }
}
