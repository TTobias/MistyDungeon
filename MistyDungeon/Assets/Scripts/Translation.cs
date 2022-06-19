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


    public static string[][][] cutsceneText = {
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
                "Du bist ein Agent der für das Ministerium zur Bekämpfung von Monstern arbeitet. Vor drei Wochen ist auf einmal ein dunkler Nebel über die Welt gebrochen, der alles verdunkelt. Bei deinen Ermittlungen hast du deinen Teamleader erspäht und bist diesem aus Neugier gefolgt. Am Rande einer Höhle verlierst du ihn aus den Augen. Nachdem du die Umgebung gescheckt hast entschließt du dich die Höhle zu erforschen. Welche Geheimnisse dich wohl erwarten werden?",
                "Du bist ein Agent der für das Ministerium zur Bekämpfung von Monstern arbeitet. Vor drei Wochen ist auf einmal ein dunkler Nebel über die Welt gebrochen, der alles verdunkelt. Bei deinen Ermittlungen hast du deinen Teamleader erspäht und bist diesem aus Neugier gefolgt. Am Rande einer Höhle verlierst du ihn aus den Augen. Nachdem du die Umgebung gescheckt hast entschließt du dich die Höhle zu erforschen. Bevor du sie jedoch betritts schreibst du noch deinem Kollegen eine Nachricht, der nach wenigen Minuten eintrifft. Welche Geheimnisse euch wohl erwarten werden?"
            },
            //depth 1
            new string[] {
                "Seite eines Notizbuch eines Mitarbeiters. Die Higher Ups werden immer verrückter. Ich kann nicht glauben, dass sie das wirklich vorhaben. Ich muss versuchen sie aufzuhalten. Vlt kann *****(unleserlicher Name) mir helfen. Ja ich werde ihm einen anonymen Brief schreiben und ihn um Hilfe bitten. Villeicht kann er sogar ein gutes Wort beim MBM für mich einlegen.\n Gezeichnet Zera, 19.08.100. Beim lesen fallen dir einige Dinge auf: Dieser Eintrag ist mittlerweile ungefähr 4 Wochen alt und deine Organistation das Ministerium zur Bekämpfung von Monstern(MBM) wird erwähnt. Außerdem scheint dieser Eintrag von einem Menschen zu stammen, bisher sind dir jedoch nur Skelette begegnet?",
                "Seite eines Notizbuch eines Mitarbeiters. Die Higher Ups werden immer verrückter. Ich kann nicht glauben, dass sie das wirklich vorhaben. Ich muss versuchen sie aufzuhalten. Vlt kann *****(unleserlicher Name) mir helfen. Ja ich werde ihm einen anonymen Brief schreiben und ihn um Hilfe bitten. Villeicht kann er sogar ein gutes Wort beim MBM für mich einlegen.\n Gezeichnet Zera, 19.08.100. Beim lesen fallen euch einige Dinge auf: Dieser Eintrag ist mittlerweile ungefähr 4 Wochen alt und deine Organistation das Ministerium zur Bekämpfung von Monstern(MBM) wird erwähnt. Außerdem scheint dieser Eintrag von einem Menschen zu stammen, bisher sind euch jedoch nur Skelette begegnet?"
            },
            //depth 2
            new string[] {
                "Eine weitere Seite aus Zeras Notizbuch: Er hat mir darin zugestimmt, das wir den Plan verhindern müssen, allerdings meinte er, dass er sich zuerst trefen will und ich die wichtigen Beweise mitbringen soll. Ich bin mir mittlerweile nicht mehr so sicher, ob er wirklich gegen die Organisation arbeiten wird, auch wenn er regelmäßig in Konflikte mit den Bosseb gerät. Könnte er mich in eine Falle locken?",
                "DEPTH 2 - GER - COOP"
            },
            //depth 3
            new string[] {
                "Zeras Notizbuch: Es war eine Falle. Gott sei dank, konnte ich entkommen, allerdings bleibt mir nur die Möglichkeit tiefer in die Höhlen hinabzusteigen. Die Beweise die ich an das MBM geschickt habe hat er wahrscheinlich ebenfalls bereits abgefangen. Das einzige was mir bleibt ist meine Notizen, in der Hoffnung, dass sie jemand Gutes findet, in der Höhle zu zerstreuen. Hoffentlich können sie dir helfen.",
                "DEPTH 3 - GER - COOP"
            },
        }
    };

    //UPGRADE TEXT
    public static string[][][] upgradeText = {
        //english
        new string[][] {
            new string[] { //0
                "Armor",
                "A piece of Armor that protects you from 1 Hit."
            },
            new string[] { //1
                "Extended View I",
                "Increases your extened view range by 1."
            },
            new string[] { //2
                "Extended View II",
                "Increases your extened view range by 1."
            },
            new string[] { //3
                "Extended View III",
                "Increases your extened view range by 1."
            },
            new string[] { //4
                "Extended View IV",
                "Increases your extened view range by 1."
            },
            new string[] { //5
                "View I",
                "Increases your clear view range by 1."
            },
            new string[] { //6
                "View II",
                "Increases your clear view range by 1."
            },
            new string[] { //7
                "View III",
                "Increases your clear view range by 1."
            }

        },
        //deutsch
        new string[][] {

        }
    };

    //MENU TEXT
    public static string[][] menuText = {
        //english
        new string[]{
            new string[] {
                "Start Game",
                "Start Coop Game"
            }

        },
        //deutsch
        new string[] {

        }
    };

    //OPTIONS TEXT

    //ITEM DESCRIPTION TEXT

    //ACHIEVEMENTS
}
