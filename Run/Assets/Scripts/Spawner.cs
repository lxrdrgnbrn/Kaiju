using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    
    [SerializeField] private int rand;
    [SerializeField] private int count;
    private bool _isObs;

    public void Spawn()
    {
        rand = Random.Range(0, 5);
        if (rand <= 3 && _isObs == false)
        {
            int i = Random.Range(1, objects.Length);
            Instantiate(objects[i], transform.position, Quaternion.identity);
            _isObs = true;
            count = 0;
        }
        else
        {
            if (count < 1)
            {
                Instantiate(objects[0], transform.position, Quaternion.identity);
                count++;
            }
            else
            {
                Instantiate(objects[0], transform.position, Quaternion.identity);
                _isObs = false;
            }
        }
    }
}
 
