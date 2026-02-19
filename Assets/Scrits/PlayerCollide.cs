using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide : MonoBehaviour
{
    // // [SerializeField]
    [SerializeField]
    private string obstacleTag = "Obstacle";
    ///* colision de monedas
    [SerializeField]
    private string coingTag = "Coin";
    //* Agregandole el T
    [SerializeField]
    private UnityEvent <Transform> onObstacleCollision;
// *private void OnCollisionEnter(Collision collision)
//* para las monedas
    [SerializeField]
    private UnityEvent<Transform> onCoinCollected;
    private void OnTriggerEnter(Collider other)
    {    //*collision.gameObject
        if (other.CompareTag(obstacleTag))
        {                //* Agregandole el T
            onObstacleCollision?.Invoke(transform);
        }//* nuevas monedas
        else if (other.CompareTag(coingTag))
        {
            onCoinCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }

    }
}