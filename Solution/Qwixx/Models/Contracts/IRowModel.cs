<<<<<<< HEAD
﻿using Qwixx.Attributes;
using Qwixx.Enums;
=======
﻿using Qwixx.Enums;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105

namespace Qwixx.Models.Contracts
{
    public interface IRowModel
    {
<<<<<<< HEAD
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

=======
        ColorCode Color { get; set; }
        bool Two { get; set; }
        bool Three { get; set; }
        bool Four { get; set; }
        bool Five { get; set; }
        bool Six { get; set; }
        bool Seven { get; set; }
        bool Eight { get; set; }
        bool Nine { get; set; }
        bool Ten { get; set; }
        bool Eleven { get; set; }
        bool Twelve { get; set; }
        bool Lock { get; set; }

>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        int Count(bool value);
        int Count();
    }
}
