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
    public class RuleService : IRuleService
    {
        public List<string> FieldList { get; } = new List<string>();

        public CheckBox ClickedField { get; set; }
        public IRowModel Model { get; set; }
        public IMissModel MissModel { get; set; }
        public List<IRowModel> ModelList { get; set; }

        public IEnumerable<MethodInfo> GetRules()
        {
            return GetType().GetMethods().Where(m => m.GetCustomAttributes(typeof(RuleAttribute), false).Any());
        }

        [Rule]
        public void RuleLockLeftFields()
        {
            if (ClickedField.Name.Substring(0, 2) == "rd" || ClickedField.Name.Substring(0, 2) == "ye")
            {
                for (int i = 2; i <= int.Parse(ClickedField.Name.Substring(2, 2)); i++)
                {
                    var box = i.ToString("D2");
                    if (!FieldList.Contains(ClickedField.Name.Substring(0, 2) + box))
                        FieldList.Add(ClickedField.Name.Substring(0, 2) + box);
                }
            }

            if (ClickedField.Name.Substring(0, 2) == "gn" || ClickedField.Name.Substring(0, 2) == "bu")
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
            if (Model.Lock.Equals(true))
            {
                FieldList.Add(Model.Color + "00");
            }
        }

        [Rule]
        public void Rule2CompleteRows()
        {
            List<bool> rowModels = new List<bool>();
            foreach (IRowModel rowModel in ModelList)
            {
                var field = rowModel.Color switch
                {
                    ColorCode.rd => rowModel.Twelve,
                    ColorCode.ye => rowModel.Twelve,
                    ColorCode.gn => rowModel.Two,
                    ColorCode.bu => rowModel.Two,
                };

                if (field.Equals(true))
                    rowModels.Add(field);
            }

            if (rowModels.Count(v => v.Equals(true)) >= 2)
                DisableAllFields();
        }

        [Rule]
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
                    if (!FieldList.Contains(rowModel.Color + i.ToString("D2")))
                        FieldList.Add(rowModel.Color + i.ToString("D2"));
                }
            }

            for (int i = 1; i <= MissModel.Count(); i++)
            {
                if (!FieldList.Contains("ms" + i.ToString("D2")))
                    FieldList.Add("ms" + i.ToString("D2"));
            }
        }
    }

}
