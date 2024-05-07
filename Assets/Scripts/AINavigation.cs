using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject priorTarget;
    public GameObject[] way;

    public Animator animator;
    public float rotation;
    public float sleepConst = 2;
    private float timeCounter = 2;
    private int wayIndex = 0;
    private Vector3 dest;
    private bool disableAgent = false;
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
        var velocity = agent.velocity;
        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        
        if (timeCounter >= sleepConst)
        {
            agent.enabled = true;
            if (priorTarget == null)
            {
                if (Vector3.Distance(transform.position, way[wayIndex].transform.position) < 2)
                {
                    wayIndex = (wayIndex + 1) % way.Length;
                    disableAgent = true;
                    timeCounter = 0;
                }

                agent.speed = 2.5f;
                dest = way[wayIndex].transform.position;
            }
            else
            {
                agent.speed = 4;
                dest = priorTarget.transform.position;
            }

            agent.SetDestination(dest);
            if (disableAgent)
            {
                agent.enabled = false;
                disableAgent = false;
            }
            if (agent.enabled)
                rotation = GetAngleFromVectorFloat(dest - transform.position);
        }
        else if(priorTarget != null)
            timeCounter = sleepConst;
        else
            timeCounter += Time.deltaTime;
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
