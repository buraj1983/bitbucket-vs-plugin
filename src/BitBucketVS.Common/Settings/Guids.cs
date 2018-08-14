using System;

namespace BitBucketVS.Common.Settings
{
    public static class Guids
    {
        public const string BitBucketPackageString = "85f76143-75ef-411e-8d7b-087613f5ecee";
        public static readonly Guid BitBucketPackage = new Guid(BitBucketPackageString);

        public const string AssemblyResolverPackageString = "e556e90e-5f52-41e6-bcc8-1cca8e51c4a2";
        
        public const string BitbucketCmdSetString = "584AAC45-E76F-45D2-B121-D9706CBA3210";
        public static readonly Guid BitbucketCmdSet = new Guid(BitbucketCmdSetString);
    }
}