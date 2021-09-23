using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject  _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3 (Random.Range(-9f, 9f), 7, 0);
        GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);//define what game object is being instantiated
        newEnemy.transform.parent = _enemyContainer.transform;//create that enemy as a child of the enemy container
            yield return new WaitForSeconds(5.0f);//wait 5 seconds before it does it all over again
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
        
