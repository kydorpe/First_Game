using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;

    private void Start()
    {
        
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed*Time.deltaTime);
        }
    }
}
