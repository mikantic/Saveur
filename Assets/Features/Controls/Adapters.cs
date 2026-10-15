using Core.Controls;
using UnityEngine;

namespace Saveur.Controls
{
    public class MovementAdapter : InputActionAdapter<Vector2, Vector3>
    {
        protected readonly Camera camera;
        public MovementAdapter(
            Behavior<Vector3> behavior,
            StateMachine stateMachine,
            Camera camera
        ) : base(behavior, stateMachine)
        {
            this.camera = camera;
        }

        protected override Vector3 Adapt(Vector2 value)
        {
            return (camera.transform.forward * value.y + camera.transform.right * value.x).normalized;
        }
    }
    
}