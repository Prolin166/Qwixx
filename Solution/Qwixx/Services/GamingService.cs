using Qwixx.Attributes;
using Qwixx.Enums;
using Qwixx.Models.Contracts;
using Qwixx.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Qwixx.Services
{
    public class GamingService : IGamingService
    {
        public List<string> FieldList { get; } = new List<string>();

        

        public IRowModel Model { get; set; }
        
        public IMissModel MissModel { get; set; }

        public CheckBox ClickedField { get; set; }

        public List<IRowModel> ModelList { get; set; }



        public IEnumerable<MethodInfo> GetRules()
        {
            return GetType().GetMethods().Where(m => m.GetCustomAttributes(typeof(RuleAttribute), false).Any());
        }

        public IEnumerable<MethodInfo> GetMissRules()
        {
            return GetType().GetMethods().Where(m => m.GetCustomAttributes(typeof(MissRuleAttribute), false).Any());
        }

        public Dictionary<string, int> CalculateResult()
        {
            Dictionary<string, int> resultList = new Dictionary<string, int>();
            int result = 0;
            foreach (var model in ModelList)
            {
                result += model.Result;
                resultList.Add(model.Code.ToString(), model.Result);

            }
            result -= MissModel.Result;
            resultList.Add(FieldCode.ms.ToString(), MissModel.Result);

            resultList.Add(FieldCode.er.ToString(), result);

            return resultList;
        }

        [Rule]
        public void RuleLockLeftFields()
        {
            if (ClickedField.Name.Substring(0, 2) == FieldCode.rd.ToString() || ClickedField.Name.Substring(0, 2) == FieldCode.ye.ToString())
            {
                for (int i = 2; i <= int.Parse(ClickedField.Name.Substring(2, 2)); i++)
                {
                    var box = i.ToString("D2");
                    if (!FieldList.Contains(ClickedField.Name.Substring(0, 2) + box))
                        FieldList.Add(ClickedField.Name.Substring(0, 2) + box);
                }
            }

            if (ClickedField.Name.Substring(0, 2) == FieldCode.gn.ToString() || ClickedField.Name.Substring(0, 2) == FieldCode.bu.ToString())
            {
                var list = new List<string>();

                for (int i = int.Parse(ClickedField.Name.Substring(2, 2)); i <= Model.Count(); i++)
                {
                    var box = i.ToString("D2");
                    if (!FieldList.Contains(ClickedField.Name.Substring(0, 2) + box))
                        FieldList.Add(ClickedField.Name.Substring(0, 2) + box);
                }
            }
        }

        [Rule]
        public void RuleAddLock()
        {
            if(Model.Twelve.Equals(true)
                && Model.Count(true) >= 4
                && (Model.Code.Equals(FieldCode.rd) || Model.Code.Equals(FieldCode.ye)))
            {
                Model.Lock = true;
                FieldList.Add(Model.Code + "00");
            }

            if (Model.Two.Equals(true)
                && Model.Count(true) >= 4
                && (Model.Code.Equals(FieldCode.gn) || Model.Code.Equals(FieldCode.bu)))
            {
                Model.Lock = true;
                FieldList.Add(Model.Code + "00");
            }
        }

        [Rule]
        public void RuleTwoCompleteRows()
        {
            List<bool> rowModels = new List<bool>();
            foreach (IRowModel rowModel in ModelList)
            {
                var field = rowModel.Code switch
                {
                    FieldCode.rd => rowModel.Twelve,
                    FieldCode.ye => rowModel.Twelve,
                    FieldCode.gn => rowModel.Two,
                    FieldCode.bu => rowModel.Two,
                };

                if (field.Equals(true))
                    rowModels.Add(field);
            }

            if (rowModels.Count(v => v.Equals(true)) >= 2)
                DisableAllFields();
        }

        [MissRule]
        public void RuleMissFields()
        {
            if (MissModel.Count(true) == 4)
                DisableAllFields();
        }

        private void DisableAllFields()
        {
            foreach (IRowModel rowModel in ModelList)
            {
                for (int i = 1; i <= Model.Count(); i++)
                {
                    if (!FieldList.Contains(rowModel.Code + i.ToString("D2")))
                        FieldList.Add(rowModel.Code + i.ToString("D2"));
                }
            }

            for (int i = 1; i <= MissModel.Count(); i++)
            {
                if (!FieldList.Contains(FieldCode.ms.ToString() + i.ToString("D2")))
                    FieldList.Add(FieldCode.ms.ToString() + i.ToString("D2"));
            }
        }
    }

}
