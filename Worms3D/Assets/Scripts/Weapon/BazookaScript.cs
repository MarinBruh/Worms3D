using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BazookaScript : MonoBehaviour
{
    public float shootForce = 40.0f;
    public GameObject rocketPrefab;
    private Transform cameraTransform;
    public ParticleSystem launchEffect;
    public AudioSource source;
    public AudioClip clip;
    public int rocketAmmo;
    public TMP_Text ammoUI;

    public ThirdPersonCam thirdPersonCam;
    void Awake()
    {
        cameraTransform = Camera.main.transform;
        rocketAmmo = 1;
    }

    void Update()
    {
        ammoUI.SetText("Ammo: " + rocketAmmo.ToString("F0"));
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && thirdPersonCam.currentStyle == ThirdPersonCam.CameraStyle.Combat && rocketAmmo >= 1)
        {
            ShootRocket();
            rocketAmmo--;
        }
    }

    void ShootRocket()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
        {
            GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            Rigidbody rb = rocket.GetComponent<Rigidbody>(); 
            rb.AddForce(transform.forward * shootForce, ForceMode.VelocityChange);
                
            launchEffect.Play(); 
            source.PlayOneShot(clip);
        }
    }
}
