// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.AI.AnomalyDetector
{
    /// <summary> Variable Status. </summary>
    public partial class VariableState
    {
        /// <summary> Initializes a new instance of VariableState. </summary>
        public VariableState()
        {
        }

        /// <summary> Initializes a new instance of VariableState. </summary>
        /// <param name="variable"></param>
        /// <param name="filledNARatio"></param>
        /// <param name="effectiveCount"></param>
        /// <param name="firstTimestamp"></param>
        /// <param name="lastTimestamp"></param>
        internal VariableState(string variable, float? filledNARatio, int? effectiveCount, DateTimeOffset? firstTimestamp, DateTimeOffset? lastTimestamp)
        {
            Variable = variable;
            FilledNARatio = filledNARatio;
            EffectiveCount = effectiveCount;
            FirstTimestamp = firstTimestamp;
            LastTimestamp = lastTimestamp;
        }

        /// <summary> Gets or sets the variable. </summary>
        public string Variable { get; set; }
        /// <summary> Gets or sets the filled na ratio. </summary>
        public float? FilledNARatio { get; set; }
        /// <summary> Gets or sets the effective count. </summary>
        public int? EffectiveCount { get; set; }
        /// <summary> Gets or sets the first timestamp. </summary>
        public DateTimeOffset? FirstTimestamp { get; set; }
        /// <summary> Gets or sets the last timestamp. </summary>
        public DateTimeOffset? LastTimestamp { get; set; }
    }
}
