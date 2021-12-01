using Autofac;
using Qwixx.Enums;
using Qwixx.FrontEnd;
using Qwixx.Models;
using Qwixx.Presenter;
using Qwixx.Services;

namespace Qwixx
{
    public class AutoFacContainer
    {
        private readonly ContainerBuilder _builder;
        public AutoFacContainer(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public IContainer Configure()
        {
            _builder.RegisterType<MainView>().AsImplementedInterfaces().AsSelf().SingleInstance();
<<<<<<< HEAD
            _builder.RegisterType<GamingService>().AsImplementedInterfaces().AsSelf().SingleInstance();
=======
            _builder.RegisterType<RuleService>().AsImplementedInterfaces().AsSelf();
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
            _builder.RegisterType<MainViewPresenter>().AsImplementedInterfaces().AsSelf();

            IContainer container = _builder.Build();

            container.Resolve<MainViewPresenter>(
<<<<<<< HEAD
                new NamedParameter("redModel", new RowModel(FieldCode.rd)),
                new NamedParameter("yellowModel", new RowModel(FieldCode.ye)),
                new NamedParameter("greenModel", new RowModel(FieldCode.gn)),
                new NamedParameter("blueModel", new RowModel(FieldCode.bu)),
                new NamedParameter("missModel", new MissModel(FieldCode.None))
=======
                new NamedParameter("redModel", new RowModel(ColorCode.rd)),
                new NamedParameter("yellowModel", new RowModel(ColorCode.ye)),
                new NamedParameter("greenModel", new RowModel(ColorCode.gn)),
                new NamedParameter("blueModel", new RowModel(ColorCode.bu)),
                new NamedParameter("missModel", new MissModel())
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
                );

            return container;
        }
    }
}
