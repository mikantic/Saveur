using UnityEngine;

public class LaunchPadDetector : MonoBehaviour
{
    [SerializeField] protected LaunchPad launchPad;

    protected void OnTriggerEnter(Collider _)
    {
        launchPad.TryLaunch();
    }
}