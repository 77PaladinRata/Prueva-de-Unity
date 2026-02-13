using UnityEngine;

public class PlaformsManajer : MonoBehaviour
{
    [SerializeField] 
    private Transform plataformsPivot;

    [SerializeField]
    private InstantiatePoolObjects[] platformPrefabs;
    [SerializeField]
    private int initialPlatforms = 5;
    [SerializeField]
    private float speed = 5f;
    private bool isRunning = true;
    private GameObject lastPlatform;
    public void StartGame()
    {
        InstantiatePlatforms();
        InstantiatePlatform(initialPlatforms);
        transform.position = plataformsPivot.position;
        isRunning = true; //*Nueva
    }
    //* 
    private void InstantiatePlatforms()
    {
        foreach (var plaform in platformPrefabs)
        {
            plaform.DeactivateAllObjects();
        }
    }
    //*
    private void InstantiatePlatform(int number)
    {
        for (int i = 0; i <number; i++)
        {
            InstantiatePoolObjects instantiatePooll = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            Vector3 spawnPosition = Vector3.zero;
            if (lastPlatform != null)
            {
                   spawnPosition = lastPlatform.transform.localPosition + lastPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5f;
            } //* GameObject y Agregando mas nuevas
            instantiatePooll.InstantiateObject(spawnPosition);
            GameObject newPlatform = instantiatePooll.GetCurrentObject();
        //* 
            newPlatform.transform.SetParent(transform); //* El Nuevo
            newPlatform.transform.localPosition = spawnPosition + newPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5f;
            lastPlatform = newPlatform;
        }
}
    private void Update()
    {
        if (isRunning)
        {
             transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
    public void StopPlatforms()
    {
        isRunning = false;
    }
}