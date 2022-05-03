# Unity iOS iCloud Plugin

Unity3d iOS iCloud Key-Value Storage Plugin and Native Alert Dialog.

### 注意事项

调用 iCloud Key-Value Store 相关方法之前，需要做好以下准备：

1. 确保构建时使用的描述文件 (.mobileprovision) 已启用了 iCloud Capabilities
2. 确保主要的 Xcodeproj 中包含 iCloud Entitlement 文件 (.entitlements)

### 如何添加 iCloud Entitlement 文件?

#### 手动添加

1. 在 Xcode 工程中，选择对应的 xcodeproj (Unity-iPhone)，导航到 Signing & Capabilities 标签页
2. 点击左上角的 `+Capability`，选择 iCloud，并启用 Key-Value storage

#### 自动添加

在 Unity 中使用构建后处理自动添加：

```csharp
[PostProcessBuild(1)]
public static void CapabilityEntitlementsAdder(BuildTarget target, string pathToBuiltProject)
{
    if (target == BuildTarget.iOS)
    {
        string pbxPath = PBXProject.GetPBXProjectPath(pathToBuiltProject);
        var capManager = new ProjectCapabilityManager(pbxPath, "Unity-iPhone.entitlements", "Unity-iPhone");
        capManager.AddiCloud(true, false, false, false, new string[]{});
        capManager.WriteToFile();
    }
}
```

完成上述步骤后，工程中会多出一个名为 `Unity-iPhone.entitlements` 的文件：

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
	<key>com.apple.developer.icloud-container-identifiers</key>
	<array/>
	<key>com.apple.developer.ubiquity-kvstore-identifier</key>
	<string>$(TeamIdentifierPrefix)$(CFBundleIdentifier)</string>
</dict>
</plist>
```

----

## Method

### Basic Alert

```csharp
iOSPlugin.ShowAlert("Hello", "World");
```

### Alert With Confirmation and callback to Unity

```csharp
iOSPlugin.ShowAlertConfirmation("Basic Alert Confirmation", "Hello this is a basic confirmation !", "CallBack");
```

### Sharing a Message and Url

```csharp
iOSPlugin.ShareMessage("Welcome To iOS Bridge Essentials", "https://github.com/georgehuan1994/Unity-iOS-iCloud-Plugin");
```

### Get Battery Status

```csharp
iOSPlugin.GetBatteryStatus();

public enum BatteryStatus 
{
    UIDeviceBatteryStateUnknown = 0,
    UIDeviceBatteryStateUnplugged = 1,
    UIDeviceBatteryStateCharging = 2,
    UIDeviceBatteryStateFull = 3
}

```

### Get Battery Level

```csharp
iOSPlugin.GetBatteryLevel()
```

### Save String Value to iCloud

```csharp
bool success = iOSPlugin.iCloudSaveStringValue("MyStringKey", valueToSave);
```

### Get String Value from iCloud

```csharp
string savedValue = iOSPlugin.iCloudGetStringValue("MyStringKey");
```

### Save Integer Value to iCloud

```csharp
bool success = iOSPlugin.iCloudSaveIntValue("MyIntgKey", valueToSave);
```

### Get Integer Value from iCloud

```csharp
int savedValue = iOSPlugin.iCloudGetIntValue("MyIntgKey");
```

### Save Bool Value to iCloud

```csharp
bool success = iOSPlugin.iCloudSaveBoolValue("MyBoolgKey", valueToSave);
```

### Get Bool Value from iCloud

```csharp
bool savedValue = iOSPlugin.iCloudGetBoolValue("MyBoolgKey");
```
