using Qwixx.Attributes;
using Qwixx.Enums;

namespace Qwixx.Models.Contracts
{
    public interface IMissModel
    {
        FieldCode Code { get; set; }
        [Field]
        bool One { get; set; }
        [Field]
        bool Two { get; set; }
        [Field]
        bool Three { get; set; }
        [Field]
        bool Four { get; set; }

        int Result { get; }

        int Count(bool value);
        int Count();
    }
}
