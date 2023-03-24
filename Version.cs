/* 
 * Version.cs
 * 
 *   Created: 2023-03-24-05:41:11
 *   Modified: 2023-03-24-05:51:11
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

namespace Microsoft.Net;
using SysVersion = System.Version;


[RegexDto(@"^(?<Major:int>0|[1-9]\d*)\.(?<Minor:int?>0|[1-9]\d*)(?:\.(?<Build:int?>0|[1-9]\d*)?(?:\.(?<Revision:int?>0|[1-9]\d*))?(?:-(?<Suffix>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+(?<BuildMetadata>[0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$")]
[JConverter(typeof(VersionJsonConverter))]
public partial record struct SemVersion
{
    public override string ToString() => $"{Major}.{Minor}{(Build.HasValue ? "." : "")}{Build}{(Revision.HasValue ? "." : "")}{Revision}{(!IsNullOrEmpty(Suffix) ? "-" : "")}{Suffix}{(!IsNullOrEmpty(BuildMetadata) ? "+" : "")}{BuildMetadata}";
    public SemVersion(int major, int minor = 0, int build = 0, int revision = 0, string suffix = "", string buildMetadata = "")
        => (this.Major, this.Minor, this.Build, this.Revision, this.Suffix, this.BuildMetadata) = (major, minor, build, revision, suffix, buildMetadata);

    public static implicit operator SemVersion(string s) => new Version(s);
    public static implicit operator string(SemVersion v) => v.ToString();
    public static implicit operator SemVersion(SysVersion s) => new SemVersion(s.Major, s.Minor, s.Build, s.Revision);
    public static implicit operator SysVersion(SemVersion v) => new SysVersion(v.Major, v.Minor ?? 0, v.Build ?? 0, v.Revision ?? 0);
}

public class VersionJsonConverter : JsonConverter<SemVersion>
{
    public override SemVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            return default;
        return SemVersion.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, SemVersion value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
