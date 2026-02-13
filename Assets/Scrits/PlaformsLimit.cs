using UnityEngine;
using UnityEngine.Events;

public class PlaformsLimit : MonoBehaviour
{   // [SerializeField]
    [SerializeField]
    private string platformsTag = "Ground";
    [SerializeField]
    private UnityEvent onPlatformDetected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(platformsTag))
        {
            other.gameObject.SetActive(false);
            onPlatformDetected?.Invoke ();
        }
    }
}
