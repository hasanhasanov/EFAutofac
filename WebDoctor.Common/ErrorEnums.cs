using System.ComponentModel;

namespace WebDoctor.Common
{
    public class ErrorEnums
    {
        public enum GlobalErrors
        {
            [Description("You have entered the missing information!")]
            MissingInformation,

            [Description("This record is already exists!")]
            RecordExists,



            [Description("{0} must be greater than zero!")]
            GreaterInformation,

            [Description("{0} field must be max {1} characters!")]
            MaxLength,

            [Description("{0} field cannot be less than {1} characters!")]
            MinLenght,

            [Description("{0} field can not be null!")]
            NotNullqsqws,

            [Description("{0} field can not be empty!")]
            NotEmpty
        }
    }
}
