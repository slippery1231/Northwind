namespace Northwind.ToggleRouter;

public interface IToggleRouter
{
    bool IsEnable(ReleaseToggleEnum toggleEnum);
}

public class ReleaseToggleRouter : IToggleRouter
{
    private readonly Dictionary<ReleaseToggleEnum, bool> _toggleLookup = new Dictionary<ReleaseToggleEnum, bool>();

    private static List<string> TestEnvironments => new List<string>()
    {
        EnvironmentEnum.Debug.ToString(), EnvironmentEnum.TST.ToString(), EnvironmentEnum.UAT.ToString()
    };

    public ReleaseToggleRouter()
    {
        foreach (ReleaseToggleEnum releaseToggle in Enum.GetValues(typeof(ReleaseToggleEnum)))
        {
            _toggleLookup.Add(releaseToggle, GetValue(releaseToggle));
        }
    }

    public bool IsEnable(ReleaseToggleEnum toggleEnum)
    {
        // var appSetting = ConfigurationManager.AppSettings["Apollo.Environment"];
        
        //先假設環境是tst
        var appSetting = "TST";

        //toggle 只允許上到UAT，上PP前必須刪除toggle off的code
        if (TestEnvironments.DoesNotContain(appSetting))
        {
            return false;
        }

        return _toggleLookup.TryGetValue(toggleEnum, out var result) && result;
    }

    private static bool GetValue(ReleaseToggleEnum toggleName)
    {
        // return bool.TryParse(ConfigurationManager.AppSettings[toggleName.ToString()], out var isEnable)
        //        && isEnable;
        
        //先假設tst的toggle是開的
        return bool.TryParse("true", out var isEnable)
               && isEnable;
    }
}

internal enum EnvironmentEnum
{
    Unknown = 0,
    Debug = 1,
    TST = 2,
    UAT = 3,
    PRDAsia = 4,
}

public enum ReleaseToggleEnum
{
    VN14
}