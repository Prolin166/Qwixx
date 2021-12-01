using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Qwixx.Attributes;
using Qwixx.Enums;
using Qwixx.FrontEnd.Contracts;
using Qwixx.Models;
using Qwixx.Presenter;
using Qwixx.Services.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Qwixx.Test
{
    [TestClass]
    public class MainViewPresenterTest
    {
        private MainViewPresenter _presenter;
        private Mock<IMainView> _mainView;
        private Mock<IGamingService> _gamingService;
        private MissModel _missModel;
        private RowModel _redModel;
        private RowModel _greenModel;   
        private RowModel _blueModel;
        private RowModel _yellowModel;

        [TestInitialize]
        public void Init()
        {
            _mainView = new Mock<IMainView>();
            _gamingService = new Mock<IGamingService>();
            _redModel = new RowModel(FieldCode.rd);
            _yellowModel = new RowModel(FieldCode.ye);
            _greenModel = new RowModel(FieldCode.gn);
            _blueModel = new RowModel(FieldCode.bu);
            _missModel = new MissModel(FieldCode.ms);
            _presenter = new MainViewPresenter(_mainView.Object, 
                                               _gamingService.Object,
                                               _redModel,
                                               _yellowModel,
                                               _greenModel,
                                               _blueModel,
                                               _missModel);
        }

        [TestMethod]
        public void VerifyGameHasFinishedState()
        {
            _presenter.MainView_CompleteGame(null, null);

            _gamingService.Verify(x => x.CalculateResult(), Times.Once());
            _mainView.Verify(x => x.SetResult(It.IsAny<Dictionary<string, int>>()), Times.Once);
        }

        [TestMethod]
        public void VerifyRedGameStateIsUpdated()
        {
            _presenter.MainView_RedMove(null, new CheckBox
            {
                Name = "new",
                Tag = "Three",
                Checked = true,
                Text = "new"
            });

            _gamingService.VerifySet(x => x.Model);
            _gamingService.VerifySet(x => x.MissModel);
            _gamingService.VerifySet(x => x.ModelList);
            _gamingService.Verify(x => x.GetRules(), Times.Once);
            _mainView.Verify(x => x.UpdateFields(It.IsAny<List<string>>()), Times.Once);

            Assert.AreEqual(_redModel.Count(true), 1);
        }

        [TestMethod]
        public void VerifyYellowGameStateIsUpdated()
        {
            _presenter.MainView_YellowMove(null, new CheckBox
            {
                Name = "new",
                Tag = "Three",
                Checked = true,
                Text = "new"
            });

            _gamingService.VerifySet(x => x.Model);
            _gamingService.VerifySet(x => x.MissModel);
            _gamingService.VerifySet(x => x.ModelList);
            _gamingService.Verify(x => x.GetRules(), Times.Once);
            _mainView.Verify(x => x.UpdateFields(It.IsAny<List<string>>()), Times.Once);
            Assert.AreEqual(_yellowModel.Count(true), 1);
        }

        [TestMethod]
        public void VerifyGreenGameStateIsUpdated()
        {
            _presenter.MainView_GreenMove(null, new CheckBox
            {
                Name = "new",
                Tag = "Three",
                Checked = true,
                Text = "new"
            });

            _gamingService.VerifySet(x => x.Model);
            _gamingService.VerifySet(x => x.MissModel);
            _gamingService.VerifySet(x => x.ModelList);
            _gamingService.Verify(x => x.GetRules(), Times.Once);
            _mainView.Verify(x => x.UpdateFields(It.IsAny<List<string>>()), Times.Once);

            Assert.AreEqual(_greenModel.Count(true), 1);
        }

        [TestMethod]
        public void VerifyBlueGameStateIsUpdated()
        {
            _presenter.MainView_BlueMove(null, new CheckBox
            {
                Name = "new",
                Tag = "Three",
                Checked = true,
                Text = "new"
            });

            _gamingService.VerifySet(x => x.Model);
            _gamingService.VerifySet(x => x.MissModel);
            _gamingService.VerifySet(x => x.ModelList);
            _gamingService.Verify(x => x.GetRules(), Times.Once);
            _mainView.Verify(x => x.UpdateFields(It.IsAny<List<string>>()), Times.Once);

            Assert.AreEqual(_blueModel.Count(true), 1);
        }

        [TestMethod]
        public void VerifyMissGameStateIsUpdated()
        {
            _presenter.MainView_MissMove(null, new CheckBox
            {
                Name = "new",
                Tag = "Three",
                Checked = true,
                Text = "new"
            });
            _presenter.MainView_MissMove(null, new CheckBox
            {
                Name = "new2",
                Tag = "One",
                Checked = true,
                Text = "new"
            });
            Assert.AreEqual(_missModel.Count(true), 2);
            _gamingService.Verify(x => x.GetMissRules(), Times.Exactly(2));
            _mainView.Verify(x => x.UpdateFields(It.IsAny<List<string>>()), Times.Once);
        }
    }
}
