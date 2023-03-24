namespace Microsoft.Net.Enums;
using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("RollForward", "Microsoft.Net")]
public enum RollForward
{
    [EnumMember(Value = "disable")]
    Disable,
    [EnumMember(Value = "patch")]
    Patch,
    [EnumMember(Value = "feature")]
    Feature,
    [EnumMember(Value = "minor")]
    Minor,
    [EnumMember(Value = "major")]
    Major,
    [EnumMember(Value = "latestPatch")]
    LatestPatch,
    [EnumMember(Value = "latestFeature")]
    LatestFeature,
    [EnumMember(Value = "latestMajor")]
    LatestMajor
}
