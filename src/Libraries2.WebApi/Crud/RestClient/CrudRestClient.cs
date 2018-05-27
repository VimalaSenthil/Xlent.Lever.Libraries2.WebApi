﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Xlent.Lever.Libraries2.Crud.Interfaces;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace Xlent.Lever.Libraries2.WebApi.Crud.RestClient
{
    /// <inheritdoc cref="CrudRestClient{TModelCreate,TModel,TId}" />
    public class CrudRestClient<TModel, TId> : CrudRestClient<TModel, TModel, TId>,
        ICrud<TModel, TId>
    {

        /// <summary></summary>
        /// <param name="baseUri">The base URL that all HTTP calls methods will refer to.</param>
        /// <param name="withLogging">Should logging handlers be used in outbound pipe?</param>
        public CrudRestClient(string baseUri, bool withLogging = true)
            : base(baseUri, withLogging)
        {
        }

        /// <summary></summary>
        /// <param name="baseUri">The base URL that all HTTP calls methods will refer to.</param>
        /// <param name="credentials">The credentials used when making the HTTP calls.</param>
        /// <param name="withLogging">Should logging handlers be used in outbound pipe?</param>
        public CrudRestClient(string baseUri, ServiceClientCredentials credentials, bool withLogging = true)
            : base(baseUri, credentials, withLogging)
        {
        }

        /// <summary></summary>
        /// <param name="baseUri">The base URL that all HTTP calls methods will refer to.</param>
        /// <param name="authenticationToken">The token used when making the HTTP calls.</param>
        /// <param name="withLogging">Should logging handlers be used in outbound pipe?</param>
        public CrudRestClient(string baseUri, AuthenticationToken authenticationToken, bool withLogging)
            : base(baseUri, authenticationToken, withLogging)
        {
        }
    }

    /// <summary>
    /// Convenience client for making REST calls
    /// </summary>
    public class CrudRestClient<TModelCreate, TModel, TId> : CrdRestClient<TModelCreate, TModel, TId>, ICrud<TModelCreate, TModel, TId> where TModel : TModelCreate
    {

        /// <summary></summary>
        /// <param name="baseUri">The base URL that all HTTP calls methods will refer to.</param>
        /// <param name="withLogging">Should logging handlers be used in outbound pipe?</param>
        public CrudRestClient(string baseUri, bool withLogging = true)
            : base(baseUri, withLogging)
        {
        }

        /// <summary></summary>
        /// <param name="baseUri">The base URL that all HTTP calls methods will refer to.</param>
        /// <param name="credentials">The credentials used when making the HTTP calls.</param>
        /// <param name="withLogging">Should logging handlers be used in outbound pipe?</param>
        public CrudRestClient(string baseUri, ServiceClientCredentials credentials, bool withLogging = true)
            : base(baseUri, credentials, withLogging)
        {
        }

        /// <summary></summary>
        /// <param name="baseUri">The base URL that all HTTP calls methods will refer to.</param>
        /// <param name="authenticationToken">The token used when making the HTTP calls.</param>
        /// <param name="withLogging">Should logging handlers be used in outbound pipe?</param>
        public CrudRestClient(string baseUri, AuthenticationToken authenticationToken, bool withLogging)
            : base(baseUri, authenticationToken, withLogging)
        {
        }

        /// <inheritdoc />
        public virtual async Task UpdateAsync(TId id, TModel item, CancellationToken token = default(CancellationToken))
        {
            await PutNoResponseContentAsync($"{id}", item, cancellationToken: token);
        }

        /// <inheritdoc />
        public virtual async Task<TModel> UpdateAndReturnAsync(TId id, TModel item, CancellationToken token = default(CancellationToken))
        {
            return await PutAndReturnUpdatedObjectAsync($"{id}/ReturnUpdated", item, cancellationToken: token);
        }

        /// <summary>
        /// Use this method to simulate the <see cref="UpdateAndReturnAsync"/> method if that method is not implemented in the service.
        /// </summary>
        /// <param name="id">How the object to be updated is identified.</param>
        /// <param name="item">The new version of the item. </param>
        /// <param name="token">Propagates notification that operations should be canceled</param>
        /// <remarks>Calls the method <see cref="UpdateAsync"/> and then the ReadAsync method.</remarks>
        protected virtual async Task<TModel> SimulateUpdateAndReturnAsync(TId id, TModel item, CancellationToken token = default(CancellationToken))
        {
            await PutNoResponseContentAsync($"{id}", item, cancellationToken: token);
            return await ReadAsync(id, token);
        }
    }
}
