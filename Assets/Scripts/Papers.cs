using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Papers : MonoBehaviour
{
    
    public GameController gameController;
    public AudioSource scream;


    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerStay(Collider collider)
    {        
         if (collider.tag == "Player"){
            {              
                if (Input.GetKeyDown(KeyCode.E))
                {
                   gameObject.SetActive(false);
                   gameController.numberPapers += 1;
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (gameController.numberPapers == 3))
        {           
            Debug.Log("Teste");
            StartCoroutine ("ScreamGirl");
        }
    }
      IEnumerator ScreamGirl()
    {               
        yield return new WaitForSeconds(1);
        scream.Play();       
    }
}
