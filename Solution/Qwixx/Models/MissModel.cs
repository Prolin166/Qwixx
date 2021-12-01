<<<<<<< HEAD
﻿using Qwixx.Attributes;
using Qwixx.Enums;
using Qwixx.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
=======
﻿using Qwixx.Models.Contracts;
using System.Collections.Generic;
using System.Reflection;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105

namespace Qwixx.Models
{
    public class MissModel : IMissModel
<<<<<<< HEAD
    {
=======
    { 
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        /// <summary>
        /// Create a MissModel for failure points
        /// </summary>
        public MissModel(FieldCode code)
        {
            Code = code;
        }

        public FieldCode Code { get; set; }
        [Field]
        public bool One { get; set; }
        [Field]
        public bool Two { get; set; }
        [Field]
        public bool Three { get; set; }
        [Field]
        public bool Four { get; set; }

        public int Result
        {
            get { return Calculate(Count(true)); }
        }

        public int Count(bool value)
        {
            var list = new List<object>();
            foreach (var prop in this.GetType().GetProperties().Where(m => m.GetCustomAttributes(typeof(FieldAttribute), false).Any()))
            {
                if (prop.GetValue(this).Equals(value))
                {
                    list.Add(prop.Name);
                }
            }

            return list.Count;
        }
<<<<<<< HEAD

        public int Count()
        {
            var list = new List<string>();
            foreach (var prop in this.GetType().GetProperties().Where(m => m.GetCustomAttributes(typeof(FieldAttribute), false).Any()))
            {
                list.Add(prop.Name);
            }
            return list.Count;
        }

        private int Calculate(int input)
        {
            return input * 5;
        }
=======
        public int Count()
        {
            var list = new List<string>();
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(bool))
                    list.Add(prop.Name);
            }
            return list.Count;
        }
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
    }
}
