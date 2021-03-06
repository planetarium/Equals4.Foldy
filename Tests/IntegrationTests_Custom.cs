﻿using System;
using Xunit;

public partial class IntegrationTests
{
    [Fact]
    public void Equals_should_use_custom_logic()
    {
        var type = testResult.Assembly.GetType("CustomEquals");
        dynamic first = Activator.CreateInstance(type);
        first.X = 1;

        dynamic second = Activator.CreateInstance(type);
        second.X = 2;

        var result = first.Equals(second);

        Assert.True(result);
    }

    [Fact]
    public void Equals_should_use_custom_logic_for_structure()
    {
        var type = testResult.Assembly.GetType("CustomStructEquals");
        dynamic first = Activator.CreateInstance(type);
        first.X = 1;

        dynamic second = Activator.CreateInstance(type);
        second.X = 2;

        var result = first.Equals(second);

        Assert.True(result);
    }

    [Fact]
    public void Equals_should_use_custom_logic_for_generic_type()
    {
        var genericClassType = testResult.Assembly.GetType("CustomGenericEquals`1");
        var propType = typeof(int);
        var type = genericClassType.MakeGenericType(propType);

        dynamic first = Activator.CreateInstance(type);
        first.Prop = 1;
        dynamic second = Activator.CreateInstance(type);
        second.Prop = 1;
        dynamic third = Activator.CreateInstance(type);
        third.Prop = 2;

        Assert.True(first.Equals(second));
        Assert.False(first.Equals(third));
    }

    [Fact]
    public void GetHashCode_should_use_custom_logic()
    {
        var type = testResult.Assembly.GetType("CustomGetHashCode");
        dynamic instance = Activator.CreateInstance(type);
        instance.X = 1;

        var result = instance.GetHashCode();

        Assert.Equal(423, result);
    }

    [Fact]
    public void GetHashCode_should_use_custom_logic_for_structure()
    {
        var type = testResult.Assembly.GetType("CustomStructEquals");
        dynamic instance = Activator.CreateInstance(type);
        instance.X = 1;

        var result = instance.GetHashCode();

        Assert.Equal(42, result);
    }

    [Fact]
    public void GetHashCode_should_use_custom_logic_for_generic_type()
    {
        var genericClassType = testResult.Assembly.GetType("CustomGenericEquals`1");
        var propType = typeof(int);
        var type = genericClassType.MakeGenericType(propType);

        dynamic instance = Activator.CreateInstance(type);
        instance.Prop = 1;

        var result = instance.GetHashCode();

        Assert.Equal(42, result);
    }
}