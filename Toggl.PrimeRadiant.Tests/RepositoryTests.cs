﻿using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Toggl.PrimeRadiant.Exceptions;
using Xunit;

namespace Toggl.PrimeRadiant.Tests
{
    public abstract class RepositoryTests<TTestModel> : BaseRepositoryTests<TTestModel>
        where TTestModel : class, ITestModel, IDatabaseSyncable, new()
    {
        protected abstract IRepository<TTestModel> Repository { get; }

        protected override IBaseRepository<TTestModel> BaseRepository => Repository;

        [Fact]
        public void TheGetByIdMethodThrowsIfThereIsNoEntityWithThatIdInTheRepository()
        {
            Func<Task> callingGetByIdInAnEmptyRepository = 
                async () => await Repository.GetById(-1);

            callingGetByIdInAnEmptyRepository
                .ShouldThrow<EntityNotFoundException>();
        }

        [Fact]
        public async Task TheGetByIdMethodAlwaysReturnsASingleElement()
        {
            var testEntity = new TTestModel();
            await Repository.Create(testEntity);

            var element = await Repository.GetById(testEntity.Id).SingleAsync();
            element.Should().Be(testEntity);
        }
    }
}
