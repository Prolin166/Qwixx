using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Qwixx.Models.Contracts;

namespace Qwixx.FrontEnd.Contracts
{
    public interface IMainView
    {
        event EventHandler<Button> ResultButtonClicked;
        event EventHandler<CheckBox> RedFieldIsSet;
        event EventHandler<CheckBox> YellowFieldIsSet;
        event EventHandler<CheckBox> GreenFieldIsSet;
        event EventHandler<CheckBox> BlueFieldIsSet;
        event EventHandler<CheckBox> MissClicked;
        void UpdateFields(List<string> checkBoxes);
<<<<<<< HEAD
        void SetResult(Dictionary<string, int> models);
=======
        void SetResult(ResultModel result);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
    }
}
