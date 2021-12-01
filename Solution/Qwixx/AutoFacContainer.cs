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
            _builder.RegisterType<GamingService>().AsImplementedInterfaces().AsSelf();
            _builder.RegisterType<MainViewPresenter>().AsImplementedInterfaces().AsSelf();

            IContainer container = _builder.Build();

            container.Resolve<MainViewPresenter>(
                new NamedParameter("redModel", new RowModel(FieldCode.rd)),
                new NamedParameter("yellowModel", new RowModel(FieldCode.ye)),
                new NamedParameter("greenModel", new RowModel(FieldCode.gn)),
                new NamedParameter("blueModel", new RowModel(FieldCode.bu)),
                new NamedParameter("missModel", new MissModel(FieldCode.ms))
                );

            return container;
        }
    }
}
