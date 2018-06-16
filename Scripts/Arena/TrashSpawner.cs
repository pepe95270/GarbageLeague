using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
	public float minRateSpawn;
	public float maxRateSpawn;
    public GameObject ground;
    public GameObject bin;
    public GameObject trashPrefab;
    public GameObject trashContainer;

	float timeUntilNextSpawn;

    private void InitializeNextTrash()
    {
        Vector3 v = ground.GetComponent<Collider>().bounds.size;
        float l =  v.x;
        float L =  v.z;
        float lr = Random.Range(1, l - 0.001f);
        float Lr = Random.Range(1, L - 0.001f);
        if (lr < bin.GetComponent<Renderer>().bounds.size.x)
        {
            if (Lr < bin.GetComponent<Renderer>().bounds.size.z || Lr > L - bin.GetComponent<Renderer>().bounds.size.z)
            {}
            else {
                GameObject newTrash = Instantiate(trashPrefab, trashContainer.transform, true);
                newTrash.transform.Translate(new Vector3(lr, 0, Lr) - new Vector3(l / 2, 0, L / 2));
            }
        }
        else if (lr > l - bin.GetComponent<Renderer>().bounds.size.x)
        {
            if (Lr <  bin.GetComponent<Renderer>().bounds.size.z || Lr > L - bin.GetComponent<Renderer>().bounds.size.z)
            {}
            else{
                GameObject newTrash = Instantiate(trashPrefab, trashContainer.transform, true);
                newTrash.transform.Translate(new Vector3(lr, 0, Lr) - new Vector3(l / 2, 0, L / 2));
            }
        }
        else
        {
            GameObject newTrash = Instantiate(trashPrefab, trashContainer.transform, true);
            newTrash.transform.Translate(new Vector3(lr, 0, Lr) - new Vector3(l / 2, 0, L / 2));
        }
    }

    private void Start()
    {
        InitializeNextTrash();
    }

    void Update()
	{
        if (Input.GetKey("space"))
            InitializeNextTrash();
	}
}
