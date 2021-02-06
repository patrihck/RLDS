using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;

namespace RldsApp.Web.Api.MaintenanceProcessing.AccountMaintenanceProcessor
{
	public class UpdateAccountMaintenanceProcessor : IUpdateAccountMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateAccountDataProcessor _dataProcessor;
		private readonly IAccountLinkService _linkService;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

		public UpdateAccountMaintenanceProcessor(IUpdateAccountDataProcessor dataProcessor, IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector, IAccountLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
			_linkService = linkService;
		}

		public Account UpdateAccount(long accountId, object accountFragment)
		{
			var fragmentAsJObject = (JObject)accountFragment;
			var model = fragmentAsJObject.ToObject<Account>();
			var entity = _autoMapper.Map<Data.Entities.Account>(model);
			var updatedPropertyValueMap = _updateablePropertyDetector.GetPropertyValueMap(fragmentAsJObject, model, entity);
			var updatedAccountEntity = _dataProcessor.UpdateAccount(accountId, updatedPropertyValueMap);
			var account = _autoMapper.Map<Account>(updatedAccountEntity);
			_linkService.AddSelfLink(account);
			_linkService.AddLinksToChildObjects(account);

			return account;
		}
	}
}
