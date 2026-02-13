using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide : MonoBehaviour
{
    // // [SerializeField]
    [SerializeField]
    private string obstacleTag = "Obstacle";
    [SerializeField]
    private UnityEvent onObstacleCollision;
// *private void OnCollisionEnter(Collision collision)
    private void OnTriggerEnter(Collider other)
    {    //*collision.gameObject
        if (other.CompareTag(obstacleTag))
        {
            onObstacleCollision?.Invoke();
        }
    }
}
