namespace RldsApp.Data.Entities
{
    public class TransactionStatus : IVersionedEntity
    {
        public virtual long TransactionStatusId { get; set; }

        public virtual string Name { get; set; }

        public virtual byte[] Version { get; set; }

        public virtual int Ordinal { get; set; }
    }
}
