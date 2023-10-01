/*
 * Sdk.cs
 *
 *   Created: 2023-03-24-05:40:23
 *   Modified: 2023-03-24-05:52:21
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Net;

public record struct Sdk
{
    public Sdk() { }

    [JProp("version")]
    public Version Version { get; set; }

    [JProp("allowPrerelease")]
    public bool AllowPrerelease { get; set; } = false;

    [JProp("rollForward")]
    public RollForward RollForward { get; set; } = RollForward.Disable.Instance;
}
