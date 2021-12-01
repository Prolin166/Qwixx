
namespace Qwixx.Models.Contracts
{
    public interface IResultModel
    {
        int RedResult { get; set; }
        int YellowResult { get; set; }
        int GreenResult { get; set; }
        int BlueResult { get; set; }
        int MissResult { get; set; }
        int EndResult { get; }
    }
}
