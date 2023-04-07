using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] int pointsToAdd;
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag2;
    [SerializeField] int pointsToAdd2;
    [SerializeField] NumberField scoreField;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (scoreField != null)
        {
            if (other.tag == triggeringTag)
            {
                scoreField.AddNumber(pointsToAdd);
            }
            else if (other.tag == triggeringTag2)
            {
                scoreField.AddNumber(pointsToAdd2);
            }
        }
    }

    public void SetScoreField(NumberField newTextField)
    {
        this.scoreField = newTextField;
    }
}
