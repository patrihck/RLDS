using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.PlanningRuleDataProcessor;
using RldsApp.Web.Api.Models;
using System;

namespace RldsApp.Web.Api.Controllers._1._0
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class PlanningRuleController : ControllerBase
    {
		private readonly IAddPlanningRuleDataProcessor _addPlanningRuleDataProcessor;

		public PlanningRuleController(IAddPlanningRuleDataProcessor addPlanningRuleDataProcessor)
        {
			_addPlanningRuleDataProcessor = addPlanningRuleDataProcessor;
        }

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult AddPlanningRule(PlanningRule planningRule)
		{
			try
			{
				_addPlanningRuleDataProcessor.AddPlanningRule(planningRule);
				return Ok();
			}
            catch(Exception ex)
            {
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}
	}
}
