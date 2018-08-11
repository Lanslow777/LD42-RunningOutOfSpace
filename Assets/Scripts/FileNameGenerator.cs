using UnityEngine;
using System.Collections;
using System;

using System.Collections.Generic;
using UnityEngine.UI;


public class NameModel
{
    public NameModel() {
        initDictionary();
    }
    
    List<String> dictionary = new List<String>();

    public String getRandomName()
    {
        int dictionaryLength = dictionary.Count;
        int randomNumber = getRandomNumber(dictionaryLength);
        String randomName = dictionary[randomNumber];
        return randomName;
    }

    public String getRandomName(int wordLength)
    {
        int dictionaryLength = dictionary.Count;
        int randomNumber = getRandomNumber(dictionaryLength);
        String randomName = dictionary[randomNumber];
        return randomName;
    }

    private int getRandomNumber(int maxValue)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(maxValue);
    }

    private void initDictionary()
    {
        dictionary.Add("AFK");
        dictionary.Add("alliance");
        dictionary.Add("apt-cache");
        dictionary.Add("apt-get");
        dictionary.Add("arborescence");
        dictionary.Add("ASCII");
        dictionary.Add("at");
        dictionary.Add("booter");
        dictionary.Add("chmod");
        dictionary.Add("cookie");
        dictionary.Add("boss");
        dictionary.Add("cat");
        dictionary.Add("capture");
        dictionary.Add("casu");
        dictionary.Add("cloud");
        dictionary.Add("community manager");
        dictionary.Add("cosplay");
        dictionary.Add("cp");
        dictionary.Add("do");
        dictionary.Add("done");
        dictionary.Add("farmer");
        dictionary.Add("fichiers sources");
        dictionary.Add("for");
        dictionary.Add("freeware");
        dictionary.Add("gamer");
        dictionary.Add("geek");
        dictionary.Add("grep");
        dictionary.Add("gzip");
        dictionary.Add("GG");
        dictionary.Add("Girl powa");
        dictionary.Add("guilde");
        dictionary.Add("head");
        dictionary.Add("history");
        dictionary.Add("guilder");
        dictionary.Add("IA");
        dictionary.Add("iconv");
        dictionary.Add("if");
        dictionary.Add("Intart");
        dictionary.Add("IRL");
        dictionary.Add("IG");
        dictionary.Add("interface");
        dictionary.Add("kevin");
        dictionary.Add("kikoolol");
        dictionary.Add("kill");
        dictionary.Add("LOL");
        dictionary.Add("loot");
        dictionary.Add("main");
        dictionary.Add("MAJ");
        dictionary.Add("make");
        dictionary.Add("mkdir");
        dictionary.Add("MMORPG");
        dictionary.Add("MP");
        dictionary.Add("mv");
        dictionary.Add("nerd");
        dictionary.Add("netiquette");
        dictionary.Add("newbie");
        dictionary.Add("noob");
        dictionary.Add("OSEF");
        dictionary.Add("ownedPGM");
        dictionary.Add("passwd");
        dictionary.Add("post");
        dictionary.Add("poweroff");
        dictionary.Add("PVP");
        dictionary.Add("PVE");
        dictionary.Add("pwd");
        dictionary.Add("pyjaracine");
        dictionary.Add("raider");
        dictionary.Add("random");
        dictionary.Add("reboot");
        dictionary.Add("régis");
        dictionary.Add("reroll");
        dictionary.Add("rmdir");
        dictionary.Add("rsync");
        dictionary.Add("roxer");
        dictionary.Add("rusher");
        dictionary.Add("skill");
        dictionary.Add("skin");
        dictionary.Add("shutdown");
        dictionary.Add("sort");
        dictionary.Add("ssh");
        dictionary.Add("sudo su");
        dictionary.Add("tail");
        dictionary.Add("tar");
        dictionary.Add("thread");
        dictionary.Add("touch");
        dictionary.Add("uniq");
        dictionary.Add("uper");
        dictionary.Add("URL");
        dictionary.Add("upgrade");
        dictionary.Add("usermod");
        dictionary.Add("wc");
        dictionary.Add("zcat");
    }
}