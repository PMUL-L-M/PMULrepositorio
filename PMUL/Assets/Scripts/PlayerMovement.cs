using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 5;
    private Animator anim;
    private bool moving; //Determinará si el personaje se mueve o no.
    private Vector2 lastMove; //Indicará cuál es la dirección en que se ha parado el personaje al dejar de moverse.
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>(); //Se obtiene una referencia al componente Animator del player.
	}
	
	// Update is called once per frame
	void Update () {
        //Al inicio de cada Update moving será false. Este valor se actualizará con cada Update.
        moving = false; 
        //Si el personaje se mueve a derecha o izquierda se multiplica su posición por la velocidad y el deltaTime en el eje x.
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            this.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            moving = true; 
            //Se guarda cuál es la última posición del jugador en el eje x del Vector2 lastMove.
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); 
        }
        //Si el personaje se mueve arriba o abajo se multiplica su posición en el eje y por la velocidad y el deltaTime.
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            this.transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            moving = true;
            //Se guarda la última posición del jugador en el eje Vertical (es decir, si se queda arriba o abajo).
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Moving", moving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
