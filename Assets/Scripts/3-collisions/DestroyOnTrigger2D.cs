using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [Tooltip("do you want to also destroy the object that you touch?")]
    [SerializeField] bool both;
    [SerializeField] bool not_self;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled && not_self) {
            Destroy(other.gameObject);
        }
        else if (other.tag == triggeringTag && enabled && both) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        else if(other.tag == triggeringTag && enabled && !both) {
            Destroy(this.gameObject);
        } 
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
