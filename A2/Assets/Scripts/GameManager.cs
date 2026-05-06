using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int currentValue = 0;

    private List<Unlockable> unlockables = new List<Unlockable>();
    [SerializeField] private Base baseA;
    [SerializeField] private Base baseB;
    private bool _win = false;

    [SerializeField] private TextMeshProUGUI victoryText;
    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        victoryText.gameObject.SetActive(false);
    }

    public void Register(Unlockable u)
    {
        if (!unlockables.Contains(u))
            unlockables.Add(u);
    }

    public void AddValue(int amount)
    {
        currentValue += amount;

        NotifyUnlocks();
    }

    private void NotifyUnlocks()
    {
        for (int i = 0; i < unlockables.Count; i++)
        {
            unlockables[i].TryUnlock(currentValue);
        }
    }

    public void Update()
    {
        if (!_win && baseA.HasPlayer() && baseB.HasPlayer())
        {
            _win = true;
            victoryText.gameObject.SetActive(true);
        }
    }

}