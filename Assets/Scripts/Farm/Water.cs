using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if(collision.CompareTag("Player"))
        { 
            detectingPlayer = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
