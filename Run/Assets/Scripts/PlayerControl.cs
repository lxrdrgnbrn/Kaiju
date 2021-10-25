using UnityEngine;


public class PlayerControl: MonoBehaviour
{


    private Rigidbody2D _player;         
    
    [SerializeField] public float force = 6;

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>(); 
    }

    private void Jump(float jumpForce)
    {
        _player.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0 && _player.velocity.y==0)
        {
                Jump(force);
        }
        if(Input.touchCount> 0 && _player.velocity.y == 0)
        {
            Jump(force);
        }
        
    }
}
