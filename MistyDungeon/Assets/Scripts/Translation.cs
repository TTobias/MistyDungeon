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
            //depth 0 (Tutorial)
            new string[] {
                "Tutorial: Move through the fog and look for the exit: Dagger: If you are standing next to an enemy and move onto a square next to the enemy you will kill them. Spear: When you move towards an enemy, you kill them. Vision Ability: Increases your vision range for 1 turn. Teleport: Teleports you to a location in Range. ManaShield: Protects you from damage",
                "Tutorial: Move through the fog and look for the exit: Dagger: If you are standing next to an enemy and move onto a square next to the enemy you will kill them. Spear: When you move towards an enemy, you kill them. Vision Ability: Increases your vision range for 1 turn. Teleport: Teleports you to a location in Range. ManaShield: Protects you from damage"
            },
            //depth 1 (intro)
            new string[] {
                "You are an Agent working for the Ministry for fighting Monsters. Three weeks ago an mysterious dark Mist appeared. While searching for the source of the mist you noticed your teamleader sneaking around and decided to follow him. You lose him in a forest. While looking around you notice an cave entrance. You decide to explor the cave. What mystery will await you?",
                "You are an Agent working for the Ministry for fighting Monsters. Three weeks ago an mysterious dark Mist appeared. While searching for the source of the mist you noticed your teamleader sneaking around and decided to follow him. You lose him in a forest. While looking around you notice an cave entrance. After calling your college, you decide to explor the cave together. What mystery will await you?"
            },
            //depth 2
            new string[] {
                "The Higher Ups are getting more and more crazy. This time they have gone to far. I need to stop them. Maybe ****(unreaadable name) can help me. He often criticeses the bosses. I will write him an anonymos letter and ask him for help. Maybe he can even say a good word in the MFFM for me. Signed Zera 19.08.100 While reading you notice some things: This entry is 4 weeks old and your Miniterium the MFFM is mentioned. In addition this entry seems to be made by a human, but you only encountered skeletons.",
                "The Higher Ups are getting more and more crazy. This time they have gone to far. I need to stop them. Maybe ****(unreaadable name) can help me. He often criticeses the bosses. I will write him an anonymos letter and ask him for help. Maybe he can even say a good word in the MFFM for me. Signed Zera 19.08.100 While reading you notice some things: This entry is 4 weeks old and your Miniterium the MFFM is mentioned. In addition this entry seems to be made by a human, but you only encountered skeletons."
            },
            //depth 3
            new string[] {
                "Another page from Zera's notebook: He agreed with me that we have to stop the plan, but he said he wants to meet first and that I should bring the important evidence with me. I'm no longer so sure if he will actually work against the organization, even if he regularly gets into trouble with the Higher Ups. Could he lure me into a trap?",
                "Another page from Zera's notebook: He agreed with me that we have to stop the plan, but he said he wants to meet first and that I should bring the important evidence with me. I'm no longer so sure if he will actually work against the organization, even if he regularly gets into trouble with the Higher Ups. Could he lure me into a trap?"
            },
            //depth 4
            new string[] {
                "Zera's notebook It was a trap. Thank God I was able to escape, but my only option is to go deeper inside the caves. He probably has already stopped the evidence I sent to the MBM. The only hope I have left is the hope that someone good will find my notes. If im still alive I hope we can meet. Signed Zera",
                "Zera's notebook It was a trap. Thank God I was able to escape, but my only option is to go deeper inside the caves. He probably has already stopped the evidence I sent to the MBM. The only hope I have left is the hope that someone good will find my notes. If im still alive I hope we can meet. Signed Zera"
            },
            //depth 5
            new string[] {
                "Altough you dont find any news note, you notice the area around you changing. More and more plants are growing and the human infleunce seems to lessen.",
                "Altough you dont find any news note, you notice the area around you changing. More and more plants are growing and the human infleunce seems to lessen."
            },
            //depth 6
            new string[] {
                "Encrypted message encoded according to a standard MBM code: It's good that you followed me, need quick help, meet me later at the exit and be careful when sniffing around. PS. I have already informed the ministry. PSS. It's best to stay on the upper levels for now. PSSS. Next time don't follow your superiors. Kind regards. Team leader Sebastian",
                "Encrypted message encoded according to a standard MBM code: It's good that you followed me, need quick help, meet me later at the exit and be careful when sniffing around. PS. I have already informed the ministry. PSS. It's best to stay on the upper levels for now. PSSS. Next time don't follow your superiors. Kind regards. Team leader Sebastian"
            },
            //depth 7
            new string[] {
                "Zera's Notebook: The plants that grow here do not appear to arise naturally. Has Ivy become so powerful that she passively influences her surroundings? I have to be more careful not to get noticed by her. The deeper I get, the more guards seem to be posted.",
                "Zera's Notebook: The plants that grow here do not appear to arise naturally. Has Ivy become so powerful that she passively influences her surroundings? I have to be more careful not to get noticed by her. The deeper I get, the more guards seem to be posted."
            },
            //depth 8
            new string[] {
                "...",
                "..."
            },
            //depth 9
            new string[] {
                "Zera's Notebook: I'm late. They actually dared to summon him. The fog is a clear sign of his arrival. I'm going to break into Ivy's office to figure out how to stop him. Maybe this is will be my last entry.",
                "Zera's Notebook: I'm late. They actually dared to summon him. The fog is a clear sign of his arrival. I'm going to break into Ivy's office to figure out how to stop him. Maybe this is will be my last entry."
            },
            //depth 10
            new string[] {
                "The plants seem to give way to more and more glowing crystals. And you feel the aura of a powerful being.",
                "The plants seem to give way to more and more glowing crystals. And you feel the aura of a powerful being."
            }
        },

        //deutsch
        new string[][] {
            //depth 0 (Tutorial)
            new string[] {
                "Tutorial: Bewege dich durch den Nebel und suche den Ausgang: Dagger: Wenn du neben einem Gegner stehst und dich auf ein Pfeld neben dem Gegner bewegst tötest du diesen. Speer: Wenn du dich auf einen Gegner zu bewegst, tötest du diesen. Sichtfähigkeit: Erhöht für einen Zug deine Sichtweite Teleport: Teleportiert dich an einen Ort in Range ManaShield: Beschützt dich vor Schaden",
                "Tutorial: Bewege dich durch den Nebel und suche den Ausgang: Dagger: Wenn du neben einem Gegner stehst und dich auf ein Pfeld neben dem Gegner bewegst tötest du diesen. Speer: Wenn du dich auf einen Gegner zu bewegst, tötest du diesen. Sichtfähigkeit: Erhöht für einen Zug deine Sichtweite Teleport: Teleportiert dich an einen Ort in Range ManaShield: Beschützt dich vor Schaden"
            },
            //depth 1 (intro)
            new string[] {
                "Du bist ein Agent der für das Ministerium zur Bekämpfung von Monstern arbeitet. Vor drei Wochen ist auf einmal ein dunkler Nebel über die Welt gebrochen, der alles verdunkelt. Bei deinen Ermittlungen hast du deinen Teamleader erspäht und bist diesem aus Neugier gefolgt. Am Rande einer Höhle verlierst du ihn aus den Augen. Nachdem du die Umgebung gescheckt hast entschließt du dich die Höhle zu erforschen. Welche Geheimnisse dich wohl erwarten werden?",
                "Du bist ein Agent der für das Ministerium zur Bekämpfung von Monstern arbeitet. Vor drei Wochen ist auf einmal ein dunkler Nebel über die Welt gebrochen, der alles verdunkelt. Bei deinen Ermittlungen hast du deinen Teamleader erspäht und bist diesem aus Neugier gefolgt. Am Rande einer Höhle verlierst du ihn aus den Augen. Nachdem du die Umgebung gescheckt hast entschließt du dich die Höhle zu erforschen. Bevor du sie jedoch betritts schreibst du noch deinem Kollegen eine Nachricht, der nach wenigen Minuten eintrifft. Welche Geheimnisse euch wohl erwarten werden?"
            },
            //depth 2
            new string[] {
                "Seite eines Notizbuch eines Mitarbeiters. Die Higher Ups werden immer verrückter. Ich kann nicht glauben, dass sie das wirklich vorhaben. Ich muss versuchen sie aufzuhalten. Vlt kann *****(unleserlicher Name) mir helfen. Ja ich werde ihm einen anonymen Brief schreiben und ihn um Hilfe bitten. Villeicht kann er sogar ein gutes Wort beim MBM für mich einlegen.\n Gezeichnet Zera, 19.08.100. Beim lesen fallen dir einige Dinge auf: Dieser Eintrag ist mittlerweile ungefähr 4 Wochen alt und deine Organistation das Ministerium zur Bekämpfung von Monstern(MBM) wird erwähnt. Außerdem scheint dieser Eintrag von einem Menschen zu stammen, bisher sind dir jedoch nur Skelette begegnet?",
                "Seite eines Notizbuch eines Mitarbeiters. Die Higher Ups werden immer verrückter. Ich kann nicht glauben, dass sie das wirklich vorhaben. Ich muss versuchen sie aufzuhalten. Vlt kann *****(unleserlicher Name) mir helfen. Ja ich werde ihm einen anonymen Brief schreiben und ihn um Hilfe bitten. Villeicht kann er sogar ein gutes Wort beim MBM für mich einlegen.\n Gezeichnet Zera, 19.08.100. Beim lesen fallen euch einige Dinge auf: Dieser Eintrag ist mittlerweile ungefähr 4 Wochen alt und deine Organistation das Ministerium zur Bekämpfung von Monstern(MBM) wird erwähnt. Außerdem scheint dieser Eintrag von einem Menschen zu stammen, bisher sind euch jedoch nur Skelette begegnet?"
            },
            //depth 3
            new string[] {
                "Eine weitere Seite aus Zeras Notizbuch: Er hat mir darin zugestimmt, das wir den Plan verhindern müssen, allerdings meinte er, dass er sich zuerst trefen will und ich die wichtigen Beweise mitbringen soll. Ich bin mir mittlerweile nicht mehr so sicher, ob er wirklich gegen die Organisation arbeiten wird, auch wenn er regelmäßig in Konflikte mit den Bosseb gerät. Könnte er mich in eine Falle locken?",
                "Eine weitere Seite aus Zeras Notizbuch: Er hat mir darin zugestimmt, das wir den Plan verhindern müssen, allerdings meinte er, dass er sich zuerst trefen will und ich die wichtigen Beweise mitbringen soll. Ich bin mir mittlerweile nicht mehr so sicher, ob er wirklich gegen die Organisation arbeiten wird, auch wenn er regelmäßig in Konflikte mit den Bosseb gerät. Könnte er mich in eine Falle locken?"
            },
            //depth 4
            new string[] {
                "Zeras Notizbuch: Es war eine Falle. Gott sei dank, konnte ich entkommen, allerdings bleibt mir nur die Möglichkeit tiefer in die Höhlen hinabzusteigen. Die Beweise die ich an das MBM geschickt habe hat er wahrscheinlich ebenfalls bereits abgefangen. Das einzige was mir bleibt ist meine Notizen, in der Hoffnung, dass sie jemand Gutes findet, in der Höhle zu zerstreuen. Hoffentlich können sie dir helfen.",
                "Zeras Notizbuch: Es war eine Falle. Gott sei dank, konnte ich entkommen, allerdings bleibt mir nur die Möglichkeit tiefer in die Höhlen hinabzusteigen. Die Beweise die ich an das MBM geschickt habe hat er wahrscheinlich ebenfalls bereits abgefangen. Das einzige was mir bleibt ist meine Notizen, in der Hoffnung, dass sie jemand Gutes findet, in der Höhle zu zerstreuen. Hoffentlich können sie dir helfen."
            },
            //depth 5
            new string[] {
                "Du findest zwar keine Notizen, bemerkst aber, dass sich die Umgebung um euch herum verändert. Immer mehr Pflanzen wachsen und der menschliche Einfluss scheint nachzulassen.",
                "Ihr findet zwar keine Notizen, bemerkt aber, dass sich die Umgebung um euch herum verändert. Immer mehr Pflanzen wachsen und der menschliche Einfluss scheint nachzulassen."
            },
            //depth 6
            new string[] {
                "Du findest eine verschlüsselte Nachricht, die nach einem Standart MBM Code verschlüsselt ist: Gut das du mir gefolgt bist, ich brauche schnelle deine Hilfe, treff mich später am Ausgang und seivorsichtig beim rumschnüffeln.PS. Ich habe bereits das Ministerium informiert. PSS. Am besten bleibst du erstmal auf den oberen Ebenen. PSSS. Beim nächsten mal nicht deinem vorgesetzten heimlich Folgen. Mfg. Teamleader Sebastian",
                "Ihr findet eine verschlüsselte Nachricht, die nach einem Standart MBM Code verschlüsselt ist: Gut das ihr mir gefolgt seit, brauche schnelle Hilfe, trefft mich später am Ausgang und seit vorsichtig beim rumschnüffeln.PS. Ich habe bereits das Ministerium informiert. PSS. Am besten bleibt ihr erstmal auf den oberen Ebenen. PSSS. Beim nächsten mal nicht eueren vorgesetzten Folgen. Mfg. Teamleader Sebastian"
            },
            //depth 7
            new string[] {
                "Zeras Notizbuch: Die Pflanzen die hier wachsen scheinen nicht natürlich zu entstehen. Ist Ivy mittlerweile so mächhtig geworden, dass sie passiv ihre Umgebung beinflusst? Ich muss vorsichtiger sein um, nicht von ihr bemerkt zu werden. Umso tiefer ich komme umso mehr Wachen scheinen aufgestellt zu sein.",
                "Zeras Notizbuch: Die Pflanzen die hier wachsen scheinen nicht natürlich zu entstehen. Ist Ivy mittlerweile so mächhtig geworden, dass sie passiv ihre Umgebung beinflusst? Ich muss vorsichtiger sein um, nicht von ihr bemerkt zu werden. Umso tiefer ich komme umso mehr Wachen scheinen aufgestellt zu sein."
            },
            //depth 8
            new string[] {
                "...",
                "..."
            },
            //depth 9
            new string[] {
                "Zeras Notizbuch: Ich bin zu spät. Sie habens es tatsächlich gewagt ihn zu beschwören. Der Nebel ist ein eindeutiges Zeichen seines eintreffen. Ich werde in Ivys Büro einbrechen um herauszufinden, wie wir in aufhalten können. Vielleicht ist dies mein letzter Eintrag. ",
                "Zeras Notizbuch: Ich bin zu spät. Sie habens es tatsächlich gewagt ihn zu beschwören. Der Nebel ist ein eindeutiges Zeichen seines eintreffen. Ich werde in Ivys Büro einbrechen um herauszufinden, wie wir in aufhalten können. Vielleicht ist dies mein letzter Eintrag. "
            },
            //depth 10
            new string[] {
                "Die Pflanzen scheinen immer mehr leuchtenden Kristallen zu weichen. Und du spürst die Aura eines mächtigen Wesens.",
                "Die Pflanzen scheinen immer mehr leuchtenden Kristallen zu weichen. Und ihr spürt die Aura eines mächtigen Wesens."
            }
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
            "Start Game",
            "Start Coop Game",
            "Achievements",
            "Options",
            "Exit"
        },
        //deutsch
        new string[] {
            "Spiel starten",
            "Koop Spiel starten",
            "Errungenschaften",
            "Einstellungen",
            "Beenden"
        }
    };

    //OPTIONS TEXT

    //ITEM DESCRIPTION TEXT

    //ACHIEVEMENTS
}
