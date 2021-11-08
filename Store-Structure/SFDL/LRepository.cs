using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SFModels;

namespace SFDL
{
    //The repository class has a bunch of methods that we will use to get or store information from the database
    //Does not actually hold the data itself
    public class LRepository : ILRepository
    {
        //Filepath need to reference from the startup project (RRUI) and hence why we need to go back a folder and cd into RRDL
        private const string _filepath = "./../SFDL/Database/Line_Item.json";
        private string _jsonString;

        public Line_Item GetLine_ItemByID(int l_item)
        {
            throw new NotImplementedException();
        }



        public List<Line_Item> GetAllLine_Items(int l_storeID)
        {
            switch (l_storeID)
            {
                case 1:    
                    _jsonString = File.ReadAllText(_filepath+"GeorgeWarehouseLine_Item.json");

                    return JsonSerializer.Deserialize<List<Line_Item>>(_jsonString);

                case 2:
                    _jsonString = File.ReadAllText(_filepath+"TimToolHouseLine_Item.json");

                    return JsonSerializer.Deserialize<List<Line_Item>>(_jsonString);

                default:
                    _jsonString = File.ReadAllText(_filepath+"GeorgeWarehouseLine_Item.json");

                    return JsonSerializer.Deserialize<List<Line_Item>>(_jsonString);
                

            }
        }
    }
}