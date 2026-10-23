using Core.Controls;
using Physics;
using Physics.Numerics;
using UnityEngine;

namespace Saveur.Controls
{
    public class Move : Behavior<Vector3>
    {
        // to do: probably project direction on anti gravity normal?
        [SerializeField] protected Body entity;
        [SerializeField] protected float acceleration;
        [SerializeField] protected float speed;
        public override bool TryPerform(Vector3 value)
        {
            entity.AddForce(
                force: acceleration * value,
                magnitude: speed,
                dotBounds: DotBounds.Project,
                durationMode: DurationMode.Continuous,
                frictionMode: FrictionMode.With,
                referenceMode: ReferenceMode.Local,
                preserveMagnitude: true
            );

            // body.AddForce(
            //     force: acceleration * value * 0.2f,
            //     magnitude: speed,
            //     durationMode: DurationMode.Continuous,
            //     frictionMode: FrictionMode.Against,
            //     referenceMode: ReferenceMode.Local,
            //     nullifiedDot: -1f,
            //     projectedDot: 1f,
            //     preserveMagnitude: true,
            //     requireContacts: false
            // );

            return true;
        }

        public override void Iterate(Vector3 value)
        {

            entity.AddForce(
                force: acceleration * value,
                magnitude: speed,
                dotBounds: DotBounds.Project,
                durationMode: DurationMode.Continuous,
                frictionMode: FrictionMode.With,
                referenceMode: ReferenceMode.Local,
                preserveMagnitude: true
            );

            // body.AddForce(
            //     force: acceleration * value * 0.2f,
            //     magnitude: speed,
            //     durationMode: DurationMode.Continuous,
            //     frictionMode: FrictionMode.Against,
            //     referenceMode: ReferenceMode.Local,
            //     nullifiedDot: -1f,
            //     projectedDot: 1f,
            //     preserveMagnitude: true,
            //     requireContacts: false
            // );
        }
    }
}