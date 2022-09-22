using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Enemy : MonoBehaviour
{
    private Stage stage;
    [SerializeField] public BoxCollider boxCollider;
    [HideInInspector] public bool atStage;

    public void Init(Stage stage)
    {
        this.stage = stage;
    }

    public void Die()
    {
        stage.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
