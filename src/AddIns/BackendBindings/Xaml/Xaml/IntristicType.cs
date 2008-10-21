﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Markup;

namespace ICSharpCode.Xaml
{
	public class IntristicType : XamlType
	{
		public static XName CodeName = XamlConstants.XamlNamespace + "Code";
		public static XName XDataName = XamlConstants.XamlNamespace + "XData";

		public static XamlType Code = new IntristicType();
		public static XamlType XData = new IntristicType();

		public static XamlType String = ReflectionMapper.GetXamlType(typeof(string));
		public static XamlType MarkupExtension = ReflectionMapper.GetXamlType(typeof(MarkupExtension));

		public override string Name
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsDefaultConstructible
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsNullable
		{
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<XamlMember> Members
		{
			get { throw new NotImplementedException(); }
		}

		public override XamlMember ContentProperty
		{
			get { throw new NotImplementedException(); }
		}

		public override XamlMember DictionaryKeyProperty
		{
			get { throw new NotImplementedException(); }
		}

		public override XamlMember NameProperty
		{
			get { throw new NotImplementedException(); }
		}

		public override XamlMember XmlLangProperty
		{
			get { throw new NotImplementedException(); }
		}

		public override bool TrimSurroundingWhitespace
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsWhitespaceSignificantCollection
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsCollection
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsDictionary
		{
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<XamlType> AllowedTypes
		{
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<XamlType> AllowedKeyTypes
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsXData
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsNameScope
		{
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<Constructor> Constructors
		{
			get { throw new NotImplementedException(); }
		}

		public override XamlType ReturnValueType
		{
			get { throw new NotImplementedException(); }
		}

		public override string Namespace
		{
			get { throw new NotImplementedException(); }
		}

		public override XamlAssembly Assembly
		{
			get { throw new NotImplementedException(); }
		}

		public override XamlMember Member(string name)
		{
			throw new NotImplementedException();
		}

		public override bool IsAssignableFrom(XamlType type)
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<XamlType> ContentWrappers
		{
			get { throw new NotImplementedException(); }
		}

		public override bool HasTextSyntax
		{
			get { throw new NotImplementedException(); }
		}

		public override Type SystemType
		{
			get { return null; }
		}

		public override T GetAttribute<T>()
		{
			throw new NotImplementedException();
		}
	}
}
