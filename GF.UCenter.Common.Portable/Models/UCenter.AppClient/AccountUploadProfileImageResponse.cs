﻿using System.Runtime.Serialization;

namespace GF.UCenter.Common.Portable
{
    [DataContract]
    public class AccountUploadProfileImageResponse : AccountRequestResponse
    {
        public override void ApplyEntity(AccountResponse account)
        {
            base.ApplyEntity(account);
        }
    }
}