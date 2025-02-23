// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> The AgentPoolAvailableVersion. </summary>
    public partial class AgentPoolAvailableVersion
    {
        /// <summary> Initializes a new instance of AgentPoolAvailableVersion. </summary>
        internal AgentPoolAvailableVersion()
        {
        }

        /// <summary> Initializes a new instance of AgentPoolAvailableVersion. </summary>
        /// <param name="isDefault"> Whether this version is the default agent pool version. </param>
        /// <param name="kubernetesVersion"> The Kubernetes version (major.minor.patch). </param>
        /// <param name="isPreview"> Whether Kubernetes version is currently in preview. </param>
        internal AgentPoolAvailableVersion(bool? isDefault, string kubernetesVersion, bool? isPreview)
        {
            IsDefault = isDefault;
            KubernetesVersion = kubernetesVersion;
            IsPreview = isPreview;
        }

        /// <summary> Whether this version is the default agent pool version. </summary>
        public bool? IsDefault { get; }
        /// <summary> The Kubernetes version (major.minor.patch). </summary>
        public string KubernetesVersion { get; }
        /// <summary> Whether Kubernetes version is currently in preview. </summary>
        public bool? IsPreview { get; }
    }
}
