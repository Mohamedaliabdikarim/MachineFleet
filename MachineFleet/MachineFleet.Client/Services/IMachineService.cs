using MachineFleet.Client.Models;

namespace MachineFleet.Client.Services;

public interface IMachineService
{
    IReadOnlyList<Machine> GetMachines();
    void AddMachine(string name);
    void RemoveMachine(Guid id);
    void StartMachine(Guid id);
    void StopMachine(Guid id);
    void UpdateMachineData(Guid id, string data);
}