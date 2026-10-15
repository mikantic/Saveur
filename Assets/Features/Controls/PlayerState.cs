using Core.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Saveur.Controls
{
    public class PlayerState : StateMachine
    {
        [SerializeField] protected Camera cam;

        [SerializeField] protected Move movement;
        [SerializeField] protected InputActionReference movementInput;
        protected MovementAdapter movementAdapter;


        [SerializeField] protected Jump jump;
        [SerializeField] protected InputActionReference jumpInput;
        protected EmptyAdapter jumpAdapter;

        protected void Awake()
        {
            movementAdapter = new(
                behavior: movement,
                stateMachine: this,
                cam
            );
            movementAdapter.Link(movementInput);

            jumpAdapter = new(
                behavior: jump,
                stateMachine: this
            );
            jumpAdapter.Link(jumpInput);
        }

        protected void OnDestroy()
        {
            movementAdapter.UnLink(movementInput);
            jumpAdapter.UnLink(jumpInput);
        }

        protected void FixedUpdate()
        {
            Iterate();
            // to do: some behaviors use Update or LateUpdate or FixedUpdate, potentially change to enabling / disabling instead of iterating here and letting the behavior use its own update loop
        }
    }
}