using UnityEngine;

public class Encounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MyPlayer"))
        {
            Destroy(gameObject);
        }
    }
    
}
