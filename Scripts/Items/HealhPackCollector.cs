using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhPackCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthPack healthPack))
        {
            healthPack.Collect();
            if(TryGetComponent(out Player player))
            {
                player.Heal(5f);
            }
        }
    }
}
