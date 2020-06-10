using System;

namespace RldsApp.Data.Entities
{
	public class CurrencyRate : IVersionedEntity
	{
		public virtual Currency SourceCurrency { get; set; }
		public virtual Currency TargetCurrency { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual decimal Rate { get; set; }
		public virtual byte[] Version { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is CurrencyRate other)
			{
				return SourceCurrency?.Id == other.SourceCurrency?.Id
					&& TargetCurrency?.Id == other.TargetCurrency?.Id
					&& Date == other.Date;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)((SourceCurrency?.Id ?? 0L) + (TargetCurrency?.Id ?? 0L) + Date.Ticks);
		}
	}
}
