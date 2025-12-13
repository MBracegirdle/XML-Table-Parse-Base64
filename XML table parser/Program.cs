// See https://aka.ms/new-console-template for more information
using System.Data;


Console.Title = "XML extraction";
Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
DataTable dt = new DataTable();
Stream s = new System.IO.MemoryStream();
DirP:

Console.WriteLine("Enter XML directory:");
string XMLPath = Console.ReadLine();
if (Path.Exists(XMLPath) == false) { goto DirP; }
Filep:
Console.WriteLine("Enter XML filename:");
string XMLFileName = Console.ReadLine();
string fullXMLPath = Path.Combine(XMLPath,XMLFileName);
Console.WriteLine(fullXMLPath);
if (Path.Exists(fullXMLPath) == false){ goto Filep; }
s = File.Open(fullXMLPath, FileMode.Open);

DataSet ds = new DataSet();
ds.ReadXml(s);
dt = ds.Tables[0];
for (int i = 0; i < dt.Columns.Count; i++)
{
    Console.WriteLine(dt.Columns[i].ColumnName);
}


Console.WriteLine("Filename column:");
string fnc = Console.ReadLine();
Console.WriteLine("Base64 column:");
string b64c = Console.ReadLine();
oPath:
Console.WriteLine("Enter output path:");
string outPath = Console.ReadLine();
if (Path.Exists(outPath) == false) { goto oPath; }
outPath =  Path.Combine(outPath, "Documents" );
for (int i = 0; i < dt.Rows.Count; i++)
{
    string fn = (string)dt.Rows[i][fnc];

    File.WriteAllBytes(Path.Combine(outPath,fn), Convert.FromBase64String( (string)dt.Rows[i][b64c]));


        }