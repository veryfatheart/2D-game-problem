using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public int damage = 40;

    public Rigidbody2D rb;

    // public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
        //rb please move right according to speed
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BadGuy badguy = hitInfo.GetComponent<BadGuy>();

        if (badguy != null)
        {
            badguy.TakeDamage(damage);

            //Instantiate(impactEfffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
