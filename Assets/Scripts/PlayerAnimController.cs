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
        if (Input.GetKeyDown(KeyCode.Space) && yerdemi)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, ziplamagücü, rb.linearVelocity.z);
            if (anim != null)
            {
                anim.SetTrigger("isJumping");
            }
            yerdemi = false;
        }

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
        //  ÖNCELÝKLE OYUNCU ÝLERÝ GÝTMEK ÝÇÝN W TUÞUNA BASIYOR MU?
        if (Input.GetKey(KeyCode.W))
        {
            // W'ye basýlýrken AYNI ANDA Sol Shift tuþuna da basýlýyor mu?
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // KOÞMA DURUMU
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);

                // Karakteri koþma hýzýyla ileri götür
                transform.Translate(Vector3.forward * kosmaHizi * Time.deltaTime);
            }
            else
            {
                // SADECE YÜRÜME DURUMU (W'ye basýlýyor ama Shift'e basýlmýyor)
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);

                // Karakteri normal yürüme hýzýyla ileri götür
                transform.Translate(Vector3.forward * yürümeHizi * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            transform.Translate(Vector3.back * (yürümeHizi / 2) * Time.deltaTime);
        }
        else
        {
            // OYUNCU ELÝNÝ W TUÞUNDAN ÇEKTÝ (IDLE - DURMA DURUMU)
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }
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
            if (rb != null)
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            // 2. Yukarý doðru zýplama gücünü ver (ziplamaGucu deðiþken adýný kendi scriptindekiyle eþitle)
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, ziplamagücü, rb.linearVelocity.z);
        }

        if (anim != null)
        {
            // 3. Zýplama animasyonunu tetikle (Animator panelindeki trigger adýn neyse onu yaz)
            anim.SetTrigger("isJumping");
        }
        yerdemi=false;
    }
}


