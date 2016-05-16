using System.IO;
using System.Xml.Serialization;
using Mixle.Entities;

namespace Mixle.Levels {
	public class LevelLoader {
		protected string[] levels;
		protected readonly string basePath = "Levels/Data/";

		public LevelLoader() {
			levels = Directory.GetFiles(basePath, "*.xml");
		}

		public Level NextLevel(int index) {
			if(index >= 0 && index < levels.Length) {
				return Load(levels[index]);
			}

			return null;
		}

		protected Level Load(string name) {
			var serializer = new XmlSerializer(typeof(Level));

			using(var reader = new StreamReader(name)) {
				return (Level) serializer.Deserialize(reader);
			}
		}
	}
}

