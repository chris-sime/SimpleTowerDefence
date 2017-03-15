using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int waypointIndex = 0;
    private Enemy enemy;

    UIManager UiManger;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
        UiManger = UIManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
        //TODO: REMOVE if slow duration is implemented
        enemy.speed = enemy.initSpeed;
    }

    void GetNextWaypoint()
    {

        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndWaypoint();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void EndWaypoint()
    {
        PlayerStats.Lives--;
        UiManger.LivesUi.text = PlayerStats.Lives.ToString();
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }
}
