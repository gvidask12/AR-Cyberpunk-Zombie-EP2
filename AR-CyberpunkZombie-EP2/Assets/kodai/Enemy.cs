using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animacija;
    public float health = 80f;
    bool arDarGyvasZombis = true;
    bool puolimoAnimacija = false;
    bool headshotoPirmas = true;
    GameObject z3Zombis;
    GameObject z1Zombis;
    GameObject z2Zombis;
    private CapsuleCollider kapsule;
    public GameObject NaujasZombis;
    public Vector3 NaujoZombioSpawnTaskas;
    Rigidbody m_Rigidbody;
    //private BoxCollider galvos;
    //public float healthZmogeliuko = 30f;
    //public float amnountZmogeliukoZala = 10f;
    public int healthZmogeliuko = 100;
    public int amnountZmogeliukoZala = 10;
    bool PirmasSuvis = true;
    Taskai taskai;
    Veikejas veikejas;
    int taskaiUzHita = 0;
    void Start()
    {
        /*var z3Zombis = Resources.Load<GameObject>("z3");
        var z2Zombis = Resources.Load<GameObject>("z2");
        var z1Zombis = Resources.Load<GameObject>("z1");
        if (this.gameObject.name == "z3")
        //if (zzz3 % 2 == 0)
        {
            NaujasZombis = z2Zombis;
            Instantiate(NaujasZombis, NaujoZombioSpawnTaskas, transform.rotation);
        }
        else if (this.gameObject.name == "z2")
        {
            NaujasZombis = z1Zombis;
            Instantiate(NaujasZombis, NaujoZombioSpawnTaskas, transform.rotation);
        }
        else if (this.gameObject.name == "z1")
        {
            NaujasZombis = z3Zombis;
            Instantiate(NaujasZombis, NaujoZombioSpawnTaskas, transform.rotation);
            //NaujasZombis = this.gameObject;
        }*/
        //z3Zombis = GameObject.Find("z3");
        m_Rigidbody = GetComponent<Rigidbody>();
        NaujoZombioSpawnTaskas = transform.position; 
        NaujasZombis = this.gameObject;
        //NaujasZombis = this.gameObject;
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY; 
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
        //if (gameObject.name == "z2")
        //{
        //    NaujasZombis = GameObject.name("z3");
        //}
        //if (gameObject.name == "z1")
        //{
        //    NaujasZombis = GameObject.Find("z2");
        //}
        //if (gameObject.name == "z3")
        //{
        //    NaujasZombis = GameObject.Find("z1");
        //}
        veikejas = FindObjectOfType<Veikejas>();
        taskai = FindObjectOfType<Taskai>();
        kapsule = GetComponent<CapsuleCollider>();
        //galvos = GetComponent<BoxCollider>();
    }
    
    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "zmogeliukas")
            {
                if (arDarGyvasZombis == true)
                {
                    if (puolimoAnimacija == false)
                    {
                        zmogeliukoGyvybe();
                        print("palieciau zmogeliuka");
                        animacija = GetComponent<Animator>();
                        animacija.Play("attack", 0, 0.1f);
                        puolimoAnimacija = true;
                        Invoke("AtakosAnimacijosAtstatymas", 1);
                    }
                }
            }
        }
    
    public void TakeDamage(float amount)
    {
        if (arDarGyvasZombis == true)
        {
            health = health - amount;
            animacija = GetComponent<Animator>();
            animacija.Play("reaction", 0, 0.1f);
            taskaiUzHita = 10;
            PirmasSuvis = false;
            TaskuSkaiciavimas();
            if (health <= 0f)
            {
                Die();
            }
        }
    }
   
    void Die()
    {
        //zzz3++;
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        arDarGyvasZombis = false;
        animacija = GetComponent<Animator>();
        animacija.Play("dying", 0, 0.1f);
        SendMessage("Nebesekioja");
        health = 50f;
        //kapsule.enabled = false;
        //galvos galva = GetComponent<galvos>();
        //galva.GalvosBox();
        Invoke("ZombioSunaikinimas", 5f);
        Invoke("NaujoZombioSpawn", 2f);
        //NaujoZombioSpawn();
        //SendMessage("GalvosBox");
        //galvos.enabled = false;
        //Destroy(gameObject);
        //animacija = GetComponent<Animator>(); 
        //animacija.Play("reaction", 0, 0.1f);
    }
    void AtakosAnimacijosAtstatymas()
    {
        puolimoAnimacija = false;
    }
    void zmogeliukoGyvybe()
    {
        Zmogeliukas();
        healthZmogeliuko = healthZmogeliuko - amnountZmogeliukoZala;
        if (healthZmogeliuko <= 0f)
        {
            print("zmogeliukas mire");  
        }
    }
   public void Headshotas()
    {
        if (headshotoPirmas == true)
        {
            health = 0;
            Die();
            print("headshotas");
            if (PirmasSuvis == true)
            {
                taskaiUzHita = 50;
            }
            TaskuSkaiciavimas();
            headshotoPirmas = false;
        }
    }
    public void TaskuSkaiciavimas()
    {
        taskai.HitoTaskai(taskaiUzHita);  
    }
    void NaujoZombioSpawn()
    {
        Instantiate(NaujasZombis, NaujoZombioSpawnTaskas, transform.rotation);
    }
    void ZombioSunaikinimas()
    {
        Destroy(gameObject);
    }
    public void Zmogeliukas()
    {
        veikejas.Zmog(amnountZmogeliukoZala);
    }
}




