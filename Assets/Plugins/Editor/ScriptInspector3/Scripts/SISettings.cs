﻿/* SCRIPT INSPECTOR 3
 * version 3.0.0, July 2015
 * Copyright © 2012-2015, Flipbook Games
 * 
 * Unity's legendary editor for C#, UnityScript, Boo, Shaders, and text,
 * now transformed into an advanced C# IDE!!!
 * 
 * Follow me on http://twitter.com/FlipbookGames
 * Like Flipbook Games on Facebook http://facebook.com/FlipbookGames
 * Join discussion in Unity forums http://forum.unity3d.com/threads/138329
 * Contact info@flipbookgames.com for feedback, bug reports, or suggestions.
 * Visit http://flipbookgames.com/ for more info.
 */

using UnityEngine;
using UnityEditor;

namespace ScriptInspector
{
class OptionsBase
{
	protected const string prefix = "FlipbookGames.ScriptInspector.";
	protected string key { get; private set; }
	protected OptionsBase(string key) { this.key = key; }
}

class BoolOption : OptionsBase
{
	private bool value;
	public bool Value
	{
		get { return value; }
		set {
			if (this.value == value)
				return;
			this.value = value;
			EditorPrefs.SetBool(prefix + key, value);
			FGTextEditor.RepaintAllInstances();
		}
	}
	public BoolOption(string key, bool defaultValue) : base(key)
	{
		value = EditorPrefs.GetBool(prefix + key, defaultValue);
	}
	public bool Toggle() { Value = !Value; return Value; }
	public override string ToString()
	{
		return Value.ToString();
	}
	public static implicit operator bool(BoolOption self) { return self.Value; }
}

class IntOption : OptionsBase
{
	private int value;
	public int Value
	{
		get { return value; }
		set {
			if (this.value == value)
				return;
			this.value = value;
			EditorPrefs.SetInt(prefix + key, value);
			FGTextEditor.RepaintAllInstances();
		}
	}
	public IntOption(string key, int defaultValue) : base(key)
	{
		value = EditorPrefs.GetInt(prefix + key, defaultValue);
	}
	public override string ToString()
	{
		return Value.ToString();
	}
	public static implicit operator int(IntOption self) { return self.Value; }
}

class FloatOption : OptionsBase
{
	private float value;
	public float Value
	{
		get { return value; }
		set {
			if (this.value == value)
				return;
			this.value = value;
			EditorPrefs.SetFloat(prefix + key, value);
			FGTextEditor.RepaintAllInstances();
		}
	}
	public FloatOption(string key, float defaultValue) : base(key)
	{
		value = EditorPrefs.GetFloat(prefix + key, defaultValue);
	}
	public override string ToString()
	{
		return Value.ToString();
	}
	public static implicit operator float(FloatOption self) { return self.Value; }
}

class StringOption : OptionsBase
{
	private string value;
	public string Value
	{
		get { return value; }
		set {
			if (this.value == value)
				return;
			this.value = value;
			EditorPrefs.SetString(prefix + key, value);
			FGTextEditor.RepaintAllInstances();
		}
	}
	public StringOption(string key, string defaultValue) : base(key)
	{
		value = EditorPrefs.GetString(prefix + key, defaultValue);
	}
	public override string ToString()
	{
		return Value.ToString();
	}
	public static implicit operator string(StringOption self) { return self.Value; }
}

static class SISettings
{
	public static IntOption expandTabTitles = Create("ExpandTabTitles", 0);
	public static BoolOption useStandardColorInPopups = Create("UseStdColorsInPopups", false);
	public static BoolOption showThickerCaret = Create("ShowThickerCaret", false);
	
	public static BoolOption handleOpenAssets = Create("HandleOpenAsset", false);
	public static BoolOption handleOpeningScripts = Create("HandleOpenFromProject", true);
	public static BoolOption handleOpeningShaders = Create("HandleOpenShaderFromProject", true);
	public static BoolOption handleOpeningText = Create("HandleOpenTextFromProject", true);

