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
        void SetResult(Dictionary<string, int> models);
    }
}
