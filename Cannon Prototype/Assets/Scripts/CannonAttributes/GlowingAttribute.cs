using UnityEngine;
using System.Collections;

public class GlowingAttribute : CannonAttribute {

    public GameObject lightPrefab;
    public Material glowMaterial;

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
        GameObject newGlow = Instantiate(lightPrefab, transform.position, Quaternion.identity) as GameObject;
        newGlow.transform.SetParent(transform);
        GetComponent<MeshRenderer>().material = glowMaterial;
        transform.Find("Cylinder").GetComponent<MeshRenderer>().material = glowMaterial;
	}
}
