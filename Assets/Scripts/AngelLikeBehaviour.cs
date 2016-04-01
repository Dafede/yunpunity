using UnityEngine;
using System.Collections;

public class AngelLikeBehaviour : MonoBehaviour
{

    /*private struct AllBounds
	{
		public Bounds[] bounds;
		public int HowManyBounds;

		public AllBounds(int cap){
			bounds = new Bounds[cap];
			HowManyBounds = 0;
		}
	}*/

    private Camera cam;
    public GameObject Objective;
    public float Speed = 2.0f;
    public float Variability = 10;
    public bool JustFollow = false;

    // Use this for initialization
    void Start()
    {
        Camera[] cams = Objective.GetComponentsInChildren<Camera>();
        cam = cams[0];

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool move = false;
        if (JustFollow == false)
        {
            // Detectar si estoy siendo visto por el usuario
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
            bool insideFrustum = false;
            // Usar todos los componentes que se renderizan en el objeto
            Renderer[] rr = GetComponentsInChildren<Renderer>();
            for (int i = 0; i < rr.Length; ++i)
            {
                if (GeometryUtility.TestPlanesAABB(planes, rr[i].bounds))
                {
                    insideFrustum = true;
                    break;
                }
            }

            move = !insideFrustum;
            if (insideFrustum)
            { // Aunque este en el frustum puede que haya un objeto entre mi y el el usuario
                RaycastHit hit;
                Ray ray = new Ray(transform.position, Objective.transform.position - transform.position);
                bool hitted = Physics.Raycast(ray, out hit);
                if (hitted && hit.collider.gameObject.tag != "Player")
                { // entre el usuario y yo hay otro objeto
                    move = true;
                }
            }
        }
        else {
            move = true;
        }


        if (move)
        {
            Vector3 objectivePosition = new Vector3(Objective.transform.position.x + Random.Range(-Variability, Variability),
                                                    Objective.transform.position.y,
                                                    Objective.transform.position.z + Random.Range(-Variability, Variability));

            transform.position = Vector3.MoveTowards(transform.position, objectivePosition, Time.deltaTime * Speed);
            transform.LookAt(new Vector3(Objective.transform.position.x, transform.position.y, Objective.transform.position.z)); // Su propia y para que al acercarse no se incline


            // No quiero que la posicion Y sea afectada asi que calculamos la distancia al suelo
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit);
            transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);


        }

    }

}

