using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f; //reset the shoot delay

        gunAudio.Play (); //"pew"

        gunLight.enabled = true; //enable the light

        gunParticles.Stop ();//stop the particle playing. this ensures it resets the particle animation
        gunParticles.Play (); //start it again.

        gunLine.enabled = true; //set the light
		gunLine.SetPosition (0, transform.position); //the first point of the gun ("0") is set as teh position of the tip of the gun

        shootRay.origin = transform.position; //start ray at gun tip
		shootRay.direction = transform.forward; //the local z axis. (creates an invisible line, which alows it to be checked later)

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)) //if it hits somthing that is in the shootable layer
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> (); //get the "victim"
            
			if(enemyHealth != null) //check if health can be taken away from it
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point); //takeaway the damage
            }
            gunLine.SetPosition (1, shootHit.point); //set the second position of the line to the point where the ray hit the object
        }
        else
        {
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range); 
			//go from the origin and add the value which is forward value (???) times the range.
			//i am guessing it only increases the on the z axis
			//continue the visible line 100 units
        }
    }
}
