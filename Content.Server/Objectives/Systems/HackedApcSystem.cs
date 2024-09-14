using Content.Server.Objectives.Components;
using Content.Shared.Objectives.Components;

namespace Content.Server.Objectives.Systems;

public sealed class HackedApcSystem : EntitySystem
{
    [Dependency] private readonly NumberObjectiveSystem _number = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<HackApcComponent, ObjectiveGetProgressEvent>(OnGetProgress);
    }

    private void OnGetProgress(EntityUid uid, HackApcComponent comp, ref ObjectiveGetProgressEvent args)
    {
        args.Progress = GetProgress(comp, _number.GetTarget(uid));
    }

    private float GetProgress(HackApcComponent comp, int target)
    {
        // prevent divide-by-zero
        if (target == 0)
            return 1f;

        if (comp.ApcHacked >= target)
            return 1f;

        return (float)comp.ApcHacked / (float)target;
    }

    public void ApcHacked(EntityUid uid, HackApcComponent? comp = null)
    {
        if (!Resolve(uid, ref comp))
            return;

        comp.ApcHacked++;
    }
}
