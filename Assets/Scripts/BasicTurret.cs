using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour {

    public Transform target;
    public float range = 15;


    public string enemyTag = "enemy";

	// Use this for initialization
	void Start () {
        InvokeRepeating("Updatetarget", 0f, 0.5f);
	}
	
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3
        }


    }

    
	// Update is called once per frame
	void Update () {
		
	}



   void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
