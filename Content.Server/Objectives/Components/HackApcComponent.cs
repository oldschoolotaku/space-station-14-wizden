using Content.Server.Objectives.Systems;

namespace Content.Server.Objectives.Components;

[RegisterComponent, Access(typeof(HackedApcSystem))]
public sealed partial class HackApcComponent : Component
{
    /// <summary>
    /// the ammount of hacked APCS
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int ApcHacked;
}
