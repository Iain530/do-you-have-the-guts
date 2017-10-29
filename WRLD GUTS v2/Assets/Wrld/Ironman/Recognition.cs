using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Recognition : MonoBehaviour
{

    KeywordRecognizer KeywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    AudioSource audioJarvis;
    AudioSource audioMission;
    AudioSource audioThanks;
    AudioSource audioHyperspeed;
    AudioSource audioCruise;
    AudioSource audioSlow;
    AudioSource audioExit;
    AudioSource audioSome;

    void Start()
    {

        audioJarvis = this.GetComponents<AudioSource>()[0];
        audioSome = this.GetComponents<AudioSource>()[1];
        audioMission = this.GetComponents<AudioSource>()[4];
        audioExit = this.GetComponents<AudioSource>()[3];
        audioThanks = this.GetComponents<AudioSource>()[2];
        audioHyperspeed = this.GetComponents<AudioSource>()[6];
        audioCruise = this.GetComponents<AudioSource>()[5];
        audioSlow = this.GetComponents<AudioSource>()[7];

        print("Jarvis booting up...");
        keywords.Add("Jarvis", () =>
        {
            GoJarvis();
        });
        keywords.Add("Hyperspeed", () =>
        {
            GoHyperspeed();
        });
        keywords.Add("Cruise", () =>
        {
            GoCruise();
        });
        keywords.Add("Slow", () =>
        {
            GoSlow();
        });
        keywords.Add("Mission", () =>
        {
            GoMission();
        });
        keywords.Add("Thanks", () =>
        {
            GoThanks();
        });
        keywords.Add("Exit", () =>
        {
            GoExit();
        });
        keywords.Add("Some", () =>
        {
            GoSome();
        });

        KeywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        KeywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhrase;
        KeywordRecognizer.Start();


    }
    void KeywordRecognizerOnPhrase(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
    void GoJarvis()
    {
        print("Jarvis here, at your command.");
        audioJarvis.Play();
    }
    void GoHyperspeed()
    {
        print("Entering hyper speed.");
        audioHyperspeed.Play();
        this.GetComponent<Move>().ChangeSpeed(1000);
    }
    void GoCruise()
    {
        print("Entering cruising speed.");
        audioCruise.Play();
        this.GetComponent<Move>().ChangeSpeed(300);
    }
    void GoSlow()
    {
        print("Entering slow speed.");
        audioSlow.Play();
        this.GetComponent<Move>().ChangeSpeed(50);
    }
    void GoMission()
    {
        print("Mission location loading up.");
        audioMission.Play();
        //this.GetComponent<SwitchCamera>().SwitchCameraMission();
        this.GetComponent<Highlights>().BeginHighlighting();
        //CameraSwitchDelay(5);
        //this.GetComponent<SwitchCamera>().CameraSwitch();
    }
    void GoThanks()
    {
        print("Not a problem, sir.");
        audioThanks.Play();
        this.GetComponent<SwitchCamera>().SwitchCameraPlayer();
        //CameraSwitchDelay(5);
        //this.GetComponent<SwitchCamera>().CameraSwitch();
    }
    void GoExit()
    {
        print("Exiting the system.");
        audioExit.Play();
        Application.Quit();
    }
    void GoSome()
    {
        print("SHREK IS LOVE SHREK IS LIFE");
        audioSome.Play();
    }

    public static void CameraSwitchDelay(int seconds)
    {
        DateTime ts = DateTime.Now.Add(TimeSpan.FromSeconds(seconds));

        do { } while (DateTime.Now < ts);

        
    }
}
