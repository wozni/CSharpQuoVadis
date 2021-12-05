using AutoSettings;

var a = XmlSettings.Main;
Console.WriteLine($"FirstRun = {XmlSettings.Main.FirstRun}");
Console.WriteLine($"CacheSize = {XmlSettings.Main.CacheSize}");
Console.WriteLine($"ValidTo = {XmlSettings.Main.ValidTo.AddYears(10)}");



