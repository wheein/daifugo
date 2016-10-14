﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSpawner{

	private Dictionary<int,string> _clubSuit;
	private Dictionary<int,string> _heartSuit;
	private Dictionary<int,string> _diamondSuit;
	private Dictionary<int,string> _spadesSuit;


	public CardSpawner(){

		_heartSuit = new Dictionary<int, string> ();
		_clubSuit = new Dictionary<int, string> ();
		_diamondSuit = new Dictionary<int, string> ();
		_spadesSuit = new Dictionary<int, string> ();

	
		string[] r = new string[] { "_of_hearts", "_of_clubs", "_of_spades", "_of_diamonds" };

		for (int i = 0; i < r.Length; i++) {	
			for (int j = 2; j < 16; j++) {
				
				Dictionary<int,string> g = getDictionaryForKey (i);
				g.Add (j,j.ToString()+r[i] );

			}
		}

	}

	public Sprite getSprite (int suit, int rank){

		string imageName = null;
		Dictionary <int,string> g = getDictionaryForKey (suit);

		if (g != null) {
			g.TryGetValue(rank, out imageName);
		}
			
		Texture2D tex = Resources.Load ("images/cards/"+ getFolderNameForKey(suit) + "/" + imageName, typeof(Texture2D)) as Texture2D;
		Sprite x = Sprite.Create (tex, new Rect (0, 0,tex.width, tex.height), new Vector2 (0.0f, 0.0f));

		return x;

	}


	private Dictionary<int,string> getDictionaryForKey(int key){

		if (key == 0) {
			return _heartSuit;
		} else if (key == 1) {
			return _clubSuit;
		} else if (key == 2) {
			return _diamondSuit;
		} else if (key == 3) {
			return _spadesSuit;
		}

		return null;

	}

	private string getFolderNameForKey(int key){

		if (key == 0) {
			return "hearts";
		} else if (key == 1) {
			return "club";
		} else if (key == 2) {
			return "diamonds";
		} else if (key == 3) {
			return "spades";
		}

		return null;

	}


}
