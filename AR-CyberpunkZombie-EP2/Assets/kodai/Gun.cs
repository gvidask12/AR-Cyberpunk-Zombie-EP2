
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera kamera;
    public ParticleSystem particle;
    //public GameObject impactas;
    public float SaudymoDaznumas = 15f;
    private float LaikasTarpSaudymo = 0f;

    public float healthZmogeliuko = 100f; //sukomunikuot su enemy scriptu
    public float amnountZmogeliukoZala = 10f;
    //private Animator animacija;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Semicolon))/*&& Time.deltaTime >= LaikasTarpSaudymo*/ //SAUTUVO ";"
        //if (Input.GetButtonDown("Fire1")) /*&& Time.deltaTime >= LaikasTarpSaudymo*/
        //if (Input.GetButtonDown("Fire1")/*&& Time.deltaTime >= LaikasTarpSaudymo*/)
        {
            //LaikasTarpSaudymo = Time.time + 1f / SaudymoDaznumas;
            Saudyt();  
        }
    }
    void Saudyt()
    {
        particle.Play();
        RaycastHit hit;
        if (Physics.Raycast(kamera.transform.position, kamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            //if (hit.transform.name == "ZombioGalva" || hit.transform.tag == "ZombioGalva")
                if (hit.collider is BoxCollider)
                {
                //SendMessage("Headshotas");
                enemy.Headshotas();
                }

                else if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            //animacija = GetComponent<Animator>();
            //animacija.Play("reaction", 0, 0.5f);
        }
            /*GameObject impactoGO = Instantiate(impactas, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactoGO, 2f);*/
    }
}

