using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public float force_move = 50;
    public float jumpVelocity = 10;
    private Animator anim;
    private bool isGround = false;
    public bool isWall = false; // whether is on the wall
    private bool isSlide = false;
    public bool mode = false;

    private Transform wallTrans;

    public float StartTime;
    public float CountTime = 90;
    private float TimeRemain;
    public float position;
    public float lastPosition;

    public float TotalScore;
    public static PlayerMove instances;

    public Text TimeText;
    public Text ScoreText;
    public Text GameOverText;
    public Text GameScoreText;

    void Awake() {
        anim = this.GetComponent<Animator>();
        instances = this;
    }

    public void AddScore(float score)
    {
        TotalScore += score;
        ScoreText.text = TotalScore.ToString(); // display
    }

    private void FixedUpdate()
    {
        TimeRemain = CountTime - (Time.time - StartTime);
        TimeText.text = FormatTime(TimeRemain);
        if (TimeRemain <= 0)
        {
            Destroy(this.gameObject);
            GameOverText.text = TextGameOver();
            GameScoreText.text = "Your Score: " + ScoreText.text;
        }
    }

    private string TextGameOver()
    {
        return "Game Over!";
    }

    private string FormatTime(float time)
    {
        string timeStr;
        int timeFormat = (int)time;
        if (time >= 0)
        {
            timeStr = time > 10 ? "00:" + timeFormat.ToString() : "00:0" + timeFormat.ToString();
        }
        else
        {
            timeStr = "00:00";
        }
        return timeStr;
    }

    // Update is called once per frame
    void Update () {

        position = transform.position.y;
        if(position == lastPosition){
            isSlide = false;
        }
        else{
            lastPosition = position;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mode = true;
        }

        float h = Input.GetAxis("Horizontal");

        if(this.transform.position.y < -8f || this.transform.position.y > 35f) {
            Destroy(this.gameObject);
            GameOverText.text = TextGameOver();
            GameScoreText.text = "Your Score: " + ScoreText.text;
        }
        if (isSlide == false) {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

            if (h > 0.05f) {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * force_move);
            } else if (h < -0.05f) {
                GetComponent<Rigidbody2D>().AddForce(-Vector2.right * force_move);
            }

            // change the direction
            if (h > 0.05f) {// the right
                transform.localScale = new Vector3(1, 1, 1);
            } else if (h < -0.05f) {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            anim.SetFloat("horizontal", Mathf.Abs(h));

            if (isGround && Input.GetKeyDown(KeyCode.Space)) {
                // jump
                velocity.y = jumpVelocity;
                GetComponent<Rigidbody2D>().velocity = velocity;
                if (isWall) {
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                }
            }

            anim.SetFloat("vertical", GetComponent<Rigidbody2D>().velocity.y);
        } else {
            // slip on the wall

        }

        if (isWall == false || isGround == true) {
            isSlide = false;
        }
	}

    public void OnCollisionEnter2D(Collision2D col ) {
        if (col.collider.tag == "Ground") {
            isGround = true;
            GetComponent<Rigidbody2D>().gravityScale = 30;
        }
        if (col.collider.tag == "Wall") {
            isWall = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 5;
            wallTrans = col.collider.transform;
            if (mode == true)
            {
                GetComponent<ChuckSubInstance>().RunCode(@"
                Wurley voc=> JCRev r => dac;

                // initial settings
                220.0 => voc.freq;
                0.95 => voc.gain;
                .8 => r.gain;
                .1 => r.mix;

                // scale
                [ 0, 3, 7, 8, 11 ] @=> int scale[];
                // scale
                scale[Math.random2(0,scale.cap()-1)] => int freq;
                Std.mtof( ( 45 + Math.random2(0,1) * 12 + freq ) ) => voc.freq;
                Math.random2f( 0.6, 0.8 ) => voc.noteOn;
                // 500::ms => now;
                250::ms => now;
                ");
            }
        }
        anim.SetBool("isGround", isGround);
        anim.SetBool("isWall", isWall);
    }
    public void OnCollisionExit2D(Collision2D col) {
        if (col.collider.tag == "Ground") {
            isGround = false;
        }
        if (col.collider.tag == "Wall") {
            isWall = false;
            GetComponent<Rigidbody2D>().gravityScale = 30;
        }
        anim.SetBool("isGround", isGround);
        anim.SetBool("isWall", isWall);
    }
    // change the direction
    public void ChangeDir() {
        isSlide = true;
        if (wallTrans.position.x < transform.position.x) {
            transform.localScale = new Vector3(1, 1, 1);
        } else {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
