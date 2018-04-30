using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIscript : MonoBehaviour
{
    public float radius = 500f;
    public GameObject grenadePrefab;
    public LaunchScriptAI _Laun;
    private NavMeshAgent agent;
    private int if_played = 0;
    public GameObject world;
    //Animator anim;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        int count = 0;
        Rigidbody[] allplayers = new Rigidbody[4];
        Collider[] colliderstodestroy = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliderstodestroy)
        {
            PlayerMovement des = nearbyObject.GetComponent<PlayerMovement>();
            if (des != null)
            {
                Debug.Log(count);
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                allplayers[count] = rb;
                count += 1;
            }
        }
        //Debug.Log("here");
        //Debug.Log(allplayers.Length);
        //StartCoroutine(Example(allplayers[0]));
        float dist = Vector3.Distance(allplayers[0].position, transform.position);
        Rigidbody target = new Rigidbody();
        float targetdist = new float();
        float dist2;
        for (int i = 0; i < count; i++)
        {
            dist2 = Vector3.Distance(allplayers[i].position, transform.position);
            if (dist >= dist2)
            {
                dist = dist2;
                target = allplayers[i];
                targetdist = dist2;
            }
        }
        
        if (if_played == 0) {
            lookatplayer(target);

            if (targetdist > 10)
            {
                //StartCoroutine(Example2());
                //float position = targetdist / (targetdist - 10);

                Vector3 position = (transform.position + target.position) / 2;
                position = (transform.position + position) / 2;
                agent.SetDestination(position);
                
            

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath )
                    {
                            Debug.Log(targetdist);
                            StartCoroutine(Example(target));
                            world.GetComponent<test>().change();
                            if_played = 1;


                        }
                    }
            }

            }
            else
            {
                StartCoroutine(Example(target));
                world.GetComponent<test>().change();
                if_played = 1;
            }
           

        }
        


    }

    IEnumerator Example(Rigidbody target)
    {

        yield return new WaitForSeconds(1);
        

        GameObject grenade = Instantiate(grenadePrefab, transform.position + new Vector3(0f, .5f, .5f), transform.rotation);
        _Laun.GetComponent<LaunchScriptAI>().Launch(target, grenade);
    }

    void lookatplayer(Rigidbody target)
    {
        //transform.LookAt(target.transform);
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*8);
        
    }

  
}
