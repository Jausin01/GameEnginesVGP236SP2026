using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddValue(_value);
            gameObject.SetActive(false);
        }
    }
}
