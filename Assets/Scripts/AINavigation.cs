using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float rotation;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        var dest = target.transform.position;
        var self = transform.position;
        agent.SetDestination(target.transform.position);
        rotation = GetAngleFromVectorFloat(dest - self);
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }

    /*public void LoadData(Save.Enemy save)
    {
        transform.position = new Vector3(save.position.x, save.position.y, save.position.z);
    }*/
}
