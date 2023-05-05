using NetDDDPokemonApi.models;
using Newtonsoft.Json;

namespace NetDDDPokemonApi.Tools
{
    public class DataReader
    {
        private static DataModel? DataModel { get; set; }

        public static DataModel? ReadDatas()
        {
            if (DataModel == null)
            {
                using(StreamReader r = new StreamReader("data.json"))
                {
                    DataModel = JsonConvert.DeserializeObject<DataModel>(r.ReadToEnd());
                }

                
            }

            return DataModel;
        }
    }
}
