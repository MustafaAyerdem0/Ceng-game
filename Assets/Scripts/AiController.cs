using UnityEngine;
using PathCreation;


public class AiController : MonoBehaviour
{
    public PathCreator pathCreator;

    public float speed;
    float distanceTravelled;
    bool isFinish;

    void Start(){
        speed= MenuManager.instance.difficult;
    }
    void Update()
    {
        if (GameManager.instance.startGame && !isFinish)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Quaternion.Euler(pathCreator.path.GetRotationAtDistance(distanceTravelled).eulerAngles.x, pathCreator.path.GetRotationAtDistance(distanceTravelled).eulerAngles.y, 0f);
        }

        

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("FinishLine"))
        {
            GameManager.instance.PlayerPosition = 2;
            isFinish=true;
        }
    }
}