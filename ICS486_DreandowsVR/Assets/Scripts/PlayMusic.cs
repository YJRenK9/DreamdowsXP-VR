using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour
{
    AudioSource dj;

    public AudioClip newClip1;
    public AudioClip newClip2;
    public AudioClip newClip3;
    public AudioClip newClip4;

    public TextMeshProUGUI musicTitle;
    Color opacity;
    
    int songIndex;
    List<AudioClip> queue;
    string[] musicTitleList;

    // Start is called before the first frame update
    void Start()
    {
        dj = GetComponent<AudioSource>();
        queue = new List<AudioClip>();
        musicTitleList = new string[4];
        songIndex = 0;

        queue.Add(newClip1);
        queue.Add(newClip2);
        queue.Add(newClip3);
        queue.Add(newClip4);

        musicTitleList[0] = "Summer by Bensound";
        musicTitleList[1] = "CreativeMinds by Bensound";
        musicTitleList[2] = "Link by Jim Yosef";
        musicTitleList[3] = "Puzzle by Retrovision";

        // make the text invisible upon start
        opacity.a = 0f;
        musicTitle.color = opacity;
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        //     songIndex--;
        //     //Debug.Log("left");
        //     if (songIndex < 0)  songIndex = queue.Count - 1;

        //     dj.clip = queue[songIndex];
        //     dj.Play();
        // }
    }

    public void switchMusic() 
    {
        
        songIndex++;
        //Debug.Log("right");
        if (songIndex == queue.Count)  songIndex = 0;
        
        musicTitle.text = musicTitleList[songIndex];

        
        dj.clip = queue[songIndex];
        
        dj.Play();

        StartCoroutine("displayMusicTitle");
    }

    IEnumerator displayMusicTitle() 
    {
        opacity.a = 1f;
        musicTitle.color = opacity;

        yield return new WaitForSeconds(2f);

        opacity.a = 0f;
        musicTitle.color = opacity;
    }
}
