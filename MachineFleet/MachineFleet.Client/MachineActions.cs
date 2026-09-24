using Microsoft.AspNetCore.Components;

namespace MachineFleet.Client;

public class MachineActions
{
    public EventCallback<Guid> OnStart { get; init; }
    public EventCallback<Guid> OnStop { get; init; }
    public EventCallback<Guid> OnSendData { get; init; }
    public EventCallback<Guid> OnDelete { get; init; }
}