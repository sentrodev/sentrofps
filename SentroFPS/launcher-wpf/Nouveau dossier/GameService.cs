using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SentroFPS.Launcher.Models;


namespace SentroFPS.Launcher.Services;


public static class GameService
{
public static async Task ApplyOptionsAsync(RemoteConfig cfg, bool fpsBoost, bool png)
{
if (cfg.Game?.Install_Dir is null) throw new("Chemin d'installation manquant");
Directory.CreateDirectory(cfg.Game.Install_Dir);


// Exemple: écrire un autoexec.cfg pour boosters FPS (ex: Source/GMOD)
var cfgDir = Path.Combine(cfg.Game.Install_Dir, "cfg");
Directory.CreateDirectory(cfgDir);
var autoexec = Path.Combine(cfgDir, "autoexec.cfg");


var sb = new StringBuilder();
if (fpsBoost)
{
sb.AppendLine("cl_cmdrate 66");
sb.AppendLine("cl_updaterate 66");
sb.AppendLine("fps_max 300");
sb.AppendLine("mat_queue_mode 2");
}
else { sb.AppendLine("fps_max 144"); }


await File.WriteAllTextAsync(autoexec, sb.ToString());


// Exemple: activer des PNG (HUD textures) en copiant/supprimant des fichiers
var pngFolder = Path.Combine(cfg.Game.Install_Dir, "custom_png");
if (png)
{
Directory.CreateDirectory(pngFolder);
// ici tu copierais tes assets .png vers le bon emplacement
}
else
{
if (Directory.Exists(pngFolder)) Directory.Delete(pngFolder, true);
}
}


public static void Launch(RemoteConfig cfg)
{
if (cfg.Game?.Install_Dir is null || cfg.Game.Exe is null)
throw new("Config jeu incomplète");


var exePath = Path.Combine(cfg.Game.Install_Dir, cfg.Game.Exe);
if (!File.Exists(exePath)) throw new($"Introuvable: {exePath}");


var psi = new ProcessStartInfo(exePath)
{
WorkingDirectory = cfg.Game.Install_Dir,
Arguments = cfg.Game.Args ?? string.Empty,
UseShellExecute = true
};
Process.Start(psi);
}
}