namespace Microsoft.Net.Global;

using System.Collections;
using System.Data;
using System.Runtime.Serialization;
using static System.String;

public record struct Json
{
    public Json() { }
    [JProp("sdk")]
    public Sdk? Sdk { get; set; } = null;
    [JProp("msbuild-sdks")]
    public IDictionary<string, Version> ProjectSdks { get; set; } = new Dictionary<string, Version>();
    [JProp("projects")]
    public IDictionary<string, DirectoryInfo> Projects { get; set; } = new Dictionary<string, DirectoryInfo>();
    [JProp("tools")]
    public IDictionary<string, Version> Tools { get; set; } = new Dictionary<string, Version>();
}
