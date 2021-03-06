using System.Text;
using System.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace CodeGenerators;

[Generator]
public class SettingsXmlGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        IEnumerable<AdditionalText> settingsFiles =
            context.AdditionalFiles.Where(at => at.Path.EndsWith(".xmlsettings"));
        foreach (AdditionalText settingsFile in settingsFiles)
        {
            ProcessSettingsFile(settingsFile, context);
        }
    }

    private void ProcessSettingsFile(AdditionalText xmlFile, GeneratorExecutionContext context)
    {
        XmlDocument xmlDoc = new XmlDocument();
        string text = xmlFile.GetText(context.CancellationToken).ToString();
        try
        {
            xmlDoc.LoadXml(text);
        }
        catch
        {
            //TODO: issue a diagnostic that says we couldn't parse it
            return;
        }


        string fileName = Path.GetFileName(xmlFile.Path);
        string name = xmlDoc.DocumentElement.GetAttribute("name");

        StringBuilder sb = new StringBuilder($@"
namespace AutoSettings
{{
    using System;
    using System.Xml;
    public partial class XmlSettings
    {{
        
        public static {name}Settings {name} {{ get; }} = new {name}Settings(""{fileName}"");
        public class {name}Settings 
        {{
            
            XmlDocument xmlDoc = new XmlDocument();
            private string fileName;
            public string GetLocation() => fileName;
                
            internal {name}Settings(string fileName)
            {{
                this.fileName = fileName;
                xmlDoc.Load(fileName);
            }}
");

        for (int i = 0; i < xmlDoc.DocumentElement.ChildNodes.Count; i++)
        {
            XmlElement setting = (XmlElement)xmlDoc.DocumentElement.ChildNodes[i];
            string settingName = setting.GetAttribute("name");
            string settingType = setting.GetAttribute("type");

            sb.Append($@"
public {settingType} {settingName}
{{
    get
    {{
        return ({settingType}) Convert.ChangeType(((XmlElement)xmlDoc.DocumentElement.ChildNodes[{i}]).InnerText, typeof({settingType}));
    }}
}}
");
        }

        sb.Append("} } }");

        context.AddSource($"Settings_{name}", SourceText.From(sb.ToString(), Encoding.UTF8));
    }

    public void Initialize(GeneratorInitializationContext context)
    {
    }
}