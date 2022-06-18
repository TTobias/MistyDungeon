using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Translation
{
    //Multilayer Arrays::
    //Layer 1 (Language): 0=english, 1=deutsch
    //Layer 2 (DepthLevel)
    //Layer 3 (Player): 0=single, 1=coop 

    public static int ENG = 0, GER = 1;


    public static string[][][] cutscenetext = {
        //english
        new string[][] {
            //depth 0 (intro)
            new string[] {
                "INTRO TEXT - ENG - SINGLE",
                "INTRO TEXT - ENG - COOP"
            },
            //depth 1
            new string[] {
                "DEPTH 1 - ENG - SINGLE",
                "DEPTH 1 - ENG - COOP"
            },
            //depth 2
            new string[] {
                "DEPTH 2 - ENG - SINGLE",
                "DEPTH 2 - ENG - COOP"
            },
            //depth 3
            new string[] {
                "DEPTH 3 - ENG - SINGLE",
                "DEPTH 3 - ENG - COOP"
            },
        },

        //deutsch
        new string[][] {
            //depth 0 (intro)
            new string[] {
                "INTRO TEXT - GER - SINGLE",
                "INTRO TEXT - GER - COOP"
            },
            //depth 1
            new string[] {
                "DEPTH 1 - GER - SINGLE",
                "DEPTH 1 - GER - COOP"
            },
            //depth 2
            new string[] {
                "DEPTH 2 - GER - SINGLE",
                "DEPTH 2 - GER - COOP"
            },
            //depth 3
            new string[] {
                "DEPTH 3 - GER - SINGLE",
                "DEPTH 3 - GER - COOP"
            },
        }
    };

    //MENU TEXT

    //OPTIONS TEXT

    //DESCRIPTION TEXT
}
