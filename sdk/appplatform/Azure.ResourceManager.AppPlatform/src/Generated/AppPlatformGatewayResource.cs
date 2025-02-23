// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppPlatform.Models;

namespace Azure.ResourceManager.AppPlatform
{
    /// <summary>
    /// A Class representing an AppPlatformGateway along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AppPlatformGatewayResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAppPlatformGatewayResource method.
    /// Otherwise you can get one from its parent resource <see cref="AppPlatformServiceResource" /> using the GetAppPlatformGateway method.
    /// </summary>
    public partial class AppPlatformGatewayResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="AppPlatformGatewayResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _appPlatformGatewayGatewaysClientDiagnostics;
        private readonly GatewaysRestOperations _appPlatformGatewayGatewaysRestClient;
        private readonly AppPlatformGatewayData _data;

        /// <summary> Initializes a new instance of the <see cref="AppPlatformGatewayResource"/> class for mocking. </summary>
        protected AppPlatformGatewayResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "AppPlatformGatewayResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal AppPlatformGatewayResource(ArmClient client, AppPlatformGatewayData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="AppPlatformGatewayResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal AppPlatformGatewayResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _appPlatformGatewayGatewaysClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppPlatform", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string appPlatformGatewayGatewaysApiVersion);
            _appPlatformGatewayGatewaysRestClient = new GatewaysRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, appPlatformGatewayGatewaysApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.AppPlatform/Spring/gateways";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual AppPlatformGatewayData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of AppPlatformGatewayRouteConfigResources in the AppPlatformGateway. </summary>
        /// <returns> An object representing collection of AppPlatformGatewayRouteConfigResources and their operations over a AppPlatformGatewayRouteConfigResource. </returns>
        public virtual AppPlatformGatewayRouteConfigCollection GetAppPlatformGatewayRouteConfigs()
        {
            return GetCachedClient(Client => new AppPlatformGatewayRouteConfigCollection(Client, Id));
        }

