using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using TMPro;


[SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
public class Player : MonoBehaviour
{
    public int factor;
    [SerializeField] private int health;
    [SerializeField] private GameManager gm;
    [SerializeField] private int coins;
    [SerializeField] private TMP_Text coin;
    [SerializeField] private PlayerControl pc;
    [SerializeField] private Vector2 incScale;
    
    private Vector2 _normalScale;
    private Rigidbody2D _player;
    

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
        _normalScale = new Vector2(0.6f, 0.6f);
        health = 2;
        factor = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetHit();
        }
        if (collision.gameObject.CompareTag("Money"))
        {
            TakeCoin();
        }
        if (collision.gameObject.CompareTag("BonusMJ"))
        {
            MegaJump();
        }

        if (collision.gameObject.CompareTag("GodBonus"))
        {
            GodMode();
        }

        if (collision.gameObject.CompareTag("MultiplyBonus"))
        {
            Multiply();
        }
    }

    private void Multiply()
    {
        StartCoroutine(MultiplyCor());
    }
    private IEnumerator MultiplyCor()
    {
        var rand = Random.Range(2, 6);
        factor = rand;
        yield return new WaitForSeconds(10);
        factor = 1;
        yield return null;

    }

    private void GetHit()
    {
        StartCoroutine(GetHitCor());
    }

    private IEnumerator GetHitCor()
    {
        health--;
        if (health <= 0)
        {
            gm.Game_Over();
            _player.freezeRotation = false;
            _player.rotation = -10;
            Destroy(gameObject);
            yield return null;
        }
        yield return new WaitForSeconds(20);
        health = 2;
        yield return null;

    }
    
    private void TakeCoin()
    {
        coins += (1*factor);
        coin.text = coins.ToString();
    }
    private IEnumerator MegaJumpCor()
    {
        pc.force = 18;
        yield return new WaitForSeconds(10);
        pc.force = 13;
        yield return null;
    }

    private void MegaJump()
    {
        StartCoroutine(MegaJumpCor());
    }
    private IEnumerator GodModeCor()
    {
        health = 9999;
        transform.localScale = incScale;
        yield return new WaitForSeconds(10);
        health = 2;
        transform.localScale = _normalScale;
        yield return null;
    }

    private void GodMode()
    {
        StartCoroutine(GodModeCor());
    }
    
}
