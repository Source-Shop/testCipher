using System;
using System.IO;
using System.Text;
using System.Text.Json;

// TestRoot myDeserializedClass = JsonConvert.DeserializeObject<TestRoot>(myJsonResponse);
    public class TestRoot
    {
        public string? UniqueID { get; set; }
        public string? Name { get; set; }

        public string? ImageSourceBasePath { get; set; }

        public string? ImageSourceFileName { get; set; }
        public string? Rarity{ get; set; }

        public string? UsingEffect{ get; set; }

        public int RedSoulChipElement{ get; set; }

        public int GreenSoulChipElement{ get; set; }

        public int BlueSoulChipElement{ get; set; }

        public int YellowSoulChipElement{ get; set; }
        public int Movement{ get; set; }

        public int RedSoulPowerVariationMinimum{ get; set; }

        public int RedSoulPowerVariationMaximum{ get; set; }

        public int GreenSoulPowerVariationMinimum{ get; set; }

        public int GreenSoulPowerVariationMaximum{ get; set; }

        public int BlueSoulPowerVariationMinimum{ get; set; }

        public int BlueSoulPowerVariationMaximum{ get; set; }


        public int YellowSoulPowerVariationMinimum{ get; set; }


        public int YellowSoulPowerVariationMaximum{ get; set; }


        public int AttackSpaceKeeper{ get; set; }
        public int Heal{ get; set; }

     
        public int SpaceKeeperActionInvokingPointVariationMinimum{ get; set; }

        public int SpaceKeeperActionInvokingPointVariationMaximum{ get; set; }
    }



public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");

        
        var readAllText = File.ReadAllText("test.json");

        Console.WriteLine(readAllText);

        var readBytes = Encoding.ASCII.GetBytes(readAllText);

        


        //암호화
        for(int i = 0; i < readBytes.Length; i++)
        {
            readBytes[i] = (byte)(readBytes[i] + 101030);
        }

    

        File.WriteAllBytes("test.jisdb", readBytes);

        //복호화
        var readByteDB = File.ReadAllBytes("test.jisdb");

        for(int i = 0; i < readByteDB.Length; i++)
        {
            readByteDB[i] = (byte)(readByteDB[i] - 101030);
        }


        var readText = Encoding.ASCII.GetString(readByteDB);

        Console.WriteLine(readText);
       
        TestRoot? classObj = JsonSerializer.Deserialize<TestRoot>(readText);

        Console.WriteLine(classObj.Name);
   
    }
}