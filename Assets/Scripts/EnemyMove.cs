using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
   public GameObject player;
   private UnityEngine.AI.NavMeshAgent navMesh;
   private bool _canAttack;
   public AudioSource warningEffect;
   Animator anim;

   void Start()
    {
        _canAttack = true;
        player = GameObject.FindWithTag ("Player");
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void Pursuit()
    {
        if (_canAttack == true)
        {
            navMesh.destination = player.transform.position;
        }
        if (player.GetComponent<HealthPlayer>().life <= 0)
        {
            navMesh.enabled = false;
            _canAttack = false;
        }                
    }
    public void AttackPlayer()
    {
       if (Vector3.Distance (transform.position, player.transform.position) < 2 && (_canAttack == true)){
           anim.SetBool ("Attack", true);
           StartCoroutine ("TimeToAttack");  
            StartCoroutine ("TimeToPursuit");  
           player.GetComponent<HealthPlayer>().life -= 50;
           navMesh.enabled = false;
       }
       else 
       {           
         anim.SetBool ("Attack", false);
        anim.SetBool ("Idle", true);
       }
    }
     private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            warningEffect.Play();
        }
    } 
     IEnumerator TimeToAttack()
    {
        _canAttack = false;
        yield return new WaitForSeconds(10);
        _canAttack = true;
    }
    IEnumerator TimeToPursuit()
    {               
        navMesh.enabled = false;
        yield return new WaitForSeconds(10);
        navMesh.enabled = true;        
    }
    void Update()
    {
       Pursuit();
       AttackPlayer();              
    }
    
}
