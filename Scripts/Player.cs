using System.Collections;
using UnityEngine;

/// <summary>
/// describe bird movements
/// </summary>
public class Player : MonoBehaviour
{
    #region -Variable- 
    
    //Audio
    
    [Header(" - Audio - ")]
    
    [SerializeField]
    private AudioSource audioFly;      //audio fly
    
    [SerializeField]              
    private AudioSource audioDied;     //audio die
    
    
    [SerializeField]
    private Animator animator;         //animation when bird died 
    
    private Rigidbody2D _rigidbody2D; 
    
    private float velocity = 5;        //velocity moving bird
     
    private bool _die;                 //check bird died
    
    private static readonly int End = Animator.StringToHash("end");

    #endregion//Variable
    
    
    void Start()
    {
        _rigidbody2D=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _die == false )
        {
            _rigidbody2D.velocity = Vector2.up * velocity;
            FlySound();
        }
    }

    #region Physics callback
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pipe"))
        {
            DeadSound();
            GameOver();
        }
        if (col.CompareTag("Pass"))
        {
            Score.score++;
        }
   
    }
    #endregion// Physics callback
   
    void GameOver() // game over bird 
    {
        transform.Rotate(0, 0, -45); // direct the bird's head towards the ground
        
        animator.SetTrigger(End);                   // pop up Banner GameOver 
        
        StartCoroutine(DamageFlashingAnimationWhenDead());       // Fx Flash Bird 
        
        _die = true;                                   // check bird die and frozen bird move
    }
    private void FlySound()
    {
        audioFly.Play();
    }
    private void DeadSound()
    {
        audioDied.Play();
    }
    
    private IEnumerator DamageFlashingAnimationWhenDead() //Fx flash bird
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        const int FLASH_COUNT = 3;
        for (int i = 0; i < FLASH_COUNT; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}