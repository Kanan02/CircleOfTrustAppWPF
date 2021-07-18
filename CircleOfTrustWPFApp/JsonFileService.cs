using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CircleOfTrustWPFApp {
    public class JsonFileService
    {
        public ObservableCollection<Friend> Open(string fileName)
        {
            var friends = new ObservableCollection<Friend>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Friend>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                friends = jsonFormatter.ReadObject(fs) as ObservableCollection<Friend>;
            }

            return friends;
        }

        public void Save(string fileName, ObservableCollection<Friend> friends)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Friend>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, friends);
            }
        }
    }
}