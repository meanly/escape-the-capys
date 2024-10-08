using UnityEngine;

public class CollisionControllerPractice : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //gives info  about the object we touch
    {
        if (collision.gameObject.name == "box")
        {
            Debug.Log("enter");
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //continues as long as the contact continues
    {
        if (collision.gameObject.name == "box")
        {
            Debug.Log("stay");
        }
    }
    private void OnCollisionExit2D(Collision2D collision) //runs once as soon as the collision ends
    {
        if (collision.gameObject.name == "box")
        {
            Debug.Log("exit");
        }
    }
}