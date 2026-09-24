using MachineFleet.Client.Models;

namespace MachineFleet.Client.Services;

public class InMemoryMachineService : IMachineService
{
    private readonly List<Machine> _machines;

    public InMemoryMachineService()
    {
        _machines =
        [
            new() { Name = "Mixer 01", IsOnline = true, LastData = "Temp: 75°C", LastUpdated = DateTime.Now.AddMinutes(-2) },
            new() { Name = "Mixer 02", IsOnline = true, LastData = "RPM: 1500", LastUpdated = DateTime.Now.AddMinutes(-3) },
            new() { Name = "Crusher 01", IsOnline = true, LastData = "Amps: 34", LastUpdated = DateTime.Now.AddMinutes(-25) },
            new() { Name = "Pump 01", IsOnline = false, LastData = "Pressure: 120 bar", LastUpdated = DateTime.Now.AddMinutes(-34) },
            new() { Name = "Roller 01", IsOnline = false, LastData = "Vibration: 0.6g", LastUpdated = DateTime.Now.AddMinutes(-50) },
            new() { Name = "Conveyor 01", IsOnline = true, LastData = "Speed: 2.4 m/s", LastUpdated = DateTime.Now.AddMinutes(-8) },
        ];
    }

    public IReadOnlyList<Machine> GetMachines() => _machines.AsReadOnly();

    public void AddMachine(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        _machines.Add(new Machine { Name = name.Trim() });
    }

    public void RemoveMachine(Guid id)
    {
        var machine = FindMachine(id);

        if (machine is null) return;

        _machines.Remove(machine);
    }

    public void StartMachine(Guid id)
    {
        var machine = FindMachine(id);

        if (machine is null) return;

        machine.IsOnline = true;
        machine.LastUpdated = DateTime.Now;
    }

    public void StopMachine(Guid id)
    {
        var machine = FindMachine(id);

        if (machine is null) return;

        machine.IsOnline = false;
        machine.LastUpdated = DateTime.Now;
    }

    public void UpdateMachineData(Guid id, string data)
    {
        var machine = FindMachine(id);

        // Only an online machine can receive new data
        if (machine is null || !machine.IsOnline) return;

        machine.LastData = data;
        machine.LastUpdated = DateTime.Now;
    }

    private Machine? FindMachine(Guid id) => _machines.FirstOrDefault(m => m.Id == id);
}