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
        private readonly IGamingService _gamingService;
        private readonly IRowModel _redModel;
        private readonly IRowModel _yellowModel;
        private readonly IRowModel _greenModel;
        private readonly IRowModel _blueModel;
        private readonly IMissModel _missModel;
        private readonly List<IRowModel> _rowModels = new List<IRowModel>();

        public MainViewPresenter(IMainView mainView,
                                 IGamingService gamingService,
                                 IRowModel redModel,
                                 IRowModel yellowModel,
                                 IRowModel greenModel,
                                 IRowModel blueModel,
                                 IMissModel missModel
                                 )
        {
            _mainView = mainView;
            _gamingService = gamingService;
            _redModel = redModel;
            _yellowModel = yellowModel;
            _greenModel = greenModel;
            _blueModel = blueModel;
            _missModel = missModel;

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
        }

        public void MainView_MissMove(object sender, CheckBox e)
        {
            _missModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_missModel, e.Checked, null);
            _gamingService.MissModel = _missModel;
            foreach (var rule in _gamingService.GetMissRules())
            {
                rule?.Invoke(_gamingService, null);
            }
            _mainView.UpdateFields(_gamingService.FieldList);
        }

        public void MainView_RedMove(object sender, CheckBox e)
        {
            _redModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_redModel, e.Checked, null);
            SetGamingService(e, _redModel);
        }

        public void MainView_YellowMove(object sender, CheckBox e)
        {
            _yellowModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_yellowModel, e.Checked, null);
            SetGamingService(e, _yellowModel);
        }

        public void MainView_GreenMove(object sender, CheckBox e)
        {
            _greenModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_greenModel, e.Checked, null);
            SetGamingService(e, _greenModel);
        }

        public void MainView_BlueMove(object sender, CheckBox e)
        {
            _blueModel.GetType().GetProperty(e.Tag.ToString()).SetValue(_blueModel, e.Checked, null);
            SetGamingService(e, _blueModel);
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
        }
    }
}
