﻿

using System.Collections.ObjectModel;
using FluentAssertions;
using Xunit;
using static Toggl.Multivac.Extensions.ObservableCollectionExtensions;

namespace Toggl.Multivac.Tests
{
    public class ObservableCollectionExtensionsTests
    {
        public class TheAddRangeMethod
        {
            [Fact]
            public void AddsAllItems()
            {
                int[] initialItems = { 1, 2 };
                int[] newItems = { 3, 4, 5 };
                var collection = new ObservableCollection<int>(initialItems);

                collection.AddRange(newItems);

                collection.Should().HaveCount(initialItems.Length + newItems.Length)
                          .And.Contain(initialItems)
                          .And.Contain(newItems);
            }
        }
    }
}
