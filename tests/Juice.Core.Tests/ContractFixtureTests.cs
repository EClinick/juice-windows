using System.Text.Json;
using Xunit;

namespace Juice.Core.Tests;

public class ContractFixtureTests
{
    private static JsonDocument ReadExample(string name)
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "contracts",
            "v0.1",
            "examples",
            name);

        return JsonDocument.Parse(File.ReadAllText(path));
    }

    [Theory]
    [InlineData("now-windows.json")]
    [InlineData("top-windows.json")]
    [InlineData("no-power-source.json")]
    public void ExamplesUseTheVersionedEnvelope(string name)
    {
        using var document = ReadExample(name);
        var root = document.RootElement;

        Assert.Equal("0.1", root.GetProperty("schemaVersion").GetString());
        Assert.Equal("windows", root.GetProperty("platform").GetString());
        Assert.NotEmpty(root.GetProperty("command").GetString()!);
        Assert.True(root.TryGetProperty("generatedAt", out _));
        Assert.True(root.TryGetProperty("ok", out _));
    }

    [Fact]
    public void NowFixtureOmitsUnmeasuredValues()
    {
        using var document = ReadExample("now-windows.json");
        var root = document.RootElement;
        var rails = root.GetProperty("measurement").GetProperty("rails");
        var battery = root.GetProperty("battery");

        Assert.False(rails.TryGetProperty("npu", out _));
        Assert.False(battery.TryGetProperty("chargeWatts", out _));
    }

    [Fact]
    public void TopFixtureEnergyReconciles()
    {
        using var document = ReadExample("top-windows.json");
        var energy = document.RootElement.GetProperty("energy");

        var system = energy.GetProperty("systemWattHours").GetDouble();
        var attributed = energy.GetProperty("attributedWattHours").GetDouble();
        var platform = energy.GetProperty("platformWattHours").GetDouble();

        Assert.Equal(system, attributed + platform, 9);
    }

    [Fact]
    public void FailureFixtureUsesTheSameEnvelope()
    {
        using var document = ReadExample("no-power-source.json");
        var root = document.RootElement;

        Assert.False(root.GetProperty("ok").GetBoolean());
        Assert.Equal("noPowerSource", root.GetProperty("error").GetProperty("code").GetString());
        Assert.False(root.TryGetProperty("measurement", out _));
    }
}
