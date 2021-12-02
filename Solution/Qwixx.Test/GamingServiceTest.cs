using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwixx.Enums;
using Qwixx.Models;
using Qwixx.Models.Contracts;
using Qwixx.Services;
using Qwixx.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Qwixx.Test
{
    [TestClass]
    public class GamingServiceTest
    {
        GamingService _gamingService;
        IRowModel _redModel;
        IRowModel _yellowModel;
        IRowModel _greenModel;
        IRowModel _blueModel;

        [TestInitialize]
        public void Init()
        {
            _redModel = new RowModel(FieldCode.rd);
            _yellowModel = new RowModel(FieldCode.ye);
            _greenModel = new RowModel(FieldCode.gn);
            _blueModel = new RowModel(FieldCode.bu);
            _gamingService = new GamingService();
            _gamingService.ModelList = new List<IRowModel>(new List<IRowModel> 
            {
                _redModel,
                _yellowModel,
                _greenModel,
                _blueModel
            });
            _gamingService.Model = new RowModel(FieldCode.None);
            _gamingService.MissModel = new MissModel(FieldCode.None);
        }

        [TestMethod]
        public void GetRules_ReturnListOfMethods()
        {
            var list = _gamingService.GetRules();

            Assert.AreEqual(3, list.Count());
        }

        [TestMethod]
        public void GetMissRules_ReturnListOfMethods()
        {
            var list = _gamingService.GetMissRules();

            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectRedCount()
        {
            _gamingService.ClickedField = new CheckBox { Name = "rd07" };

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 6);
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectYellowCount()
        {
            _gamingService.ClickedField = new CheckBox { Name = "ye04" };

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 3);
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectGreenCount()
        {
            _gamingService.ClickedField = new CheckBox { Name = "gn07" };
            _gamingService.Model = new RowModel(FieldCode.None);

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 6);
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectBlueCount()
        {
            _gamingService.ClickedField = new CheckBox { Name = "bu04" };
            _gamingService.Model = new RowModel(FieldCode.None);

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 9);
        }

        [TestMethod]
        public void AddLockField_ListContain00()
        {
            _gamingService.Model.Lock = true;

            _gamingService.RuleAddLock();

            Assert.IsTrue(_gamingService.FieldList.Contains("00"));
        }

        [TestMethod]
        public void TwoCompleteRows_FieldListHasCountOf0()
        {
            _gamingService.RuleTwoCompleteRows();

            Assert.AreEqual(0, _gamingService.FieldList.Count);
        }

        [TestMethod]
        public void TwoCompleteRows_FieldListHasCountOf52()
        {
            _redModel.Twelve = true;
            _greenModel.Two = true;

            _gamingService.RuleTwoCompleteRows();

            Assert.AreEqual(52, _gamingService.FieldList.Count);
        }

        [TestMethod]
        public void MissField_DisableAllFieldsWasNotCalled()
        {
            _gamingService.MissModel = new MissModel(FieldCode.ms);
            _gamingService.MissModel.Two = true;

            _gamingService.RuleMissFields();

            Assert.AreEqual(0, _gamingService.FieldList.Count);
        }

        [TestMethod]
        public void MissField_DisableAllFieldsWasCalled()
        {
            _gamingService.MissModel.Four = true;
            _gamingService.MissModel.Three = true;
            _gamingService.MissModel.Two = true;
            _gamingService.MissModel.One = true;

            _gamingService.RuleMissFields();

            Assert.AreEqual(52, _gamingService.FieldList.Count);
        }

        [TestMethod]
        public void CalculateResult_IsCorrectAndNotNull()
        {
            _greenModel.Five = true;
            _blueModel.Five = true;
            _greenModel.Eight = true;

            var result = _gamingService.CalculateResult();
            result.TryGetValue("er", out int value);

            Assert.IsNotNull(result.ContainsKey("er"));
            Assert.AreEqual(value, 4);
        }
    }
}
