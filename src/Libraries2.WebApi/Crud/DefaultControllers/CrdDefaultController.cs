﻿using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Crud.Interfaces;
using Xlent.Lever.Libraries2.WebApi.Crud.ApiControllers;

namespace Xlent.Lever.Libraries2.WebApi.Crud.DefaultControllers
{
    /// <inheritdoc cref="ReadDefaultController{TModel}" />
    public abstract class CrdDefaultController<TModel> : CrdDefaultController<TModel, TModel>, ICrd<TModel, string>
    {
        /// <inheritdoc />
        protected CrdDefaultController(ICrd<TModel, string> logic)
            : base(logic)
        {
        }
    }

    /// <inheritdoc cref="ReadDefaultController{TModel}" />
    public abstract class CrdDefaultController<TModelCreate, TModel> : CrdApiController<TModelCreate, TModel>, ICrd<TModelCreate, TModel, string>
        where TModel : TModelCreate
    {
        private readonly ICrd<TModelCreate, TModel, string> _logic;

        /// <inheritdoc />
        protected CrdDefaultController(ICrd<TModelCreate, TModel, string> logic)
            : base(logic)
        {
            _logic = logic;
        }

        /// <inheritdoc />
        [Route("")]
        public override async Task<string> CreateAsync(TModelCreate item, CancellationToken token = default(CancellationToken))
        {
            return await base.CreateAsync(item, token);
        }

        /// <inheritdoc />
        [Route("{id}")]
        public override async Task DeleteAsync(string id, CancellationToken token = default(CancellationToken))
        {
            await base.DeleteAsync(id, token);
        }

        /// <inheritdoc />
        [Route("")]
        public override async Task DeleteAllAsync(CancellationToken token = default(CancellationToken))
        {
            await base.DeleteAllAsync(token);
        }
    }
}