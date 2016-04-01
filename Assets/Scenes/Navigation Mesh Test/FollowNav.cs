using UnityEngine;
using System.Collections;

public class FollowNav : MonoBehaviour
{
    public GameObject Objective;
    public float Speed = 2.0f;
    public float Variability = 10;
    private NavMeshAgent navMeshAgent;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 objectivePosition = new Vector3(Objective.transform.position.x + Random.Range(-Variability, Variability),
                                                Objective.transform.position.y,
                                                Objective.transform.position.z + Random.Range(-Variability, Variability));

        /*transform.position = Vector3.MoveTowards(transform.position, objectivePosition, Time.deltaTime * Speed);
        transform.LookAt(new Vector3(Objective.transform.position.x, transform.position.y, Objective.transform.position.z)); // Su propia y para que al acercarse no se incline


        // No quiero que la posicion Y sea afectada asi que calculamos la distancia al suelo
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit);
        transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);*/


        navMeshAgent.SetDestination(objectivePosition);
    }

}

