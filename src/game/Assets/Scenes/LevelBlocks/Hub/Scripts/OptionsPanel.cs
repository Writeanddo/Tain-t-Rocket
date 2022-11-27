using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] OptionSlider fieldOfView;
    [SerializeField] OptionSlider volumeMaster;
    [SerializeField] OptionSlider volumeEffects;
    [SerializeField] OptionSlider volumeMusic;

    void Start()
    {
        OptionsManager optionsManager = OptionsManager.GetOrCreate();

        volumeMaster.onChanged.AddListener(value =>
        {
            optionsManager.Options.volumeMaster = value;
            optionsManager.Save();
        });
        volumeEffects.onChanged.AddListener(value =>
        {
            optionsManager.Options.volumeEffects = value;
            optionsManager.Save();
        });
        volumeMusic.onChanged.AddListener(value =>
        {
            optionsManager.Options.volumeMusic = value;
            optionsManager.Save();
        });
        fieldOfView.onChanged.AddListener(value =>
        {
            optionsManager.Options.fieldOfView = value;
            optionsManager.Save();
            FindObjectOfType<SatriProtoPlayer>().RefreshFieldOfView();
        });

        volumeMaster.SetValue(optionsManager.Options.volumeMaster);
        volumeEffects.SetValue(optionsManager.Options.volumeEffects);
        volumeMusic.SetValue(optionsManager.Options.volumeMusic);
        fieldOfView.SetValue(optionsManager.Options.fieldOfView);
    }
}