	public static BoolOption highlightCurrentLine = Create("HighlightCurrentLine", true);
	public static FloatOption highlightCurrentLineAlpha = Create("HighlightCurrentLineAlpha", 0.5f);
	public static BoolOption frameCurrentLine = Create("FrameCurrentLine", true);
	public static BoolOption showLineNumbersCode = Create("LineNumbersCode", true);
	public static BoolOption showLineNumbersCodeInspector = Create("LineNumbersCodeInspector", false);
	public static BoolOption showLineNumbersText = Create("LineNumbersText", false);
	public static BoolOption showLineNumbersTextInspector = Create("LineNumbersTextInspector", false);
	public static BoolOption trackChangesCode = Create("TrackChangesCode", true);
	public static BoolOption trackChangesCodeInspector = Create("TrackChangesCodeInspector", false);
	public static BoolOption trackChangesText = Create("TrackChangesText", true);
	public static BoolOption trackChangesTextInspector = Create("TrackChangesTextInspector", false);
	public static BoolOption wordWrapCode = Create("WordWrapCode", false);
	public static BoolOption wordWrapCodeInspector = Create("WordWrapCodeInspector", true);
	public static BoolOption wordWrapText = Create("WordWrapText", true);
	public static BoolOption wordWrapTextInspector = Create("WordWrapTextInspector", true);
	public static StringOption editorFont = Create("EditorFont", "");
	public static BoolOption fontHinting = Create("FontHinting", Application.platform != RuntimePlatform.OSXEditor);
	public static IntOption fontSizeDelta = Create("FontSizeDelta", 0);
	public static IntOption fontSizeDeltaInspector = Create("FontSizeDeltaInspector", 0);
	public static StringOption themeNameCode = Create("ThemeNameCode",
		EditorGUIUtility.isProSkin ? "Darcula" :
		Application.platform == RuntimePlatform.OSXEditor ? "Xcode" :
		"Visual Studio");
	public static StringOption themeNameText = Create("ThemeNameText", "");
	public static BoolOption autoReloadAssemblies = Create("AutoReloadAssemblies", true);
	public static BoolOption compileOnSave = Create("CompileOnSave", true);
	public static BoolOption cancelReloadOnEdit = Create("CancelReloadOnEdit", true);
	
	//public static BoolOption semanticHighlighting = Create("SemanticHighlighting", true);
	public static BoolOption referenceHighlighting = Create("ReferenceHighlighting", true);
	public static BoolOption keepLastHighlight = Create("KeepLastHighlight", true);
	public static BoolOption highlightWritesInRed = Create("HighlightWritesInRed", true);
	
	public static BoolOption loopSearchResults = Create("LoopSearchResults", true);
	public static BoolOption smoothScrolling = Create("smoothScrolling", true);
	public static BoolOption sortRegionsByName = Create("sortRegionsByName", false);
	
	private static BoolOption Create(string key, bool defaultValue)
	{
		return new BoolOption(key, defaultValue);
	}
	
	private static IntOption Create(string key, int defaultValue)
	{
		return new IntOption(key, defaultValue);
	}
		
	private static FloatOption Create(string key, float defaultValue)
	{
		return new FloatOption(key, defaultValue);
	}
	
	private static StringOption Create(string key, string defaultValue)
	{
		return new StringOption(key, defaultValue);
	}

	public static void SaveSettings()
	{
		FGTextEditor.RepaintAllInstances();
	}
	
	static readonly GUIContent[] modeToggles = new GUIContent[]
	{
		new GUIContent("General"),
		new GUIContent("View"),
		new GUIContent("Editor"),
	};
	
	static int selectedMode;
	
	static SISettings()
	{
		selectedMode = EditorPrefs.GetInt("FlipbookGames.ScriptInspector.SettingsMode", 0);
	}
	
	static class Styles
	{
		public static GUIStyle largeButton = "LargeButton";
	}
	
	[PreferenceItem("Script Inspector")]
	static void SettingsGUI()
	{
		EditorGUILayout.Space();
		int newSelectedMode = GUILayout.Toolbar(selectedMode, modeToggles, Styles.largeButton);
		if (newSelectedMode != selectedMode)
		{
			selectedMode = newSelectedMode;
			EditorPrefs.SetInt("FlipbookGames.ScriptInspector.SettingsMode", selectedMode);
		}
		
		EditorGUILayout.Space();
#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_3_5
		EditorGUIUtility.LookLikeControls();
#endif
		
		switch (selectedMode)
		{
		case 0:
			GeneralSettings();
			break;
		case 1:
			ViewSettings();
			break;
		case 2:
			EditorSettings();
			break;
		}
	}
	
	static void GeneralSettings()
	{
		GUILayout.Label("Use Si3 instead of the external IDE", EditorStyles.boldLabel);
		Draw("Always Open in Script Inspector", handleOpenAssets);
		EditorGUILayout.Space();
		
		GUILayout.Label("Open on double-click", EditorStyles.boldLabel);
		Draw("Scripts", handleOpeningScripts);
		Draw("Shaders", handleOpeningShaders);
		Draw("Text Assets", handleOpeningText);
		EditorGUILayout.Space();
		
		GUILayout.Label("Si3 tabs titles", EditorStyles.boldLabel);
		expandTabTitles.Value = EditorGUILayout.Toggle("Expand on Mouse-Over", expandTabTitles.Value == 1) ? 1 : 0;
	}
	
