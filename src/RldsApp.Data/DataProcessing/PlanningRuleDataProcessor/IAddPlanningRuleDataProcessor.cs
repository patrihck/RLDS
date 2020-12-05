using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.DataProcessing.PlanningRuleDataProcessor
{
    public interface IAddPlanningRuleDataProcessor
    {
        void AddPlanningRule(PlanningRule planningRule);
    }
}
