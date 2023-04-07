using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class speedBoost : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [SerializeField] protected float new_speed;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            var last_pre = other.transform.GetComponent<InputMover>().speed;
            if (destroyComponent) {
                other.transform.GetComponent<InputMover>().speed=new_speed;
                destroyComponent.StartCoroutine(ShieldTemporarily(other, last_pre));        // co-routines
                    // NOTE: If you just call "StartCoroutine", then it will not work, 
                    //       since the present object is destroyed!
                // ShieldTemporarily(destroyComponent);                                      // async-await
                Destroy(gameObject);  // Destroy the objecy itself - prevent double-use
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }

    private IEnumerator ShieldTemporarily(Collider2D destroyComponent,float pre ) {   // co-routines
        
        for (float i = duration; i > 0; i--) {

                  Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
        }
        destroyComponent.transform.GetComponent<InputMover>().speed=pre;
    }
}
