namespace Content.Server.Malf.Components;

public sealed partial class CpuComponent : Component
{
    [ViewVariables(VVAccess.ReadWrite)]
    public bool Hacked = false;

    [ViewVariables(VVAccess.ReadWrite)]
    public float CpuAmount = 0f;
}