	static Vector2 viewScrollPosition;
	static void ViewSettings()
	{
		viewScrollPosition = GUILayout.BeginScrollView(viewScrollPosition);
		
		Draw("Show thicker caret", showThickerCaret);
		EditorGUILayout.Space();

		GUILayout.Label("Current Line Highlighting", EditorStyles.boldLabel);
		Draw("Frame Current Line", frameCurrentLine);
		Draw("Highlight Current Line", highlightCurrentLine);
		EditorGUILayout.Space();

		GUILayout.BeginHorizontal();
		GUILayout.Label("Word Wrap", EditorStyles.boldLabel);
		GUILayout.FlexibleSpace();
		GUILayout.Label("Si3 Tabs", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));
		GUILayout.Space(16);
		GUILayout.Label("Inspector Tab", EditorStyles.boldLabel, GUILayout.ExpandWidth(false));
		GUILayout.EndHorizontal();
		Draw2("Scripts & Shaders", wordWrapCode, wordWrapCodeInspector);
		Draw2("Text Assets", wordWrapText, wordWrapTextInspector);
		EditorGUILayout.Space();
		
		GUILayout.Label("Show Line Numbers", EditorStyles.boldLabel);
		Draw2("Scripts & Shaders", showLineNumbersCode, showLineNumbersCodeInspector);
		Draw2("Text Assets", showLineNumbersText, showLineNumbersTextInspector);
		EditorGUILayout.Space();
		
		GUILayout.Label("Track Changes", EditorStyles.boldLabel);
		Draw2("Scripts & Shaders", trackChangesCode, trackChangesCodeInspector);
		Draw2("Text Assets", trackChangesText, trackChangesTextInspector);
		EditorGUILayout.Space();
		
		GUILayout.Label("C# Code", EditorStyles.boldLabel);
		//Draw("Semantic Highlighting", semanticHighlighting);
		Draw("Use Neutral Colors in Popups", useStandardColorInPopups);
		Draw("Reference Highlighting", referenceHighlighting);
		Draw(".  Keep Last Highlighted Symbol", keepLastHighlight, referenceHighlighting);
		Draw(".  Highlight Writes in Red", highlightWritesInRed, referenceHighlighting);
		EditorGUILayout.Space();
		
		EditorGUILayout.EndScrollView();
	}
	
	static void EditorSettings()
	{
		bool isOSX = Application.platform == RuntimePlatform.OSXEditor;
		
		GUILayout.Label("Saving Scripts", EditorStyles.boldLabel);
		Draw("Compile on Save", compileOnSave, true);
		if (compileOnSave && !isOSX)
		{
			Draw("Auto Reload Assemblies", autoReloadAssemblies, true);
		}
		else
		{
			bool saved = autoReloadAssemblies;
			autoReloadAssemblies.Value = true;
			Draw("Auto Reload Assemblies", autoReloadAssemblies, false);
			autoReloadAssemblies.Value = saved || isOSX;
		}
		//		Draw("... Unless Editing Continues", cancelReloadOnEdit, compileOnSave && autoReloadAssemblies);
		cancelReloadOnEdit.Value = false;
		
		var ctrlR = isOSX ? "Cmd-Alt-R" : "Ctrl+R";
		if (!compileOnSave)
		{
			EditorGUILayout.HelpBox(
				@"Saving will NOT recompile assemblies automatically.

Compile and reload assemblies with " + ctrlR + " or with a 'double-save'.",
				MessageType.None, true);
		}
		else if (autoReloadAssemblies)
		{
			EditorGUILayout.HelpBox(cancelReloadOnEdit ?
			"Saving will recompile and reload assemblies automatically if you don't edit scripts while they are compiling.\n\nIf you edit scripts while compiling then you can reload previously compiled assemblies with " + ctrlR + " or save the changes." :
				"Saving will recompile and reload assemblies automatically.",
				MessageType.None, true);
		}
		else
		{
			EditorGUILayout.HelpBox(
			"Saving will recompile assemblies in background.\n\nReload them with " + ctrlR + " or with a 'double-save'.",
				MessageType.None, true);
		}
		
		EditorGUILayout.Space();
		
		GUILayout.Label("More options...", EditorStyles.boldLabel);
		Draw("Search results looping", loopSearchResults);
		Draw("Smooth scrolling", smoothScrolling);
	}

	static void Draw2(string label, BoolOption option1, BoolOption option2)
	{
		GUILayout.BeginHorizontal();
		Draw(label, option1);
		Draw(null, option2);
		GUILayout.EndHorizontal();
	}
	
	static bool Draw(string label, BoolOption option, bool enabled = true, GUIStyle style = null)
	{
#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_3_5
		EditorGUIUtility.LookLikeControls(label == null ? 35f : 200f);
#else
		EditorGUIUtility.labelWidth = label == null ? 35f : 200f;
#endif
		if (enabled)
		{
			if (style != null)
				option.Value = EditorGUILayout.Toggle(label, option.Value, style);
			else
				option.Value = EditorGUILayout.Toggle(label, option.Value);
		}
		else
		{
			var old = GUI.enabled;
			GUI.enabled = false;
			if (style != null)
				option.Value = EditorGUILayout.Toggle(label, option.Value, style);
			else
				option.Value = EditorGUILayout.Toggle(label, option.Value);
			GUI.enabled = old;
		}
		return option;
	}
}

}
