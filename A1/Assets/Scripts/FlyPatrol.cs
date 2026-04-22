using UnityEngine;

public class FlyPatrol : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float leftLimit = -4f;
    [SerializeField] private float rightLimit = 4f;

    private int direction = 1;

    private void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (transform.position.x >= rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x <= leftLimit)
        {
            direction = 1;
        }
    }
}
