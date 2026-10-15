using Core.Controls;
using Physics;
using UnityEngine;

namespace Saveur.Controls
{
    public class Move : Behavior<Vector3>
    {
        [SerializeField] protected Body body;
        [SerializeField] protected float acceleration;
        [SerializeField] protected float speed;
        public override bool TryPerform(Vector3 value)
        {
            Debug.Log($"Perform Move {value}");
            body.AddForce(
                force: acceleration * value,
                magnitude: speed,
                durationMode: DurationMode.Continuous,
                frictionMode: FrictionMode.With,
                referenceMode: ReferenceMode.Local,
                nullifiedDot: -1f,
                projectedDot: 1f,
                preserveMagnitude: true,
                requireContacts: true
            );

            return true;
        }

        public override void Iterate(Vector3 value)
        {
            Debug.Log($"Iterate Move {value}");
            body.AddForce(
                force: acceleration * value,
                magnitude: speed,
                durationMode: DurationMode.Continuous,
                frictionMode: FrictionMode.With,
                referenceMode: ReferenceMode.Local,
                nullifiedDot: -1f,
                projectedDot: 1f,
                preserveMagnitude: true,
                requireContacts: true
            );
        }
    }
}