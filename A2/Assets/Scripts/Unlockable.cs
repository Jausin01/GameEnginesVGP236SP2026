using UnityEngine;

public class Unlockable : MonoBehaviour
{
    [SerializeField] private int _requiredValue = 5;

    private bool _unlocked = false;

    private void Start()
    {
        GameManager.Instance.Register(this);
        gameObject.SetActive(false); 
    }

    public void TryUnlock(int currentValue)
    {
        if (_unlocked) return;

        if (currentValue >= _requiredValue)
        {
            _unlocked = true;
            gameObject.SetActive(true);

            Debug.Log("Desbloqueado: " + gameObject.name);
        }
    }
}