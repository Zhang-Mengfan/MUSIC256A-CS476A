using UnityEngine;
using System.Collections;
using System.Threading;

public class Award : MonoBehaviour {

    public float speed = 500;
    public bool mode = false;

	void Update () {
        transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.M)){
            mode = true;
        }
	}

    public void OnTriggerEnter2D( Collider2D col ) {
        if (col.tag == "Player" && mode == false)
        {
            PlayerMove.instances.AddScore(10);
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            120::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            // Math.random2f( 50, 60 ) => float pitch; 
            playNote( 64, Q );    
        ");
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            120::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            // Math.random2f( 50, 60 ) => float pitch; 
            playNote( 55, Q );    
        ");
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            120::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            // Math.random2f( 50, 60 ) => float pitch; 
            playNote( 60, Q );    
        ");
            Thread.Sleep(120);
            Destroy(this.gameObject);
        }
        else
        {
            if (col.tag == "Player" && mode == true){
                PlayerMove.instances.AddScore(10);
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
                120::ms => now;
                ");
                Thread.Sleep(120);
                Destroy(this.gameObject);
            }
        }
    }
}
