﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Referee : EntityBase
{
    public string? Name { get; set; }
    public string? RefereeCategory { get; set; }
    public string? RefereeCity { get; set; }
}