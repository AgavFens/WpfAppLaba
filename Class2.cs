using System;

namespace WpfAppLaba
{
public class Class1
{
	public static T DeserializeObject<T>()
	{
		OpenFileDialog dialog = new OpenFileDialog();
		if (dialog.ShowDialog() == true)
		{
			string json = File.ReadAllText(dialog.FileName);
			T obj = json.DeserializeObject<T>(json);
			return obj;
		}
		else
		{
			return default(T);
		}
	}
}

}

