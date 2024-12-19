 using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    public void onHit()
    {
        treeHealth--;
        anim.SetTrigger("isHit");
        if (treeHealth <= 0 )
        {
            anim.SetTrigger("cut");
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if(collision.CompareTag("Axe"))
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
