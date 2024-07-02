using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Contract.Constants.Main
{
    public class ReturnValueConstants: IReturnValueConstants
    {
        public string SUCCESSFUL_CREATE { get; } = "{0} created successfully";
        public string SUCCESSFUL_UPDATE { get; } = "{0} updated successfully";
        public string SUCCESSFUL_DELETE { get; } = "{0} deleted successfully";
        public string SUCCESSFUL_VERIFICATION { get; } = "Email verified successfully. Please proceed to login";
        public string SUCCESSFUL_CHANGE_PASSWORD {get; } = "Password changed successfully. Please check your email";
        public string SUCCESSFUL_RESET_PASSWORD { get; } = "Password reset successfully. Please check your email";


        public string FAILED_CREATE { get; } = "Failed to create {0}";
        public string FAILED_UPDATE { get; } = "Failed to update {0}";
        public string FAILED_DELETE { get; } = "Failed to delete {0}";
        public string FAILED_VERIFICATION { get; } = "Failed to verify {0}";
        public string FAILED_CHANGED_PASSWORD { get; } = "Failed to change {0} password";
        public string FAILED_RESET_PASSWORD { get; } = "Failed to reset {0} password";


        public string ITEM_DOES_NOT_EXIST { get; } = "{0} does not exist";
        public string ITEM_ALREADY_EXIST { get; } = "{0} already exists";
        
        public string NO_CHANGES_MADE { get; } = "No changes has been made to {0}";

        public string ACCOUNT_NOT_VERIRIED { get; } = "The account is not verified. Please check your email";

        public string EMAIL_SENDING_ERROR { get; } = "Wrong in sending {0}";

        public string DATABASE_OPERATION_FAILED { get; } = "Database operation failed";
    }
}