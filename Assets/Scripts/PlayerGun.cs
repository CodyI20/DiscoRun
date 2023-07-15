using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private BulletScript _bulletPrefab;
    [SerializeField] private GameObject _shootingPosition;
    void ShootBullet()
    {
        if (_bulletPrefab != null && Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(_bulletPrefab.gameObject, _shootingPosition.transform.position, gameObject.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ShootBullet();
    }
}
