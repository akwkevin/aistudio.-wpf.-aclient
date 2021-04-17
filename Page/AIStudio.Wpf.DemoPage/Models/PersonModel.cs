using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Util.Controls;

namespace TestApp
{
	public class PersonModel : ITreeModel
	{
		public static PersonModel CreateTestModel(int count1, int count2, int count3)
		{
			var model = new PersonModel();
			for (int i = 0; i < count1; i++)
			{
				var p = new TreePerson() { Name = "TreePerson A " + i.ToString() };
				model.Root.Children.Add(p);
				for (int n = 0; n < count2; n++)
				{
					var p2 = new TreePerson() { Name = "TreePerson B" + n.ToString() };
					p.Children.Add(p2);
					for (int k = 0; k < count3; k++)
						p2.Children.Add(new TreePerson() { Name = "TreePerson C" + k.ToString() });
				}
			}
			return model;
		}

		public TreePerson Root { get; private set; }

		public PersonModel()
		{
			Root = new TreePerson();
		}

		public System.Collections.IEnumerable GetChildren(object parent)
		{
			if (parent == null)
				parent = Root;
			return (parent as TreePerson).Children;
		}

		public bool HasChildren(object parent)
		{
			return (parent as TreePerson).Children.Count > 0;
		}
	}

	public class TreePerson
	{
		private readonly ObservableCollection<TreePerson> _children = new ObservableCollection<TreePerson>();
		public ObservableCollection<TreePerson> Children
		{
			get { return _children; }
		}

		public string Name { get; set; }

		public int Id { get; set; }

		static int _i;
		public TreePerson()
		{
			Id = ++_i;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
