using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwixx.Enums;
using Qwixx.Models;
using Qwixx.Models.Contracts;
using Qwixx.Services;
using Qwixx.Services.Contracts;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
using System.Reflection;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
using System.Windows.Forms;

namespace Qwixx.Test
{
    [TestClass]
<<<<<<< HEAD
    public class gamingServiceTest
    {
        IGamingService _gamingService;
=======
    public class RuleServiceTest
    {
        IRuleService _ruleService;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        IRowModel _redModel;
        IRowModel _yellowModel;
        IRowModel _greenModel;
        IRowModel _blueModel;

        [TestInitialize]
        public void Init()
        {
<<<<<<< HEAD
            _redModel = new RowModel(FieldCode.rd);
            _yellowModel = new RowModel(FieldCode.ye);
            _greenModel = new RowModel(FieldCode.gn);
            _blueModel = new RowModel(FieldCode.bu);
            _gamingService = new GamingService();
            _gamingService.ModelList = new List<IRowModel>(new List<IRowModel> 
=======
            _redModel = new RowModel(ColorCode.rd);
            _yellowModel = new RowModel(ColorCode.ye);
            _greenModel = new RowModel(ColorCode.gn);
            _blueModel = new RowModel(ColorCode.bu);
            _ruleService = new RuleService();
            _ruleService.ModelList = new List<IRowModel>(new List<IRowModel> 
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
            {
                _redModel,
                _yellowModel,
                _greenModel,
                _blueModel
            });
<<<<<<< HEAD
            _gamingService.Model = new RowModel(FieldCode.None);
            _gamingService.MissModel = new MissModel(FieldCode.None);
=======
            _ruleService.Model = new RowModel(ColorCode.None);
            _ruleService.MissModel = new MissModel();
            _ruleService.MissModel = new MissModel();
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void GetRules_ReturnListOfMethods()
        {
<<<<<<< HEAD

=======
            var list = _ruleService.GetRules();

            Assert.AreEqual(4, list.Count()); 
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectRedCount()
        {
<<<<<<< HEAD
            _gamingService.ClickedField = new CheckBox { Name = "rd07" };

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 6);
=======
            _ruleService.ClickedField = new CheckBox { Name = "rd07" };

            _ruleService.RuleLockLeftFields();

            Assert.IsNotNull(_ruleService.ClickedField);
            Assert.AreEqual(_ruleService.FieldList.Count, 6);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectYellowCount()
        {
<<<<<<< HEAD
            _gamingService.ClickedField = new CheckBox { Name = "ye04" };

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 3);
=======
            _ruleService.ClickedField = new CheckBox { Name = "ye04" };

            _ruleService.RuleLockLeftFields();

            Assert.IsNotNull(_ruleService.ClickedField);
            Assert.AreEqual(_ruleService.FieldList.Count, 3);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectGreenCount()
        {
<<<<<<< HEAD
            _gamingService.ClickedField = new CheckBox { Name = "gn07" };
            _gamingService.Model = new RowModel(FieldCode.None);

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 6);
=======
            _ruleService.ClickedField = new CheckBox { Name = "gn07" };
            _ruleService.Model = new RowModel(ColorCode.None);

            _ruleService.RuleLockLeftFields();

            Assert.IsNotNull(_ruleService.ClickedField);
            Assert.AreEqual(_ruleService.FieldList.Count, 6);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void LockLeftFields_IsNotNullAndHasCorrectBlueCount()
        {
<<<<<<< HEAD
            _gamingService.ClickedField = new CheckBox { Name = "bu04" };
            _gamingService.Model = new RowModel(FieldCode.None);

            _gamingService.RuleLockLeftFields();

            Assert.IsNotNull(_gamingService.ClickedField);
            Assert.AreEqual(_gamingService.FieldList.Count, 9);
=======
            _ruleService.ClickedField = new CheckBox { Name = "bu04" };
            _ruleService.Model = new RowModel(ColorCode.None);

            _ruleService.RuleLockLeftFields();

            Assert.IsNotNull(_ruleService.ClickedField);
            Assert.AreEqual(_ruleService.FieldList.Count, 9);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void CheckAddLock_ListContain00()
        {
<<<<<<< HEAD
            _gamingService.Model.Lock = true;

            _gamingService.RuleAddLock();

            Assert.IsTrue(_gamingService.FieldList.Contains("None00"));
=======
            _ruleService.Model.Lock = true;

            _ruleService.RuleAddLock();

            Assert.IsTrue(_ruleService.FieldList.Contains("None00"));
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void Check2CompleteRows_FieldListHasCountOf0()
        {
<<<<<<< HEAD
            _gamingService.Rule2CompleteRows();

            Assert.AreEqual(0, _gamingService.FieldList.Count);
=======
            _ruleService.Rule2CompleteRows();

            Assert.AreEqual(0, _ruleService.FieldList.Count);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void Check2CompleteRows_FieldListHasCountOf52()
        {
            _redModel.Twelve = true;
            _greenModel.Two = true;
<<<<<<< HEAD

            _gamingService.Rule2CompleteRows();

            Assert.AreEqual(52, _gamingService.FieldList.Count);
=======
            _ruleService.Rule2CompleteRows();

            Assert.AreEqual(52, _ruleService.FieldList.Count);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void CheckMissFields_DisableAllFieldsWasNotCalled()
        {
<<<<<<< HEAD
            _gamingService.MissModel = new MissModel(FieldCode.ms);
            _gamingService.MissModel.Two = true;

            _gamingService.RuleMissFields();

            Assert.AreEqual(0, _gamingService.FieldList.Count);
=======
            _ruleService.MissModel = new MissModel();
            _ruleService.MissModel.Two = true;

            _ruleService.RuleMissFields();

            Assert.AreEqual(0, _ruleService.FieldList.Count);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        [TestMethod]
        public void CheckMissFields_DisableAllFieldsWasCalled()
        {

<<<<<<< HEAD
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
=======
            _ruleService.MissModel.Four = true;
            _ruleService.MissModel.Three = true;
            _ruleService.MissModel.Two = true;
            _ruleService.MissModel.One = true;

            _ruleService.RuleMissFields();

            Assert.AreEqual(52, _ruleService.FieldList.Count);
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }
    }
}
