using Content.Server.Malf.Components;
using Content.Shared.Mind.Components;
using Content.Shared.Mobs.Components;

namespace Content.Server.Malf.Systems;

public sealed class CpuSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CpuComponent, ComponentStartup>(OnCpuEventReceived);
        SubscribeLocalEvent<CpuComponent, MindAddedMessage>(OnCpuEventReceived);
        SubscribeLocalEvent<CpuComponent, MindRemovedMessage>(OnCpuEventReceived);
    }


    private void OnCpuEventReceived(EntityUid uid, CpuComponent component, EntityEventArgs args)
    {
        UpdateCpuAmount(uid, component);
    }

    private void UpdateCpuAmount(EntityUid uid, CpuComponent component)
    {
        if (!TryComp<MobStateComponent>(uid, out var apc))
            return;

        component.Hacked = true
        component.CpuAmount += 10;
    }
}
