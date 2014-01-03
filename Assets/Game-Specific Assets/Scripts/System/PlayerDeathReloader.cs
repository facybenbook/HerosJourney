﻿using UnityEngine;
using System;
using System.Collections;

public class PlayerDeathReloader : MonoBehaviour 
{
	#region Variables / Properties
	
	public bool DebugMode = false;
	public string observedTag = "Player";

	private Fader _fader;
	private HealthSystem _health;
	private TransitionManager _sceneChange;
	
	#endregion Variables / Properties
	
	#region Engine Hooks
	
	public void Start()
	{
		_sceneChange = TransitionManager.Instance;
		_fader = (Fader) FindObjectOfType(typeof(Fader));
	}

	public void OnLevelWasLoaded()
	{
		StandardDebugMessage("Level was successfully reloaded.");
		_fader = (Fader) FindObjectOfType(typeof(Fader));
	}

	#endregion Engine Hooks
	
	#region Methods

	public void OnHealthChanged(HealthEventArgs args)
	{
		if(args.Tag != observedTag)
			return;

		StandardDebugMessage("HP has changed!");

		if(args.HP > 0)
			return;

		StartCoroutine(ReloadLevelSequence());
	}

	private IEnumerator ReloadLevelSequence()
	{
		StandardDebugMessage("Reloading level...");
		
		_fader.FadeOut();
		while(_fader.ScreenShown)
		{
			StandardDebugMessage("Fading screen out...");
			yield return 0;
		}
		
		_sceneChange.ChangeScenes();
		yield return null;
	}

	private void StandardDebugMessage(string message)
	{
		if(! DebugMode)
			return;

		Debug.Log(string.Format("({0}) {1}", DateTime.Now.ToString("HH:mm:ss"), message));
	}
	
	#endregion Methods
}