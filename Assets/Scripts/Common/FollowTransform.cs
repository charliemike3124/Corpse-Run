using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform objectToFollow;
    public bool[] position = new bool[3];
    public bool[] rotation = new bool[3];

    public float[] positionOffset = new float[3];
    public float[] rotationOffset = new float[3];

    // Update is called once per frame
    void Update()
    {
        float posx = position[0] ? objectToFollow.position.x + positionOffset[0] : transform.position.x;
        float posy = position[1] ? objectToFollow.position.y + positionOffset[1] : transform.position.y;
        float posz = position[2] ? objectToFollow.position.z + positionOffset[2] : transform.position.z;
        Vector3 pos = new Vector3(posx, posy, posz); 
        transform.position = pos;

        float rotx = rotation[0] ? objectToFollow.localEulerAngles.x + rotationOffset[0] : transform.localRotation.x;
        float roty = rotation[1] ? objectToFollow.localEulerAngles.y + rotationOffset[1] : transform.localRotation.y;
        float rotz = rotation[2] ? objectToFollow.localEulerAngles.z + rotationOffset[2] : transform.localRotation.z;
        Vector3 rot = new Vector3(rotx, roty, rotz);
        transform.rotation = Quaternion.Euler(rot);
    }
}
