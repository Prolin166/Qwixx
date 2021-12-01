using System.Windows.Forms;

namespace Qwixx.Presenter.Contracts
{
    public interface IMainViewPresenter
    {
        void MainView_RedMove(object sender, CheckBox e);
        void MainView_GreenMove(object sender, CheckBox e);
        void MainView_YellowMove(object sender, CheckBox e);
        void MainView_BlueMove(object sender, CheckBox e);

        void MainView_MissMove(object sender, CheckBox e);
        void MainView_CompleteGame(object sender, Button e);
    }
}
