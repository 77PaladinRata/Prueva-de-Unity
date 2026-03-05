using UnityEngine;

public class CoinFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float followSpeed = 5f;
    [SerializeField]
    private float minimunDistance = 0.05f;
    private bool isFollowing = false;
    private void StartFollowing(Transform playerTransform)
    {
        originalPosition = transform.localPosition;
        player = playerTransform;
        isFollowing = true;
    }
    public void Update()
    {
        if(isFollowing && player != null)
        {
            Vector3 tragetPosition = player.position; //* + originalPosition;
            tarnsform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition > minimunDistance))
            {
                player = null;
                isFollowing = false;
                transform.localPosition = originalPosition;
            }
        }
    }
}
