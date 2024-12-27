using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private int digAmount;
    private int initialDigAmount;


   void Start()
    {
        initialDigAmount = digAmount;
    }

    public void onHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount /2)
        {
            spriteRender.sprite = hole;

        }

       /* if (digAmount <= 0 )
        {
            spriteRender.sprite = carrot;
        }
       */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Dig"))
        {
            onHit();
        }

    }
}
