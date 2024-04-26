using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
//for UI management


public class settingsMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public TMPro.TMP_Dropdown resolutionsDropDown;
    //reference dropdown
    Resolution[] resolutions;
    //create list of resolutions
    int resolutionIndex = 0;
    //store resolution index to change resolution
    void Start()
    {
        resolutions = Screen.resolutions;
        //get users screen resolutions
        resolutionsDropDown.ClearOptions();
        //clear the dropdown

        List<string> dropDownOptions = new List<string>();
        //create list of strings to store resolution options

        //iterate through indexes of resolutions
        for(int i = 0 ; i < resolutions.Length; i++)
        {
            //create a string to display from resolution width and height
            string option = resolutions[i].width + "x" + resolutions[i].height;
            //append string to list of resolution options
            //check if resolution in list
            if (!dropDownOptions.Contains(option))
            {
                dropDownOptions.Add(option);
            }

            //check that the resolution matches the current resolution
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionIndex = i;
            }

        }
        resolutionsDropDown.AddOptions(dropDownOptions);
        //add resolutions to list
        resolutionsDropDown.value = resolutionIndex;
        //set the selected value to string of current index
        resolutionsDropDown.RefreshShownValue();
        //refresh selected value when new choice is made
    }
    public void graphicsPreset(int presetIndex)
    {
        QualitySettings.SetQualityLevel(presetIndex);
        //Debug.Log("Value Input" + presetIndex);
    }
    public void toggleFullscreen(bool ToggleFullscreen)
    {
        Screen.fullScreen = ToggleFullscreen;
        Debug.Log("Fullscreen successfully toggled to " + ToggleFullscreen);
    }

    public void setResolution(int resolutionIndex)
    {
        //assign resolution of current index to resolution
        Resolution resolution = resolutions[resolutionIndex];
        //set resolution and pass through whether fullscreen is on
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
   