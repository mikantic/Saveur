using Core.Controls;
using Physics;
using UnityEngine;

namespace Saveur.Controls
{
    public class Jump : Behavior
    {
        // to do: maybe use a jump height or something?

        [SerializeField] protected Body entity;
        [SerializeField] protected float speed = 10f;
        [SerializeField] protected float duration = 0.25f;

        protected float startTime;

        public override bool TryPerform()
        {
            startTime = Time.time;

            entity.AddForce(
                force: Vector3.up * 200,
                magnitude: speed,
                durationMode: DurationMode.Instant,
                frictionMode: FrictionMode.None,
                referenceMode: ReferenceMode.Local,
                preserveMagnitude: false
            );

            return true;
        }

        public override void Iterate()
        {
            if (Time.time - startTime >= duration)
            {
                Complete();
                return;
            }

            entity.AddForce(
                force: Vector3.up * 200,
                magnitude: speed,
                durationMode: DurationMode.Instant,
                frictionMode: FrictionMode.None,
                referenceMode: ReferenceMode.Local,
                preserveMagnitude: false
            );
        }
    }
}