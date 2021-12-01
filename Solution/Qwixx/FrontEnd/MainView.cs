 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Windows.Forms;
 using Qwixx.FrontEnd.Contracts;
using Qwixx.Models.Contracts;

namespace Qwixx.FrontEnd
{
    public partial class MainView : Form, IMainView
    {
        private List<CheckBox> _checkBoxes;
<<<<<<< HEAD
        private List<TextBox> _textBoxes;
=======
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105

        public event EventHandler<CheckBox> RedFieldIsSet;

        public event EventHandler<CheckBox> YellowFieldIsSet;

        public event EventHandler<CheckBox> GreenFieldIsSet;

        public event EventHandler<CheckBox> BlueFieldIsSet;

        public event EventHandler<Button> ResultButtonClicked;

        public event EventHandler<CheckBox> MissClicked;

        public MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void RedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var ctrlSender = (CheckBox)sender;
            ctrlSender.Enabled = false;
            RedFieldIsSet?.Invoke(this, ctrlSender);
        }

        private void YellowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var ctrlSender = (CheckBox)sender;
            ctrlSender.Enabled = false;
            YellowFieldIsSet?.Invoke(this, ctrlSender);
        }

        private void GreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var ctrlSender = (CheckBox)sender;
            ctrlSender.Enabled = false;
            GreenFieldIsSet?.Invoke(this, ctrlSender);
        }

        private void BlueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var ctrlSender = (CheckBox)sender;
            ctrlSender.Enabled = false;
            BlueFieldIsSet?.Invoke(this, ctrlSender);
        }

        private void Miss_CheckedChanged(object sender, EventArgs e)
        {
            var ctrlSender = (CheckBox)sender;
            ctrlSender.Enabled = false;
            MissClicked?.Invoke(this, ctrlSender);
        }

        private void Result_Click(object sender, EventArgs e)
        {
            var ctrlSender = (Button)sender;
            ResultButtonClicked?.Invoke(this, ctrlSender);
        }

        public void UpdateFields(List<string> checkBoxes)
        {
            foreach (var checkBox in checkBoxes)
            {
                var box = _checkBoxes.FirstOrDefault(x => x.Name == checkBox);
                if (box != null)
                {
                    box.Enabled = false;
                    if (box.Name.Substring(2, 2) == "00") box.Checked = true;
                }
            }
        }

<<<<<<< HEAD
        public void SetResult(Dictionary<string, int> models)
        {
            foreach (var box in _textBoxes)
            {
                foreach(var model in models)
                {
                    if (box.Tag.ToString() == model.Key)
                        box.Text = model.Value.ToString();
                }
            }
=======
        public void SetResult(ResultModel result)
        {
            redResult.Text = result.RedResult.ToString();
            yellowResult.Text = result.YellowResult.ToString();
            greenResult.Text = result.GreenResult.ToString();
            blueResult.Text = result.BlueResult.ToString();
            missResult.Text = result.MissResult.ToString();
            endResult.Text = result.EndResult.ToString();
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        private void Initialize()
        {
            _checkBoxes = new List<CheckBox>();
            _checkBoxes.AddRange(new List<CheckBox>
            {
                rd02,
                rd03,
                rd04,
                rd05,
                rd06,
                rd07,
                rd08,
                rd09,
                rd10,
                rd11,
                rd12,
                rd00,
                ye02,
                ye03,
                ye04,
                ye05,
                ye06,
                ye07,
                ye08,
                ye09,
                ye10,
                ye11,
                ye12,
                ye00,
                gn02,
                gn03,
                gn04,
                gn05,
                gn06,
                gn07,
                gn08,
                gn09,
                gn10,
                gn11,
                gn12,
                gn00,
                bu02,
                bu03,
                bu04,
                bu05,
                bu06,
                bu07,
                bu08,
                bu09,
                bu10,
                bu11,
                bu12,
                bu00,
                ms01,
                ms02,
                ms03,
                ms04
            });

            _textBoxes = new List<TextBox>();
            _textBoxes.AddRange(new List<TextBox>
            {
                redResult,
                yellowResult,
                greenResult,
                blueResult,
                missResult,
                endResult
            });

        }
    }
}
