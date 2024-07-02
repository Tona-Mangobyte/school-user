namespace SchoolUser.Application.Constants.Interfaces
{
    public interface IReturnValueConstants
    {
        string SUCCESSFUL_CREATE { get; }
        string SUCCESSFUL_UPDATE { get; }
        string SUCCESSFUL_DELETE { get; }
        string SUCCESSFUL_VERIFICATION { get; }
        string SUCCESSFUL_CHANGE_PASSWORD { get; }
        string SUCCESSFUL_RESET_PASSWORD { get; }

        string FAILED_CREATE { get; }
        string FAILED_UPDATE { get; }
        string FAILED_DELETE { get; }
        string FAILED_VERIFICATION { get; }
        string FAILED_CHANGED_PASSWORD { get; }
        string FAILED_RESET_PASSWORD { get; }

        string ITEM_DOES_NOT_EXIST { get; }
        string ITEM_ALREADY_EXIST { get; }

        string NO_CHANGES_MADE { get; }

        string ACCOUNT_NOT_VERIRIED { get; }

        string EMAIL_SENDING_ERROR { get; }

        string DATABASE_OPERATION_FAILED { get; }
    }
}