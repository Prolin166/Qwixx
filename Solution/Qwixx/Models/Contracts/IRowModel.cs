using Qwixx.Attributes;
using Qwixx.Enums;

namespace Qwixx.Models.Contracts
{
    public interface IRowModel
    {
        FieldCode Code { get; set; }
        [Field]
        bool Two { get; set; }
        [Field]
        bool Three { get; set; }
        [Field]
        bool Four { get; set; }
        [Field]
        bool Five { get; set; }
        [Field]
        bool Six { get; set; }
        [Field]
        bool Seven { get; set; }
        [Field]
        bool Eight { get; set; }
        [Field]
        bool Nine { get; set; }
        [Field]
        bool Ten { get; set; }
        [Field]
        bool Eleven { get; set; }
        [Field]
        bool Twelve { get; set; }
        [Field]
        bool Lock { get; set; }

        int Result { get; }

        int Count(bool value);
        int Count();
    }
}
