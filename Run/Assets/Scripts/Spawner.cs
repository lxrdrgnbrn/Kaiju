using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    [SerializeField] private List<GameObject> obstaclePrefab;
    [SerializeField] private List<GameObject> flatPrefab;
    [SerializeField] private List<GameObject> bonusPrefab;
    [SerializeField] private List<GameObject> rareObjectPrefab;
    private int _count;
    private bool _prevObs;
    
    private void SpawnObstacle()
    {
        if (!_prevObs && _count >= 1) 
        {
            var i = Random.Range(0, obstaclePrefab.Count);
            Instantiate(obstaclePrefab[i], transform.position, Quaternion.identity);
            _prevObs = true;
            _count = 0;
        }
        else
        {
            var rand = Random.Range(0, 100);
            if (rand == 99)
            {
                SpawnBonus();
            }
            else
            {
                SpawnFlat();
            }

            _count++;
            _prevObs = false;
        }

    }

    private void SpawnFlat()
    {
        var i = Random.Range(0, flatPrefab.Count);
        Instantiate(flatPrefab[i], transform.position, Quaternion.identity);
    }

    private void SpawnBonus()
    {
        var i = Random.Range(0, bonusPrefab.Count);
        Instantiate(bonusPrefab[i], transform.position, Quaternion.identity);
    }
    
    public void Spawn()
    {
        var rand = Random.Range(0, 100);
        if (rand >= 45 && rand!=99)
        {
            SpawnObstacle();
        }
        else if (rand == 99)
        {
            SpawnBonus();
        }
        else
        {
            SpawnFlat();
        }
    }
}
 
