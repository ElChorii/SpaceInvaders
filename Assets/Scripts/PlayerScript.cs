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
}
