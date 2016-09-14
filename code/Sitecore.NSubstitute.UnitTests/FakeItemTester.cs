﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.NSubstitute.UnitTests
{
  [TestFixture]
  public class FakeItemTester
  {
    [Test]
    public void FakeItem_CanBeInstantiated()
    {
      var item = new FakeItem();
    }

    [Test]
    public void FakeItem_ShouldInitializeProperties()
    {
      var fakeItem = new FakeItem();
      fakeItem.ID.Should().NotBeNull();
      fakeItem.ID.Should().NotBe(ID.Null);

      var item = (Item)fakeItem;
      item.Should().NotBeNull();
    }

    [Test]
    public void FakeItem_ShouldInitialize_ItemProperties()
    {
      var item = (Item) new FakeItem();

      item.Fields.Should().NotBeNull();
      item.Editing.Should().NotBeNull();
      item.Template.Should().NotBeNull();
      item.Children.Should().NotBeNull();
      item.Children.Count.Should().Be(0);
      item.Database.Should().NotBeNull();
      item.Database.GetItem(item.ID).Should().Be(item);
    }

    [Test]
    public void FakeItem_ShouldInitializeField_ByNameIDValue()
    {
      var item = new FakeItem();
      ID id = ID.NewID;
      string name = "test field";
      string value = "test value";

      item.Add(id, name, value);

      var scItem = (Item) item;

      scItem.Fields[id].Should().NotBeNull();
      scItem.Fields[name].Should().NotBeNull();
      scItem.Fields[id].Value.Should().Be(value);
      scItem[id].Should().Be(value);
      scItem[name].Should().Be(value);
    }
  }
}