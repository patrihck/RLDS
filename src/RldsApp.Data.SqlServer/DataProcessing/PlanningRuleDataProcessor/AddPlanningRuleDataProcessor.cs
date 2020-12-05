using System.Linq;
using NHibernate;
using NHibernate.Util;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.PlanningRuleDataProcessor;
using RldsApp.Data.Entities;
using RldsApp.Web.Api.Models;

namespace RldsApp.Data.SqlServer.DataProcessing.PlanningRuleDataProcessor
{
    public class AddPlanningRuleDataProcessor : IAddPlanningRuleDataProcessor
    {
        private readonly ISession _session;

        public AddPlanningRuleDataProcessor(ISession session)
        {
            _session = session;
        }

        public void AddPlanningRule(PlanningRule planningRule)
        {
            _session.SaveOrUpdate(planningRule);
        }
    }
}
