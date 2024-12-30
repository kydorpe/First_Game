 using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject Wood;
    [SerializeField] private int totalWood;

    [SerializeField] private ParticleSystem leafs;
    private bool isCut;


    public void onHit()
    {
        treeHealth--;
        anim.SetTrigger("isHit");
        leafs.Play();

        if (treeHealth <= 0 )
        {

            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(Wood,transform.position + new Vector3 (Random.Range(-0.8f,0.8f),Random.Range(-0.8f, 0.8f), 0f) ,transform.rotation);
            }

            anim.SetTrigger("cut");
            isCut = true;
            
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if(collision.CompareTag("Axe") && !isCut)
        {
            onHit();
        }

    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
