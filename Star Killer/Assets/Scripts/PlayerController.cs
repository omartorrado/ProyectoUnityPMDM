using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private Transform trans;
    public Vector3 cameraPosition;
    public Camera main;
    public GameObject laserShot;
    public Transform laserSpawn;
    public Transform laserSpawn2;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	trans = GetComponent<Transform>();

    }

    void Update(){
	if (Input.GetKeyDown(KeyCode.Space)){
		Fire();
	}
    }

    void FixedUpdate ()
    {
	cameraPosition=main.transform.position;
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        //float moveHorizontal = Input.acceleration.x;
        //float moveVertical = Input.acceleration.y;

        Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
        //print("Camara Y:"+main.transform.position.y);
	//print("Camara X:"+main.transform.position.x);
	//print("Nave X:"+trans.position.x);
	//print("Nave Y:"+trans.position.y);
//Limitamos el movimiento en los ejes X/Y para que no salga de la zona de la camara
	if(trans.position.y<=(main.transform.position.y+13.3f) && trans.position.y>=(main.transform.position.y-13.3f) && trans.position.x<=(main.transform.position.x+31.5f) && trans.position.x>=(main.transform.position.x-31.5f)){
	        rb.velocity = (movement * speed);		
	}else if (trans.position.y>(main.transform.position.y+13.3f)){
		rb.transform.position += new Vector3(0.0f,-0.5f,0.0f);
	}else if (trans.position.y<(main.transform.position.y-13.3f)){
		rb.transform.position += new Vector3(0.0f,+0.5f,0.0f);
	}
//Establecemos el boton de disparo
	
    }

    void Fire(){
	var shot = (GameObject) Instantiate (laserShot,laserSpawn.position, new Quaternion(0f,0f,0f,0f));
	shot.GetComponent<Rigidbody>().velocity = new Vector3(0f,50f,0f);
	var shot2 = (GameObject) Instantiate (laserShot,laserSpawn2.position, new Quaternion(0f,0f,0f,0f));
	shot2.GetComponent<Rigidbody>().velocity = new Vector3(0f,50f,0f);
	Destroy(shot,3.0f);	
	Destroy(shot2,3.0f);
    }
}
