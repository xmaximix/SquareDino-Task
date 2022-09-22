using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float projectileSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(DelayDisable());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy)){
            gameObject.SetActive(false);
            enemy.Die();
        }
    }

    IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    public void SetMoveDirection(Vector3 direction)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(direction * projectileSpeed, ForceMode.Impulse);
    }
}
