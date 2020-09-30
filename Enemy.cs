using UnityEngine;
using System.Collections;
using System.Threading;

public class Enemy : MonoBehaviour {

    private Transform player;
    public float attackDistance = 25;
    private Animator anim;
    public float speed = 5;
    public float deadDistance = 4;
    public bool playChuck = false;
    public int beat_time = 0;
    public bool mode = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = this.GetComponent<Animator>();
    }


	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mode = true;
        }

        float distance = Vector3.Distance( player.position,transform.position);
        if(distance < deadDistance){
            beat_time++;
        }
        if (beat_time == 8 && mode == true)
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
            0 => int i;
            2 * Math.random2( 1, 3 ) => int pick;
            0 => int pick_dir;
            0.0 => float pluck;
            repeat( 100 )
            {
                voc.freq() * 1.01 => voc.freq;
                10::ms => now;
            }
         ");
            Thread.Sleep(1000);
            Destroy(this.gameObject);
        }
          
        if (distance < attackDistance) {
            // attack
            anim.SetBool("Run", true);
            if (player.position.x < transform.position.x) {
                transform.localScale = new Vector3(-1, 1, 1);
            } else {
                transform.localScale = new Vector3(1, 1, 1);
            }
            Vector3 dir = player.position - transform.position;
            transform.position = dir.normalized * speed * Time.deltaTime + transform.position;
        } else {
            // sleep
            anim.SetBool("Run", false);
        }
	}

}
