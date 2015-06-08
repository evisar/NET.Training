using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    public abstract class ExternalFileRules<T>: IRule<T>
    {
        public bool Check(T obj)
        {
            var name = this.GetType().Name + ".rule";
            var ruleText = File.ReadAllText(name);
            var tokens = ruleText.Split(' ');
            var property = tokens.First();
            int value = int.Parse(tokens.Last());
            var operation = tokens[1];

            var type = typeof(T);
            var pi = type.GetProperty(property);
            int piValue = (int)pi.GetValue(obj);

            bool result = false;
            switch(operation)
            {
                case ">":
                    result = piValue > value;
                    break;
                case "<":
                    result = piValue < value;
                    break;
                case "=":
                    result = piValue == value;
                    break;
                case ">=":
                    result = piValue >= value;
                    break;
                case "<=":
                    result = piValue <= value;
                    break;
            }

            return result;
        }
    }
}
