

using Qwixx.Models.Contracts;

namespace Qwixx.Models
{
    public class ResultModel : IResultModel
    {
        /// <summary>
        /// Create a ResultModel with points from RowModels
        /// </summary>
        public ResultModel(int red, int yellow, int green, int blue, int miss)
        {
            RedResult = red;
            YellowResult = yellow;
            GreenResult = green;
            BlueResult = blue;
            MissResult = miss;
        }

        public int RedResult
        {
            get { return Calculate(_redResult); }
            set { _redResult = value; }
        }
        public int YellowResult
        {
            get { return Calculate(_yellowResult); }
            set { _yellowResult = value; }
        }
        public int GreenResult
        {
            get { return Calculate(_greenResult); }
            set { _greenResult = value; }
        }
        public int BlueResult
        {
            get { return Calculate(_blueResult); }
            set { _blueResult = value; }
        }
        public int MissResult
        {
            get { return CalculateMissResult(_missResult); }
            set { _missResult = value; }
        }
        public int EndResult 
        {
            get { return (RedResult + YellowResult + GreenResult + BlueResult) - MissResult; }
        }

        private int _redResult;
        private int _yellowResult;
        private int _greenResult;
        private int _blueResult;
        private int _missResult;

        private static int CalculateMissResult(int input)
        {
            return input * 5;
        }

        private static int Calculate(int input)
        {
            var result = input switch
            {
                1 => 1,
                2 => 3,
                3 => 6,
                4 => 10,
                5 => 15,
                6 => 21,
                7 => 28,
                8 => 36,
                9 => 45,
                10 => 55,
                11 => 66,
                12 => 78,
                _ => 0,
            };
            return result;
        }
    }
}
