using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	NavMeshAgent agent;

	[SerializeField]
	GameObject m_Pointer;

	bool _spawned = false;
	bool Spawned
	{
		get { return _spawned; }
		set { _spawned = _spawned || value; }
	}

	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();	
	}

    // Update is called once per frame
    void Update () 
    {

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		bool collided = Physics.Raycast(ray, out hit);

		if (collided)
		{

			if (!Spawned)
			{
				m_Pointer = Instantiate(m_Pointer, hit.point, Quaternion.identity);
				Spawned = true;
			}

				m_Pointer.SetActive(true);
				m_Pointer.transform.position = hit.point;

			// La posición a la que queremos mover el agente está en 'hit.point'
			// hit.point es un Vector3, es decir que podríamos hacer:
			// transform.position = hit.point;

			if (Input.GetMouseButtonDown(0) && tag == "Player")
			{
				// Mover 'Human'

			}
			else if (Input.GetMouseButtonDown(1) && tag == "Pig")
			{
				// Mover 'Pig'

			}

		}
		else
		{
			m_Pointer.SetActive(false);
		}

    }
}