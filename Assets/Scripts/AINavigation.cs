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

    private MeshTest mesh;
    private float timeCounter = 2;
    private int wayIndex = 0;
    private Vector3 dest;
    private Vector3? playerPos;
    private bool disableAgent = false;
    private bool disabled = false;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        mesh = GetComponent<MeshTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled) return;
        
        
        var velocity = agent.velocity.normalized;
        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        
        if (timeCounter >= sleepConst)
        {
            if (mesh.IsPlayerVisible())
                playerPos = priorTarget.transform.position;
            
            agent.enabled = true;
            if (playerPos != null)
            {
                agent.speed = 7.25f;
                dest = playerPos.Value;
                
                if (Vector3.Distance(transform.position, dest) < 1.5)
                {
                    playerPos = null;
                    disableAgent = true;
                    timeCounter = 0;
                }
            }
            else
            {
                dest = way[wayIndex].transform.position;
                if (Vector3.Distance(transform.position, dest) < 1.5)
                {
                    wayIndex = (wayIndex + 1) % way.Length;
                    disableAgent = true;
                    timeCounter = 0;
                }

                agent.speed = 2.5f;
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
        else if (mesh.IsPlayerVisible())
            timeCounter = sleepConst;
        else
            timeCounter += Time.deltaTime;
    }

    public void Disable()
    {
        disabled = true;
        agent.enabled = false;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
    }

    public void Enable()
    {
        disabled = false;
        agent.enabled = true;
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }

    public void LoadData(Save.Enemy save)
    {
        transform.position = new Vector3(save.position.x, save.position.y, save.position.z);
        rotation = save.rotation;
    }
}