        /// <summary>
        /// Get the Spring Cloud Gateway route configs.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}/routeConfigs/{routeConfigName}
        /// Operation Id: GatewayRouteConfigs_Get
        /// </summary>
        /// <param name="routeConfigName"> The name of the Spring Cloud Gateway route config. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeConfigName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeConfigName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<AppPlatformGatewayRouteConfigResource>> GetAppPlatformGatewayRouteConfigAsync(string routeConfigName, CancellationToken cancellationToken = default)
        {
            return await GetAppPlatformGatewayRouteConfigs().GetAsync(routeConfigName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the Spring Cloud Gateway route configs.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}/routeConfigs/{routeConfigName}
        /// Operation Id: GatewayRouteConfigs_Get
        /// </summary>
        /// <param name="routeConfigName"> The name of the Spring Cloud Gateway route config. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeConfigName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeConfigName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<AppPlatformGatewayRouteConfigResource> GetAppPlatformGatewayRouteConfig(string routeConfigName, CancellationToken cancellationToken = default)
        {
            return GetAppPlatformGatewayRouteConfigs().Get(routeConfigName, cancellationToken);
        }

        /// <summary> Gets a collection of AppPlatformGatewayCustomDomainResources in the AppPlatformGateway. </summary>
        /// <returns> An object representing collection of AppPlatformGatewayCustomDomainResources and their operations over a AppPlatformGatewayCustomDomainResource. </returns>
        public virtual AppPlatformGatewayCustomDomainCollection GetAppPlatformGatewayCustomDomains()
        {
            return GetCachedClient(Client => new AppPlatformGatewayCustomDomainCollection(Client, Id));
        }

        /// <summary>
        /// Get the Spring Cloud Gateway custom domain.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}/domains/{domainName}
        /// Operation Id: GatewayCustomDomains_Get
        /// </summary>
        /// <param name="domainName"> The name of the Spring Cloud Gateway custom domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<AppPlatformGatewayCustomDomainResource>> GetAppPlatformGatewayCustomDomainAsync(string domainName, CancellationToken cancellationToken = default)
        {
            return await GetAppPlatformGatewayCustomDomains().GetAsync(domainName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the Spring Cloud Gateway custom domain.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}/domains/{domainName}
        /// Operation Id: GatewayCustomDomains_Get
        /// </summary>
        /// <param name="domainName"> The name of the Spring Cloud Gateway custom domain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<AppPlatformGatewayCustomDomainResource> GetAppPlatformGatewayCustomDomain(string domainName, CancellationToken cancellationToken = default)
        {
            return GetAppPlatformGatewayCustomDomains().Get(domainName, cancellationToken);
        }

        /// <summary>
        /// Get the Spring Cloud Gateway and its properties.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}
        /// Operation Id: Gateways_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AppPlatformGatewayResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.Get");
            scope.Start();
            try
            {
                var response = await _appPlatformGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AppPlatformGatewayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the Spring Cloud Gateway and its properties.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}
        /// Operation Id: Gateways_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AppPlatformGatewayResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.Get");
            scope.Start();
            try
            {
                var response = _appPlatformGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AppPlatformGatewayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Disable the default Spring Cloud Gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}
        /// Operation Id: Gateways_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.Delete");
            scope.Start();
            try
            {
                var response = await _appPlatformGatewayGatewaysRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new AppPlatformArmOperation(_appPlatformGatewayGatewaysClientDiagnostics, Pipeline, _appPlatformGatewayGatewaysRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Disable the default Spring Cloud Gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}
        /// Operation Id: Gateways_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.Delete");
            scope.Start();
            try
            {
                var response = _appPlatformGatewayGatewaysRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new AppPlatformArmOperation(_appPlatformGatewayGatewaysClientDiagnostics, Pipeline, _appPlatformGatewayGatewaysRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create the default Spring Cloud Gateway or update the existing Spring Cloud Gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}
        /// Operation Id: Gateways_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The gateway for the create or update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AppPlatformGatewayResource>> UpdateAsync(WaitUntil waitUntil, AppPlatformGatewayData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.Update");
            scope.Start();
            try
            {
                var response = await _appPlatformGatewayGatewaysRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new AppPlatformArmOperation<AppPlatformGatewayResource>(new AppPlatformGatewayOperationSource(Client), _appPlatformGatewayGatewaysClientDiagnostics, Pipeline, _appPlatformGatewayGatewaysRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create the default Spring Cloud Gateway or update the existing Spring Cloud Gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}
        /// Operation Id: Gateways_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The gateway for the create or update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AppPlatformGatewayResource> Update(WaitUntil waitUntil, AppPlatformGatewayData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.Update");
            scope.Start();
            try
            {
                var response = _appPlatformGatewayGatewaysRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new AppPlatformArmOperation<AppPlatformGatewayResource>(new AppPlatformGatewayOperationSource(Client), _appPlatformGatewayGatewaysClientDiagnostics, Pipeline, _appPlatformGatewayGatewaysRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Check the domains are valid as well as not in use.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}/validateDomain
        /// Operation Id: Gateways_ValidateDomain
        /// </summary>
        /// <param name="content"> Custom domain payload to be validated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<AppPlatformCustomDomainValidateResult>> ValidateDomainAsync(AppPlatformCustomDomainValidateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.ValidateDomain");
            scope.Start();
            try
            {
                var response = await _appPlatformGatewayGatewaysRestClient.ValidateDomainAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Check the domains are valid as well as not in use.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}/gateways/{gatewayName}/validateDomain
        /// Operation Id: Gateways_ValidateDomain
        /// </summary>
        /// <param name="content"> Custom domain payload to be validated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<AppPlatformCustomDomainValidateResult> ValidateDomain(AppPlatformCustomDomainValidateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _appPlatformGatewayGatewaysClientDiagnostics.CreateScope("AppPlatformGatewayResource.ValidateDomain");
            scope.Start();
            try
            {
                var response = _appPlatformGatewayGatewaysRestClient.ValidateDomain(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
