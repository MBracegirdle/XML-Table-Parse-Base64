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

Console.WriteLine("-- Tables --");
for (int i = 0; i < ds.Tables.Count; i++)
{
    Console.WriteLine(i.ToString()+". "+ ds.Tables[i].TableName);
}
int tabL = int.Parse(Console.ReadLine());



dt = ds.Tables[0];
Console.Clear();
Console.WriteLine("-- Table Headers:enter number --");

for (int i = 0; i < dt.Columns.Count; i++)
{
    Console.WriteLine(i.ToString() + ". " + dt.Columns[i].ColumnName);
}


Console.WriteLine("Filename column:");
int fnc = int.Parse(Console.ReadLine());
Console.WriteLine("Base64 column:");
int b64c = int.Parse(Console.ReadLine());
oPath:
Console.WriteLine("Enter output path:");
string outPath = Console.ReadLine();
if (Path.Exists(outPath) == false) { goto oPath; }
outPath =  Path.Combine(outPath, "Documents" );
Console.WriteLine(outPath);
Directory.CreateDirectory(outPath);
Console.WriteLine(Directory.Exists(outPath));
Console.WriteLine(dt.Rows.Count);
for (int i = 0; i < dt.Rows.Count; i++)
{
    Console.WriteLine("Row "+i.ToString());
    string fn = (string)dt.Rows[i][fnc];
    string b64s = (string)dt.Rows[i][b64c];
    Console.WriteLine("Base 64 string read");
    File.WriteAllBytes(Path.Combine(outPath,fn), Convert.FromBase64String(b64s));
    Console.WriteLine(fn);
    b64s = null;
        }