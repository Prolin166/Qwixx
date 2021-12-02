using Qwixx.Attributes;
using Qwixx.Enums;
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
            Code = code;
        }

        public FieldCode Code { get; set; }
        [Field]
        public bool Two { get; set; }
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
        public bool Twelve { get; set; }
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
    }
}
