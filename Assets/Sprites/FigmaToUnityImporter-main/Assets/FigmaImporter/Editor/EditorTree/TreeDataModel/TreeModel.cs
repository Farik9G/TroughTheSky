using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace UnityEditor.TreeViewExamples
{
	// The TreeModel is a utility class working on a list of serializable TreeElements where the order and the depth of each TreeElement define
	// the tree structure. Note that the TreeModel itself is not serializable (in Unity we are currently limited to serializing lists/arrays) but the 
	// input list is.
	// The tree representation (parent and children references) are then build internally using TreeElementUtility.ListToTree (using depth 
	// values of the elements). 
	// The first element of the input list is required to have depth == -1 (the hiddenroot) and the rest to have
	// depth >= 0 (otherwise an exception will be thrown)

	public class TreeModel<T> where T : TreeElement
	{
		IList<T> m_Data;
		T m_Root;
		int m_MaxID;
	
		public T root { get { return m_Root; } set { m_Root = value; } }
		public event Action modelChanged;
		public int numberOfDataElements
		{
			get { return m_Data.Count; }
		}

		public IList<T> Data => m_Data;

		public TreeModel (IList<T> data)
		{
			SetData (data);
		}

		public T Find (int id)
		{
			return m_Data.FirstOrDefault (element => element.id == id);
		}
	
		public void SetData (IList<T> data)
		{
			Init (data);
		}

		void Init (IList<T> data)
		{
			if (data == null)
				throw new ArgumentNullException("data", "Input data is null. Ensure input is a non-null list.");

			m_Data = data;
			if (m_Data.Count > 0)
				m_Root = TreeElementUtility.ListToTree(data);

			m_MaxID = m_Data.Max(e => e.id);
		}

		public IList<int> GetAncestors (int id)
		{
			var parents = new List<int>();
			TreeElement T = Find(id);
			if (T != null)
			{
				while (T.parent != null)
				{
					parents.Add(T.parent.id);
					T = T.parent;
				}
			}
			return parents;
		}

		public IList<int> GetDescendantsThatHaveChildren (int id)
		{
			T searchFromThis = Find(id);
			if (searchFromThis != null)
			{
				return GetParentsBelowStackBased(searchFromThis);
			}
			return new List<int>();
		}

		IList<int> GetParentsBelowStackBased(TreeElement searchFromThis)
		{
			Stack<TreeElement> stack = new Stack<TreeElement>();
			stack.Push(searchFromThis);

			var parentsBelow = new List<int>();
			while (stack.Count > 0)
			{
				TreeElement current = stack.Pop();
				if (current.hasChildren)
				{
					parentsBelow.Add(current.id);
					foreach (var T in current.children)
					{
						stack.Push(T);
					}
				}
			}

			return parentsBelow;
		}

		public void RemoveElements (IList<T> elements)
		{
			foreach (var element in elements)
				if (element == m_Root)
					throw new ArgumentException("It is not allowed to remove the root element");
		
			var commonAncestors = TreeElementUtility.FindCommonAncestorsWithinList (elements);

			foreach (var element in commonAncestors)
			{
				element.parent.children.Remove (element);
				element.parent = null;
			}

			TreeElementUtility.TreeToList(m_Root, m_Data);

			Changed();
		}

		void Changed ()
		{
			if (modelChanged != null)
				modelChanged ();
		}
	}
}
