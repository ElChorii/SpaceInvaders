using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    [SerializeField] private float shipSpeed;
    [SerializeField] private float shootCooldown;
    [SerializeField] private float bulletSpeed;

    [HideInInspector] public bool canShoot = true;
    [HideInInspector] public bool canSuperShoot = true;

    [SerializeField] private float leftBarrier;
    [SerializeField] private float rightBarrier;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject superBulletPrefab;
    private Rigidbody shipRigidbody;

    private Vector3 currentPosition;

    [SerializeField] private bool hasTwoGuns;
    [SerializeField] private bool useRightGun = false;
    [SerializeField] private Vector3 bulletSpawn;
    [SerializeField] private Vector3 secondaryBulletSpawn;
    private Vector3 selectedBulletSpawn;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        shipRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x + (Input.GetAxis("Horizontal")) * shipSpeed * Time.deltaTime, leftBarrier, rightBarrier);

        shipRigidbody.MovePosition(currentPosition);
    }

    private void Shoot()
    {
        if (hasTwoGuns == true)
        {
            if (useRightGun)
            {
                selectedBulletSpawn = bulletSpawn;
            }
            else
            {
                selectedBulletSpawn = secondaryBulletSpawn;
            }

            useRightGun = !useRightGun;
        }
        else
        {
            selectedBulletSpawn = bulletSpawn;
        }

        GameObject createdBullet = Instantiate(bulletPrefab, transform.position + selectedBulletSpawn, Quaternion.identity);
        createdBullet.GetComponent<BulletScript>().currentBulletSpeed = bulletSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + bulletSpawn, new Vector3(0.1f, 0.1f, 0.1f));

        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position + secondaryBulletSpawn, new Vector3(0.1f, 0.1f, 0.1f));
    }
}
