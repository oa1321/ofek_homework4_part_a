using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var x = other.transform.Find("Circle");
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<goto_lose_on_colide>();
            Renderer circleRenderer = x.GetComponent<Renderer>();
            if (destroyComponent)
            {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent, circleRenderer));
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        }
        else
        {
            Debug.Log("Shield triggered by  " + other.name);
        }
    }

    private IEnumerator ShieldTemporarily(goto_lose_on_colide destroyComponent, Renderer c)
    {   // co-routines
        // private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {      // async-await
        Color currentColor = c.material.color;
        destroyComponent.enabled = false;

        for (float i = duration; i > 0; i--)
        {


            // await Task.Delay(1000);                // async-await
            // Create a new color with the desired alpha value
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f * (i / duration));
            c.enabled = true;
            // Set the material color property of the Renderer component to the new color
            c.material.color = newColor;
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
        }
        Debug.Log("Shield gone!");
        c.enabled = false;
        Color resetColor = new Color(currentColor.r, currentColor.g, currentColor.b, 200);

        // Set the material color property of the Renderer component to the new color
        c.material.color = resetColor;
        destroyComponent.enabled = true;
    }
}
