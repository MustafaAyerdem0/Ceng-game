using UnityEngine;
using PathCreation;


public class AiController : MonoBehaviour
{
    public PathCreator pathCreator;

    public float speed = 5;
    float distanceTravelled;
    void Update()
    {
        if (GameManager.instance.startGame)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Quaternion.Euler(pathCreator.path.GetRotationAtDistance(distanceTravelled).eulerAngles.x, pathCreator.path.GetRotationAtDistance(distanceTravelled).eulerAngles.y, 0f);
        }

    }
}