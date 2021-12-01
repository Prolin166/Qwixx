using Qwixx.FrontEnd.Contracts;
using Qwixx.Models;
using Qwixx.Models.Contracts;
using Qwixx.Presenter.Contracts;
using Qwixx.Services.Contracts;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Qwixx.Presenter
{
    public class MainViewPresenter : IMainViewPresenter
    {
        private readonly IMainView _mainView;
<<<<<<< HEAD
        private readonly IGamingService _gamingService;
=======
        private readonly IRuleService _ruleService;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        private readonly IRowModel _redModel;
        private readonly IRowModel _yellowModel;
        private readonly IRowModel _greenModel;
        private readonly IRowModel _blueModel;
        private readonly IMissModel _missModel;
<<<<<<< HEAD
        private readonly List<IRowModel> _rowModels = new List<IRowModel>();

        public MainViewPresenter(IMainView mainView,
                                 IGamingService gamingService,
=======

        public MainViewPresenter(IMainView mainView, 
                                 IRuleService gamingService, 
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
                                 IRowModel redModel,
                                 IRowModel yellowModel,
                                 IRowModel greenModel,
                                 IRowModel blueModel,
<<<<<<< HEAD
                                 IMissModel missModel
                                 )
        {
            _mainView = mainView;
            _gamingService = gamingService;
=======
                                 IMissModel missModel)
        {
            _mainView = mainView;
            _ruleService = gamingService;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
            _redModel = redModel;
            _yellowModel = yellowModel;
            _greenModel = greenModel;
            _blueModel = blueModel;
            _missModel = missModel;
<<<<<<< HEAD
            _rowModels.AddRange(new List<IRowModel>
            {
                _redModel,
                _yellowModel,
                _greenModel,
                _blueModel
            });

            Subscribe();
        }

        public void MainView_CompleteGame(object sender, Button e)
        {   
            _mainView.SetResult(_gamingService.CalculateResult());
=======

            Subscribe();

        }

        public void MainView_CompleteGame(object sender, Button e)
        {
            var result = new ResultModel(_redModel.Count(true),
                                         _yellowModel.Count(true),
                                         _greenModel.Count(true),
                                         _blueModel.Count(true),
                                         _missModel.Count(true));
            _mainView.SetResult(result);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        public void MainView_MissMove(object sender, CheckBox e)
        {
            _missModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_missModel, e.Checked, null);
<<<<<<< HEAD
            _gamingService.MissModel = _missModel;
            foreach (var rule in _gamingService.GetMissRules())
            {
                rule?.Invoke(_gamingService, null);
            }
            _mainView.UpdateFields(_gamingService.FieldList);
=======
            _ruleService.MissModel = _missModel;
            _ruleService.RuleMissFields();
            _mainView.UpdateFields(_ruleService.FieldList);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        public void MainView_RedMove(object sender, CheckBox e)
        {
            _redModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_redModel, e.Checked, null);
<<<<<<< HEAD
            SetGamingService(e, _redModel);
=======
            SetRuleService(e, _redModel);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        public void MainView_YellowMove(object sender, CheckBox e)
        {
            _yellowModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_yellowModel, e.Checked, null);
<<<<<<< HEAD
            SetGamingService(e, _yellowModel);
=======
            SetRuleService(e, _yellowModel);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        public void MainView_GreenMove(object sender, CheckBox e)
        {
            _greenModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_greenModel, e.Checked, null);
<<<<<<< HEAD
            SetGamingService(e, _greenModel);
=======
            SetRuleService(e, _greenModel);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        public void MainView_BlueMove(object sender, CheckBox e)
        {
            _blueModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_blueModel, e.Checked, null);
<<<<<<< HEAD
            SetGamingService(e, _blueModel);
=======
            SetRuleService(e, _blueModel);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        private void Subscribe()
        {
            _mainView.ResultButtonClicked += MainView_CompleteGame;
            _mainView.RedFieldIsSet += MainView_RedMove;
            _mainView.GreenFieldIsSet += MainView_GreenMove;
            _mainView.YellowFieldIsSet += MainView_YellowMove;
            _mainView.BlueFieldIsSet += MainView_BlueMove;
            _mainView.MissClicked += MainView_MissMove;
        }

<<<<<<< HEAD
        private void SetGamingService(CheckBox clickedField, IRowModel model)
        {
            _gamingService.MissModel = _missModel;
            _gamingService.Model = model;
            _gamingService.ClickedField = clickedField;
            _gamingService.ModelList = _rowModels;

            //Call all rulemethods
            foreach (var rule in _gamingService.GetRules())
            {
                rule?.Invoke(_gamingService, null);
            }

            _mainView.UpdateFields(_gamingService.FieldList);
=======
        private void SetRuleService(CheckBox clickedField, IRowModel model)
        {
            _ruleService.MissModel = _missModel;
            _ruleService.Model = model;
            _ruleService.ClickedField = clickedField;

            _ruleService.ModelList = new List<IRowModel>(new List<IRowModel>
            {
                _redModel,
                _yellowModel,
                _greenModel,
                _blueModel
            });

            //Call all rulemethods
            foreach (var rule in _ruleService.GetRules())
            {
                rule?.Invoke(_ruleService, null);
            }

            _mainView.UpdateFields(_ruleService.FieldList);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }
    }
}
