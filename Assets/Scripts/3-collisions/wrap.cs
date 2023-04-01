using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class wrap : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string up_wall;
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string down_wall;
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string left_wall;
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string right_wall;
    [Tooltip("do you want to also destroy the object that you touch?")]

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Get the position of the left and right edges of the game window in world coordinates
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f));

        // Calculate the width of the world
        float worldWidth = Vector3.Distance(leftEdge, rightEdge);
        // Get the position of the top and bottom edges of the game window in world coordinates
        Vector3 topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f));
        Vector3 bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f));

        // Calculate the height of the world
        float worldHeight = Vector3.Distance(topEdge, bottomEdge);


        if (other.tag == up_wall && enabled)
        {
            float newPosY = GetComponent<Collider2D>().transform.position.y - worldHeight;
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
        if (other.tag == down_wall && enabled)
        {
            float newPosY = GetComponent<Collider2D>().transform.position.y + worldHeight;
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
        if (other.tag == right_wall && enabled)
        {
            float newPosX = GetComponent<Collider2D>().transform.position.x - worldWidth;
            transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
        }
        if (other.tag == left_wall && enabled)
        {
            float newPosX = GetComponent<Collider2D>().transform.position.x + worldWidth;
            transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
