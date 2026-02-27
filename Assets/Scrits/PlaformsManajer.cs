using UnityEngine;
using UnityEngine.Events;

public class PlaformsManajer : MonoBehaviour
{
    [SerializeField] 
    private Transform plataformsPivot;

    [SerializeField]
    private InstantiatePoolObjects[] platformPrefabs;
    //* nueva
    [SerializeField]
    private InstantiatePoolObjects [] securePlatformPrefatbs;
    // 
    [SerializeField]
    private int initialPlatforms = 5;
    [SerializeField]
    private float speed = 5f;
    //* nueva
    [SerializeField]
    private UnityEvent<Platform> onPlatformPassed;
    //*
    private bool isRunning = true;
    private GameObject lastPlatform;
    //* conteo de plataformas
    private int platformsInstantiated = 0;
    public void StartGame()
    {   
        lastPlatform = null;
        platformsInstantiated = 0;
        InitializePlatforms();
        InstantiatePlatform(initialPlatforms);
        transform.position = plataformsPivot.position;
        isRunning = true; //*Nueva
    }
    //* 
    private void InitializePlatforms()
    {
        foreach (var platform in platformPrefabs)
        {
            platform.DeactivateAllObjects();
        }
        ///* conteo de platformas
        foreach (var securePlatform in securePlatformPrefatbs)
        {
            securePlatform.DeactivateAllObjects();
        }
    }
    //*
    private void InstantiatePlatform(int number)
    {
        for (int i = 0; i <number; i++)
        {   //* Nueva para las plataformas
            InstantiatePoolObjects instantiatePool;
            if (platformsInstantiated < 2)
            {
                instantiatePool = securePlatformPrefatbs[Random.Range(0, securePlatformPrefatbs.Length)];
            }
            else
            {
                instantiatePool = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            }
            platformsInstantiated++;
            //* InstantiatePoolObjects instantiatePool = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            Vector3 spawnPosition = Vector3.zero;
            if (lastPlatform != null)
            {
                   spawnPosition = lastPlatform.transform.localPosition + lastPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5f;
            } //* GameObject y Agregando mas nuevas
            instantiatePool.InstantiateObject(spawnPosition);
            GameObject newPlatform = instantiatePool.GetCurrentObject();
        //* 
            newPlatform.transform.SetParent(transform); //* El Nuevo
            newPlatform.transform.localPosition = spawnPosition + newPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5f;
            lastPlatform = newPlatform; //* nueva Abajo
            onPlatformPassed?.Invoke(newPlatform.GetComponent<Platform>());
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