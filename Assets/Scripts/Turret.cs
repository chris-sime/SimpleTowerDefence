using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;

    [Header("Turret Attributes")]
    public bool shootNearest = true;
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("For Laser Turrets:")]
    public bool isLaserTurret = false;

    public int damageOverTime = 30;
    public float slow = 0.2f;
    public float slowDuration = 10f;

    public LineRenderer lineRenderer;
    public GameObject laserParticlesStart;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Setup")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            if (isLaserTurret) if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }

            return;
        }

        LockOnTarget();
        if (isLaserTurret)
        {         
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }


    }

    void Laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slow);
        //targetEnemy.Invoke("ResetSpeed", slowDuration);
        if (!lineRenderer.enabled)
        {
            impactEffect.Play();
            lineRenderer.enabled = true;
            impactLight.enabled = true;
        }  
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 particleDirection = firePoint.position - target.position;
        impactEffect.transform.position = target.position + particleDirection.normalized * (target.transform.localScale.x / 2);
        impactEffect.transform.rotation = Quaternion.LookRotation(particleDirection);


    }
    
    void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        if(shootNearest == true)
        {
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < range)
                {
                    
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
