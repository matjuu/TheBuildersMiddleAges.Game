﻿using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace TheBuildersMiddleAges.Game.Actions
{
    public class ActionRequest
    {
        public Guid PlayerGuid { get; set; }
        public Guid GameGuid { get; set; }
        public int BuildingId { get; set; }
        public int WorkerId { get; set; }
    }
}