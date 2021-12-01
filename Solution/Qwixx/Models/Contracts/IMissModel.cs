<<<<<<< HEAD
﻿using Qwixx.Attributes;
using Qwixx.Enums;

=======
﻿
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
namespace Qwixx.Models.Contracts
{
    public interface IMissModel
    {
<<<<<<< HEAD
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

=======
        bool One { get; set; }
        bool Two { get; set; }
        bool Three { get; set; }
        bool Four { get; set; }

>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        int Count(bool value);
        int Count();
    }
}
