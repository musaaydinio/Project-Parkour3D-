using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    public float yürümeHizi = 1f;
    public float kosmaHizi = 4f;
    public float ziplamagücü = 3f;
    public float donmeHizi = 120f;
    private bool yerdemi = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        // Zýplama komutu geldiðinde karakter zemindeyse dikey eksende kuvvet uygulayýp animasyonlarý tetikliyoruz.
        if (Input.GetKeyDown(KeyCode.Space) && yerdemi)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, ziplamagücü, rb.linearVelocity.z);
            if (anim != null)
            {
                GetComponent<SoundManager>().ZiplamaSesiCal();
                anim.SetTrigger("isJumping");
            }
            yerdemi = false;
        }

        // Sol ve sað yönlü fiziksel hareketini yapýp ilgili animasyonlarý aktif ediyoruz.
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isLeft", true);
            transform.Translate(Vector3.left * yürümeHizi * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isLeft",false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRight",true);
            transform.Translate(Vector3.right * yürümeHizi * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isRight",false) ;
        }

        // Ýleri yönlü harekette koþma tuþuna basýlý tutulursa hýzý artýrýp koþma animasyonuna geçiþ yapýyoruz.
        if (Input.GetKey(KeyCode.W))
        {
           
            if (Input.GetKey(KeyCode.LeftShift))
            {
               
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);

               
                transform.Translate(Vector3.forward * kosmaHizi * Time.deltaTime);
            }
            else
            {
                
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);

               
                transform.Translate(Vector3.forward * yürümeHizi * Time.deltaTime);
            }
        }
        // Geriye doðru hareketlerde dengeyi saðlamak adýna hýzý yarýya düþürüyoruz.
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            transform.Translate(Vector3.back * (yürümeHizi / 2) * Time.deltaTime);
        }
        else
        {
            
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }
    // Zemin algýlama sistemini Unity fizik motorunun çarpýþma metotlarý ile takip ediyoruz.
    private void OnCollisionStay(Collision collision)
    {
        yerdemi = true;

    }
    private void OnCollisionExit(Collision other)
    {
        yerdemi = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SonsuzZýplama"))
        {
            // Birikmiþ düþüþ hýzýný sýfýrlayýp pürüzsüz bir sekme kuvveti uyguluyoruz.
            if (rb != null)
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

           
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, ziplamagücü, rb.linearVelocity.z);
        }

        if (anim != null)
        {
           
            anim.SetTrigger("isJumping");
        }
        yerdemi=false;
    }
}


