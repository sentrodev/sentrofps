namespace SentroFPS.Launcher.Models;


public class RemoteConfig
{
public string? Version { get; set; }
public string? Announcement { get; set; }
public Toggles? Toggles { get; set; }
public Game? Game { get; set; }
}


public class Toggles { public bool FpsBoost { get; set; } public bool PngEnabled { get; set; } }
public class Game { public string? Install_Dir { get; set; } public string? Exe { get; set; } public string? Args { get; set; } }