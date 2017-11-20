using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course3.Models
{
    public class 此欄位必須至少出現一個空白字元Attribute : DataTypeAttribute
    {
        public 此欄位必須至少出現一個空白字元Attribute() : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            var str = (string)value;

            return str.Contains(" ");
        }

    }
}