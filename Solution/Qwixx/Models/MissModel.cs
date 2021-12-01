using Qwixx.Attributes;
using Qwixx.Enums;
using Qwixx.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Qwixx.Models
{
    public class MissModel : IMissModel
    {
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
    }
}
