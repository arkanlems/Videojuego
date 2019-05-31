using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public float motionSpeed;
    public int CornPoints;
    public float jumpForce;
    public bool jumpOnce = false;
    public int lifePoints = 3;
    // Start is called before the first frame update
    public void tapOnButtonJump()
    {

        if (!jumpOnce){
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            this.gameObject.GetComponent<Animator>().SetBool("Jump", true);

            jumpOnce = true;
        }
    }
    public void tapOnLeftJump()
    {
        if (!jumpOnce)
        {

            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * (motionSpeed *30), ForceMode2D.Impulse);

            this.gameObject.GetComponent<Animator>().SetBool("Jump", true);
            jumpOnce = true;
        }
    }
    public void tapOnRightJump()
    {
        if (!jumpOnce)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * (motionSpeed * 30), ForceMode2D.Impulse);

            this.gameObject.GetComponent<Animator>().SetBool("Jump", true);
            jumpOnce = true;
        }
    }

    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Corn")
        {
            Destroy(col.gameObject);
            CornPoints++;

            GameObject.Find("Canvas/ScreenGame/TextCorn").GetComponent<Text>().text = "Corn " + CornPoints.ToString();


        }
        if (col.gameObject.tag == "NextLevel")
        {
            Destroy(col.gameObject);
            transform.position = new Vector3(-402.4f, -6.5f, 0);


        }
        if (col.gameObject.tag == "Final")
        {
            Destroy(col.gameObject);
            //Destroy(this.gameObject);
            Destroy(GetComponent<Rigidbody2D>());

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        Vector3 contactPoint = col.contacts[0].point;
        Vector3 center = collider.bounds.center;
        float rectWidth = gameObject.GetComponent<Collider2D>().bounds.size.x;
        float rectHeight = gameObject.GetComponent<Collider2D>().bounds.size.y;
        if (col.gameObject.tag == "Zombie" && contactPoint.y > center.y &&
            (contactPoint.x < center.x + rectWidth / 2 && contactPoint.x > center.x - rectWidth / 2))
        {
            Destroy(col.gameObject);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * 0.5f, ForceMode2D.Impulse);
        }
        else if (col.gameObject.tag == "Zombie" && contactPoint.x > center.x)
        {
            lifePoints--;
            GameObject.Find("Canvas/ScreenGame/TextLifes").GetComponent<Text>().text = "Lifes " + lifePoints.ToString();
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForce * 0.5f, ForceMode2D.Impulse);
        }
        else if (col.gameObject.tag == "Zombie" && contactPoint.x < center.x)
        {
            lifePoints--;
            GameObject.Find("Canvas/ScreenGame/TextLifes").GetComponent<Text>().text = "Lifes " + lifePoints.ToString();
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * jumpForce * 0.5f, ForceMode2D.Impulse);
        }
        if (col.gameObject.tag == "Floor" && contactPoint.y > center.y)
        {
            jumpOnce = false;
            this.gameObject.GetComponent<Animator>().SetBool("Jump", false);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoints <=0)
        {
            string scene = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * motionSpeed);

            this.gameObject.GetComponent<Animator>().SetBool("Idle", false);
            this.gameObject.GetComponent<Animator>().SetBool("Run",true);

            this.gameObject.GetComponent<SpriteRenderer>().flipX=false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x> -404.75f )
        {
            this.transform.Translate(Vector3.left * motionSpeed);

            this.gameObject.GetComponent<Animator>().SetBool("Idle", false);
            this.gameObject.GetComponent<Animator>().SetBool("Run", true);

            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& !jumpOnce)
        {
            jumpOnce = true;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            this.gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Idle", true);
            this.gameObject.GetComponent<Animator>().SetBool("Run", false);
        }
        if(this.transform.position.y< -16.96f)
        {
            lifePoints--;
            GameObject.Find("Canvas/ScreenGame/TextLifes").GetComponent<Text>().text = "Lifes " + lifePoints.ToString();
            transform.position = new Vector3(-402.4f,-6.5f,0);
        }
        

    }
    
}
