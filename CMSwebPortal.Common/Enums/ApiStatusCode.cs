using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.Common.Enums
{
    public enum ApiStatusCode
    {
        InternalServerError = 1,
        UserAlreadyRegistered,
        InvalidEmailOrPassword,
        PasswordRequired,
        ExceededLoginAttempts,
        EmailNotVerified,
        InvalidPassword,
        UserNotFound,
        GeneralError,
        UserAlreadyVerified,
        UserRegistrationError,
        RegisterSuccess,
        InvalidCode,
        EmailError,
        EmailAlreadyRegistered,
        EmailVerified,
        InviteUrlExpire,
        UserEmailNotVerified,
        UserPhoneNotVerified,
        UserEmailAlreadyVerified,
        UserDisabledError,
        InvalidRole,
        RoleAlreadyExist,
        NoArtistFound,
        ArtRatingSavedUnsuccessfull,
        ArtRatingSavedSuccessful,
        NoDataFound,
        NoDropAvailable,
        StripePaymentCompleted,
        StripePaymentFailure,
        BlockChainCompleted,
        BlockChainFailure,
        ArtistFanExists,
        AristFansSuccessful,
        BidAuthorizeSuccessful,
        BidAuthorizeFailure,
        HigherBidExist,
        PaymentSucessButErrorInMintingAndOrder,
        PaymentProcessingError,
        DropSupplyScriptError,

        ErrorOnOrderInsertionDB,
        TransactionConfrimation,
        InvalidAccessOrRefreshToken,
        [Description("User Login Successful")]
        UserLoginSucess,
        ExpireCode,
        SerializtionError,
        Logoutsuccessfully,
        SaveNFTSurveyDataFailure,
        UserNameExists,
        EmailSubscriptionFailed,
        S3BucketNotExist,
        S3BucketAlreadyExist,
        NoUserProfileDataFound,
        ScriptNotFound,
        ScriptAddedSuccessfully,
        DataAddedSuccessfully,
        FaildToDataAddedSuccessfully,
        DataNotFound,
        Successs,
        Failure,
        CategoryNotFound,
        DeletionUnsuccessfull,
        DeletionSuccessfull,
        EmailSendSuccessfully,
        NotWhiteListedUser,
        AlreadyClaimed,
        UserAlreadyExist,
        WhiteListUserAdded
    }
}
