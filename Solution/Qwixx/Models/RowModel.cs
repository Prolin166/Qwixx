<<<<<<< HEAD
﻿using Qwixx.Attributes;
using Qwixx.Enums;
=======
﻿using Qwixx.Enums;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
using Qwixx.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Qwixx.Models
{
    public class RowModel : IRowModel
    {
        private bool _twelve;
        private bool _two;

        /// <summary>
        /// Create a RowModel and use code according to IEC 60757
        /// </summary>
        public RowModel(FieldCode code)
        {
<<<<<<< HEAD
            Code = code;
=======
            Color = color;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
        }

        public FieldCode Code { get; set; }
        [Field]
        public bool Two
        {
            get
            {
                return _two;
            }
            set
            {
<<<<<<< HEAD
                if (this.Count(true) >= 4 && (Code.Equals(FieldCode.gn) || Code.Equals(FieldCode.bu))) this.Lock = true;
=======
                if (this.Count(true) >= 4 && (Color.Equals(ColorCode.gn) || Color.Equals(ColorCode.bu))) this.Lock = true;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
                _two = value;
            }
        }
        [Field]
        public bool Three { get; set; }
        [Field]
        public bool Four { get; set; }
        [Field]
        public bool Five { get; set; }
        [Field]
        public bool Six { get; set; }
        [Field]
        public bool Seven { get; set; }
        [Field]
        public bool Eight { get; set; }
        [Field]
        public bool Nine { get; set; }
        [Field]
        public bool Ten { get; set; }
        [Field]
        public bool Eleven { get; set; }
        [Field]
        public bool Twelve
        {
            get
            {
                return _twelve;
            }
            set
            {
<<<<<<< HEAD
                if (this.Count(true) >= 4 && (Code.Equals(FieldCode.rd) || Code.Equals(FieldCode.ye))) this.Lock = true;
=======
                if (this.Count(true) >= 4 && (Color.Equals(ColorCode.rd) || Color.Equals(ColorCode.ye))) this.Lock = true;
>>>>>>> 4140869e415681d24a866a9ab5f6ad3e85995105
                _twelve = value;
            }
        }
        [Field]
        public bool Lock { get; set; }

        public int Result
        {
            get { return Calculate(Count(true)); }
        }

        public int Count(bool value)
        {
            var list = new List<string>();
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
