namespace RldsApp.Data.Entities
{
    public class Group : IVersionedEntity
    {
        public virtual int GroupId { get; set; }

        public virtual string Name { get; set; }
        
        public virtual string Info { get; set; }
        
        public virtual int Ordinal { get; set; }
        
        public virtual byte[] Version { get; set; }
    }
}
