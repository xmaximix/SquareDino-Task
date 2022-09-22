using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private List<Enemy> stageEnemies;
    private Player player;

    private void Awake()
    {
        stageEnemies = new List<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.atStage == false)
            {
                stageEnemies.Add(enemy);
                enemy.Init(this);
                enemy.boxCollider.enabled = false;
                enemy.atStage = true;
            }
        }

        if (other.TryGetComponent(out Player player))
        {
            this.player = player;
            for (int i = 0; i < stageEnemies.Count; i++)
            {
                stageEnemies[i].boxCollider.enabled = true;
            }
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        stageEnemies.Remove(enemy);
        if (stageEnemies.Count <= 0)
        {
            player.MoveToNextStage();
        }
    }
}
