using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    public static int coinsCount = 0;

    //El start se inicia para cada game objet, no solo 1 por prefab
    void Start()
    {
        
         Coin.coinsCount++;
         Debug.Log("El juego ha comenzado y ahora hay "+Coin.coinsCount+ " monedas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
     * Metodo siguiente hace trigger al entrar en tontacto 
     */
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Coin.coinsCount--;
            Debug.Log("Hemos recogido la moneda y ahora quedan "+Coin.coinsCount+" monedas");

            if (Coin.coinsCount == 0)
            {
                Debug.Log("El juego ha terminado");

                GameObject gameManager = GameObject.Find("GameManager");

                Destroy(gameManager);
                GameObject[] fireworksSystem = GameObject.FindGameObjectsWithTag("Firework");

                foreach(GameObject firework in fireworksSystem)
                {
                    firework.GetComponent<ParticleSystem>().Play();
                }

            }
            Destroy(gameObject); //destruye el objeto

        }
    }




}
