using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Contract.Constants.Main
{
    public class GeneralUseConstants : IGeneralUseConstants
    {
        public string DateFormat { get; } = "dd-MM-yyyy";
    }
}