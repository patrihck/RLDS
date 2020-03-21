namespace RldsApp.Data.Entities
{
    public class TaskStatus : IVersionedEntity
    {
        public virtual long TaskStatusId { get; set; }

        public virtual string Name { get; set; }

        public virtual int Ordinal { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
