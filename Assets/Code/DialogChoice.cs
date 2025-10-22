using System.Collections;
using UnityEngine;

//attribute -> tag für Klassen, Variabeln, Funktionen
[System.Serializable] //erlaubt Unity die Daten aus der Klasse zu lesen und zu speichern
public class DialogChoice {
	public string text;
	public DialogLine nextLine;
}