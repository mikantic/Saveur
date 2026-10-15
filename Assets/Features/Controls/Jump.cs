using Core.Controls;
using Physics;
using UnityEngine;

namespace Saveur.Controls
{
    public class Jump : Behavior
    {
        [SerializeField] protected Body body;
        [SerializeField] protected float speed = 10f;
        [SerializeField] protected float duration = 0.25f;

        protected float startTime;

        // should this handle 

        public override bool TryPerform()
        {
            startTime = Time.time;

            body.AddForce(
                force: Vector3.up * 200,
                magnitude: speed,
                durationMode: DurationMode.Instant,
                frictionMode: FrictionMode.None,
                referenceMode: ReferenceMode.Local,
                nullifiedDot: 0,
                projectedDot: 0,
                preserveMagnitude: false,
                requireContacts: true
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

            body.AddForce(
                force: Vector3.up * 200,
                magnitude: speed,
                durationMode: DurationMode.Instant,
                frictionMode: FrictionMode.None,
                referenceMode: ReferenceMode.Local,
                nullifiedDot: 0,
                projectedDot: 0,
                preserveMagnitude: false,
                requireContacts: false
            );
        }
    }
}