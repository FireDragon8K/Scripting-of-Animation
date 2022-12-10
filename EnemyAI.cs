using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    // Enemy Stats
    public int curHp, maxHp, scoreToGive;
    public float moveSpeed, attackRange, yPathOffset;
    
    private List<Vector3> path;
    
    // Target to follow
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp = maxHp;
    }

    // Update is called once per frame
    void UpdatePath()
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if (path.Count == 0)
            return;
        
        // Move towards the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0));
            path.RemoveAt(0);
        
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp<= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);

    }

    void Update()
    {
        // Look at the target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        // Calculate the distance between enemy and the player
        float dist = Vector3.Distance(transform.position, target.transform.position);
            
    }
}
