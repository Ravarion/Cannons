using UnityEngine;
using System.Collections;

public class GlowingAttribute : CannonAttribute {

    public GameObject lightPrefab;
    public Material glowMaterial;
    public Material normalMaterial;

    public bool lightOn = true;

    private GameObject lightObject;

	public override void Start () {
        base.Start();
        if(lightPrefab == null)
        {
            lightPrefab = Resources.Load("LightPrefab") as GameObject;
        }
        if(glowMaterial == null)
        {
            glowMaterial = Resources.Load("GlowMaterial") as Material;
        }
        if(normalMaterial == null)
        {
            normalMaterial = Resources.Load("CannonMaterial") as Material;
        }
        lightObject = Instantiate(lightPrefab, transform.position, Quaternion.identity) as GameObject;
        lightObject.transform.SetParent(transform);
        GetComponent<MeshRenderer>().material = glowMaterial;
        transform.Find("Cylinder").GetComponent<MeshRenderer>().material = glowMaterial;
	}

    public override void ADown()
    {
        if(lightOn)
        {
            lightObject.SetActive(false);
            GetComponent<MeshRenderer>().material = normalMaterial;
            transform.Find("Cylinder").GetComponent<MeshRenderer>().material = normalMaterial;
        }
        else
        {
            lightObject.SetActive(true);
            GetComponent<MeshRenderer>().material = glowMaterial;
            transform.Find("Cylinder").GetComponent<MeshRenderer>().material = glowMaterial;
        }
        lightOn = !lightOn;
    }
}
