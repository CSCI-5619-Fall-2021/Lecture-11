using UnityEngine;
using UnityEngine.UI;

public class SwingAngle : MonoBehaviour
{
    public Text angleText;

    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the velocity
        Vector3 velocity = (this.transform.position - lastPosition) / Time.deltaTime;
        lastPosition = this.transform.position;

        // if the sword is moving above some threshold
        if (velocity.magnitude > 2)
        {
            // reduce to a 2D vector and normalize
            velocity.z = 0;
            velocity.Normalize();

            // calculate the angle between the vectors in radians
            float dotProduct = Vector3.Dot(Vector3.up, velocity);
            float swingAngle = Mathf.Acos(dotProduct);

            // acos returns an angle between 0 and 180
            // if the swing is moving to the left, then negate it
            if (velocity.x < 0)
            {
                swingAngle *= -1.0f;
            }

            // update the text to display the angle
            angleText.text = "" + (swingAngle * 180 / Mathf.PI);
        }
        
    }
}
