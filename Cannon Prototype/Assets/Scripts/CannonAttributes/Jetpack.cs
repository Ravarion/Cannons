using UnityEngine;
using System.Collections;

public class Jetpack : CannonAttribute {

    public GameObject fuelGUIPrefab;
    private GameObject fuelGUI;

    public GameObject particleEffect;
    public float timeSinceBurn = 0;
    public float maxEnergy = 3;
    public float energy = 3; //Seconds of burn time

    public override void Start()
    {
        base.Start();
        if (particleEffect == null)
        {
            particleEffect = Resources.Load("Jetpack Particle") as GameObject;
        }
        if (fuelGUIPrefab == null)
        {
            fuelGUIPrefab = Resources.Load("FuelGUI") as GameObject;
        }
        if (fuelGUI == null)
        {
            if (transform.FindChild("FuelGUI"))
            {
                fuelGUI = transform.FindChild("FuelGUI").gameObject;
            }
            else
            {
                fuelGUI = Instantiate(fuelGUIPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity) as GameObject;
                fuelGUI.transform.SetParent(transform);
            }
        }
    }

    public override void Update()
    {
        timeSinceBurn += Time.deltaTime;
        if(energy < maxEnergy && timeSinceBurn > 1f && GetComponent<PlayerController>().isGrounded)
        {
            energy += Time.deltaTime * 3;
        }
        fuelGUI.transform.FindChild("Fuel").GetComponent<RectTransform>().sizeDelta = new Vector2(0,-1+energy/maxEnergy);
        fuelGUI.transform.LookAt(Camera.main.transform);
    }

    public override bool AHold(bool checkOverwrite)
    {
        return true;
    }

    public override void AHold()
    {
        if (!GetComponent<PlayerController>().currentCannon)
        {
            return;
        }

        if(energy > 0)
        {
            energy -= Time.deltaTime;
        }
        else
        {
            return;
        }

        timeSinceBurn = 0;

        GameObject particles = Instantiate(particleEffect, transform.position - transform.up*1.5f*transform.localScale.x, Quaternion.Euler(90,0,0)) as GameObject;
        particles.transform.localScale = transform.localScale;
        particles.transform.parent = transform;

        Vector3 forwardMovement = new Vector3(0, 0.9f, 0) + transform.forward*0.1f;
        if (GetComponent<Rigidbody>().velocity.y >= 5)
        {
            GetComponent<Rigidbody>().AddForce(forwardMovement * -0.1f, ForceMode.Impulse);
        }
        GetComponent<Rigidbody>().AddForce(forwardMovement * 0.1f, ForceMode.Impulse);
    }
}
