using UnityEngine;

public class BodyType : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum TypeBody
    {
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Head
    }

    public TypeBody BodyPart;
}
