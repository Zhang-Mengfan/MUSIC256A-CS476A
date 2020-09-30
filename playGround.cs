using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playGround : MonoBehaviour {

    public int real_count = 0;
    public int count = 0;
    public int count_total = 42;
    public int count_mode = 1;
    public bool voice = false;
    public bool mode = false;
    public Text ModeChange;

    // Use this for initialization
    void Start () {

    }

// Update is called once per frame
void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            real_count = 0;
            ModeChange.text = "Mode Changed!!";
            GetComponent<ChuckSubInstance>().RunCode(@"
                SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
                .2 => r.mix;
                500 => lpf.freq;
                e.set( 20::ms, 10::ms, .25, 20::ms );
                440 => foo.freq;
                1000::ms => dur Q;
                playNote( 70, Q );
                fun void playNote( float pitch, dur T)
                {
                    pitch => Std.mtof => foo.freq;
                    e.keyOn();
                    T - e.releaseTime() => now;
                    e.keyOff();
                }
                ");
            mode = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            real_count++;
            count = real_count - real_count / count_total * count_total;
            voice = true;
        }

        // jump
        if ((count == 1 || count == 2 || count == 29 || count == 30) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            60 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 3 || count == 4 || count == 31 || count == 32) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            67 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 5 || count == 6 || count == 33 || count == 34) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            69 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 7 || count == 35) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            400::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            67 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 8 || count == 9 || count == 36 || count == 37) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            65 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 10 || count == 11 || count == 38 || count == 39) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            64 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 12 || count == 13 || count == 40 || count == 41) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            62 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 14 || count == 0) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            400::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            60 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 15 || count == 16 || count == 22 || count == 23) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            67 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 17 || count == 18 || count == 24 || count == 25) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            65 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 19 || count == 20 || count == 26 || count == 27) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            200::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            64 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if ((count == 21 || count == 28) && voice == true && mode == false)
        {
            GetComponent<ChuckSubInstance>().RunCode(@"
            SqrOsc foo => LPF lpf => ADSR e => NRev r => dac;
            .1 => r.mix;
            500 => lpf.freq;
            e.set( 20::ms, 10::ms, .25, 20::ms );
            440 => foo.freq;
            400::ms => dur Q;  
            fun void playNote( float pitch, dur T)
            {
                pitch => Std.mtof => foo.freq;
                e.keyOn();
                T - e.releaseTime() => now;
                e.keyOff();
            }
            62 => float pitch; 
            playNote( pitch, Q );    
        ");
            voice = false;
        }

        if(mode == true && voice == true && real_count == count_mode)
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
            for( ; i < pick; i++ )
                {
                    Math.random2f(.4,.6) + i*.035 => pluck;
                    pluck + 0.03 * (i * pick_dir) => voc.noteOn;
                    !pick_dir => pick_dir;
                    250::ms => now;
                }
         ");
            voice = false;
            count_mode++;
        }

    }

}
