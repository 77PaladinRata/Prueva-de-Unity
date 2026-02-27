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
    /// las botas
    [SerializeField]
    private string jumpPowerUpTag = "JumPowerUp";
    //* Agregandole el T
    [SerializeField]
    private UnityEvent <Transform> onObstacleCollision;
// *private void OnCollisionEnter(Collision collision)
    //* otras Botas
    [SerializeField]
    private UnityEvent<Transform> onJumpPowerUpCollected;
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
    //* Agregandole las botas
        else if (other.CompareTag(jumpPowerUpTag))
        {
            onJumpPowerUpCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
    }
}