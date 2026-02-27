using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PonistManager : MonoBehaviour
{
    private int points;
    [SerializeField]
    private float pointsInterval = 0.5f;
    [SerializeField]
    private UnityEvent<int> onPointsChanged;
    private Coroutine pointsCoroutine;
    private void StartCounting()
    {
        points = 0;
        onPointsChanged?.Invoke(points);
        pointsCoroutine = StartCoroutine(CountPoints());
    }
    public void StopCounting()
    {
        if (pointsCoroutine != null)
        {
            StopCoroutine(pointsCoroutine);
            pointsCoroutine = null;
        }
    }
    private IEnumerator CountPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(pointsInterval);
            points++;
            onPointsChanged?.Invoke(points);
        }
    }
}
