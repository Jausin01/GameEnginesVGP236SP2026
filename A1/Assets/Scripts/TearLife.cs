using UnityEngine;

public class TearLife : MonoBehaviour
{
    private PlayerController player;

    public void Init(PlayerController p)
    {
        player = p;
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            player.OnTearDestroyed();
        }
    }
}
