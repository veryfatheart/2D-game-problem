using UnityEngine;

public class NewScript : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        transform.Translate(direction * speed * Time.deltaTime);
        CheckBounds();
    }

    void CheckBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), 1.5f, 0);
    }
}
