using System.Collections;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField] private int health=1;
    [SerializeField] private GameManager gm;
    [SerializeField] private int coins;
    [SerializeField] private TMP_Text coin;
    [SerializeField] private PlayerControl pc;
    private bool _isDeath;
    private Rigidbody2D _player;

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            health = health - 1;
        }
        if (collision.gameObject.CompareTag("Money"))
        {
            coins++;
            coin.text = coins.ToString();
        }
        if (collision.gameObject.CompareTag("BonusMJ"))
        {
            StartCoroutine(MegaJump());
        }
    }

    private IEnumerator MegaJump()
    {
        pc.force = 18;
        yield return new WaitForSeconds(5);
        pc.force = 13;
        yield return null;
    }
    
    private void FixedUpdate()
    {
        if (health == 0)
            _isDeath = true;
        if (_isDeath)
        {
            gm.Game_Over();
            _player.freezeRotation = false;
            _player.rotation = -10;
            Destroy(gameObject);
        }
    }
}
