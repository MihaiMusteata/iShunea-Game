using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamEnemies : MonoBehaviour
{
    // Start is called before the first frame update
   // GameObject gameObject;
    /* void Start()
    {
        //gameObject = GameObject.FindGameObjectWithTag("SpamPlane");
    } */
   /*  private void OnCollisionEnter(Collision other) {
            Debug.Log("SpamPlane(1)");

        if (other.gameObject.CompareTag("SpamPlane"))
        {
            Debug.Log("SpamPlane");
             // Găsim toate obiectele cu eticheta "Bot" din scenă
        GameObject[] bots = GameObject.FindGameObjectsWithTag("bot");

        // Inițializăm variabila pentru a ține cel mai apropiat bot
        GameObject nearestBot = null;
        float nearestDistance = float.MaxValue;

        // Iterăm prin toate obiectele "Bot" găsite
        foreach (GameObject bot in bots)
        {
            // Calculăm distanța dintre obiectul curent și bot
            float distance = Vector3.Distance(transform.position, bot.transform.position);

            // Verificăm dacă acesta este cel mai apropiat bot până acum
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestBot = bot;
            }
        }

        // Verificăm dacă am găsit cel mai apropiat bot
        if (nearestBot != null)
        {
            // Aici poți activa cel mai apropiat bot sau să faci orice altă acțiune dorită.
            nearestBot.SetActive(true);
        }
        }
    } */
    private CharacterController characterController;
    private List<GameObject> bots;
    //private GameObject[] bots;
    private void Awake() {
        bots = new List<GameObject>(GameObject.FindGameObjectsWithTag("bot"));
        foreach (GameObject bot in bots)
        {
            bot.SetActive(false);
        }
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verificăm coliziunile manual în fiecare cadru
        CheckCollisions();
    }

    void CheckCollisions()
    {
        // Obținem extremitățile Character Controller-ului
        Vector3 bottom = transform.position - characterController.height / 2 * Vector3.up;
        Vector3 top = transform.position + characterController.height / 2 * Vector3.up;

        // Verificăm coliziunile cu obiectele care au tag-ul "SpamPlane"
        Collider[] hitColliders = Physics.OverlapCapsule(bottom, top, characterController.radius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("SpamPlane"))
            {
                Debug.Log("SpamPlane");

                // Găsim toate obiectele cu eticheta "Bot" din scenă
                //GameObject[] bots = GameObject.FindGameObjectsWithTag("bot");
                //List<GameObject> bots = new List<GameObject>(GameObject.FindGameObjectsWithTag("bot"));
                // Inițializăm variabila pentru a ține cel mai apropiat bot
                GameObject nearestBot = null;
                float nearestDistance = 10;
                int nr = 0;
                // Iterăm prin toate obiectele "Bot" găsite
                foreach (GameObject bot in bots)
                {
                    nr++;
                    // Calculăm distanța dintre obiectul curent și bot
                    float distance = Vector3.Distance(transform.position, bot.transform.position);
                    
                    // Verificăm dacă acesta este cel mai apropiat bot până acum
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestBot = bot;
                    }
                }
                Debug.Log("Boti: "+nr);
                
                // Verificăm dacă am găsit cel mai apropiat bot și îl activăm
                if (nearestBot != null)
                {
                    nearestBot.SetActive(true);
                }
            }

        }
    }

    // Update is called once per frame
   /*  void Update()
    {
        
    } */
}
