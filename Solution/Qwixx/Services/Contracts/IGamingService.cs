using Qwixx.Attributes;
using Qwixx.Models.Contracts;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Qwixx.Services.Contracts
{
    public interface IGamingService
    {
        List<string> FieldList { get; }


        CheckBox ClickedField { get; set; }
        
        IRowModel Model { get; set; }
        
        IMissModel MissModel { get; set; }
        
        List<IRowModel> ModelList { get; set; }



        IEnumerable<MethodInfo> GetRules();

        IEnumerable<MethodInfo> GetMissRules();

        Dictionary<string, int> CalculateResult();

        [Rule]
        void RuleLockLeftFields();
        [Rule]
        void RuleAddLock();
        [Rule]
        void RuleTwoCompleteRows();
        [Rule]
        void RuleMissFields();
    }
}
