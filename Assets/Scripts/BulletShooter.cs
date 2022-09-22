using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletShooter 
{
    [SerializeField] Camera cam;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] GameObject shootPos;
    private ObjectPool<Bullet> bulletPool;

    public void Init()
    {
        bulletPool = new ObjectPool<Bullet>(bulletPrefab, 10);
    }

    public void Shoot()
    {
        Vector3 dir;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 30f))
        {
            dir = hit.point - shootPos.transform.position;
        }
        else
        {
            dir = ray.GetPoint(35f) - shootPos.transform.position;
        }
        Bullet newBullet = bulletPool.GetPooledObject();
        newBullet.transform.position = shootPos.transform.position;
        newBullet.SetMoveDirection(dir.normalized);
    }
}
