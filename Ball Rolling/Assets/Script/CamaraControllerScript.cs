using UnityEngine;

public class CamaraControllerScript : MonoBehaviour 
{
    // making GameObject Field variable for store playerGamerObject Component data
    public GameObject player;

   
    public GameObject music;

    // we want store playerGameObject transform component data so we create Vector3 struct instance
    //format: acessModifier strcut structInstanceName; 
    private Vector3 offsetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        //storing offset value relative to player position
        //example: offset(0,9.9f,10) = this.ObjectTransform.Positon(0,10,10) - player.Transform.Position(0,0.1f,0);
        offsetPos = transform.position - player.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {   //changing thisGameObject Transform.Position component value by fixing its position relative to playerGameObject.transform.position component value + offset value;
        //format: this.transformComponentValue.positionValue = GameObject.transformComponentValue.PositionValue + Offset Value;
        transform.position = player.transform.position + offsetPos;
    }
}
