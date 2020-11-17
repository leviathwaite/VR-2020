using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollision : MonoBehaviour
{
    public GameObject impactPrefab;
    public AudioClip impactAudioClip;

    [SerializeField]
    private int poolSize = 10;

    private GameObject[] impactEffects;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPool();
    }

    private void SpawnPool()
    {
        impactEffects = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject temp = Instantiate(impactPrefab, transform.position, transform.rotation);
            temp.transform.parent = transform;
            temp.SetActive(false);
            impactEffects[i] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject temp = GetImpactEffect();

        // other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

        if (temp != null)
        {
            temp.transform.position = other.transform.position;
            // TODO reset to original spot?
            Destroy(other.gameObject);

            temp.transform.rotation = Quaternion.Euler(Vector3.up);
            temp.SetActive(true);
        }
    }

    private GameObject GetImpactEffect()
    {
        foreach (GameObject effect in impactEffects)
        {
            if(!effect.activeInHierarchy)
            {
                return effect;
            }
        }

        return null;
    }
}
