using UnityEngine;

// Parkur içindeki kayýt noktalarýný yönetiyor, oyuncu bu nesnelere temas ettiðinde doðma noktasýný güncelliyoruz.
public class CoinManager : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealtController health =other.GetComponent<HealtController>();
            if (health != null)
            {
                // Oyuncunun saðlýk kontrolcüsüne ulaþýp, öldüðünde yeniden doðacaðý konumu bu kayýt noktasýnýn koordinatlarý ile deðiþtiriyoruz.
                health.SetCehckpoint(transform.position);

                // Kayýt iþleminin baþarýlý olduðunu oyuncuya hissettirmek için ilgili ses efektini tetikliyoruz.
                SoundManager soundManager = FindAnyObjectByType<SoundManager>();
                if (soundManager != null)
                {
                    soundManager.CheckPointCal();
                }
                // Nesnenin bir daha tetiklenmemesi ve ekranda kalabalýk yapmamasý için görselini ve fiziksel algýlayýcýsýný kapatýyoruz.
                MeshRenderer mr = GetComponent<MeshRenderer>();
                if (mr != null) mr.enabled = false;

                Collider col = GetComponent<Collider>();
                if (col != null) col.enabled = false;

                Destroy(gameObject, 1f);
            }
           
        }
    }
}
