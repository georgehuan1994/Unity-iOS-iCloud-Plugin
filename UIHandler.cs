using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public void ShowBasicAlert()
    {
        iOSPlugin.ShowAlert("Basic Alert", "Hello this is a basic alert !");
    }

    public void ShowAlertConfirmation()
    {
        iOSPlugin.ShowAlertConfirmation("Basic Alert Confirmation", "Hello this is a basic confirmation !", "CallBack");
    }

    public void CallBack()
    {
        Debug.Log("CallBack!");
    }

    public void ShareMessage()
    {
        iOSPlugin.ShareMessage("Sharing a message!", "https://github.com/georgehuan1994/Unity-iOS-iCloud-Plugin");
    }

    public void BatteryStatus()
    {
        var batteryStatus = iOSPlugin.GetBatteryStatus();
        iOSPlugin.ShowAlert("Battery Status", batteryStatus.ToString());
    }

    public void BatteryLevel()
    {
        string batteryLevel = iOSPlugin.GetBatteryLevel();
        iOSPlugin.ShowAlert("Battery Level", batteryLevel);
    }

    public void iCloudGetStringValue()
    {
        string savedValue = iOSPlugin.iCloudGetStringValue("UIHandler.String.Key");
        iOSPlugin.ShowAlert("iCloud Value", string.IsNullOrEmpty(savedValue) ? "Nothing Saved Yet..." : savedValue);
    }

    public void iCloudSaveStringValue()
    {
        string valueToSave = System.Guid.NewGuid().ToString();
        bool success = iOSPlugin.iCloudSaveStringValue("UIHandler.String.Key", valueToSave);
        
        if (success)
        {
            iOSPlugin.ShowAlert("iCloud Value Saved Success", valueToSave);
        }
        else 
        {
            iOSPlugin.ShowAlert("iCloud Value Saved failed", valueToSave);
        }
    }
}